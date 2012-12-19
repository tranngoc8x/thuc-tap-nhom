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
    public partial class frmHocsinh : Form
    {
        SqlConnection con;
        DataTable dtHS = new DataTable();
        DataTable dtNH = new DataTable();
        DataTable dtLop = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
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
        public frmHocsinh()
        {
            InitializeComponent();
            connect();
            getData();
            binding();
        }
        private void getData()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT S.STT as N'STT' , MAHS as N'MÃ HỌC SINH' , TENHS as N'HỌ TÊN' ,NAMHOC as N'NĂM HỌC',LOP as N'LỚP',NGAYSINH as N'NGÀY SINH',
                                   GIOITINH as N'GIỚI TÍNH', QUEQUAN as N'QUÊ QUÁN'
                                  From HOCSINH S";
            da.SelectCommand = command;
            da.Fill(dtHS);
            dgvHOCSINH.DataSource = dtHS;

            command.CommandText = @"select * From NAMHOC";
            da.Fill(dtNH);
            cbxNAMHOC.DataSource = dtNH;
            cbxNAMHOC.DisplayMember = "MANAMHOC";
            cbxNAMHOC.ValueMember = "NAMHOC";
            cbxNAMHOC.SelectedValue = "NAMHOC";

            command.CommandText = @"Select * From LOP";
            da.Fill(dtLop);
            cbxLop.DataSource = dtLop;
            cbxLop.DisplayMember = "MALOP";
            cbxLop.ValueMember = "MALOP";
            cbxLop.SelectedValue = "MALOP";
        }
        private void binding()
        {
            tbxSTT.DataBindings.Clear();
            tbxSTT.DataBindings.Add("Text", dgvHOCSINH.DataSource, "STT");
            tbxTENHS.DataBindings.Clear();
            tbxTENHS.DataBindings.Add("Text", dgvHOCSINH.DataSource, "HỌ TÊN");
            tbxMAHS.DataBindings.Clear();
            tbxMAHS.DataBindings.Add("Text", dgvHOCSINH.DataSource, "MÃ HỌC SINH");
            dtpNgaySinh.DataBindings.Clear();
            cbxNAMHOC.DataBindings.Clear();
            cbxNAMHOC.DataBindings.Add("Text", dgvHOCSINH.DataSource, "NĂM HỌC");
            cbxLop.DataBindings.Clear();
            cbxLop.DataBindings.Add("Text", dgvHOCSINH.DataSource, "LỚP");
            dtpNgaySinh.DataBindings.Add("Text", dgvHOCSINH.DataSource, "NGÀY SINH");
            cbxGIOITINH.DataBindings.Clear();
            cbxGIOITINH.DataBindings.Add("Text", dgvHOCSINH.DataSource, "GIỚI TÍNH");
            tbxQUEQUAN.DataBindings.Clear();
            tbxQUEQUAN.DataBindings.Add("Text", dgvHOCSINH.DataSource, "QUÊ QUÁN");

        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            bool ktt = false;
            int time = Convert.ToInt32(dtpNgaySinh.Value.Year.ToString());
            int timeht = Convert.ToInt32(DateTime.Now.Year.ToString());
            if (timeht >= 15 + time)
            {
                ktt = true;
            }
            else
            {
                MessageBox.Show("tuổi học sinh phải lớn hơn hoặc bằng 15", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ktt == true)
            {
                DataRow row = dtHS.Select("STT=" + Convert.ToInt32(tbxSTT.Text))[0];
                row.BeginEdit();
                row["MÃ HỌC SINH"] = tbxMAHS.Text;
                row["HỌ TÊN"] = tbxTENHS.Text;
                row["NĂM HỌC"] = cbxNAMHOC.Text;
                row["LỚP"] = cbxLop.Text;
                row["NGÀY SINH"] = dtpNgaySinh.Value;
                row["GIỚI TÍNH"] = cbxGIOITINH.Text;
                row["QUÊ QUÁN"] = tbxQUEQUAN.Text;
                row.EndEdit();
                SqlCommand commandUpdate = new SqlCommand();
                commandUpdate.Connection = con;
                commandUpdate.CommandType = CommandType.Text;
                commandUpdate.CommandText = @"Update HOCSINH SET MAHS=@MAHS ,TENHS=@TENHS,NAMHOC=@NAMHOC,LOP=@LOP,NGAYSINH=@NGAYSINH,
                                                           GIOITINH=@GIOITINH, QUEQUAN=@QUEQUAN
                                        Where STT=@STT and MAHS=@MAHS";
                commandUpdate.Parameters.Add("@STT", SqlDbType.Int, 50, "STT");
                commandUpdate.Parameters.Add("@MAHS", SqlDbType.VarChar, 10, "MÃ HỌC SINH");
                commandUpdate.Parameters.Add("@TENHS", SqlDbType.NVarChar, 50, "HỌ TÊN");
                commandUpdate.Parameters.Add("@NAMHOC", SqlDbType.Int, 50, "NĂM HỌC");
                commandUpdate.Parameters.Add("@LOP", SqlDbType.VarChar, 10, "LỚP");
                commandUpdate.Parameters.Add("@NGAYSINH", SqlDbType.DateTime, 50, "NGÀY SINH");
                commandUpdate.Parameters.Add("@GIOITINH", SqlDbType.NVarChar, 50, "GIỚI TÍNH");
                commandUpdate.Parameters.Add("@QUEQUAN", SqlDbType.NVarChar, 50, "QUÊ QUÁN");

                da.UpdateCommand = commandUpdate;
                da.Update(dtHS);
                MessageBox.Show("Ban sua thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KT(true);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Hide(); ;
            frmThemHS hs = new frmThemHS();
            hs.ShowDialog();
        }

        private void KT(bool kt)
        {
            tbxTENHS.ReadOnly = kt;
            tbxQUEQUAN.ReadOnly = kt;
            cbxNAMHOC.Enabled = !kt;
            cbxLop.Enabled = !kt;
            cbxGIOITINH.Enabled = !kt;
            dtpNgaySinh.Enabled = !kt;
            btnLUU.Enabled = !kt;
            btnSUA.Enabled = kt;
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            KT(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon xoa ban gi nay khong ?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow row = dtHS.Select("STT=" + Convert.ToInt32(tbxSTT.Text))[0];
                row.BeginEdit();
                row.Delete();
                row.EndEdit();
                SqlCommand Deletecommand = new SqlCommand();
                Deletecommand.Connection = con;
                Deletecommand.CommandType = CommandType.Text;
                Deletecommand.CommandText = @"DELETE from HOCSINH where MAHS=@MAHS";
                Deletecommand.Parameters.Add("@MAHS", SqlDbType.VarChar, 10, "MAHS");

                da.DeleteCommand = Deletecommand;
                da.Update(dtHS);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
