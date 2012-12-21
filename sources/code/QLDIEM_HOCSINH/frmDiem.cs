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
    public partial class frmDiem : Form
    {
        private SqlConnection con;
        private DataTable dtHS = new DataTable("HOCSINH");
        private DataTable dtLOP = new DataTable("LOP");
        private DataTable dtHK = new DataTable("HOCKY");
        private DataTable dtMH = new DataTable("MONHOC");
        private DataTable dtNH = new DataTable("NAMHOC");
        private DataTable dtD = new DataTable("DIEM");
        private SqlDataAdapter da = new SqlDataAdapter();
        private SqlDataAdapter da1 = new SqlDataAdapter();
        private void connect()
        {
            string cn = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLHOCSINH;Integrated Security=True";
            try
            {
                con =new SqlConnection(cn);
                con.Open();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Khong the ket noi CSDL","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void Disconect()
        {
            con.Close();
            con.Dispose();
            con = null;
        }
        public frmDiem()
        {
            InitializeComponent();
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            connect();
            getDaTa();
            binding();
            //Disconect();
        }
        private void getDaTa()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MÃ HS' ,S.TENHS as N'HỌ TÊN', D.MALOP as N'LỚP' ,MAMON as N'MÔN HỌC',MANAMHOC as N'NĂM HỌC',
                                         MAHK as N'HỌC KỲ' , DIEM15 as N'ĐIỂM 15' , DIEM45 as N'ĐIỂM 45', DIEMKT as N'ĐIỂM KT',
                                         DIEMTHI as N'ĐIỂM THI',DIEMHK as N'ĐIỂM HK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS";
            da.SelectCommand = command;
            da.Fill(dtD);
            dgvViewDiem.DataSource = dtD;

                
            
            command.CommandText = @"select * From LOP";
            da.Fill(dtLOP);
            cbxMalop.DataSource = dtLOP;
            cbxMalop.DisplayMember = "TENLOP";
            cbxMalop.ValueMember = "MALOP";
            cbxMalop.SelectedValue = "MALOP";

            command.CommandText = @"select * From HOCSINH";
            da.Fill(dtHS);
            cbxMahs.DataSource = dtHS;
            cbxMahs.DisplayMember = "TENHS";
            cbxMahs.ValueMember = "MAHS";
            cbxMahs.SelectedValue = "MAHS";

            command.CommandText = @"select * From MONHOC";
            da.Fill(dtMH);
            cbxMamon.DataSource = dtMH;
            cbxMamon.DisplayMember = "TENMONHOC";
            cbxMamon.ValueMember = "MAMON";
            cbxMamon.SelectedValue = "MAMON";

            command.CommandText = @"select * From HOCKY";
            da.Fill(dtHK);
            cbxMaHocKy.DataSource = dtHK;
            cbxMaHocKy.DisplayMember = "MAHK";
            cbxMaHocKy.ValueMember = "TENHK";
            cbxMaHocKy.SelectedValue = "TENHK";

            command.CommandText = @"select * From NAMHOC";
            da.Fill(dtNH);
            cbxMaNamHoc.DataSource = dtNH;
            cbxMaNamHoc.DisplayMember = "MANAMHOC";
            cbxMaNamHoc.ValueMember = "NAMHOC";
            cbxMaNamHoc.SelectedValue = "NAMHOC";
                                  
        }
        private void binding()
        {
            tbxSTT.DataBindings.Clear();
            tbxSTT.DataBindings.Add("Text", dgvViewDiem.DataSource, "STT");
            cbxMahs.DataBindings.Clear();
            cbxMahs.DataBindings.Add("Text", dgvViewDiem.DataSource, "MÃ HS");
            cbxMalop.DataBindings.Clear();
            cbxMalop.DataBindings.Add("Text", dgvViewDiem.DataSource, "LỚP");
            cbxMamon.DataBindings.Clear();
            cbxMamon.DataBindings.Add("Text", dgvViewDiem.DataSource, "MÔN HỌC");
            cbxMaHocKy.DataBindings.Clear();
            cbxMaHocKy.DataBindings.Add("Text", dgvViewDiem.DataSource, "HỌC KỲ");
            cbxMaNamHoc.DataBindings.Clear();
            cbxMaNamHoc.DataBindings.Add("Text", dgvViewDiem.DataSource, "NĂM HỌC");
            tbxDiem15.DataBindings.Clear();
            tbxDiem15.DataBindings.Add("Text", dgvViewDiem.DataSource, "ĐIỂM 15");
            tbxDiem45.DataBindings.Clear();
            tbxDiem45.DataBindings.Add("Text", dgvViewDiem.DataSource, "ĐIỂM 45");
            tbxDiemKT.DataBindings.Clear();
            tbxDiemKT.DataBindings.Add("Text", dgvViewDiem.DataSource, "ĐIỂM KT");
            tbxDiemThi.DataBindings.Clear();
            tbxDiemThi.DataBindings.Add("Text", dgvViewDiem.DataSource, "ĐIỂM THI");
            tbxDiemHK.DataBindings.Clear();
            tbxDiemHK.DataBindings.Add("Text", dgvViewDiem.DataSource, "ĐIỂM HK");

        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Ban co muon xoa ban gi nay khong ?","Thong Bao",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
           {
            DataRow row = dtD.Select("STT=" + Convert.ToInt32(tbxSTT.Text))[0];
            row.BeginEdit();
            row.Delete();
            row.EndEdit();
            SqlCommand Deletecommand = new SqlCommand();
            Deletecommand.Connection = con;
            Deletecommand.CommandType = CommandType.Text;
            Deletecommand.CommandText = @"DELETE from DIEM where MAHS=@MAHS and MAMON=@MAMON and MANAMHOC=@MANAMHOC and MAHK=@MAHK";
            Deletecommand.Parameters.Add("@MAHS", SqlDbType.VarChar, 10, "MAHS");
            Deletecommand.Parameters.Add("@MAMON", SqlDbType.VarChar, 10, "MAMON");
            Deletecommand.Parameters.Add("@MANAMHOC", SqlDbType.Int, 500, "MANAMHOC");
            Deletecommand.Parameters.Add("@MAHK", SqlDbType.VarChar, 10, "MAHK");
            da.DeleteCommand = Deletecommand;
            da.Update(dtD);
           }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KT(true);

        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            double D15, D45, Dkt, Dthi, Dhk ;
            double Kt=0;
            //int D;
            D15 = kiemTra(tbxDiem15.Text);
            D45 = kiemTra(tbxDiem45.Text);
            Dkt = kiemTra(tbxDiemKT.Text);
            Dthi = kiemTra(tbxDiemThi.Text);
            //D = Double.Parse(tbxDiem15.Text);
            if (D15 == 11)
            {
                tbxDiem15.Text = "";
                Kt = 1;
            }
            if (D45 == 11)
            {
                tbxDiem45.Text = "";
                Kt = 1;
            }
            if (Dkt == 11)
            {
                tbxDiemKT.Text = "";
                Kt = 1;
            }
            if (Dthi == 11)
            {
                tbxDiemThi.Text = "";
                Kt = 1;
            }
            

            if(Kt==0)
            {
                Dhk = (((D15 + 2 * D45) / 3 + 2 * Dkt) / 3 + 2 * Dthi) / 3;
                tbxDiemHK.Text = Dhk.ToString();

                DataRow row = dtD.Select("STT=" + Convert.ToInt32(tbxSTT.Text))[0];
                row.BeginEdit();
                row["MÃ HS"] = cbxMahs.Text;
                row["LỚP"] = cbxMalop.Text;
                row["MÔN HỌC"] = cbxMamon.Text;
                row["NĂM HỌC"] = cbxMaNamHoc.Text;
                row["HỌC KỲ"] = cbxMaHocKy.Text;
                row["ĐIỂM 15"] = tbxDiem15.Text;
                row["ĐIỂM 45"] = tbxDiem45.Text;
                row["ĐIỂM KT"] = tbxDiemKT.Text;
                row["ĐIỂM THI"] = tbxDiemThi.Text;
                row["ĐIỂM HK"] = tbxDiemHK.Text;
                row.EndEdit();
                SqlCommand commandUpdate = new SqlCommand();
                commandUpdate.Connection = con;
                commandUpdate.CommandType = CommandType.Text;
                commandUpdate.CommandText = @" Update DIEM SET  MAHS=@MAHS , MALOP=@MALOP ,MAMON=@MAMON,MANAMHOC=@MANAMHOC,MAHK=@MAHK ,
                                                         DIEM15=@DIEM15, DIEM45=@DIEM45, DIEMKT=@DIEMKT, DIEMTHI=@DIEMTHI ,DIEMHK=@DIEMHK
                                                         Where STT=@STT and MAHS=@MAHS";
                commandUpdate.Parameters.Add("@STT", SqlDbType.Int, 50, "STT");
                commandUpdate.Parameters.Add("@MAHS", SqlDbType.VarChar, 10, "MÃ HS");
                commandUpdate.Parameters.Add("@MALOP", SqlDbType.VarChar, 10, "LỚP");
                commandUpdate.Parameters.Add("@MAMON", SqlDbType.VarChar, 10, "MÔN HỌC");
                commandUpdate.Parameters.Add("@MANAMHOC", SqlDbType.Int, 50, "NĂM HỌC");
                commandUpdate.Parameters.Add("@MAHK", SqlDbType.VarChar, 10, "HỌC KỲ");
                commandUpdate.Parameters.Add("@DIEM15", SqlDbType.NVarChar, 50, "ĐIỂM 15");
                commandUpdate.Parameters.Add("@DIEM45", SqlDbType.NVarChar, 50, "ĐIỂM 45");
                commandUpdate.Parameters.Add("@DIEMKT", SqlDbType.NVarChar, 50, "ĐIỂM KT");
                commandUpdate.Parameters.Add("@DIEMTHI", SqlDbType.NVarChar, 50, "ĐIỂM THI");
                commandUpdate.Parameters.Add("@DIEMHK", SqlDbType.NVarChar, 50, "ĐIỂM HK");
                da.UpdateCommand = commandUpdate;
                da.Update(dtD);
                MessageBox.Show("Ban sua thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KT(false);
            }
            else
            {
               
                return;

            }
            
            //da.Fill(dtD);
            //dgvViewDiem.DataSource = dtD;
            
        }
        private double kiemTra(string st)
        {
            try
            {
                double D = Convert.ToDouble(st);
                if (D < 0 || D > 10)
                {
                    MessageBox.Show("Ban Nhap sai Diem", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 11;
                }
                else
                {
                    return D;
                }
            }
            catch (FormatException EX)
            {
                MessageBox.Show("Ban Phai Nhap So", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 11;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmThemDiem ThemDiem = new frmThemDiem();
            ThemDiem.ShowDialog();
        }
        private void KT(bool kt)
        {
           // cbxMahs.Enabled = kt;
            cbxMalop.Enabled = kt;
            cbxMamon.Enabled = kt;
            cbxMaHocKy.Enabled = kt;
            cbxMaNamHoc.Enabled = kt;
            tbxDiem15.ReadOnly = !kt;
            tbxDiem45.ReadOnly = !kt;
            tbxDiemKT.ReadOnly = !kt;
            tbxDiemThi.ReadOnly = !kt;
            btnSua.Enabled = !kt;
            btnLUU.Enabled = kt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
