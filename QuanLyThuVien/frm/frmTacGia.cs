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
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLTacGia()
        {
            conn.Open();
            string sql = "SELECT * FROM QLTacGia";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvTacGia.DataSource = dt;
        }
        private void frmTacGia_Load(object sender, EventArgs e)
        {
            dataQLTacGia();

        }
        private bool IsMaSachExists(string maSach)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM QLTacGia WHERE MaTacGia = @MaTacGia";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaTacGia", maSach);
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
                string query = "SELECT * FROM QLTacGia";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvTacGia.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maTacGia = txtMaTacGia.Text;
            if (IsMaSachExists(maTacGia))
            {
                MessageBox.Show("Mã tác giả đã tồn tại. Vui lòng chọn mã sách khác.");
                return;
            }
            string tenTacGia = txtTenTacGia.Text;

            DateTime ngaySinh = dtpNgaySinh.Value;
            string queQuan = txtQueQuan.Text;
            string soDienThoai = txtSoDienThoai.Text;

            string query = "INSERT INTO QLTacGia (MaTacGia, TenTacGia, NgaySinh, QueQuan, SoDienThoai) " +
                           "VALUES (@MaTacGia, @TenTacGia, @NgaySinh, @QueQuan, @SoDienThoai)";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);
                cmd.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@QueQuan", queQuan);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);


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
                if (dgvTacGia.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvTacGia.SelectedRows[0];
                    txtMaTacGia.Text = selectedRow.Cells["MaTacGia"].Value.ToString();
                    txtTenTacGia.Text = selectedRow.Cells["TenTacGia"].Value.ToString();
                    dtpNgaySinh.Text = selectedRow.Cells["NgaySinh"].Value.ToString();
                    txtQueQuan.Text = selectedRow.Cells["QueQuan"].Value.ToString();
                    txtSoDienThoai.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();

                    isEditing = true;
                    editedRowIndex = selectedRow.Index;
                    btnThem.Enabled = false;
                    btnSua.Text = "Lưu";
                }
            }
            else
            {
                string maTacGia = txtMaTacGia.Text;
                if (IsMaSachExists(maTacGia) && maTacGia != dgvTacGia.Rows[editedRowIndex].Cells["MaTacGia"].Value.ToString())
                {
                    MessageBox.Show("Mã tác giả đã tồn tại. Vui lòng nhập mã sách khác.");
                    return;
                }
                string tenTacGia = txtTenTacGia.Text;
                DateTime ngaySinh = dtpNgaySinh.Value;
                string queQuan = txtQueQuan.Text;
                string soDienThoai = txtSoDienThoai.Text;

                string connString = @"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE QLTacGia SET MaTacGia = @MaTacGia, TenTacGia = @TenTacGia, NgaySinh = @NgaySinh, QueQuan = @QueQuan, SoDienThoai = @SoDienThoai WHERE MaTacGia = @OldMaTacGia";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@MaTacGia", SqlDbType.VarChar).Value = maTacGia;
                            command.Parameters.Add("@TenTacGia", SqlDbType.NVarChar).Value = tenTacGia;
                            command.Parameters.Add("@NgaySinh", SqlDbType.VarChar).Value = ngaySinh;
                            command.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = queQuan;
                            command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = soDienThoai;

                            command.Parameters.Add("@OldMaTacGia", SqlDbType.VarChar).Value = dgvTacGia.Rows[editedRowIndex].Cells["MaTacGia"].Value.ToString();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Dữ liệu đã được cập nhật.");
                        }
                        dataQLTacGia();
                        txtMaTacGia.Clear();
                        txtTenTacGia.Clear();
                        txtQueQuan.Clear();
                        txtSoDienThoai.Clear();

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
            if (dgvTacGia.SelectedRows.Count > 0)
            {
                string maTacGia = dgvTacGia.SelectedRows[0].Cells["MaTacGia"].Value.ToString();

                string query = "DELETE FROM QLTacGia WHERE MaTacGia = @MaTacGia";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
    
                            string tenTacGia = dgvTacGia.SelectedRows[0].Cells["TenTacGia"].Value.ToString();
                            string ngaySinh = dgvTacGia.SelectedRows[0].Cells["NgaySinh"].Value.ToString();

                            string queQuan = dgvTacGia.SelectedRows[0].Cells["QueQuan"].Value.ToString();
                            string soDienThoai = dgvTacGia.SelectedRows[0].Cells["SoDienThoai"].Value.ToString();


                            // Thêm các thông tin đã lấy vào bảng thùng rác dgvThungRacQLSach
                            string insertQuery = "INSERT INTO ThungRacQLTacGia (MaTacGia, TenTacGia, NgaySinh, QueQuan, SoDienThoai) " +
                                                 "VALUES (@MaTacGia, @TenTacGia, @NgaySinh, @QueQuan, @SoDienThoai)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MaTacGia", maTacGia);
                                insertCmd.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                                insertCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                insertCmd.Parameters.AddWithValue("@QueQuan", queQuan);
                                insertCmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

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
                string query = "SELECT * FROM QLTacGia WHERE MaTacGia LIKE @Keyword OR TenTacGia LIKE @Keyword";
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

                                dgvTacGia.DataSource = dataTable;

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
            frmThungRacTacGia thungRacForm = new frmThungRacTacGia();

            thungRacForm.ShowDialog();
        }
    }
}
