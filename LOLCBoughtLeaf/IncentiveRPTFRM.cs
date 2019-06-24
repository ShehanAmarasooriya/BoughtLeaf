using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class IncentiveRPTFRM : Form
    {
        public IncentiveRPTFRM()
        {
            InitializeComponent();
        }
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();
        BoughtLeafBusinessLayer.BLMonthlySettings mySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.Incentives oIncentives = new BoughtLeafBusinessLayer.Incentives();



        private void IncentiveReport_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);

            

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void cmdDisplay_Click(object sender, EventArgs e)
        {
            DataSet oDataSet = new DataSet();

            if (allChk.Checked)
            {
                oDataSet = oIncentives.ListIncentiveRouteWise(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()));
                
            }
            else
            {
                oDataSet = oIncentives.ListIncentiveRouteWise( Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
            }

            oDataSet.WriteXml("incentive.xml");
            IncentiveRPT oincentiveReportPRT = new IncentiveRPT();
            
            oincentiveReportPRT.SetDataSource(oDataSet);
            ReportViewer oReportViewer = new ReportViewer();
            oincentiveReportPRT.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            oincentiveReportPRT.SetParameterValue("Month", cmbMonth.Text);
            oincentiveReportPRT.SetParameterValue("Year", cmbYear.Text);

            string rte = "ALL Route";
            if (allChk.Checked)
                oincentiveReportPRT.SetParameterValue("Route", rte);
            else
                oincentiveReportPRT.SetParameterValue("Route", cmbRoute.Text);
            
            oReportViewer.crystalReportViewer1.ReportSource = oincentiveReportPRT;
            oReportViewer.Show();
        }

        private void allChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allChk.Checked)
                cmbRoute.Enabled = false;
            else
                cmbRoute.Enabled = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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