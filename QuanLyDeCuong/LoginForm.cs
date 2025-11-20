using Microsoft.Data.SqlClient;

namespace QuanLyDeCuong
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                string query = "SELECT UserID, FullName, Role FROM [User] WHERE Username = @Username AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lưu thông tin người dùng
                        CurrentUser.UserID = Convert.ToInt32(reader["UserID"]);
                        CurrentUser.Username = username;
                        CurrentUser.FullName = reader["FullName"].ToString();
                        CurrentUser.Role = reader["Role"].ToString();

                        reader.Close();

                        // Nếu là giảng viên, lấy luôn GiangVienID
                        if (CurrentUser.Role == "GiangVien")
                        {
                            string gvQuery = "SELECT GiangVienID FROM GiangVien WHERE UserID = @UserID";
                            SqlCommand gvCmd = new SqlCommand(gvQuery, conn);
                            gvCmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID);
                            object gvId = gvCmd.ExecuteScalar();
                            if (gvId != null)
                            {
                                CurrentUser.GiangVienID = Convert.ToInt32(gvId);
                            }
                        }

                        // Ẩn form login
                        this.Hide();

                        // Mở form tương ứng
                        switch (CurrentUser.Role)
                        {
                            case "Admin":
                                AdminForm adminForm = new AdminForm();
                                adminForm.ShowDialog();
                                break;
                            case "GiangVien":
                                GiangVienForm gvForm = new GiangVienForm();
                                gvForm.ShowDialog();
                                break;
                            case "SinhVien":
                                SinhVienForm svForm = new SinhVienForm();
                                svForm.ShowDialog();
                                break;
                            default:
                                MessageBox.Show("Vai trò người dùng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                                CurrentUser.Clear();
                                return;
                        }

                        // Sau khi form kia đóng, đóng form login
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Close();
        }
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            QuenMatKhau fp = new QuenMatKhau();
            this.Hide();
            fp.ShowDialog();
            this.Close();
        }
    }
}
