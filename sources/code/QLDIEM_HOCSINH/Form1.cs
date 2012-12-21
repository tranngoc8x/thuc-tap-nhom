using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLDIEM_HOCSINH
{
    public partial class frmMain : Form
    {
        private truyCap tc = new truyCap();
        private string ktdn="";
        private string pw = ""; 
        public frmMain()
        {
            InitializeComponent();

           // this.timer1_Tick += new System.EventHandler(this.timer1_Tick) ;
              //  tlblTime.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void themMoiHocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHocsinh hs = new frmHocsinh();
            hs.ShowDialog();
        }

        private void nhapDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiem diem =new frmDiem();
            diem.ShowDialog();
        }

        private void ketQuaHocTapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewDTK dtk =new frmViewDTK();
            dtk.ShowDialog();
        }

        private void themMoiLopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemLop lop = new frmThemLop();
            lop.ShowDialog();
        }

        private void themMoiNamHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNamhoc nh = new frmNamhoc();
            nh.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            quanLyDiemToolStripMenuItem.Enabled = false;
            quanLyHocSinhToolStripMenuItem.Enabled = false;
            thongTinPhanMenToolStripMenuItem.Enabled = false;
            tsmDoiPassWord.Enabled = false;
            tsmThemNguoiDung.Enabled = false;
            thongTinPhanMenToolStripMenuItem.Enabled = false;
            
            

        }

        private void tsmDangNhap_Click(object sender, EventArgs e)
        {
            frmLogin ln = new frmLogin();
            ln.ShowDialog();
            ktdn = ln.Quyen;
            pw = ln.Pass;
            //label1.Text = pw;
            kiemTraDangNhap(ktdn);
           
            
        }
        private void kiemTraDangNhap(string dn)
        {
            if (dn == "admin")
            {
               // MessageBox.Show("Ban dang nhap thanh cong Voi Quyen admin", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quanLyDiemToolStripMenuItem.Enabled = true;
                quanLyHocSinhToolStripMenuItem.Enabled = true;
                thongTinPhanMenToolStripMenuItem.Enabled = true;
                tsmDangNhap.Enabled = false;
                tsmDoiPassWord.Enabled = true;
                tsmThemNguoiDung.Enabled = true;
                tlblUser.Text = "User:Admin";
            }
            if (dn == "giaovien")
            {
                quanLyDiemToolStripMenuItem.Enabled = true;
                thongTinPhanMenToolStripMenuItem.Enabled = true;
                tsmDangNhap.Enabled = false;
                tsmDoiPassWord.Enabled = true;
                tlblUser.Text = "User:Giao Vien";

            }
            if (dn == "hocsinh")
            {
                quanLyDiemToolStripMenuItem.Enabled = true;
                nhapDiemToolStripMenuItem.Enabled = false;
                thongTinPhanMenToolStripMenuItem.Enabled = true;
                tsmDangNhap.Enabled = false;
                tsmDoiPassWord.Enabled = true;
                tlblUser.Text = "User:Hoc Sinh";
                //ketQuaHocTapToolStripMenuItem.Enabled = true;
            }
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban Co Muon Thoat Khoi Chuong Tring ? ", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            Application.Exit();
        }

        private void thongTinPhanMenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem ttpm = new frmThongTinPhanMem();
            ttpm.ShowDialog();
        }

        private void tsmDoiPassWord_Click(object sender, EventArgs e)
        {
            frmChangePass change = new frmChangePass();
            change.ShowDialog();
            //change.Pass = pw;
            //label1.Text = change.Pass;
        }

        private void tsmThemNguoiDung_Click(object sender, EventArgs e)
        {
            frmThemNguoiDung frmND = new frmThemNguoiDung();
            frmND.ShowDialog();
        }

        private void menuTimDiem_Click(object sender, EventArgs e)
        {
            frmTimKiem tkd = new frmTimKiem();
            tkd.ShowDialog();
        }

        private void bAOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport rp = new frmReport();
            rp.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tlblTime.Text = DateTime.Now.ToLongTimeString();
        }

       
    }
}
