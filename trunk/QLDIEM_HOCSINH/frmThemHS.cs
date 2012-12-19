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
    public partial class frmThemHS : Form
    {

        private SqlConnection con;
        private DataTable dtHS = new DataTable("HOCSINH");
        private DataTable dtNH = new DataTable("NAMHOC");
        private DataTable dtKQ = new DataTable("KETQUA");
        private DataTable dtLop = new DataTable("LOP");
        private DataSet ds;
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
        public frmThemHS()
        {
            InitializeComponent();
            connect();
            getDaTa();
            tbxMAHS.Text = maTD();
        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            string checkMa = tbxMAHS.Text;
            string checkTen = tbxTENHS.Text;
            bool kt=true;
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
            foreach (DataRow dtr in KT().Tables[0].Rows)
            {
                if (dtr["MAHS"].ToString() == tbxMAHS.Text)
                    kt = false;
            }
            if (checkMa != "" && checkTen != "")
            {
                if (kt == true)
                {
                    if (ktt == true)
                    {
                        DataRow row = dtHS.NewRow();
                        row["MAHS"] = tbxMAHS.Text;
                        row["TENHS"] = tbxTENHS.Text;
                        row["NAMHOC"] = cbxNAMHOC.Text;
                        row["LOP"] = cbxLop.Text;
                        row["NGAYSINH"] = dtpNgaySinh.Value;
                        row["GIOITINh"] = cbxGIOITINH.Text;
                        row["QUEQUAN"] = tbxQUEQUAN.Text;
                        dtHS.Rows.Add(row);
                        SqlCommand commandinsert = new SqlCommand();
                        commandinsert.Connection = con;
                        commandinsert.CommandType = CommandType.Text;
                        commandinsert.CommandText = @"insert HOCSINH (MAHS,TENHS,NAMHOC,LOP,NGAYSINH,GIOITINH,QUEQUAN)
                                        values(@MAHS,@TENHS,@NAMHOC,@LOP,@NGAYSINH,@GIOITINH,@QUEQUAN)";
                        commandinsert.Parameters.Add("@MAHS", SqlDbType.VarChar, 10, "MAHS");
                        commandinsert.Parameters.Add("@TENHS", SqlDbType.NVarChar, 50, "TENHS");
                        commandinsert.Parameters.Add("@NAMHOC", SqlDbType.Int, 50, "NAMHOC");
                        commandinsert.Parameters.Add("@LOP", SqlDbType.VarChar, 10, "LOP");
                        commandinsert.Parameters.Add("@NGAYSINH", SqlDbType.DateTime, 50, "NGAYSINH");
                        commandinsert.Parameters.Add("@GIOITINh", SqlDbType.NVarChar, 50, "GIOITINH");
                        commandinsert.Parameters.Add("@QUEQUAN", SqlDbType.NVarChar, 50, "QUEQUAN");
                        da.InsertCommand = commandinsert;
                        da.Update(dtHS);
                        DataRow rowkq = dtKQ.NewRow();
                        rowkq["MAHS"] = tbxMAHS.Text;
                        rowkq["MANAMHOC"] = cbxNAMHOC.Text;
                        dtKQ.Rows.Add(rowkq);
                        SqlCommand commandinsertkq = new SqlCommand();
                        commandinsertkq.Connection = con;
                        commandinsertkq.CommandType = CommandType.Text;
                        commandinsertkq.CommandText = @"insert KETQUA (MAHS,MANAMHOC)
                                            Values(@MAHS,@MANAMHOC)";
                        commandinsertkq.Parameters.Add("@MAHS", SqlDbType.VarChar, 10, "MAHS");
                        commandinsertkq.Parameters.Add("@MANAMHOC", SqlDbType.Int, 50, "MANAMHOC");
                        da.InsertCommand = commandinsertkq;
                        da.Update(dtKQ);
                        MessageBox.Show("Ban them thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        tbxMAHS.Text = "";
                        tbxTENHS.Text = "";
                        dtpNgaySinh.ResetText();
                        cbxGIOITINH.ResetText();
                        tbxQUEQUAN.Text = "";
                        tbxMAHS.Text = maTD();
                    }
                }
                else
                {
                    MessageBox.Show("Học Sinh Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn Chưa Nhập mã hoặc chưa nhập tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void getDaTa()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select * From HOCSINH";
            da.SelectCommand = command;
            da.Fill(dtHS);
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

            command.CommandText = @"select * From KETQUA";
            da.SelectCommand = command;
            da.Fill(dtKQ);
            
        }

        private void btnCancal_Click(object sender, EventArgs e)
        {
            tbxMAHS.Text = "";
            tbxTENHS.Text = "";
            dtpNgaySinh.ResetText();
            cbxGIOITINH.ResetText();
            tbxQUEQUAN.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHocsinh hs = new frmHocsinh();
            hs.ShowDialog();
        }
        private DataSet KT()
        {
        
            SqlCommand commandKT = new SqlCommand();
            commandKT.Connection = con;
            ds = new DataSet();
            commandKT.CommandType = CommandType.Text;
            commandKT.CommandText = @"Select * from HOCSINH";
            da.SelectCommand = commandKT;
            da.Fill(ds);
            return ds;

        
        }
        private string maTD()
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = con;
            selectCommand.CommandType = CommandType.Text;
            selectCommand.CommandText = @"SELECT TOP (1) PERCENT MAHS 
                                         FROM         dbo.HOCSINH
                                         ORDER BY MAHS DESC";
            object maSV = selectCommand.ExecuteScalar();
            if (maSV != null)
            {
                string tam = maSV.ToString().Substring(2);
                int ms = Convert.ToInt32(tam);
                ms++;
                if(ms<10)
                return "HS00"+Convert.ToString(ms);
                else if(ms<100)
                    return "HS0" + Convert.ToString(ms);
                else
                    return "HS" + Convert.ToString(ms);



            }
            else
                return "HS001";

        }
       
    }
}
