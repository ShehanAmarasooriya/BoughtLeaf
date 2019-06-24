using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class DailyAnalysisReport : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();
        BoughtLeafBusinessLayer.BLMonthlySettings mySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.GreenLeaf objGL = new BoughtLeafBusinessLayer.GreenLeaf();

        public DailyAnalysisReport()
        {
            InitializeComponent();
        }

        private void DailyAnalysisReport_Load(object sender, EventArgs e)
        {
            cmbSupplier.DataSource = mySupplier.ListActiveSuppliers();
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierCode";
            cmbSupplier.Enabled = false;

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void btnGreenLeafReg_Click(object sender, EventArgs e)
        {
            String strSupplierSelection = "%";
            String strRouteSelection = "%";
            if (!chkRoute.Checked)
                strRouteSelection = cmbRoute.SelectedValue.ToString();
            if (!chkSupplier.Checked)
                strSupplierSelection = cmbSupplier.SelectedValue.ToString();
            DataSet dataSetReport = objGL.ListGreenLeafRegister(Convert.ToDateTime(dtpFrom.Value.Date.ToShortDateString()), Convert.ToDateTime(dtpTo.Value.Date.ToShortDateString()), strRouteSelection, strSupplierSelection);
            dataSetReport.WriteXml("DailyGreenLeafReg.xml");
            DailyGreenLeafRegisterRPT myReport = new DailyGreenLeafRegisterRPT();
            myReport.SetDataSource(dataSetReport);
            ReportViewer rptViewer = new ReportViewer();

            myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReport.SetParameterValue("From", dtpFrom.Value.Date.ToShortDateString());
            myReport.SetParameterValue("To", dtpTo.Value.Date.ToShortDateString());

            if (chkRoute.Checked == true)
                myReport.SetParameterValue("Route", "All Routes");
            else
                myReport.SetParameterValue("Route", cmbRoute.Text);

            rptViewer.crystalReportViewer1.ReportSource = myReport;
            rptViewer.Show();


        }

        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplier.Checked)
            {
                cmbSupplier.Enabled = false;
            }
            else
            {
                cmbSupplier.Enabled = true;
            }
        }
    }
}