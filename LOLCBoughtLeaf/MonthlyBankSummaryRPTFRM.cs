using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class MonthlyBankSummaryRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();

        public MonthlyBankSummaryRPTFRM()
        {
            InitializeComponent();
        }

        private void BankSummary_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);
        }

        private void cmdDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSetReport = new DataSet();
                BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

                dataSetReport = myReports.getBankPaymentSummary(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()));

                dataSetReport.WriteXml("BankPayments.xml");
                MonthlyBankSummaryRPT myaclist = new MonthlyBankSummaryRPT();
                myaclist.SetDataSource(dataSetReport);
                ReportViewer myReportViewer = new ReportViewer();
                myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                myaclist.SetParameterValue("Period", "Period : " + cmbYear.Text + " / " + cmbMonth.Text);
                myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                myReportViewer.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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