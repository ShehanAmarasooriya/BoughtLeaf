using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BoughtLeafDataAccess;
using BoughtLeafBusinessLayer;

namespace OLAXBoughtLeaf
{
    public partial class CashPaymentListFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        

        public CashPaymentListFRM()
        {
            InitializeComponent();
        }
       
        private void cmdDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSetReport = new DataSet();

                if (allCheck.Checked)
                {                     
                    BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                    dataSetReport = myReports.getCashPaymentAllList(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()));
                    dataSetReport.WriteXml("CashPaymentAllList.xml");
                    CashPaymentAllListRPT myaclist = new CashPaymentAllListRPT();
                    myaclist.SetDataSource(dataSetReport);
                    ReportViewer myReportViewer = new ReportViewer();
                    myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                    myaclist.SetParameterValue("Period", "Period : " + cmbYear.Text + " / " + cmbMonth.Text);
                    myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                    myReportViewer.Show();

                }
                else
                {
                    BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                    dataSetReport = myReports.getCashPaymentList(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), (cmbRoute.SelectedValue.ToString()));
                    dataSetReport.WriteXml("CashPaymentAllList.xml");
                    CashPaymentAllListRPT myaclist = new CashPaymentAllListRPT();
                    myaclist.SetDataSource(dataSetReport);
                    ReportViewer myReportViewer = new ReportViewer();
                    myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                    myaclist.SetParameterValue("Period", "Period : " + cmbYear.Text + " / " + cmbMonth.Text);
                    myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                    myReportViewer.Show();
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void MonthlyPaymentSummaryFRM_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            //cmbMonth.DataSource = myYear.ListAllMonths();
            //cmbMonth.DisplayMember = "MonthName";
            //cmbMonth.ValueMember = "MonthCode";

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void allCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (allCheck.Checked)
            {
                cmbRoute.Enabled = false;
            }
            else 
            {
                cmbRoute.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMonth.DataSource = myYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
                cmbMonth.DisplayMember = "MonthName";
                cmbMonth.ValueMember = "MonthCode";
                cmbMonth.SelectedValue = BLUser.strMonthID;
            }
            catch { }
        }
    }
}