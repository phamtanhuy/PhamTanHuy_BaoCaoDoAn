using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyThuVien.frm;

namespace QuanLyThuVien
{

    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }
        public void OpenLoginForm()
        {
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }



        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNV = new frmNhanVien();

            frmNV.TopLevel = false;
            frmNV.Parent = this;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(frmNV);

            frmNV.Show();
        }

        private void menuTheLoai_Click(object sender, EventArgs e)
        {
            frmTheLoai frmTL = new frmTheLoai();

            frmTL.TopLevel = false;
            frmTL.Parent = this;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(frmTL);

            frmTL.Show();
        }

        private void menuQLSach_Click(object sender, EventArgs e)
        {
            frmQLSach frmSach = new frmQLSach();

            frmSach.TopLevel = false;
            frmSach.Parent = this;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(frmSach);
            frmSach.Show();
        }

        private void menuTacGia_Click(object sender, EventArgs e)
        {
             frmTacGia frmTG = new frmTacGia();

            frmTG.TopLevel = false;
            frmTG.Parent = this;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(frmTG);
            frmTG.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Xác nhận đóng ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void menuDocGia_Click(object sender, EventArgs e)
        {
            frmDocGia frmDG = new frmDocGia();

            frmDG.TopLevel = false;
            frmDG.Parent = this;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(frmDG);
            frmDG.Show();
        }

        private void menuPhieuMuon_Click(object sender, EventArgs e)
        {
            frmPhieuMuon frmPM = new frmPhieuMuon();

            frmPM.TopLevel = false;
            frmPM.Parent = this;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(frmPM);
            frmPM.Show();
        }

        private void menuTroGiup_Click(object sender, EventArgs e)
        {
            frmTroGiup frmTGIUP = new frmTroGiup();

            frmTGIUP.TopLevel = false;
            frmTGIUP.Parent = this;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(frmTGIUP);
            frmTGIUP.Show();
        }
    }
}