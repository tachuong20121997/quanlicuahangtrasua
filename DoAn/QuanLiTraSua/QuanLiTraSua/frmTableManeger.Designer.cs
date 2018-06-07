namespace QuanLiTraSua
{
    partial class frmTableManeger
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
            this.nmfoodcount = new System.Windows.Forms.NumericUpDown();
            this.flptable = new System.Windows.Forms.FlowLayoutPanel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbThucAn = new MetroFramework.Controls.MetroComboBox();
            this.cbLoaiThucAn = new MetroFramework.Controls.MetroComboBox();
            this.btnaddfood = new MetroFramework.Controls.MetroButton();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giúpĐỡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dữToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoLưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbswitch = new MetroFramework.Controls.MetroComboBox();
            this.btnswitchtable = new MetroFramework.Controls.MetroButton();
            this.nmGiamGia = new System.Windows.Forms.NumericUpDown();
            this.btncheckout = new MetroFramework.Controls.MetroButton();
            this.txtTongTien = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBanHienHanh = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.phụcHồiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nmfoodcount)).BeginInit();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiamGia)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // nmfoodcount
            // 
            this.nmfoodcount.Location = new System.Drawing.Point(130, 50);
            this.nmfoodcount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmfoodcount.Name = "nmfoodcount";
            this.nmfoodcount.Size = new System.Drawing.Size(85, 29);
            this.nmfoodcount.TabIndex = 4;
            this.nmfoodcount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flptable
            // 
            this.flptable.AutoScroll = true;
            this.flptable.Location = new System.Drawing.Point(6, 19);
            this.flptable.Name = "flptable";
            this.flptable.Size = new System.Drawing.Size(335, 448);
            this.flptable.TabIndex = 10;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.lsvBill.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBill.FullRowSelect = true;
            this.lsvBill.GridLines = true;
            this.lsvBill.Location = new System.Drawing.Point(6, 19);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(291, 448);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên món ăn";
            this.columnHeader3.Width = 94;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số lượng";
            this.columnHeader1.Width = 65;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Đơn giá";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 65;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(172, 25);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbThucAn);
            this.panel4.Controls.Add(this.cbLoaiThucAn);
            this.panel4.Controls.Add(this.btnaddfood);
            this.panel4.Controls.Add(this.nmfoodcount);
            this.panel4.Location = new System.Drawing.Point(6, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(235, 83);
            this.panel4.TabIndex = 9;
            // 
            // cbThucAn
            // 
            this.cbThucAn.FormattingEnabled = true;
            this.cbThucAn.ItemHeight = 23;
            this.cbThucAn.Location = new System.Drawing.Point(3, 41);
            this.cbThucAn.Name = "cbThucAn";
            this.cbThucAn.Size = new System.Drawing.Size(121, 29);
            this.cbThucAn.TabIndex = 1;
            // 
            // cbLoaiThucAn
            // 
            this.cbLoaiThucAn.FormattingEnabled = true;
            this.cbLoaiThucAn.ItemHeight = 23;
            this.cbLoaiThucAn.Location = new System.Drawing.Point(3, 9);
            this.cbLoaiThucAn.Name = "cbLoaiThucAn";
            this.cbLoaiThucAn.Size = new System.Drawing.Size(121, 29);
            this.cbLoaiThucAn.TabIndex = 1;
            this.cbLoaiThucAn.SelectedIndexChanged += new System.EventHandler(this.cbLoaiThucAn_SelectedIndexChanged);
            // 
            // btnaddfood
            // 
            this.btnaddfood.Location = new System.Drawing.Point(130, 3);
            this.btnaddfood.Name = "btnaddfood";
            this.btnaddfood.Size = new System.Drawing.Size(85, 40);
            this.btnaddfood.TabIndex = 5;
            this.btnaddfood.Text = "Thêm món";
            this.btnaddfood.Click += new System.EventHandler(this.btnaddfood_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(73, 25);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.chứcToolStripMenuItem,
            this.giúpĐỡToolStripMenuItem,
            this.dữToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 29);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcToolStripMenuItem
            // 
            this.chứcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMónToolStripMenuItem,
            this.thanhToánToolStripMenuItem,
            this.chuyểnBànToolStripMenuItem});
            this.chứcToolStripMenuItem.Name = "chứcToolStripMenuItem";
            this.chứcToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.chứcToolStripMenuItem.Text = " Chức năng";
            // 
            // thêmMónToolStripMenuItem
            // 
            this.thêmMónToolStripMenuItem.Name = "thêmMónToolStripMenuItem";
            this.thêmMónToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.thêmMónToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.thêmMónToolStripMenuItem.Text = "Thêm món";
            this.thêmMónToolStripMenuItem.Click += new System.EventHandler(this.thêmMónToolStripMenuItem_Click);
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.thanhToánToolStripMenuItem.Text = "Thanh toán";
            this.thanhToánToolStripMenuItem.Click += new System.EventHandler(this.thanhToánToolStripMenuItem_Click);
            // 
            // chuyểnBànToolStripMenuItem
            // 
            this.chuyểnBànToolStripMenuItem.Name = "chuyểnBànToolStripMenuItem";
            this.chuyểnBànToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.chuyểnBànToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.chuyểnBànToolStripMenuItem.Text = "Chuyển bàn";
            this.chuyểnBànToolStripMenuItem.Click += new System.EventHandler(this.chuyểnBànToolStripMenuItem_Click);
            // 
            // giúpĐỡToolStripMenuItem
            // 
            this.giúpĐỡToolStripMenuItem.Name = "giúpĐỡToolStripMenuItem";
            this.giúpĐỡToolStripMenuItem.Size = new System.Drawing.Size(82, 25);
            this.giúpĐỡToolStripMenuItem.Text = "Giúp đỡ";
            this.giúpĐỡToolStripMenuItem.Click += new System.EventHandler(this.giúpĐỡToolStripMenuItem_Click);
            // 
            // dữToolStripMenuItem
            // 
            this.dữToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saoLưuToolStripMenuItem,
            this.phụcHồiToolStripMenuItem});
            this.dữToolStripMenuItem.Name = "dữToolStripMenuItem";
            this.dữToolStripMenuItem.Size = new System.Drawing.Size(82, 25);
            this.dữToolStripMenuItem.Text = " Dữ liệu";
            // 
            // saoLưuToolStripMenuItem
            // 
            this.saoLưuToolStripMenuItem.Name = "saoLưuToolStripMenuItem";
            this.saoLưuToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.saoLưuToolStripMenuItem.Text = "Sao lưu";
            this.saoLưuToolStripMenuItem.Click += new System.EventHandler(this.saoLưuToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbswitch);
            this.panel3.Controls.Add(this.btnswitchtable);
            this.panel3.Location = new System.Drawing.Point(7, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 53);
            this.panel3.TabIndex = 8;
            // 
            // cbswitch
            // 
            this.cbswitch.FormattingEnabled = true;
            this.cbswitch.ItemHeight = 23;
            this.cbswitch.Location = new System.Drawing.Point(3, 8);
            this.cbswitch.Name = "cbswitch";
            this.cbswitch.Size = new System.Drawing.Size(121, 29);
            this.cbswitch.TabIndex = 1;
            // 
            // btnswitchtable
            // 
            this.btnswitchtable.Location = new System.Drawing.Point(133, 3);
            this.btnswitchtable.Name = "btnswitchtable";
            this.btnswitchtable.Size = new System.Drawing.Size(75, 40);
            this.btnswitchtable.TabIndex = 5;
            this.btnswitchtable.Text = "Chuyển bàn";
            this.btnswitchtable.Click += new System.EventHandler(this.btnswitchtable_Click);
            // 
            // nmGiamGia
            // 
            this.nmGiamGia.Location = new System.Drawing.Point(10, 54);
            this.nmGiamGia.Name = "nmGiamGia";
            this.nmGiamGia.Size = new System.Drawing.Size(75, 29);
            this.nmGiamGia.TabIndex = 7;
            // 
            // btncheckout
            // 
            this.btncheckout.Location = new System.Drawing.Point(97, 19);
            this.btncheckout.Name = "btncheckout";
            this.btncheckout.Size = new System.Drawing.Size(118, 52);
            this.btncheckout.TabIndex = 5;
            this.btncheckout.Text = "Thanh toán";
            this.btncheckout.Click += new System.EventHandler(this.btncheckout_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.SystemColors.ControlText;
            this.txtTongTien.Enabled = false;
            this.txtTongTien.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtTongTien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTongTien.Location = new System.Drawing.Point(10, 88);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(205, 25);
            this.txtTongTien.TabIndex = 7;
            this.txtTongTien.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvBill);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(365, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 475);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBanHienHanh);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(690, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 108);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bàn hiện hành";
            // 
            // lblBanHienHanh
            // 
            this.lblBanHienHanh.AutoSize = true;
            this.lblBanHienHanh.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanHienHanh.Location = new System.Drawing.Point(97, 42);
            this.lblBanHienHanh.Name = "lblBanHienHanh";
            this.lblBanHienHanh.Size = new System.Drawing.Size(0, 32);
            this.lblBanHienHanh.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(690, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 108);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thêm món ăn";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel3);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(696, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(271, 93);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nghiệp vụ";
            // 
            // metroButton1
            // 
            this.metroButton1.Enabled = false;
            this.metroButton1.Location = new System.Drawing.Point(10, 19);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 29);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Giảm giá(%)";
            this.metroButton1.Click += new System.EventHandler(this.btnswitchtable_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nmGiamGia);
            this.groupBox5.Controls.Add(this.txtTongTien);
            this.groupBox5.Controls.Add(this.btncheckout);
            this.groupBox5.Controls.Add(this.metroButton1);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(696, 383);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(271, 119);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tổng tiền";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.flptable);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(12, 35);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(347, 475);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bàn ăn";
            // 
            // phụcHồiToolStripMenuItem
            // 
            this.phụcHồiToolStripMenuItem.Name = "phụcHồiToolStripMenuItem";
            this.phụcHồiToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.phụcHồiToolStripMenuItem.Text = "Phục hồi";
            this.phụcHồiToolStripMenuItem.Click += new System.EventHandler(this.phụcHồiToolStripMenuItem_Click);
            // 
            // frmTableManeger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 514);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmTableManeger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form quản lí";
            ((System.ComponentModel.ISupportInitialize)(this.nmfoodcount)).EndInit();
            this.panel4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmGiamGia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmfoodcount;
        private System.Windows.Forms.FlowLayoutPanel flptable;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroComboBox cbThucAn;
        private MetroFramework.Controls.MetroComboBox cbLoaiThucAn;
        private MetroFramework.Controls.MetroButton btnaddfood;
        private MetroFramework.Controls.MetroButton btnswitchtable;
        private MetroFramework.Controls.MetroComboBox cbswitch;
        private MetroFramework.Controls.MetroButton btncheckout;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private MetroFramework.Controls.MetroTextBox txtTongTien;
        private System.Windows.Forms.NumericUpDown nmGiamGia;
        private System.Windows.Forms.ToolStripMenuItem chứcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ToolStripMenuItem chuyểnBànToolStripMenuItem;
        private System.Windows.Forms.Label lblBanHienHanh;
        private System.Windows.Forms.ToolStripMenuItem giúpĐỡToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dữToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoLưuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phụcHồiToolStripMenuItem;
    }
}