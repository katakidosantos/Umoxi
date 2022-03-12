using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace UmojaSchool
{
    public partial class SplashScreen : Form
    {
        Timer Timer = new Timer();
        public SplashScreen()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2019-" + DateTime.Now.Year.ToString();
            this.labelVersion.Text = String.Format("Versão " + AssemblyVersion);
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            if (!ModConnectionNode.CheckServer())
            {
                FrmServerSetting.Default.Show();
                return;
            }

            Timer.Interval = 5000; //5 segundos
            Timer.Tick += new EventHandler(Timer_Tick);

            progressBarControl.Animated = true;
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();
            Timer.Tick -= new EventHandler(Timer_Tick);

            ModConnectionNode.ExecuteSQLQuery(SQLQuery: "SELECT * FROM Users");
            if (!(ModConnectionNode.sqlDT.Rows.Count > 0))
            {
                FrmWelcome create = new FrmWelcome();
                create.Show();
            }
            else
            {
                FrmLogIn.Default.Show();
            }
            this.Hide();
        }

    }
}
