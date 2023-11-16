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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
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

                string query = "SELECT * FROM QLNhanVien";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvNhanVien.DataSource = dataTable;
                    }
                }
            }
        }
        private void dataQLNhanVien()
        {
            conn.Open();
            string sql = "SELECT * FROM QLNhanVien";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvNhanVien.DataSource = dt;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dataQLNhanVien();
        }
        private bool IsMaNhanVienExists(string maNhanVien)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM QLNhanVien WHERE MaNhanVien = @MaNhanVien";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text;
            if (IsMaNhanVienExists(maNhanVien))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }
            string hoTenNhanVien = txtHoTenNhanVien.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;

            string matKhau = txtMatKhau.Text;
            int soDienThoai = Convert.ToInt32(txtSoDienThoai.Text);
            string email = txtEmail.Text;
            string diaChi = txtDiaChi.Text;
            string capBac = cbCapBac.Text;

            string query = "INSERT INTO QLNhanVien (MaNhanVien, HoTenNhanVien, NgaySinh, TenDangNhap, MatKhau, SoDienThoai, Email, DiaChi, CapBac) " +
                           "VALUES (@MaNhanVien, @HoTenNhanVien, @NgaySinh, @TenDangNhap, @MatKhau, @SoDienThoai, @Email, @DiaChi, @CapBac)";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand(query, conn))
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
                if (dgvNhanVien.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvNhanVien.SelectedRows[0];
                    txtMaNhanVien.Text = selectedRow.Cells["MaNhanVien"].Value.ToString();
                    txtHoTenNhanVien.Text = selectedRow.Cells["HoTenNhanVien"].Value.ToString();
                    dtpNgaySinh.Text= selectedRow.Cells["NgaySinh"].Value.ToString();
                    txtTenDangNhap.Text = selectedRow.Cells["TenDangNhap"].Value.ToString();
                    txtMatKhau.Text = selectedRow.Cells["MatKhau"].Value.ToString();
                    txtSoDienThoai.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                    txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                    cbCapBac.Text = selectedRow.Cells["CapBac"].Value.ToString();
                    isEditing = true;
                    editedRowIndex = selectedRow.Index;
                    btnThem.Enabled = false;
                    btnSua.Text = "Lưu";
                }
            }
            else
            {
                string maNhanVien = txtMaNhanVien.Text;
                if (IsMaNhanVienExists(maNhanVien) && maNhanVien != dgvNhanVien.Rows[editedRowIndex].Cells["MaNhanVien"].Value.ToString())
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác.");
                    return;
                }
                string hoTenNhanVien = txtHoTenNhanVien.Text;
                DateTime ngaySinh = dtpNgaySinh.Value;
                string tenDangNhap = txtTenDangNhap.Text;
                string matKhau = txtMatKhau.Text;
                int soDienThoai = Convert.ToInt32(txtSoDienThoai.Text);
                string email = txtEmail.Text;
                string diaChi = txtDiaChi.Text;
                string capBac = cbCapBac.Text;

                string connString = @"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE QLNhanVien SET MaNhanVien = @MaNhanVien, HoTenNhanVien = @HoTenNhanVien,NgaySinh = @NgaySinh, TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, SoDienThoai = @SoDienThoai, Email = @Email, DiaChi = @DiaChi, CapBac = @CapBac  WHERE MaNhanVien = @OldMaNhanVien";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar).Value = maNhanVien;
                            command.Parameters.Add("@HoTenNhanVien", SqlDbType.NVarChar).Value = hoTenNhanVien;
                            command.Parameters.Add("@NgaySinh", SqlDbType.NVarChar).Value = ngaySinh;
                            command.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = tenDangNhap;
                            command.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = matKhau;
                            command.Parameters.Add("@SoDienThoai", SqlDbType.VarChar).Value = soDienThoai;
                            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = diaChi;
                            command.Parameters.Add("@CapBac", SqlDbType.NVarChar).Value = capBac;
                            command.Parameters.Add("@OldMaNhanVien", SqlDbType.VarChar).Value = dgvNhanVien.Rows[editedRowIndex].Cells["MaNhanVien"].Value.ToString();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Dữ liệu đã được cập nhật.");
                        }
                        dataQLNhanVien();
                        txtMaNhanVien.Clear();
                        txtHoTenNhanVien.Clear();
                        txtTenDangNhap.Clear();
                        txtMatKhau.Clear();
                        txtSoDienThoai.Clear();
                        txtEmail.Clear();
                        txtDiaChi.Clear();

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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                string maNhanVien = dgvNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();

                string query = "DELETE FROM QLNhanVien WHERE MaNhanVien = @MaNhanVien";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            string hoTenNhanVien = dgvNhanVien.SelectedRows[0].Cells["HoTenNhanVien"].Value.ToString();
                            string ngaySinh = dgvNhanVien.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
                            string tenDangNhap = dgvNhanVien.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
                            string matKhau = dgvNhanVien.SelectedRows[0].Cells["MatKhau"].Value.ToString();
                            int soDienThoai = Convert.ToInt32(dgvNhanVien.SelectedRows[0].Cells["SoDienThoai"].Value);
               
                            string email = dgvNhanVien.SelectedRows[0].Cells["Email"].Value.ToString();
                            string diaChi = dgvNhanVien.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                            string capBac = dgvNhanVien.SelectedRows[0].Cells["CapBac"].Value.ToString();

                            // Thêm các thông tin đã lấy vào bảng thùng rác dgvThungRacQLSach
                            string insertQuery = "INSERT INTO ThungRacQLNhanVien (MaNhanVien, HoTenNhanVien, NgaySinh, TenDangNhap, MatKhau, SoDienThoai, Email, DiaChi, CapBac) " +
                                                 "VALUES (@MaNhanVien, @HoTenNhanVien, @NgaySinh, @TenDangNhap, @MatKhau, @SoDienThoai, @Email, @DiaChi, @CapBac)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                                insertCmd.Parameters.AddWithValue("@HoTenNhanVien", hoTenNhanVien);
                                insertCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                insertCmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                                insertCmd.Parameters.AddWithValue("@MatKhau", matKhau);
                                insertCmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                                insertCmd.Parameters.AddWithValue("@Email", email);
                                insertCmd.Parameters.AddWithValue("@DiaChi", diaChi);
                                insertCmd.Parameters.AddWithValue("@CapBac", capBac);
                         

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
                string query = "SELECT * FROM QLNhanVien WHERE MaNhanVien LIKE @Keyword OR HoTenNhanVien LIKE @Keyword";
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

                                dgvNhanVien.DataSource = dataTable;

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

        private void btnThungRac_Click(object sender, EventArgs e)
        {
            frmThungRacNhanVien thungRacForm = new frmThungRacNhanVien();

            thungRacForm.ShowDialog();
        }
    }
}
