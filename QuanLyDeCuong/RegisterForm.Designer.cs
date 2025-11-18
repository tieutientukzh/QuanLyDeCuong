namespace QuanLyDeCuong
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            btnRegisterSubmit = new Button();
            txtRegConfirmPassword = new TextBox();
            txtRegUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            lbDangKy = new Label();
            label4 = new Label();
            txtRegPassword = new TextBox();
            label5 = new Label();
            txtRegFullName = new TextBox();
            label6 = new Label();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(273, 455);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(146, 43);
            btnLogin.TabIndex = 18;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegisterSubmit
            // 
            btnRegisterSubmit.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegisterSubmit.Location = new Point(104, 315);
            btnRegisterSubmit.Margin = new Padding(3, 4, 3, 4);
            btnRegisterSubmit.Name = "btnRegisterSubmit";
            btnRegisterSubmit.Size = new Size(315, 47);
            btnRegisterSubmit.TabIndex = 17;
            btnRegisterSubmit.Text = "Đăng ký";
            btnRegisterSubmit.UseVisualStyleBackColor = true;
            btnRegisterSubmit.Click += btnRegisterSubmit_Click;
            // 
            // txtRegConfirmPassword
            // 
            txtRegConfirmPassword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegConfirmPassword.Location = new Point(235, 261);
            txtRegConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtRegConfirmPassword.Name = "txtRegConfirmPassword";
            txtRegConfirmPassword.Size = new Size(273, 30);
            txtRegConfirmPassword.TabIndex = 16;
            txtRegConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtRegUsername
            // 
            txtRegUsername.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegUsername.Location = new Point(235, 75);
            txtRegUsername.Margin = new Padding(3, 4, 3, 4);
            txtRegUsername.Name = "txtRegUsername";
            txtRegUsername.Size = new Size(273, 30);
            txtRegUsername.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 266);
            label3.Name = "label3";
            label3.Size = new Size(174, 25);
            label3.TabIndex = 11;
            label3.Text = "Nhập lại mật khẩu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 10;
            label2.Text = "Tài khoản:";
            // 
            // lbDangKy
            // 
            lbDangKy.AutoSize = true;
            lbDangKy.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDangKy.Location = new Point(117, 9);
            lbDangKy.Name = "lbDangKy";
            lbDangKy.Size = new Size(302, 32);
            lbDangKy.TabIndex = 9;
            lbDangKy.Text = "ĐĂNG KÍ TÀI KHOẢN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(104, 466);
            label4.Name = "label4";
            label4.Size = new Size(134, 20);
            label4.TabIndex = 12;
            label4.Text = "Đã có tài khoản?";
            // 
            // txtRegPassword
            // 
            txtRegPassword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegPassword.Location = new Point(235, 200);
            txtRegPassword.Margin = new Padding(3, 4, 3, 4);
            txtRegPassword.Name = "txtRegPassword";
            txtRegPassword.Size = new Size(273, 30);
            txtRegPassword.TabIndex = 15;
            txtRegPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 200);
            label5.Name = "label5";
            label5.Size = new Size(99, 25);
            label5.TabIndex = 18;
            label5.Text = "Mật khẩu:";
            // 
            // txtRegFullName
            // 
            txtRegFullName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegFullName.Location = new Point(235, 136);
            txtRegFullName.Margin = new Padding(3, 4, 3, 4);
            txtRegFullName.Name = "txtRegFullName";
            txtRegFullName.Size = new Size(273, 30);
            txtRegFullName.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 136);
            label6.Name = "label6";
            label6.Size = new Size(117, 25);
            label6.TabIndex = 20;
            label6.Text = "Tên đầy đủ:";
            // 
            // button1
            // 
            button1.Location = new Point(273, 398);
            button1.Name = "button1";
            button1.Size = new Size(146, 40);
            button1.TabIndex = 21;
            button1.Text = "Quên mật khẩu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 408);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 22;
            label1.Text = "Không nhớ mật khẩu?";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(541, 529);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtRegFullName);
            Controls.Add(label6);
            Controls.Add(txtRegPassword);
            Controls.Add(label5);
            Controls.Add(btnLogin);
            Controls.Add(btnRegisterSubmit);
            Controls.Add(txtRegConfirmPassword);
            Controls.Add(txtRegUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbDangKy);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RegisterForm";
            Text = "RegisterForm";
            FormClosed += RegisterForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegisterSubmit;
        private System.Windows.Forms.TextBox txtRegConfirmPassword;
        private System.Windows.Forms.TextBox txtRegUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDangKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRegFullName;
        private System.Windows.Forms.Label label6;
        private Button button1;
        private Label label1;
    }
}