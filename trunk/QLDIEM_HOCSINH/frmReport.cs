using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsort.Reporting.WinForms
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace QLDIEM_HOCSINH
{
    public partial class frmReport : Form
    {
    //    private SqlConnection con;
     
    //    private DataTable dtLOP = new DataTable("LOP");
        
    //    private SqlDataAdapter da = new SqlDataAdapter();
       
    //    private DataSet ds;
    //    private void connect()
    //    {
    //        string cn = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLHOCSINH;Integrated Security=True";
    //        try
    //        {
    //            con = new SqlConnection(cn);
    //            con.Open();

    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("Khong the ket noi CSDL", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }
    //    private void Disconect()
    //    {
    //        con.Close();
    //        con.Dispose();
    //        con = null;
    //    }
    //    private void getDaTa()
    //    {
    //        SqlCommand command = new SqlCommand();
    //        command.Connection = con;
    //        command.CommandType = CommandType.Text;
                      
    //        command.CommandText = @"select * From LOP";
    //        da.Fill(dtLOP);
    //        cbxMALOP.DataSource = dtLOP;
    //        cbxMALOP.DisplayMember = "TENLOP";
    //        cbxMALOP.ValueMember = "MALOP";
    //        cbxMALOP.SelectedValue = "MALOP";

            
    //    }
        public frmReport()
        {
            InitializeComponent();
            //connect();
            //getDaTa();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.dataSet1.LOP);
            // TODO: This line of code loads data into the 'dataSet1.DataTable2' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.Fill(this.dataSet1.DataTable2);
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            setParameter();
            reportViewer1.RefreshReport();
            
        }
        private void setParameter()
        {
            ReportParameter[] parameter = new ReportParameter[1]; 

            parameter[0] = new ReportParameter("SortName");
            parameter[0].Values.Add(cbxMALOP.Text);
           
            
            reportViewer1.LocalReport.SetParameters(parameter);
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            setParameter();
            reportViewer1.RefreshReport();
            
        }
        

       

        //private void reportViewer1_Load(object sender, EventArgs e)
        //{

        //}

        //private void tabControlPanel2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
