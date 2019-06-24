using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class MonthlyDeductionSummaryRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();
        BoughtLeafBusinessLayer.BLDeductionGroup DeductGroupMaster = new BoughtLeafBusinessLayer.BLDeductionGroup();
        BoughtLeafBusinessLayer.BLDeductionCode DeductMaster = new BoughtLeafBusinessLayer.BLDeductionCode();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLRegisters objReg = new BoughtLeafBusinessLayer.BLRegisters();
        BoughtLeafBusinessLayer.Reports objRpt = new BoughtLeafBusinessLayer.Reports();

        public MonthlyDeductionSummaryRPTFRM()
        {
            InitializeComponent();
        }

        private void MonthlyDeductionSummaryRPTFRM_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);


            cmbSupplier.DataSource = mySupplier.ListActiveSuppliers();
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierCode";
          

            cmbDeductionGroup.SelectedIndexChanged -= new EventHandler(cmbDeductionGroup_SelectedIndexChanged);
            cmbDeductionGroup.DataSource = DeductGroupMaster.LoadComboboxGroupCode();
            cmbDeductionGroup.DisplayMember = "GroupName";
            cmbDeductionGroup.ValueMember = "GroupCode";
            cmbDeductionGroup.SelectedIndexChanged += new EventHandler(cmbDeductionGroup_SelectedIndexChanged);

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";

            cmbSupplier.Enabled = false;
            cmbDeductionGroup.Enabled = false;
            cmbDeductionCode.Enabled = false;
            cmbRoute.Enabled = false;

            cmbDeductionGroup_SelectedIndexChanged(null, null);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string supCode = cmbSupplier.SelectedValue.ToString();
            if (chkSupplier.Checked)
                supCode = "%";

            DataSet dataSet = myMonthlySummary.getMonthlyDeductionSummary(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), supCode);

            dataSet.WriteXml("MonthlyDeductionSummary.xml");
            MonthlyDeductionSummaryRPT myReport = new MonthlyDeductionSummaryRPT();
            myReport.SetDataSource(dataSet);

            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());

            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        
        }

        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplier.Checked)
                cmbSupplier.Enabled = false;
            else
                cmbSupplier.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            string supCode = cmbSupplier.SelectedValue.ToString();
            if (chkSupplier.Checked)
                supCode = "%";

            String strAllDeductions = "%";
            if (!chkDeduction.Checked)
                strAllDeductions = cmbDeductionCode.SelectedValue.ToString();

            DataSet dataSet = myMonthlySummary.getMonthlyDeductionSummaryDeductionCodewise(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), supCode, strAllDeductions);

            dataSet.WriteXml("MonthlyDeductionSummaryDC.xml");
            MonthlyDeductionSummaryDCRPT myReport = new MonthlyDeductionSummaryDCRPT();
            myReport.SetDataSource(dataSet);

            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());

            if (chkDeduction.Checked == true)
                myReport.SetParameterValue("Deduction", "All Deduction");
            else
                myReport.SetParameterValue("Deduction", cmbDeductionCode.Text);

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Route");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void cmbDeductionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            cmbDeductionCode.DataSource = DeductMaster.ViewAllDeductionByGroup(cmbDeductionGroup.SelectedValue.ToString());
            cmbDeductionCode.DisplayMember = "DeductionName";
            cmbDeductionCode.ValueMember = "DeductionCode";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strAllRoute = "%";
            if (!chkRoute.Checked)
                strAllRoute = cmbRoute.SelectedValue.ToString();

            string supCode = cmbSupplier.SelectedValue.ToString();
            if (chkSupplier.Checked)
                supCode = "%";

            String strAllDeductions = "%";
            if (!chkDeduction.Checked)
                strAllDeductions = cmbDeductionCode.SelectedValue.ToString();

            DataSet dataSet = myMonthlySummary.getMonthlyDeductionSummaryRoutewise(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), supCode, strAllDeductions, strAllRoute);

            dataSet.WriteXml("MonthlyDeductionSummaryDC.xml");
            MonthlyDeductionSummaryRWRPT myReport = new MonthlyDeductionSummaryRWRPT();
            myReport.SetDataSource(dataSet);

            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Route");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void chkDeduction_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeduction.Checked)
            {
                
                cmbDeductionCode.Enabled = false;
            }
            else
            {
                
                cmbDeductionCode.Enabled = true;
            }

            
        }

        private void chkRoute_CheckedChanged(object sender, EventArgs e)
        {

            if (chkRoute.Checked)
                cmbRoute.Enabled = false;
            else
                cmbRoute.Enabled = true;
        }

        private void btnDeductionRegister_Click(object sender, EventArgs e)
        {
            string supCode = cmbSupplier.SelectedValue.ToString();
            if (chkSupplier.Checked)
                supCode = "%";

            String strAllDeductionsGroup = "%";
            if (!chkAllGroup.Checked)
                strAllDeductionsGroup = cmbDeductionGroup.SelectedValue.ToString();

            String strAllDeductions = "%";
            if (!chkDeduction.Checked)
                strAllDeductions = cmbDeductionCode.SelectedValue.ToString();

            String route = "%";
            if (!chkRoute.Checked)
                route = cmbRoute.SelectedValue.ToString();

            DataSet dataSet = objReg.getMonthlyDeductionSummaryDeductionCodewise(route,Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), supCode, strAllDeductions,strAllDeductionsGroup);

            dataSet.WriteXml("MonthDeductionRegister.xml");
            MonthDeductionRegisterRPT myReport = new MonthDeductionRegisterRPT();
            myReport.SetDataSource(dataSet);

            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());

            if (chkDeduction.Checked == true)
                myReport.SetParameterValue("Deduction", "All Deduction");
            else
                myReport.SetParameterValue("Deduction", cmbDeductionCode.Text);

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Route");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void btnDeductRegWithLeaf_Click(object sender, EventArgs e)
        {
            string supCode = cmbSupplier.SelectedValue.ToString();
            if (chkSupplier.Checked)
                supCode = "%";

            String strAllDeductionsGroup = "%";
            if (!chkAllGroup.Checked)
                strAllDeductionsGroup = cmbDeductionGroup.SelectedValue.ToString();

            String strAllDeductions = "%";
            if (!chkDeduction.Checked)
                strAllDeductions = cmbDeductionCode.SelectedValue.ToString();

            String route = "%";
            if (!chkRoute.Checked)
                route = cmbRoute.SelectedValue.ToString();

            DataSet dataSet = objReg.getMonthlyDeductionRegisterWithLeafTodate(route, Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), supCode, strAllDeductions,strAllDeductionsGroup);

            dataSet.WriteXml("MonthDeductionRegister.xml");
            MonthDeductionRegisterWithTodateGLRPT myReport = new MonthDeductionRegisterWithTodateGLRPT();
            myReport.SetDataSource(dataSet);

            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());

            if (chkDeduction.Checked == true)
                myReport.SetParameterValue("Deduction", "All Deduction");
            else
                myReport.SetParameterValue("Deduction", cmbDeductionCode.Text);

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Route");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string supCode = cmbSupplier.SelectedValue.ToString();
            if (chkSupplier.Checked)
                supCode = "%";

            String strAllDeductions = "%";
            if (!chkDeduction.Checked)
                strAllDeductions = cmbDeductionCode.SelectedValue.ToString();

            String strAllDeductionsGroup = "%";
            if (!chkAllGroup.Checked)
                strAllDeductionsGroup = cmbDeductionGroup.SelectedValue.ToString();

            String route = "%";
            if (!chkRoute.Checked)
                route = cmbRoute.SelectedValue.ToString();

            DataSet dataSet = objRpt.GetDeductionDetailReport( Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue),route, supCode,strAllDeductionsGroup,strAllDeductions);

            dataSet.WriteXml("SuppliyerMonthDeductions.xml");
            SupplierWiseMonthDeductionRPT myReport = new SupplierWiseMonthDeductionRPT();
            myReport.SetDataSource(dataSet);

            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());

            if (chkDeduction.Checked == true)
                myReport.SetParameterValue("Deduction", "All Deduction");
            else
                myReport.SetParameterValue("Deduction", cmbDeductionCode.Text);

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Route");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

        private void chkAllGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllGroup.Checked)
            {
                cmbDeductionGroup.Enabled = false;
                
            }
            else
            {
                cmbDeductionGroup.Enabled = true;
                
            }
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

        private void btnDepositFund_Click(object sender, EventArgs e)
        {
            string supCode = cmbSupplier.SelectedValue.ToString();
            if (chkSupplier.Checked)
                supCode = "%";

            String strAllDeductions = "%";
            if (!chkDeduction.Checked)
                strAllDeductions = cmbDeductionCode.SelectedValue.ToString();

            DataSet dataSet = myMonthlySummary.getMonthlyDepositFundContribution(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), supCode);

            dataSet.WriteXml("MonthlyDepositFundContribution.xml");
            MonthlyDepositFundContributionRPT myReport = new MonthlyDepositFundContributionRPT();
            myReport.SetDataSource(dataSet);

            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());

            if (chkDeduction.Checked == true)
                myReport.SetParameterValue("Deduction", "All Deduction");
            else
                myReport.SetParameterValue("Deduction", cmbDeductionCode.Text);

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Route");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();
        }

       
    }
}