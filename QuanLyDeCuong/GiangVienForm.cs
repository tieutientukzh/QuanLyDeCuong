using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDeCuong
{
    public partial class GiangVienForm : Form
    {
        private int currentGiangVienID = 0;
        private int selectedDeCuongID = 0;
        public GiangVienForm()
        {
            InitializeComponent();
            currentGiangVienID = CurrentUser.GiangVienID;
        }
        private void GiangVienForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Chào mừng, " + CurrentUser.FullName;

            if (currentGiangVienID == 0)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin giảng viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadMonHocComboBox();
            LoadDeCuongGrid();
        }

        private void LoadMonHocComboBox()
        {
            string query = @"
                SELECT MonHocID, TenMonHoc 
                FROM MonHoc";

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    cmbMonHoc.DataSource = dt;
                    cmbMonHoc.DisplayMember = "TenMonHoc";
                    cmbMonHoc.ValueMember = "MonHocID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDeCuongGrid(string searchTerm = "")
        {
            string query = @"
                SELECT d.DeCuongID, m.TenMonHoc, d.Link, d.MonHocID 
                FROM DeCuong d 
                JOIN MonHoc m ON d.MonHocID = m.MonHocID 
                WHERE d.GiangVienID = @GiangVienID";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " AND m.TenMonHoc LIKE @SearchTerm";
            }

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GiangVienID", currentGiangVienID);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    dgvDeCuong.DataSource = dt;

                    // Ẩn các cột ID
                    dgvDeCuong.Columns["DeCuongID"].Visible = false;
                    dgvDeCuong.Columns["MonHocID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải đề cương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDeCuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDeCuong.Rows[e.RowIndex];
                selectedDeCuongID = Convert.ToInt32(row.Cells["DeCuongID"].Value);
                txtLink.Text = row.Cells["Link"].Value.ToString();

                // Set ComboBox
                int monHocID = Convert.ToInt32(row.Cells["MonHocID"].Value);
                cmbMonHoc.SelectedValue = monHocID;
            }
        }

        private void btnAddDeCuong_Click(object sender, EventArgs e)
        {
            int monHocID = (int)cmbMonHoc.SelectedValue;
            string link = txtLink.Text.Trim();

            if (string.IsNullOrEmpty(link))
            {
                MessageBox.Show("Vui lòng nhập link đề cương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO DeCuong (GiangVienID, MonHocID, Link) VALUES (@GiangVienID, @MonHocID, @Link)";

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GiangVienID", currentGiangVienID);
                cmd.Parameters.AddWithValue("@MonHocID", monHocID);
                cmd.Parameters.AddWithValue("@Link", link);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm đề cương thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeCuongGrid();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditDeCuong_Click(object sender, EventArgs e)
        {
            if (selectedDeCuongID == 0)
            {
                MessageBox.Show("Vui lòng chọn đề cương để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int monHocID = (int)cmbMonHoc.SelectedValue;
            string link = txtLink.Text.Trim();

            string query = "UPDATE DeCuong SET MonHocID = @MonHocID, Link = @Link WHERE DeCuongID = @DeCuongID AND GiangVienID = @GiangVienID";

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MonHocID", monHocID);
                cmd.Parameters.AddWithValue("@Link", link);
                cmd.Parameters.AddWithValue("@DeCuongID", selectedDeCuongID);
                cmd.Parameters.AddWithValue("@GiangVienID", currentGiangVienID);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDeCuongGrid();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đề cương để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteDeCuong_Click(object sender, EventArgs e)
        {
            if (selectedDeCuongID == 0)
            {
                MessageBox.Show("Vui lòng chọn đề cương để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa đề cương này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            string query = "DELETE FROM DeCuong WHERE DeCuongID = @DeCuongID AND GiangVienID = @GiangVienID";

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DeCuongID", selectedDeCuongID);
                cmd.Parameters.AddWithValue("@GiangVienID", currentGiangVienID);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDeCuongGrid();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đề cương để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadDeCuongGrid(searchTerm);
        }

        private void ClearInputs()
        {
            txtLink.Text = "";
            cmbMonHoc.SelectedIndex = 0;
            selectedDeCuongID = 0;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
