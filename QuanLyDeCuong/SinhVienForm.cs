using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyDeCuong
{
    public partial class SinhVienForm : Form
    {
        public SinhVienForm()
        {
            InitializeComponent();
            this.Text = "Sinh viên - " + CurrentUser.Username;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void SinhVienForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Chào mừng, " + CurrentUser.FullName;
            LoadDeCuongGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadDeCuongGrid(searchTerm);
        }

        private void LoadDeCuongGrid(string searchTerm = "")
        {
            string query = @"
                SELECT m.TenMonHoc as 'Tên môn học', u.FullName AS 'Tên giảng viên', d.Link, d.HocKy as 'Học kỳ', d.NgayCapNhat as 'Ngày cập nhật'
                FROM DeCuong d
                JOIN MonHoc m ON d.MonHocID = m.MonHocID
                JOIN GiangVien g ON d.GiangVienID = g.GiangVienID
                JOIN [User] u ON g.UserID = u.UserID
                ORDER BY m.TenMonHoc";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE m.TenMonHoc LIKE @SearchTerm OR u.FullName LIKE @SearchTerm";
            }

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
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
                    dgvDeCuong.RowHeadersVisible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDeCuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDeCuong.Rows.Count - 1)
            {
                DataGridViewRow row = dgvDeCuong.Rows[e.RowIndex];
                string link = row.Cells["Link"].Value.ToString();
                txtLink.Text = link;
            }
        }

        private void btnCopyLink_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLink.Text))
            {
                Clipboard.SetText(txtLink.Text);
                MessageBox.Show("Đã sao chép link vào clipboard!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có link để sao chép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.ShowDialog();
        }
    }
}
