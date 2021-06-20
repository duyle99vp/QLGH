using ltm.Class;
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

namespace ltm
{
    public partial class frmPhieuNhap : Form
    {
        DataTable tblPN;
        DataTable tblPNCT;
        char btn;
        String rbn, soluongc;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {

            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            txtSL.Text = "0";
            txtDonGia.Text = "0";
            txtTien.Text = "0";
            LoadDataGridView();
            Disable();
            Functions.FillCombo("SELECT MaG, TenG FROM GachHoa ", cboMaG, "MaG", "MaG");
            cboMaG.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNCC, TenNCC FROM NCC", cboMaNCC, "MaNCC", "MaNCC");
            cboMaNCC.SelectedIndex = -1;
            rbnMaPN_CheckedChanged(sender, e);
        }

        private void Disable()
        {
            txtMaPN.Enabled = false;
            cboMaNCC.Enabled = false;
            cboMaG.Enabled = false;
            txtSL.Enabled = false;
            txtDonGia.Enabled = false;
            dtpThoiGian.Enabled = false;
        }

        private void Enable()
        {
            cboMaNCC.Enabled = true;
            cboMaG.Enabled = true;
            txtSL.Enabled = true;
            txtDonGia.Enabled = true;
            dtpThoiGian.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btn = 't';
            Enable();          
            txtMaPN.Focus();
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaPN.Text = Functions.CreateKey("PN");
            ResetValues();
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            btn = 's';
            txtSL.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled= false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            cboMaG.Enabled = true;
            soluongc = txtSL.Text.Trim();
        }

        //Hiển thị phiếu nhập
        private void LoadDataGridView()
        {
            String sql;
          //  sql = "SELECT * FROM PhieuNhap";
            sql = "SELECT a.MaPN,a.ThoiGian,a.MaNCC,b.TenNCC FROM PhieuNhap AS a, NCC AS b WHERE a.MaNCC = b.MaNCC ";

            tblPN = Functions.GetDataToTable(sql);
            dgvPN.DataSource = tblPN;
            dgvPN.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvPN.Columns[2].HeaderText = "Mã nhà cung cấp";
            dgvPN.Columns[1].HeaderText = "Thời gian";
            dgvPN.Columns[3].HeaderText = "Tên nhà cung cấp";
            dgvPN.Columns[0].Width = 200;
            dgvPN.Columns[1].Width = 100;
            dgvPN.Columns[2].Width = 200;
            dgvPN.Columns[3].Width = 250;
            dgvPN.AllowUserToAddRows = false;
            dgvPN.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        //Hiển thị phiếu nhập CT
        private void LoadDateGirdViewCT()
        {
            String sql;
       //     sql = "SELECT * FROM CTPhieuNhap WHERE MaPN = N'" + txtMaPN.Text.Trim() + "'";
            sql = "SELECT a.MaG,b.TenG,a.SoLuong,a.DonGia,a.SoLuong * a.DonGia AS ThanhTien FROM CTPhieuNhap AS a,GachHoa AS b WHERE a.MaPN = N'" + txtMaPN.Text.Trim() + "' AND a.MaG=b.MaG";
           
            tblPNCT = Functions.GetDataToTable(sql);
            dgvPNCT.DataSource = tblPNCT;

            dgvPNCT.Columns[0].HeaderText = "Mã gạch";
            dgvPNCT.Columns[1].HeaderText = "Tên gạch";
            dgvPNCT.Columns[2].HeaderText = "Số lượng";
            dgvPNCT.Columns[3].HeaderText = "Đơn giá";
            dgvPNCT.Columns[4].HeaderText = "Thành tiền";

            dgvPNCT.Columns[0].Width = 150;
            dgvPNCT.Columns[1].Width = 150;
            dgvPNCT.Columns[2].Width = 150;
            dgvPNCT.Columns[3].Width = 150;
            dgvPNCT.Columns[4].Width = 250;
            dgvPNCT.AllowUserToAddRows = false;
            dgvPNCT.EditMode = DataGridViewEditMode.EditProgrammatically;
            TongTien();
        }

        //tính tổng tiền
        private void TongTien()
        {
            String sql;
 
            if (dgvPNCT.Rows.Count > 0)
            {
                sql = "SELECT SUM(SoLuong * DonGia) FROM CTPhieuNhap WHERE MaPN = N'"+txtMaPN.Text.Trim()+"'";
                txtTongTien.Text =  Functions.GetFieldValues(sql);
            }
            else txtTongTien.Text = "0";
            lblTien.Text = Functions.ChuyenSoSangChuoi(double.Parse(txtTongTien.Text));
        }


        private void ResetValues()
        {

            dtpThoiGian.Text = "";
            cboMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChiNCC.Text = "";
            txtSDTNCC.Text = "";
            cboMaG.Text = "";
            txtTenG.Text = "";
            txtSL.Text = "0";
            txtDonGia.Text = "0";
            txtTien.Text = "0";
        }
        
        private void cboMaNCC_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboMaNCC.Text == "")
            {
                txtTenNCC.Text = "";
                txtDiaChiNCC.Text = "";
                txtSDTNCC.Text = "";
            }
            // Khi chọn Mã NCC thì các trường khác tự động hiện ra
            sql = "Select TenNCC from NCC where MaNCC =N'" + cboMaNCC.SelectedValue + "'";
            txtTenNCC.Text = Functions.GetFieldValues(sql);
            sql = "Select DiaChi from NCC where MaNCC =N'" + cboMaNCC.SelectedValue + "'";
            txtDiaChiNCC.Text = Functions.GetFieldValues(sql);
            sql = "Select SDT from NCC where MaNCC =N'" + cboMaNCC.SelectedValue + "'";
            txtSDTNCC.Text = Functions.GetFieldValues(sql);
        }

