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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
//using COMExcel = Microsoft.Office.Interop.Excel;



namespace ltm
{

    public partial class frmHoaDon : Form
    {
        DataTable tblHD, tblCTHD;
        char btn, rbt;
        String soluongc;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void Disable()
        {
            txtMaHD.Enabled = false;
            cboMaKH.Enabled = false;
            cboMaG.Enabled = false;
            txtSL.Enabled = false;
            dtpThoiGian.Enabled = false;
            
        }

        private void Enable()
        {
            cboMaKH.Enabled = true;
            cboMaG.Enabled = true;
            txtSL.Enabled = true;
            dtpThoiGian.Enabled = true;
        }

        private void ResetValues()
        {

            dtpThoiGian.Text = "";
            cboMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            cboMaG.Text = "";
            txtTenG.Text = "";
            txtSL.Text = "0";
            txtDonGia.Text = "0";
            txtTien.Text = "0";
        }

        

        private void TongTien()
        {
            
            if (dgvCTHD.Rows.Count > 0)
            {
                string sql = "SELECT SUM(SoLuong * DonGia) FROM CTHoaDon WHERE MaHD = N'" + txtMaHD.Text.Trim() + "'";
                txtTongTien.Text = Functions.GetFieldValues(sql);

            }
            else txtTongTien.Text = "0";
            lblTongTien.Text =Functions.ChuyenSoSangChuoi( double.Parse(txtTongTien.Text));
        }

       
       

        private void LoadDataGridView()
        {
            String sql;
            sql = "SELECT a.MaHD,a.ThoiGian,a.MaKH,b.TenKH FROM HoaDon AS a, KhachHang AS b WHERE a.MaKH = b.MaKH ";
            tblHD = Functions.GetDataToTable(sql);
            dgvHD.DataSource = tblHD;  
            dgvHD.AllowUserToAddRows = false;
            dgvHD.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void LoadDateGirdViewCT()
        {
            String sql;
            sql = "SELECT a.MaG,b.TenG,a.SoLuong,a.DonGia,a.SoLuong * a.DonGia AS ThanhTien FROM CTHoaDon AS a,GachHoa AS b WHERE a.MaHD = N'" + txtMaHD.Text.Trim() + "' AND a.MaG=b.MaG";
            tblCTHD = Functions.GetDataToTable(sql);
            dgvCTHD.DataSource = tblCTHD;
            dgvCTHD.AllowUserToAddRows = false;
            dgvCTHD.EditMode = DataGridViewEditMode.EditProgrammatically;
            TongTien();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
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
            Functions.FillCombo("SELECT MaG FROM GachHoa ", cboMaG, "MaG", "MaG");
            cboMaG.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaKH FROM KhachHang", cboMaKH, "MaKH", "MaKH");
            cboMaKH.SelectedIndex = -1;
            rbnTenKH_CheckedChanged(sender, e);
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
            }
            // Khi chọn Mã KH thì các trường khác tự động hiện ra
            sql = "Select TenKH from KhachHang where MaKH =N'" + cboMaKH.SelectedValue + "'";
            txtTenKH.Text = Functions.GetFieldValues(sql);
            sql = "Select DiaChi from KhachHang where MaKH =N'" + cboMaKH.SelectedValue + "'";
            txtDiaChi.Text = Functions.GetFieldValues(sql);
            sql = "Select SDT from KhachHang where MaKH =N'" + cboMaKH.SelectedValue + "'";
            txtSDT.Text = Functions.GetFieldValues(sql);
        }

        private void cboMaG_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboMaG.Text == "")
            {
                txtTenG.Text = "";
            }
            sql = "Select TenG from GachHoa where MaG =N'" + cboMaG.SelectedValue + "'";
            txtTenG.Text = Functions.GetFieldValues(sql);
            
