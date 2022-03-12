using Bunifu.UI.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmLogIn : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        Timer Exit = new Timer();
        private int xcountx;

        public bool CheckUser;

        public frmLogIn()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
        }

        #region Default Instance

        private static frmLogIn defaultInstance;

        /// <summary>
        /// default instance behavour in C#
        /// </summary>
        public static frmLogIn Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmLogIn();
                    defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.App_UserRemember)
            {
                txtUserName.Text = Properties.Settings.Default.App_UserName;
                txtPassword.Text = Properties.Settings.Default.App_UserPassword;
                chkRememberMe.Checked = Properties.Settings.Default.App_UserRemember;
            }

            Exit.Interval = 3000; //3 segundos
            Exit.Tick += new EventHandler(frmExit_Tick);
            txtPassword.UseSystemPasswordChar = true;
        }

        void frmExit_Tick(object sender, EventArgs e)
        {
            Exit.Stop();
            Exit.Tick -= new EventHandler(frmExit_Tick);
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

        }

        private void lblForgotPass_LinkClicked(object sender, EventArgs e)
        {
          
        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtPassword.UseSystemPasswordChar, txtPassword);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string timex;

            TransitionsEffects.ResetColor(txtUserName, lblUserName);
            TransitionsEffects.ResetColor(txtPassword, lblPassword);

            if (string.IsNullOrWhiteSpace(this.txtUserName.Text))
            {
                Snackbar.Show(this, "Insert the user!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtUserName, lblUserName);
            }
            else if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                Snackbar.Show(this, "Insert the password!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtPassword, lblPassword);
            }
            else
            {
                ConnectionNode.sqlSTR = "SELECT * FROM Users WHERE user_name='" + Convert.ToString(UtilitiesFunctions.str_repl(txtUserName.Text)) + "' AND password ='" + Convert.ToString(UtilitiesFunctions.CreateMD5(txtPassword.Text)) + "' AND (status = 'Y')";
                ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlSTR);
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    Waiting.ShowWaitForm();

                    #region Main content
                    ConnectionNode.userName = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["user_name"]);
                    ConnectionNode.fullName = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["full_name"]);
                    ConnectionNode.xUserPassword = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["password"]);
                    ConnectionNode.xUser_ID = Convert.ToInt32(ConnectionNode.sqlDT.Rows[0]["User_ID"]);
                    byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["UserPicture"]);
                    MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                    FrmMain.Default.UserPictureBox.Image = Image.FromStream(stmBLOBData);
                    FrmMain.Default.toastNotificationsManager1.Notifications[0].AppLogoImage = Image.FromStream(stmBLOBData);
                    FrmMain.Default.PictureBox1.Image = Image.FromStream(stmBLOBData);
                    FrmMain.Default.currentUser.ImageOptions.Image = (new Bitmap(Image.FromStream(stmBLOBData), new Size(20, 20)));
                    FrmMain.Default.labelOff.Text = "Login";
                    timex = DateTime.Now.ToLongTimeString();

                    FrmMain.Default.LogOffToolStripMenuItem.Caption = "Terminar sessão " + ConnectionNode.userName;
                    FrmMain.Default.currentUser.Caption = "Bem-vindo " + ConnectionNode.userName;
                    FrmMain.Default.toastNotificationsManager1.Notifications[0].Body = "Nova sessão iniciada no sistema com a conta " + ConnectionNode.userName;
                    FrmMain.Default.lblUserName.Text = "@" + ConnectionNode.userName;
                    FrmMain.Default.lblFullName.Text = ConnectionNode.fullName;
                    //FrmMain.Default.lblUserEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["e_mail"]);
                    FrmMain.Default.lblUser_name.Text = ConnectionNode.userName;
                    #endregion

                    ConnectionNode.ExecuteSQLQuery("INSERT INTO UserLog (User_ID, Log_In) VALUES (" + ConnectionNode.xUser_ID + ", '" + timex + "')");
                    ConnectionNode.ExecuteSQLQuery("SELECT * FROM UserLog ORDER BY Log_ID DESC");
                    ConnectionNode.LOGID = Convert.ToInt32(ConnectionNode.sqlDT.Rows[0]["Log_ID"]);

                    UtilitiesFunctions.Audit_Trail(ConnectionNode.xUser_ID, Convert.ToString(DateTime.Now.ToLongTimeString()), "Usuario " + txtUserName.Text + " iniciou sessão no sistema ");

                    UserPermission.LoadUserPermission();

                    if (chkRememberMe.Checked)
                    {
                        Properties.Settings.Default.App_UserName = txtUserName.Text;
                        Properties.Settings.Default.App_UserPassword = txtPassword.Text;
                    }
                    else
                    {
                        Properties.Settings.Default.App_UserName = null;
                        Properties.Settings.Default.App_UserPassword = null;
                    }
                    Properties.Settings.Default.App_UserRemember = chkRememberMe.Checked;
                    Properties.Settings.Default.Save();

                    Waiting.CloseWaitForm();
                    FrmMain.Default.Show();
                    this.Hide();
                }
                else
                {
                    xcountx = xcountx + 1;

                    if (xcountx >= 3)
                    {
                        Snackbar.Show(this, "Reached maximum login attempt!", BunifuSnackbar.MessageTypes.Error);
                        Exit.Start();
                    }
                    else
                        Snackbar.Show(this, "You are not allowed to use the system\n" +
                            "For more details, please contact\n" +
                            "your superior management system!", BunifuSnackbar.MessageTypes.Warning);
                    return;
                }
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
