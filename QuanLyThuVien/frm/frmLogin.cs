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

namespace QuanLyThuVien.frm
{
    public partial class frmLogin : Form
    {
        private bool mainFormOpened = false;
        public frmLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormClosing += frmLogin_FormClosing;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;
            string connectionString = "Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM QLNhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@TenDangNhap", SqlDbType.VarChar).Value = username;
                        command.Parameters.Add("@MatKhau", SqlDbType.VarChar).Value = password;

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            MessageBox.Show("Đăng nhập thành công!");
                            this.Hide();

                            if (!mainFormOpened)
                            {
                                mainFormOpened = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện đăng nhập: " + ex.Message);
                }
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}