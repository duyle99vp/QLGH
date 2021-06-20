using ltm.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ltm
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        
        public string GetID()
        {
            string loaiND = "";
            try
            {
                DataTable tblLogin;
                string sql;
                sql = "SELECT * FROM NguoiDung WHERE Username = N'" + txtUser.Text.Trim() + "'AND Password = N'" + txtPass.Text.Trim() + "'";
                tblLogin = Functions.GetDataToTable(sql);
                if (tblLogin != null)
                {
                    foreach (DataRow dr in tblLogin.Rows)
                    {
                        loaiND = dr["Loai"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            return loaiND;
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DataTable tblLogin;
            string sql;

            if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập Username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập Password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }
            sql = "SELECT * FROM NguoiDung WHERE Username =N'" + txtUser.Text.Trim() + "' AND Password=N'" + txtPass.Text.Trim() + "'";
            tblLogin = Functions.GetDataToTable(sql);

            if (tblLogin.Rows.Count > 0)
            {
                this.Close();
               
            }
            else
            {
                MessageBox.Show("Sai toài khoản hoặc mật khẩu!");
                txtUser.Focus();
            }
        }

    }
}
