using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLTransportCostFRM : Form
    {
        BoughtLeafBusinessLayer.BLTransportCost oTransportCost = new BoughtLeafBusinessLayer.BLTransportCost();

        public BLTransportCostFRM()
        {
            InitializeComponent();
        }

        private void TransportCost_Load(object sender, EventArgs e)
        {
            dgvMain.DataSource = oTransportCost.getTransportCost();
            dgvMain.Columns[2].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                errorProvider.SetError(txtCode, "Fill Transport Code");
            }
            else if (txtCost.Text.Trim() == "")
            {
                errorProvider.SetError(txtCost, "Fill Transport Cost");
            }
            else if (txtGLAccntNo.Text.Trim() == "")
            {
                errorProvider.SetError(txtGLAccntNo, "Fill GL Account No");
            }
            else
            {
                try
                {
                    valueAssign();
                    oTransportCost.InsertTransportCost();
                    MessageBox.Show("Insert Successfully...!");
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                ControllerClear();
            }
        }

        private void ControllerClear()
        {
            txtCode.Clear();
            txtCost.Clear();
            txtGLAccntNo.Clear();
            dgvMain.DataSource = oTransportCost.getTransportCost();
        }

        private void valueAssign()
        {
            oTransportCost.TrnsCode = txtCode.Text;
            oTransportCost.TrnsCost = Convert.ToDecimal(txtCost.Text);
            oTransportCost.TrnsAccNo = txtGLAccntNo.Text;
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCode.Text = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCost.Text = dgvMain.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtGLAccntNo.Text = dgvMain.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblId.Text = dgvMain.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                errorProvider.SetError(txtCode, "Fill Transport Code");
            }
            else if (txtCost.Text.Trim() == "")
            {
                errorProvider.SetError(txtCost, "Fill Transport Cost");
            }
            else if (txtGLAccntNo.Text.Trim() == "")
            {
                errorProvider.SetError(txtGLAccntNo, "Fill GL Account No");
            }
            else
            {
                valueAssign();
                try
                {
                    oTransportCost.UpdateTransportCode(Convert.ToInt32(lblId.Text));
                    MessageBox.Show("Update Success...!");
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                ControllerClear();
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

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtCost, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Press OK to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                if (txtCode.Text.Trim() == "")
                {
                    errorProvider.SetError(txtCode, "Fill Transport Code");
                }
                else if (txtCost.Text.Trim() == "")
                {
                    errorProvider.SetError(txtCost, "Fill Transport Cost");
                }
                else if (txtGLAccntNo.Text.Trim() == "")
                {
                    errorProvider.SetError(txtGLAccntNo, "Fill GL Account No");
                }
                else
                {
                    try
                    {
                        valueAssign();
                        oTransportCost.DeleteTransportCode(Convert.ToInt32(lblId.Text));
                        MessageBox.Show("Successfully Deleted");

                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    ControllerClear();
                }
            }
        }
    }
}