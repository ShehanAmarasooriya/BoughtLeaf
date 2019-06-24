using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BoughtLeafDataAccess;

namespace OLAXBoughtLeaf
{
    public partial class GreenLeafSummaryReport : Form
    {
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
        BoughtLeafBusinessLayer.BLCalculateMonthPayment objCalMonthPay = new BoughtLeafBusinessLayer.BLCalculateMonthPayment();
        BoughtLeafBusinessLayer.GreenLeaf myGreenLeaf = new BoughtLeafBusinessLayer.GreenLeaf();
        BoughtLeafBusinessLayer.BLMonthlySettings myMonthlySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();
        BoughtLeafBusinessLayer.BLCalculateMonthPayment calcBLPayment = new BoughtLeafBusinessLayer.BLCalculateMonthPayment();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.MothlyPaymentSummary myMonthlySummary = new BoughtLeafBusinessLayer.MothlyPaymentSummary();
        BoughtLeafBusinessLayer.BLMonthlySettings mySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();

        public GreenLeafSummaryReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSupCode.Text == "") 
            {
                errorProvider1.SetError(txtSupCode, "Enter Supplier Code");
            }
            string sup = txtSupCode.Text;
            string newSup;
            DataTable dt = myReports.getSupplierSummaryDetails(newSup = sup.PadLeft(5, '0'), FromDate.Text.ToString(), ToDate.Text.ToString());
            dt.TableName = "GreanLeafSummary";
            //dt.Columns.Add(FromDate.Text, typeof(System.Int32));
            //dt.Columns.Add(ToDate.Text, typeof(System.Int32));
            dt.WriteXml("SupplierGreenLeafSummary.xml");
            suppliergreanleafsummarytotal myaclist = new suppliergreanleafsummarytotal();
            myaclist.SetDataSource(dt);
            crystalReportViewer1.ReportSource = myaclist;
            crystalReportViewer1.Show();
            txtSupCode.Focus();
        }

        private void GreenLeafSummaryReport_Load(object sender, EventArgs e)
        {
            
            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void Clear()
        {
            txt_rate.Text = "0.00";
            cmdProcess.Enabled = true;
            txtSupCode.Clear();
            txtSupName.Clear();
            crystalReportViewer1.ReportSource = null;
            errorProvider1.Clear();
        }

        private void Error()
        {
            if (txtSupName.Text == "" && txtSupCode.Text == "")
            {
                errorProvider1.Clear();
            }
            else if (txtSupCode.Text != "" && txtSupName.Text == "")
            {
                errorProvider1.SetError(txtSupCode, "Invalid Supplier Code");
                txtSupCode.Focus();
            }

            else if (txtSupCode.Text != "" && txtSupName.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void getSupName()
        {
            txtSupName.Clear();
            string sup = txtSupCode.Text;
            string newSup = sup.PadLeft(5, '0');
            string q = "SELECT SupplierName FROM Supplier WHERE SupplierCode='" + newSup + "'";
            SQLHelper.ExecuteReader(q, CommandType.Text);
            SqlDataReader rdr = SQLHelper.ExecuteReader(q, CommandType.Text);

            while (rdr.Read())
            {
                txtSupName.Text = rdr["SupplierName"].ToString();
            }
            Error();
        }

        private void txtSupCode_TextChanged(object sender, EventArgs e)
        {
            getSupName();
            if (string.IsNullOrEmpty(txtSupCode.Text))
            {
                errorProvider1.Clear();
                Clear();
            }
        }

        private void txtSupCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtSupCode_Leave(object sender, EventArgs e)
        {
            getSupName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            Clear();
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            
                if (objCalMonthPay.getProcessEntries(ToDate.Value.Date.Year, ToDate.Value.Date.Month, cmbRoute.SelectedValue.ToString()).Tables[0].Rows.Count > 0)
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
                        if (calcBLPayment.getProcessEntries(ToDate.Value.Date.Year, ToDate.Value.Date.Month, cmbRoute.SelectedValue.ToString()).Tables[0].Rows.Count > 0)
                        {
                            txt_rate.Enabled = false;
                            MessageBox.Show("Already Processed.");
                        }
                        else
                        {
                            String status = "";
                            String statusCancel = "";
                            calcBLPayment.DtFromDate = new DateTime(ToDate.Value.Date.Year, ToDate.Value.Date.Month, 1);
                            calcBLPayment.DtToDate = calcBLPayment.DtFromDate.AddMonths(1).AddDays(-1);
                            calcBLPayment.StrRouteCode = drow[0].ToString();

                            //myMonthlySettings.IntYear = ToDate.Value.Date.Year;
                            //myMonthlySettings.IntMonth = ToDate.Value.Date.Month;
                            //bool isIncentiveRouteWise = BoughtLeafBusinessLayer.BLUser.IsIncentiveLevelsSettingRouteWise();
                            decimal PayRate = myMonthlySettings.getKiloRate(ToDate.Value.Date.Year, ToDate.Value.Date.Month);
                            txt_rate.Text = PayRate.ToString("F2");
                            //decimal StampDutyLevel = Convert.ToDecimal(fixedPaySettings.GetStampDuty().Rows[0][0].ToString());
                            //decimal StampDuty = Convert.ToDecimal(fixedPaySettings.GetStampDuty().Rows[0][1].ToString());

                            //myRoute.RouteCode = drow[0].ToString();


                            if (PayRate > 0)
                            {

                                DataTable dt = mySupplier.ListActiveSuppliers(drow[0].ToString());
                                calcBLPayment.IntProYear = ToDate.Value.Date.Year;
                                calcBLPayment.IntProMonth = ToDate.Value.Date.Month;
                                try
                                {
                                    //statusCancel = calcBLPayment.CancleMonthBLPayment(drow[0].ToString());
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
                                            //status = calcBLPayment.CalculateMonthBLPayment(dt.Rows[i][0].ToString(), drow[0].ToString());

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
                            lblStatus.Text = drow[0].ToString() + " Successfully Prepared Credit Availability";
                            progressBar.Value = 0;
                        }
                    }
                    MessageBox.Show(ProcessedDivisions + " Successfully Prepared Credit Availability");
                    lblStatus.Text = "Successfully Prepared Credit Availability";
                    gbSupplierSelection.Enabled = true;
                    
                }
                else
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
                        if (calcBLPayment.getProcessEntries(ToDate.Value.Date.Year, ToDate.Value.Date.Month, cmbRoute.SelectedValue.ToString()).Tables[0].Rows.Count > 0)
                        {
                            txt_rate.Enabled = false;
                            MessageBox.Show("Already Processed.");
                            
                        }
                        else
                        {
                            String status = "";
                            String statusCancel = "";
                            calcBLPayment.DtFromDate = new DateTime(ToDate.Value.Date.Year, ToDate.Value.Date.Month, 1);
                            calcBLPayment.DtToDate = calcBLPayment.DtFromDate.AddMonths(1).AddDays(-1);
                            calcBLPayment.StrRouteCode = drow[0].ToString();

                            //myMonthlySettings.IntYear = ToDate.Value.Date.Year;
                            //myMonthlySettings.IntMonth = ToDate.Value.Date.Month;
                            //bool isIncentiveRouteWise = BoughtLeafBusinessLayer.BLUser.IsIncentiveLevelsSettingRouteWise();
                            decimal PayRate = Convert.ToDecimal(txt_rate.Text);
                            //decimal StampDutyLevel = Convert.ToDecimal(fixedPaySettings.GetStampDuty().Rows[0][0].ToString());
                            //decimal StampDuty = Convert.ToDecimal(fixedPaySettings.GetStampDuty().Rows[0][1].ToString());

                            //myRoute.RouteCode = drow[0].ToString();


                            if (PayRate > 0)
                            {

                                DataTable dt = mySupplier.ListActiveSuppliers(drow[0].ToString());
                                calcBLPayment.IntProYear = ToDate.Value.Date.Year;
                                calcBLPayment.IntProMonth = ToDate.Value.Date.Month;
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
                                            status = calcBLPayment.CalculateMonthBLPayment(dt.Rows[i][0].ToString(), drow[0].ToString(),Convert.ToDecimal(txt_rate.Text));

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
                            lblStatus.Text = drow[0].ToString() + " Successfully Prepared Credit Availability";
                            progressBar.Value = 0;
                        }
                    }
                    MessageBox.Show(ProcessedDivisions + " Successfully Prepared Credit Availability");
                    lblStatus.Text = "Successfully Prepared Credit Availability";
                    gbSupplierSelection.Enabled = true;
                }
                
                
            }

        private void txtSupCode_TextChanged_1(object sender, EventArgs e)
        {
            txtSupName.Text=mySupplier.getSupplierName(cmbRoute.SelectedValue.ToString(), txtSupCode.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSupCode.Text) )
            {
                MessageBox.Show("Type A Valid Supplier");
                txtSupCode.Focus();
            }
            else if( !chkAllRoutes.Checked && String.IsNullOrEmpty(mySupplier.getSupplierName(cmbRoute.SelectedValue.ToString(),txtSupCode.Text)))
            {
                MessageBox.Show("Type A Valid Supplier");
                txtSupCode.Focus();
            }
            else if (chkAllRoutes.Checked && String.IsNullOrEmpty(mySupplier.getSupplierName(txtSupCode.Text)))
            {
                MessageBox.Show("Type A Valid Supplier");
                txtSupCode.Focus();
            }
            else
            {
                DataSet dsRPT = new DataSet();
                DataTable dataSetReport = new DataTable();
                dataSetReport.TableName = "SupplierPaymentsSummary";
                DataTable dataSetReport1 = new DataTable();
                dataSetReport.TableName = "PaymentsHistory";

                string supCode = string.Empty;
                supCode = txtSupCode.Text;

                string strRoute = "%";
                if (chkAllRoutes.Checked)
                    strRoute = "%";
                else
                    strRoute = cmbRoute.SelectedValue.ToString();

                dataSetReport = myMonthlySummary.getSupplierPaymentsDetail(ToDate.Value.Year, ToDate.Value.Month, supCode, strRoute).Tables[0];
                dataSetReport1 = myMonthlySummary.getCreditAvailabilityPaymentSummary(ToDate.Value.Year, ToDate.Value.Month,FromDate.Value.Month , supCode, strRoute).Tables[0];
                dataSetReport1.TableName = "History";
                if (dataSetReport.Rows.Count > 0)
                {
                    dataSetReport.WriteXml("SupplierPaymentsSummary.xml");
                    dataSetReport1.WriteXml("supplierPaymentsHistory.xml");
                    //SupplierCreditAvailabilityRPT myReport = new SupplierCreditAvailabilityRPT();
                    SupplierCreditAvailabilityRPTTemp myReport = new SupplierCreditAvailabilityRPTTemp();
                    myReport.SetDataSource(dataSetReport);
                    SupplierGLHistoryRPT glRpt = new SupplierGLHistoryRPT();
                    glRpt.SetDataSource(dataSetReport1);
                    //myReport.SetDataSource(dataSetReport1);
                    ReportViewer rptViewer = new ReportViewer();

                    myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                    myReport.SetParameterValue("Year", ToDate.Value.Date.Year.ToString());
                    myReport.SetParameterValue("Month", ToDate.Value.Date.Month.ToString());
                    //myReport.SetParameterValue("payRate", mySettings.getKiloRate(ToDate.Value.Date.Year, ToDate.Value.Date.Month));
                    myReport.SetParameterValue("payRate", Convert.ToDecimal( txt_rate.Text) );
                    rptViewer.crystalReportViewer1.ReportSource = myReport;
                    rptViewer.Show();
                }
                else
                {
                    MessageBox.Show("No Data Available");
                }
            }
            
        }

        private void btnCreditAvailability_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSupCode.Text))
            {
                MessageBox.Show("Type A Valid Supplier");
                txtSupCode.Focus();
            }
            else if (!chkAllRoutes.Checked && String.IsNullOrEmpty(mySupplier.getSupplierName(cmbRoute.SelectedValue.ToString(), txtSupCode.Text)))
            {
                MessageBox.Show("Type A Valid Supplier");
                txtSupCode.Focus();
            }
            else if (chkAllRoutes.Checked && String.IsNullOrEmpty(mySupplier.getSupplierName(txtSupCode.Text)))
            {
                MessageBox.Show("Type A Valid Supplier");
                txtSupCode.Focus();
            }
            else
            {
                DataSet dsRPT = new DataSet();
               
                DataTable dataSetReport1 = new DataTable();
                dataSetReport1.TableName = "PaymentsHistory";

                string supCode = string.Empty;
                supCode = txtSupCode.Text;

                string strRoute = "%";
                if (chkAllRoutes.Checked)
                    strRoute = "%";
                else
                    strRoute = cmbRoute.SelectedValue.ToString();

                //dataSetReport = myMonthlySummary.getSupplierPaymentsDetail(ToDate.Value.Year, ToDate.Value.Month, supCode, strRoute).Tables[0];
                dataSetReport1 = myMonthlySummary.getCreditAvailabilityPaymentSummary(ToDate.Value.Year, ToDate.Value.Month,FromDate.Value.Month, supCode, strRoute).Tables[0];
                dataSetReport1.TableName = "History";
                if (dataSetReport1.Rows.Count > 0)
                {
                    //dataSetReport.WriteXml("SupplierPaymentsSummary.xml");
                    dataSetReport1.WriteXml("supplierPaymentsHistory.xml");
                   
                    SupplierGLHistoryRPT glRpt = new SupplierGLHistoryRPT();
                    glRpt.SetDataSource(dataSetReport1);
                    //myReport.SetDataSource(dataSetReport1);
                    ReportViewer rptViewer = new ReportViewer();


                    rptViewer.crystalReportViewer1.ReportSource = glRpt;
                    rptViewer.Show();
                }
                else
                {
                    MessageBox.Show("No Data Available");
                }
            }
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

            decimal PayRate_ThisMomth = myMonthlySettings.getKiloRate(ToDate.Value.Date.Year, ToDate.Value.Date.Month);
            decimal PayRate_PreviousMomth = myMonthlySettings.previousmonthrate(ToDate.Value.Date.Year, ToDate.Value.Date.Month);
            Clear();
            txt_rate.Enabled = false;
           
            if (PayRate_ThisMomth <= 0)
            {
                txt_rate.Enabled = true;
                
                DialogResult result = MessageBox.Show("This month Pay Rate Is 0 Do You Wish To Get Prevoius Month Pay Rate", "OLAX ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txt_rate.Text = PayRate_PreviousMomth.ToString("F2");
                }
                else if (result == DialogResult.No)
                {
                    txt_rate.Text = 0.ToString("F2");
                }

            }
            else
            {
                txt_rate.Text= myMonthlySettings.getKiloRate(ToDate.Value.Date.Year, ToDate.Value.Date.Month).ToString("F2");
                
            }
        }

        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;               
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_rate_Leave(object sender, EventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void txt_rate_TextChanged(object sender, EventArgs e)
        {
            cmdProcess.Enabled = true;
        }
        
    }
}