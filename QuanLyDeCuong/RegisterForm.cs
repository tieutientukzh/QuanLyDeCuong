using Microsoft.Data.SqlClient;

namespace QuanLyDeCuong
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegisterSubmit_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.Text.Trim();
            string password = txtRegPassword.Text.Trim();
            string confirmPassword = txtRegConfirmPassword.Text.Trim();
            string fullName = txtRegFullName.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin (Tên đăng nhập, Mật khẩu, Họ tên).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Kiểm tra username đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Thêm user mới
                    string insertQuery = "INSERT INTO [User] (Username, Password, FullName, Role) VALUES (@Username, @Password, @FullName, 'SinhVien')";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@Username", username);
                    insertCmd.Parameters.AddWithValue("@Password", password);
                    insertCmd.Parameters.AddWithValue("@FullName", fullName);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Đăng ký tài khoản sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đăng ký thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuenMatKhau fp = new QuenMatKhau();
            this.Hide();
            fp.ShowDialog();    
            this.Close();
        }
    }
}
