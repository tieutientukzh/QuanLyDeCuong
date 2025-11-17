using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDeCuong
{
    public partial class AdminForm : Form
    {
        // Biến lưu trữ UserID và GiangVienID đang được chọn trong dgvGiangVien
        private int selectedUserId = 0;
        private int selectedGiangVienId = 0;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadGiangVienData();
        }

        private void LoadGiangVienData()
        {
            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                string query = "SELECT g.GiangVienID, u.UserID, u.FullName, g.Email, u.Username, u.Password FROM GiangVien g JOIN [User] u ON g.UserID = u.UserID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    dgvGiangVien.DataSource = dt;

                    // Ẩn các cột không cần thiết
                    dgvGiangVien.Columns["UserID"].Visible = false;
                    dgvGiangVien.Columns["GiangVienID"].Visible = false;
                    dgvGiangVien.Columns["Password"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách giảng viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGiangVien.Rows[e.RowIndex];
                selectedGiangVienId = Convert.ToInt32(row.Cells["GiangVienID"].Value);
                selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);

                txtGvFullName.Text = row.Cells["FullName"].Value.ToString();
                txtGvEmail.Text = row.Cells["Email"].Value.ToString();
                txtGvUsername.Text = row.Cells["Username"].Value.ToString();
                txtGvPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void btnAddGv_Click(object sender, EventArgs e)
        {
            string fullName = txtGvFullName.Text.Trim();
            string email = txtGvEmail.Text.Trim();
            string username = txtGvUsername.Text.Trim();
            string password = txtGvPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    // Kiểm tra Username đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn, transaction);
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // 1. Thêm vào bảng User
                    cmd.CommandText = "INSERT INTO [User] (Username, Password, FullName, Role) OUTPUT INSERTED.UserID VALUES (@Username, @Password, @FullName, 'GiangVien')";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@FullName", fullName);

                    int newUserId = (int)cmd.ExecuteScalar();

                    // 2. Thêm vào bảng GiangVien
                    cmd.CommandText = "INSERT INTO GiangVien (Email, UserID) VALUES (@Email, @UserID)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserID", newUserId);
                    cmd.ExecuteNonQuery();

                    // 3. Commit
                    transaction.Commit();
                    MessageBox.Show("Thêm giảng viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGiangVienData();
                    ClearGvInputs();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Thêm giảng viên thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditGv_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn một giảng viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtGvFullName.Text.Trim();
            string email = txtGvEmail.Text.Trim();
            string username = txtGvUsername.Text.Trim();
            string password = txtGvPassword.Text.Trim();

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    // Kiểm tra Username đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // 1. Cập nhật bảng User
                    cmd.CommandText = "UPDATE [User] SET Username = @Username, Password = @Password, FullName = @FullName WHERE UserID = @UserID";
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@UserID", selectedUserId);
                    cmd.ExecuteNonQuery();

                    // 2. Cập nhật bảng GiangVien
                    cmd.CommandText = "UPDATE GiangVien SET Email = @Email WHERE GiangVienID = @GiangVienID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@GiangVienID", selectedGiangVienId);
                    cmd.ExecuteNonQuery();

                    // 3. Commit
                    transaction.Commit();
                    MessageBox.Show("Cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGiangVienData();
                    ClearGvInputs();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Cập nhật thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteGv_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn một giảng viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên này? TOÀN BỘ đề cương của họ cũng sẽ bị xóa.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    // 1. Xóa đề cương (Theo yêu cầu)
                    cmd.CommandText = "DELETE FROM DeCuong WHERE GiangVienID = @GiangVienID";
                    cmd.Parameters.AddWithValue("@GiangVienID", selectedGiangVienId);
                    cmd.ExecuteNonQuery();

                    // 2. Xóa giảng viên
                    cmd.CommandText = "DELETE FROM GiangVien WHERE GiangVienID = @GiangVienID";
                    cmd.ExecuteNonQuery();

                    // 3. Xóa User
                    cmd.CommandText = "DELETE FROM [User] WHERE UserID = @UserID";
                    cmd.Parameters.AddWithValue("@UserID", selectedUserId);
                    cmd.ExecuteNonQuery();

                    // 4. Commit
                    transaction.Commit();
                    MessageBox.Show("Xóa giảng viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGiangVienData();
                    ClearGvInputs();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Xóa thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearGvInputs()
        {
            txtGvFullName.Text = "";
            txtGvEmail.Text = "";
            txtGvUsername.Text = "";
            txtGvPassword.Text = "";
            selectedUserId = 0;
            selectedGiangVienId = 0;
        }

        // --- Tab Báo cáo ---

        private void btnReportByCourse_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT m.TenMonHoc, COUNT(d.DeCuongID) AS SoLuongDeCuong
                FROM MonHoc m
                LEFT JOIN DeCuong d ON m.MonHocID = d.MonHocID
                GROUP BY m.TenMonHoc
                ORDER BY m.TenMonHoc";

            LoadReport(query);
        }

        private void btnReportByLecturer_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT u.FullName, COUNT(d.DeCuongID) AS SoLuongDeCuong
                FROM GiangVien g
                JOIN [User] u ON g.UserID = u.UserID
                LEFT JOIN DeCuong d ON g.GiangVienID = d.GiangVienID
                GROUP BY u.FullName
                ORDER BY u.FullName";

            LoadReport(query);
        }

        private void LoadReport(string query)
        {
            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    dgvReport.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Logic xuất file (ví dụ: CSV)
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = "BaoCao.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // Add header
                    for (int i = 0; i < dgvReport.Columns.Count; i++)
                    {
                        sb.Append(dgvReport.Columns[i].HeaderText);
                        if (i < dgvReport.Columns.Count - 1) sb.Append(";");
                    }
                    sb.AppendLine();

                    // Add rows
                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        for (int i = 0; i < dgvReport.Columns.Count; i++)
                        {
                            string cellValue = row.Cells[i].Value?.ToString() ?? "";
                            sb.Append(cellValue);
                            if (i < dgvReport.Columns.Count - 1) sb.Append(";");
                        }
                        sb.AppendLine();
                    }

                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
