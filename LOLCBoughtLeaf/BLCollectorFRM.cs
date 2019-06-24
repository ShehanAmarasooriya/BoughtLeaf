using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLCollectorFRM : Form
    {
        BoughtLeafBusinessLayer.BLCollector collectorObj = new BoughtLeafBusinessLayer.BLCollector();
        public BLCollectorFRM()
        {
            InitializeComponent();
        }

        private void CollectorFRM_Load(object sender, EventArgs e)
        {
            btnClear.PerformClick();
        }

        private void assignController()
        {
            collectorObj.CollectorCode = txtColCode.Text.Trim().ToUpper();
            collectorObj.CollectorName = txtColName.Text.Trim().ToUpper();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtColCode.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtColCode, "Fill Collector Code");
                }
                else if (txtColName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtColName, "Fill Collector Name");
                }
                else
                {
                    assignController();
                    collectorObj.insertCollector();
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
                if (txtColName.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtColName, "Fill Collector Name");
                }
                else
                {
                    assignController();
                    collectorObj.updateCollector();
                    MessageBox.Show("Successfully Upadated");
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (collectorObj.checkCanDelete(txtColCode.Text) == 0)
            {
                if (MessageBox.Show("Press OK to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    assignController();
                    collectorObj.deleteCollector();
                    MessageBox.Show("Successfully Deleted");
                    btnClear.PerformClick();
                }
            }
            else
                MessageBox.Show("This Collector Is Currently Used In System.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = collectorObj.getCollectors();
            txtColCode.Clear();
            txtColName.Clear();
            txtColCode.Enabled = true;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtColCode.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            txtColCode.Text = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtColName.Text = dgvMain.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

        }
    }
}