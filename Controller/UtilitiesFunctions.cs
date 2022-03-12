using Microsoft.VisualBasic;
using System;
using System.Text;
using Bunifu.UI.WinForms;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Data.Utils;
using DevExpress.Utils.Animation;
using System.Drawing;

namespace Umoxi
{
    class UtilitiesFunctions
    {
        #region Password view

        public static void ViewPassword(bool status, BunifuTextBox textBox)
        {
            switch (status)
            {
                case true:
                    textBox.UseSystemPasswordChar = false;
                    textBox.IconRight = Properties.Resources.icons8_invisible_24px_1;
                    break;
                case false:
                    textBox.UseSystemPasswordChar = true;
                    textBox.IconRight = Properties.Resources.icons8_eye_24px_1;
                    break;
            }
        }
        #endregion

        #region replace
        public static object str_repl(string str)
        {
            return str.Replace("'", "").Replace(",", ",").Replace("`", "");
        }
        #endregion

        #region EmailCheck
        public static bool EmailCheck(string emailAddress)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var emailAddressMatch = Regex.Match(emailAddress, pattern);
            if (emailAddressMatch.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Criptograpic
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        #endregion

        #region ExportToExcel
        public static void ExportDataToExcelSheet(DataGridView dgv)
        {
            dynamic Exp_Xls = default(dynamic);
            int lig_cpt = 0;
            int Col_cpt = 0;
            Exp_Xls = Interaction.CreateObject("Excel.Application");
            Exp_Xls.Workbooks.add();
            Exp_Xls.Visible = true;
            try
            {
                //----------------
                for (Col_cpt = 0; Col_cpt <= dgv.ColumnCount - 4; Col_cpt++)
                {
                    Exp_Xls.ActiveSheet.Cells(1, Col_cpt + 1).value = dgv.Columns[Col_cpt].HeaderText;
                }
                for (lig_cpt = 0; lig_cpt <= dgv.Rows.Count - 1; lig_cpt++)
                {
                    for (Col_cpt = 0; Col_cpt <= dgv.ColumnCount - 4; Col_cpt++)
                    {
                        if (Information.IsNumeric(dgv[Col_cpt, lig_cpt].Value))
                        {
                            Exp_Xls.ActiveSheet.Cells(lig_cpt + 2, Col_cpt + 1).value = System.Convert.ToDouble(dgv[Col_cpt, lig_cpt].Value);
                        }
                        else
                        {
                            Exp_Xls.ActiveSheet.Cells(lig_cpt + 2, Col_cpt + 1).value = dgv[Col_cpt, lig_cpt].Value;
                        }
                    }
                }
                //----------------
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

        }
        #endregion

        #region name
        public static void Audit_Trail(int user_ID, string xtime, string xAction)
        {
            ConnectionNode.sqlSTR = "INSERT INTO UserTrail (User_ID, Action, Date, Timex, log_ID) " +
                "VALUES (" + System.Convert.ToString(user_ID) + ", "
                + "'" + xAction + "', "
                + "'" + Strings.Format(DateTime.Now, "MM/dd/yyyy") + "', "
                + "'" + xtime + "', " 
                + System.Convert.ToString(ConnectionNode.LOGID) + ")";
            ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlSTR);
        }
        #endregion

        #region name
        public static void StudentBanalce(double STUDENT_ID, BunifuTextBox Amount)
        {
            ConnectionNode.ExecuteSQLQuery(" SELECT        Debit, Credit  FROM            StudentLedger  WHERE        (STUDENT_ID = " + System.Convert.ToString(STUDENT_ID) + ") ");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                ConnectionNode.ExecuteSQLQuery(" SELECT  SUM(Debit - Credit) AS Exp1  FROM   StudentLedger  WHERE        (STUDENT_ID = " + System.Convert.ToString(STUDENT_ID) + ") ");
                Amount.Text = "balanço: " + ConnectionNode.sqlDT.Rows[0]["Exp1"];
            }
            else
            {
                Amount.Text = "balanço: 0";
            }
        }
        #endregion

    }
}
