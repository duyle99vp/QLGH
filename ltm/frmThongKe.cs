using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ltm.Class;

namespace ltm
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            string sql = "Select DISTINCT ThangNH  From NhapHang_view ";
            Functions.FillCombo(sql, cboThang, "ThangNH", "ThangNH");
            sql = "Select DISTINCT NamNH  From NhapHang_view ";
            Functions.FillCombo(sql, cboNam, "NamNH", "NamNH");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            string sql, dt, von; 
            double lai, roi;
            chrTienBan.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
            chrTienBan.ChartAreas["ChartArea1"].AxisY.Title = "Tiền";
            chrTienBan.Series["Doanh thu bán hàng"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chrTienBan.Series["Doanh thu bán hàng"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chrTienNhap.Series["Vốn nhập"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chrTienNhap.Series["Vốn nhập"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

            if (rbnNgay.Checked)
            {
                sql = "Select NgayHD,sum(TienBan) AS TongTien  From BanHang_view where NgayHD between '" + dtpBD.Text.Trim() + "'and'" + dtpKT.Text.Trim()+ "' GROUP BY NgayHD";
                chrTienBan.DataSource = Functions.GetDataToTable(sql);               
                chrTienBan.Series["Doanh thu bán hàng"].XValueMember ="NgayHD";
                chrTienBan.Series["Doanh thu bán hàng"].YValueMembers = "TongTien";
                sql = "Select NgayNH,sum(TienNhap) AS TongTien  From NhapHang_view where NgayNH between '" + dtpBD.Text.Trim() + "'and'" + dtpKT.Text.Trim() + "' GROUP BY NgayNH";
                chrTienNhap.DataSource = Functions.GetDataToTable(sql);                
                chrTienNhap.Series["Vốn nhập"].XValueMember = "NgayNH";   
                chrTienNhap.Series["Vốn nhập"].YValueMembers = "TongTien";
                sql = "Select sum(TienBan) AS TongTien From BanHang_view where NgayHD between '" + dtpBD.Text.Trim() + "'and'" + dtpKT.Text.Trim() + "'";
                dt = Functions.GetFieldValues(sql);
                lblDT.Text = "Doanh thu: " + dt;
                sql = "Select sum(TienNhap) AS TongTien From NhapHang_view where NgayNH between '" + dtpBD.Text.Trim() + "'and'" + dtpKT.Text.Trim() + "'";
                von = Functions.GetFieldValues(sql);
                lai = double.Parse(dt) - double.Parse(von);
                roi = lai / double.Parse(von) * 100;
                lblVon.Text = "Vốn nhập: " + von ;
                lblLai.Text = "Lãi: "+lai.ToString();
                lblRoi.Text = "ROI: " + roi.ToString() + "%";
            }
            if (rbnThang.Checked)
            {
                sql = "Select NgayHD, sum(TienBan) AS TongTien  From BanHang_view where ThangHD ='" + cboThang.SelectedValue+ "' GROUP BY NgayHD";
                chrTienBan.DataSource = Functions.GetDataToTable(sql);
                chrTienBan.Series["Doanh thu bán hàng"].XValueMember = "NgayHD";
                chrTienBan.Series["Doanh thu bán hàng"].YValueMembers = "TongTien";
                sql = "Select NgayNH,sum(TienNhap) AS TongTien  From NhapHang_view where ThangNH ='" + cboThang.SelectedValue+ "' GROUP BY NgayNH ";
                chrTienNhap.DataSource = Functions.GetDataToTable(sql);
                chrTienNhap.Series["Vốn nhập"].XValueMember = "NgayNH";
                chrTienNhap.Series["Vốn nhập"].YValueMembers = "TongTien";
                sql = "Select sum(TienBan) AS TongTien From BanHang_view where ThangHD ='" + cboThang.SelectedValue + "'";
                dt = Functions.GetFieldValues(sql);
                lblDT.Text = "Doanh thu: " + dt;
                sql = "Select sum(TienNhap) AS TongTien From NhapHang_view where ThangNH ='" + cboThang.SelectedValue + "'";
                von = Functions.GetFieldValues(sql);
                lai = double.Parse(dt) - double.Parse(von);
                roi = lai / double.Parse(von) * 100;
                lblVon.Text = "Vốn nhập: " + von;
                lblLai.Text = "Lãi: " + lai.ToString();
                lblRoi.Text = "ROI: " + roi.ToString() + "%";
            }

            if (rbnNam.Checked)
            {
                chrTienBan.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                sql = "Select ThangHD, sum(TienBan) AS TongTien  From BanHang_view where NamHD ='" + cboNam.SelectedValue + "' GROUP BY ThangHD";
                chrTienBan.DataSource = Functions.GetDataToTable(sql);
                chrTienBan.Series["Doanh thu bán hàng"].XValueMember = "ThangHD";
                chrTienBan.Series["Doanh thu bán hàng"].YValueMembers = "TongTien";
                chrTienBan.Series["Doanh thu bán hàng"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                sql = "Select ThangNH,sum(TienNhap) AS TongTien  From NhapHang_view where NamNH ='" + cboNam.SelectedValue + "' GROUP BY ThangNH ";
                chrTienNhap.DataSource = Functions.GetDataToTable(sql);
                chrTienNhap.Series["Vốn nhập"].XValueMember = "ThangNH";
                chrTienNhap.Series["Vốn nhập"].YValueMembers = "TongTien";
                chrTienNhap.Series["Vốn nhập"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                sql = "Select sum(TienBan) AS TongTien From BanHang_view where NamHD ='" + cboNam.SelectedValue + "'";
                dt = Functions.GetFieldValues(sql);
                lblDT.Text = "Doanh thu: " + dt;
                sql = "Select sum(TienNhap) AS TongTien From NhapHang_view where NamNH ='" + cboNam.SelectedValue + "'";
                von = Functions.GetFieldValues(sql);
                lai = double.Parse(dt) - double.Parse(von);
                roi = lai / double.Parse(von) * 100;
                lblVon.Text = "Vốn nhập: " + von;
                lblLai.Text = "Lãi: " + lai.ToString();
                lblRoi.Text = "ROI: " + roi.ToString() + "%";
            }
        }

        private void rbnThang_CheckedChanged(object sender, EventArgs e)
        {
            lblThang.Visible = true;
            cboThang.Visible = true;
            
            cboThang.SelectedIndex = -1;
        }

        private void rbnNam_CheckedChanged(object sender, EventArgs e)
        {
            lblNam.Visible = true;
            cboNam.Visible = true;
            
            cboNam.SelectedIndex = -1;
        }
    }
}
