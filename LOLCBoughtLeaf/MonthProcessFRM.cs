using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Transactions;
using BoughtLeafBusinessLayer;

namespace OLAXBoughtLeaf
{
    public partial class MonthProcessFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.GreenLeaf myGreenLeaf = new BoughtLeafBusinessLayer.GreenLeaf();
        BoughtLeafBusinessLayer.BLMonthlySettings myMonthlySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();
        BoughtLeafBusinessLayer.BLFixedPaymentSettings fixedPaySettings = new BoughtLeafBusinessLayer.BLFixedPaymentSettings();
        BoughtLeafBusinessLayer.MonthlyProcess myProcess = new BoughtLeafBusinessLayer.MonthlyProcess();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLTransportCost myTran = new BoughtLeafBusinessLayer.BLTransportCost();
        BoughtLeafBusinessLayer.OtherAdditions myOtherAdditions = new BoughtLeafBusinessLayer.OtherAdditions();
        BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
        BoughtLeafBusinessLayer.Incentives myIncentive = new BoughtLeafBusinessLayer.Incentives();
        BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();
        BoughtLeafBusinessLayer.SupplierDeduction supDeduction = new BoughtLeafBusinessLayer.SupplierDeduction();
        BoughtLeafBusinessLayer.BLCalculateMonthPayment calcBLPayment = new BoughtLeafBusinessLayer.BLCalculateMonthPayment();
        BoughtLeafBusinessLayer.BLSettings PrSettings = new BLSettings();
        BoughtLeafBusinessLayer.UpdateManager myUpdates = new UpdateManager();
        BoughtLeafBusinessLayer.BLCollector objBLCollector = new BLCollector();

        public MonthProcessFRM()
        {
            InitializeComponent();
        }

        private void MonthProcess_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = BLUser.StrYear;

            cmbYear_SelectedIndexChanged(null, null);            

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";

