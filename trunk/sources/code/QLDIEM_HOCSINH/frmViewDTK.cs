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
    
    public partial class frmViewDTK : Form
    {
        private SqlConnection con;
        private DataTable dtKQ = new DataTable();
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
        public frmViewDTK()
        {
            InitializeComponent();
            connect();
            getData();
        }
        private void getData()
        {
            SqlCommand command=new SqlCommand();
            command.Connection=con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT KQ.MAHS as N'MAHS' , S.TENHS as N'HO TEN' , KQ.MANAMHOC as N'NAMHOC'
                                         , DTBK1 as N'DIEM TB KY 1' , DTBK2 as N'DIEM TB KY2' , DIEMTK N'DIEM TONG KET'
                                         , HANHKIEM as N'HANH KIEM' , KHENTHUONG as N'KHEN THUONG', KYLUAT as N'KY LUAT'
                                         From KETQUA KQ , HOCSINH S
                                         Where S.MAHS=KQ.MAHS";
            da.SelectCommand = command;
            da.Fill(dtKQ);
            dgvDIEMTK.DataSource = dtKQ;

        }

        private void btnTIMKIEM_Click(object sender, EventArgs e)
        {
            switch (cbxDANHSACH.Text)
            {
                case "TEN":
                    {
                        dtKQ.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT KQ.MAHS as N'MAHS' , S.TENHS as N'HO TEN' , KQ.MANAMHOC as N'NAMHOC'
                                         , DTBK1 as N'DIEM TB KY 1' , DTBK2 as N'DIEM TB KY2' , DIEMTK N'DIEM TONG KET'
                                         , HANHKIEM as N'HANH KIEM' , KHENTHUONG as N'KHEN THUONG', KYLUAT as N'KY LUAT'
                                         From KETQUA KQ , HOCSINH S
                                         Where S.MAHS=KQ.MAHS and S.TENHS LIKE '%'+@TEN+'%'";
                        command.Parameters.Add("@TEN", SqlDbType.NVarChar, 50).Value = tbxThongTin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtKQ);
                        if (dtKQ.Rows.Count > 0)
                        {
                            dgvDIEMTK.DataSource = dtKQ;
                        }
                        else
                        {
                            MessageBox.Show("Khong tim thay thong tin", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "MAHS":
                    {
                        dtKQ.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT KQ.MAHS as N'MAHS' , S.TENHS as N'HO TEN' , KQ.MANAMHOC as N'NAMHOC'
                                         , DTBK1 as N'DIEM TB KY 1' , DTBK2 as N'DIEM TB KY2' , DIEMTK N'DIEM TONG KET'
                                         , HANHKIEM as N'HANH KIEM' , KHENTHUONG as N'KHEN THUONG', KYLUAT as N'KY LUAT'
                                         From KETQUA KQ , HOCSINH S
                                         Where S.MAHS=KQ.MAHS and S.MAHS LIKE '%'+@MAHS+'%'";
                        command.Parameters.Add("@MAHS", SqlDbType.VarChar, 10).Value = tbxThongTin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtKQ);
                        if (dtKQ.Rows.Count > 0)
                        {
                            dgvDIEMTK.DataSource = dtKQ;
                        }
                        else
                        {
                            MessageBox.Show("Khong tim thay thong tin", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "*":
                    {
                        dtKQ.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT KQ.MAHS as N'MAHS' , S.TENHS as N'HO TEN' , KQ.MANAMHOC as N'NAMHOC'
                                         , DTBK1 as N'DIEM TB KY 1' , DTBK2 as N'DIEM TB KY2' , DIEMTK N'DIEM TONG KET'
                                         , HANHKIEM as N'HANH KIEM' , KHENTHUONG as N'KHEN THUONG', KYLUAT as N'KY LUAT'
                                         From KETQUA KQ , HOCSINH S
                                         Where S.MAHS=KQ.MAHS";
                        
                        da.SelectCommand = command;
                        da.Fill(dtKQ);
                        dgvDIEMTK.DataSource = dtKQ;
                        
                    }
                    break;
            }

        }

    }
}
