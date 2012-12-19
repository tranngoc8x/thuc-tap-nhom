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
    public partial class frmNamhoc : Form
    {
        private SqlConnection con;
        private int kt = 0;
        private int kt1 = 0;
        private DataTable dtNH = new DataTable("NAMHOC");

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
        public frmNamhoc()
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
            command.CommandText = @"select N.STT as N'STT', N.MANAMHOC as N'MANAMHOC' ,N.NAMHOC as N'NAMHOC', N.DACTA as N'DACTA'
                                         
                                  From NAMHOC N ";
            da.SelectCommand = command;
            da.Fill(dtNH);
            dgvNamhoc.DataSource = dtNH;
        }
        private void binding()
        {
            tbxSTT.DataBindings.Clear();
            tbxSTT.DataBindings.Add("Text", dgvNamhoc.DataSource, "STT");
            tbxMANAMHOC.DataBindings.Clear();
            tbxMANAMHOC.DataBindings.Add("Text", dgvNamhoc.DataSource, "MANAMHOC");
            tbxNAMHOC.DataBindings.Clear();
            tbxNAMHOC.DataBindings.Add("Text", dgvNamhoc.DataSource, "NAMHOC");
            tbxDACTA.DataBindings.Clear();
            tbxDACTA.DataBindings.Add("Text", dgvNamhoc.DataSource, "DACTA");
        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            string ktMaNH = tbxMANAMHOC.Text;
            string ktNamhoc = tbxNAMHOC.Text;
            if (ktMaNH == "")
            {
                kt1 = 1;
                MessageBox.Show("Ban chua nhap ma nam hoc", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (ktNamhoc == "")
            {
                MessageBox.Show("Ban chua them nam hoc", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                kt1 = 1;
            }
            if ((kt == 1) && (kt1 == 0))
            {
                DataRow row = dtNH.NewRow();
                // row["STT"] = tbxSTT.Text;
                row["MANAMHOC"] = tbxMANAMHOC.Text;
                row["NAMHOC"] = tbxNAMHOC.Text;
                row["DACTA"] = tbxDACTA.Text;
                dtNH.Rows.Add(row);
                SqlCommand commandinsert = new SqlCommand();
                commandinsert.Connection = con;
                commandinsert.CommandType = CommandType.Text;
                commandinsert.CommandText = @"INSERT NAMHOC (MANAMHOC,NAMHOC,DACTA)
                                            VALUES(@MANAMHOC,@NAMHOC,@DACTA)";
                commandinsert.Parameters.Add("@MANAMHOC", SqlDbType.Int, 50, "MANAMHOC");
                commandinsert.Parameters.Add("@NAMHOC", SqlDbType.VarChar, 10, "NAMHOC");
                commandinsert.Parameters.Add("@DACTA", SqlDbType.NVarChar, 50, "DACTA");
                da.InsertCommand = commandinsert;
                da.Update(dtNH);
                dtNH.Clear();
                da.Fill(dtNH);
                dgvNamhoc.DataSource = dtNH;
                MessageBox.Show("Ban them thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KiemTra(false);
                tbxMANAMHOC.ReadOnly = true;

            }
            if (kt == 2)
            {

               
                DataRow row = dtNH.Select("STT=" + Convert.ToInt32(tbxSTT.Text))[0];
                row.BeginEdit();
                row["STT"] = tbxSTT.Text;
                row["MANAMHOC"] = tbxMANAMHOC.Text;
                row["NAMHOC"] = tbxNAMHOC.Text;
                row["DACTA"] = tbxDACTA.Text;
                row.EndEdit();
                SqlCommand commandUpdate = new SqlCommand();
                commandUpdate.Connection = con;
                commandUpdate.CommandType = CommandType.Text;
                commandUpdate.CommandText = @"Update NAMHOC SET MANAMHOC=@MANAMHOC,NAMHOC=@NAMHOC,DACTA=@DACTA
                                            Where STT=@STT";
                commandUpdate.Parameters.Add("@STT", SqlDbType.Int, 50, "STT");
                commandUpdate.Parameters.Add("@MANAMHOC", SqlDbType.Int, 50, "MANAMHOC");
                commandUpdate.Parameters.Add("@NAMHOC", SqlDbType.VarChar, 10, "NAMHOC");
                commandUpdate.Parameters.Add("@DACTA", SqlDbType.NVarChar, 50, "DACTA");
                da.UpdateCommand = commandUpdate;
                da.Update(dtNH);
                MessageBox.Show("Ban sua thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                KiemTra(false);
            }
        }
         private void KiemTra(bool kt)
        {
            tbxNAMHOC.ReadOnly = !kt;
            tbxDACTA.ReadOnly = !kt;
            btnLUU.Enabled = kt;
            btnSua.Enabled = !kt;
            btnThem.Enabled = !kt;

        }

         private void btnThem_Click(object sender, EventArgs e)
         {
             kt = 1;
             KiemTra(true);
             tbxDACTA.Text = "";
             //tbxSTT.Text = "";
             tbxMANAMHOC.Text = "";
             tbxNAMHOC.Text = "";
             tbxMANAMHOC.ReadOnly = false;
             KiemTra(true);
         }

         private void btnSua_Click(object sender, EventArgs e)
         {
             kt = 2;
             KiemTra(true);

         }

         private void btnThoat_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnXOA_Click(object sender, EventArgs e)
         {
             //tbxSTT.Clear();
             //tbxNAMHOC.Clear();
             //tbxMANAMHOC.Clear();
             //tbxDACTA.Clear();
             //binding();
         }
        

        
    }
}
