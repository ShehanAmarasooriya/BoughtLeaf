using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLBankFRM : Form
    {
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();

        public BLBankFRM()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bank_Load(object sender, EventArgs e)
        {
            btnClear.PerformClick();
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCode.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;

                txtCode.Text = gvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = gvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void valueAssign()
        {
            myBank.StrBankCode = txtCode.Text;
            myBank.StrBankName = txtName.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtCode, "Fill Bank Code");
                }
                else if (txtName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtName, "Fill Bank Name");
                }
                else
                {
                    valueAssign();
                    myBank.InsertBank();
                    MessageBox.Show("Successfully Inserted...!");
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtCode, "Fill Bank Code");
                }
                else if (txtName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtName, "Fill Bank Name");
                }
                else
                {
                    valueAssign();
                    myBank.UpdateBank();
                    btnClear.PerformClick();
                    MessageBox.Show("Successfully Updated...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            txtCode.Clear();
            txtName.Clear();
            gvList.DataSource = myBank.ListBankDetails();
            gvList.Columns[2].Width = 170;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Delete...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myBank.StrBankCode = txtCode.Text;
                    myBank.DeleteBank();
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtCode, null);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtName, null);
        }
    }
}