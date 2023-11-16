using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.frm
{
    public partial class frmThungRacDocGia : Form
    {
        public frmThungRacDocGia()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLDocGiaThungRac()
        {
            conn.Open();
            string sql = "SELECT * FROM ThungRacQLDocGia";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvThungRacDocGia.DataSource = dt;
        }

        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM ThungRacQLDocGia";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvThungRacDocGia.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (dgvThungRacDocGia.SelectedRows.Count > 0)
            {
                string maDocGia = dgvThungRacDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();
                string tenDocGia = dgvThungRacDocGia.SelectedRows[0].Cells["TenDocGia"].Value.ToString();
                string ngaySinh = dgvThungRacDocGia.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
                string gioiTinh = dgvThungRacDocGia.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
                string diaChi = dgvThungRacDocGia.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                string soDienThoai = dgvThungRacDocGia.SelectedRows[0].Cells["SoDienThoai"].Value.ToString();
                string email = dgvThungRacDocGia.SelectedRows[0].Cells["Email"].Value.ToString();
                string ngayDangKi = dgvThungRacDocGia.SelectedRows[0].Cells["NgayDangKi"].Value.ToString();


                string insertQuery = "INSERT INTO QLDocGia (MaDocGia, TenDocGia, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, NgayDangKi) " +
                                                 "VALUES (@MaDocGia, @TenDocGia, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @NgayDangKi)";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                        cmd.Parameters.AddWithValue("@TenDocGia", tenDocGia);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@NgayDangKi", ngayDangKi);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Khôi phục thành công.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi khôi phục dữ liệu: " + ex.Message);
                        }
                    }
                }

                // Xóa dữ liệu từ bảng thùng rác sau khi đã khôi phục thành công
                string deleteQuery = "DELETE FROM ThungRacQLDocGia WHERE MaDocGia = @MaDocGia";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa dữ liệu khỏi thùng rác: " + ex.Message);
                        }
                    }
                }
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để khôi phục.");
            }
        }



        private void frmThungRacDocGia_Load(object sender, EventArgs e)
        {
            dataQLDocGiaThungRac();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThungRacDocGia.SelectedRows.Count > 0)
            {
                string maTheLoai = dgvThungRacDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();

                string query = "DELETE FROM ThungRacQLDocGia WHERE MaDocGia  = @MaDocGia";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDocGia", maTheLoai);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Dữ liệu đã được xóa.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                        }
                    }
                }

                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để xóa.");
            }
        }
    }
}
