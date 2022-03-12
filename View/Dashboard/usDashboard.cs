using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usDashboard : UserControl
    {
        public usDashboard()
        {
            InitializeComponent();
            this.Tag = "Dashboard";
        }

        private static usDashboard _instance;

        public static usDashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usDashboard();
                return _instance;
            }
        }
    }
}
