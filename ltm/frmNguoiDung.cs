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
    public partial class frmNguoiDung : Form
    {
        DataTable tblUser; // Lưu dữ liệu bảng người dùng;
        Char btn, rbt;

        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            LoadDataGridView();
            Disable();
            rbnUser_CheckedChanged(sender, e);
        }

        // Ẩn các txt
        private void Disable() {
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            txtHoTen.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            cboLoai.Enabled = false;
            rbnNam.Enabled = false;
            rbnNu.Enabled = false;
            dtpNgaySinh.Enabled = false;
        }

        //Hiện các txt
        private void Enable() {
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            txtHoTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            cboLoai.Enabled = true;
            rbnNam.Enabled = true;
            rbnNu.Enabled = true;
            dtpNgaySinh.Enabled = true;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NguoiDung";
            tblUser = Functions.GetDataToTable(sql); //Lấy dữ liệu
            dgvUser.DataSource = tblUser; //Hiển thị vào dataGridView
            dgvUser.Columns[0].HeaderText = "Username";
            dgvUser.Columns[1].HeaderText = "Password";
            dgvUser.Columns[2].HeaderText = "Loại tài khoản";
            dgvUser.Columns[3].HeaderText = "Họ tên";
            dgvUser.Columns[4].HeaderText = "Ngày Sinh";
            dgvUser.Columns[5].HeaderText = "Giới tính";
            dgvUser.Columns[6].HeaderText = "Địa chỉ";
            dgvUser.Columns[7].HeaderText = "SDT";
            dgvUser.Columns[0].Width = 150;
            dgvUser.Columns[1].Width = 150;
            dgvUser.Columns[2].Width = 150;
            dgvUser.Columns[3].Width = 150;
            dgvUser.Columns[4].Width = 150;
            dgvUser.Columns[5].Width = 150;
            dgvUser.Columns[6].Width = 150;
            dgvUser.Columns[7].Width = 150;
            dgvUser.AllowUserToAddRows = false;
            dgvUser.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //Click vào hàng cột trong datagridview
        private void dgvUser_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUser.Focus(); //đặt lại con trỏ chuột   
                return;
            }
            if (tblUser.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtUser.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
            txtPass.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            cboLoai.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
            txtHoTen.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
            dtpNgaySinh.Text = dgvUser.CurrentRow.Cells[4].Value.ToString();
            if (dgvUser.CurrentRow.Cells[5].Value.ToString() == "Nam")
                rbnNam.Checked = true;
            else rbnNu.Checked = true;
            txtDiaChi.Text = dgvUser.CurrentRow.Cells[6].Value.ToString();
            txtSDT.Text = dgvUser.CurrentRow.Cells[7].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            Disable();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btn = 't';
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            Enable();
            txtUser.Focus();
        
        }
        private void ResetValues()
        {
            txtUser.Text = "";
            txtPass.Text = "";
            txtDiaChi.Text = "";
            cboLoai.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            {
                if (txtUser.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                    
                }
                if (txtPass.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Focus();
                   
                }
                if (cboLoai.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập loại tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboLoai.Focus();
                }
                if (txtHoTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                }

                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                }
                if (txtSDT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                }
                if (dtpNgaySinh.Text == "  /  /")
                {
                    MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpNgaySinh.Focus();
                }

                if (rbnNam.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nữ";
                //Thêm người dùng
                if (btn == 't')
                {
                    sql = "SELECT Username FROM NguoiDung WHERE Username=N'" + txtUser.Text.Trim() + "'";
                    if (Functions.CheckKey(sql))
                    {
                        MessageBox.Show("Username này đã có, bạn phải nhập Username khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUser.Focus();
                        txtUser.Text = "";
                        return;
                    }

                    sql = "INSERT INTO NguoiDung(Username,Password,Loai,Ten,NgaySinh,GioiTinh,DiaChi,SDT) VALUES" +
                        "(N'" + txtUser.Text.Trim() + "',N'" + txtPass.Text.Trim() + "',N'" + cboLoai.Text.Trim() + "',N'"
                        + txtHoTen.Text.Trim() + "','" + dtpNgaySinh.Text + "',N'" + gt + "',N'" + txtDiaChi.Text.Trim() + "','" + txtSDT.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                    LoadDataGridView();
                    MessageBox.Show("Đã thêm người dùng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValues();
                    btnXoa.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    Disable();
                }
                //Sửa người dùng
                if (btn == 's')
                {
                    if (MessageBox.Show("Bạn có muốn lưu chỉnh sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        sql = "UPDATE NguoiDung SET Password=N'" + txtPass.Text.Trim() + "',Loai=N'" + cboLoai.Text.Trim() + "'," +
                        "Ten=N'" + txtHoTen.Text.Trim() + "',NgaySinh='" + dtpNgaySinh.Text + "'," +
                        "GioiTinh=N'" + gt + "',DiaChi=N'" + txtDiaChi.Text.Trim() + "',SDT=N'" + txtSDT.Text.Trim() + "' WHERE Username=N'" + txtUser.Text + "'";
                        Functions.RunSQL(sql);
                        LoadDataGridView();
                        MessageBox.Show("Đã cập nhật User:" + txtUser.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            btn = 's';
            if (tblUser.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (txtUser.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            Enable();
            txtUser.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblUser.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txtUser.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NguoiDung WHERE Username=N'" + txtUser.Text + "'";
                Functions.RunSQLDel(sql);
                LoadDataGridView();
                ResetValues();
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void rbnUser_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 'u';
            sql = "SELECT * fROM NguoiDung";
            tblUser = Functions.GetDataToTable(sql); //Lấy dữ liệu
            cboSearch.DataSource = tblUser;
            cboSearch.DisplayMember = "Username";
            cboSearch.ValueMember = "Username";
            cboSearch.Text = "";
        }

        private void rbnTen_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 'n';
            sql = "SELECT * fROM NguoiDung";
            tblUser = Functions.GetDataToTable(sql); //Lấy dữ liệu
            cboSearch.DataSource = tblUser;
            cboSearch.DisplayMember = "Ten";
            cboSearch.ValueMember = "Ten";
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
            if (rbt == 'u') //Tìm kiếm theo Username
            {
                sql = "SELECT * FROM NguoiDung WHERE Username LIKE N'%" + cboSearch.Text + "%'";
                tblUser = Functions.GetDataToTable(sql);
            }
            if (rbt == 'n') //Tìm kiếm theo Tên
            {
                sql = "SELECT * FROM NguoiDung WHERE Ten LIKE N'%" + cboSearch.Text + "%'";
                tblUser = Functions.GetDataToTable(sql);
            }
            if (tblUser.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblUser.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvUser.DataSource = tblUser;
            ResetValues();
        }

        private void btnHuy_Click(object sender, EventArgs e)
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
