using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using DevExpress.XtraSplashScreen;
using Bunifu.UI.WinForms;

namespace Umoxi
{
    class UserPermission
    {
        #region Start code
        public static void LoadUserPermission()
        {
            //ProgressBar1.show = 10;
            // Primary set up
            // -------ACTION-CODE- 101
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 101)");

            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SchoolInformationToolStripMenuItem.Enabled = true;
                //FrmMain.Default.ToolStripButtonStudent.Enabled = true;
            }
            else
            {
                FrmMain.Default.SchoolInformationToolStripMenuItem.Enabled = false;
                //FrmMain.Default.ToolStripButtonStudent.Enabled = false;
            }
            // -------ACTION-CODE- 102
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 102)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SchoolBusToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.SchoolBusToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 103
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 103)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SessionToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.SessionToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 104
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 104)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.ClassToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.ClassToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 105
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 105)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.ClassTypeToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.ClassTypeToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 106
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 106)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.ExaminationToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.ExaminationToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 107
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 107)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SubjectEntryToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.SubjectEntryToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 108
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 108)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.GradingMakingToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.GradingMakingToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 109
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 109)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.FeesEntryToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.FeesEntryToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 110
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 110)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.NationalityToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.NationalityToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 111
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 111)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.HolidayDeclarationToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.HolidayDeclarationToolStripMenuItem.Enabled = false;
            }

            //ProgressBar1.Value = ProgressBar1.Value + 10;

            // Studnet
            // -------ACTION-CODE- 301
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 301)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.StudentInformationToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llStudentInformation.Enabled = true;
            }
            else
            {
                FrmMain.Default.StudentInformationToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llStudentInformation.Enabled = false;
            }
            // -------ACTION-CODE- 302
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 302)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.StudentListToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llStudentList.Enabled = true;
            }
            else
            {
                FrmMain.Default.StudentListToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llStudentList.Enabled = false;
            }
            // -------ACTION-CODE- 303
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 303)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.IdentityCardToolStripMenuItem.Enabled = true;
                //FrmMain.Default.ToolStripButtonPay.Enabled = true;
                //FrmMain.Default.llIdentityCard.Enabled = true;
            }
            else
            {
                FrmMain.Default.IdentityCardToolStripMenuItem.Enabled = false;
                //FrmMain.Default.ToolStripButtonPay.Enabled = false;
                //FrmMain.Default.llIdentityCard.Enabled = false;
            }
            // -------ACTION-CODE- 304
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 304)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.FeesCollectionToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llFeesCollection.Enabled = true;
            }
            else
            {
                FrmMain.Default.FeesCollectionToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llFeesCollection.Enabled = false;
            }
            // -------ACTION-CODE- 305
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 305)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.DailyAttendanceToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llDailyAttendance.Enabled = true;
            }
            else
            {
                FrmMain.Default.DailyAttendanceToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llDailyAttendance.Enabled = false;
            }

            // -------ACTION-CODE- 306
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 306)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.MarksEntryToolStripMenuItem.Enabled = true;
                FrmMain.Default.MarkSheetToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llMarksEntry.Enabled = true;
            }
            else
            {
                FrmMain.Default.MarksEntryToolStripMenuItem.Enabled = false;
                FrmMain.Default.MarkSheetToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llMarksEntry.Enabled = false;
            }
            // -------ACTION-CODE- 307
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 307)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.PromotionImprovementToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llPromotion.Enabled = true;
            }
            else
            {
                FrmMain.Default.PromotionImprovementToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llPromotion.Enabled = false;
            }

            // -------ACTION-CODE- 308
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 308)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.WaiverToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.WaiverToolStripMenuItem.Enabled = false;
            }

            //ProgressBar1.Value = ProgressBar1.Value + 10;

            // Student
            // -------ACTION-CODE- 401
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 401)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.EmployeeInformationToolStripMenuItem.Enabled = true;
                FrmMain.Default.EmployeeListToolStripMenuItem1.Enabled = true;
                //FrmMain.Default.llEmployeeInformation.Enabled = true;
                //FrmMain.Default.ToolStripButtonEmployee.Enabled = true;
            }
            else
            {
                FrmMain.Default.EmployeeInformationToolStripMenuItem.Enabled = false;
                FrmMain.Default.EmployeeListToolStripMenuItem1.Enabled = false;
                //FrmMain.Default.llEmployeeInformation.Enabled = false;
                //FrmMain.Default.ToolStripButtonEmployee.Enabled = false;
            }
            // -------ACTION-CODE- 402
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 402)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.EmployeeListToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llEmployeeList.Enabled = true;
            }
            else
            {
                FrmMain.Default.EmployeeListToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llEmployeeList.Enabled = false;
            }
            // -------ACTION-CODE- 403
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 403)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SalaryEntryToolStripMenuItem.Enabled = true;
                FrmMain.Default.EmployeeLedgerToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llSalaryEntry.Enabled = true;
            }
            else
            {
                FrmMain.Default.SalaryEntryToolStripMenuItem.Enabled = false;
                FrmMain.Default.EmployeeLedgerToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llSalaryEntry.Enabled = false;
            }
            // -------ACTION-CODE- 404
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 404)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SalaryPayToolStripMenuItem.Enabled = true;
                //FrmMain.Default.PaySummeryToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llSalaryPay.Enabled = true;
            }
            else
            {
                FrmMain.Default.SalaryPayToolStripMenuItem.Enabled = false;
                //FrmMain.Default.PaySummeryToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llSalaryPay.Enabled = false;
            }
            // -------ACTION-CODE- 405
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 405)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.AttendanceToolStripMenuItem.Enabled = true;
                FrmMain.Default.AttendanceSummeryToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llAttendance.Enabled = true;
            }
            else
            {
                FrmMain.Default.AttendanceToolStripMenuItem.Enabled = false;
                FrmMain.Default.AttendanceSummeryToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llAttendance.Enabled = false;
            }

            // -------ACTION-CODE- 406
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 406)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.DeductionsToolStripMenuItem.Enabled = true;
                FrmMain.Default.DeductionsSummeryToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llDeductions.Enabled = true;
            }
            else
            {
                FrmMain.Default.DeductionsToolStripMenuItem.Enabled = false;
                FrmMain.Default.DeductionsSummeryToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llDeductions.Enabled = false;
            }
            // -------ACTION-CODE- 407
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 407)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.AllowancesToolStripMenuItem.Enabled = true;
                FrmMain.Default.AllowancesSummeryToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llAllowances.Enabled = true;
            }
            else
            {
                FrmMain.Default.AllowancesToolStripMenuItem.Enabled = false;
                FrmMain.Default.AllowancesSummeryToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llAllowances.Enabled = false;
            }


            // Library
            //ProgressBar1.Value = ProgressBar1.Value + 10;
            // -------ACTION-CODE- 501
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 501)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SupplierInformationToolStripMenuItem.Enabled = true;
                FrmMain.Default.SupplierListToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llSupplierInformation.Enabled = true;
            }
            else
            {
                FrmMain.Default.SupplierInformationToolStripMenuItem.Enabled = false;
                FrmMain.Default.SupplierListToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llSupplierInformation.Enabled = false;
            }
            // -------ACTION-CODE- 502
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 502)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.BookInformationToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llBookInformation.Enabled = true;
            }
            else
            {
                FrmMain.Default.BookInformationToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llBookInformation.Enabled = false;
            }
            // -------ACTION-CODE- 503
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 503)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.BookListToolStripMenuItem.Enabled = true;
                FrmMain.Default.BookListToolStripMenuItem1.Enabled = true;
                //FrmMain.Default.llBookList.Enabled = true;
            }
            else
            {
                FrmMain.Default.BookListToolStripMenuItem.Enabled = false;
                FrmMain.Default.BookListToolStripMenuItem1.Enabled = false;
                //FrmMain.Default.llBookList.Enabled = false;
            }
            // -------ACTION-CODE- 504
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 504)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.BookIssueToolStripMenuItem.Enabled = true;
                FrmMain.Default.BookIssueToolStripMenuItem1.Enabled = true;
                //FrmMain.Default.llBookIssue.Enabled = true;
            }
            else
            {
                FrmMain.Default.BookIssueToolStripMenuItem.Enabled = false;
                FrmMain.Default.BookIssueToolStripMenuItem1.Enabled = false;
                //FrmMain.Default.llBookIssue.Enabled = false;
            }
            // -------ACTION-CODE- 505
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 505)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.BookReturnToolStripMenuItem.Enabled = true;
                //FrmMain.Default.BookReturnToolStripMenuItem1.Enabled = true;
                //FrmMain.Default.llBookReturn.Enabled = true;
            }
            else
            {
                FrmMain.Default.BookReturnToolStripMenuItem.Enabled = false;
                //FrmMain.Default.BookReturnToolStripMenuItem1.Enabled = false;
                //FrmMain.Default.llBookReturn.Enabled = false;
            }

            // -------ACTION-CODE- 506
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 506)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.BarcodePrintToolStripMenuItem.Enabled = true;
                FrmMain.Default.BarcodePrintToolStripMenuItem1.Enabled = true;
                //FrmMain.Default.llBarcodePrint.Enabled = true;
            }
            else
            {
                FrmMain.Default.BarcodePrintToolStripMenuItem.Enabled = false;
                FrmMain.Default.BarcodePrintToolStripMenuItem1.Enabled = false;
                //FrmMain.Default.llBarcodePrint.Enabled = false;
            }

            // Accounts
            //ProgressBar1.Value = ProgressBar1.Value + 10;

            // -------ACTION-CODE- 601
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 601)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.OptionsToolStripMenuItem.Enabled = true;
                FrmMain.Default.ListOfAccountToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llChartOfAccounts.Enabled = true;
            }
            else
            {
                FrmMain.Default.OptionsToolStripMenuItem.Enabled = false;
                FrmMain.Default.ListOfAccountToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llChartOfAccounts.Enabled = false;
            }
            // -------ACTION-CODE- 602
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 602)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.VoucherEntryToolStripMenuItem.Enabled = true;
                FrmMain.Default.DailyTransactionToolStripMenuItem.Enabled = true;
                FrmMain.Default.AccountLedgerToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llVoucherEntry.Enabled = true; 
            }
            else
            {
                FrmMain.Default.VoucherEntryToolStripMenuItem.Enabled = false;
                FrmMain.Default.DailyTransactionToolStripMenuItem.Enabled = false;
                FrmMain.Default.AccountLedgerToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llVoucherEntry.Enabled = false; 
            }
            // -------ACTION-CODE- 603
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 603)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.VoucherListToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llVoucherList.Enabled = true;
            }
            else
            {
                FrmMain.Default.VoucherListToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llVoucherList.Enabled = false;
            }
            // -------ACTION-CODE- 604
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 604)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.VoucherApprovalToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llVoucherApproval.Enabled = true;
            }
            else
            {
                FrmMain.Default.VoucherApprovalToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llVoucherApproval.Enabled = false;
            }
            // -------ACTION-CODE- 605
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 605)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.VoucherCancelToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llVoucherCancel.Enabled = true;
            }
            else
            {
                FrmMain.Default.VoucherCancelToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llVoucherCancel.Enabled = false;
            }

            // SMS
            //ProgressBar1.Value = ProgressBar1.Value + 10;

            // -------ACTION-CODE- 701
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 701)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SettingsToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.SettingsToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 702
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 702)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.DraftsToolStripMenuItem.Enabled = true;
            }
            else
            {
                FrmMain.Default.DraftsToolStripMenuItem.Enabled = false;
            }
            // -------ACTION-CODE- 703
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 703)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.NewSMSToolStripMenuItem.Enabled = true;
                FrmMain.Default.SMSDeliveryReportToolStripMenuItem.Enabled = true; 
            }
            else
            {
                FrmMain.Default.NewSMSToolStripMenuItem.Enabled = false;
                FrmMain.Default.SMSDeliveryReportToolStripMenuItem.Enabled = false; 
            }


            // Email
            //ProgressBar1.Value = ProgressBar1.Value + 10;
            // -------ACTION-CODE- 801
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 801)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.SettingsToolStripMenuItem1.Enabled = true;
            }
            else
            {
                FrmMain.Default.SettingsToolStripMenuItem1.Enabled = false;
            }
            // -------ACTION-CODE- 702
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 802)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.EmailSentToolStripMenuItem.Enabled = true;
                FrmMain.Default.EMAILDeliveryReportToolStripMenuItem.Enabled = true; 
            }
            else
            {
                FrmMain.Default.EmailSentToolStripMenuItem.Enabled = false;
                FrmMain.Default.EMAILDeliveryReportToolStripMenuItem.Enabled = false; 
            }


            // Administration
            //ProgressBar1.Value = ProgressBar1.Value + 10;
            // -------ACTION-CODE- 901
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 901)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                //FrmMain.Default.ToolStripButtonUser.Enabled = true;
                FrmMain.Default.UserRegistrationToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llUserRegistration.Enabled = true; 
            }
            else
            {
                //FrmMain.Default.ToolStripButtonUser.Enabled = false;
                FrmMain.Default.UserRegistrationToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llUserRegistration.Enabled = false; 
            }
            // -------ACTION-CODE- 902
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 902)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.PermissionToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llPermission.Enabled = true;
            }
            else
            {
                FrmMain.Default.PermissionToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llPermission.Enabled = false;
            }
            // -------ACTION-CODE- 903
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 903)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.UserLogToolStripMenuItem.Enabled = true;
                FrmMain.Default.UserLogToolStripMenuItem1.Enabled = true;
                //FrmMain.Default.llUserLog.Enabled = true;
            }
            else
            {
                FrmMain.Default.UserLogToolStripMenuItem.Enabled = false;
                FrmMain.Default.UserLogToolStripMenuItem1.Enabled = false;
                //FrmMain.Default.llUserLog.Enabled = false;
            }
            // -------ACTION-CODE- 904
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + ConnectionNode.xUser_ID + ") AND (AccessKey = 904)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                FrmMain.Default.ChangePasswordToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llChangePassword.Enabled = true;
            }
            else
            {
                FrmMain.Default.ChangePasswordToolStripMenuItem.Enabled = false;
                //FrmMain.Default.llChangePassword.Enabled = false;
            }

        }
        #endregion
    }
}