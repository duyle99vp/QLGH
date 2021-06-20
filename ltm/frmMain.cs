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
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGach_Click(object sender, EventArgs e)
        {
            Functions.CloseForm(this);
            Functions.MenuMove(btnGach,pnlMove);
            frmGachHoa frmGH = new frmGachHoa();
            Functions.MenuClick(frmGH, this);
        }

        private void btnKH_Click(object sender, EventArgs e)
        {     
            Functions.CloseForm(this);
            Functions.MenuMove(btnKH, pnlMove);
            frmKhachHang frmKH = new frmKhachHang();
            Functions.MenuClick(frmKH, this);
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            Functions.CloseForm(this);
            Functions.MenuMove(btnNCC, pnlMove);
            frmNCC frmNCC = new frmNCC();
            Functions.MenuClick(frmNCC, this);
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            Functions.CloseForm(this);
            Functions.MenuMove(btnHD, pnlMove);
            frmHoaDon frmHD = new frmHoaDon();
            Functions.MenuClick(frmHD, this);
        }

        private void btnPN_Click(object sender, EventArgs e)
        {
            Functions.CloseForm(this);
            Functions.MenuMove(btnPN, pnlMove);
            frmPhieuNhap frmPN = new frmPhieuNhap();
            Functions.MenuClick(frmPN, this);
            frmPN.Dock = DockStyle.Fill;
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            Functions.CloseForm(this);
            Functions.MenuMove(btnTK, pnlMove);
            frmThongKe frmTK = new frmThongKe();
            Functions.MenuClick(frmTK, this);

        }

        private void btnND_Click(object sender, EventArgs e)
        {
            Functions.CloseForm(this);
            Functions.MenuMove(btnND, pnlMove);
            frmNguoiDung frmND = new frmNguoiDung();
            Functions.MenuClick(frmND, this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect();//Mở kết nối
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            string loai =frm.GetID().Trim();
            if (loai == "Quản lý")
            {
                btnPN.Visible = true;
                btnND.Visible = true;
            }
        }
    }
}