            cmdProcess.Enabled = false;
            btnConfirm.Enabled = false;
        }

        private Decimal getTransportCharge(String SupplierCode)
        {
            Decimal Transport = 0;
            mySupplier.StrSupplierCode = SupplierCode;
            String TownCode = mySupplier.getSupplierTown();
            if (TownCode == "Direct")
            {
                Transport = 0;
            }
            else
            {
                myRoute.RouteCode = TownCode;
            }

            return Transport;
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            //try
            //{
            
                if (MessageBox.Show("Confirm "+cmbYear.Text+"-"+cmbMonth.SelectedValue.ToString()+" to Calculate...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string ProcessedDivisions = "";
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
                        if (calcBLPayment.getProcessEntries(Convert.ToInt32(cmbYear.SelectedValue.ToString()), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), strChkAllRoutes).Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Already Processed.");
                        }
                        else
                        {
                            String status = "";
                            String statusCancel = "";
                            calcBLPayment.DtFromDate = new DateTime(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), 1);
                            calcBLPayment.DtToDate = calcBLPayment.DtFromDate.AddMonths(1).AddDays(-1);
                            calcBLPayment.StrRouteCode = drow[0].ToString();

                            //myMonthlySettings.IntYear = Convert.ToInt32(cmbYear.Text);
                            //myMonthlySettings.IntMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                            //bool isIncentiveRouteWise = BoughtLeafBusinessLayer.BLUser.IsIncentiveLevelsSettingRouteWise();
                            decimal PayRate = myMonthlySettings.getKiloRate(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue));
                            //decimal StampDutyLevel = Convert.ToDecimal(fixedPaySettings.GetStampDuty().Rows[0][0].ToString());
                            //decimal StampDuty = Convert.ToDecimal(fixedPaySettings.GetStampDuty().Rows[0][1].ToString());

                            //myRoute.RouteCode = drow[0].ToString();


                            if (PayRate > 0)
                            {

                                DataTable dt = mySupplier.ListActiveSuppliers(drow[0].ToString());
                                calcBLPayment.IntProYear = Convert.ToInt32(cmbYear.Text);
                                calcBLPayment.IntProMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                                try
                                {
                                    statusCancel = calcBLPayment.CancleMonthBLPayment(drow[0].ToString());
                                    //MessageBox.Show("Cancel Route, " + drow[0].ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error On Cancel, Route:" + drow[0].ToString() + " - " + ex.Message);
                                }


                                if (dt.Rows.Count > 0)
                                {
                                    progressBar.Minimum = 0;
                                    progressBar.Maximum = dt.Rows.Count;

                                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                    {
                                        calcBLPayment.StrSupplierCode = dt.Rows[i][0].ToString();

                                        myGreenLeaf.StrSupplierCode = dt.Rows[i][0].ToString();
                                        string supCode = dt.Rows[i][0].ToString();

                                        //if (Convert.ToInt32(supCode) == 96)
                                        //    Console.WriteLine();
                                        try
                                        {
                                            status = calcBLPayment.CalculateMonthBLPayment(dt.Rows[i][0].ToString(), drow[0].ToString(),0);

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error On Supplier:" + dt.Rows[i][0].ToString() + " Of Route " + drow[0].ToString() + " - " + ex.Message);
                                        }

                                        progressBar.Value = i;
                                    }
                                    ProcessedDivisions += drow[0].ToString() + "-";
                                }
                                dt.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Bought Leaf Per Kilo Rate Is Not Defined For This Month...");
                                return;
                            }
                            lblStatus.Text = drow[0].ToString() + " Process Completed";
                            progressBar.Value = 0;
                        }
                    }
                    String Collectorstatus = "";
                    String CollectorstatusCancel = "";
                    #region Process_Collector_Payment
                    try
                    {
                        DataTable dtCollector = objBLCollector.getCollectors();
                        foreach (DataRow dr1 in dtCollector.Rows)
                        {
                            calcBLPayment.IntProYear = Convert.ToInt32(cmbYear.Text);
                            calcBLPayment.IntProMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                            calcBLPayment.StrCollector = dr1[0].ToString();
                            try
                            {
                                CollectorstatusCancel = calcBLPayment.CancleMonthCollectorBLPayment(dr1[0].ToString());
                                //MessageBox.Show("Cancel Route, " + drow[0].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error On Cancel, Route:" + dr1[0].ToString() + " - " + ex.Message);
                            }
                            try
                            {
                                Collectorstatus = calcBLPayment.CalculateMonthCollectorBLPayment(dr1[0].ToString());

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error On Collector:" + dr1[0].ToString() + " - " + ex.Message);
                            }
                            lblStatus.Text = dr1[0].ToString() + "Processed.";
                            Application.DoEvents();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error On Collector Payment, "+ex.Message);
                    }
                    #endregion
                    MessageBox.Show(ProcessedDivisions+" Calculated Successfully");
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

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            lblEarningsStatus.Text = "Creating Checkroll Backup....";
            String dirPath = PrSettings.GetBackUpLocation("BackUpLocation");
            String SDirectory = "BL" +  "_BF_Calculate";
            String filePath = "";
            String fileName = "";

            fileName = String.Format(SDirectory + "-{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
            filePath = dirPath + fileName + ".bak";
            if (File.Exists(filePath))
            {
                MessageBox.Show(" Already Backed Up Now,\r\n Press 'OK' To Proceed. ");
                lblEarningsStatus.Text = "Ready to preview....";
                cmdProcess.Enabled = true;
                btnBackUp.Enabled = false;
            }
            else
            {
                try
                {
                    myUpdates.BackUpDataBase(filePath, PrSettings.GetBackUpLocation("DBName"));
                    lblEarningsStatus.Text = "Created Backup Successfully ....";
                    cmdProcess.Enabled = true;
                    btnBackUp.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Back Up Error, " + ex.Message);
                    cmdProcess.Enabled = false;
                    btnBackUp.Enabled = true;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String strChkAllRoutes = "%";
            chkAllRoutes.Checked = true;
            if (MessageBox.Show("All Division Will Process...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //if (!chkAllRoutes.Checked)
                //{
                //    strChkAllRoutes = cmbRoute.SelectedValue.ToString();
                //}
                if (MessageBox.Show("Confirm " + cmbYear.Text + "-" + cmbMonth.SelectedValue.ToString() + " to Confirm...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (calcBLPayment.getProcessEntries(Convert.ToInt32(cmbYear.SelectedValue.ToString()), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), strChkAllRoutes).Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Route Already Processed.");
                    }
                    else
                    {
                        cmdProcess.Enabled = false;


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
                            String status = "";
                            String statusCancel = "";

                            calcBLPayment.StrRouteCode = drow[0].ToString();


                            DataTable dt = mySupplier.ListActiveSuppliers(drow[0].ToString());
                            calcBLPayment.IntProYear = Convert.ToInt32(cmbYear.Text);
                            calcBLPayment.IntProMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());



                            if (dt.Rows.Count > 0)
                            {
                                progressBar.Minimum = 0;
                                progressBar.Maximum = dt.Rows.Count;

                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    calcBLPayment.StrSupplierCode = dt.Rows[i][0].ToString();

                                    myGreenLeaf.StrSupplierCode = dt.Rows[i][0].ToString();
                                    string supCode = dt.Rows[i][0].ToString();

                                    //if (Convert.ToInt32(supCode) == 96)
                                    //    Console.WriteLine();
                                    try
                                    {
                                        status = calcBLPayment.ConfirmMonthBLPayment(dt.Rows[i][0].ToString(), drow[0].ToString());

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error On Confirm Supplier:" + dt.Rows[i][0].ToString() + " Of Route " + drow[0].ToString() + " - " + ex.Message);
                                    }

                                    progressBar.Value = i;
                                }

                            }
                            dt.Dispose();
                            calcBLPayment.InsertProcessConfirmationDetails(drow[0].ToString(), calcBLPayment.IntProYear, calcBLPayment.IntProMonth);
                            MessageBox.Show("Completed Confirmation On Route: " + drow[0].ToString());
                            lblStatus.Text = drow[0].ToString() + " Confirmation Completed";
                            
                            progressBar.Value = 0;

                        }
                        DateTime dtnxDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue.ToString()), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), 1).AddMonths(1);
                        String strMonthOpen = calcBLPayment.OpenNewMonth(dtnxDate.Year, dtnxDate.Month, dtnxDate, "System");
                        if (!strMonthOpen.ToUpper().Equals("ADDED"))
                        {
                            MessageBox.Show("Month Open Error");
                        }

                        MessageBox.Show("Process Completed");
                        lblStatus.Text = "Process Completed";
                        cmdProcess.Enabled = true;
                    }
                }
            }
        }

        private void BackupBfConfirm_Click(object sender, EventArgs e)
        {
            lblEarningsStatus.Text = "Creating Checkroll Backup....";
            String dirPath = PrSettings.GetBackUpLocation("BackUpLocation");
            String SDirectory = "BL" + "_BF_CONFIRM";
            String filePath = "";
            String fileName = "";

            fileName = String.Format(SDirectory + "-{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
            filePath = dirPath + fileName + ".bak";
            if (File.Exists(filePath))
            {
                MessageBox.Show(" Already Backed Up Now,\r\n Press 'OK' To Proceed. ");
                lblEarningsStatus.Text = "Ready to preview....";
                btnConfirm.Enabled = true;
                btnBackUp.Enabled = false;
            }
            else
            {
                try
                {
                    myUpdates.BackUpDataBase(filePath, PrSettings.GetBackUpLocation("DBName"));
                    lblEarningsStatus.Text = "Created Backup Successfully ....";
                    btnConfirm.Enabled = true;
                    btnBackUp.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Back Up Error, " + ex.Message);
                    btnConfirm.Enabled = false;
                    btnBackUp.Enabled = true;
                }
            }
        }

        private void btnCancelProcess_Click(object sender, EventArgs e)
        {

        }

        private void chkAllRoutes_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}