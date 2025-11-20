namespace QuanLyDeCuong
{
    partial class DoiMatKhau
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
            btnSave = new Button();
            btnCancel = new Button();
            txtOldPass = new TextBox();
            txtNewPass = new TextBox();
            txtConfirmPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(94, 240);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(118, 44);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(304, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 44);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Thoát";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtOldPass
            // 
            txtOldPass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOldPass.Location = new Point(242, 48);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.Size = new Size(254, 30);
            txtOldPass.TabIndex = 2;
            // 
            // txtNewPass
            // 
            txtNewPass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPass.Location = new Point(242, 108);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(256, 30);
            txtNewPass.TabIndex = 3;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPass.Location = new Point(242, 167);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(256, 30);
            txtConfirmPass.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 51);
            label1.Name = "label1";
            label1.Size = new Size(156, 23);
            label1.TabIndex = 5;
            label1.Text = "Nhập mật khẩu cũ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(45, 111);
            label2.Name = "label2";
            label2.Size = new Size(167, 23);
            label2.TabIndex = 6;
            label2.Text = "Nhập mật khẩu mới:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(45, 174);
            label3.Name = "label3";
            label3.Size = new Size(189, 23);
            label3.TabIndex = 7;
            label3.Text = "Nhập lại mật khẩu mới:";
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 315);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtConfirmPass);
            Controls.Add(txtNewPass);
            Controls.Add(txtOldPass);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "DoiMatKhau";
            Text = "DoiMatKhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private TextBox txtOldPass;
        private TextBox txtNewPass;
        private TextBox txtConfirmPass;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}