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
    public partial class frmThungRacPhieuMuon : Form
    {
        public frmThungRacPhieuMuon()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLPhieuMuonThungRac()
        {
            conn.Open();
            string sql = "SELECT * FROM ThungRacQLPhieuMuon";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvThungRacPhieuMuon.DataSource = dt;
        }

        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM ThungRacQLPhieuMuon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvThungRacPhieuMuon.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (dgvThungRacPhieuMuon.SelectedRows.Count > 0)
            {
                string maPhieuMuon = dgvThungRacPhieuMuon.SelectedRows[0].Cells["MaPhieuMuon"].Value.ToString();
                string maDocGia = dgvThungRacPhieuMuon.SelectedRows[0].Cells["MaDocGia"].Value.ToString();
                string maSach = dgvThungRacPhieuMuon.SelectedRows[0].Cells["MaSach"].Value.ToString();
                string ngayMuon = dgvThungRacPhieuMuon.SelectedRows[0].Cells["NgayMuon"].Value.ToString();
                string ngayHenTra = dgvThungRacPhieuMuon.SelectedRows[0].Cells["NgayHenTra"].Value.ToString();
                string ngayTraThucTe = dgvThungRacPhieuMuon.SelectedRows[0].Cells["NgayTraThucTe"].Value.ToString();
                string tinhTrangMuon = dgvThungRacPhieuMuon.SelectedRows[0].Cells["TinhTrangMuon"].Value.ToString();
                string mucPhat = dgvThungRacPhieuMuon.SelectedRows[0].Cells["MucPhat"].Value.ToString();


                string insertQuery = "INSERT INTO QLPhieuMuon (MaPhieuMuon, MaDocGia, MaSach, NgayMuon, NgayHenTra, NgayTraThucTe, TinhTrangMuon, MucPhat) " +
                                                 "VALUES (@MaPhieuMuon, @MaDocGia, @MaSach, @NgayMuon, @NgayHenTra, @NgayTraThucTe, @TinhTrangMuon, @MucPhat)";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieuMuon", maPhieuMuon);
                        cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                        cmd.Parameters.AddWithValue("@MaSach", maSach);
                        cmd.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                        cmd.Parameters.AddWithValue("@NgayHenTra", ngayHenTra);
                        cmd.Parameters.AddWithValue("@NgayTraThucTe", ngayTraThucTe);
                        cmd.Parameters.AddWithValue("@TinhTrangMuon", tinhTrangMuon);
                        cmd.Parameters.AddWithValue("@MucPhat", mucPhat);

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
                string deleteQuery = "DELETE FROM ThungRacQLPhieuMuon WHERE MaPhieuMuon = @MaPhieuMuon";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieuMuon", maPhieuMuon);

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



        private void frmThungRacPhieuMuon_Load(object sender, EventArgs e)
        {
            dataQLPhieuMuonThungRac();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThungRacPhieuMuon.SelectedRows.Count > 0)
            {
                string maTheLoai = dgvThungRacPhieuMuon.SelectedRows[0].Cells["MaPhieuMuon"].Value.ToString();

                string query = "DELETE FROM ThungRacQLPhieuMuon WHERE MaPhieuMuon  = @MaPhieuMuon";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieuMuon", maTheLoai);
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
