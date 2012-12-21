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
    public partial class frmThemLop : Form
    {
        private SqlConnection con;
        private int kt = 0;
        private int kt1 = 0;
        private DataTable dtLop = new DataTable("LOP");
       
        private SqlDataAdapter da = new SqlDataAdapter();
        
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
        public frmThemLop()
        {
            InitializeComponent();
            connect();
            getDaTa();
            binding();
        }
        private void getDaTa()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select L.STT as N'STT', L.MALOP as N'MALOP' ,L.TENLOP as N'TENLOP', L.SISO as N'SISO' 
                                         
                                  From LOP L ";
            da.SelectCommand = command;
            da.Fill(dtLop);
            dgvThemlop.DataSource = dtLop;
        }
        private void binding()
        {
            tbxSTT.DataBindings.Clear();
            tbxSTT.DataBindings.Add("Text", dgvThemlop.DataSource, "STT");
            tbxMALOP.DataBindings.Clear();
            tbxMALOP.DataBindings.Add("Text", dgvThemlop.DataSource, "MALOP");
            tbxTenLop.DataBindings.Clear();
            tbxTenLop.DataBindings.Add("Text", dgvThemlop.DataSource, "TENLOP");
            tbxSISO.DataBindings.Clear();
            tbxSISO.DataBindings.Add("Text", dgvThemlop.DataSource, "SISO");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            kt = 1;
            KiemTra(true);
            tbxSISO.Text = "";
            //tbxSTT.Text = "";
            tbxMALOP.Text = "";
            tbxTenLop.Text = "";
            tbxMALOP.ReadOnly = false;
            KiemTra(true);
        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            string ktMalop = tbxMALOP.Text;
            string ktTenlop = tbxTenLop.Text;
            if (ktMalop == "")
            {
                kt1 = 1;
                MessageBox.Show("Ban chua nhap ma lop", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (ktTenlop == "")
            {
                MessageBox.Show("Ban them ten lop", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                kt1 = 1;
            }
            if ((kt == 1)&&(kt1==0))
            {
                DataRow row = dtLop.NewRow();
               // row["STT"] = tbxSTT.Text;
                row["MALOP"] = tbxMALOP.Text;
                row["TENLOP"] = tbxTenLop.Text;
                row["SISO"] = tbxSISO.Text;
                dtLop.Rows.Add(row);
                SqlCommand commandinsert = new SqlCommand();
                commandinsert.Connection = con;
                commandinsert.CommandType = CommandType.Text;
                commandinsert.CommandText = @"INSERT LOP (MALOP,TENLOP,SISO)
                                            VALUES(@MALOP,@TENLOP,@SISO)";
                commandinsert.Parameters.Add("@MALOP", SqlDbType.VarChar, 10, "MALOP");
                commandinsert.Parameters.Add("@TENLOP", SqlDbType.NVarChar, 50, "TENLOP");
                commandinsert.Parameters.Add("@SISO", SqlDbType.Int, 50, "SISO");
                da.InsertCommand = commandinsert;
                da.Update(dtLop);
                dtLop.Clear();
                da.Fill(dtLop);
                dgvThemlop.DataSource = dtLop;
                MessageBox.Show("Ban them thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KiemTra(false);
                tbxMALOP.ReadOnly = true;

            }
            if (kt == 2)
            {

               
                DataRow row = dtLop.Select("STT=" + Convert.ToInt32(tbxSTT.Text))[0];
                row.BeginEdit();
                row["STT"] = tbxSTT.Text;
                row["MALOP"] = tbxMALOP.Text;
                row["TENLOP"] = tbxTenLop.Text;
                row["SISO"] = tbxSISO.Text;
                row.EndEdit();
                SqlCommand commandUpdate = new SqlCommand();
                commandUpdate.Connection = con;
                commandUpdate.CommandType = CommandType.Text;
                commandUpdate.CommandText = @"Update LOP SET MALOP=@MALOP,TENLOP=@TENLOP,SISO=@SISO
                                            Where STT=@STT";
                commandUpdate.Parameters.Add("@STT", SqlDbType.Int, 50, "STT");
                commandUpdate.Parameters.Add("@MALOP", SqlDbType.VarChar, 10, "MALOP");
                commandUpdate.Parameters.Add("@TENLOP", SqlDbType.NVarChar, 50, "TENLOP");
                commandUpdate.Parameters.Add("@SISO", SqlDbType.Int, 50, "SISO");
                da.UpdateCommand = commandUpdate;
                da.Update(dtLop);
                MessageBox.Show("Ban sua thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                KiemTra(false);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = 2;
            //tbxSTT.ReadOnly = false;
            KiemTra(true);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void KiemTra(bool kt)
        {
            tbxTenLop.ReadOnly = !kt;
            tbxSISO.ReadOnly = !kt;
            btnLUU.Enabled = kt;
            btnSua.Enabled = !kt;
            btnThem.Enabled = !kt;

        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon xoa ban gi nay khong ?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow row = dtLop.Select("STT=" + Convert.ToInt32(tbxSTT.Text))[0];
                row.BeginEdit();
                row.Delete();
                row.EndEdit();
                SqlCommand Deletecommand = new SqlCommand();
                Deletecommand.Connection = con;
                Deletecommand.CommandType = CommandType.Text;
                Deletecommand.CommandText = @"DELETE from LOP where MALOP=@MALOP ";
                Deletecommand.Parameters.Add("@MALOP", SqlDbType.VarChar, 10, "MALOP");
                
                da.DeleteCommand = Deletecommand;
                da.Update(dtLop);
            }
        }

        
        
       
    }
}
