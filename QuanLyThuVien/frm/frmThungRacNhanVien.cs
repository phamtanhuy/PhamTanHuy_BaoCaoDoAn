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
    public partial class frmThungRacNhanVien : Form
    {
        public frmThungRacNhanVien()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLNhanVienThungRac()
        {
            conn.Open();
            string sql = "SELECT * FROM ThungRacQLNhanVien";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvThungRacNhanVien.DataSource = dt;
        }

        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM ThungRacQLNhanVien";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvThungRacNhanVien.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (dgvThungRacNhanVien.SelectedRows.Count > 0)
            {
                string maNhanVien = dgvThungRacNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();
                string hoTenNhanVien = dgvThungRacNhanVien.SelectedRows[0].Cells["HoTenNhanVien"].Value.ToString();
                string ngaySinh = dgvThungRacNhanVien.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
                string tenDangNhap = dgvThungRacNhanVien.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
                string matKhau = dgvThungRacNhanVien.SelectedRows[0].Cells["MatKhau"].Value.ToString();
                int soDienThoai = Convert.ToInt32(dgvThungRacNhanVien.SelectedRows[0].Cells["SoDienThoai"].Value);

                string email = dgvThungRacNhanVien.SelectedRows[0].Cells["Email"].Value.ToString();
                string diaChi = dgvThungRacNhanVien.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                string capBac = dgvThungRacNhanVien.SelectedRows[0].Cells["CapBac"].Value.ToString();

                // Thêm dữ liệu vào bảng QLSach từ thùng rác
                string insertQuery = "INSERT INTO QLNhanVien (MaNhanVien, HoTenNhanVien, NgaySinh, TenDangNhap, MatKhau, SoDienThoai, Email, DiaChi, CapBac) " +
                                                 "VALUES (@MaNhanVien, @HoTenNhanVien, @NgaySinh, @TenDangNhap, @MatKhau, @SoDienThoai, @Email, @DiaChi, @CapBac)";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@HoTenNhanVien", hoTenNhanVien);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmd.Parameters.AddWithValue("@CapBac", capBac);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Dữ liệu đã được khôi phục từ thùng rác về bảng QLNhanVien.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi khôi phục dữ liệu: " + ex.Message);
                        }
                    }
                }

                // Xóa dữ liệu từ bảng thùng rác sau khi đã khôi phục thành công
                string deleteQuery = "DELETE FROM ThungRacQLNhanVien WHERE MaNhanVien = @MaNhanVien";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

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
                MessageBox.Show("Vui lòng chọn dòng để khôi phục.");
            }
        }

        private void frmThungRacNhanVien_Load(object sender, EventArgs e)
        {
            dataQLNhanVienThungRac();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThungRacNhanVien.SelectedRows.Count > 0)
            {
                string maSach = dgvThungRacNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();

                string query = "DELETE FROM ThungRacQLNhanVien WHERE MaNhanVien = @MaNhanVien";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maSach);
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
