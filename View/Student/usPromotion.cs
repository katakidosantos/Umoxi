using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usPromotion : UserControl
    {
        public usPromotion()
        {
            InitializeComponent();
            LoadData();
        }

        #region instance
        private static usPromotion _instance;

        public static usPromotion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usPromotion();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT        SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchool);
            ConnectionNode.FILLComboBox("SELECT        CLASS_ID, Class_name  FROM            ClassName", cmbClass);
            ConnectionNode.FILLComboBox("SELECT        BATCH_ID, BatchName  FROM            Batch", cmbSession);
            ConnectionNode.FillDataGrid(" SELECT        STUDENT_ID, AdmissionNo, StudentName  FROM            StudentInformation " + " WHERE        (SCHOOL_ID = 0  ) ", DataGridView1);
        }

        private void btnAddPromotion_Click(object sender, EventArgs e)
        {
            frmAddPromotion promotion = new frmAddPromotion();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (promotion)
            {
                promotion.school = cmbSchool;
                promotion.classe = cmbClass;
                promotion.session = cmbSession;
                promotion.DataGridView1 = DataGridView1;
                promotion.ShowDialog();
            }
            LoadData();
        }

        private void btnPrintSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool.Text))
            {
                Snackbar.Show(FrmMain.Default, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSession.Text))
            {
                Snackbar.Show(FrmMain.Default, "Required: Session", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbClass.Text))
            {
                Snackbar.Show(FrmMain.Default, "Required: Class", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                ConnectionNode.FillDataGrid(" SELECT        STUDENT_ID, AdmissionNo, StudentName  FROM            StudentInformation " +
                    " WHERE        (SCHOOL_ID = " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (CLASS_ID = " + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (BATCH_ID = " + cmbSession.Text.Split(" # ".ToCharArray()[0])[0] + ") ", DataGridView1);
            }
        }
    }
}
