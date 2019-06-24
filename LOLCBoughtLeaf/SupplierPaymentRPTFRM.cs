using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class SupplierPaymentRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();
        BoughtLeafBusinessLayer.BLMonthlySettings mySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();

        public SupplierPaymentRPTFRM()
        {
            InitializeComponent();
        }

        //Start Sachintha edited code 2016.10.12
        private void btnPaySmryDetail_Click(object sender, EventArgs e)
        {
            string strRoute = "%";
            if (chkRoute.Checked)
                strRoute = "%";
            else
                strRoute = cmbRoute.SelectedValue.ToString();
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "SupplierPaymentsSummaryDetail";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();

            string supCode = string.Empty;
            if (chkSupplier.Checked == true)
                supCode = "%";
            else
                supCode = cmbSupplier.SelectedValue.ToString();

            dataSetReport = myMonthlySummary.getSupplierPaymentsDetail(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), supCode,strRoute).Tables[0];
            dataSetReport.WriteXml("SupplierPaymentsSummaryDetail.xml");
            SupplierPaymentSummaryDetailRPT2 myReport = new SupplierPaymentSummaryDetailRPT2();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("PayRate", mySettings.getKiloRate(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())).ToString("N2"));
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Routes");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void btnPaySmry_Click(object sender, EventArgs e)
        {
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "SupplierPaymentsSummary";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();

            string supCode = string.Empty;
            if (chkSupplier.Checked == true)
                supCode = "%";
            else
                supCode = cmbSupplier.SelectedValue.ToString();

            string strRoute = "%";
            if (chkRoute.Checked)
                strRoute = "%";
            else
                strRoute = cmbRoute.SelectedValue.ToString();

            dataSetReport = myMonthlySummary.getSupplierPaymentsDetail(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), supCode,strRoute).Tables[0];
            dataSetReport.WriteXml("SupplierPaymentsSummary.xml");
            SupplierPaymentSummaryRPT myReport = new SupplierPaymentSummaryRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());
            myReport.SetParameterValue("payRate", mySettings.getKiloRate(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue)));
            myReport.SetParameterValue("CheckTotal", myBank.getCheckPaymentTotal(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())));
            myReport.SetParameterValue("BankTotal", myMonthlySummary.getBankPaymentSummaryTotal(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())));
            myReport.SetParameterValue("CashTotal", myMonthlySummary.getCashPaymentSummaryTotal(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())));
            
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void btnPaySmryRoute_Click(object sender, EventArgs e)
        {
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "SupplierPaymentsSummaryTown";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();

            dataSetReport = myMonthlySummary.getSupplierPaymentsDetailByRoute(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())).Tables[0];

            dataSetReport.WriteXml("SupplierPaymentsSummaryTown.xml");
            SupplierPaymentSummaryRouteRPT myReport = new SupplierPaymentSummaryRouteRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("PayRate", mySettings.getKiloRate(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())).ToString("N2"));
            myReport.SetParameterValue("CheckTotal", myBank.getCheckPaymentTotal(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())));
            myReport.SetParameterValue("BankTotal", myMonthlySummary.getBankPaymentSummaryTotal(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())));
            myReport.SetParameterValue("CashTotal", myMonthlySummary.getCashPaymentSummaryTotal(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())));
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("SupCount", myMonthlySummary.getMonthlyActiveSupplier(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())));
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());
            rptViewer.crystalReportViewer1.ReportSource = myReport;

            rptViewer.Show();
        }

        private void btnLMDebt_Click(object sender, EventArgs e)
        {
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "PreviousMonthSummary";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();

            dataSetReport = myMonthlySummary.getPreviousMonthDebts(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())).Tables[0];

            dataSetReport.WriteXml("PreviousMonthSummary.xml");
            PreviousMonthDebtSummaryRPT myReport = new PreviousMonthDebtSummaryRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());

            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void btnNMDebt_Click(object sender, EventArgs e)
        {
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "NextMonthSummary";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();

            dataSetReport = myMonthlySummary.getNextMonthDebts(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())).Tables[0];

            dataSetReport.WriteXml("NextMonthSummary.xml");
            NextMonthDebtSummaryRPT myReport = new NextMonthDebtSummaryRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());

            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // end Sachintha Edited Code

        private void SupplierPaymentRegister_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);

            

            cmbSupplier.DataSource = mySupplier.ListActiveSuppliers();
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierCode";
            cmbSupplier.Enabled = false;

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplier.Checked)
                cmbSupplier.Enabled = false;
            else
                cmbSupplier.Enabled = true;
        }

        private void btnIncentiveSummary_Click(object sender, EventArgs e)
        {
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "SupplierIncentiveDetails";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();
            string supRoute = "%";
            if (!chkRoute.Checked)
                supRoute = cmbRoute.SelectedValue.ToString();
            string supCode = string.Empty;
            if (chkSupplier.Checked == true)
                supCode = "%";
            else
                supCode = cmbSupplier.SelectedValue.ToString();

            dataSetReport = myMonthlySummary.getSupplierIncentiveDetail(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), supCode,supRoute).Tables[0];
            dataSetReport.WriteXml("SupplierIncentiveDetails.xml");
            SupplierIncentiveDetailsRPT myReport = new SupplierIncentiveDetailsRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());
            myReport.SetParameterValue("payRate", mySettings.getKiloRate(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue)));
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void chkRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRoute.Checked)
                cmbRoute.Enabled = false;
            else
                cmbRoute.Enabled = true;
        }

        private void btnSkippedDeductions_Click(object sender, EventArgs e)
        {
            string strRoute = "%";
            if (chkRoute.Checked)
                strRoute = "%";
            else
                strRoute = cmbRoute.SelectedValue.ToString();
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "SkippedDeductionsDetails";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();

            string supCode = string.Empty;
            if (chkSupplier.Checked == true)
                supCode = "%";
            else
                supCode = cmbSupplier.SelectedValue.ToString();

            dataSetReport = myMonthlySummary.getSkippedDeductions(strRoute,Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString())).Tables[0];
            dataSetReport.WriteXml("SkippedDeductionsDetails.xml");
            SkippedDeductionsRPT myReport = new SkippedDeductionsRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Routes");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strRoute = "%";
            if (chkRoute.Checked)
                strRoute = "%";
            else
                strRoute = cmbRoute.SelectedValue.ToString();
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "SupplierPaymentsSummaryDetail";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();

            string supCode = string.Empty;
            if (chkSupplier.Checked == true)
                supCode = "%";
            else
                supCode = cmbSupplier.SelectedValue.ToString();

            dataSetReport = myMonthlySummary.getSupplierPaymentsDeductionDetail(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), supCode, strRoute).Tables[0];
            dataSetReport.WriteXml("SupplierPaymentsDeductionDetail.xml");
            SupplierPaymentsDeductionDetailRPT myReport = new SupplierPaymentsDeductionDetailRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Routes");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void btnCollectorPayment_Click(object sender, EventArgs e)
        {
            DataTable dataSetReport = new DataTable();
            dataSetReport.TableName = "SupplierIncentiveDetails";

            BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();
            string supRoute = "%";
            if (!chkRoute.Checked)
                supRoute = cmbRoute.SelectedValue.ToString();
            string supCode = string.Empty;
            if (chkSupplier.Checked == true)
                supCode = "%";
            else
                supCode = cmbSupplier.SelectedValue.ToString();

            dataSetReport = myMonthlySummary.ListCollectorPayment(Convert.ToInt32(cmbYear.Text),Convert.ToInt32(cmbMonth.SelectedValue.ToString()), "%").Tables[0];
            dataSetReport.TableName = "CollectorPayment";
            dataSetReport.WriteXml("CollecotrPaymentDetails.xml");
            CollectorPaymentDetailsRPT myReport = new CollectorPaymentDetailsRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.SelectedValue.ToString());
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMonth.DataSource = myYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
                cmbMonth.DisplayMember = "MonthName";
                cmbMonth.ValueMember = "MonthCode";

            }
            catch { }
        }
    }
}