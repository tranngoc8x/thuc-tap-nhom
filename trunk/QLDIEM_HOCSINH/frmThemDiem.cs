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
    public partial class frmThemDiem : Form
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
        private DataSet ds;
        private void connect()
        {
            string cn = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLHOCSINH;Integrated Security=True";
            try
            {
                con = new SqlConnection(cn);
                con.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the ket noi CSDL", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Disconect()
        {
            con.Close();
            con.Dispose();
            con = null;
        }
        private void getDaTa()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select * From DIEM";
            da.SelectCommand = command;
            da.Fill(dtD);
           // dgvViewDiem.DataSource = dtD;



            command.CommandText = @"select * From LOP";
            da.Fill(dtLOP);
            cbxMALOP.DataSource = dtLOP;
            cbxMALOP.DisplayMember = "TENLOP";
            cbxMALOP.ValueMember = "MALOP";
            cbxMALOP.SelectedValue = "MALOP";
            cbxLop.DataSource = dtLOP;
            cbxLop.DisplayMember = "MALOP";
            cbxLop.ValueMember = "MALOP";
            cbxLop.SelectedValue = "MALOP";

            ////command.CommandText = @"select * From HOCSINH ";

            ////da.Fill(dtHS);
            ////cbxMAHS.DataSource = dtHS;
            ////cbxMAHS.DisplayMember = "TENHS";
            ////cbxMAHS.ValueMember = "MAHS";
            ////cbxMAHS.SelectedValue = "MAHS";

            command.CommandText = @"select * From MONHOC";
            da.Fill(dtMH);
            cbxMAMON.DataSource = dtMH;
            cbxMAMON.DisplayMember = "TENMONHOC";
            cbxMAMON.ValueMember = "MAMON";
            cbxMAMON.SelectedValue = "MAMON";

            command.CommandText = @"select * From HOCKY";
            da.Fill(dtHK);
            cbxMAHK.DataSource = dtHK;
            cbxMAHK.DisplayMember = "MAHK";
            cbxMAHK.ValueMember = "TENHK";
            cbxMAHK.SelectedValue = "TENHK";

            command.CommandText = @"select * From NAMHOC";
            da.Fill(dtNH);
            cbxMANAMHOC.DataSource = dtNH;
            cbxMANAMHOC.DisplayMember = "MANAMHOC";
            cbxMANAMHOC.ValueMember = "NAMHOC";
            cbxMANAMHOC.SelectedValue = "NAMHOC";

        }
        public frmThemDiem()
        {
            InitializeComponent();
            connect();
            getDaTa();
            cbxLop.Text = "10A1";
            timKiemHocSinh();
        }

       


        private double kiemTra(string st)//kiem tra diem
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
            double D15, D45, Dkt, Dthi, Dhk;
            double KT = 0;
            bool ktM, ktML, ktMM, ktMNH, ktMHK ,dk;
            //label11.Text = KiemTra().ToString();
            ktM = ktMM = ktML = ktMNH = ktMHK = dk = true;
            foreach (DataRow dtr in kttk().Tables[0].Rows)//kiem tra ton tai
            {
                if (dtr["MAHS"].ToString() == cbxMAHS.Text.ToString())
                    ktM = false;
                if (dtr["MALOP"].ToString() == cbxMALOP.Text.ToString())
                    ktML = false;
                if (dtr["MAMON"].ToString() == cbxMAMON.SelectedValue.ToString())
                    ktMM = false;
                if (dtr["MANAMHOC"].ToString() == cbxMANAMHOC.Text)
                    ktMNH = false;
                if (dtr["MAHK"].ToString() == cbxMAHK.Text)
                    ktMHK = false;

            }
            if (ktM == false&&ktMHK == false&&ktML == false&&ktMM == false&&ktMNH ==false)
            {
                dk = false;
            }
            else
            {
                dk = true;
            }
            //label11.Text = dk.ToString();
            D15 = kiemTra(tbxDIEM15.Text);
            D45 = kiemTra(tbxDIEM45.Text);
            Dkt = kiemTra(tbxDIEMKT.Text);
            Dthi = kiemTra(tbxDIEMTHI.Text);
            
            if (D15 == 11)
            {
                tbxDIEM15.Text = "";
                KT = 1;
            }
            if (D45 == 11)
            {
                tbxDIEM45.Text = "";
                KT = 1;
            }
            if (Dkt == 11)
            {
                tbxDIEMKT.Text = "";
                KT = 1;
            }
            if (Dthi == 11)
            {
                tbxDIEMTHI.Text = "";
                KT = 1;
            }
            if (KT == 0)
            {
                if (dk == true)
                {
                    Dhk = (((D15 + 2 * D45) / 3 + 2 * Dkt) / 3 + 2 * Dthi) / 3;
                    tbxDIEMHK.Text = Dhk.ToString();
                    DataRow row = dtD.NewRow();
                    row["MAHS"] = cbxMAHS.Text;
                    row["MALOP"] = cbxMALOP.Text;
                    row["MAMON"] = cbxMAMON.SelectedValue;
                    row["MANAMHOC"] = cbxMANAMHOC.Text;
                    row["MAHK"] = cbxMAHK.Text;
                    row["DIEM15"] = tbxDIEM15.Text;
                    row["DIEM45"] = tbxDIEM45.Text;
                    row["DIEMKT"] = tbxDIEMKT.Text;
                    row["DIEMTHI"] = tbxDIEMTHI.Text;
                    row["DIEMHK"] = tbxDIEMHK.Text;
                    dtD.Rows.Add(row);
                    SqlCommand commandinsert = new SqlCommand();
                    commandinsert.Connection = con;
                    commandinsert.CommandType = CommandType.Text;
                    commandinsert.CommandText = @"INSERT DIEM (MAHS,MALOP,MAMON,MANAMHOC,MAHK,DIEM15,DIEM45,DIEMKT,DIEMTHI,DIEMHK)
                                              VALUES(@MAHS,@MALOP,@MAMON,@MANAMHOC,@MAHK,@DIEM15,@DIEM45,@DIEMKT,@DIEMTHI,@DIEMHK)";
                    commandinsert.Parameters.Add("@MAHS", SqlDbType.VarChar, 10, "MAHS");
                    commandinsert.Parameters.Add("@MALOP", SqlDbType.VarChar, 10, "MALOP");
                    commandinsert.Parameters.Add("@MAMON", SqlDbType.VarChar, 10, "MAMON");
                    commandinsert.Parameters.Add("@MANAMHOC", SqlDbType.Int, 50, "MANAMHOC");
                    commandinsert.Parameters.Add("@MAHK", SqlDbType.VarChar, 10, "MAHK");
                    commandinsert.Parameters.Add("@DIEM15", SqlDbType.NVarChar, 50, "DIEM15");
                    commandinsert.Parameters.Add("@DIEM45", SqlDbType.NVarChar, 50, "DIEM45");
                    commandinsert.Parameters.Add("@DIEMKT", SqlDbType.NVarChar, 50, "DIEMKT");
                    commandinsert.Parameters.Add("@DIEMTHI", SqlDbType.NVarChar, 50, "DIEMTHI");
                    commandinsert.Parameters.Add("@DIEMHK", SqlDbType.NVarChar, 50, "DIEMHK");
                    da.InsertCommand = commandinsert;
                    da.Update(dtD);
                    MessageBox.Show("Bạn Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxMALOP.Enabled = false;
                    cbxMANAMHOC.Enabled = false;
                    cbxMAHK.ResetText(); 
                    cbxMAHS.ResetText();
                    cbxMALOP.ResetText();
                    cbxMAMON.ResetText();
                    cbxMANAMHOC.ResetText();
                    tbxDIEM15.Clear();
                    tbxDIEM45.Clear();
                    tbxDIEMHK.Clear();
                    tbxDIEMKT.Clear();
                    tbxDIEMTHI.Clear();
                }
                else
                    MessageBox.Show("Thông Tin Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancal_Click(object sender, EventArgs e)
        {
            cbxMAHK.ResetText();
            cbxMAHS.ResetText();
            cbxMALOP.ResetText();
            cbxMAMON.ResetText();
            cbxMANAMHOC.ResetText();
            tbxDIEM15.Text = "";
            tbxDIEM45.Text = "";
            tbxDIEMHK.Text = "";
            tbxDIEMKT.Text = "";
            tbxDIEMTHI.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiem Diem = new frmDiem();
            Diem.ShowDialog();
        }
        private DataSet kttk()
        {
            SqlCommand commandKT = new SqlCommand();
            commandKT.Connection = con;
            ds = new DataSet();
            commandKT.CommandType = CommandType.Text;
            commandKT.CommandText = @"Select * from DIEM";
            da.SelectCommand = commandKT;
            da.Fill(ds);
            return ds;

        }

        private void timKiemHocSinh()
        {
            dtHS.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select S.MAHS as N'MÃ HỌC SINH',TENHS as N'HỌ TÊN',NAMHOC as N'NĂM HỌC',LOP as N'LỚP'
                                         From HOCSINH S
                                         WHere S.LOP Like @LOP";
            command.Parameters.Add("LOP", SqlDbType.VarChar, 10).Value = cbxLop.Text;
            da.SelectCommand = command;
            da.Fill(dtHS);
            dgvHocSinh.DataSource = dtHS;
        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            //timKiemHocSinh();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            timKiemHocSinh();
        }

        private void dgvHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentIndext = dgvHocSinh.CurrentRow.Index;
            cbxMAHS.Text = dgvHocSinh.Rows[currentIndext].Cells[0].Value.ToString();
            cbxMANAMHOC.Text = dgvHocSinh.Rows[currentIndext].Cells[2].Value.ToString();
            cbxMALOP.Text = dgvHocSinh.Rows[currentIndext].Cells[3].Value.ToString();

        }

        private void btnSang_Click(object sender, EventArgs e)
        {
            int currentIndext = dgvHocSinh.CurrentRow.Index;
            cbxMAHS.Text = dgvHocSinh.Rows[currentIndext].Cells[0].Value.ToString();
            cbxMANAMHOC.Text = dgvHocSinh.Rows[currentIndext].Cells[2].Value.ToString();
            cbxMALOP.Text = dgvHocSinh.Rows[currentIndext].Cells[3].Value.ToString();

        }

        private void checMalop_CheckedChanged(object sender, EventArgs e)
        {
            if (checMalop.Checked == true)
                cbxMALOP.Enabled = true;
            else
                cbxMALOP.Enabled = false;
        }

        private void checNamHoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checNamHoc.Checked == true)
                cbxMANAMHOC.Enabled = true;
            else
                cbxMANAMHOC.Enabled = false;
        }

      
        
    }
}
