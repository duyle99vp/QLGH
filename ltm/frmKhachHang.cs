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
using ltm.Class;

namespace ltm
{
    public partial class frmKhachHang : Form
    {
        DataTable tblKH;
        char btn,rbt;
        public frmKhachHang()
        {
            InitializeComponent();
        }


        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM KhachHang";
            tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu
            dgvKhachHang.DataSource = tblKH; //Hiển thị vào dataGridView
            dgvKhachHang.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;//Không cho sửa dữ liệu trực tiếp

        }

        // Ẩn các txt
        private void Enable()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtSDTKH.Enabled = false;
            txtDiaChiKH.Enabled = false;         
        }

        //Hiện các txt
        private void Disable()
        {
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtSDTKH.Enabled = true;
            txtDiaChiKH.Enabled = true;
        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            txtDiaChiKH.Text = ""; 
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            LoadDataGridView();
            Enable();
            rbnTenKH_CheckedChanged(sender, e);
        }
        
        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
            txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtDiaChiKH.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSDTKH.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            Enable();

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            btn = 't';
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            Disable();
            txtMaKH.Focus();
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            string sql;
            {
                if (txtMaKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKH.Focus();
                }
                if (txtTenKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKH.Focus();
                }              
                if (txtDiaChiKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChiKH.Focus();
                }
                if (txtSDTKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDTKH.Focus();
                }
                
                //Thêm 
                if (btn == 't')
                {
                    sql = "SELECT MaKH FROM KhachHang WHERE MaKH=N'" + txtMaKH.Text.Trim() + "'";
                    if (Functions.CheckKey(sql))
                    {
                        MessageBox.Show("Khách hàng này đã có, bạn phải nhập khách hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaKH.Focus();
                        txtMaKH.Text = "";
                        return;
                        
                    }

                    sql = "INSERT INTO KhachHang VALUES" +
                        "(N'" + txtMaKH.Text.Trim() + "',N'" + txtTenKH.Text.Trim() + "',N'" + txtDiaChiKH.Text.Trim() + "',N'"+ txtSDTKH.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                    LoadDataGridView();
                    MessageBox.Show("Đã thêm người dùng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValues();
                    btnXoa.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    Enable();
                }
                //Sửa 
                if (btn == 's')
                {
                    if (MessageBox.Show("Bạn có muốn lưu chỉnh sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        sql = "UPDATE KhachHang SET TenKH=N'" + txtTenKH.Text.Trim() + "',DiaChi=N'" + txtDiaChiKH.Text.Trim() + 
                            "', SDT=N'" + txtSDTKH.Text.Trim() + "' WHERE MaKH=N'" + txtMaKH.Text + "'";
                        Functions.RunSQL(sql);
                        LoadDataGridView();
                        MessageBox.Show("Đã cập nhật khách hàng:" + txtMaKH.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValues();
                        btnXoa.Enabled = false;
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                        btnHuy.Enabled = false;
                        btnLuu.Enabled = false;
                        Enable();
                    }
                }
            }

        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            btn = 's';
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            Disable();
            txtMaKH.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhachHang WHERE MaKH='" + txtMaKH.Text.Trim() + "'";
                Functions.RunSQLDel(sql);
                LoadDataGridView();
                ResetValues();
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            Enable();
        }

        private void rbnTenKH_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 't';
            sql = "SELECT TenKH fROM KhachHang";
            Functions.FillCombo(sql, cboSearch, "TenKH", "TenKH");
            cboSearch.Text = "";
        }

        private void rbnMaKH_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 'm';
            sql = "SELECT MaKH fROM KhachHang";
            Functions.FillCombo(sql, cboSearch, "MaKH", "MaKH");
            cboSearch.Text = "";
        }

       

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboSearch.Text.Trim() == "")
            {
                MessageBox.Show("Bạn hãy nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSearch.Focus();
                return;
            }
            if (rbt == 'm') 
            {
                sql = "SELECT * FROM KhachHang WHERE MaKH LIKE N'%" + cboSearch.Text + "%'";
                tblKH = Functions.GetDataToTable(sql);
            }
            if (rbt == 't') //Tìm kiếm theo Tên
            {
                sql = "SELECT * FROM KhachHang WHERE TenKH LIKE N'%" + cboSearch.Text + "%'";
                tblKH = Functions.GetDataToTable(sql);
            }
            if (tblKH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblKH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvKhachHang.DataSource = tblKH;
            ResetValues();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
