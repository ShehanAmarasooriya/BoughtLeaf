using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace OLAXBoughtLeaf
{
    public partial class BLBankBranchFRM : Form
    {
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();
        BoughtLeafBusinessLayer.BLBankBranch myBranch = new BoughtLeafBusinessLayer.BLBankBranch();

        public BLBankBranchFRM()
        {
            InitializeComponent();
        }

        private void Branch_Load(object sender, EventArgs e)
        {
            cmbBank.SelectedIndexChanged -= new EventHandler(cmbBank_SelectedIndexChanged);
            cmbBank.DataSource = myBank.ListBankDetails();
            cmbBank.DisplayMember = "BankName";
            cmbBank.ValueMember = "BankCode";
            cmbBank.SelectedIndexChanged += new EventHandler(cmbBank_SelectedIndexChanged);
            btnClear.PerformClick();
        }

        private void gvlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBranchCode.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtBranchCode.Text = gvlist.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBranchName.Text = gvlist.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbBank.SelectedValue = gvlist.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void valueAssign() 
        {
            myBranch.BankCode = cmbBank.SelectedValue.ToString();
            myBranch.BranchCode = myBranch.BankCode + '-' + txtBranchCode.Text.ToUpper();
            myBranch.BranchName = txtBranchName.Text.ToUpper();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBranchCode.Text.Trim() == "")
                {
                    errorProvider.SetError(txtBranchCode, "Fill Branch Code");
                }
                else if (txtBranchName.Text.Trim() == "")
                {
                    errorProvider.SetError(txtBranchName, "Fill Branch Name");
                }
                else
                {
                    valueAssign();
                    myBranch.InsertBankBranch();
                    MessageBox.Show("Branch Added Successful...!");
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
                if (txtBranchCode.Text.Trim() == "")
                {
                    errorProvider.SetError(txtBranchCode, "Fill Branch Code");
                }
                else if (txtBranchName.Text.Trim() == "")
                {
                    errorProvider.SetError(txtBranchName, "Fill Branch Name");
                }
                else
                {
                    if (MessageBox.Show("Confirm Delete...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        myBranch.BankCode = cmbBank.SelectedValue.ToString();
                        myBranch.BranchCode = txtBranchCode.Text;
                        myBranch.BranchName = txtBranchName.Text.ToUpper();

                        //valueAssign();
                        myBranch.DeleteBranch();
                        MessageBox.Show("Branch Deleted Successful...!");
                        btnClear.PerformClick();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBranchCode.Text.Trim() == "")
                {
                    errorProvider.SetError(txtBranchCode, "Fill Branch Code");
                }
                else if (txtBranchName.Text.Trim() == "")
                {
                    errorProvider.SetError(txtBranchName, "Fill Branch Name");
                }
                else
                {
                    myBranch.BankCode = cmbBank.SelectedValue.ToString();
                    myBranch.BranchCode = txtBranchCode.Text;
                    myBranch.BranchName = txtBranchName.Text.ToUpper();

                    //valueAssign();
                    myBranch.UpdateBranch();
                    MessageBox.Show("Branch Updated Successful...!");
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBranchCode.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            cmbBank.SelectedIndex = 0;
            txtBranchName.Clear();
            txtBranchCode.Clear();
            gvlist.DataSource = myBranch.ListBranchDetails(cmbBank.SelectedValue.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBranchCode_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtBranchCode, null);
        }

        private void txtBranchName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtBranchName, null);
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvlist.DataSource = myBranch.ListBranchDetails(cmbBank.SelectedValue.ToString());
        }
    }
}