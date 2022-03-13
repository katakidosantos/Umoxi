using System;
using System.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;
using PasswordStrengthControlLib;
using Microsoft.VisualBasic.CompilerServices;
using DevExpress.XtraEditors.ImageEditor;

namespace Umoxi
{
    public partial class FrmFirstOpen : Form
    {
        Timer frmOpem = new Timer();
        string chkVAL;

        public FrmFirstOpen()
        {
            InitializeComponent();
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
        }

        private void FrmUserRegistration_Load(object sender, EventArgs e)
        {
            stepProgress.SelectedItemIndex = -1;
            txtPass_TextChanged(null, null);
            txtUserID.Visible = false;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtUserName, lblUserName);
            TransitionsEffects.ResetColor(txtFullName, lblFullName);
            TransitionsEffects.ResetColor(txtContactNo, lblContactNo);
            TransitionsEffects.ResetColor(txtEmail, lblEmail);
            TransitionsEffects.ResetColor(txtPassword, lblPassword);

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                Snackbar.Show(this, "Nome do Usuário Obrigatório", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtUserName, lblUserName);
            }
            else if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                Snackbar.Show(this, "Contacto Obrigatório", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtFullName, lblFullName);
            }
            else if (string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                Snackbar.Show(this, "Contacto Obrigatório", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
            }
            else if (!UtilitiesFunctions.EmailCheck(txtEmail.Text.Trim()))
            {
                Snackbar.Show(this, "Email Incorreto", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtEmail, lblEmail);
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Snackbar.Show(this, "Senha Obrigatório", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtPassword, lblPassword);
            }
            else
            {
                if (passwordStrengthControl1.StrengthText == "Curta")
                {
                    Snackbar.Show(this, "Senha curta, tente outra!", BunifuSnackbar.MessageTypes.Warning);
                }
                else if (passwordStrengthControl1.StrengthText == "Fraca")
                {
                    Snackbar.Show(this, "Senha fraca, tente outra!", BunifuSnackbar.MessageTypes.Warning);
                }
                else
                {
                    if (txtPassword.Text == txtRePassword.Text)
                    {
                        chkVAL = "Y";
                        TabContent.SelectedTabPage = Page2;
                        stepProgress.SelectedItemIndex = 0;
                    }
                    else
                        Snackbar.Show(this, "As senhas não conscidem!", BunifuSnackbar.MessageTypes.Error);

                }
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            TabContent.SelectedTabPage = Page1;
            stepProgress.SelectedItemIndex = 0;
        }


        private void btnNext2_Click(object sender, EventArgs e)
        {
            TabContent.SelectedTabPage = Page3;
            stepProgress.SelectedItemIndex = 2;
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "Imagem (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
        }

        private void btnReturnP_Click(object sender, EventArgs e)
        {
            TabContent.SelectedTabPage = Page1;
            stepProgress.SelectedItemIndex = -1;
        }

        private void btnNextP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja confirmar os dados da usuario " + txtUserName.Text + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TabContent.SelectedTabPage = Page3;
                stepProgress.SelectedItemIndex = 1;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            int x = PasswordStregthManager.Instance.GetPasswordScore(txtUserName.Text, txtPassword.Text);
            string str = PasswordStregthManager.Instance.GetPasswordStrength(txtUserName.Text, txtPassword.Text);
            Color col = PasswordStregthManager.Instance.GetPasswordColor(txtUserName.Text, txtPassword.Text);
            this.SetPasswordControls(this.passwordStrengthControl1, x, str, Color.Black, col); //"Forca: " +
        }

        private void SetPasswordControls(PasswordStrengthControl cont, int s, string text, Color f, Color b)
        {
            cont.Strength = s;
            cont.SolidColor = b;
            cont.ForeColor = f;
            cont.StrengthText = text;
        }

        private void chkFinish_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkFinish.Checked == true)
                btnSave.Enabled = true;
            else
            {
                btnSave.Enabled = false;
                Snackbar.Show(this, "Não pode utilizar o software\nsem aceitar os nossos termos e Condições!", BunifuSnackbar.MessageTypes.Information);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Usuarios (usuario, password, nome, email, contacto, ativo) VALUES ('" + UtilitiesFunctions.str_repl(txtUserName.Text) + "', '" + UtilitiesFunctions.CreateMD5(txtPassword.Text) + "', '" + UtilitiesFunctions.str_repl(txtFullName.Text) + "', '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', '" + chkVAL + "')");
            //get last inserted id
            ConnectionNode.ExecuteSQLQuery("SELECT User_ID  FROM   Users  ORDER BY User_ID DESC");
            int SCHOOL_ID = 1;
            //upload image
            ConnectionNode.UploadUserPhoto(SCHOOL_ID, PictureBox1);
            UtilitiesFunctions.Logger(ConnectionNode.xUser_ID, DateAndTime.TimeOfDay.ToString(), "primeiro utilizador criado # " + txtUserName.Text);

            #region Permissions

            //ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = 1) AND (AccessKey = *)");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 101) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 102) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 103) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 104) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 105) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 106) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 107) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 108) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 109) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 110) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 111) ");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 201) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 202) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 203) ");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 301) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 302) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 303) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 304) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 305) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 306) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 307) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 308) ");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 401) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 402) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 403) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 404) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 405) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 406) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 407) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 408) ");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 501) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 502) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 503) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 504) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 505) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 506) ");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 601) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 602) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 603) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 604) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 605) ");


            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 701) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 702) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 703) ");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 801) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 802) ");

            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 901) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 902) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 903) ");
            ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (1, 904) ");

            UtilitiesFunctions.Logger(ConnectionNode.xUser_ID, Conversions.ToString(DateAndTime.TimeOfDay), "Set user permission.");

            #endregion

            Snackbar.Show(this, "Concluio as configurações do admin\n Aguarde...!", BunifuSnackbar.MessageTypes.Success);

            frmOpem.Interval = 5000; //cinco segundos
            frmOpem.Tick += new EventHandler(frmOpem_Tick);
            frmOpem.Start();

        }

        void frmOpem_Tick(object sender, EventArgs e)
        {
            frmOpem.Stop();
            frmOpem.Tick -= new EventHandler(frmOpem_Tick);
            frmLogIn.Default.Show();
            this.Close();

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRePassword.Text))
                txtRePassword.UseSystemPasswordChar = false;
            else
                txtRePassword.UseSystemPasswordChar = true;
        }

        private static bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }

        private void FrmFirstOpen_FormClosing(object sender, FormClosingEventArgs e)
        {
            FlyoutAction action = new FlyoutAction() { Caption = "      Confirmar", Description = "Deseja sair da aplicação?" };
            action.ImageOptions.Image = Properties.Resources.icons8_cancel;
            Predicate<DialogResult> predicate = canCloseFunc;
            FlyoutCommand command1 = new FlyoutCommand() { Text = "Sair", Result = DialogResult.Yes };
            FlyoutCommand command2 = new FlyoutCommand() { Text = "Cancelar", Result = DialogResult.No };
            action.Commands.Add(command1);
            action.Commands.Add(command2);
            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new Size(100, 40);
            properties.Style = FlyoutStyle.MessageBox;
            if (FlyoutDialog.Show(this, action, properties, predicate) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtPassword.UseSystemPasswordChar, txtPassword);
        }

        private void txtRePassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtRePassword.UseSystemPasswordChar, txtRePassword);
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "Imagem (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName);
            }
        }

        private void btnNextF_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtSchoolName, lblSchoolName);
            TransitionsEffects.ResetColor(txtAddress, lblAddress);
            TransitionsEffects.ResetColor(txtContactNoSchool, lblContactNoSchool);

            if (string.IsNullOrEmpty(txtSchoolName.Text))
            {
                Snackbar.Show(this, "Nome do Hosital necessario!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtSchoolName, lblSchoolName);
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                Snackbar.Show(this, "Endereço necessario!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtAddress, lblAddress);
            }
            else if (string.IsNullOrEmpty(txtContactNoSchool.Text))
            {
                Snackbar.Show(this, "Contacto necessario!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtContactNoSchool, lblContactNoSchool);
            }
            else
            {
                if (MessageBox.Show("Deseja confirmar os dados do Hospital " + txtSchoolName.Text + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO SchoolInformation (School_Name, Address, Contact_No, FAX, Email, Web) VALUES " + (
                           " ('" + UtilitiesFunctions.str_repl(txtSchoolName.Text) + "', '" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNoSchool.Text) + "', '" + UtilitiesFunctions.str_repl(txtFAX.Text) + "', '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', '" + UtilitiesFunctions.str_repl(txtWeb.Text) + "') "));
                    double SCHOOL_ID = 1;
                    //upload image
                    ConnectionNode.UploadCompanyLogo(SCHOOL_ID, PictureBox1);
                    UtilitiesFunctions.Logger(ConnectionNode.xUser_ID, DateAndTime.TimeOfDay.ToString(), "escola adicionada # " + txtSchoolName.Text);

                    Snackbar.Show(this, "Hospital registrado com sucesso!", BunifuSnackbar.MessageTypes.Success);
                    stepProgress.SelectedItemIndex = 2;
                    TabContent.SelectedTabPage = Page4;
                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void backcolorTop_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnEditImage_Click(object sender, EventArgs e)
        //{
        //    if (editDialog.ShowDialog(pictureEdit1.Image) == DialogResult.OK)
        //    {
        //        pictureEdit1.Image = editDialog.Image;
        //    }
        //}
    }
}