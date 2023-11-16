namespace QuanLyThuVien.frm
{
    partial class frmThungRacQLTheLoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThungRacQLTheLoai));
            this.dgvThungRacTheLoai = new System.Windows.Forms.DataGridView();
            this.MaTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTaNgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnKhoiPhuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThungRacTheLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvThungRacTheLoai
            // 
            this.dgvThungRacTheLoai.AllowUserToAddRows = false;
            this.dgvThungRacTheLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThungRacTheLoai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTheLoai,
            this.TenTheLoai,
            this.MoTaNgan,
            this.NgayTao});
            this.dgvThungRacTheLoai.Location = new System.Drawing.Point(12, 53);
            this.dgvThungRacTheLoai.Name = "dgvThungRacTheLoai";
            this.dgvThungRacTheLoai.RowHeadersWidth = 51;
            this.dgvThungRacTheLoai.RowTemplate.Height = 24;
            this.dgvThungRacTheLoai.Size = new System.Drawing.Size(776, 385);
            this.dgvThungRacTheLoai.TabIndex = 1;
            // 
            // MaTheLoai
            // 
            this.MaTheLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaTheLoai.DataPropertyName = "MaTheLoai";
            this.MaTheLoai.HeaderText = "Mã Thể Loại";
            this.MaTheLoai.MinimumWidth = 6;
            this.MaTheLoai.Name = "MaTheLoai";
            // 
            // TenTheLoai
            // 
            this.TenTheLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenTheLoai.DataPropertyName = "TenTheLoai";
            this.TenTheLoai.HeaderText = "Tên Thể Loại";
            this.TenTheLoai.MinimumWidth = 6;
            this.TenTheLoai.Name = "TenTheLoai";
            // 
            // MoTaNgan
            // 
            this.MoTaNgan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MoTaNgan.DataPropertyName = "MoTaNgan";
            this.MoTaNgan.HeaderText = "Mô Tả Ngắn";
            this.MoTaNgan.MinimumWidth = 6;
            this.MoTaNgan.Name = "MoTaNgan";
            // 
            // NgayTao
            // 
            this.NgayTao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayTao.DataPropertyName = "NgayTao";
            this.NgayTao.HeaderText = "Ngày Tạo";
            this.NgayTao.MinimumWidth = 6;
            this.NgayTao.Name = "NgayTao";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(12, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(128, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa vĩnh viễn";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.BackColor = System.Drawing.Color.Lime;
            this.btnKhoiPhuc.Location = new System.Drawing.Point(660, 12);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Size = new System.Drawing.Size(128, 35);
            this.btnKhoiPhuc.TabIndex = 3;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.UseVisualStyleBackColor = false;
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // frmThungRacQLTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKhoiPhuc);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvThungRacTheLoai);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThungRacQLTheLoai";
            this.Text = "Thùng rác quản lý thể loại";
            this.Load += new System.EventHandler(this.frmThungRacQLTheLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThungRacTheLoai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThungRacTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTaNgan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnKhoiPhuc;
    }
}