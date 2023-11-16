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
    public partial class frmPhieuMuon : Form
    {
        public frmPhieuMuon()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");

        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();

                string query = "SELECT * FROM QLPhieuMuon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvPhieuMuon.DataSource = dataTable;
                    }
                }
            }
        }
        private void dataQLPhieuMuon()
        {
            conn.Open();
            string sql = "SELECT * FROM QLPhieuMuon";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvPhieuMuon.DataSource = dt;
        }

        private void frmPhieuMuon_Load(object sender, EventArgs e)
        {
            dataQLPhieuMuon();
        }
        private bool IsMaPhieuMuonExists(string maPhieuMuon)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM QLPhieuMuon WHERE MaPhieuMuon = @MaPhieuMuon";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuMuon", maPhieuMuon);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhieuMuon = txtMaPhieuMuon.Text;
            if (IsMaPhieuMuonExists(maPhieuMuon))
            {
                MessageBox.Show("Mã phiếu mượn đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }
            string maDocGia = txtMaDocGia.Text;
            string maSach = txtMaSach.Text;
            DateTime ngayMuon = dtpNgayMuon.Value;
            DateTime ngayHenTra = dtpNgayHenTra.Value;
            DateTime ngayTraThucTe = dtpNgayTraThucTe.Value;
            string tinhTrangMuon = cbTinhTrangMuon.Text;
            string mucPhat = txtMucPhat.Text;

            string query = "INSERT INTO QLPhieuMuon (MaPhieuMuon, MaDocGia, MaSach, NgayMuon, NgayHenTra, NgayTraThucTe, TinhTrangMuon, MucPhat) " +
                           "VALUES (@MaPhieuMuon, @MaDocGia, @MaSach, @NgayMuon, @NgayHenTra, @NgayTraThucTe, @TinhTrangMuon, @MucPhat)";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand(query, conn))
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
                    MessageBox.Show("Dữ liệu đã được thêm vào cơ sở dữ liệu.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
            RefreshDataGridView();
        }

        private bool isEditing = false;
        private int editedRowIndex = -1;

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (dgvPhieuMuon.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvPhieuMuon.SelectedRows[0];
                    txtMaPhieuMuon.Text = selectedRow.Cells["MaPhieuMuon"].Value.ToString();
                    txtMaDocGia.Text = selectedRow.Cells["MaDocGia"].Value.ToString();
                    txtMaSach.Text = selectedRow.Cells["MaSach"].Value.ToString();
                    dtpNgayMuon.Text = selectedRow.Cells["NgayMuon"].Value.ToString();
                    dtpNgayHenTra.Text = selectedRow.Cells["NgayHenTra"].Value.ToString();
                    dtpNgayTraThucTe.Text = selectedRow.Cells["NgayTraThucTe"].Value.ToString();
                    cbTinhTrangMuon.Text = selectedRow.Cells["TinhTrangMuon"].Value.ToString();
                    txtMucPhat.Text = selectedRow.Cells["MucPhat"].Value.ToString();
                    
                    isEditing = true;
                    editedRowIndex = selectedRow.Index;
                    btnThem.Enabled = false;
                    btnSua.Text = "Lưu";
                }
            }
            else
            {
                string maPhieuMuon = txtMaPhieuMuon.Text;
                if (IsMaPhieuMuonExists(maPhieuMuon) && maPhieuMuon != dgvPhieuMuon.Rows[editedRowIndex].Cells["MaDocGia"].Value.ToString())
                {
                    MessageBox.Show("Mã phiếu mượn đã tồn tại. Vui lòng chọn mã khác.");
                    return;
                }
                string maDocGia = txtMaDocGia.Text;
                string maSach = txtMaSach.Text;
                DateTime ngayMuon = dtpNgayMuon.Value;
                DateTime ngayHenTra = dtpNgayHenTra.Value;
                DateTime ngayTraThucTe = dtpNgayTraThucTe.Value;
                string tinhTrangMuon = cbTinhTrangMuon.Text;
                string mucPhat = txtMucPhat.Text;
             

                string connString = @"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE QLPhieuMuon SET MaPhieuMuon = @MaPhieuMuon, MaDocGia = @MaDocGia,MaSach = @MaSach, NgayMuon = @NgayMuon, NgayHenTra = @NgayHenTra, NgayTraThucTe = @NgayTraThucTe, TinhTrangMuon = @TinhTrangMuon, MucPhat = @MucPhat  WHERE MaPhieuMuon = @OldMaPhieuMuon";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@MaPhieuMuon", SqlDbType.VarChar).Value = maPhieuMuon;
                            command.Parameters.Add("@MaDocGia", SqlDbType.NVarChar).Value = maDocGia;
                            command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = maSach;
                            command.Parameters.Add("@NgayMuon", SqlDbType.NVarChar).Value = ngayMuon;
                            command.Parameters.Add("@NgayHenTra", SqlDbType.NVarChar).Value = ngayHenTra;
                            command.Parameters.Add("@NgayTraThucTe", SqlDbType.VarChar).Value = ngayTraThucTe;
                            command.Parameters.Add("@TinhTrangMuon", SqlDbType.NVarChar).Value = tinhTrangMuon;

                            command.Parameters.Add("@MucPhat", SqlDbType.NVarChar).Value = mucPhat;
                            command.Parameters.Add("@OldMaPhieuMuon", SqlDbType.VarChar).Value = dgvPhieuMuon.Rows[editedRowIndex].Cells["MaPhieuMuon"].Value.ToString();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Dữ liệu đã được cập nhật.");
                        }
                        dataQLPhieuMuon();
                        txtMaPhieuMuon.Clear();
                        txtMaDocGia.Clear();
                        txtMaSach.Clear();
                        txtMucPhat.Clear();

                        isEditing = false;
                        btnThem.Enabled = true;
                        btnSua.Text = "Sửa";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                string query = "SELECT * FROM QLPhieuMuon WHERE MaPhieuMuon LIKE @Keyword OR MaDocGia LIKE @Keyword OR MaSach LIKE @Keyword";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                        try
                        {
                            conn.Open();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                dgvPhieuMuon.DataSource = dataTable;

                                if (dataTable.Rows.Count == 0)
                                {
                                    MessageBox.Show("Không tìm thấy kết quả nào.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.SelectedRows.Count > 0)
            {
                string maPhieuMuon = dgvPhieuMuon.SelectedRows[0].Cells["MaPhieuMuon"].Value.ToString();

                string query = "DELETE FROM QLPhieuMuon WHERE MaPhieuMuon = @MaPhieuMuon";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieuMuon", maPhieuMuon);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            string maDocGia = dgvPhieuMuon.SelectedRows[0].Cells["MaDocGia"].Value.ToString();
                            string maSach = dgvPhieuMuon.SelectedRows[0].Cells["MaSach"].Value.ToString();

                            string ngayMuon = dgvPhieuMuon.SelectedRows[0].Cells["NgayMuon"].Value.ToString();
                            string ngayHenTra = dgvPhieuMuon.SelectedRows[0].Cells["NgayHenTra"].Value.ToString();
                            string ngayTraThucTe = dgvPhieuMuon.SelectedRows[0].Cells["NgayTraThucTe"].Value.ToString();
                            string tinhTrangMuon = dgvPhieuMuon.SelectedRows[0].Cells["TinhTrangMuon"].Value.ToString();
                            string mucPhat = dgvPhieuMuon.SelectedRows[0].Cells["MucPhat"].Value.ToString();


                            // Thêm các thông tin đã lấy vào bảng thùng rác dgvThungRacQLSach
                            string insertQuery = "INSERT INTO ThungRacQLPhieuMuon (MaPhieuMuon, MaDocGia, MaSach, NgayMuon, NgayHenTra, NgayTraThucTe, TinhTrangMuon, MucPhat) " +
                                                 "VALUES (@MaPhieuMuon, @MaDocGia, @MaSach, @NgayMuon, @NgayHenTra, @NgayTraThucTe, @TinhTrangMuon, @MucPhat)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MaPhieuMuon", maPhieuMuon);
                                insertCmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                                insertCmd.Parameters.AddWithValue("@MaSach", maSach);
                                insertCmd.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                                insertCmd.Parameters.AddWithValue("@NgayHenTra", ngayHenTra);
                                insertCmd.Parameters.AddWithValue("@NgayTraThucTe", ngayTraThucTe);
                                insertCmd.Parameters.AddWithValue("@TinhTrangMuon", tinhTrangMuon);
                                insertCmd.Parameters.AddWithValue("@MucPhat", mucPhat);

                                insertCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Dữ liệu đã được xóa và chuyển sang thùng rác.");
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

        private void btnThungRac_Click(object sender, EventArgs e)
        {
            frmThungRacPhieuMuon thungRacForm = new frmThungRacPhieuMuon();

            thungRacForm.ShowDialog();
        }
    }
}
