using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLJournalAccountConfiguration : Form
    {
        BoughtLeafBusinessLayer.ClsBLAccountConfiguration objACConfig = new BoughtLeafBusinessLayer.ClsBLAccountConfiguration();

        public BLJournalAccountConfiguration()
        {
            InitializeComponent();
        }

        private void BLJournalAccountConfiguration_Load(object sender, EventArgs e)
        {
            //Leaf Type Accounts
            gvLeafTypeAC.DataSource = objACConfig.ListBLLeafTypeAccounts().Tables[0];
            //BL Settings Accounts
            gvSettingsAC.DataSource = objACConfig.ListBLMasterSettings().Tables[0];
            //GL General Accounts
            gvBLGeneralAccounts.DataSource = objACConfig.ListBLLeafGeneralAccounts().Tables[0];
            //BL Deduction Accounts
            gvDeductionACs.DataSource = objACConfig.ListDeductionAccounts().Tables[0];
        }

        private void btnSaveLTAC_Click(object sender, EventArgs e)
        {
            Boolean boolSuccess = true;
            for (int i = 0; i < gvLeafTypeAC.Rows.Count; i++)
            {
                try
                {
                    objACConfig.SaveBLLeafTypeAccounts(gvLeafTypeAC.Rows[i].Cells[0].Value.ToString(), gvLeafTypeAC.Rows[i].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {
                    boolSuccess = false;
                    MessageBox.Show("Error On Account Saving Of Leaf Type- " + gvLeafTypeAC.Rows[i].Cells[0].Value.ToString()+"Account, "+ ex.Message);
                }
            }
            if (boolSuccess)
            {
                MessageBox.Show("Leaf Type Accounts Configured Successfully");
            }
            else
            {
                MessageBox.Show("Configuration Failed..");
            }
        }

        private void btnSaveSettingsAC_Click(object sender, EventArgs e)
        {
            Boolean boolSuccess = true;
            for (int i = 0; i < gvSettingsAC.Rows.Count; i++)
            {
                try
                {
                    objACConfig.SaveBLMasterSettings(gvSettingsAC.Rows[i].Cells[1].Value.ToString(), gvSettingsAC.Rows[i].Cells[0].Value.ToString(), gvSettingsAC.Rows[i].Cells[2].Value.ToString());
                }
                catch (Exception ex)
                {
                    boolSuccess = false;
                    MessageBox.Show("Error On Account Saving Of Settings- " + gvSettingsAC.Rows[i].Cells[0].Value.ToString() +"-"+ gvSettingsAC.Rows[i].Cells[1].Value.ToString() + "Account, " + ex.Message);
                }
            }
            if (boolSuccess)
            {
                MessageBox.Show("Settings Accounts Configured Successfully");
            }
            else
            {
                MessageBox.Show("Configuration Failed..");
            }
        }

        
        private void btnSaveGeneralAC_Click(object sender, EventArgs e)
        {
            Boolean boolSuccess = true;
            for (int i = 0; i < gvBLGeneralAccounts.Rows.Count; i++)
            {
                try
                {
                    objACConfig.StrGreenLeaf = gvBLGeneralAccounts.Rows[i].Cells[0].Value.ToString();
                    objACConfig.StrOtherAddition = gvBLGeneralAccounts.Rows[i].Cells[1].Value.ToString();
                    objACConfig.StrIncentive = gvBLGeneralAccounts.Rows[i].Cells[2].Value.ToString();
                    objACConfig.StrLeafQualityIncen = gvBLGeneralAccounts.Rows[i].Cells[3].Value.ToString();
                    objACConfig.StrTransportIncen = gvBLGeneralAccounts.Rows[i].Cells[4].Value.ToString();
                    objACConfig.StrElevationIncen = gvBLGeneralAccounts.Rows[i].Cells[5].Value.ToString();
                    objACConfig.StrSlabIncen = gvBLGeneralAccounts.Rows[i].Cells[6].Value.ToString();
                    objACConfig.StrBFCoin = gvBLGeneralAccounts.Rows[i].Cells[7].Value.ToString();
                    objACConfig.StrFertilizer = gvBLGeneralAccounts.Rows[i].Cells[8].Value.ToString();
                    objACConfig.StrTransportDeduction = gvBLGeneralAccounts.Rows[i].Cells[9].Value.ToString();
                    objACConfig.StrLoans = gvBLGeneralAccounts.Rows[i].Cells[10].Value.ToString();
                    objACConfig.StrCashAdvance = gvBLGeneralAccounts.Rows[i].Cells[11].Value.ToString();
                    objACConfig.StrTeaAllowance = gvBLGeneralAccounts.Rows[i].Cells[12].Value.ToString();
                    objACConfig.StrPayslip = gvBLGeneralAccounts.Rows[i].Cells[13].Value.ToString();
                    objACConfig.StrStampDuty = gvBLGeneralAccounts.Rows[i].Cells[14].Value.ToString();
                    objACConfig.StrOtherDeduction = gvBLGeneralAccounts.Rows[i].Cells[15].Value.ToString();
                    objACConfig.StrBFDebt = gvBLGeneralAccounts.Rows[i].Cells[16].Value.ToString();
                    objACConfig.StrCFDebtBalance = gvBLGeneralAccounts.Rows[i].Cells[17].Value.ToString();
                    objACConfig.SaveBLLeafGeneralAccounts();
                }
                catch (Exception ex)
                {
                    boolSuccess = false;
                    MessageBox.Show("Error On General Account Saving - " + ex.Message);
                }
            }
            if (boolSuccess)
            {
                MessageBox.Show("General Accounts Configured Successfully");
            }
            else
            {
                MessageBox.Show("General Accounts Configuration Failed..");
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            btnSaveLTAC.PerformClick();
            btnSaveSettingsAC.PerformClick();
            btnSaveGeneralAC.PerformClick();
            btnSaveDeductions.PerformClick();

        }

        private void btnSaveDeductions_Click(object sender, EventArgs e)
        {
            Boolean boolSuccess = true;
            for (int i = 0; i < gvDeductionACs.Rows.Count; i++)
            {
                try
                {
                    
                    objACConfig.SaveBLDeductionAccounts(gvDeductionACs.Rows[i].Cells[2].Value.ToString(), gvDeductionACs.Rows[i].Cells[0].Value.ToString(), gvDeductionACs.Rows[i].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {
                    boolSuccess = false;
                    MessageBox.Show("Error On Deduction Account Saving - " + ex.Message);
                }
            }
            if (boolSuccess)
            {
                MessageBox.Show("Deduction Accounts Configured Successfully");
            }
            else
            {
                MessageBox.Show("Deduction Accounts Configuration Failed..");
            }
        }

    }
}