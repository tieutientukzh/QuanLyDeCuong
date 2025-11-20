namespace QuanLyDeCuong
{
    partial class SinhVienForm
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
            txtSearch = new TextBox();
            txtLink = new TextBox();
            btnSearch = new Button();
            btnCopyLink = new Button();
            dgvDeCuong = new DataGridView();
            lblWelcome = new Label();
            label2 = new Label();
            label3 = new Label();
            btnLogout = new Button();
            btnChangePass = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDeCuong).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(167, 111);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(521, 30);
            txtSearch.TabIndex = 0;
            // 
            // txtLink
            // 
            txtLink.Enabled = false;
            txtLink.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLink.Location = new Point(167, 201);
            txtLink.Margin = new Padding(3, 4, 3, 4);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(521, 30);
            txtLink.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(724, 98);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 58);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCopyLink
            // 
            btnCopyLink.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCopyLink.Location = new Point(724, 193);
            btnCopyLink.Margin = new Padding(3, 4, 3, 4);
            btnCopyLink.Name = "btnCopyLink";
            btnCopyLink.Size = new Size(105, 51);
            btnCopyLink.TabIndex = 3;
            btnCopyLink.Text = "Copy";
            btnCopyLink.UseVisualStyleBackColor = true;
            btnCopyLink.Click += btnCopyLink_Click;
            // 
            // dgvDeCuong
            // 
            dgvDeCuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeCuong.ColumnHeadersHeight = 29;
            dgvDeCuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDeCuong.Location = new Point(20, 285);
            dgvDeCuong.Margin = new Padding(3, 4, 3, 4);
            dgvDeCuong.Name = "dgvDeCuong";
            dgvDeCuong.RowHeadersWidth = 100;
            dgvDeCuong.RowTemplate.Height = 24;
            dgvDeCuong.Size = new Size(878, 308);
            dgvDeCuong.TabIndex = 4;
            dgvDeCuong.CellClick += dgvDeCuong_CellClick;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(229, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(30, 25);
            lblWelcome.TabIndex = 5;
            lblWelcome.Text = "Hi";
            lblWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(64, 111);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 6;
            label2.Text = "Tìm kiếm:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(64, 205);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 7;
            label3.Text = "Link:";
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(790, 13);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(108, 45);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnChangePass
            // 
            btnChangePass.Location = new Point(652, 13);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(121, 45);
            btnChangePass.TabIndex = 9;
            btnChangePass.Text = "Đổi mật khẩu";
            btnChangePass.UseVisualStyleBackColor = true;
            btnChangePass.Click += btnChangePass_Click;
            // 
            // SinhVienForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 608);
            Controls.Add(btnChangePass);
            Controls.Add(btnLogout);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblWelcome);
            Controls.Add(dgvDeCuong);
            Controls.Add(btnCopyLink);
            Controls.Add(btnSearch);
            Controls.Add(txtLink);
            Controls.Add(txtSearch);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SinhVienForm";
            Text = "SinhVienForm";
            Load += SinhVienForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDeCuong).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCopyLink;
        private System.Windows.Forms.DataGridView dgvDeCuong;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogout;
        private Button btnChangePass;
    }
}