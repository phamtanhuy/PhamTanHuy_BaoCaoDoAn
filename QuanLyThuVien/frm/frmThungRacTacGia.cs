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
    public partial class frmThungRacTacGia : Form
    {
        public frmThungRacTacGia()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLTacGiaThungRac()
        {
            conn.Open();
            string sql = "SELECT * FROM ThungRacQLTacGia";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvThungRacTacGia.DataSource = dt;
        }

        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM ThungRacQLTacGia";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvThungRacTacGia.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (dgvThungRacTacGia.SelectedRows.Count > 0)
            {
                string maTacGia = dgvThungRacTacGia.SelectedRows[0].Cells["MaTacGia"].Value.ToString();
                string tenTacGia = dgvThungRacTacGia.SelectedRows[0].Cells["TenTacGia"].Value.ToString();
                string ngaySinh = dgvThungRacTacGia.SelectedRows[0].Cells["NgaySinh"].Value.ToString();

                string queQuan = dgvThungRacTacGia.SelectedRows[0].Cells["QueQuan"].Value.ToString();
                string soDienThoai = dgvThungRacTacGia.SelectedRows[0].Cells["SoDienThoai"].Value.ToString();


                // Thêm dữ liệu vào bảng QLSach từ thùng rác
                string insertQuery = "INSERT INTO QLTacGia (MaTacGia, TenTacGia, NgaySinh, QueQuan, SoDienThoai) " +
                                     "VALUES (@MaTacGia, @TenTacGia, @NgaySinh, @QueQuan, @SoDienThoai)";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);
                        cmd.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@QueQuan", queQuan);
                        cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        ;

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
                string deleteQuery = "DELETE FROM ThungRacQLTacGia WHERE MaTacGia = @MaTacGia";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);

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

        

        private void frmThungRacTacGia_Load(object sender, EventArgs e)
        {
            dataQLTacGiaThungRac();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThungRacTacGia.SelectedRows.Count > 0)
            {
                string maTheLoai = dgvThungRacTacGia.SelectedRows[0].Cells["MaTheLoai"].Value.ToString();

                string query = "DELETE FROM ThungRacQLTacGia WHERE MaTacGia  = @MaTacGia";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTacGia", maTheLoai);
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
