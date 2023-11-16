namespace QuanLyThuVien.frm
{
    partial class frmThungRacPhieuMuon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThungRacPhieuMuon));
            this.dgvThungRacPhieuMuon = new System.Windows.Forms.DataGridView();
            this.MaPhieuMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHenTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTraThucTe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnKhoiPhuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThungRacPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvThungRacPhieuMuon
            // 
            this.dgvThungRacPhieuMuon.AllowUserToAddRows = false;
            this.dgvThungRacPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThungRacPhieuMuon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuMuon,
            this.MaDocGia,
            this.MaSach,
            this.NgayMuon,
            this.NgayHenTra,
            this.NgayTraThucTe,
            this.MucPhat});
            this.dgvThungRacPhieuMuon.Location = new System.Drawing.Point(12, 57);
            this.dgvThungRacPhieuMuon.Name = "dgvThungRacPhieuMuon";
            this.dgvThungRacPhieuMuon.RowHeadersWidth = 51;
            this.dgvThungRacPhieuMuon.RowTemplate.Height = 24;
            this.dgvThungRacPhieuMuon.Size = new System.Drawing.Size(1176, 337);
            this.dgvThungRacPhieuMuon.TabIndex = 6;
            // 
            // MaPhieuMuon
            // 
            this.MaPhieuMuon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaPhieuMuon.DataPropertyName = "MaPhieuMuon";
            this.MaPhieuMuon.HeaderText = "Mã phiếu mượn";
            this.MaPhieuMuon.MinimumWidth = 6;
            this.MaPhieuMuon.Name = "MaPhieuMuon";
            // 
            // MaDocGia
            // 
            this.MaDocGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaDocGia.DataPropertyName = "MaDocGia";
            this.MaDocGia.HeaderText = "Mã độc giả";
            this.MaDocGia.MinimumWidth = 6;
            this.MaDocGia.Name = "MaDocGia";
            // 
            // MaSach
            // 
            this.MaSach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSach.DataPropertyName = "MaSach";
            this.MaSach.HeaderText = "Mã sách";
            this.MaSach.MinimumWidth = 6;
            this.MaSach.Name = "MaSach";
            // 
            // NgayMuon
            // 
            this.NgayMuon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayMuon.DataPropertyName = "NgayMuon";
            this.NgayMuon.HeaderText = "Ngày mượn";
            this.NgayMuon.MinimumWidth = 6;
            this.NgayMuon.Name = "NgayMuon";
            // 
            // NgayHenTra
            // 
            this.NgayHenTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayHenTra.DataPropertyName = "NgayHenTra";
            this.NgayHenTra.HeaderText = "Ngày hẹn trả";
            this.NgayHenTra.MinimumWidth = 6;
            this.NgayHenTra.Name = "NgayHenTra";
            // 
            // NgayTraThucTe
            // 
            this.NgayTraThucTe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayTraThucTe.DataPropertyName = "NgayTraThucTe";
            this.NgayTraThucTe.HeaderText = "Ngày trả thực tế";
            this.NgayTraThucTe.MinimumWidth = 6;
            this.NgayTraThucTe.Name = "NgayTraThucTe";
            // 
            // MucPhat
            // 
            this.MucPhat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MucPhat.DataPropertyName = "MucPhat";
            this.MucPhat.HeaderText = "Mức phạt";
            this.MucPhat.MinimumWidth = 6;
            this.MucPhat.Name = "MucPhat";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(12, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(139, 39);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa vĩnh viễn";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.BackColor = System.Drawing.Color.Lime;
            this.btnKhoiPhuc.Location = new System.Drawing.Point(1049, 12);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Size = new System.Drawing.Size(139, 39);
            this.btnKhoiPhuc.TabIndex = 8;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.UseVisualStyleBackColor = false;
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // frmThungRacPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 406);
            this.Controls.Add(this.btnKhoiPhuc);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvThungRacPhieuMuon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThungRacPhieuMuon";
            this.Text = "Thùng rác phiếu mượn trả";
            this.Load += new System.EventHandler(this.frmThungRacPhieuMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThungRacPhieuMuon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThungRacPhieuMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHenTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTraThucTe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucPhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnKhoiPhuc;
    }
}