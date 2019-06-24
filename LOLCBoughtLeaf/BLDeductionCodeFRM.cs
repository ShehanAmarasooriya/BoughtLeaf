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
    public partial class BLDeductionCodeFRM : Form
    {

        BoughtLeafBusinessLayer.BLDeductionCode Deduct = new BoughtLeafBusinessLayer.BLDeductionCode();
        BoughtLeafBusinessLayer.BLDeductionGroup DeductGroupMaster = new BoughtLeafBusinessLayer.BLDeductionGroup();
        public BLDeductionCodeFRM()
        {
            InitializeComponent();
        }

        private void Deduction_Load(object sender, EventArgs e)
        {
            cmbDeductGroupCode.SelectedIndexChanged -= new EventHandler(cmbDeductGroupCode_SelectedIndexChanged);
            cmbDeductGroupCode.DataSource = DeductGroupMaster.LoadComboboxGroupCode();
            cmbDeductGroupCode.DisplayMember = "GroupName";
            cmbDeductGroupCode.ValueMember = "GroupCode";
            cmbDeductGroupCode.SelectedIndexChanged += new EventHandler(cmbDeductGroupCode_SelectedIndexChanged);
            cmbDeductGroupCode_SelectedIndexChanged(null, null);
            btnClear.PerformClick();
        }

        private void enableDeductAmountCommissionController()
        {
            if (DeductGroupMaster.statusOfDeductAmnt(cmbDeductGroupCode.SelectedValue.ToString()))
            {
                txtDeductAmount.Enabled = true;
                txtCommissionAmount.Enabled = true;
            }
            else
            {
                txtDeductAmount.Enabled = false;
                txtCommissionAmount.Enabled = false;
            }
        }


        private void valueAssign()
        {
            Deduct.StrDeductionCode = txtDeductionCode.Text.ToUpper();
            Deduct.StrDeductionName = txtDeductionName.Text.ToUpper();
            Deduct.StrDeductionPriority = Convert.ToInt32(nudPriority.Value);
            Deduct.StrDeductionAccountCode = txtAccountCode.Text;
            Deduct.StrDeductionGroupCode = cmbDeductGroupCode.SelectedValue.ToString();
            Deduct.StrDeductionUntillStop = chkDeductionUntilStop.Checked;

            if (txtDeductAmount.Enabled)
            {
                Deduct.DeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                Deduct.CommissionAmount = Convert.ToDecimal(txtCommissionAmount.Text);
            }
            else
            {
                Deduct.DeductAmount = 0;
                Deduct.CommissionAmount = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeductionCode.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtDeductionCode, "Fill Deduction Code");
                }
                else if (txtDeductionName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtDeductionName, "Fill Deduction Name");
                }
                else if (txtAccountCode.Text.Trim() == string.Empty)
                {
                    txtAccountCode.Text = "NA";
                }
                else if (txtDeductAmount.Enabled && txtAccountCode.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtDeductionName, "Fill Deduction Amount");
                }
                else
                {
                    valueAssign();
                    Deduct.AddDeduction();
                    MessageBox.Show("Successfully Added !");

                    //btnClear.PerformClick();

             
                    txtDeductionCode.Text = string.Empty;
                    txtDeductionName.Text = string.Empty;
                    txtDeductAmount.Text = "0";
                    txtCommissionAmount.Text = "0";
                    nudPriority.Text = "0";
                    txtAccountCode.Text = " NA";
                    chkDeductionUntilStop.Checked = false;
                    dgvDeduction.DataSource = Deduct.ViewAllDeductionByGroup(cmbDeductGroupCode.SelectedValue.ToString());

                   
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeductionCode.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtDeductionCode, "Fill Deduction Code");
                }
                else if (txtDeductionName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtDeductionName, "Fill Deduction Name");
                }
                else if (txtAccountCode.Text.Trim() == string.Empty)
                {
                    txtAccountCode.Text = "NA";
                }
                else
                {
                    valueAssign();
                    Deduct.UpdateDeduction();
                    MessageBox.Show("Successfully Updated !");

                    //btnClear.PerformClick();

                    txtDeductionCode.Text = string.Empty;
                    txtDeductionName.Text = string.Empty;
                    txtDeductAmount.Text = "0";
                    txtCommissionAmount.Text = "0";
                    nudPriority.Text = "0";
                    txtAccountCode.Text = " NA";
                    chkDeductionUntilStop.Checked = false;
                    dgvDeduction.DataSource = Deduct.ViewAllDeductionByGroup(cmbDeductGroupCode.SelectedValue.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Deduct.checkDeductionCodeInDeductoinTRN(txtDeductionCode.Text) == 0)
            {

                if (MessageBox.Show("Press OK to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    try
                    {
                        if (txtDeductionCode.Text.Trim() == "")
                        {
                            errorProvider.SetError(txtDeductionCode, "Please Fill Deduction Code");
                        }
                        else
                        {
                            Deduct.StrDeductionCode = txtDeductionCode.Text;
                            Deduct.DeleteDeduction();
                            MessageBox.Show("Successfully Deleted !");

                            //btnClear.PerformClick();

                            txtDeductionCode.Text = string.Empty;
                            txtDeductionName.Text = string.Empty;
                            txtDeductAmount.Text = "0";
                            txtCommissionAmount.Text = "0";
                            nudPriority.Text = "0";
                            txtAccountCode.Text = " NA";
                            chkDeductionUntilStop.Checked = false;
                            dgvDeduction.DataSource = Deduct.ViewAllDeductionByGroup(cmbDeductGroupCode.SelectedValue.ToString());
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }
            else
                MessageBox.Show("Deduct Code Is Currently In Use..!", "Cannot Delete..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDeduction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    txtDeductionCode.Text = dgvDeduction.Rows[e.RowIndex].Cells[0].Value.ToString();

            //    txtDeductionName.Text = dgvDeduction.Rows[e.RowIndex].Cells[1].Value.ToString();

            //    txtDeductAmount.Text = dgvDeduction.Rows[e.RowIndex].Cells[9].Value.ToString();

            //    txtCommissionAmount.Text = dgvDeduction.Rows[e.RowIndex].Cells[10].Value.ToString();

            //    nudPriority.Text = dgvDeduction.Rows[e.RowIndex].Cells[2].Value.ToString();

            //    txtAccountCode.Text = dgvDeduction.Rows[e.RowIndex].Cells[3].Value.ToString();

            //    if (Convert.ToBoolean(dgvDeduction.Rows[e.RowIndex].Cells[5].Value))
            //        chkDeductionUntilStop.Checked = true;
            //    else
            //        chkDeductionUntilStop.Checked = false;

            //    btnAdd.Enabled = false;
            //    btnDelete.Enabled = true;
            //    btnUpdate.Enabled = true;
            //    cmbDeductGroupCode.Enabled = false;
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDeductGroupCode.SelectedIndex = 0;
            txtDeductionCode.Text = string.Empty;
            txtDeductionName.Text = string.Empty;
            txtDeductAmount.Text = "0";
            txtCommissionAmount.Text = "0";
            nudPriority.Text = "0";
            txtAccountCode.Text = " NA";
            chkDeductionUntilStop.Checked = false;
            dgvDeduction.DataSource = Deduct.ViewAllDeductionByGroup(cmbDeductGroupCode.SelectedValue.ToString());

            txtDeductionCode.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            cmbDeductGroupCode.Enabled = true;
        }

        private void txtDeductionCode_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtDeductionCode, null);
        }

        private void txtDeductionName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtDeductionName, null);
        }

        private void cmbDeductGroupCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDeductAmountCommissionController();
            dgvDeduction.DataSource = Deduct.ViewAllDeductionByGroup(cmbDeductGroupCode.SelectedValue.ToString());
        }

        private void dgvDeduction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDeductionCode.Enabled = false;

            if (e.RowIndex >= 0)
            {
                txtDeductionCode.Text = dgvDeduction.Rows[e.RowIndex].Cells[0].Value.ToString();

                txtDeductionName.Text = dgvDeduction.Rows[e.RowIndex].Cells[1].Value.ToString();

                txtDeductAmount.Text = dgvDeduction.Rows[e.RowIndex].Cells[9].Value.ToString();

                txtCommissionAmount.Text = dgvDeduction.Rows[e.RowIndex].Cells[10].Value.ToString();

                nudPriority.Text = dgvDeduction.Rows[e.RowIndex].Cells[2].Value.ToString();

                txtAccountCode.Text = dgvDeduction.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (Convert.ToBoolean(dgvDeduction.Rows[e.RowIndex].Cells[5].Value))
                    chkDeductionUntilStop.Checked = true;
                else
                    chkDeductionUntilStop.Checked = false;

                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                cmbDeductGroupCode.Enabled = false;
            }
        }
    }
}