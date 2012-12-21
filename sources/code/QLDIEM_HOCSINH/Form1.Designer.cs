namespace QLDIEM_HOCSINH
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quanLyNguoiDungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmThemNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDoiPassWord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyHocSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themMoiHocSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themMoiNamHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themMoiLopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyDiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhapDiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ketQuaHocTapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTimDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.bAOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinPhanMenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyNguoiDungToolStripMenuItem,
            this.quanLyHocSinhToolStripMenuItem,
            this.quanLyDiemToolStripMenuItem,
            this.thongTinPhanMenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(706, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quanLyNguoiDungToolStripMenuItem
            // 
            this.quanLyNguoiDungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmThemNguoiDung,
            this.tsmDoiPassWord,
            this.tsmDangNhap,
            this.tsmThoat});
            this.quanLyNguoiDungToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quanLyNguoiDungToolStripMenuItem.Image")));
            this.quanLyNguoiDungToolStripMenuItem.Name = "quanLyNguoiDungToolStripMenuItem";
            this.quanLyNguoiDungToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.quanLyNguoiDungToolStripMenuItem.Text = "NGƯỜI DÙNG";
            // 
            // tsmThemNguoiDung
            // 
            this.tsmThemNguoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsmThemNguoiDung.Image = ((System.Drawing.Image)(resources.GetObject("tsmThemNguoiDung.Image")));
            this.tsmThemNguoiDung.Name = "tsmThemNguoiDung";
            this.tsmThemNguoiDung.Size = new System.Drawing.Size(152, 22);
            this.tsmThemNguoiDung.Text = "THÊM MỚI";
            this.tsmThemNguoiDung.Click += new System.EventHandler(this.tsmThemNguoiDung_Click);
            // 
            // tsmDoiPassWord
            // 
            this.tsmDoiPassWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsmDoiPassWord.Image = ((System.Drawing.Image)(resources.GetObject("tsmDoiPassWord.Image")));
            this.tsmDoiPassWord.Name = "tsmDoiPassWord";
            this.tsmDoiPassWord.Size = new System.Drawing.Size(152, 22);
            this.tsmDoiPassWord.Text = "ĐỔI PASS";
            this.tsmDoiPassWord.Click += new System.EventHandler(this.tsmDoiPassWord_Click);
            // 
            // tsmDangNhap
            // 
            this.tsmDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsmDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("tsmDangNhap.Image")));
            this.tsmDangNhap.Name = "tsmDangNhap";
            this.tsmDangNhap.Size = new System.Drawing.Size(152, 22);
            this.tsmDangNhap.Text = "ĐĂNG NHẬP";
            this.tsmDangNhap.Click += new System.EventHandler(this.tsmDangNhap_Click);
            // 
            // tsmThoat
            // 
            this.tsmThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsmThoat.Image = ((System.Drawing.Image)(resources.GetObject("tsmThoat.Image")));
            this.tsmThoat.Name = "tsmThoat";
            this.tsmThoat.Size = new System.Drawing.Size(152, 22);
            this.tsmThoat.Text = "THOÁT";
            this.tsmThoat.Click += new System.EventHandler(this.tsmThoat_Click);
            // 
            // quanLyHocSinhToolStripMenuItem
            // 
            this.quanLyHocSinhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themMoiHocSinhToolStripMenuItem,
            this.themMoiNamHocToolStripMenuItem,
            this.themMoiLopToolStripMenuItem});
            this.quanLyHocSinhToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quanLyHocSinhToolStripMenuItem.Image")));
            this.quanLyHocSinhToolStripMenuItem.Name = "quanLyHocSinhToolStripMenuItem";
            this.quanLyHocSinhToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.quanLyHocSinhToolStripMenuItem.Text = "QUẢN LÝ HỌC SINH";
            // 
            // themMoiHocSinhToolStripMenuItem
            // 
            this.themMoiHocSinhToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.themMoiHocSinhToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("themMoiHocSinhToolStripMenuItem.Image")));
            this.themMoiHocSinhToolStripMenuItem.Name = "themMoiHocSinhToolStripMenuItem";
            this.themMoiHocSinhToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.themMoiHocSinhToolStripMenuItem.Text = "THÊM MỚI";
            this.themMoiHocSinhToolStripMenuItem.Click += new System.EventHandler(this.themMoiHocSinhToolStripMenuItem_Click);
            // 
            // themMoiNamHocToolStripMenuItem
            // 
            this.themMoiNamHocToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.themMoiNamHocToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("themMoiNamHocToolStripMenuItem.Image")));
            this.themMoiNamHocToolStripMenuItem.Name = "themMoiNamHocToolStripMenuItem";
            this.themMoiNamHocToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.themMoiNamHocToolStripMenuItem.Text = "THÊM NĂM HỌC";
            this.themMoiNamHocToolStripMenuItem.Click += new System.EventHandler(this.themMoiNamHocToolStripMenuItem_Click);
            // 
            // themMoiLopToolStripMenuItem
            // 
            this.themMoiLopToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.themMoiLopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("themMoiLopToolStripMenuItem.Image")));
            this.themMoiLopToolStripMenuItem.Name = "themMoiLopToolStripMenuItem";
            this.themMoiLopToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.themMoiLopToolStripMenuItem.Text = "THÊM LỚP";
            this.themMoiLopToolStripMenuItem.Click += new System.EventHandler(this.themMoiLopToolStripMenuItem_Click);
            // 
            // quanLyDiemToolStripMenuItem
            // 
            this.quanLyDiemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhapDiemToolStripMenuItem,
            this.ketQuaHocTapToolStripMenuItem,
            this.menuTimDiem,
            this.bAOToolStripMenuItem});
            this.quanLyDiemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quanLyDiemToolStripMenuItem.Image")));
            this.quanLyDiemToolStripMenuItem.Name = "quanLyDiemToolStripMenuItem";
            this.quanLyDiemToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.quanLyDiemToolStripMenuItem.Text = "QUẢN LÝ ĐIỂM";
            // 
            // nhapDiemToolStripMenuItem
            // 
            this.nhapDiemToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nhapDiemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nhapDiemToolStripMenuItem.Image")));
            this.nhapDiemToolStripMenuItem.Name = "nhapDiemToolStripMenuItem";
            this.nhapDiemToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.nhapDiemToolStripMenuItem.Text = "NHẬP DIỂM";
            this.nhapDiemToolStripMenuItem.Click += new System.EventHandler(this.nhapDiemToolStripMenuItem_Click);
            // 
            // ketQuaHocTapToolStripMenuItem
            // 
            this.ketQuaHocTapToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ketQuaHocTapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ketQuaHocTapToolStripMenuItem.Image")));
            this.ketQuaHocTapToolStripMenuItem.Name = "ketQuaHocTapToolStripMenuItem";
            this.ketQuaHocTapToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ketQuaHocTapToolStripMenuItem.Text = "KẾT QUẢ HỌC TẬP";
            this.ketQuaHocTapToolStripMenuItem.Click += new System.EventHandler(this.ketQuaHocTapToolStripMenuItem_Click);
            // 
            // menuTimDiem
            // 
            this.menuTimDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuTimDiem.Image = ((System.Drawing.Image)(resources.GetObject("menuTimDiem.Image")));
            this.menuTimDiem.Name = "menuTimDiem";
            this.menuTimDiem.Size = new System.Drawing.Size(175, 22);
            this.menuTimDiem.Text = "TÌM KIẾM ĐIỂM";
            this.menuTimDiem.Click += new System.EventHandler(this.menuTimDiem_Click);
            // 
            // bAOToolStripMenuItem
            // 
            this.bAOToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bAOToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bAOToolStripMenuItem.Image")));
            this.bAOToolStripMenuItem.Name = "bAOToolStripMenuItem";
            this.bAOToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.bAOToolStripMenuItem.Text = "BÁO CÁO";
            this.bAOToolStripMenuItem.Click += new System.EventHandler(this.bAOToolStripMenuItem_Click);
            // 
            // thongTinPhanMenToolStripMenuItem
            // 
            this.thongTinPhanMenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thongTinPhanMenToolStripMenuItem.Image")));
            this.thongTinPhanMenToolStripMenuItem.Name = "thongTinPhanMenToolStripMenuItem";
            this.thongTinPhanMenToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.thongTinPhanMenToolStripMenuItem.Text = "THÔNG TIN PHẦN MỀM";
            this.thongTinPhanMenToolStripMenuItem.Click += new System.EventHandler(this.thongTinPhanMenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblUser,
            this.tlblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(706, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblUser
            // 
            this.tlblUser.Name = "tlblUser";
            this.tlblUser.Size = new System.Drawing.Size(36, 17);
            this.tlblUser.Text = "User :";
            // 
            // tlblTime
            // 
            this.tlblTime.Name = "tlblTime";
            this.tlblTime.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(706, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Quan Ly Diem";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanLyNguoiDungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyHocSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyDiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmThemNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem tsmDoiPassWord;
        private System.Windows.Forms.ToolStripMenuItem thongTinPhanMenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themMoiHocSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themMoiNamHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhapDiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ketQuaHocTapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themMoiLopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDangNhap;
        private System.Windows.Forms.ToolStripMenuItem tsmThoat;
        private System.Windows.Forms.ToolStripMenuItem menuTimDiem;
        private System.Windows.Forms.ToolStripMenuItem bAOToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblUser;
        private System.Windows.Forms.ToolStripStatusLabel tlblTime;
        private System.Windows.Forms.Timer timer1;
    }
}

