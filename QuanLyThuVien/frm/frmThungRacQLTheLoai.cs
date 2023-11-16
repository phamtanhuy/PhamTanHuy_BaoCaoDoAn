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
    public partial class frmThungRacQLTheLoai : Form
    {
        public frmThungRacQLTheLoai()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLTheLoaiThungRac()
        {
            conn.Open();
            string sql = "SELECT * FROM ThungRacQLTheLoai";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvThungRacTheLoai.DataSource = dt;
        }

        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM ThungRacQLTheLoai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvThungRacTheLoai.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (dgvThungRacTheLoai.SelectedRows.Count > 0)
            {
                string maTheLoai = dgvThungRacTheLoai.SelectedRows[0].Cells["MaTheLoai"].Value.ToString();
                string tenTheLoai = dgvThungRacTheLoai.SelectedRows[0].Cells["TenTheLoai"].Value.ToString();
                string moTaNgan = dgvThungRacTheLoai.SelectedRows[0].Cells["MoTaNgan"].Value.ToString();
                string ngayTao = dgvThungRacTheLoai.SelectedRows[0].Cells["NgayTao"].Value.ToString();
  

                // Thêm dữ liệu vào bảng QLSach từ thùng rác
                string insertQuery = "INSERT INTO QLTheLoai (MaTheLoai, TenTheLoai, MoTaNgan, NgayTao) " +
                                     "VALUES (@MaTheLoai, @TenTheLoai, @MoTaNgan, @NgayTao)";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                        cmd.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);
                        cmd.Parameters.AddWithValue("@MoTaNgan", moTaNgan);
                        cmd.Parameters.AddWithValue("@NgayTao", ngayTao);
         ;

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Dữ liệu đã được khôi phục từ thùng rác về bảng QLTheLoai.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi khôi phục dữ liệu: " + ex.Message);
                        }
                    }
                }

                // Xóa dữ liệu từ bảng thùng rác sau khi đã khôi phục thành công
                string deleteQuery = "DELETE FROM ThungRacQLTheLoai WHERE MaTheLoai = @MaTheLoai";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);

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
            if (dgvThungRacTheLoai.SelectedRows.Count > 0)
            {
                string maTheLoai = dgvThungRacTheLoai.SelectedRows[0].Cells["MaTheLoai"].Value.ToString();

                string query = "DELETE FROM ThungRacQLTheLoai WHERE MaTheLoai = @MaTheLoai";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
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

        private void frmThungRacQLTheLoai_Load(object sender, EventArgs e)
        {
            dataQLTheLoaiThungRac();
        }
    }
}
