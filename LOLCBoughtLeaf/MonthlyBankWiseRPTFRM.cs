using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class MonthlyBankWiseRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();


        public MonthlyBankWiseRPTFRM()
        {
            InitializeComponent();
        }

        private void BankwiseReport_Load(object sender, EventArgs e)
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
            try
            {
                DataSet ds = new DataSet();
                
                if (allCheck.Checked)
                {
                    ds = myBank.getBankwiseReport(Convert.ToInt32(cmbYear.Text),Convert.ToInt32( cmbMonth.SelectedValue.ToString()));
                    ds.WriteXml("allBank.xml");
                    string Allroute = "ALL";
                    MonthlyBankWiseRPT oBankwiseRepoort = new MonthlyBankWiseRPT();
                    oBankwiseRepoort.SetDataSource(ds);
                    oBankwiseRepoort.SetParameterValue("Route", Allroute);
                    oBankwiseRepoort.SetParameterValue("Month", cmbMonth.Text);
                    oBankwiseRepoort.SetParameterValue("Year", cmbYear.Text);
                    oBankwiseRepoort.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                    ReportViewer oReportViewer = new ReportViewer();
                    oReportViewer.crystalReportViewer1.ReportSource = oBankwiseRepoort;
                    oReportViewer.Show();
                }
                else 
                {
                    ds = myBank.getBankwiseReportRouteWise(Convert.ToInt32(cmbYear.Text),Convert.ToInt32( cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                    ds.WriteXml("allBank.xml");
                    MonthlyBankWiseRPT oBankwiseRepoort = new MonthlyBankWiseRPT();
                    oBankwiseRepoort.SetDataSource(ds);
                    oBankwiseRepoort.SetParameterValue("Route", cmbRoute.Text);
                    oBankwiseRepoort.SetParameterValue("Month", cmbMonth.Text);
                    oBankwiseRepoort.SetParameterValue("Year", cmbYear.Text);
                    oBankwiseRepoort.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                    ReportViewer oReportViewer = new ReportViewer();
                    oReportViewer.crystalReportViewer1.ReportSource = oBankwiseRepoort;
                    oReportViewer.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
        }

        private void allCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (allCheck.Checked)
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