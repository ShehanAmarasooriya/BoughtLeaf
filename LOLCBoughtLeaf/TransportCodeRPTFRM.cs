using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class TransportCodeRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLMonthlySettings mySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();

        public TransportCodeRPTFRM()
        {
            InitializeComponent();
        }

        private void TransportCodeRPTFRM_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataSet dataSetReport = new DataSet();
        
            BoughtLeafBusinessLayer.BLSupplier myAccount = new BoughtLeafBusinessLayer.BLSupplier();
            dataSetReport = myAccount.TransportCodeWiseSuppliers(Convert.ToInt32(cmbMonth.SelectedValue.ToString()), Convert.ToInt32(cmbYear.Text));

            dataSetReport.WriteXml("trnCode.xml");

            TransportCodeWiseRPT myaclist = new TransportCodeWiseRPT();
            myaclist.SetDataSource(dataSetReport);
            ReportViewer myReportViewer = new ReportViewer();
            myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myaclist.SetParameterValue("Month", cmbMonth.Text);
            myaclist.SetParameterValue("Year", cmbYear.Text);
            myReportViewer.crystalReportViewer1.ReportSource = myaclist;
            myReportViewer.Show();
        }

        private void WithoutCost_Click(object sender, EventArgs e)
        {
            DataSet dataSetReport = new DataSet();
        
            BoughtLeafBusinessLayer.BLSupplier myAccount = new BoughtLeafBusinessLayer.BLSupplier();
            dataSetReport = myAccount.TransportCodeWiseSuppliersWithouCost(Convert.ToInt32(cmbMonth.SelectedValue.ToString()), Convert.ToInt32(cmbYear.Text));

            dataSetReport.WriteXml("trnCodeWithout.xml");

            TransportCodeWiseWithoutCostRPT myaclist = new TransportCodeWiseWithoutCostRPT();
            myaclist.SetDataSource(dataSetReport);
            ReportViewer myReportViewer = new ReportViewer();
            myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myaclist.SetParameterValue("Month", cmbMonth.Text);
            myaclist.SetParameterValue("Year", cmbYear.Text);
            myReportViewer.crystalReportViewer1.ReportSource = myaclist;
            myReportViewer.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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