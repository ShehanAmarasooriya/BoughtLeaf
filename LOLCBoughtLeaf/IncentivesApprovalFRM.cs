using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class IncentivesApprovalFRM : Form
    {
        BoughtLeafBusinessLayer.Incentives incentiveObj = new BoughtLeafBusinessLayer.Incentives();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();

        bool status = true;

        public IncentivesApprovalFRM()
        {
            InitializeComponent();
        }

        private void FrmOtherPaymentApproval_Load(object sender, EventArgs e)
        {
            cmbRouteCode.DataSource = myRoute.ListRouteDetails(); ;
            cmbRouteCode.DisplayMember = "RouteName";
            cmbRouteCode.ValueMember = "RouteCode";
        }

        private void dataGridViewSelectAll()
        {
            string locRoute = cmbRouteCode.SelectedValue.ToString();

            if (chkAll.Checked)
                locRoute = "%";

            gvList.DataSource = incentiveObj.ListIncentivesForApproval(Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.StrYear), Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.strMonthID), locRoute);

            gvList.ReadOnly = false;

            foreach (DataGridViewColumn dc in gvList.Columns)
            {
                if (!dc.Index.Equals(3))
                    dc.ReadOnly = true;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (status)
            {
                foreach (DataGridViewRow dr in gvList.Rows)
                {
                    dr.Cells[3].Value = true;
                }
                status = false;
                btnAll.Text = "Un-Check All";
            }
            else
            {
                foreach (DataGridViewRow dr in gvList.Rows)
                {
                    dr.Cells[3].Value = false;
                }
                status = true;
                btnAll.Text = "Check All";
            }
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount > 0)
            {
                DialogResult dResult = MessageBox.Show("Are You Sure to update as Confirmed ? ", "Warning", MessageBoxButtons.YesNo);

                if (dResult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow dr in gvList.Rows)
                        {
                            incentiveObj.ApprovalIncentives(Convert.ToInt32(dr.Cells[0].Value), Convert.ToInt32(dr.Cells[1].Value), dr.Cells[2].Value.ToString(), Convert.ToBoolean(dr.Cells[3].Value));
                        }
                        MessageBox.Show("Successfully Approved !");
                        dataGridViewClear();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }
            else
                MessageBox.Show("This Month has no Any Other Incentives", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridViewClear()
        {
            gvList.DataSource = null;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridViewSelectAll();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                cmbRouteCode.Enabled = false;
            else
                cmbRouteCode.Enabled = true;
        }
    }
}