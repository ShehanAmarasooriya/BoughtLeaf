using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class MonthlyRouteWiseSupplierRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.Reports rpt = new BoughtLeafBusinessLayer.Reports();

        public MonthlyRouteWiseSupplierRPTFRM()
        {
            InitializeComponent();
        }

        private void RouteWiseMonthlySup_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataTable source = rpt.MonthlySupCountRouteWise(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue));
            source.WriteXml("MonthlyRouteWiseSup.xml");
            MonthlyRouteWiseSupRPT myReport = new MonthlyRouteWiseSupRPT();
            myReport.SetDataSource(source);
            myReport.SetParameterValue("Year", cmbYear.SelectedValue.ToString());
            myReport.SetParameterValue("Month", cmbMonth.Text);
            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();

        }

        private void button1_Click(object sender, EventArgs e)
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