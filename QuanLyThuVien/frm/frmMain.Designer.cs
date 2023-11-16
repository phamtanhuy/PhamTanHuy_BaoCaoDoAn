
namespace QuanLyThuVien
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.menuQLSach = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTheLoai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTacGia = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocGia = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPhieuMuon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 28);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(929, 468);
            this.panelMain.TabIndex = 1;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Aqua;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQLSach,
            this.menuTheLoai,
            this.menuTacGia,
            this.menuDocGia,
            this.menuPhieuMuon,
            this.menuNhanVien,
            this.menuTroGiup});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(929, 28);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // menuQLSach
            // 
            this.menuQLSach.Image = global::QuanLyThuVien.Properties.Resources.stack_of_books;
            this.menuQLSach.Name = "menuQLSach";
            this.menuQLSach.Size = new System.Drawing.Size(126, 24);
            this.menuQLSach.Text = "Quản lý sách";
            this.menuQLSach.Click += new System.EventHandler(this.menuQLSach_Click);
            // 
            // menuTheLoai
            // 
            this.menuTheLoai.Image = global::QuanLyThuVien.Properties.Resources.book_stack;
            this.menuTheLoai.Name = "menuTheLoai";
            this.menuTheLoai.Size = new System.Drawing.Size(96, 24);
            this.menuTheLoai.Text = "Thể loại";
            this.menuTheLoai.Click += new System.EventHandler(this.menuTheLoai_Click);
            // 
            // menuTacGia
            // 
            this.menuTacGia.Image = global::QuanLyThuVien.Properties.Resources.mime;
            this.menuTacGia.Name = "menuTacGia";
            this.menuTacGia.Size = new System.Drawing.Size(89, 24);
            this.menuTacGia.Text = "Tác giả";
            this.menuTacGia.Click += new System.EventHandler(this.menuTacGia_Click);
            // 
            // menuDocGia
            // 
            this.menuDocGia.Image = global::QuanLyThuVien.Properties.Resources.actor;
            this.menuDocGia.Name = "menuDocGia";
            this.menuDocGia.Size = new System.Drawing.Size(95, 24);
            this.menuDocGia.Text = "Độc giả";
            this.menuDocGia.Click += new System.EventHandler(this.menuDocGia_Click);
            // 
            // menuPhieuMuon
            // 
            this.menuPhieuMuon.Image = global::QuanLyThuVien.Properties.Resources.ticket;
            this.menuPhieuMuon.Name = "menuPhieuMuon";
            this.menuPhieuMuon.Size = new System.Drawing.Size(144, 24);
            this.menuPhieuMuon.Text = "Phiếu mượn trả";
            this.menuPhieuMuon.Click += new System.EventHandler(this.menuPhieuMuon_Click);
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.Image = global::QuanLyThuVien.Properties.Resources.model;
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(109, 24);
            this.menuNhanVien.Text = "Nhân viên";
            this.menuNhanVien.Click += new System.EventHandler(this.menuNhanVien_Click);
            // 
            // menuTroGiup
            // 
            this.menuTroGiup.Image = global::QuanLyThuVien.Properties.Resources.question;
            this.menuTroGiup.Name = "menuTroGiup";
            this.menuTroGiup.Size = new System.Drawing.Size(98, 24);
            this.menuTroGiup.Text = "Trợ giúp";
            this.menuTroGiup.Click += new System.EventHandler(this.menuTroGiup_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(929, 496);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.FlowLayoutPanel panelMain;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuQLSach;
        private System.Windows.Forms.ToolStripMenuItem menuTheLoai;
        private System.Windows.Forms.ToolStripMenuItem menuTacGia;
        private System.Windows.Forms.ToolStripMenuItem menuDocGia;
        private System.Windows.Forms.ToolStripMenuItem menuPhieuMuon;
        private System.Windows.Forms.ToolStripMenuItem menuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuTroGiup;
    }
    #endregion
}