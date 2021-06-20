
namespace ltm
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnNgay = new System.Windows.Forms.RadioButton();
            this.rbnThang = new System.Windows.Forms.RadioButton();
            this.rbnNam = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBD = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpKT = new System.Windows.Forms.DateTimePicker();
            this.lblThang = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.chrTienBan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.chrTienNhap = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDT = new System.Windows.Forms.Label();
            this.lblVon = new System.Windows.Forms.Label();
            this.lblRoi = new System.Windows.Forms.Label();
            this.lblLai = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrTienBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrTienNhap)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(185)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1636, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::ltm.Properties.Resources.logo_tienich;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 89);
            this.label1.TabIndex = 1;
            this.label1.Text = "     THỐNG KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbnNgay
            // 
            this.rbnNgay.AutoSize = true;
            this.rbnNgay.Location = new System.Drawing.Point(50, 133);
            this.rbnNgay.Name = "rbnNgay";
            this.rbnNgay.Size = new System.Drawing.Size(91, 20);
            this.rbnNgay.TabIndex = 1;
            this.rbnNgay.TabStop = true;
            this.rbnNgay.Text = "Theo ngày";
            this.rbnNgay.UseVisualStyleBackColor = true;
            // 
            // rbnThang
            // 
            this.rbnThang.AutoSize = true;
            this.rbnThang.Location = new System.Drawing.Point(436, 133);
            this.rbnThang.Name = "rbnThang";
            this.rbnThang.Size = new System.Drawing.Size(94, 20);
            this.rbnThang.TabIndex = 2;
            this.rbnThang.TabStop = true;
            this.rbnThang.Text = "Theo tháng";
            this.rbnThang.UseVisualStyleBackColor = true;
            this.rbnThang.CheckedChanged += new System.EventHandler(this.rbnThang_CheckedChanged);
            // 
            // rbnNam
            // 
            this.rbnNam.AutoSize = true;
            this.rbnNam.Location = new System.Drawing.Point(672, 133);
            this.rbnNam.Name = "rbnNam";
            this.rbnNam.Size = new System.Drawing.Size(87, 20);
            this.rbnNam.TabIndex = 3;
            this.rbnNam.TabStop = true;
            this.rbnNam.Text = "Theo năm";
            this.rbnNam.UseVisualStyleBackColor = true;
            this.rbnNam.CheckedChanged += new System.EventHandler(this.rbnNam_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ";
            // 
            // dtpBD
            // 
            this.dtpBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBD.Location = new System.Drawing.Point(84, 164);
            this.dtpBD.Name = "dtpBD";
            this.dtpBD.Size = new System.Drawing.Size(116, 22);
            this.dtpBD.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "đến";
            // 
            // dtpKT
            // 
            this.dtpKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKT.Location = new System.Drawing.Point(253, 163);
            this.dtpKT.Name = "dtpKT";
            this.dtpKT.Size = new System.Drawing.Size(120, 22);
            this.dtpKT.TabIndex = 33;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(433, 167);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(84, 16);
            this.lblThang.TabIndex = 34;
            this.lblThang.Text = "Chọn tháng : ";
            this.lblThang.Visible = false;
            // 
            // cboThang
            // 
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(526, 162);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(121, 24);
            this.cboThang.TabIndex = 35;
            this.cboThang.Visible = false;
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(767, 163);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(121, 24);
            this.cboNam.TabIndex = 37;
            this.cboNam.Visible = false;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(674, 167);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(77, 16);
            this.lblNam.TabIndex = 36;
            this.lblNam.Text = "Chọn năm : ";
            this.lblNam.Visible = false;
            // 
            // chrTienBan
            // 
            chartArea1.Name = "ChartArea1";
            this.chrTienBan.ChartAreas.Add(chartArea1);
            this.chrTienBan.Location = new System.Drawing.Point(73, 273);
            this.chrTienBan.Name = "chrTienBan";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Doanh thu bán hàng";
            this.chrTienBan.Series.Add(series1);
            this.chrTienBan.Size = new System.Drawing.Size(607, 463);
            this.chrTienBan.TabIndex = 38;
            this.chrTienBan.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Biểu đồ doanh thu của hàng";
            title1.Text = "Biểu đồ doanh thu của hàng";
            this.chrTienBan.Titles.Add(title1);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1013, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 43);
            this.button1.TabIndex = 39;
            this.button1.Text = "Thống Kê";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chrTienNhap
            // 
            chartArea2.Name = "ChartArea1";
            this.chrTienNhap.ChartAreas.Add(chartArea2);
            this.chrTienNhap.Location = new System.Drawing.Point(797, 273);
            this.chrTienNhap.Name = "chrTienNhap";
            this.chrTienNhap.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.Name = "Vốn nhập";
            this.chrTienNhap.Series.Add(series2);
            this.chrTienNhap.Size = new System.Drawing.Size(621, 463);
            this.chrTienNhap.TabIndex = 40;
            this.chrTienNhap.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Biểu đồ vốn nhập của cửa hàng";
            title2.Text = "Biểu đồ vốn nhập của cửa hàng";
            this.chrTienNhap.Titles.Add(title2);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lblLai);
            this.panel2.Controls.Add(this.lblRoi);
            this.panel2.Controls.Add(this.lblVon);
            this.panel2.Controls.Add(this.lblDT);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 907);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1636, 154);
            this.panel2.TabIndex = 41;
            // 
            // lblDT
            // 
            this.lblDT.AutoSize = true;
            this.lblDT.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDT.Location = new System.Drawing.Point(104, 40);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(72, 33);
            this.lblDT.TabIndex = 0;
            this.lblDT.Text = "label4";
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVon.Location = new System.Drawing.Point(458, 40);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(72, 33);
            this.lblVon.TabIndex = 1;
            this.lblVon.Text = "label4";
            // 
            // lblRoi
            // 
            this.lblRoi.AutoSize = true;
            this.lblRoi.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoi.Location = new System.Drawing.Point(1137, 40);
            this.lblRoi.Name = "lblRoi";
            this.lblRoi.Size = new System.Drawing.Size(71, 33);
            this.lblRoi.TabIndex = 2;
            this.lblRoi.Text = "label5";
            // 
            // lblLai
            // 
            this.lblLai.AutoSize = true;
            this.lblLai.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLai.Location = new System.Drawing.Point(816, 40);
            this.lblLai.Name = "lblLai";
            this.lblLai.Size = new System.Drawing.Size(72, 33);
            this.lblLai.TabIndex = 3;
            this.lblLai.Text = "label4";
            // 
            // frmThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1636, 1061);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chrTienNhap);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chrTienBan);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.dtpKT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpBD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbnNam);
            this.Controls.Add(this.rbnThang);
            this.Controls.Add(this.rbnNgay);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrTienBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrTienNhap)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbnNgay;
        private System.Windows.Forms.RadioButton rbnThang;
        private System.Windows.Forms.RadioButton rbnNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpKT;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrTienBan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrTienNhap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLai;
        private System.Windows.Forms.Label lblRoi;
        private System.Windows.Forms.Label lblVon;
        private System.Windows.Forms.Label lblDT;
    }
}