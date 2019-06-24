using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLDeductionGroupFRM : Form
    {
        BoughtLeafBusinessLayer.BLDeductionGroup DeductionGrp = new BoughtLeafBusinessLayer.BLDeductionGroup();

        public BLDeductionGroupFRM()
        {
            InitializeComponent();
        }

        private void DeductionGroupFRM_Load(object sender, EventArgs e)
        {
            btnClear.PerformClick();
        }

        private void AssignVariables()
        {
            DeductionGrp.StrDeductionGroupCode = txtDeducGroupCode.Text.Trim().ToUpper();
            DeductionGrp.StrGroupName = txtGroupName.Text.ToUpper();
            DeductionGrp.StrPriority = Convert.ToInt32(nudPriority.Value);
            DeductionGrp.StrGroupType = cmbGroupType.SelectedItem.ToString();
            DeductionGrp.BoolDeductAmnt = chkDeductAmnt.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeducGroupCode.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtDeducGroupCode, "Fill Deduction Group Code");
                }
                else if (txtGroupName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtGroupName, "Fill Deduction Group Name");
                }
                else
                {
                    this.AssignVariables();
                    DeductionGrp.AddDeductionGroup();
                    MessageBox.Show("Successfully Added");
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGroupName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtGroupName, "Fill Deduction Group Name");
                }
                else
                {
                    this.AssignVariables();
                    DeductionGrp.UpdateDeductionGroup();
                    MessageBox.Show("Successfully Updated");

                    btnClear.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeductionGrp.checkDeductionGroupInDeductoinCode(txtDeducGroupCode.Text) == 0)
            {
                if (MessageBox.Show("Press OK to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    try
                    {
                        DeductionGrp.StrDeductionGroupCode = txtDeducGroupCode.Text.Trim().ToUpper();
                        DeductionGrp.DeleteDeductionGroup();
                        MessageBox.Show("Successfully Deleted");
                        btnClear.PerformClick();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }else
                MessageBox.Show("This Deduct Group Is Currently Use In System !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDeducGroupCode.Clear();
            txtGroupName.Clear();
            cmbGroupType.SelectedIndex = 0;
            nudPriority.Text = "0";

            txtDeducGroupCode.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            chkDeductAmnt.Checked = false;
            dgvDeductionGroup.DataSource = DeductionGrp.ViewAllDeductionGroup();
        }

        private void dgvDeductionGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtDeducGroupCode.Text = dgvDeductionGroup.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtGroupName.Text = dgvDeductionGroup.Rows[e.RowIndex].Cells[1].Value.ToString();
                nudPriority.Text = dgvDeductionGroup.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbGroupType.Text = dgvDeductionGroup.Rows[e.RowIndex].Cells[4].Value.ToString();
                chkDeductAmnt.Checked = Convert.ToBoolean(dgvDeductionGroup.Rows[e.RowIndex].Cells[5].Value);
                txtDeducGroupCode.Enabled = false;
                btnClear.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        private void txtDeducGroupCode_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtDeducGroupCode, null);
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtGroupName, null);
        }

        private void cmbGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}