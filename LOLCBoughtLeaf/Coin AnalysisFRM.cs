using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BoughtLeafBusinessLayer;

namespace OLAXBoughtLeaf
{
    public partial class Coin_Analysis : Form
    {
   
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();

        public Coin_Analysis()
        {
            InitializeComponent();
        }

        private void Coin_Analysis_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = DateTime.Now.Year.ToString();

            cmbYear_SelectedIndexChanged(null, null);

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (allCheck.Checked)
            {
                
                try
                {
                  
                    //int chkresult = ChkNotes.CheckState == CheckState.Checked ? 1 : 0;
                    
                    DataTable dt = new DataTable();
                    //BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                    //myReports.Note = Convert.ToInt32(ChkNotes.CheckState == CheckState.Checked ? 1 : 0).ToString();
                    dt = myReports.getCashAmountAll(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), ChkNotes.CheckState == CheckState.Checked ? 1 : 0);     
                    dt.TableName = "Coin";                    
                    dt.WriteXml("CoinAnalysis.xml");
                    CoinAnalysisRPT myaclist = new CoinAnalysisRPT();
                    myaclist.SetDataSource(dt);
                    ReportViewer myReportViewer = new ReportViewer();
                    myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                    myaclist.SetParameterValue("Period", "Period : " + cmbYear.Text + " / " + cmbMonth.Text);
                    myaclist.SetParameterValue("Route", "ALL");
                    myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                    myReportViewer.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }
            else 
            {
                try
                {
                    DataTable dt = new DataTable();
                    BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
                    dt = myReports.getCashAmount(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), (cmbRoute.SelectedValue.ToString()), ChkNotes.CheckState == CheckState.Checked ? 1 : 0);
                    //dt.Columns.Add(cmbRoute.Text.ToString());
                    dt.TableName = "Coin";
                    dt.WriteXml("CoinAnalysis.xml");
                    CoinAnalysisRPT myaclist = new CoinAnalysisRPT();
                    myaclist.SetDataSource(dt);
                    ReportViewer myReportViewer = new ReportViewer();
                    myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                    myaclist.SetParameterValue("Period", "Period : " + cmbYear.Text + " / " + cmbMonth.Text);
                    myaclist.SetParameterValue("Route", cmbRoute.Text.ToString());
                    myReportViewer.crystalReportViewer1.ReportSource = myaclist;
                    myReportViewer.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
 
            }
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

        private void ChkNotes_CheckedChanged(object sender, EventArgs e)
        {
            //myReports.Note = Convert.ToInt32(ChkNotes.CheckState == CheckState.Checked ? 2000 : 0).ToString();
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