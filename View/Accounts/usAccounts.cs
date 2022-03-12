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
    public partial class usAccounts : UserControl
    {
        public usAccounts()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[4].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usAccounts _instance;

        public static usAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usAccounts();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid(" SELECT     ChartOfAccount.AC_LEDGER_ID, Accounts.AC_Name, ChartOfAccount.LedgerName, ChartOfAccount.Status " +
                " FROM    ChartOfAccount INNER JOIN  Accounts ON ChartOfAccount.AC_ID = Accounts.AC_ID ", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddLedger_Click(object sender, EventArgs e)
        {
            chartOfAccount account = new chartOfAccount();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (account)
            {
                account.ShowDialog();
            }
            loadData();
        }

        private void btnAddAccounts_Click(object sender, EventArgs e)
        {
            frmAddAccounts accounts = new frmAddAccounts();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (accounts)
            {
                accounts.ShowDialog();
            }
            loadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    #region edit account ledger
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT        ChartOfAccount.AC_LEDGER_ID, ChartOfAccount.AC_ID, ChartOfAccount.LedgerName, ChartOfAccount.LedgerDate, ChartOfAccount.OpeningBalance,  " +
                            " ChartOfAccount.Status, Accounts.AC_Name  FROM            ChartOfAccount INNER JOIN  Accounts ON ChartOfAccount.AC_ID = Accounts.AC_ID " +
                            " WHERE        (ChartOfAccount.AC_LEDGER_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            chartOfAccount chartOfAccount = new chartOfAccount();
                            chartOfAccount.txtLedgerName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["LedgerName"]);
                            chartOfAccount.txtOpeningBalance.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["OpeningBalance"]);
                            chartOfAccount.cmbStatus.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Status"]);
                            chartOfAccount.txtACLedgerId.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["AC_LEDGER_ID"]);
                            chartOfAccount.dtpOpeningDate.DateTime = Convert.ToDateTime(ConnectionNode.sqlDT.Rows[0]["LedgerDate"]);
                            chartOfAccount.cmbAccount.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["AC_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["AC_Name"]);

                            chartOfAccount.btnSave.Text = "Update";

                            #region OpenDialog
                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (chartOfAccount)
                            {
                                chartOfAccount.ShowDialog();
                            }
                            loadData();
                            #endregion
                        }

                    }
                    #endregion
                    break;
                default:
                    break;
            }

        }
    }
}
