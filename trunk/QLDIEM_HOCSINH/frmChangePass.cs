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
    public partial class frmChangePass : Form
    {
        private SqlConnection con;
       // private string pass = "";
        private object Q = "";
        DataSet ds;
        //private truyCap tc = new truyCap(); 
        private DataTable dtLogin = new DataTable("LOGIN");

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
        public frmChangePass()
        {
            InitializeComponent();
            connect();
            
        }
        //public string Pass
        //{
        //    set { pass = value; }
        //    get { return pass; }
        //}

        private void btnChange_Click(object sender, EventArgs e)
        {
            //if (tbxOldPass.Text ==Pass  && tbxNewPass.Text != "")
            //{
            //    MessageBox.Show("Mat Khau hop le");
            //}
            foreach (DataRow dtr in getDataSet().Tables[0].Rows)
            {
                if (dtr["pass"].ToString() == tbxOldPass.Text)
                {
                    if (tbxNewPass.Text.Trim() == tbxComform.Text.Trim())
                    {
                        string User = tbxUser.Text;
                        string Pass = tbxNewPass.Text;
                       

                        string sql = "update LOGIN set pass='" + Pass + "' where userName ='" + User + "'";
                        da = new SqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        MessageBox.Show("Ban doi thanh cong","Thong Bao",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Ban Nhap sai pass word");

                    }

                }
                
            }
        }
        private DataSet getDataSet()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            ds=new DataSet();
            command.CommandType = CommandType.Text;
            command.CommandText = @"select * from LOGIN";
            da.SelectCommand = command;
            da.Fill(ds);
            return ds;
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            tbxUser.Focus();

        }
    }
}
