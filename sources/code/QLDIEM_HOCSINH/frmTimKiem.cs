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
    public partial class frmTimKiem : Form
    {
         private SqlConnection con;
      //  private DataTable dtHS = new DataTable("HOCSINH");
      //  private DataTable dtLOP = new DataTable("LOP");
      //  private DataTable dtHK = new DataTable("HOCKY");
      //  private DataTable dtMH = new DataTable("MONHOC");
      //  private DataTable dtNH = new DataTable("NAMHOC");
        private DataTable dtD = new DataTable("DIEM");
        private SqlDataAdapter da = new SqlDataAdapter();
       // private SqlDataAdapter da1 = new SqlDataAdapter();
        private void connect()
        {
            string cn = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLHOCSINH;Integrated Security=True";
            try
            {
                con =new SqlConnection(cn);
                con.Open();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Khong the ket noi CSDL","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void Disconect()
        {
            con.Close();
            con.Dispose();
            con = null;
        }
        

        private void frmDiem_Load(object sender, EventArgs e)
        {
          
           
        }
        private void getDaTa()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MAHS' ,S.TENHS as N'HOTEN', D.MALOP as N'MALOP' ,MAMON as N'MAMON',MANAMHOC as N'MANAMHOC',
                                         MAHK as N'MAHK' , DIEM15 as N'DIEM15' , DIEM45 as N'DIEM45', DIEMKT as N'DIEMKT',
                                         DIEMTHI as N'DIEMTHI',DIEMHK as N'DIEMHK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS";
           da.SelectCommand = command;
           da.Fill(dtD);
           dgvDiem.DataSource = dtD;

        }

        public frmTimKiem()
        {
            InitializeComponent();
            connect();
            getDaTa();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            switch (cbxKieu.SelectedIndex.ToString())
            {
                case "0":
                    {
                        dtD.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MAHS' ,S.TENHS as N'HOTEN', D.MALOP as N'MALOP' ,MAMON as N'MAMON',MANAMHOC as N'MANAMHOC',
                                         MAHK as N'MAHK' , DIEM15 as N'DIEM15' , DIEM45 as N'DIEM45', DIEMKT as N'DIEMKT',
                                         DIEMTHI as N'DIEMTHI',DIEMHK as N'DIEMHK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS and S.TENHS Like '%'+@TENHS+'%'" ;
                        command.Parameters.Add("@TENHS", SqlDbType.NVarChar, 50).Value = tbxThongtin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtD);
                        if (dtD.Rows.Count > 0)
                        {

                            dgvDiem.DataSource = dtD;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    break;
                case "1":
                    {
                        dtD.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MAHS' ,S.TENHS as N'HOTEN', D.MALOP as N'MALOP' ,MAMON as N'MAMON',MANAMHOC as N'MANAMHOC',
                                         MAHK as N'MAHK' , DIEM15 as N'DIEM15' , DIEM45 as N'DIEM45', DIEMKT as N'DIEMKT',
                                         DIEMTHI as N'DIEMTHI',DIEMHK as N'DIEMHK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS and D.MAHS Like '%'+@MAHS+'%'";
                        command.Parameters.Add("@MAHS", SqlDbType.VarChar, 10).Value = tbxThongtin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtD);
                        if (dtD.Rows.Count > 0)
                        {

                            dgvDiem.DataSource = dtD;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "2":
                    {
                        dtD.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MAHS' ,S.TENHS as N'HOTEN', D.MALOP as N'MALOP' ,MAMON as N'MAMON',MANAMHOC as N'MANAMHOC',
                                         MAHK as N'MAHK' , DIEM15 as N'DIEM15' , DIEM45 as N'DIEM45', DIEMKT as N'DIEMKT',
                                         DIEMTHI as N'DIEMTHI',DIEMHK as N'DIEMHK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS and D.MALOP Like '%'+@MALOP+'%'";
                        command.Parameters.Add("@MALOP", SqlDbType.VarChar, 10).Value = tbxThongtin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtD);
                        if (dtD.Rows.Count > 0)
                        {

                            dgvDiem.DataSource = dtD;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "3":
                    {
                        dtD.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MAHS' ,S.TENHS as N'HOTEN', D.MALOP as N'MALOP' ,MAMON as N'MAMON',MANAMHOC as N'MANAMHOC',
                                         MAHK as N'MAHK' , DIEM15 as N'DIEM15' , DIEM45 as N'DIEM45', DIEMKT as N'DIEMKT',
                                         DIEMTHI as N'DIEMTHI',DIEMHK as N'DIEMHK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS and D.MAMON Like '%'+@MAMON+'%'";
                        command.Parameters.Add("@MAMON", SqlDbType.VarChar, 10).Value = tbxThongtin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtD);
                        if (dtD.Rows.Count > 0)
                        {

                            dgvDiem.DataSource = dtD;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "4":
                    {
                        dtD.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MAHS' ,S.TENHS as N'HOTEN', D.MALOP as N'MALOP' ,MAMON as N'MAMON',MANAMHOC as N'MANAMHOC',
                                         MAHK as N'MAHK' , DIEM15 as N'DIEM15' , DIEM45 as N'DIEM45', DIEMKT as N'DIEMKT',
                                         DIEMTHI as N'DIEMTHI',DIEMHK as N'DIEMHK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS and D.MANAMHOC Like '%'+@MANAMHOC+'%'";
                        command.Parameters.Add("@MANAMHOC", SqlDbType.VarChar, 10).Value = tbxThongtin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtD);
                        if (dtD.Rows.Count > 0)
                        {

                            dgvDiem.DataSource = dtD;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "5":
                    {
                        dtD.Clear();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"select D.STT as N'STT', D.MAHS as N'MAHS' ,S.TENHS as N'HOTEN', D.MALOP as N'MALOP' ,MAMON as N'MAMON',MANAMHOC as N'MANAMHOC',
                                         MAHK as N'MAHK' , DIEM15 as N'DIEM15' , DIEM45 as N'DIEM45', DIEMKT as N'DIEMKT',
                                         DIEMTHI as N'DIEMTHI',DIEMHK as N'DIEMHK'
                                  From DIEM D , HOCSINH S
                                  WHere D.MAHS=S.MAHS ";
                        //command.Parameters.Add("@MANAMHOC", SqlDbType.VarChar, 10).Value = tbxThongtin.Text;
                        da.SelectCommand = command;
                        da.Fill(dtD);
                        if (dtD.Rows.Count > 0)
                        {

                            dgvDiem.DataSource = dtD;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
           }
        }
    }
}
