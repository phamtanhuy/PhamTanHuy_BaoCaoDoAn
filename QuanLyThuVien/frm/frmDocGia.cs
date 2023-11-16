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
    public partial class frmDocGia : Form
    {
        public frmDocGia()
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

                string query = "SELECT * FROM QLDocGia";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvDocGia.DataSource = dataTable;
                    }
                }
            }
        }
        private void dataQLDocGia()
        {
            conn.Open();
            string sql = "SELECT * FROM QLDocGia";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvDocGia.DataSource = dt;
        }
        private void frmDocGia_Load(object sender, EventArgs e)
        {
            dataQLDocGia();
        }
        private bool IsMaDocGiaExists(string maDocGia)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM QLDocGia WHERE MaDocGia = @MaDocGia";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maDocGia = txtMaDocGia.Text;
            if (IsMaDocGiaExists(maDocGia))
            {
                MessageBox.Show("Mã độc giả đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }
            string tenDocGia = txtTenDocGia.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = cbGioiTinh.Text;
            string diaChi = txtDiaChi.Text;
            int soDienThoai = Convert.ToInt32(txtSoDienThoai.Text);
            string email = txtEmail.Text;
            DateTime ngayDangKi = dtpNgayDangKi.Value;

            string query = "INSERT INTO QLDocGia (MaDocGia, TenDocGia, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, NgayDangKi) " +
                           "VALUES (@MaDocGia, @TenDocGia, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @NgayDangKi)";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand(query, conn))
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
                if (dgvDocGia.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDocGia.SelectedRows[0];
                    txtMaDocGia.Text = selectedRow.Cells["MaDocGia"].Value.ToString();
                    txtTenDocGia.Text = selectedRow.Cells["TenDocGia"].Value.ToString();
                    dtpNgaySinh.Text = selectedRow.Cells["NgaySinh"].Value.ToString();
                    cbGioiTinh.Text = selectedRow.Cells["GioiTinh"].Value.ToString();
                    txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                    txtSoDienThoai.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                    dtpNgayDangKi.Text = selectedRow.Cells["NgayDangKi"].Value.ToString();
                    isEditing = true;
                    editedRowIndex = selectedRow.Index;
                    btnThem.Enabled = false;
                    btnSua.Text = "Lưu";
                }
            }
            else
            {
                string maDocGia = txtMaDocGia.Text;
                if (IsMaDocGiaExists(maDocGia) && maDocGia != dgvDocGia.Rows[editedRowIndex].Cells["MaDocGia"].Value.ToString())
                {
                    MessageBox.Show("Mã độc giả đã tồn tại. Vui lòng chọn mã khác.");
                    return;
                }
                string tenDocGia = txtTenDocGia.Text;
                DateTime ngaySinh = dtpNgaySinh.Value;
                string gioiTinh = cbGioiTinh.Text;
                string diaChi = txtDiaChi.Text;
                int soDienThoai = Convert.ToInt32(txtSoDienThoai.Text);
                string email = txtEmail.Text;
                string ngayDangKi = dtpNgayDangKi.Text;

                string connString = @"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE QLDocGia SET MaDocGia = @MaDocGia, TenDocGia = @TenDocGia,NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, NgayDangKi = @NgayDangKi  WHERE MaDocGia = @OldMaDocGia";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@MaDocGia", SqlDbType.VarChar).Value = maDocGia;
                            command.Parameters.Add("@TenDocGia", SqlDbType.NVarChar).Value = tenDocGia;
                            command.Parameters.Add("@NgaySinh", SqlDbType.NVarChar).Value = ngaySinh;
                            command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = gioiTinh;
                            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = diaChi;
                            command.Parameters.Add("@SoDienThoai", SqlDbType.VarChar).Value = soDienThoai;
                            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                         
                            command.Parameters.Add("@NgayDangKi", SqlDbType.NVarChar).Value = ngayDangKi;
                            command.Parameters.Add("@OldMaDocGia", SqlDbType.VarChar).Value = dgvDocGia.Rows[editedRowIndex].Cells["MaDocGia"].Value.ToString();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Dữ liệu đã được cập nhật.");
                        }
                        dataQLDocGia();
                        txtMaDocGia.Clear();
                        txtTenDocGia.Clear();
                        txtDiaChi.Clear();
                        txtSoDienThoai.Clear();
                     
                        txtEmail.Clear();

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
                string query = "SELECT * FROM QLDocGia WHERE MaDocGia LIKE @Keyword OR TenDocGia LIKE @Keyword";
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

                                dgvDocGia.DataSource = dataTable;

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
            if (dgvDocGia.SelectedRows.Count > 0)
            {
                string maDocGia = dgvDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();

                string query = "DELETE FROM QLDocGia WHERE MaDocGia = @MaDocGia";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            string tenDocGia = dgvDocGia.SelectedRows[0].Cells["TenDocGia"].Value.ToString();
                            string ngaySinh = dgvDocGia.SelectedRows[0].Cells["NgaySinh"].Value.ToString();

                            string gioiTinh = dgvDocGia.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
                            string diaChi = dgvDocGia.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                            string soDienThoai = dgvDocGia.SelectedRows[0].Cells["SoDienThoai"].Value.ToString();
                            string email = dgvDocGia.SelectedRows[0].Cells["Email"].Value.ToString();
                            string ngayDangKi = dgvDocGia.SelectedRows[0].Cells["NgayDangKi"].Value.ToString();


                            // Thêm các thông tin đã lấy vào bảng thùng rác dgvThungRacQLSach
                            string insertQuery = "INSERT INTO ThungRacQLDocGia (MaDocGia, TenDocGia, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, NgayDangKi) " +
                                                 "VALUES (@MaDocGia, @TenDocGia, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @NgayDangKi)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                                insertCmd.Parameters.AddWithValue("@TenDocGia", tenDocGia);
                                insertCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                insertCmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                insertCmd.Parameters.AddWithValue("@DiaChi", diaChi);
                                insertCmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                                insertCmd.Parameters.AddWithValue("@Email", email);
                                insertCmd.Parameters.AddWithValue("@NgayDangKi", ngayDangKi);

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
            frmThungRacDocGia thungRacForm = new frmThungRacDocGia();

            thungRacForm.ShowDialog();
        }
    }
}