            sql = "Select Gia from GachHoa where MaG =N'" + cboMaG.SelectedValue + "'";
            txtDonGia.Text = Functions.GetFieldValues(sql);
            txtSL_TextChanged(sender, e);
        }

        private void dgvHD_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Focus();
                return;
            }
            if (tblHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHD.Text = dgvHD.CurrentRow.Cells[0].Value.ToString().Trim();
            dtpThoiGian.Text = dgvHD.CurrentRow.Cells[1].Value.ToString();
            cboMaKH.Text = dgvHD.CurrentRow.Cells[2].Value.ToString();

            cboMaKH_SelectedIndexChanged(sender, e);
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

        private void dgvCTHD_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Focus();
                return;
            }
            if (tblCTHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMaG.Text = dgvCTHD.CurrentRow.Cells[0].Value.ToString();
            txtSL.Text = dgvCTHD.CurrentRow.Cells[2].Value.ToString();
            cboMaG_SelectedIndexChanged(sender, e);
            txtSL_TextChanged(sender, e);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            Disable();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            btn = 't';
            Enable();
            txtMaHD.Focus();
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaHD.Text = Functions.CreateKey("HD");
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btn = 's';
            txtSL.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            cboMaG.Enabled = true;
            soluongc = txtSL.Text.Trim();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            ResetValues();
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHD.Text = "";
            Disable();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHD.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "SELECT MaG,SoLuong FROM CTHoaDon WHERE MaHD = N'" + txtMaHD.Text.Trim() + "'";

                DataTable table = Functions.GetDataToTable(sql);
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    double sl, slcon, slxoa;
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sql = "SELECT MaG,SoLuong FROM CTHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
                        DataTable tblHang = Functions.GetDataToTable(sql);
                        for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                        {
                            // Cập nhật lại số lượng cho các mặt hàng
                            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLB FROM GachHoa WHERE MaG = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                            slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                            slcon = sl - slxoa;
                            sql = "UPDATE GachHoa SET SLB =" + slcon + " WHERE MaG= N'" + tblHang.Rows[hang][0].ToString() + "'";
                            Functions.RunSQL(sql);
                        }
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = Functions.Con;
                        sql = "DELETE CTHoaDon WHERE MaHD=N'" + txtMaHD.Text.Trim() + "'";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        sql = "DELETE HoaDon WHERE MaHD=N'" + txtMaHD.Text.Trim() + "'";
                        Functions.RunSQLDel(sql);

                        LoadDataGridView();
                        LoadDateGirdViewCT();
                        ResetValues();
                        btnHuy.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnThem.Enabled = true;
                        txtMaHD.Text = "";
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            {
                if (cboMaKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa chọn mã khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaKH.Focus();
                    return;
                }
                if (cboMaG.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa chọn mã gạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    sql = "SELECT MaHD FROM HoaDon WHERE MaHD=N'" + txtMaHD.Text.Trim() + "'";
                    if (!Functions.CheckKey(sql))//Chưa có mã HD
                    {
                        sql = "INSERT INTO HoaDon(MaHD, ThoiGian, MaKH) VALUES " +
                            "(N'" + txtMaHD.Text.Trim() + "',N'" + dtpThoiGian.Text.Trim() + "',N'" + cboMaKH.SelectedValue + "')";
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

                    sql = "SELECT MaG FROM CTHoaDon WHERE MaG = N'" + cboMaG.SelectedValue + "' AND MaHD = N'" + txtMaHD.Text.Trim() + "'";
                    if (Functions.CheckKey(sql))
                    {
                        MessageBox.Show("Mã gạch này đã có, bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboMaG.Focus();
                        cboMaG.Text = "";
                        return;
                    }
                    // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
                     double sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLN-SLB as SL FROM GachHoa WHERE MAG = N'" + cboMaG.SelectedValue + "'"));
                    if (Convert.ToDouble(txtSL.Text) > sl)
                    {
                        MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSL.Text = "";
                        txtSL.Focus();
                        return;
                    }

                    sql = "INSERT INTO CTHoaDon(MaHD, MaG, SoLuong, DonGia)" +
                        " VALUES(N'" + txtMaHD.Text.Trim() + "',N'" + cboMaG.SelectedValue + "',N'" + txtSL.Text.Trim() + "',N'" + txtDonGia.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                    sql = "UPDATE GachHoa SET SLB = (SLB + " + txtSL.Text.Trim() + ") Where MaG = N'" + cboMaG.SelectedValue + "'";
                    Functions.RunSQL(sql);
                    LoadDateGirdViewCT();
                }


                //Sửa
                if (btn == 's')
                {
                    if (MessageBox.Show("Bạn có muốn lưu chỉnh sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        sql = "UPDATE CTHoaDon SET SoLuong=N'" + txtSL.Text.Trim() + "' WHERE MaHD=N'" + txtMaHD.Text + "' AND MaG= N'" + cboMaG.SelectedValue + "'";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã cập nhật số lượng mã gạch: " + cboMaG.SelectedValue + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "UPDATE GachHoa SET SLB = (SLB + " + txtSL.Text.Trim() + " - " + soluongc + ") Where MaG = N'" + cboMaG.SelectedValue + "'";
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

        private void dgvCTHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaG, sql;
            //    Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                MaG = dgvCTHD.CurrentRow.Cells["MaG"].Value.ToString();
                sql = "DELETE CTHoaDon WHERE MaHD=N'" + txtMaHD.Text + "' AND MaG = N'" + MaG + "'";
                Functions.RunSQL(sql);
                // LoadDataGridView();
                LoadDateGirdViewCT();
            }
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
            if (rbt == 't')
            {
                sql = "SELECT a.MaHD,a.ThoiGian,a.MaKH,b.TenKH FROM HoaDon AS a, KhachHang AS b WHERE a.MaKH = b.MaKH and b.TenKH LIKE N'%" + cboSearch.Text.Trim() + "%'";
                tblHD = Functions.GetDataToTable(sql);
            }
            if (rbt == 'm') 
            {
                sql = "SELECT a.MaHD,a.ThoiGian,a.MaKH,b.TenKH FROM HoaDon AS a, KhachHang AS b  WHERE a.MaKH = b.MaKH and a.MaHD LIKE N'%" + cboSearch.Text.Trim() + "%'";
                tblHD = Functions.GetDataToTable(sql);
            }
            if (tblHD.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblHD.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHD.DataSource = tblHD;
            ResetValues();
        }

       
        private void rbnTenKH_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 't';
            sql = "SELECT TenKH fROM KhachHang";
            Functions.FillCombo(sql, cboSearch, "TenKH", "TenKH");
            cboSearch.Text = "";
        }

        private void rbnMaHD_CheckedChanged(object sender, EventArgs e)
        {
            string sql;
            rbt = 'm';
            sql = "SELECT MaHD fROM HoaDon";
            Functions.FillCombo(sql, cboSearch, "MaHD", "MaHD");
            cboSearch.Text = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            LoadDateGirdViewCT();
            if (dgvCTHD.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = txtMaHD.Text.Trim() + ".pdf";
               
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                       
                        Document doc = new Document(PageSize.A4.Rotate());
                        
                        BaseFont arial = BaseFont.CreateFont(Functions.GetPath("/Resources/ARIAL.TTF") , BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font f_12_nomal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font f_25_bold = new iTextSharp.text.Font(arial, 25, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font f_12_italic = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.ITALIC);
                        iTextSharp.text.Font f_12_bold = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.BOLD);


                        FileStream os = new FileStream(sfd.FileName,FileMode.Create);
                        
                        using (os)
                        {
                            PdfWriter.GetInstance(doc, os);
                            doc.Open();
                            
                            PdfPTable tbl1 = new PdfPTable(2);
                            //Ảnh
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(Properties.Resources.logo, System.Drawing.Imaging.ImageFormat.Png);
                            PdfPCell cell1 = new PdfPCell(image);
                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            //Thông tin
                            PdfPCell cell2 = new PdfPCell();
                            Chunk c1 = new Chunk("CỬA HÀNG GẠCH HOA DUZHOME", f_15_bold);
                            Chunk c2 = new Chunk("Địa chỉ: 548 Hùng Vương, Đồng Tâm, Vĩnh Yên, Vĩnh Phúc \nĐiện thoại: 0325698233 \nEmail: cuahangduzome@gmail.com", f_12_nomal);
                            cell2.AddElement(c1);
                            cell2.AddElement(c2);
                            cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;

                            //Hoa don
                            string[] partsDay;
                            partsDay = dtpThoiGian.Text.Split('/');
                            Paragraph p_hoadon = new Paragraph();
                            Chunk c_hoadon = new Chunk("HÓA ĐƠN BÁN HÀNG\n", f_25_bold);
                            Chunk c_thoigian = new Chunk("Ngày " + partsDay[1]+" tháng " + partsDay[0] + " năm "+ partsDay[2], f_12_italic);
                            p_hoadon.Add(c_hoadon);
                            p_hoadon.Add(c_thoigian);
                            p_hoadon.Alignment = Element.ALIGN_CENTER;
                            p_hoadon.SpacingAfter = 20;
                            p_hoadon.SpacingBefore = 30;
                            tbl1.AddCell(cell1);
                            tbl1.AddCell(cell2);
                            doc.Add(tbl1);
                            doc.Add(p_hoadon);

                            //Thông tin khách hàng
                            Paragraph p_kh = new Paragraph("Họ và tên khách hàng: "+txtTenKH.Text +"\nSố điện thoại: "+txtSDT.Text+"\nĐịa chỉ: "+txtDiaChi.Text,f_12_nomal);
                            doc.Add(p_kh);

                            //Bảng CTHD
                            PdfPTable talCTHD = new PdfPTable(dgvCTHD.Columns.Count);
                            talCTHD.DefaultCell.Padding = 6;
                            talCTHD.WidthPercentage = 100;
                            talCTHD.HorizontalAlignment = Element.ALIGN_LEFT;
                            

                            foreach (DataGridViewColumn column in dgvCTHD.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,f_12_nomal));
                                talCTHD.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvCTHD.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    talCTHD.AddCell(cell.Value.ToString());
                                }
                            }
                            talCTHD.SpacingBefore = 20;
                            doc.Add(talCTHD);

                            //Tổng tiền
                            PdfPTable tal_tien = new PdfPTable(2);
                            PdfPCell cell_tongtien = new PdfPCell(new Phrase("Tổng tiền ", f_12_nomal));
                            PdfPCell cell_tien = new PdfPCell(new Phrase(txtTongTien.Text, f_12_nomal));
                            PdfPCell cell_tienchu = new PdfPCell(new Phrase("Số tiền viết bằng chữ: "+lblTongTien.Text, f_12_nomal));
                            cell_tongtien.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cell_tongtien.PaddingRight = 8;
                            float[] width = new float[] { 400, 100 };
                            tal_tien.WidthPercentage = 100;
                            tal_tien.SetWidths(width);
                            tal_tien.AddCell(cell_tongtien);
                            tal_tien.AddCell(cell_tien);
                            PdfPTable tal_tienchu = new PdfPTable(1);
                            tal_tienchu.WidthPercentage = 100;
                            tal_tienchu.SetWidths(new float[] {500});
                            tal_tienchu.AddCell(cell_tienchu);

                            doc.Add(tal_tien);
                            doc.Add(tal_tienchu);

                            //Chữ ký
                            PdfPTable tal_chuky= new PdfPTable(2);
                            PdfPCell cell_mua = new PdfPCell();
                             c1 = new Chunk("  Người mua hàng", f_12_bold);
                             c2 = new Chunk("(Ký, ghi rõ họ , tên)", f_12_italic);
                            cell_mua.AddElement(c1);
                            cell_mua.AddElement(c2);
                            cell_mua.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell_mua.PaddingLeft = 100;
                            PdfPCell cell_ban = new PdfPCell();
                            c1 = new Chunk("  Người bán hàng", f_12_bold);
                            c2 = new Chunk("(Ký, ghi rõ họ , tên)", f_12_italic);
                            cell_ban.AddElement(c1);
                            cell_ban.AddElement(c2);
                            cell_ban.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell_ban.PaddingLeft = 150;
                            tal_chuky.AddCell(cell_mua);
                            tal_chuky.AddCell(cell_ban);
                            tal_chuky.WidthPercentage = 100;
                            tal_chuky.SpacingBefore = 20;
                            doc.Add(tal_chuky);

                            doc.Close();


                            //mở doc
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }


    }
}
