using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace OLAXBoughtLeaf
{
    public partial class BLMonthlySettingsFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myFinancialYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLMonthlySettings mySettings = new BoughtLeafBusinessLayer.BLMonthlySettings();
        BoughtLeafBusinessLayer.BLSettings ObjBLSettings = new BoughtLeafBusinessLayer.BLSettings();

        public BLMonthlySettingsFRM()
        {
            InitializeComponent();
        }

        private void MonthlySettings_Load(object sender, EventArgs e)
        {            
            cmbYear.DataSource = myFinancialYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";

            cmbMonth.DataSource = myFinancialYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";


            dgvMain.DataSource = mySettings.ListSettings();

            cmbYear.SelectedValue = DateTime.Now.Year.ToString();
            cmbMonth.SelectedValue = DateTime.Now.Month.ToString();

            RefreshLeafTypeRatesGrid();

            btnClear.PerformClick();
        }

        private void RefreshLeafTypeRatesGrid()
        {
            try
            {
                gvLeafTypeRates.DataSource = ObjBLSettings.ListBLMasterRates("LeafQuality");
                gvLeafTypeRates.Columns[0].ReadOnly = true;
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsBLMasterRates=new DataSet();
                if (txtPerKiloRate.Text.Trim() == "")
                {
                    errorProvider.SetError(txtPerKiloRate, "Fill Per Kilo Rate");
                }
                else
                {
                    mySettings.IntYear = Convert.ToInt32(cmbYear.SelectedValue);
                    mySettings.IntMonth = Convert.ToInt32(cmbMonth.SelectedValue);
                    mySettings.DecKiloRate = Convert.ToDecimal(txtPerKiloRate.Text);
                    if (!mySettings.IsMonthlySettingsAvailable(mySettings.IntYear, mySettings.IntMonth))
                    {
                        mySettings.InsertSettings();
                    }
                    else
                    {
                        MessageBox.Show("Month Per Kilo Rate Already Exists");
                    }

                    UpdateLeafTypeRates();

                    btnClear.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void UpdateLeafTypeRates()
        {
            Boolean boolSuccess = true;
            for (Int32 i = 0; i <= gvLeafTypeRates.Rows.Count - 1; i++)
            {
                if (!Regex.IsMatch(gvLeafTypeRates.Rows[i].Cells[1].Value.ToString(), @"^\d*\.?\d*$"))
                {
                    boolSuccess = false;
                    MessageBox.Show("Leaf Type " + gvLeafTypeRates.Rows[i].Cells[0].Value.ToString() + " Amount Is Invalid");
                    break;
                }
                else
                {
                    ObjBLSettings.UpdateBLMonthlySetting("LeafQuality", gvLeafTypeRates.Rows[i].Cells[0].Value.ToString(), Convert.ToDecimal(gvLeafTypeRates.Rows[i].Cells[1].Value.ToString()));
                    //MessageBox.Show("Leaf Type Rates Updated Successfully...!");
                }
            }
            if (boolSuccess)
            {
                MessageBox.Show("Leaf Type Rates Updated Successfully...!");
            }
            else
            {
                MessageBox.Show("Leaf Type Rates Updated With Errors");
            }

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPerKiloRate.Text.Trim() == "")
                {
                    errorProvider.SetError(txtPerKiloRate, "Fill Per Kilo Rate");
                }
                else
                {

                    mySettings.IntYear = Convert.ToInt32(cmbYear.SelectedValue);
                    mySettings.IntMonth = Convert.ToInt32(cmbMonth.SelectedValue);
                    mySettings.DecKiloRate = Convert.ToDecimal(txtPerKiloRate.Text);
                    //mySettings.DecGLPerKg = Convert.ToDecimal(txtGLAddition.Text);

                    mySettings.UpdateSettings();
                    UpdateLeafTypeRates();
                    MessageBox.Show("Settings Updated Successfully...!");
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void txtPerKiloRate_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPerKiloRate.Clear();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            dgvMain.DataSource = mySettings.ListSettings();
            RefreshLeafTypeRatesGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    cmbYear.SelectedValue = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
                    cmbMonth.SelectedValue = dgvMain.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtPerKiloRate.Text = dgvMain.Rows[e.RowIndex].Cells[2].Value.ToString();
                    //txtGLAddition.Text = dgvMain.Rows[e.RowIndex].Cells[3].Value.ToString();
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                catch { }
            }
        }
    }
}