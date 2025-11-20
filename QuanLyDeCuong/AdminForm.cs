using System.Data;
using Microsoft.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

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

        private void LoadGiangVienData(string searchTerm = "")
        {
            string query = "SELECT g.GiangVienID, u.UserID, u.FullName as 'Tên giảng viên', g.Email, u.Username, u.Password FROM GiangVien g JOIN [User] u ON g.UserID = u.UserID";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE u.FullName LIKE @SearchTerm OR g.Email LIKE @SearchTerm";
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
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn, transaction);
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 1)
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
                SELECT m.TenMonHoc as 'Tên môn học', d.Link
                FROM MonHoc m
                LEFT JOIN DeCuong d ON m.MonHocID = d.MonHocID
                WHERE d.Link != ''
                ORDER BY m.TenMonHoc";

            LoadReport(query);
        }

        private void btnReportByLecturer_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT u.FullName as 'Tên giảng viên', COUNT(d.DeCuongID) AS 'Số lượng đề cương'
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
                MessageBox.Show("Không có dữ liệu để in/xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application exApp = null;
            Excel.Workbook exBook = null;
            Excel.Worksheet exSheet = null;

            try
            {
                // Khởi tạo Excel
                exApp = new Excel.Application();
                exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                // 1. Định dạng tiêu đề chung
                // Hàng 1: Tên hệ thống
                Excel.Range qldc = (Excel.Range)exSheet.Cells[1, 1];
                qldc.Font.Size = 12;
                qldc.Font.Bold = true;
                qldc.Font.Color = Color.Blue;
                qldc.Value = "HỆ THỐNG QUẢN LÝ ĐỀ CƯƠNG MÔN HỌC";
                // Merge vài cột để nhìn đẹp hơn
                exSheet.Range["A1:D1"].Merge();

                // Hàng 2: Người thực hiện báo cáo
                Excel.Range nguoiBaoCao = (Excel.Range)exSheet.Cells[2, 1];
                nguoiBaoCao.Font.Size = 11;
                nguoiBaoCao.Font.Bold = false;
                nguoiBaoCao.Value = "Người xuất báo cáo: " + (CurrentUser.FullName ?? "Admin");
                exSheet.Range["A2:D2"].Merge();

                // Hàng 4: Tiêu đề báo cáo
                Excel.Range header = (Excel.Range)exSheet.Cells[4, 2];
                exSheet.Range["A4:D4"].Merge();
                exSheet.Range["A4"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                header = exSheet.Range["A4"]; // Trỏ lại vào ô đã merge
                header.Font.Size = 14;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "BÁO CÁO THỐNG KÊ SỐ LIỆU";

                // 2. Định dạng tiêu đề cột (Bắt đầu từ dòng 6)
                int headerRow = 6;
                // Cột STT
                exSheet.Cells[headerRow, 1] = "STT";
                ((Excel.Range)exSheet.Cells[headerRow, 1]).Font.Bold = true;
                ((Excel.Range)exSheet.Cells[headerRow, 1]).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Các cột dữ liệu lấy từ DataGridView
                for (int i = 0; i < dgvReport.Columns.Count; i++)
                {
                    // Cột Excel bắt đầu từ 2 (vì 1 là STT)
                    Excel.Range colHeader = (Excel.Range)exSheet.Cells[headerRow, i + 2];
                    colHeader.Value = dgvReport.Columns[i].HeaderText;
                    colHeader.Font.Bold = true;
                    colHeader.ColumnWidth = 25;
                    colHeader.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    colHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                // 3. Đổ dữ liệu
                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    // Bỏ qua dòng trống cuối cùng của DataGridView (nếu có)
                    if (dgvReport.Rows[i].IsNewRow) continue;

                    int currentRow = headerRow + 1 + i;

                    // Ghi STT
                    Excel.Range cellSTT = (Excel.Range)exSheet.Cells[currentRow, 1];
                    cellSTT.Value = i + 1;
                    cellSTT.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    cellSTT.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    // Ghi dữ liệu các cột
                    for (int j = 0; j < dgvReport.Columns.Count; j++)
                    {
                        Excel.Range cellData = (Excel.Range)exSheet.Cells[currentRow, j + 2];
                        if (dgvReport.Rows[i].Cells[j].Value != null)
                        {
                            cellData.Value = dgvReport.Rows[i].Cells[j].Value.ToString();
                        }
                        cellData.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }

                // Đặt tên sheet
                exSheet.Name = "BaoCao";

                // 4. Lưu file
                exBook.Activate();
                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "Excel Document(*.xlsx)|*.xlsx|Excel 97-2003(*.xls)|*.xls";
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xlsx";

                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    exBook.SaveAs(dlgSave.FileName);
                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    exApp.Visible = true;
                }
                else
                {
                    exBook.Close(false);
                    exApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất Excel: " + ex.Message + "\n\nHãy đảm bảo máy tính đã cài Microsoft Office.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Dọn dẹp nếu lỗi
                if (exBook != null) exBook.Close(false);
                if (exApp != null) exApp.Quit();
            }
            finally
            {
                // Giải phóng tài nguyên COM để tránh ứng dụng Excel chạy ngầm
                if (exSheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(exSheet);
                if (exBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                if (exApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
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

        private void btnGvSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtGv.Text.Trim();
            LoadGiangVienData(searchTerm);
        }
    }
}
