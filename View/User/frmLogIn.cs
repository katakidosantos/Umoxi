using Bunifu.UI.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Umoxi.Controller;

namespace Umoxi
{
    public partial class frmLogIn : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
       
        //caso o numero de tantivas para fazer login seja maior q 10 então aplicação fecha
        private int numero_de_tentativas;
     
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
                chkRememberMe.Checked = Properties.Settings.Default.App_UserRemember;
            }

            
        }

        void frmExit_Tick(object sender, EventArgs e)
        {
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


        void _validarCampos() {

            TransitionsEffects.ResetColor(txtUserName, lblUserName);
            TransitionsEffects.ResetColor(txtPassword, lblPassword);
            if (string.IsNullOrWhiteSpace(this.txtUserName.Text))
            {
                Snackbar.Show(this, "O campo usúario é necessário!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtUserName, lblUserName);
            }
            else if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                Snackbar.Show(this, "Password inválida!!!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtPassword, lblPassword);

            }
            else
            {
                _iniciarSessao();
            }
          

        }

        private void _iniciarSessao()
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


                FrmMain.Default.LogOffToolStripMenuItem.Caption = "Terminar sessão " + ConnectionNode.userName;
                FrmMain.Default.currentUser.Caption = "Bem-vindo " + ConnectionNode.userName;
                FrmMain.Default.toastNotificationsManager1.Notifications[0].Body = "Nova sessão iniciada no sistema com a conta " + ConnectionNode.userName;
                FrmMain.Default.lblUserName.Text = "@" + ConnectionNode.userName;
                FrmMain.Default.lblFullName.Text = ConnectionNode.fullName;
                //FrmMain.Default.lblUserEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["e_mail"]);
                FrmMain.Default.lblUser_name.Text = ConnectionNode.userName;
                #endregion

                UtilitiesFunctions.Logger(ConnectionNode.xUser_ID, Convert.ToString(DateTime.Now.ToLongTimeString()), "Usuario: " + txtUserName.Text + " iniciou sessão no sistema ");

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
                numero_de_tentativas++;
                if (numero_de_tentativas >= 3)
                {
                    Snackbar.Show(this, "Demasiadas tentativas incorretas!!!", BunifuSnackbar.MessageTypes.Error);
                    Application.Exit();
                }
                else
                    Snackbar.Show(this, "Você não tem permissão para usar o sistema \n" +
                        "Para mais informações por favor, converse com \n" +
                        "O administrador do sistema!", BunifuSnackbar.MessageTypes.Warning);
                return;
            }

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            _validarCampos();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
