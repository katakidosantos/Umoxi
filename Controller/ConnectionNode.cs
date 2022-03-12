using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Xml;

namespace Umoxi
{
    class ConnectionNode
    {
        #region Start code

        public static DataTable sqlDT = new DataTable();
        public static string CnString;
        public static string sqlSTR;
        public static string tmpStr;
        public static string xUserPassword;
        public static int xUser_ID;
        public static string userName;
        public static string fullName;
        public static string userEmail;
        public static int LOGID;

        //Metodo para ver a conexão com a base
        public static bool CheckServer()
        {
            return true;
        }

        public static DataTable ExecuteSQLQuery(string SQLQuery)
        {
            try
            {
                var sqlCon = new SqlConnection(CnString);
                var sqlDA = new SqlDataAdapter(SQLQuery, sqlCon);
                var sqlCB = new SqlCommandBuilder(sqlDA);
                sqlDT.Reset(); // refresh 
                sqlDA.Fill(sqlDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

            return sqlDT;
        }

        //Priencher as comboBox com os dados da db
        public static void FILLComboBox(string sql, System.Windows.Forms.ComboBox cb)
        {
            var conn = new SqlConnection(CnString);
            cb.Items.Clear();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    cb.Items.Add(rdr[0].ToString() + " # " + rdr[1].ToString());
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as comboBox com os dados da db
        public static void FILLComboBox2(string sql, System.Windows.Forms.ComboBox cb)
        {
            var conn = new SqlConnection(CnString);
            cb.Items.Clear();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    cb.Items.Add(rdr[0].ToString());
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as datagridview com os dados da db
        public static void FillDataGrid(string sql, DataGridView dgv)
        {
            var conn = new SqlConnection(CnString);
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var adp = new SqlDataAdapter();
                var dt = new DataTable();
                adp.SelectCommand = cmd;
                adp.Fill(dt);
                dgv.DataSource = dt;
                adp.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as listbox com os dados da db
        public static void FillListBox(string sql, ListBoxControl lstbox)
        {
            var conn = new SqlConnection(CnString);
            lstbox.Items.Clear();
            try
            {
                conn.Open();
                var DT = new DataTable();
                var DS = new DataSet();
                DS.Tables.Add(DT);
                var DA = new SqlDataAdapter(sql, conn);
                DA.Fill(DT);
                foreach (DataRow r in DT.Rows)
                    lstbox.Items.Add(r[0].ToString() + " # " + r[1].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as listbox com os dados da db
        public static void FillListBox2(string sql, ListBoxControl lstbox)
        {
            var conn = new SqlConnection(CnString);
            lstbox.Items.Clear();
            try
            {
                conn.Open();
                var DT = new DataTable();
                var DS = new DataSet();
                DS.Tables.Add(DT);
                var DA = new SqlDataAdapter(sql, conn);
                DA.Fill(DT);
                foreach (DataRow r in DT.Rows)
                    lstbox.Items.Add(r[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //Carregar o logo para db
        public static void UploadCompanyLogo(double SCHOOL_ID, PictureEdit PB1)
        {
            var con = new SqlConnection(CnString);
            con.Open();
            string sql = "UPDATE  SchoolInformation SET  SCH_LOGO=@photo WHERE SCHOOL_ID=" + SCHOOL_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Carregar a photo do usuario
        public static void UploadUserPhoto(double USER_ID, PictureEdit PB1)
        {
            var con = new SqlConnection(CnString);
            con.Open();
            string sql = "UPDATE  Users SET  UserPicture=@photo WHERE User_ID=" + USER_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Carregar a imagem do livro
        public static void UploadBookCoverPhoto(double BOOK_ID, PictureEdit PB1)
        {
            var con = new SqlConnection(CnString);
            con.Open();
            string sql = "UPDATE  BookInfo SET  CoverPhoto=@photo WHERE BOOK_ID=" + BOOK_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Carregar a imagem do estudante
        public static void UploadStudentPhoto(double STUDENT_ID, PictureEdit PB1)
        {
            var con = new SqlConnection(CnString);
            con.Open();
            string sql = "UPDATE  StudentInformation SET  StudentPicture=@photo WHERE STUDENT_ID=" + STUDENT_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Carregar a imagem do funcionario
        public static void UploadEmployeePhoto(double EmployeeID, PictureEdit PB1)
        {
            var con = new SqlConnection(CnString);
            con.Open();
            string sql = "UPDATE  Employee  SET  EmployeePicture=@photo WHERE EmployeeID=" + EmployeeID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //fff


        #endregion
    }
}
