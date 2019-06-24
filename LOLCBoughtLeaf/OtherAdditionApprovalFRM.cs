using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class OtherAdditionApprovalFRM : Form
    {
        BoughtLeafBusinessLayer.OtherAdditions addition = new BoughtLeafBusinessLayer.OtherAdditions();
        bool status = true;

        public OtherAdditionApprovalFRM()
        {
            InitializeComponent();
        }

        private void FrmOtherPaymentApproval_Load(object sender, EventArgs e)
        {
            dataGridViewSelectAll();
        }

        private void dataGridViewSelectAll()
        {
            gvList.DataSource = addition.ListOtherAdditionForApproval(Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.StrYear), Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.strMonthID));

            gvList.ReadOnly = false;

            foreach (DataGridViewColumn dc in gvList.Columns)
            {
                if (!dc.Index.Equals(4))
                    dc.ReadOnly = true;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (status)
            {
                foreach (DataGridViewRow dr in gvList.Rows)
                {
                    dr.Cells[4].Value = true;
                }
                status = false;
                btnAll.Text = "Un-Check All";
            }
            else
            {
                foreach (DataGridViewRow dr in gvList.Rows)
                {
                    dr.Cells[4].Value = false;
                }
                status = true;
                btnAll.Text = "Check All";
            }
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount > 0)
            {
                DialogResult dResult = MessageBox.Show("Are You Sure To update as Confirmed ? ", "Warning", MessageBoxButtons.YesNo);

                if (dResult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow dr in gvList.Rows)
                        {
                            addition.ApprovalOtherAddition(Convert.ToInt32(dr.Cells[2].Value), Convert.ToInt32(dr.Cells[3].Value), dr.Cells[0].Value.ToString(), Convert.ToBoolean(dr.Cells[4].Value));
                        }
                        MessageBox.Show("Successfully Approved !");
                        dataGridViewClear();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }
            else
                MessageBox.Show("This Month has no Any Other Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridViewClear()
        {
            gvList.DataSource = null;
        }
    }
}