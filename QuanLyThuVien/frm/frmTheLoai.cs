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
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
        private void dataQLTheLoai()
        {
            conn.Open();
            string sql = "SELECT * FROM QLTheLoai";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dgvTheLoai.DataSource = dt;
        }
        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            dataQLTheLoai();
        }
        private void RefreshDataGridView()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM QLTheLoai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvTheLoai.DataSource = dataTable;
                    }
                }
            }
        }
        private bool IsMaNhanVienExists(string maNhanVien)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM QLTheLoai WHERE MaTheLoai = @MaTheLoai";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaTheLoai", maNhanVien);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtMaTheLoai.Text;
            if (IsMaNhanVienExists(maTheLoai))
            {
                MessageBox.Show("Mã thể loại đã tồn tại. Vui lòng nhập mã khác.");
                return;
            }
            string tenTheLoai = txtTenTheLoai.Text;
            string moTaNgan = txtMoTaNgan.Text;
            DateTime ngayTao = dtpNgayTao.Value;
          

            string query = "INSERT INTO QLTheLoai (MaTheLoai, TenTheLoai, MoTaNgan, NgayTao) " +
                           "VALUES (@MaTheLoai, @TenTheLoai, @MoTaNgan, @NgayTao)";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                cmd.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);
                cmd.Parameters.AddWithValue("@MoTaNgan", moTaNgan);
                cmd.Parameters.AddWithValue("@NgayTao", ngayTao);

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
                if (dgvTheLoai.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvTheLoai.SelectedRows[0];
                    txtMaTheLoai.Text = selectedRow.Cells["MaTheLoai"].Value.ToString();
                    txtTenTheLoai.Text = selectedRow.Cells["TenTheLoai"].Value.ToString();
                    txtMoTaNgan.Text = selectedRow.Cells["MoTaNgan"].Value.ToString();
                    dtpNgayTao.Text = selectedRow.Cells["NgayTao"].Value.ToString();

                    isEditing = true;
                    editedRowIndex = selectedRow.Index;
                    btnThem.Enabled = false;
                    btnSua.Text = "Lưu";
                }
            }
            else
            {
                string maTheLoai = txtMaTheLoai.Text;
                if (IsMaNhanVienExists(maTheLoai) && maTheLoai != dgvTheLoai.Rows[editedRowIndex].Cells["MaNhanVien"].Value.ToString())
                {
                    MessageBox.Show("Mã loại đã tồn tại. Vui lòng chọn mã khác.");
                    return;
                }
                string tenTheLoai = txtTenTheLoai.Text;
                string moTaNgan = txtMoTaNgan.Text;
                string ngayTao = dtpNgayTao.Text;

                string connString = @"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE QLTheLoai SET MaTheLoai = @MaTheLoai, TenTheLoai = @TenTheLoai, MoTaNgan = @MoTaNgan, NgayTao = @NgayTao  WHERE MaTheLoai = @OldMaTheLoai";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@MaTheLoai", SqlDbType.VarChar).Value = maTheLoai;
                            command.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar).Value = tenTheLoai;
                            command.Parameters.Add("@MoTaNgan", SqlDbType.NVarChar).Value = moTaNgan;
                            command.Parameters.Add("@NgayTao", SqlDbType.NVarChar).Value = ngayTao;
                            command.Parameters.Add("@OldMaTheLoai", SqlDbType.VarChar).Value = dgvTheLoai.Rows[editedRowIndex].Cells["MaTheLoai"].Value.ToString();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Dữ liệu đã được cập nhật.");
                        }
                        dataQLTheLoai();
                        txtMaTheLoai.Clear();
                        txtTenTheLoai.Clear();
                        txtMoTaNgan.Clear();

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
            if (dgvTheLoai.SelectedRows.Count > 0)
            {
                string maTheLoai = dgvTheLoai.SelectedRows[0].Cells["MaTheLoai"].Value.ToString();

                string query = "DELETE FROM QLTheLoai WHERE MaTheLoai = @MaTheLoai";
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0SI7UHO;Initial Catalog=QLThuVien;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            string tenTheLoai = dgvTheLoai.SelectedRows[0].Cells["TenTheLoai"].Value.ToString();
                        
                            string moTaNgan = dgvTheLoai.SelectedRows[0].Cells["MoTaNgan"].Value.ToString();
                            string ngayTao = dgvTheLoai.SelectedRows[0].Cells["NgayTao"].Value.ToString();
       

                            // Thêm các thông tin đã lấy vào bảng thùng rác dgvThungRacQLSach
                            string insertQuery = "INSERT INTO ThungRacQLTheLoai (MaTheLoai, TenTheLoai, MoTaNgan, NgayTao) " +
                                                 "VALUES (@MaTheLoai, @TenTheLoai, @MoTaNgan, @NgayTao)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                                insertCmd.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);
                                insertCmd.Parameters.AddWithValue("@MoTaNgan", moTaNgan);
                                insertCmd.Parameters.AddWithValue("@NgayTao", ngayTao);

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
                string query = "SELECT * FROM QLTheLoai WHERE MaTheLoai LIKE @Keyword OR TenTheLoai LIKE @Keyword";
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

                                dgvTheLoai.DataSource = dataTable;

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
            frmThungRacQLTheLoai thungRacForm = new frmThungRacQLTheLoai();

            thungRacForm.ShowDialog();
        }
    }
}
