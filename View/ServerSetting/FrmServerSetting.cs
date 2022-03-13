using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Umoxi
{
    public partial class FrmServerSetting : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public FrmServerSetting()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmServerSetting defaultInstance;

        /// <summary>
        /// default instance behavour in C#
        /// </summary>
        public static FrmServerSetting Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmServerSetting();
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

        public void SavetoXML(object dbconnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes.Item(0).Value = Convert.ToString(dbconnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtconnString.Text))
            {
                MessageBox.Show("Please enter a connection string..", "Empty line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SavetoXML(txtconnString.Text);
                MessageBox.Show("Successfully saved to ConnectionString.xml", "Save record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
        }

        private string dbconnString;

        public void ReadfromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            dbconnString = root.Attributes.Item(0).Value;
            txtconnString.Text = dbconnString;
        }

        public void frmServerSetting_Load(Object sender, System.EventArgs e)
        {
            ReadfromXML();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
