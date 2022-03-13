using System;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.Utils.Controls;
using System.Windows.Forms;

namespace Umoxi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            WindowsFormsSettings.ForceDirectXPaint();
            WindowsFormsSettings.SetDPIAware();
            WindowsFormsSettings.EnableFormSkins();
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Touch;
            WindowsFormsSettings.CustomizationFormSnapMode = SnapMode.OwnerControl;
            WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.True;

            if (!ConnectionNode.CheckServer())
                Application.Run(new FrmServerSetting());
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT * FROM usuarios");
                if (!(ConnectionNode.sqlDT.Rows.Count > 0))
                    Application.Run(new frmLogIn());
                else
                    Application.Run(new frmLogIn());
            }
        }
    }
}