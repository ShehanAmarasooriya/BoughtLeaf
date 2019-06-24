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
    public partial class LoginFRM : Form
    {
        BoughtLeafBusinessLayer.BLUser myUser = new BoughtLeafBusinessLayer.BLUser();
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.MonthlyProcess oMonthlyProcess = new BoughtLeafBusinessLayer.MonthlyProcess();

        public LoginFRM()
        {
            InitializeComponent();
        }
        public static string month_log = "";
        private void Login_Load(object sender, EventArgs e)
        {
            //OlaxToolsSet.SystemInformation SI = new OlaxToolsSet.SystemInformation();
            //SI.dbServer = @"ISURU-DELL\SQL2014";
            //SI.dbUserId = "sa";
            //SI.dbPassWord = "pass1234";
            //SI.module = "Bought Leaf";
            //SI.latestVersion = "1.0.0.0";

            //OlaxToolsSet.VersionUpdateManage.updateSystem(SI);
            ////OlaxToolsSet.VersionUpdateManage.validateVersion(SI);
            //this.Text = OlaxToolsSet.VersionUpdateManage.getCurrentVersion(SI);
           
            DataTable dtLastYearMonth = new DataTable();
            dtLastYearMonth = myYear.ListLastYearMonth();

            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.SelectedValue = DateTime.Now.Year;
            cmbYear.SelectedValue = dtLastYearMonth.Rows[0][0].ToString();
            

            cmbMonth.DataSource = myYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";
            cmbMonth.SelectedValue = DateTime.Now.Month;
            cmbMonth.SelectedValue = dtLastYearMonth.Rows[0][1].ToString();
            month_log = dtLastYearMonth.Rows[0][1].ToString();
         

            if (cmbMonth.Items.Count == 0)
            {
                oMonthlyProcess.UpdateMonthProcessToNewYear();
            }
            txtUserName.Focus();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            BoughtLeafBusinessLayer.BLUser.StrUserName = txtUserName.Text;
            BoughtLeafBusinessLayer.BLUser.StrUserPassword = txtPassword.Text;
            BoughtLeafBusinessLayer.BLUser.strMonthID = cmbMonth.SelectedValue.ToString();
            BoughtLeafBusinessLayer.BLUser.StrYear = cmbYear.Text;

            if (myUser.checkValidUser(myUser) == true)
            {
                MainForm myMainForm = new MainForm();
                myMainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid User Details...!");
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdLogin.PerformClick();
            }
        }

        private void cmbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmbMonth.Focus();
        }

        private void cmbMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtUserName.Focus();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}