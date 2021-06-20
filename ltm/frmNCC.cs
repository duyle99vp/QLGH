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
    public partial class frmNCC : Form
    {
        DataTable tblNCC;
        char btn, rbt;
        public frmNCC()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NCC";
            tblNCC = Functions.GetDataToTable(sql); //Lấy dữ liệu
            dgvNCC.DataSource = tblNCC; //Hiển thị vào dataGridView
            dgvNCC.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;//Không cho sửa dữ liệu trực tiếp

        }

        // Ẩn các txt
        private void Disable()
        {
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSdtNcc.Enabled = false;
            txtDiaChiNCC.Enabled = false;
        }

        //Hiện các txt
        private void Enable()
        {
            txtMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            txtSdtNcc.Enabled = true;
            txtDiaChiNCC.Enabled = true;
        }

        private void ResetValues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSdtNcc.Text = "";
            txtDiaChiNCC.Text = "";
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            LoadDataGridView();
            Disable();
            rbnTen_CheckedChanged(sender, e);
        }

        private void dgvNCC_Click(object sender, EventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNCC.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
            txtDiaChiNCC.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
            txtSdtNcc.Text = dgvNCC.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            Disable();
        }


        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            btn = 't';
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            Enable();
            txtMaNCC.Focus();
        }
        

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            btn = 's';
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            Enable();
            txtMaNCC.Enabled = false;
        }

        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            string sql;
            {
                if (txtMaNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNCC.Focus();
                }
                if (txtTenNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNCC.Focus();
                }
                if (txtDiaChiNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChiNCC.Focus();
                }
                if (txtSdtNcc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSdtNcc.Focus();
                }

                //Thêm 
                if (btn == 't')
                {
                    sql = "SELECT MaNCC FROM NCC WHERE MaNCC=N'" + txtMaNCC.Text.Trim() + "'";
                    if (Functions.CheckKey(sql))
                    {
                        MessageBox.Show("nhà cung cấp này đã có, bạn phải nhập nhà cung cấp khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaNCC.Focus();
                        txtMaNCC.Text = "";
                        return;

                    }

                    sql = "INSERT INTO NCC VALUES" +
                        "(N'" + txtMaNCC.Text.Trim() + "',N'" + txtTenNCC.Text.Trim() + "',N'" + txtDiaChiNCC.Text.Trim() + "',N'" + txtSdtNcc.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                    LoadDataGridView();
                    MessageBox.Show("Đã thêm nhà cung cấp mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValues();
                    btnXoa.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    Disable();
                }
                //Sửa 
                if (btn == 's')
                {
                    if (MessageBox.Show("Bạn có muốn lưu chỉnh sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        sql = "UPDATE NCC SET TenNCC=N'" + txtTenNCC.Text.Trim() + "',DiaChi=N'" + txtDiaChiNCC.Text.Trim() +
                            "', SDT=N'" + txtSdtNcc.Text.Trim() + "' WHERE MaNCC=N'" + txtMaNCC.Text + "'";
                        Functions.RunSQL(sql);
                        LoadDataGridView();
                        MessageBox.Show("Đã cập nhật nhà cung cấp:" + txtMaNCC.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValues();
                        btnXoa.Enabled = false;
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                        btnHuy.Enabled = false;
                        btnLuu.Enabled = false;
                        Disable();
                    }
                }
            }

        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NCC WHERE MaNCC='" + txtMaNCC.Text.Trim() + "'";
                Functions.RunSQLDel(sql);
                LoadDataGridView();
                ResetValues();
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void rbnTen_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 't';
            sql = "SELECT TenNCC fROM NCC";
            Functions.FillCombo(sql, cboSearch, "TenNCC", "TenNCC");
            cboSearch.Text = "";
        }

        private void rbnMa_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 'm';
            sql = "SELECT MaNCC fROM NCC";
            Functions.FillCombo(sql, cboSearch, "MaNCC", "MaNCC");
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
                sql = "SELECT * FROM NCC WHERE MaNCC LIKE N'%" + cboSearch.Text + "%'";
                tblNCC = Functions.GetDataToTable(sql);
                
            }
            if (rbt == 't') //Tìm kiếm theo Tên
            {
                sql = "SELECT * FROM NCC WHERE TenNCC LIKE N'%" + cboSearch.Text + "%'";
                tblNCC = Functions.GetDataToTable(sql);
                
            }
            if (tblNCC.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblNCC.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvNCC.DataSource = tblNCC;
            ResetValues();
        }
     
        private void btnHuyNCC_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            Disable();
        }
    }
}
