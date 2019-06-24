using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class GreenLeafSummaryRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLSettings mySettings = new BoughtLeafBusinessLayer.BLSettings();
        int approvalStatus = 0;

        public GreenLeafSummaryRPTFRM()
        {
            InitializeComponent();
        }

        private void GreenLeafSummary_Load(object sender, EventArgs e)
        {

            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);


            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";

            cmbLeafType.DataSource = mySettings.ListBLMasterRates("LeafQuality");
            cmbLeafType.DisplayMember = "Name";
            cmbLeafType.ValueMember = "Amount";

            cmbMonth.SelectedValue = DateTime.Now.Month;

            cmbRoute.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSetReport = new DataSet();
                BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                String strAllRoute = "%";
                if (!chkRoute.Checked)
                    strAllRoute = cmbRoute.SelectedValue.ToString();

                String strAllLeafType = "%";
                if (!chkAllType.Checked)
                    strAllLeafType = cmbLeafType.Text;

                dataSetReport = myReports.getGreenLeafSummary(Convert.ToInt32(cmbYear.SelectedValue.ToString()), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), strAllRoute, strAllLeafType);
                

                dataSetReport.WriteXml("GreenLeafSummary.xml");
                GreenLeafSummarySUPRPT myaclist = new GreenLeafSummarySUPRPT();
                myaclist.SetDataSource(dataSetReport);
                ReportViewer myReportViewer = new ReportViewer();
                if (chkRoute.Checked == true)
                    myaclist.SetParameterValue("Route", "All Routes");
                else
                    myaclist.SetParameterValue("Route", cmbRoute.Text);

                myaclist.SetParameterValue("Year", cmbYear.Text);
                myaclist.SetParameterValue("Month", cmbMonth.Text);
                myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                myReportViewer.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSetReport = new DataSet();
                BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                String strAllRoute = "%";
                if (!chkRoute.Checked)
                    strAllRoute = cmbRoute.SelectedValue.ToString();
                String strAllLeafType = "%";
                if (!chkAllType.Checked)
                    strAllLeafType = cmbLeafType.Text;

                dataSetReport = myReports.getGreenLeafSummary(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()),strAllRoute,strAllLeafType);
                dataSetReport.WriteXml("GreenLeafSummary.xml");
                GreenLeafSummaryROUTERPT myaclist = new GreenLeafSummaryROUTERPT();
                myaclist.SetDataSource(dataSetReport);
                ReportViewer myReportViewer = new ReportViewer();
                myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                myaclist.SetParameterValue("Year", cmbYear.Text);
                myaclist.SetParameterValue("Month", cmbMonth.Text);

                if (chkRoute.Checked == true)
                    myaclist.SetParameterValue("Route", "All Routes");
                else
                    myaclist.SetParameterValue("Route", cmbRoute.Text);
                myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                myReportViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRoute.Checked)
                cmbRoute.Enabled = false;
            else
                cmbRoute.Enabled = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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