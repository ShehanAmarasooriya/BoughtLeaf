using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace OLAXBoughtLeaf
{
    //public delegate void PrintDelegate();
    public partial class PaymentSlipRPTFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.Reports myreports = new BoughtLeafBusinessLayer.Reports();
        OLAXBoughtLeaf.LoginFRM log = new OLAXBoughtLeaf.LoginFRM();

        public PaymentSlipRPTFRM()
        {
            InitializeComponent();
        }
        private void CustomPrintMethod()
        {
            MessageBox.Show("Custom Print Method");
        }

        private void PaymentSlip_Load(object sender, EventArgs e)
        {
            
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbMonth.DataSource = myYear.ListAllMonths();
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";
            cmbMonth.SelectedValue = LoginFRM.month_log; //DateTime.Now.Year.ToString();
           
           
            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";

            DataTable dt = new DataTable();
            
            String pay_slip = myreports.getmastersetingforpayslip().Tables[0].Rows[0]["Name"].ToString();
            //pay_slip.ToUpper();

            if (pay_slip.ToUpper() == "NO")
            {
                radioButton1.Text = "Sinhala";
                radioButton1.Checked = true;
                radioButton2.Text = "English";
            }
            else
            {
                radioButton2.Visible = false;
                radioButton1.Text = "Pre Printed";
                radioButton1.Checked = true;
            }
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataSetReport = new DataTable();

                BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                dataSetReport = myReports.getPaymentSlipS(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                dataSetReport.WriteXml("PaymentSlip.xml");

                DataTable NewDt = myReports.getDayWiseGreenLeaf(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                NewDt.TableName = "DayLeaf";
                NewDt.WriteXml("DayGreenLeaf.xml");

                DataTable Newdt1 = myReports.getSalarySlipDetailItems(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                Newdt1.TableName = "SalaryItems";
                Newdt1.WriteXml("SalaryItems.xml");
                //GetCashBalance
                PaySlipRPT myaclist = new PaySlipRPT();
                //BoughtleafPayslipRPT 
                myaclist.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                myaclist.SetDataSource(dataSetReport);
                myaclist.Subreports["Leaf"].SetDataSource(NewDt);
                myaclist.Subreports["Item"].SetDataSource(Newdt1);
                ReportViewer myReportViewer = new ReportViewer();
                myaclist.SetParameterValue("year", cmbYear.Text);
                myaclist.SetParameterValue("month", cmbMonth.Text);
                myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
                myReportViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsGeneral = new DataSet();

                BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                
                dsGeneral = myReports.GetSupplierPaymentForPaySlipGeneral(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                dsGeneral.Tables[0].TableName = "GetSupplierPaymentForPaySlipGeneral";
                //dataSetReport.WriteXml("PaymentSlip.xml");

                DataSet dsGreenLeaf = myReports.GetSupplierPaymentForPaySlipGreenLeaf(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                dsGreenLeaf.Tables[0].TableName = "GetSupplierPaymentForPaySlipGreenLeaf";
               // NewDt.WriteXml("DayGreenLeaf.xml");

                DataSet dsThisMonthIssues = myReports.GetSupplierPaymentForPaySlipThisMonthIssues(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                dsThisMonthIssues.Tables[0].TableName = "GetSupplierPaymentForPaySlipThisMonthIssues";
                //Newdt1.WriteXml("SalaryItems.xml");
                //GetCashBalance
             
                PaySlipRPT01 myaclist = new PaySlipRPT01();


                #region Payslip Paper Selection
                PrintDocument pDoc = new PrintDocument();
                int paperNo = 0;
                for (int j = 0; j < pDoc.PrinterSettings.PaperSizes.Count; j++)
                {
                    if (pDoc.PrinterSettings.PaperSizes[j].PaperName.Equals("lol1"))
                    {
                        paperNo = (int)pDoc.PrinterSettings.PaperSizes[j].RawKind;
                        break;
                    }
                }
                // myaclist.PrintOptions.PrinterName = "EPSON LQ-2190 ESC/P2";

                myaclist.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)paperNo;
                myaclist.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                #endregion
                //BoughtleafPayslipRPT 
                //DataSet FinalDs = new DataSet();
                //FinalDs.Tables.Add(dsGeneral.Tables[0]);
                //FinalDs.Tables.Add(dsGreenLeaf.Tables[0]);
                //FinalDs.Tables.Add(dsThisMonthIssues.Tables[0]);


                //myaclist.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                //myaclist.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
               // myaclist.SetDataSource(dsGeneral.Tables[0]);
                //myaclist.SetDataSource(dsGreenLeaf.Tables[0]);
               // myaclist.SetDataSource(dsThisMonthIssues.Tables[0]);
                myaclist.Database.Tables["GetSupplierPaymentForPaySlipGeneral"].SetDataSource(dsGeneral.Tables[0]);
                myaclist.Database.Tables["GetSupplierPaymentForPaySlipGreenLeaf"].SetDataSource(dsGreenLeaf.Tables[0]);
                myaclist.Database.Tables["GetSupplierPaymentForPaySlipThisMonthIssues"].SetDataSource(dsThisMonthIssues.Tables[0]);
                //myaclist.Subreports["Leaf"].SetDataSource(NewDt);
                //myaclist.Subreports["Item"].SetDataSource(Newdt1);
                ReportViewer myReportViewer = new ReportViewer();
                //myaclist.SetParameterValue("year", cmbYear.Text);
                //myaclist.SetParameterValue("month", cmbMonth.Text);
                myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
                myReportViewer.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dsGeneral = new DataSet();

            BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

            dsGeneral = myReports.GetSupplierPaymentForPaySlipGeneral(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
            dsGeneral.WriteXml("lolTest.xml");
            





            CrystalReport1 myaclist = new CrystalReport1();


            #region Payslip Paper Selection
            PrintDocument pDoc = new PrintDocument();
            int paperNo = 0;
            for (int j = 0; j < pDoc.PrinterSettings.PaperSizes.Count; j++)
            {
                if (pDoc.PrinterSettings.PaperSizes[j].PaperName.Equals("lol1"))
                {
                    paperNo = (int)pDoc.PrinterSettings.PaperSizes[j].RawKind;
                    break;
                }
            }
            // myaclist.PrintOptions.PrinterName = "EPSON LQ-2190 ESC/P2";

            myaclist.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)paperNo;
            myaclist.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
            #endregion
            //myaclist.Subreports["Item"].SetDataSource(Newdt1);
            ReportViewer myReportViewer = new ReportViewer();
            //myaclist.SetParameterValue("year", cmbYear.Text);
            //myaclist.SetParameterValue("month", cmbMonth.Text);
            myReportViewer.crystalReportViewer1.ReportSource = myaclist;
            myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
            myReportViewer.Show();

        }

        private void btnDouble_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMonth.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select The Month");
                }
                else
                {
                    if (radioButton1.Checked == true && radioButton1.Text == "Sinhala")
                    {
                        //MessageBox.Show("dasdasd");
                        DataSet dsGeneral = new DataSet();

                        BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

                        dsGeneral = myReports.GetSupplierPaymentForPaySlipGeneral(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                        dsGeneral.Tables[0].TableName = "GetSupplierPaymentForPaySlipGeneral";
                        //dataSetReport.WriteXml("PaymentSlip.xml");

                        DataSet dsGreenLeaf = myReports.GetSupplierPaymentForPaySlipGreenLeaf(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                        dsGreenLeaf.Tables[0].TableName = "GetSupplierPaymentForPaySlipGreenLeaf";
                        // NewDt.WriteXml("DayGreenLeaf.xml");

                        DataSet dsThisMonthIssues = myReports.GetSupplierPaymentForPaySlipThisMonthIssues(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                        dsThisMonthIssues.Tables[0].TableName = "GetSupplierPaymentForPaySlipThisMonthIssues";
                        PayslipRPT_Sinhala myaclist = new PayslipRPT_Sinhala();

                        myaclist.Database.Tables["GetSupplierPaymentForPaySlipGeneral"].SetDataSource(dsGeneral.Tables[0]);
                        myaclist.Database.Tables["GetSupplierPaymentForPaySlipGreenLeaf"].SetDataSource(dsGreenLeaf.Tables[0]);
                        myaclist.Database.Tables["GetSupplierPaymentForPaySlipThisMonthIssues"].SetDataSource(dsThisMonthIssues.Tables[0]);

                        ReportViewer myReportViewer = new ReportViewer();

                        myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                        myaclist.SetParameterValue("company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                        myaclist.SetParameterValue("factory", BoughtLeafBusinessLayer.BLUser.getFactoryName());
                        myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
                        myReportViewer.Show();
                    }
                    else if (radioButton2.Checked == true && radioButton2.Text == "English")
                    {
                        //;

                        DataSet dsGeneral = new DataSet();

                        BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

                        dsGeneral = myReports.GetSupplierPaymentForPaySlipGeneral(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                        dsGeneral.Tables[0].TableName = "GetSupplierPaymentForPaySlipGeneral";
                        //dataSetReport.WriteXml("PaymentSlip.xml");

                        DataSet dsGreenLeaf = myReports.GetSupplierPaymentForPaySlipGreenLeaf(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                        dsGreenLeaf.Tables[0].TableName = "GetSupplierPaymentForPaySlipGreenLeaf";
                        // NewDt.WriteXml("DayGreenLeaf.xml");

                        DataSet dsThisMonthIssues = myReports.GetSupplierPaymentForPaySlipThisMonthIssues(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                        dsThisMonthIssues.Tables[0].TableName = "GetSupplierPaymentForPaySlipThisMonthIssues";
                        PayslipRPT_English myaclist = new PayslipRPT_English();

                        myaclist.Database.Tables["GetSupplierPaymentForPaySlipGeneral"].SetDataSource(dsGeneral.Tables[0]);
                        myaclist.Database.Tables["GetSupplierPaymentForPaySlipGreenLeaf"].SetDataSource(dsGreenLeaf.Tables[0]);
                        myaclist.Database.Tables["GetSupplierPaymentForPaySlipThisMonthIssues"].SetDataSource(dsThisMonthIssues.Tables[0]);

                        ReportViewer myReportViewer = new ReportViewer();

                        myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                        myaclist.SetParameterValue("company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                        myaclist.SetParameterValue("factory", BoughtLeafBusinessLayer.BLUser.getFactoryName());
                        myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
                        myReportViewer.Show();
                    }
                    else if (radioButton1.Checked == true && radioButton1.Text == "Pre Printed")
                    {
                    
                        if (BoughtLeafBusinessLayer.BLUser.getCompanyCode().ToUpper() == "APL")
                        {
                            DataSet dsGeneral = new DataSet();

                            BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

                            dsGeneral = myReports.GetSupplierPaymentForPaySlipGeneral(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsGeneral.Tables[0].TableName = "GetSupplierPaymentForPaySlipGeneral";
                            //dataSetReport.WriteXml("PaymentSlip.xml");

                            DataSet dsGreenLeaf = myReports.GetSupplierPaymentForPaySlipGreenLeaf(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsGreenLeaf.Tables[0].TableName = "GetSupplierPaymentForPaySlipGreenLeaf";
                            // NewDt.WriteXml("DayGreenLeaf.xml");

                            DataSet dsThisMonthIssues = myReports.GetSupplierPaymentForPaySlipThisMonthIssues(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsThisMonthIssues.Tables[0].TableName = "GetSupplierPaymentForPaySlipThisMonthIssues";
                           
                            APLPayslipRPT myaclist = new APLPayslipRPT();

                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipGeneral"].SetDataSource(dsGeneral.Tables[0]);
                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipGreenLeaf"].SetDataSource(dsGreenLeaf.Tables[0]);
                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipThisMonthIssues"].SetDataSource(dsThisMonthIssues.Tables[0]);

                            ReportViewer myReportViewer = new ReportViewer();

                            myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                            myaclist.SetParameterValue("company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                            myaclist.SetParameterValue("factory", BoughtLeafBusinessLayer.BLUser.getFactoryName());
                            myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
                            myReportViewer.Show();
                        }
                        else if (BoughtLeafBusinessLayer.BLUser.getCompanyCode().ToUpper() == "KTFL")
                        {

                            DataSet dsGeneral = new DataSet();

                            BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

                            dsGeneral = myReports.GetSupplierPaymentForPaySlipGeneral(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsGeneral.Tables[0].TableName = "GetSupplierPaymentForPaySlipGeneral";
                            //dataSetReport.WriteXml("PaymentSlip.xml");

                            DataSet dsGreenLeaf = myReports.GetSupplierPaymentForPaySlipGreenLeaf(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsGreenLeaf.Tables[0].TableName = "GetSupplierPaymentForPaySlipGreenLeaf";
                            // NewDt.WriteXml("DayGreenLeaf.xml");

                            DataSet dsThisMonthIssues = myReports.GetSupplierPaymentForPaySlipThisMonthIssues(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsThisMonthIssues.Tables[0].TableName = "GetSupplierPaymentForPaySlipThisMonthIssues";
                            dsThisMonthIssues.WriteXml("ThisMonthIssuesXml.xml");
                            KTFLPayslip myaclist = new KTFLPayslip();

                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipGeneral"].SetDataSource(dsGeneral.Tables[0]);
                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipGreenLeaf"].SetDataSource(dsGreenLeaf.Tables[0]);
                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipThisMonthIssues"].SetDataSource(dsThisMonthIssues.Tables[0]);

                            ReportViewer myReportViewer = new ReportViewer();

                            myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                            //myaclist.SetParameterValue("company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                            // myaclist.SetParameterValue("factory", BoughtLeafBusinessLayer.BLUser.getFactoryName());
                            myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
                            myReportViewer.Show();
                        }
                        else if (BoughtLeafBusinessLayer.BLUser.getCompanyCode().ToUpper() == "BPL")
                        {
                            DataSet dsGeneral = new DataSet();

                            BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

                            dsGeneral = myReports.GetSupplierPaymentForPaySlipGeneral(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsGeneral.Tables[0].TableName = "GetSupplierPaymentForPaySlipGeneral";
                            //dataSetReport.WriteXml("PaymentSlip.xml");

                            DataSet dsGreenLeaf = myReports.GetSupplierPaymentForPaySlipGreenLeaf(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsGreenLeaf.Tables[0].TableName = "GetSupplierPaymentForPaySlipGreenLeaf";
                            // NewDt.WriteXml("DayGreenLeaf.xml");

                            DataSet dsThisMonthIssues = myReports.GetSupplierPaymentForPaySlipThisMonthIssues(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString());
                            dsThisMonthIssues.Tables[0].TableName = "GetSupplierPaymentForPaySlipThisMonthIssues";

                            BalangodaPayslipRPT myaclist = new BalangodaPayslipRPT();

                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipGeneral"].SetDataSource(dsGeneral.Tables[0]);
                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipGreenLeaf"].SetDataSource(dsGreenLeaf.Tables[0]);
                            myaclist.Database.Tables["GetSupplierPaymentForPaySlipThisMonthIssues"].SetDataSource(dsThisMonthIssues.Tables[0]);

                            ReportViewer myReportViewer = new ReportViewer();

                            myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                            myaclist.SetParameterValue("company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                            myaclist.SetParameterValue("factory", BoughtLeafBusinessLayer.BLUser.getFactoryName());
                            myReportViewer.crystalReportViewer1.DisplayGroupTree = true;
                            myReportViewer.Show();
                        }
                    }
                }
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
                cmbMonth.SelectedValue = DateTime.Now.Month;
            }
            catch { }
        }
    }
}