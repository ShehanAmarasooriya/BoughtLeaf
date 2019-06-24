using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class rptSupplierPaymentToBank : Form
    {
        public rptSupplierPaymentToBank()
        {
            InitializeComponent();
        }
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();

        private void rptSupplierPaymentToBank_Load(object sender, EventArgs e)
        {
            try
            {
                cmbYear.DataSource = myYear.ListAllVisibleYears();
                cmbYear.DisplayMember = "YearCode";
                cmbYear.ValueMember = "YearCode";
                cmbYear.Text = DateTime.Now.Year.ToString();

                cmbMonth.DataSource = myYear.ListAllMonths();
                cmbMonth.DisplayMember = "MonthName";
                cmbMonth.ValueMember = "MonthCode";

                cmbRoute.DataSource = myRoute.ListRouteDetails();
                cmbRoute.DisplayMember = "RouteName";
                cmbRoute.ValueMember = "RouteCode";
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

        private void cmdDisplay_Click(object sender, EventArgs e)
        {
            //DataSet ds;
            //int payYear;
            //int payMonth;
            //string routecdoe;
            //string Allroute;
            //try
            //{
            //    if (allCheck.Checked)
            //    {
            //        Allroute = "All Routes";
            //        routecdoe = "%";
            //    }
            //    else
            //    {
            //        Allroute = cmbRoute.Text;
            //        routecdoe = cmbRoute.SelectedValue.ToString();
            //    }

            //    payYear = Convert.ToInt32(cmbYear.Text);
            //    payMonth =Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                

            //    BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();
            //    //ds = myBank.GetSupplierPaymentToBank(payYear,payMonth,routecdoe);
            //    //ds.Tables[0].TableName = "SupplierPaymentToBank";
            //    //ds.WriteXml("SupplierPaymentToBank.xml");
                
            //    SupplierPaymentToBankReport oBankwiseRepoort = new SupplierPaymentToBankReport();
            //    oBankwiseRepoort.SetDataSource(ds);
            //    oBankwiseRepoort.SetParameterValue("Estate", "");
            //    oBankwiseRepoort.SetParameterValue("Route", Allroute);
            //    oBankwiseRepoort.SetParameterValue("PayMonth", cmbMonth.Text);
            //    oBankwiseRepoort.SetParameterValue("PayYear", cmbYear.Text);
            //    oBankwiseRepoort.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            //    //oBankwiseRepoort.SetParameterValue("FactoryName", BoughtLeafBusinessLayer.BLUser.getFactoryName());
            //    ReportViewer oReportViewer = new ReportViewer();
            //    oReportViewer.crystalReportViewer1.ReportSource = oBankwiseRepoort;
            //    oReportViewer.Show();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}