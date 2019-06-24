using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;

namespace OLAXBoughtLeaf
{
    public partial class MonthlyProcessCancelFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.GreenLeaf myGreenLeaf = new BoughtLeafBusinessLayer.GreenLeaf();
        BoughtLeafBusinessLayer.BLMonthlySettings myMonthlySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();
        BoughtLeafBusinessLayer.BLFixedPaymentSettings myOtherSettings = new BoughtLeafBusinessLayer.BLFixedPaymentSettings();
        BoughtLeafBusinessLayer.MonthlyProcess myProcess = new BoughtLeafBusinessLayer.MonthlyProcess();
        BoughtLeafBusinessLayer.OtherAdditions myAdditions = new BoughtLeafBusinessLayer.OtherAdditions();
        BoughtLeafBusinessLayer.MothlyPaymentSummary mySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();
        BoughtLeafBusinessLayer.SupplierDeduction myDeduction = new BoughtLeafBusinessLayer.SupplierDeduction();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        public MonthlyProcessCancelFRM()
        {
            InitializeComponent();
        }

        private void MonthlyProcessCancel_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = BoughtLeafBusinessLayer.BLUser.StrYear;

            cmbYear_SelectedIndexChanged(null, null);

            

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            string q = "fff";
            //try
            //{
                if (MessageBox.Show("Confirm Monthly Process to Reverse...?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmdProcess.Enabled = false;
                    String strChkAllRoutes = "%";
                    if (chkAllRoutes.Checked)
                    {
                        strChkAllRoutes = "%";
                    }
                    else
                    {
                        strChkAllRoutes = cmbRoute.SelectedValue.ToString();
                    }

                    DataTable dtRoute = myRoute.ListRouteDetails(strChkAllRoutes);

                    foreach (DataRow drow in dtRoute.Rows)
                    {
                        ////using (TransactionScope scope = new TransactionScope())
                        ////{
                        myProcess.IntMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                        myProcess.IntYear = Convert.ToInt32(cmbYear.Text);

                        myGreenLeaf.CancelUpdateAsProcessed(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), drow[0].ToString());
                        myAdditions.CancelUpdateAsProcessed(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), drow[0].ToString());
                        myDeduction.cancelAllDeduction((Convert.ToInt32(cmbYear.Text)), Convert.ToInt32(cmbMonth.SelectedValue.ToString()));
                        mySummary.deleteMonthyPaymenySummary(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), drow[0].ToString());


                        //scope.Complete();
                        ////}
                        //MessageBox.Show(drow[0].ToString() + "Process Completed");
                        lblStatus.Text = drow[0].ToString() + " Process Completed";
                    }
                    MessageBox.Show("Process Reversed");
                    lblStatus.Text = "Process Completed";
                    cmdProcess.Enabled = true;
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void chkAllRoutes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllRoutes.Checked)
            {
                cmbRoute.Enabled = false;
            }
            else
                cmbRoute.Enabled = true;
        }

        private void btnPayVoucher_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GL Not Connected.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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