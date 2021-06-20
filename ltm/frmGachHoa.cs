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
using System.IO;

namespace ltm
{
    public partial class frmGachHoa : Form
    {
        DataTable tblGH;
        char btn, rbt;

        public frmGachHoa()
        {
            InitializeComponent();
        }

        private void frmGachHoa_Load(object sender, EventArgs e)
        {           
            btnSuaG.Enabled = false;
            btnXoaG.Enabled = false;
            btnLuuG.Enabled = false;
            btnHuyG.Enabled = false;
            Disable();
            LoadDataGridView();
            rbnMa_CheckedChanged(sender, e);
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaG,TenG,LoaiG,DvTinh,Gia,Anh, SLN-SLB as SL FROM GachHoa";
            tblGH = Functions.GetDataToTable(sql);
            dgvGH.DataSource = tblGH;         
            dgvGH.Columns[0].HeaderText = "Mã gạch hoa";
            dgvGH.Columns[1].HeaderText = "Tên gạch hoa";
            dgvGH.Columns[2].HeaderText = "Loại gạch hoa";
            dgvGH.Columns[3].HeaderText = "Đơn vị tính";
            dgvGH.Columns[4].HeaderText = "Giá";
            dgvGH.Columns[5].HeaderText = "Số lượng";

            dgvGH.Columns[0].Width = 150;
            dgvGH.Columns[1].Width = 150;
            dgvGH.Columns[2].Width = 150;
            dgvGH.Columns[3].Width = 150;
            dgvGH.Columns[4].Width = 150;
            dgvGH.Columns[5].Width = 150;
            dgvGH.Columns[6].Width = 150;
            dgvGH.AllowUserToAddRows = false;
            dgvGH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThemG_Click(object sender, EventArgs e)
        {
            btn = 't';
            btnSuaG.Enabled = false;
            btnXoaG.Enabled = false;
            btnHuyG.Enabled = true;
            btnLuuG.Enabled = true;
            btnThemG.Enabled = false;
            ResetValues();
            Enable();
            txtMa.Focus();
        }

        private void Disable()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtLoai.Enabled = false;
            txtGia.Enabled = false;
            txtDV.Enabled = false;
            txtAnh.Enabled = false;
            picAnh.Enabled = false;
            btnChonAnh.Enabled = false;
        }

        private void Enable()
        {
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtLoai.Enabled = true;
            txtGia.Enabled = true;
            txtDV.Enabled = true;
            txtAnh.Enabled = false;
            picAnh.Enabled = false;
            btnChonAnh.Enabled = true;
        }
        private void ResetValues()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtLoai.Text = "";
            txtDV.Text = "";
            txtGia.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                
            }
            picAnh.Image.Save(@"D:\ltm\ltm2\ltm\Resources\image" + txtMa.Text.Trim() + ".jpg");

