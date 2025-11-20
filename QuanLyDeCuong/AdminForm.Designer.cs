namespace QuanLyDeCuong
{
    partial class AdminForm
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
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnGvSearch = new Button();
            txtGv = new TextBox();
            label6 = new Label();
            btnDeleteGv = new Button();
            btnEditGv = new Button();
            btnAddGv = new Button();
            dgvGiangVien = new DataGridView();
            txtGvPassword = new TextBox();
            label5 = new Label();
            txtGvUsername = new TextBox();
            txtGvEmail = new TextBox();
            txtGvFullName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tabPage2 = new TabPage();
            btnReportGv = new Button();
            btnReportByLecturer = new Button();
            btnReportByCourse = new Button();
            btnExport = new Button();
            dgvReport = new DataGridView();
            btnLogout = new Button();
            btnChangePass = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(928, 245);
            label1.Name = "label1";
            label1.Size = new Size(87, 18);
            label1.TabIndex = 0;
            label1.Text = "Hello Admin";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(910, 722);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnGvSearch);
            tabPage1.Controls.Add(txtGv);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(btnDeleteGv);
            tabPage1.Controls.Add(btnEditGv);
            tabPage1.Controls.Add(btnAddGv);
            tabPage1.Controls.Add(dgvGiangVien);
            tabPage1.Controls.Add(txtGvPassword);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtGvUsername);
            tabPage1.Controls.Add(txtGvEmail);
            tabPage1.Controls.Add(txtGvFullName);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 27);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(902, 691);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quản lý giảng viên";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGvSearch
            // 
            btnGvSearch.Location = new Point(656, 151);
            btnGvSearch.Name = "btnGvSearch";
            btnGvSearch.Size = new Size(94, 38);
            btnGvSearch.TabIndex = 6;
            btnGvSearch.Text = "Tìm kiếm";
            btnGvSearch.UseVisualStyleBackColor = true;
            btnGvSearch.Click += btnGvSearch_Click;
            // 
            // txtGv
            // 
            txtGv.Location = new Point(128, 158);
            txtGv.Name = "txtGv";
            txtGv.Size = new Size(502, 24);
            txtGv.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 163);
            label6.Name = "label6";
            label6.Size = new Size(73, 18);
            label6.TabIndex = 12;
            label6.Text = "Tìm kiếm:";
            // 
            // btnDeleteGv
            // 
            btnDeleteGv.Location = new Point(651, 87);
            btnDeleteGv.Margin = new Padding(3, 4, 3, 4);
            btnDeleteGv.Name = "btnDeleteGv";
            btnDeleteGv.Size = new Size(99, 37);
            btnDeleteGv.TabIndex = 11;
            btnDeleteGv.Text = "Xóa";
            btnDeleteGv.UseVisualStyleBackColor = true;
            btnDeleteGv.Click += btnDeleteGv_Click;
            // 
            // btnEditGv
            // 
            btnEditGv.Location = new Point(769, 32);
            btnEditGv.Margin = new Padding(3, 4, 3, 4);
            btnEditGv.Name = "btnEditGv";
            btnEditGv.Size = new Size(100, 37);
            btnEditGv.TabIndex = 10;
            btnEditGv.Text = "Sửa";
            btnEditGv.UseVisualStyleBackColor = true;
            btnEditGv.Click += btnEditGv_Click;
            // 
            // btnAddGv
            // 
            btnAddGv.Location = new Point(651, 32);
            btnAddGv.Margin = new Padding(3, 4, 3, 4);
            btnAddGv.Name = "btnAddGv";
            btnAddGv.Size = new Size(99, 37);
            btnAddGv.TabIndex = 9;
            btnAddGv.Text = "Thêm";
            btnAddGv.UseVisualStyleBackColor = true;
            btnAddGv.Click += btnAddGv_Click;
            // 
            // dgvGiangVien
            // 
            dgvGiangVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiangVien.ColumnHeadersHeight = 29;
            dgvGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGiangVien.Location = new Point(34, 211);
            dgvGiangVien.Margin = new Padding(3, 4, 3, 4);
            dgvGiangVien.Name = "dgvGiangVien";
            dgvGiangVien.RowHeadersWidth = 51;
            dgvGiangVien.RowTemplate.Height = 24;
            dgvGiangVien.Size = new Size(835, 445);
            dgvGiangVien.TabIndex = 8;
            dgvGiangVien.CellClick += dgvGiangVien_CellClick;
            // 
            // txtGvPassword
            // 
            txtGvPassword.Location = new Point(459, 100);
            txtGvPassword.Margin = new Padding(3, 4, 3, 4);
            txtGvPassword.Name = "txtGvPassword";
            txtGvPassword.Size = new Size(171, 24);
            txtGvPassword.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(380, 106);
            label5.Name = "label5";
            label5.Size = new Size(73, 18);
            label5.TabIndex = 6;
            label5.Text = "Mật khẩu:";
            // 
            // txtGvUsername
            // 
            txtGvUsername.Location = new Point(459, 38);
            txtGvUsername.Margin = new Padding(3, 4, 3, 4);
            txtGvUsername.Name = "txtGvUsername";
            txtGvUsername.Size = new Size(171, 24);
            txtGvUsername.TabIndex = 3;
            // 
            // txtGvEmail
            // 
            txtGvEmail.Location = new Point(128, 100);
            txtGvEmail.Margin = new Padding(3, 4, 3, 4);
            txtGvEmail.Name = "txtGvEmail";
            txtGvEmail.Size = new Size(233, 24);
            txtGvEmail.TabIndex = 2;
            // 
            // txtGvFullName
            // 
            txtGvFullName.Location = new Point(128, 38);
            txtGvFullName.Margin = new Padding(3, 4, 3, 4);
            txtGvFullName.Name = "txtGvFullName";
            txtGvFullName.Size = new Size(233, 24);
            txtGvFullName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(376, 41);
            label4.Name = "label4";
            label4.Size = new Size(77, 18);
            label4.TabIndex = 2;
            label4.Text = "Tài khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 106);
            label3.Name = "label3";
            label3.Size = new Size(49, 18);
            label3.TabIndex = 1;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 41);
            label2.Name = "label2";
            label2.Size = new Size(62, 18);
            label2.TabIndex = 0;
            label2.Text = "Tên GV:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnReportGv);
            tabPage2.Controls.Add(btnReportByLecturer);
            tabPage2.Controls.Add(btnReportByCourse);
            tabPage2.Controls.Add(btnExport);
            tabPage2.Controls.Add(dgvReport);
            tabPage2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 27);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(902, 691);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Báo cáo";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReportGv
            // 
            btnReportGv.Location = new Point(759, 293);
            btnReportGv.Name = "btnReportGv";
            btnReportGv.Size = new Size(109, 73);
            btnReportGv.TabIndex = 14;
            btnReportGv.Text = "Danh sách giảng viên";
            btnReportGv.UseVisualStyleBackColor = true;
            btnReportGv.Click += btnReportGv_Click;
            // 
            // btnReportByLecturer
            // 
            btnReportByLecturer.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportByLecturer.Location = new Point(759, 211);
            btnReportByLecturer.Margin = new Padding(3, 4, 3, 4);
            btnReportByLecturer.Name = "btnReportByLecturer";
            btnReportByLecturer.Size = new Size(109, 64);
            btnReportByLecturer.TabIndex = 3;
            btnReportByLecturer.Text = "Xuất báo cáo theo giảng viên";
            btnReportByLecturer.UseVisualStyleBackColor = true;
            btnReportByLecturer.Click += btnReportByLecturer_Click;
            // 
            // btnReportByCourse
            // 
            btnReportByCourse.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportByCourse.Location = new Point(759, 111);
            btnReportByCourse.Margin = new Padding(3, 4, 3, 4);
            btnReportByCourse.Name = "btnReportByCourse";
            btnReportByCourse.Size = new Size(109, 68);
            btnReportByCourse.TabIndex = 2;
            btnReportByCourse.Text = "Xuất báo cáo theo môn";
            btnReportByCourse.UseVisualStyleBackColor = true;
            btnReportByCourse.Click += btnReportByCourse_Click;
            // 
            // btnExport
            // 
            btnExport.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExport.Location = new Point(759, 21);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(109, 64);
            btnExport.TabIndex = 1;
            btnExport.Text = "Xuất báo cáo";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // dgvReport
            // 
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ColumnHeadersHeight = 29;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReport.Location = new Point(16, 21);
            dgvReport.Margin = new Padding(3, 4, 3, 4);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 51;
            dgvReport.RowTemplate.Height = 24;
            dgvReport.Size = new Size(713, 651);
            dgvReport.TabIndex = 0;
            dgvReport.CellClick += dgvGiangVien_CellClick;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(916, 301);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(109, 49);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnChangePass
            // 
            btnChangePass.Location = new Point(919, 364);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(105, 48);
            btnChangePass.TabIndex = 3;
            btnChangePass.Text = "Đổi mật khẩu";
            btnChangePass.UseVisualStyleBackColor = true;
            btnChangePass.Click += btnChangePass_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 719);
            Controls.Add(btnChangePass);
            Controls.Add(btnLogout);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminForm";
            Text = "Admin";
            FormClosed += AdminForm_FormClosed;
            Load += AdminForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtGvUsername;
        private System.Windows.Forms.TextBox txtGvEmail;
        private System.Windows.Forms.TextBox txtGvFullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGvPassword;
        private System.Windows.Forms.Button btnDeleteGv;
        private System.Windows.Forms.Button btnEditGv;
        private System.Windows.Forms.Button btnAddGv;
        private System.Windows.Forms.DataGridView dgvGiangVien;
        private System.Windows.Forms.Button btnReportByLecturer;
        private System.Windows.Forms.Button btnReportByCourse;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnLogout;
        private Button btnGvSearch;
        private TextBox txtGv;
        private Label label6;
        private Button btnReportGv;
        private Button btnChangePass;
    }
}