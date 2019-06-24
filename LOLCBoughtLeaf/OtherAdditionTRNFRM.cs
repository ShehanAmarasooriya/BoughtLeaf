using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class OtherAdditionTRNFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.OtherAdditions myAdditions = new BoughtLeafBusinessLayer.OtherAdditions();

        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        public OtherAdditionTRNFRM()
        {
            InitializeComponent();
        }

        private void OtherAddition_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = BoughtLeafBusinessLayer.BLUser.StrYear;

            cmbMonth.DataSource = myYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";
            cmbMonth.SelectedValue = BoughtLeafBusinessLayer.BLUser.strMonthID;

            btnClear.PerformClick();
        }

        //sacchintha udara add new method for change supplier code with four zero prefix
        // 1 is like 0001
        private string supCodeChange(string pSupCode)
        {
            //return pSupCode.PadLeft(5, '0');
            return pSupCode;
        }

        private void txtSupplierCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string locSupCode = supCodeChange(txtSupplierCode.Text);

                lblSupplierName.Text = mySupplier.getSupplierName(locSupCode);
                txtSupplierCode.Text = locSupCode;
                if (lblSupplierName.Text == "NA")
                    MessageBox.Show("Supplier Not Found !");
                else
                    txtValue.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierCode.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please Enter Supplier Code !");
                }
                else if (txtValue.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please Enter Payment Amount !");
                }
                else
                {
                    myAdditions.InsertAdditions(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), supCodeChange(txtSupplierCode.Text), Convert.ToDecimal(txtValue.Text), txtRemarks.Text, mySupplier.getSupplierRoute(txtSupplierCode.Text));
                    MessageBox.Show("Addition Successfully Added !");

                    btnClear.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierCode.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please Enter Supplier Code !");
                }
                else if (txtValue.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please Enter Payment Amount !");
                }
                else
                {
                    myAdditions.UpdateAdditions(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), supCodeChange(txtSupplierCode.Text), Convert.ToDecimal(txtValue.Text), txtRemarks.Text);
                    MessageBox.Show("Addition Successfully Added !");

                    btnClear.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierCode.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please Enter Supplier Code !");
                }
                else
                {
                    if (MessageBox.Show("Press OK to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        myAdditions.DeleteAdditions(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue.ToString()), supCodeChange(txtSupplierCode.Text));
                        MessageBox.Show("Addition Successfully Deleted !");

                        btnClear.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            txtSupplierCode.Enabled = true;

            txtRemarks.Text = "NA";
            txtValue.Clear();
            txtSupplierCode.Clear();
            lblSupplierName.Text = "Supplier Name";

            gvList.DataSource = myAdditions.ListAdditions(Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.StrYear), Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.strMonthID));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbYear.SelectedValue = gvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbMonth.SelectedValue = gvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSupplierCode.Text = gvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            lblSupplierName.Text = gvList.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtValue.Text = gvList.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtRemarks.Text = gvList.Rows[e.RowIndex].Cells[5].Value.ToString();

            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            txtSupplierCode.Enabled = false;
        }

        private void txtSupplierCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}