        private void cboMaG_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboMaG.Text == "")
            {
                txtTenG.Text = "";
            }
            sql = "Select TenG from GachHoa where MaG =N'" + cboMaG.SelectedValue + "'";
            txtTenG.Text = Functions.GetFieldValues(sql);
           
        }

        private void rbnMaPN_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbn = "MaPN";
            sql = "SELECT * fROM PhieuNhap";
            tblPN = Functions.GetDataToTable(sql); //Lấy dữ liệu
            cboSearch.DataSource = tblPN;
            cboSearch.DisplayMember = "MaPN";
            cboSearch.ValueMember = "MaPN";
            cboSearch.Text = "";
        }

        private void rbnTenNcc_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbn = "MaNCC";
            sql = "SELECT * fROM NCC";
            tblPN = Functions.GetDataToTable(sql); //Lấy dữ liệu
            cboSearch.DataSource = tblPN;
            cboSearch.DisplayMember = "MaNCC";
            cboSearch.ValueMember = "MaNCC";
            cboSearch.Text = "";
        }
        
        //Khi click vào các hàng trong datagridview
        private void dgvPN_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPN.Focus();
                return;
            }
            if (tblPN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaPN.Text = dgvPN.CurrentRow.Cells[0].Value.ToString();
            dtpThoiGian.Text = dgvPN.CurrentRow.Cells[1].Value.ToString();
            cboMaNCC.Text = dgvPN.CurrentRow.Cells[2].Value.ToString();
            cboMaNCC_TextChanged(sender, e);
            LoadDateGirdViewCT();
            TongTien();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            cboMaG.Text = "";
            txtTenG.Text = "";
            txtSL.Text = "0";
            txtTien.Text = "0";
            txtDonGia.Text = "0";
            Disable();
        }

        private void dgvPNCT_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPN.Focus();
                return;
            }
            if (tblPNCT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMaG.Text = dgvPNCT.CurrentRow.Cells[0].Value.ToString();
            txtSL.Text = dgvPNCT.CurrentRow.Cells[2].Value.ToString();
            cboMaG_TextChanged(sender, e);
            txtSL_TextChanged(sender, e);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            Disable();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            {
                if (cboMaNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa chọn mã NCC!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaNCC.Focus();
                    return;
                }
                if (cboMaG.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa chọn mà gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaG.Focus();
                    return;
                }
                if (txtSL.Text == "0")
                {
                    MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSL.Focus();
                    return;
                }
                if (btn == 't')
                {
                    sql = "SELECT MaPN FROM PhieuNhap WHERE MaPN=N'" + txtMaPN.Text.Trim() + "'";
                    if (!Functions.CheckKey(sql))//Chưa có mã PN
                    {
                        sql = "INSERT INTO PhieuNhap(MaPN, ThoiGian, MaNCC) VALUES " +
                            "(N'" + txtMaPN.Text.Trim() + "',N'" + dtpThoiGian.Text.Trim() + "',N'" + cboMaNCC.SelectedValue + "')";
                        Functions.RunSQL(sql);
                        LoadDataGridView();
                    }

                    //Lưu thông tin của các mặt hàng
                    if (cboMaG.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn phải nhập mã gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboMaG.Focus();
                        return;
                    }

                    if (txtSL.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn phải nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSL.Focus();
                        return;
                    }

                    sql = "SELECT MaG FROM CTPhieuNhap WHERE MaG = N'" + cboMaG.SelectedValue + "' AND MaPN = N'" + txtMaPN.Text.Trim() + "'";
                    if (Functions.CheckKey(sql))
                    {
                        MessageBox.Show("Mã gạch này đã có, bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboMaG.Focus();
                        cboMaG.Text = "";
                        return;
                    }

                    sql = "INSERT INTO CTPhieuNhap(MaPN, MaG, SoLuong, DonGia)" +
                        " VALUES(N'" + txtMaPN.Text.Trim() + "',N'" + cboMaG.SelectedValue + "',N'" + txtSL.Text.Trim() + "',N'" + txtDonGia.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                    sql = "UPDATE GachHoa SET SLN = (SLN + "+txtSL.Text.Trim()+") Where MaG = N'"+cboMaG.SelectedValue+"'";
                    Functions.RunSQL(sql);
                    LoadDateGirdViewCT();
                }


                //Sửa
                if (btn == 's')
                {
                    if (MessageBox.Show("Bạn có muốn lưu chỉnh sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        

                        sql = "UPDATE CTPhieuNhap SET SoLuong=N'" + txtSL.Text.Trim() + "' WHERE MaPN=N'" + txtMaPN.Text + "' AND MaG= N'" + cboMaG.SelectedValue + "'";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã cập nhật số lượng mã gạch: " + cboMaG.SelectedValue + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "UPDATE GachHoa SET SLN = (SLN + " + txtSL.Text.Trim() + " - "+soluongc+") Where MaG = N'" + cboMaG.SelectedValue + "'";
                        Functions.RunSQL(sql);
                        LoadDateGirdViewCT();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaPN.Text = "";
            Disable();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            
            
            if (tblPN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "SELECT MaG,SoLuong FROM CTPhieuNhap WHERE MaPN = N'" + txtMaPN.Text.Trim() + "'";

                DataTable table = Functions.GetDataToTable(sql);
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {     
                    double sl, slcon, slxoa;
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sql = "SELECT MaG,SoLuong FROM CTPhieuNhap WHERE MaPN = N'" + txtMaPN.Text + "'";
                        DataTable tblHang = Functions.GetDataToTable(sql);
                        for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                        {
                            // Cập nhật lại số lượng cho các mặt hàng
                            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLN FROM GachHoa WHERE MaG = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                            slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                            slcon = sl - slxoa;
                            sql = "UPDATE GachHoa SET SLN =" + slcon + " WHERE MaG= N'" + tblHang.Rows[hang][0].ToString() + "'";
                            Functions.RunSQL(sql);
                        }
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = Functions.Con;
                        sql = "DELETE CTPhieuNhap WHERE MaPN=N'" + txtMaPN.Text.Trim() + "'";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        sql = "DELETE PhieuNhap WHERE MaPN=N'" + txtMaPN.Text.Trim() + "'";
                        Functions.RunSQLDel(sql);

                        LoadDataGridView();
                        LoadDateGirdViewCT();
                        ResetValues();
                        btnHuy.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnThem.Enabled = true;
                        txtMaPN.Text = "";

                    }
                }
            }
            
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
          
            try
            {
                Convert.ToInt32(txtSL.Text);
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
                MessageBox.Show("Bạn phải nhập số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSL.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSL.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg * 1000;
            txtTien.Text = tt.ToString();
        }

        private void dgvPNCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string MaG, sql;
            //    Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblPNCT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                MaG = dgvPNCT.CurrentRow.Cells["MaG"].Value.ToString();
                sql = "DELETE CTPhieuNhap WHERE MaPN=N'" + txtMaPN.Text + "' AND MaG = N'" + MaG + "'";
                Functions.RunSQL(sql);
                // LoadDataGridView();
                LoadDateGirdViewCT();
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            txtSL_TextChanged(sender, e);
        }

        private void btnTimKiemNCC_Click(object sender, EventArgs e)
        {
            
            string sql;
            if (cboSearch.Text.Trim() == "")
            {
                /* MessageBox.Show("Bạn hãy nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 cboSearch.Focus();
                 return; */
                LoadDataGridView();
            }
            if (rbn == "MaPN") //Tìm kiếm theo mã PN
            {
                sql = "SELECT * FROM PhieuNhap WHERE MaPN LIKE N'%" + cboSearch.Text.Trim() + "%'";
                tblPN = Functions.GetDataToTable(sql);
            }
            if (rbn == "MaNCC") //Tìm kiếm theo mã NCC
            {
                sql = "SELECT * FROM PhieuNhap WHERE MaNCC LIKE N'%" + cboSearch.Text.Trim() + "%'";
                tblPN = Functions.GetDataToTable(sql);
            }
            if (tblPN.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + tblPN.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvPN.DataSource = tblPN;
            //ResetValues();
        }
    }
}
