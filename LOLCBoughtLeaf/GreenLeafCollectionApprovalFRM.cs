using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class GreenLeafCollectionApprovalFRM : Form
    {

        BoughtLeafBusinessLayer.GreenLeaf greenLeaf = new BoughtLeafBusinessLayer.GreenLeaf();
        BoughtLeafBusinessLayer.SMSSettings smsSettings = new BoughtLeafBusinessLayer.SMSSettings();
        BoughtLeafBusinessLayer.SMSHelper smsHelper = new BoughtLeafBusinessLayer.SMSHelper();
        BoughtLeafBusinessLayer.BLSupplier supplierObj = new BoughtLeafBusinessLayer.BLSupplier();

        bool status = true;

        public GreenLeafCollectionApprovalFRM()
        {
            InitializeComponent();
        }

        private void FrmDailyGreenLeafApproval_Load(object sender, EventArgs e)
        {
            cmbRoute.DataSource = new BoughtLeafBusinessLayer.BLRoute().ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private string getRoute()
        {
            if (chkAllRoute.Checked)
                return "%";
            else
                return cmbRoute.SelectedValue.ToString();
        }

        private void dataGridViewSelectAll()
        {
            gvList.DataSource = greenLeaf.ListGreenLeafApproval(getRoute(), Convert.ToDateTime(dtpMain.Value.Date));

            gvList.ReadOnly = false;

            foreach (DataGridViewColumn dc in gvList.Columns)
            {
                if (!dc.Index.Equals(3))
                    dc.ReadOnly = true;
            }
        }

        private void dataGridViewClear()
        {
            gvList.DataSource = null;
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
                btnAll.Text = "Check All";
                status = true;
            }
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount > 0)
            {
                DialogResult dResult = MessageBox.Show("Are You Sure Confirm ? ", "Warning", MessageBoxButtons.YesNo);

                if (dResult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow dr in gvList.Rows)
                        {
                            greenLeaf.UpdateApprovalGreenLeaf(Convert.ToDateTime(dr.Cells[5].Value), Convert.ToString(dr.Cells[0].Value), Convert.ToString(dr.Cells[4].Value), Convert.ToBoolean(dr.Cells[3].Value));
                        }

                        MessageBox.Show("Successfully Approved !");

                        //SMS Machanism START
                        DataTable dt = smsSettings.getSMSSendData();

                        if (Convert.ToBoolean(dt.Rows[0][0]))
                        {
                            smsHelper.connectPort();
                            foreach (DataGridViewRow dr in gvList.Rows)
                            {
                                if(Convert.ToBoolean(dr.Cells[3].Value))
                                {
                                    string mobNumber = supplierObj.getMobileNumber(Convert.ToString(dr.Cells[0].Value));
                                    string smsMessage = BoughtLeafBusinessLayer.BLUser.getCompanyName() + "\n" + "Mema dinayata " + dr.Cells[5].Value.ToString().Split(' ')[0]
                                                        + "\n" + "Apa ayathanaya wetha labunu Amu-dalu pramanaya sahathika karana ladi"
                                                        + "\n" + "Amu Dalu Pramanaya : " + Convert.ToInt32(dr.Cells[6].Value) + " kg";
                                    smsHelper.SendMessage(mobNumber, smsMessage);
                                }
                            }
                            smsHelper.closePort();
                            MessageBox.Show("Successfully Send SMS for Approved Suppliers!");
                        }
                        //SMS Machanism END
                        dataGridViewClear();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }
            else
                MessageBox.Show("Not Any Daily GreenLeaf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkAllRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllRoute.Checked)
                cmbRoute.Enabled = false;
            else
                cmbRoute.Enabled = true;
        }

        private void btnFillData_Click(object sender, EventArgs e)
        {
            dataGridViewSelectAll();

            DataRow dr = greenLeaf.GetTotalGreenLeafDeatailForApproval(getRoute(), Convert.ToDateTime(dtpMain.Value.Date)).Rows[0];
            lblGreenLeaf.Text = dr[0].ToString();
            lblBags.Text = dr[1].ToString();
            lblSack.Text = dr[2].ToString();
            lblTrnCost.Text = dr[3].ToString();
        }
    }
}