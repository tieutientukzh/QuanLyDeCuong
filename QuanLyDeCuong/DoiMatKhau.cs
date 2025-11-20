using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace QuanLyDeCuong
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
            this.Text = "Đổi Mật Khẩu - " + CurrentUser.Username;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass.Length < 3)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 3 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = KetNoiCSDL.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 2. Kiểm tra mật khẩu cũ có đúng không
                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE UserID = @UserID AND Password = @Password";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID);
                    checkCmd.Parameters.AddWithValue("@Password", oldPass);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. Cập nhật mật khẩu mới
                    string updateQuery = "UPDATE [User] SET Password = @NewPassword WHERE UserID = @UserID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@NewPassword", newPass);
                    updateCmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID);

                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
