using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class ChequePaySummaryRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLBank bank = new BoughtLeafBusinessLayer.BLBank();

        public ChequePaySummaryRPTFRM()
        {
            InitializeComponent();
        }

        private void checkPaySummary_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);

            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataSet oDataSet = new DataSet();
            oDataSet = bank.getCheckPaymentReport(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()));

            oDataSet.WriteXml("checkPayment.xml");
            ChequePaySummaryRPT myaclist = new ChequePaySummaryRPT();
            myaclist.SetDataSource(oDataSet);
            ReportViewer myReportViewer = new ReportViewer();
            myaclist.SetParameterValue("Year", cmbYear.Text);
            myaclist.SetParameterValue("Month", cmbMonth.Text);
            myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
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