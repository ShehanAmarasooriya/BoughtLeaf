using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class AdvanceOutStandingRPTFRM : Form
    {
        public AdvanceOutStandingRPTFRM()
        {
            InitializeComponent();
        }
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.ReportHelper rptHelp = new BoughtLeafBusinessLayer.ReportHelper();
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();

        private void advanceReport_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbMonth.DataSource = myYear.ListAllMonths();
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";
            cmbMonth.Text = DateTime.Now.Month.ToString();

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string route = cmbRoute.Text;

            DataSet ds = rptHelp.getAdvancePayment(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue), route);

            ds.WriteXml("AdvanceOutStandValues.xml");

            string CompanyName = rptHelp.getCompanyName();
            string factory = rptHelp.getFactoryName();

            ReportViewer viewerRPT = new ReportViewer();
            AdvanceOutStandingRPT myReport = new AdvanceOutStandingRPT();
            myReport.SetDataSource(ds);
          
            myReport.SetParameterValue("Company", CompanyName);
            myReport.SetParameterValue("Year", cmbYear.Text);
            myReport.SetParameterValue("Month", cmbMonth.Text);

            viewerRPT.crystalReportViewer1.ReportSource = myReport;
            viewerRPT.crystalReportViewer1.DisplayGroupTree = true;
            viewerRPT.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
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