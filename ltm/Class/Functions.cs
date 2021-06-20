using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ltm.Class
{
    class Functions
    {
        public static SqlConnection Con; //Khai báo đối tượng kết nối
        public static void Connect()
        {
            Con = new SqlConnection(); //Khởi tạo đối tượng kết nối
            Con.ConnectionString = @"Data Source = 192.168.8.129; Initial Catalog = QLGH; Persist Security Info = True; User ID = sa; Password = 123456";
            
            Con.Open();
            //Kiểm tra kết nối
            if (Con.State == ConnectionState.Open)
            {
                MessageBox.Show("Kết nối thành công!");
            }
            else
                MessageBox.Show("Không thể kết nối với dử liệu!");
        }

        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close(); //Đóng kết nối
                Con.Dispose(); //Giải phóng tài nguyên
                Con = null;
            }
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        public static void RunSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Con);
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL(update, insert,delete)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        public static void RunSQLDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.Con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        internal static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter();//Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            dap.SelectCommand = new SqlCommand();//Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand.Connection = Con;
            dap.SelectCommand.CommandText = sql;
            //SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        //Lấy dữ liệu từ câu lệnh sql
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }

        //Gán giá trị cho Combobox
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            try
            {
                SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
                DataTable table = new DataTable();
                dap.Fill(table);
                cbo.DataSource = table;
                cbo.ValueMember = ma; //Trường giá trị
                cbo.DisplayMember = ten; //Trường hiển thị
            }
            catch (Exception ex)
            {

            }
        }

        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/06/2021
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + d + t;
            return key;
        }
        //di chuyển panel vàng
        public static void MenuMove(Button btn, Panel pnl)
        {           
            pnl.Height = btn.Height - 1;
            pnl.Top = btn.Top;
            pnl.Visible = true;
        }

        //hiển thị form
        public static void MenuClick(Form frm , Form frmM)
        {
            frm.MdiParent = frmM;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //Đóng các form đã mở
        public static void CloseForm(Form frm)
        {
            if(frm.MdiChildren.Length > 0)
            {
                frm.ActiveMdiChild.Close();
            }
        }


        //Chuyển số thành chữ
        static string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        //Viết hàm chuyển số hàng chục, giá trị truyền vào là số cần chuyển và một biến đọc phần lẻ hay không ví dụ 101 => một trăm lẻ một
        private static string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private static string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private static  string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        public static string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }
        public static string GetPath(string fname)
        {

            string startupPath = System.IO.Directory.GetCurrentDirectory();

            startupPath = AppDomain.CurrentDomain.BaseDirectory;
            startupPath = startupPath.Replace("\\bin\\Debug", "");
            startupPath = startupPath.Replace("\\", "/");
            return startupPath + fname.Trim();
            

        }
    }

}
