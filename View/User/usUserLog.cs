using Bunifu.UI.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usUserLog : UserControl
    {
        public usUserLog()
        {
            InitializeComponent();
            LoadData();
        }

        #region instance
        private static usUserLog _instance;

        public static usUserLog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usUserLog();
                return _instance;
            }
        }
        #endregion

        public void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT User_ID, user_name   FROM Users", cmbUserName);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUserName.Text))
            {
                Snackbar.Show(FrmMain.Default, "Select the user", BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                ConnectionNode.FillDataGrid(" SELECT DISTINCT UserTrail.Date, UserTrail.Action, UserTrail.Timex, UserLog.Log_In, UserLog.Log_Out  FROM            UserTrail INNER JOIN UserLog ON UserTrail.Log_ID = UserLog.Log_ID " +
                    " WHERE        (UserTrail.User_ID = " + cmbUserName.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (UserTrail.Date >=  '" + Strings.Format(DateTimePicker2.DateTime.Date, "MM/dd/yyyy") + "' AND UserTrail.Date <= '" + Strings.Format(DateTimePicker1.DateTime.Date, "MM/dd/yyyy") + "') ", DataGridView1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ConnectionNode.FILLComboBox("SELECT User_ID, user_name   FROM Users", cmbUserName);
        }

        private void btnCleanLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUserName.Text))
            {
                Snackbar.Show(FrmMain.Default, "Select the user", BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID  FROM            UserTrail  WHERE        (User_ID = " + cmbUserName.Text.Split(" # ".ToCharArray()[0])[0] + ")");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE UserTrail  WHERE  (User_ID = " + cmbUserName.Text.Split(" # ".ToCharArray()[0])[0] + ")");
                    ConnectionNode.ExecuteSQLQuery(" DELETE  UserLog WHERE  (User_ID = " + cmbUserName.Text.Split(" # ".ToCharArray()[0])[0] + ") ");
                    btnSubmit.PerformClick();
                    Snackbar.Show(FrmMain.Default, "Informação", BunifuSnackbar.MessageTypes.Information);
                }
                else
                {
                    Snackbar.Show(FrmMain.Default, "O registo do usuário selecionado não foi encontrado", BunifuSnackbar.MessageTypes.Information);
                }
            }
        }
    }
}
