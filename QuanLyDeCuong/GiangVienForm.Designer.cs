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
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvDeCuong = new System.Windows.Forms.DataGridView();
            this.btnAddDeCuong = new System.Windows.Forms.Button();
            this.btnEditDeCuong = new System.Windows.Forms.Button();
            this.btnDeleteDeCuong = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeCuong)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Location = new System.Drawing.Point(122, 63);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(257, 28);
            this.cmbMonHoc.TabIndex = 0;
            // 
            // txtLink
            // 
            this.txtLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLink.Location = new System.Drawing.Point(122, 114);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(368, 27);
            this.txtLink.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(122, 174);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(257, 27);
            this.txtSearch.TabIndex = 2;
            // 
            // dgvDeCuong
            // 
            this.dgvDeCuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeCuong.Location = new System.Drawing.Point(16, 230);
            this.dgvDeCuong.Name = "dgvDeCuong";
            this.dgvDeCuong.RowHeadersWidth = 51;
            this.dgvDeCuong.RowTemplate.Height = 24;
            this.dgvDeCuong.Size = new System.Drawing.Size(626, 351);
            this.dgvDeCuong.TabIndex = 3;
            this.dgvDeCuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeCuong_CellClick);
            // 
            // btnAddDeCuong
            // 
            this.btnAddDeCuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDeCuong.Location = new System.Drawing.Point(535, 66);
            this.btnAddDeCuong.Name = "btnAddDeCuong";
            this.btnAddDeCuong.Size = new System.Drawing.Size(80, 36);
            this.btnAddDeCuong.TabIndex = 4;
            this.btnAddDeCuong.Text = "Thêm";
            this.btnAddDeCuong.UseVisualStyleBackColor = true;
            this.btnAddDeCuong.Click += new System.EventHandler(this.btnAddDeCuong_Click);
            // 
            // btnEditDeCuong
            // 
            this.btnEditDeCuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeCuong.Location = new System.Drawing.Point(535, 121);
            this.btnEditDeCuong.Name = "btnEditDeCuong";
            this.btnEditDeCuong.Size = new System.Drawing.Size(80, 35);
            this.btnEditDeCuong.TabIndex = 5;
            this.btnEditDeCuong.Text = "Sửa";
            this.btnEditDeCuong.UseVisualStyleBackColor = true;
            this.btnEditDeCuong.Click += new System.EventHandler(this.btnEditDeCuong_Click);
            // 
            // btnDeleteDeCuong
            // 
            this.btnDeleteDeCuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDeCuong.Location = new System.Drawing.Point(535, 174);
            this.btnDeleteDeCuong.Name = "btnDeleteDeCuong";
            this.btnDeleteDeCuong.Size = new System.Drawing.Size(80, 35);
            this.btnDeleteDeCuong.TabIndex = 6;
            this.btnDeleteDeCuong.Text = "Xóa";
            this.btnDeleteDeCuong.UseVisualStyleBackColor = true;
            this.btnDeleteDeCuong.Click += new System.EventHandler(this.btnDeleteDeCuong_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(385, 169);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 37);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(197, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(26, 20);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Hi";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Môn học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Link:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tìm kiếm:";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(562, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(95, 44);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // GiangVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 593);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDeleteDeCuong);
            this.Controls.Add(this.btnEditDeCuong);
            this.Controls.Add(this.btnAddDeCuong);
            this.Controls.Add(this.dgvDeCuong);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.cmbMonHoc);
            this.Name = "GiangVienForm";
            this.Text = "GiangVienForm";
            this.Load += new System.EventHandler(this.GiangVienForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeCuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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