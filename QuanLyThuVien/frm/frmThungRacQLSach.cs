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
    public partial class frmThungRacQLSach : Form
    {
        public frmThungRacQLSach()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLSachThungRac()
        {
            conn.Open();
            string sql = "SELECT * FROM ThungRacQLSach";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvThungRacQLSach.DataSource = dt;
        }
        private void frmThungRacQLSach_Load(object sender, EventArgs e)
        {
            dataQLSachThungRac();
        }
        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM ThungRacQLSach";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvThungRacQLSach.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (dgvThungRacQLSach.SelectedRows.Count > 0)
            {
                string maSach = dgvThungRacQLSach.SelectedRows[0].Cells["MaSach"].Value.ToString();
                string tacGia = dgvThungRacQLSach.SelectedRows[0].Cells["TacGia"].Value.ToString();
                int namXuatBan = Convert.ToInt32(dgvThungRacQLSach.SelectedRows[0].Cells["NamXuatBan"].Value);
                int soTrang = Convert.ToInt32(dgvThungRacQLSach.SelectedRows[0].Cells["SoTrang"].Value);
                string tenSach = dgvThungRacQLSach.SelectedRows[0].Cells["TenSach"].Value.ToString();
                string theLoai = dgvThungRacQLSach.SelectedRows[0].Cells["TheLoai"].Value.ToString();
                string ngonNgu = dgvThungRacQLSach.SelectedRows[0].Cells["NgonNgu"].Value.ToString();
                string nhaXuatBan = dgvThungRacQLSach.SelectedRows[0].Cells["NhaXuatBan"].Value.ToString();
                string soLuongConLai = dgvThungRacQLSach.SelectedRows[0].Cells["SoLuongConLai"].Value.ToString();
                string giaSach = dgvThungRacQLSach.SelectedRows[0].Cells["GiaSach"].Value.ToString();

                // Thêm dữ liệu vào bảng QLSach từ thùng rác
                string insertQuery = "INSERT INTO QLSach (MaSach, TacGia, NamXuatBan, SoTrang, TenSach, TheLoai, NgonNgu, NhaXuatBan, SoLuongConLai, GiaSach) " +
                                     "VALUES (@MaSach, @TacGia, @NamXuatBan, @SoTrang, @TenSach, @TheLoai, @NgonNgu, @NhaXuatBan, @SoLuongConLai, @GiaSach)";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSach", maSach);
                        cmd.Parameters.AddWithValue("@TacGia", tacGia);
                        cmd.Parameters.AddWithValue("@NamXuatBan", namXuatBan);
                        cmd.Parameters.AddWithValue("@SoTrang", soTrang);
                        cmd.Parameters.AddWithValue("@TenSach", tenSach);
                        cmd.Parameters.AddWithValue("@TheLoai", theLoai);
                        cmd.Parameters.AddWithValue("@NgonNgu", ngonNgu);
                        cmd.Parameters.AddWithValue("@NhaXuatBan", nhaXuatBan);
                        cmd.Parameters.AddWithValue("@SoLuongConLai", soLuongConLai);
                        cmd.Parameters.AddWithValue("@GiaSach", giaSach);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Dữ liệu đã được khôi phục từ thùng rác về bảng QLSach.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi khôi phục dữ liệu: " + ex.Message);
                        }
                    }
                }

                // Xóa dữ liệu từ bảng thùng rác sau khi đã khôi phục thành công
                string deleteQuery = "DELETE FROM ThungRacQLSach WHERE MaSach = @MaSach";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSach", maSach);

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThungRacQLSach.SelectedRows.Count > 0)
            {
                string maSach = dgvThungRacQLSach.SelectedRows[0].Cells["MaSach"].Value.ToString();

                string query = "DELETE FROM ThungRacQLSach WHERE MaSach = @MaSach";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSach", maSach);
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
