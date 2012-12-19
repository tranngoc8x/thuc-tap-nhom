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
    public partial class frmThemNguoiDung : Form
    {
        private SqlConnection con;
       
        private DataTable dtLogin = new DataTable("LOGIN");
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
        private void getDaTa()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select * From LOGIN";
            da.SelectCommand = command;
            da.Fill(dtLogin);
        }
        private void Disconect()
        {
            con.Close();
            con.Dispose();
            con = null;
        }
        public frmThemNguoiDung()
        {
            InitializeComponent();
            connect();
            getDaTa();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool kt = true;
            foreach (DataRow dtr in getDataSet().Tables[0].Rows)
            {
                if (dtr["userName"].ToString() == tbxUserName.Text)
                {
                    MessageBox.Show("User Da Ton Tai", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kt = false;
                }
            }
            if (tbxUserName.Text != "" && tbxPass.Text != ""&&kt==true)
            {
                DataRow row = dtLogin.NewRow();
                row["userName"] = tbxUserName.Text;
                row["pass"] = tbxPass.Text;
                row["quyen"] = cbxPhanQuyen.Text;
                dtLogin.Rows.Add(row);
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandType = CommandType.Text;
                command.CommandText = @"insert LOGIN (userName,pass,quyen)
                                              values(@userName,@pass,@quyen)";
                command.Parameters.Add("@userName", SqlDbType.NVarChar, 50, "userName");
                command.Parameters.Add("@pass", SqlDbType.NVarChar, 50, "pass");
                command.Parameters.Add("@quyen", SqlDbType.VarChar, 50, "quyen");
                da.InsertCommand = command;
                da.Update(dtLogin);
                MessageBox.Show("Ban them thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private DataSet getDataSet()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            ds = new DataSet();
            command.CommandType = CommandType.Text;
            command.CommandText = @"select * from LOGIN";
            da.SelectCommand = command;
            da.Fill(ds);
            return ds;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
