namespace QuanLyDeCuong
{
    partial class GiangVienForm
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
            cmbMonHoc = new ComboBox();
            txtLink = new TextBox();
            txtSearch = new TextBox();
            dgvDeCuong = new DataGridView();
            btnAddDeCuong = new Button();
            btnEditDeCuong = new Button();
            btnDeleteDeCuong = new Button();
            btnSearch = new Button();
            lblWelcome = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDeCuong).BeginInit();
            SuspendLayout();
            // 
            // cmbMonHoc
            // 
            cmbMonHoc.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMonHoc.FormattingEnabled = true;
            cmbMonHoc.Location = new Point(122, 79);
            cmbMonHoc.Margin = new Padding(3, 4, 3, 4);
            cmbMonHoc.Name = "cmbMonHoc";
            cmbMonHoc.Size = new Size(257, 28);
            cmbMonHoc.TabIndex = 0;
            // 
            // txtLink
            // 
            txtLink.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLink.Location = new Point(122, 142);
            txtLink.Margin = new Padding(3, 4, 3, 4);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(368, 27);
            txtLink.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(122, 218);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(257, 27);
            txtSearch.TabIndex = 2;
            // 
            // dgvDeCuong
            // 
            dgvDeCuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeCuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeCuong.Location = new Point(16, 288);
            dgvDeCuong.Margin = new Padding(3, 4, 3, 4);
            dgvDeCuong.Name = "dgvDeCuong";
            dgvDeCuong.RowHeadersWidth = 51;
            dgvDeCuong.RowTemplate.Height = 24;
            dgvDeCuong.Size = new Size(626, 439);
            dgvDeCuong.TabIndex = 3;
            dgvDeCuong.CellClick += dgvDeCuong_CellClick;
            // 
            // btnAddDeCuong
            // 
            btnAddDeCuong.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddDeCuong.Location = new Point(535, 82);
            btnAddDeCuong.Margin = new Padding(3, 4, 3, 4);
            btnAddDeCuong.Name = "btnAddDeCuong";
            btnAddDeCuong.Size = new Size(80, 45);
            btnAddDeCuong.TabIndex = 4;
            btnAddDeCuong.Text = "Thêm";
            btnAddDeCuong.UseVisualStyleBackColor = true;
            btnAddDeCuong.Click += btnAddDeCuong_Click;
            // 
            // btnEditDeCuong
            // 
            btnEditDeCuong.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditDeCuong.Location = new Point(535, 151);
            btnEditDeCuong.Margin = new Padding(3, 4, 3, 4);
            btnEditDeCuong.Name = "btnEditDeCuong";
            btnEditDeCuong.Size = new Size(80, 44);
            btnEditDeCuong.TabIndex = 5;
            btnEditDeCuong.Text = "Sửa";
            btnEditDeCuong.UseVisualStyleBackColor = true;
            btnEditDeCuong.Click += btnEditDeCuong_Click;
            // 
            // btnDeleteDeCuong
            // 
            btnDeleteDeCuong.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteDeCuong.Location = new Point(535, 218);
            btnDeleteDeCuong.Margin = new Padding(3, 4, 3, 4);
            btnDeleteDeCuong.Name = "btnDeleteDeCuong";
            btnDeleteDeCuong.Size = new Size(80, 44);
            btnDeleteDeCuong.TabIndex = 6;
            btnDeleteDeCuong.Text = "Xóa";
            btnDeleteDeCuong.UseVisualStyleBackColor = true;
            btnDeleteDeCuong.Click += btnDeleteDeCuong_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(385, 211);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 46);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(197, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(26, 20);
            lblWelcome.TabIndex = 8;
            lblWelcome.Text = "Hi";
            lblWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 82);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 9;
            label1.Text = "Môn học:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 146);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 10;
            label2.Text = "Link:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 221);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 11;
            label3.Text = "Tìm kiếm:";
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(562, 15);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(95, 55);
            btnLogout.TabIndex = 12;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // GiangVienForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 741);
            Controls.Add(btnLogout);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblWelcome);
            Controls.Add(btnSearch);
            Controls.Add(btnDeleteDeCuong);
            Controls.Add(btnEditDeCuong);
            Controls.Add(btnAddDeCuong);
            Controls.Add(dgvDeCuong);
            Controls.Add(txtSearch);
            Controls.Add(txtLink);
            Controls.Add(cmbMonHoc);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GiangVienForm";
            Text = "GiangVienForm";
            Load += GiangVienForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDeCuong).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMonHoc;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvDeCuong;
        private System.Windows.Forms.Button btnAddDeCuong;
        private System.Windows.Forms.Button btnEditDeCuong;
        private System.Windows.Forms.Button btnDeleteDeCuong;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogout;
    }
}