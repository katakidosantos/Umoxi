using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usPermission : UserControl
    {
        public int Current;
        public usPermission()
        {
            InitializeComponent();
            LoadData();
        }

        private static usPermission _instance;

        public static usPermission Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usPermission();
                return _instance;
            }
        }

        public void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT User_ID, user_name   FROM Users", cmbUser);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ConnectionNode.FILLComboBox("SELECT User_ID, user_name   FROM Users", cmbUser);
        }


        private void ShowPopup()
        {
            btnNext.Enabled=false;
            Snackbar.Show(FrmMain.Default, "Select user!", BunifuSnackbar.MessageTypes.Warning);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUser.Text))
            {
                ShowPopup();
            }
            else
            {
                OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

                frmAddPermission addPermission = new frmAddPermission();

                using (addPermission)
                {
                    addPermission.permission = cmbUser;
                    addPermission.LoadAccessKey();
                    addPermission.ShowDialog();
                }
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            OverlayLoading.handle = OverlayLoading.ShowProgressPanel(FrmMain.Default);

            frmAddPermission addPermission = new frmAddPermission();
            if (string.IsNullOrEmpty(cmbUser.Text))
            {
            }
            else
            {
                btnNext.Enabled=true;
                using (addPermission)
                {
                    addPermission.permission = cmbUser;
                    addPermission.ViewAcess();
                    Current = addPermission.currentP;
                }
                OverlayLoading.CloseProgressPanel(OverlayLoading.handle);
            }
        }
    }
}
