using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            try
            {
                Image myimage = new Bitmap(@"D:\olax\BLG_Image.jpg");
                this.BackgroundImage = myimage;
            }
            catch { }
        }

        private void paymentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLPaymentSettingsFRM locObject = new BLPaymentSettingsFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void monthlySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLMonthlySettingsFRM locObject = new BLMonthlySettingsFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLSupplierFRM locObject = new BLSupplierFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }


        private void transportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLTransportCostFRM locObject = new BLTransportCostFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLBankFRM locObject = new BLBankFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void bankBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLBankBranchFRM locObject = new BLBankBranchFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void routeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLRouteFRM locObject = new BLRouteFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void townToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLTownFRM locObject = new BLTownFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void greenLeafCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GreenLeafCollectionTRNFRM locObject = new GreenLeafCollectionTRNFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void otherPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherAdditionTRNFRM locObject = new OtherAdditionTRNFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void deductionCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLDeductionCodeFRM locObject = new BLDeductionCodeFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void deductionGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLDeductionGroupFRM locObject = new BLDeductionGroupFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeductionsTRNFRM locObject = new DeductionsTRNFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfileFRM locObject = new UserProfileFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordFRM locObject = new ChangePasswordFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void monthlyProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthProcessFRM locObject = new MonthProcessFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void reverseMonthlyProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyProcessCancelFRM locObject = new MonthlyProcessCancelFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void greenLeafSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GreenLeafSummaryRPTFRM locObject = new GreenLeafSummaryRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void fertilizerIssuesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FertilizerIssueRegisterRPTFRM locObject = new FertilizerIssueRegisterRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void supplierRegisteryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataSet dataSetReport = new DataSet();
            //BoughtLeafBusinessLayer.BLSupplier myAccount = new BoughtLeafBusinessLayer.BLSupplier();
            //dataSetReport = myAccount.viewSupplierList();
            //dataSetReport.WriteXml("SupplierList.xml");
            //SuppliersRPT myaclist = new SuppliersRPT();
            //myaclist.SetDataSource(dataSetReport);
            //ReportViewer myReportViewer = new ReportViewer();
            //myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            //myReportViewer.crystalReportViewer1.ReportSource = myaclist;
            //myReportViewer.Show();

            Supplier_Reg sup = new Supplier_Reg();
            sup.MdiParent = this;
            sup.Show();
        }

        private void bankWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyBankWiseRPTFRM locObject = new MonthlyBankWiseRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void transportCodeWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransportCodeRPTFRM locObject = new TransportCodeRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void insentiveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncentiveRPTFRM locObject = new IncentiveRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void monthlyRouteWiseSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyRouteWiseSupplierRPTFRM locObject = new MonthlyRouteWiseSupplierRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void bankSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyBankSummaryRPTFRM locObject = new MonthlyBankSummaryRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void chequePaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChequePaySummaryRPTFRM locObject = new ChequePaySummaryRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void advanceOutstadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvanceOutStandingRPTFRM locObject = new AdvanceOutStandingRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void monthlyPaySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierPaymentRPTFRM locObject = new SupplierPaymentRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void paymentSlipReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentSlipRPTFRM locObject = new PaymentSlipRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void incentiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncentivesTRNFRM locObject = new IncentivesTRNFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void monthyDeductionSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyDeductionSummaryRPTFRM locObject = new MonthlyDeductionSummaryRPTFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void collectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLCollectorFRM locObject = new BLCollectorFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }



        private void greenLeafCollectionApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GreenLeafCollectionApprovalFRM locObject = new GreenLeafCollectionApprovalFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void deductionsApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeductionApprovalFRM locObject = new DeductionApprovalFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void otherPaymentsApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherAdditionApprovalFRM locObject = new OtherAdditionApprovalFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void incentivesApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncentivesApprovalFRM locObject = new IncentivesApprovalFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void incentiveLevelsSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncentiveLevelsSettingFRM locObject = new IncentiveLevelsSettingFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void sMSSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SMSSendSettingFRM locObject = new SMSSendSettingFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (BoughtLeafBusinessLayer.BLUser.getCompanyCode().ToUpper().Equals("APL"))
                {
                    //this.BackgroundImage = Image.FromFile(Path + @"\ChkRol_BgUi_BPL.jpg");
                    this.BackgroundImage = Properties.Resources.BghtLf_BgUi_APL;
                    //this.BackgroundImage = Properties.Resources.ChkRl_BgUi_MPL;
                }
                else if (BoughtLeafBusinessLayer.BLUser.getCompanyCode().ToUpper().Equals("BPL"))
                {
                    //this.BackgroundImage = Image.FromFile(Path + @"\ChkRol_BgUi_BPL.jpg");
                    this.BackgroundImage = Properties.Resources.Balangoda_bg_boughtLef;
                    //this.BackgroundImage = Properties.Resources.ChkRl_BgUi_MPL;
                }
                else if (BoughtLeafBusinessLayer.BLUser.getCompanyCode().ToUpper().Equals("KTFL"))
                {
                    //this.BackgroundImage = Image.FromFile(Path + @"\ChkRol_BgUi_BPL.jpg");
                    this.BackgroundImage = Properties.Resources.BghtLf_BgUi_KTFL;
                    //this.BackgroundImage = Properties.Resources.ChkRl_BgUi_MPL;
                }
                //else if (BoughtLeafBusinessLayer.BLUser.getCompanyCode().ToUpper().Equals("TSFL"))
                //{
                //    //this.BackgroundImage = Image.FromFile(Path + @"\ChkRol_BgUi_BPL.jpg");
                //    this.BackgroundImage = Properties.Resources.BghtLf_BgUi_KTFL;
                //    //this.BackgroundImage = Properties.Resources.ChkRl_BgUi_MPL;
                //}
                Image myimage = new Bitmap(@"D:\olax\BLG_Image.jpg");
                this.BackgroundImage = myimage;
            }
            catch { }
            //OlaxToolsSet.SystemInformation SI = new OlaxToolsSet.SystemInformation();
            //SI.dbServer = @"ISURU-DELL\SQL2014";
            //SI.dbUserId = "sa";
            //SI.dbPassWord = "pass1234";
            //SI.module = "Bought Leaf";
            //SI.latestVersion = "1.0.0.0";

            ////OlaxToolsSet.VersionUpdateManage.updateSystem(SI);
            ////OlaxToolsSet.VersionUpdateManage.validateVersion(SI);
            //this.Text = OlaxToolsSet.VersionUpdateManage.getCurrentVersion(SI);



        }

        private void mnuPaymentToBank_Click(object sender, EventArgs e)
        {
            //rptSupplierPaymentToBank supToBank = new rptSupplierPaymentToBank();
            //supToBank.MdiParent = this;
            //supToBank.Show();
        }

        private void coinsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void coinsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pre_Month_DebtsCoinsEntry pre = new Pre_Month_DebtsCoinsEntry();
            pre.MdiParent = this;
            pre.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CashPaymentListFRM locObject = new CashPaymentListFRM();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void coinAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Coin_Analysis locObject = new Coin_Analysis();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void supplierGreenLeafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier_Green_Leaf_Amount locObject = new Supplier_Green_Leaf_Amount();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void incentiveSlabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSlabIncentive objSlabInce = new FrmSlabIncentive();
            objSlabInce.MdiParent = this;
            objSlabInce.Show();
        }

        private void ggggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GreenLeafSummaryReport locObject = new GreenLeafSummaryReport();
            locObject.MdiParent = this;
            locObject.Show();
        }

        private void MIGLRegisterDetail_Click(object sender, EventArgs e)
        {
            DailyAnalysisReport objDA = new DailyAnalysisReport();
            objDA.MdiParent = this;
            objDA.Show();
        }

        private void msMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void configureAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLJournalAccountConfiguration objACConfigure = new BLJournalAccountConfiguration();
            objACConfigure.MdiParent = this;
            objACConfigure.Show();
        }

        private void adavancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedBooking advancedBook = new AdvancedBooking();
            advancedBook.MdiParent = this;
            advancedBook.Show();
        }

        private void adToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedBookingRate advBookRate = new AdvancedBookingRate();
            advBookRate.MdiParent = this;
            advBookRate.Show();
        }
    }
}