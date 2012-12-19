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
    public partial class frmLogin : Form
    {
        private SqlConnection con;
        private string quyen = "";
        private string pass = "";
        private object Q="";
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
        
       
        public frmLogin()
        {
            InitializeComponent();
            connect();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand commandselect = new SqlCommand();
            commandselect.Connection = con;
           
            commandselect.CommandText = @"Select count(*) from LOGIN Where userName=@userName and pass=@Pass ";
            commandselect.Parameters.Add("@userName", SqlDbType.NVarChar, 50).Value = tbxUser.Text;
            commandselect.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = tbxPassWord.Text;
            

            object check = commandselect.ExecuteScalar();
            if (Int32.Parse(check.ToString()) != 0)
            {
                quyen = Truycap();
                pass = passWord();
                if (MessageBox.Show("Ban dang nhap thanh cong voi Quyen "+quyen, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) ;
                this.Close();
                              
              
            }
            else
                MessageBox.Show("Ban Nhap sai User Pass", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string Truycap()
        {
            SqlCommand commandselect = new SqlCommand();
            commandselect.Connection = con;
            commandselect.CommandText = @"Select quyen from LOGIN where userName=@userName";
            commandselect.Parameters.Add("@userName", SqlDbType.NVarChar, 50).Value = tbxUser.Text;
            object pass = commandselect.ExecuteScalar();
            if (pass != null)
            {
                return pass.ToString();
            }
           
            return null;
        }
        private string passWord()
        {
            SqlCommand commandselect = new SqlCommand();
            commandselect.Connection = con;
            commandselect.CommandText = @"Select pass from LOGIN where userName=@userName";
            commandselect.Parameters.Add("@userName", SqlDbType.NVarChar, 50).Value = tbxUser.Text;
            Q = commandselect.ExecuteScalar();
            if (Q != null)
            {
                return Q.ToString();
            }

            return null;
        }

        public string Quyen
        {
            set{quyen=value;}
            get{return quyen;}
        }
        public string Pass
        {
            set { pass = value; }
            get { return pass; }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            tbxUser.Focus();
        }

        private void tbxPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand commandselect = new SqlCommand();
                commandselect.Connection = con;

                commandselect.CommandText = @"Select count(*) from LOGIN Where userName=@userName and pass=@Pass ";
                commandselect.Parameters.Add("@userName", SqlDbType.NVarChar, 50).Value = tbxUser.Text;
                commandselect.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = tbxPassWord.Text;


                object check = commandselect.ExecuteScalar();
                if (Int32.Parse(check.ToString()) != 0)
                {
                    quyen = Truycap();
                    pass = passWord();
                    if (MessageBox.Show("Ban dang nhap thanh cong voi Quyen " + quyen, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) ;
                    this.Close();


                }
                else
                    MessageBox.Show("Ban Nhap sai User Pass", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
}