            txtAnh.Text = Functions.GetPath("/Resoures/image/") + txtMa.Text.Trim();
        }

        private void btnSuaG_Click(object sender, EventArgs e)
        {
            btn = 's';
            if (tblGH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMa.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnLuuG.Enabled = true;
            btnHuyG.Enabled = true;
            Enable();
            txtMa.Enabled = false;
        }

        private void btnXoaG_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblGH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE GachHoa WHERE MaG=N'" + txtMa.Text.Trim() + "'";
                Functions.RunSQLDel(sql);
                LoadDataGridView();
                ResetValues();
                btnHuyG.Enabled = false;
                btnLuuG.Enabled = false;
                btnSuaG.Enabled = false;
                btnXoaG.Enabled = false;
            }
        }

        private void btnHuyG_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuyG.Enabled = false;
            btnThemG.Enabled = true;
            btnXoaG.Enabled = false;
            btnSuaG.Enabled = false;
            btnLuuG.Enabled = false;
            Disable();
         }

        private void rbnMa_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 'm';
            sql = "SELECT * fROM GachHoa";
            tblGH = Functions.GetDataToTable(sql); //Lấy dữ liệu
            cboSearch.DataSource = tblGH;
            cboSearch.DisplayMember = "MaG";
            cboSearch.ValueMember = "MaG";
            cboSearch.Text = "";
        }

        private void rbnTen_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 't';
            sql = "SELECT * fROM GachHoa";
            tblGH = Functions.GetDataToTable(sql); //Lấy dữ liệu
            cboSearch.DataSource = tblGH;
            cboSearch.DisplayMember = "TenG"; 
            cboSearch.ValueMember = "TenG";
            cboSearch.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboSearch.Text.Trim() == "")
            {
                /* MessageBox.Show("Bạn hãy nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 cboSearch.Focus();
                 return; */
                LoadDataGridView();
            }
            if (rbt == 'm') //Tìm kiếm theo mã GH
            {
                sql = "SELECT * FROM GachHoa WHERE MaG LIKE N'%" + cboSearch.Text.Trim() + "%'";
                tblGH = Functions.GetDataToTable(sql);
            }
            if (rbt == 't') //Tìm kiếm theo Tên GH
            {
                sql = "SELECT * FROM GachHoa WHERE TenG LIKE N'%" + cboSearch.Text.Trim() + "%'";
                tblGH = Functions.GetDataToTable(sql);
            }
            if (tblGH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else 
                MessageBox.Show("Có " + tblGH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvGH.DataSource = tblGH;
            ResetValues();
        }

        private void dgvGH_Click(object sender, EventArgs e)
        {
            if (btnThemG.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblGH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMa.Text = dgvGH.CurrentRow.Cells["MaG"].Value.ToString();
            txtTen.Text = dgvGH.CurrentRow.Cells["TenG"].Value.ToString();
            txtLoai.Text = dgvGH.CurrentRow.Cells["LoaiG"].Value.ToString();
            txtDV.Text = dgvGH.CurrentRow.Cells["DvTinh"].Value.ToString();
            txtGia.Text = dgvGH.CurrentRow.Cells["Gia"].Value.ToString();
            txtAnh.Text = dgvGH.CurrentRow.Cells["Anh"].Value.ToString();
            if (txtAnh.Text != "")
            {
                picAnh.Image = Image.FromFile(txtAnh.Text);
            }
            else
                picAnh.Image = null;
            btnSuaG.Enabled = true;
            btnXoaG.Enabled = true;
            Disable();
       //     btnHuyG.Enabled = true;
        }

        private void btnLuuG_Click(object sender, EventArgs e)
        {
            string sql;
            {
                if (txtMa.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    return;
                }
                if (txtLoai.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập loại gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLoai.Focus();
                    return;
                }
                if (txtDV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đơn vị tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDV.Focus();
                    return;
                }

                if (txtGia.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGia.Focus();
                    return;
                }
                /*if (txtAnh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn ảnh cho gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnChonAnh.Focus();
                    return;
                }
                */
                //Thêm gạch
                if (btn == 't')
                {
                    sql = "SELECT MaG FROM GachHoa WHERE MaG=N'" + txtMa.Text.Trim() + "'";
                    if (Functions.CheckKey(sql))
                    {
                        MessageBox.Show("Mã gạch này đã có, bạn phải nhập mã gạch khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMa.Focus();
                        txtMa.Text = "";
                        return;
                    }

                    sql = "INSERT INTO GachHoa(MaG,TenG,LoaiG,DvTinh,Gia,Anh) VALUES" +
                        "(N'" + txtMa.Text.Trim() + "',N'" + txtTen.Text.Trim() + "',N'" + txtLoai.Text.Trim() + "',N'"
                        + txtDV.Text.Trim() + "','" + txtGia.Text.Trim() + "',N'" + txtAnh.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                    LoadDataGridView();
                    MessageBox.Show("Đã thêm gạch mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValues();
                    btnXoaG.Enabled = false;
                    btnThemG.Enabled = true;
                    btnSuaG.Enabled = false;
                    btnHuyG.Enabled = false;
                    btnLuuG.Enabled = false;
                    Disable();
                    //txtMa.Enabled = false;
                }
                //Sửa 
                if (btn == 's')
                {
                    if (MessageBox.Show("Bạn có muốn lưu thông tin chỉnh sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        sql = "UPDATE GachHoa SET TenG=N'" + txtTen.Text.Trim() + "',LoaiG=N'" + txtLoai.Text.Trim() + "'," +
                        "DvTinh=N'" + txtDV.Text.Trim() + "',Gia='" + txtGia.Text.Trim() + "'," +
                        "Anh=N'" + txtAnh.Text.Trim() + "' WHERE MaG=N'" + txtMa.Text.Trim() + "'";
                        Functions.RunSQL(sql);
                        LoadDataGridView();
                        MessageBox.Show("Đã cập nhật gạch mã :" + txtMa.Text.Trim() + "thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValues();
                        btnXoaG.Enabled = false;
                        btnThemG.Enabled = true;
                        btnSuaG.Enabled = false;
                        btnHuyG.Enabled = false;
                        btnLuuG.Enabled = false;
                        Disable();
                    }
                }
            }
        }
    }
}
