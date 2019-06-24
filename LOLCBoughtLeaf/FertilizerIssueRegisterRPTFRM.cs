using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class FertilizerIssueRegisterRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLDeductionCode myDeduction = new BoughtLeafBusinessLayer.BLDeductionCode();
        public FertilizerIssueRegisterRPTFRM()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FertilizerIssueRegister_Load(object sender, EventArgs e)
        {

            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);


            cmbSupplier.DataSource = mySupplier.ListActiveSuppliers();
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierCode";

            cmbFertilizer.DataSource = myDeduction.ViewAllDeductionByGroup("FET");
            cmbFertilizer.DisplayMember = "DeductionName";
            cmbFertilizer.ValueMember = "DeductionCode";

            cmbMonth.SelectedValue = DateTime.Now.Month;
        }

        private void chkFertilizer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFertilizerAll.Checked)
            {
                cmbFertilizer.Enabled = false;
            }
            else
                cmbFertilizer.Enabled = true;
        }

        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplier.Checked)
            {
                chkFertilizerAll.Checked = false;
                cmbSupplier.Enabled = false;
            }
            else
            {
                chkFertilizerAll.Checked = true;
                cmbSupplier.Enabled = true;
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSetReport = new DataSet();
                BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                ReportViewer myReportViewer = new ReportViewer();
                if (chkSupplier.Checked)
                {
                    if (chkFertilizerAll.Checked)
                    {
                        dataSetReport = myReports.getFertlizerIssuesSummary(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()));
                        myReportViewer.crystalReportViewer1.DisplayGroupTree = true; // because report group by fertilzer there for display group tree of report 
                    }
                    else
                    {
                        dataSetReport = myReports.getFertlizerIssuesSummaryByFert(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbFertilizer.SelectedValue.ToString());
                    }
                }
                else
                {
                    dataSetReport = myReports.getFertlizerIssuesSummaryBySup(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbSupplier.SelectedValue.ToString());
                    myReportViewer.crystalReportViewer1.DisplayGroupTree = true; // because report group by fertilzer there for display group tree of report 
                }

                dataSetReport.WriteXml("FertilizerIssueSummary.xml");
                FertilizerIssueRegisterRPT myaclist = new FertilizerIssueRegisterRPT();
                myaclist.SetDataSource(dataSetReport);

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