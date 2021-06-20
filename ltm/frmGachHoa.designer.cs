namespace ltm
{
    partial class frmGachHoa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGachHoa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.rbnTen = new System.Windows.Forms.RadioButton();
            this.rbnMa = new System.Windows.Forms.RadioButton();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvGH = new System.Windows.Forms.DataGridView();
            this.btnHuyG = new System.Windows.Forms.Button();
            this.btnLuuG = new System.Windows.Forms.Button();
            this.btnXoaG = new System.Windows.Forms.Button();
            this.btnSuaG = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.txtDV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThemG = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGH)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cboSearch);
            this.groupBox1.Controls.Add(this.rbnTen);
            this.groupBox1.Controls.Add(this.rbnMa);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Location = new System.Drawing.Point(0, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1636, 133);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cboSearch
            // 
            this.cboSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearch.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(494, 38);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(260, 31);
            this.cboSearch.TabIndex = 24;
            // 
            // rbnTen
            // 
            this.rbnTen.AutoSize = true;
            this.rbnTen.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnTen.Location = new System.Drawing.Point(899, 45);
            this.rbnTen.Name = "rbnTen";
            this.rbnTen.Size = new System.Drawing.Size(94, 25);
            this.rbnTen.TabIndex = 3;
            this.rbnTen.Text = "Theo tên";
            this.rbnTen.UseVisualStyleBackColor = true;
            this.rbnTen.CheckedChanged += new System.EventHandler(this.rbnTen_CheckedChanged);
            // 
            // rbnMa
            // 
            this.rbnMa.AutoSize = true;
            this.rbnMa.Checked = true;
            this.rbnMa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnMa.Location = new System.Drawing.Point(786, 46);
            this.rbnMa.Name = "rbnMa";
            this.rbnMa.Size = new System.Drawing.Size(94, 25);
            this.rbnMa.TabIndex = 2;
            this.rbnMa.TabStop = true;
            this.rbnMa.Text = "Theo mã";
            this.rbnMa.UseVisualStyleBackColor = true;
            this.rbnMa.CheckedChanged += new System.EventHandler(this.rbnMa_CheckedChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Image = global::ltm.Properties.Resources.img_timkiem;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(363, 28);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(125, 48);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "     Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvGH
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGH.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGH.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGH.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGH.GridColor = System.Drawing.Color.DodgerBlue;
            this.dgvGH.Location = new System.Drawing.Point(0, 496);
            this.dgvGH.Name = "dgvGH";
            this.dgvGH.RowHeadersWidth = 51;
            this.dgvGH.Size = new System.Drawing.Size(1636, 565);
            this.dgvGH.TabIndex = 8;
            this.dgvGH.Click += new System.EventHandler(this.dgvGH_Click);
            // 
            // btnHuyG
            // 
            this.btnHuyG.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHuyG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyG.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyG.Image = global::ltm.Properties.Resources.img_huy;
            this.btnHuyG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuyG.Location = new System.Drawing.Point(1178, 321);
            this.btnHuyG.Name = "btnHuyG";
            this.btnHuyG.Size = new System.Drawing.Size(94, 31);
            this.btnHuyG.TabIndex = 13;
            this.btnHuyG.Text = " Hủy";
            this.btnHuyG.UseVisualStyleBackColor = true;
            this.btnHuyG.Click += new System.EventHandler(this.btnHuyG_Click);
            // 
            // btnLuuG
            // 
            this.btnLuuG.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLuuG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuG.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuG.Image = global::ltm.Properties.Resources.img_luu;
            this.btnLuuG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuG.Location = new System.Drawing.Point(1178, 274);
            this.btnLuuG.Name = "btnLuuG";
            this.btnLuuG.Size = new System.Drawing.Size(94, 31);
            this.btnLuuG.TabIndex = 12;
            this.btnLuuG.Text = "Lưu";
            this.btnLuuG.UseVisualStyleBackColor = true;
            this.btnLuuG.Click += new System.EventHandler(this.btnLuuG_Click);
            // 
            // btnXoaG
            // 
            this.btnXoaG.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXoaG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaG.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaG.Image = global::ltm.Properties.Resources.img_xoa;
            this.btnXoaG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaG.Location = new System.Drawing.Point(1178, 228);
            this.btnXoaG.Name = "btnXoaG";
            this.btnXoaG.Size = new System.Drawing.Size(94, 31);
            this.btnXoaG.TabIndex = 11;
            this.btnXoaG.Text = " Xóa";
            this.btnXoaG.UseVisualStyleBackColor = true;
            this.btnXoaG.Click += new System.EventHandler(this.btnXoaG_Click);
            // 
            // btnSuaG
            // 
            this.btnSuaG.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSuaG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaG.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaG.Image = global::ltm.Properties.Resources.img_sua;
            this.btnSuaG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaG.Location = new System.Drawing.Point(1178, 182);
            this.btnSuaG.Name = "btnSuaG";
            this.btnSuaG.Size = new System.Drawing.Size(94, 31);
            this.btnSuaG.TabIndex = 10;
            this.btnSuaG.Text = "Sửa";
            this.btnSuaG.UseVisualStyleBackColor = true;
            this.btnSuaG.Click += new System.EventHandler(this.btnSuaG_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnHuyG);
            this.panel1.Controls.Add(this.btnLuuG);
            this.panel1.Controls.Add(this.btnXoaG);
            this.panel1.Controls.Add(this.btnSuaG);
            this.panel1.Controls.Add(this.btnThemG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1636, 496);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(185)))), ((int)(((byte)(244)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1636, 100);
            this.panel2.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::ltm.Properties.Resources.logo_tienich;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "       GẠCH HOA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAnh);
            this.groupBox3.Controls.Add(this.btnChonAnh);
            this.groupBox3.Controls.Add(this.picAnh);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtLoai);
            this.groupBox3.Controls.Add(this.txtDV);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtMa);
            this.groupBox3.Controls.Add(this.txtGia);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtTen);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(178, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(976, 282);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chi tiết";
            // 
            // txtAnh
            // 
            this.txtAnh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnh.Location = new System.Drawing.Point(589, 52);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(240, 26);
            this.txtAnh.TabIndex = 29;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.Location = new System.Drawing.Point(846, 47);
            this.btnChonAnh.Margin = new System.Windows.Forms.Padding(4);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(109, 38);
            this.btnChonAnh.TabIndex = 6;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // picAnh
            // 
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.Location = new System.Drawing.Point(589, 100);
            this.picAnh.Margin = new System.Windows.Forms.Padding(4);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(240, 156);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnh.TabIndex = 27;
            this.picAnh.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(518, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 22);
            this.label7.TabIndex = 25;
            this.label7.Text = "Ảnh";
            // 
            // txtLoai
            // 
            this.txtLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoai.Location = new System.Drawing.Point(215, 133);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(240, 26);
            this.txtLoai.TabIndex = 3;
            // 
            // txtDV
            // 
            this.txtDV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDV.Location = new System.Drawing.Point(215, 177);
            this.txtDV.Name = "txtDV";
            this.txtDV.Size = new System.Drawing.Size(240, 26);
            this.txtDV.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(38, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Đơn vị tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(38, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Loại gạch hoa";
            // 
            // txtMa
            // 
            this.txtMa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(215, 46);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(240, 26);
            this.txtMa.TabIndex = 1;
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.Location = new System.Drawing.Point(215, 226);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(240, 26);
            this.txtGia.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(38, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 22);
            this.label11.TabIndex = 12;
            this.label11.Text = "Giá bán";
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(215, 87);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(240, 26);
            this.txtTen.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(38, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tên gạch hoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(38, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã gạch hoa";
            // 
            // btnThemG
            // 
            this.btnThemG.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThemG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemG.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemG.Image = global::ltm.Properties.Resources.img_them;
            this.btnThemG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemG.Location = new System.Drawing.Point(1178, 137);
            this.btnThemG.Name = "btnThemG";
            this.btnThemG.Size = new System.Drawing.Size(94, 31);
            this.btnThemG.TabIndex = 9;
            this.btnThemG.Text = " Thêm";
            this.btnThemG.UseVisualStyleBackColor = true;
            this.btnThemG.Click += new System.EventHandler(this.btnThemG_Click);
            // 
            // frmGachHoa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1636, 1061);
            this.Controls.Add(this.dgvGH);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGachHoa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Vat Tư";
            this.Load += new System.EventHandler(this.frmGachHoa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGH)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnTen;
        private System.Windows.Forms.RadioButton rbnMa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvGH;
        private System.Windows.Forms.Button btnHuyG;
        private System.Windows.Forms.Button btnLuuG;
        private System.Windows.Forms.Button btnXoaG;
        private System.Windows.Forms.Button btnSuaG;
        private System.Windows.Forms.Button btnThemG;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.TextBox txtDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSearch;
    }
}