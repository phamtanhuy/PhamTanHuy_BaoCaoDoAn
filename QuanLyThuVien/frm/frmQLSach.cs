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
    public partial class frmQLSach : Form
    {
        public frmQLSach()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLSach()
        {
            conn.Open();
            string sql = "SELECT * FROM QLSach";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvQLS.DataSource = dt;
        }

        private bool IsMaSachExists(string maSach)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM QLSach WHERE MaSach = @MaSach";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM QLSach";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvQLS.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text;
            if (IsMaSachExists(maSach))
            {
                MessageBox.Show("Mã sách đã tồn tại. Vui lòng chọn mã sách khác.");
                return;
            }
            string tacGia = txtTacGia.Text;
            int namXuatBan = Convert.ToInt32(txtNamXuatBan.Text);
            int soTrang = Convert.ToInt32(txtSoTrang.Text);
            string tenSach = txtTenSach.Text;
            string theLoai = cbTheLoai.Text;
            string ngonNgu = cbNgonNgu.Text;
            string nhaXuatBan = txtNhaXuatBan.Text;
            int conLai = Convert.ToInt32(txtSoLuongConLai.Text);
            decimal giaSach = Convert.ToDecimal(txtGiaSach.Text);

            string query = "INSERT INTO QLSach (MaSach, TacGia, NamXuatBan, SoTrang, TenSach, TheLoai, NgonNgu, NhaXuatBan, SoLuongConLai, GiaSach) " +
                           "VALUES (@MaSach, @TacGia, @NamXuatBan, @SoTrang, @TenSach, @TheLoai, @NgonNgu, @NhaXuatBan, @SoLuongConLai, @GiaSach)";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                cmd.Parameters.AddWithValue("@TacGia", tacGia);
                cmd.Parameters.AddWithValue("@NamXuatBan", namXuatBan);
                cmd.Parameters.AddWithValue("@SoTrang", soTrang);
                cmd.Parameters.AddWithValue("@TenSach", tenSach);
                cmd.Parameters.AddWithValue("@TheLoai", theLoai);
                cmd.Parameters.AddWithValue("@NgonNgu", ngonNgu);
                cmd.Parameters.AddWithValue("@NhaXuatBan", nhaXuatBan);
                cmd.Parameters.AddWithValue("@SoLuongConLai", conLai);
                cmd.Parameters.AddWithValue("@GiaSach", giaSach);

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
                if (dgvQLS.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvQLS.SelectedRows[0];
                    txtMaSach.Text = selectedRow.Cells["MaSach"].Value.ToString();
                    txtTacGia.Text = selectedRow.Cells["TacGia"].Value.ToString();
                    txtNamXuatBan.Text = selectedRow.Cells["NamXuatBan"].Value.ToString();
                    txtSoTrang.Text = selectedRow.Cells["SoTrang"].Value.ToString();
                    txtTenSach.Text = selectedRow.Cells["TenSach"].Value.ToString();
                    cbTheLoai.Text = selectedRow.Cells["TheLoai"].Value.ToString();
                    cbNgonNgu.Text = selectedRow.Cells["NgonNgu"].Value.ToString();
                    txtNhaXuatBan.Text = selectedRow.Cells["NhaXuatBan"].Value.ToString();
                    txtSoLuongConLai.Text = selectedRow.Cells["SoLuongConLai"].Value.ToString();
                    txtGiaSach.Text = selectedRow.Cells["GiaSach"].Value.ToString();
                    isEditing = true;
                    editedRowIndex = selectedRow.Index;
                    btnThem.Enabled = false;
                    btnSua.Text = "Lưu";
                }
            }
            else
            {
                string maSach = txtMaSach.Text;
                if (IsMaSachExists(maSach) && maSach != dgvQLS.Rows[editedRowIndex].Cells["MaSach"].Value.ToString())
                {
                    MessageBox.Show("Mã sách đã tồn tại. Vui lòng chọn mã sách khác.");
                    return;
                }
                string tacGia = txtTacGia.Text;
                string namXuatBan = txtNamXuatBan.Text;
                string soTrang = txtSoTrang.Text;
                string tenSach = txtTenSach.Text;
                string theLoai = cbTheLoai.Text;
                string ngonNgu = cbNgonNgu.Text;
                string nhaXuatBan = txtNhaXuatBan.Text;
                string soluongConLai = txtSoLuongConLai.Text;
                string giaSach = txtGiaSach.Text;

                string connString = @"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE QLSach SET MaSach = @MaSach, TacGia = @TacGia, NamXuatBan = @NamXuatBan, SoTrang = @SoTrang, TenSach = @TenSach, TheLoai = @TheLoai, NgonNgu = @NgonNgu, NhaXuatBan = @NhaXuatBan, SoLuongConLai = @SoLuongConLai, GiaSach = @GiaSach WHERE MaSach = @OldMaSach";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@MaSach", SqlDbType.VarChar).Value = maSach;
                            command.Parameters.Add("@TacGia", SqlDbType.NVarChar).Value = tacGia;
                            command.Parameters.Add("@NamXuatBan", SqlDbType.VarChar).Value = namXuatBan;
                            command.Parameters.Add("@SoTrang", SqlDbType.VarChar).Value = soTrang;
                            command.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = tenSach;
                            command.Parameters.Add("@TheLoai", SqlDbType.NVarChar).Value = theLoai;
                            command.Parameters.Add("@NgonNgu", SqlDbType.NVarChar).Value = ngonNgu;
                            command.Parameters.Add("@NhaXuatBan", SqlDbType.NVarChar).Value = nhaXuatBan;
                            command.Parameters.Add("@SoLuongConLai", SqlDbType.VarChar).Value = soluongConLai;
                            command.Parameters.Add("@GiaSach", SqlDbType.VarChar).Value = giaSach;
                            command.Parameters.Add("@OldMaSach", SqlDbType.VarChar).Value = dgvQLS.Rows[editedRowIndex].Cells["MaSach"].Value.ToString();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Dữ liệu đã được cập nhật.");
                        }
                        dataQLSach();
                        txtMaSach.Clear();
                        txtTacGia.Clear();
                        txtNamXuatBan.Clear();
                        txtSoTrang.Clear();
                        txtTenSach.Clear();
                        txtNhaXuatBan.Clear();
                        txtSoLuongConLai.Clear();
                        txtGiaSach.Clear();

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

        private void frmQLSach_Load(object sender, EventArgs e)
        {
            dataQLSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvQLS.SelectedRows.Count > 0)
            {
                string maSach = dgvQLS.SelectedRows[0].Cells["MaSach"].Value.ToString();

                string query = "DELETE FROM QLSach WHERE MaSach = @MaSach";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSach", maSach);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            string tacGia = dgvQLS.SelectedRows[0].Cells["TacGia"].Value.ToString();
                            int namXuatBan = Convert.ToInt32(dgvQLS.SelectedRows[0].Cells["NamXuatBan"].Value);
                            int soTrang = Convert.ToInt32(dgvQLS.SelectedRows[0].Cells["SoTrang"].Value);
                            string tenSach = dgvQLS.SelectedRows[0].Cells["TenSach"].Value.ToString();
                            string theLoai = dgvQLS.SelectedRows[0].Cells["TheLoai"].Value.ToString();
                            string ngonNgu = dgvQLS.SelectedRows[0].Cells["NgonNgu"].Value.ToString();
                            string nhaXuatBan = dgvQLS.SelectedRows[0].Cells["NhaXuatBan"].Value.ToString();
                            string soLuongConLai = dgvQLS.SelectedRows[0].Cells["SoLuongConLai"].Value.ToString();
                            string giaSach = dgvQLS.SelectedRows[0].Cells["GiaSach"].Value.ToString();

                            // Thêm các thông tin đã lấy vào bảng thùng rác dgvThungRacQLSach
                            string insertQuery = "INSERT INTO ThungRacQLSach (MaSach, TacGia, NamXuatBan, SoTrang, TenSach, TheLoai, NgonNgu, NhaXuatBan, SoLuongConLai, GiaSach) " +
                                                 "VALUES (@MaSach, @TacGia, @NamXuatBan, @SoTrang, @TenSach, @TheLoai, @NgonNgu, @NhaXuatBan, @SoLuongConLai, @GiaSach)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MaSach", maSach);
                                insertCmd.Parameters.AddWithValue("@TacGia", tacGia);
                                insertCmd.Parameters.AddWithValue("@NamXuatBan", namXuatBan);
                                insertCmd.Parameters.AddWithValue("@SoTrang", soTrang);
                                insertCmd.Parameters.AddWithValue("@TenSach", tenSach);
                                insertCmd.Parameters.AddWithValue("@TheLoai", theLoai);
                                insertCmd.Parameters.AddWithValue("@NgonNgu", ngonNgu);
                                insertCmd.Parameters.AddWithValue("@NhaXuatBan", nhaXuatBan);
                                insertCmd.Parameters.AddWithValue("@SoLuongConLai", soLuongConLai);
                                insertCmd.Parameters.AddWithValue("@GiaSach", giaSach);

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

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                string query = "SELECT * FROM QLSach WHERE MaSach LIKE @Keyword OR TenSach LIKE @Keyword";
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

                                dgvQLS.DataSource = dataTable;

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

        private void btnThungRacQLSach_Click(object sender, EventArgs e)
        {
            
            frmThungRacQLSach thungRacForm = new frmThungRacQLSach();

            thungRacForm.ShowDialog();
        }

    }
}
