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
    public partial class DeductionApprovalFRM : Form
    {
        BoughtLeafBusinessLayer.SupplierDeduction deduction = new BoughtLeafBusinessLayer.SupplierDeduction();
        BoughtLeafBusinessLayer.BLDeductionGroup DeductGroupMaster = new BoughtLeafBusinessLayer.BLDeductionGroup();
        BoughtLeafBusinessLayer.SMSSettings smsSettings = new BoughtLeafBusinessLayer.SMSSettings();
        BoughtLeafBusinessLayer.SMSHelper smsHelper = new BoughtLeafBusinessLayer.SMSHelper();
        BoughtLeafBusinessLayer.BLSupplier supplierObj = new BoughtLeafBusinessLayer.BLSupplier();

        bool status = true;

        public DeductionApprovalFRM()
        {
            InitializeComponent();
        }

        private void FrmOtherDeductionApproval_Load(object sender, EventArgs e)
        {
            cmbDeductGroup.DataSource = DeductGroupMaster.LoadComboboxGroupCode();
            cmbDeductGroup.DisplayMember = "GroupName";
            cmbDeductGroup.ValueMember = "GroupCode";
        }

        private void dataGridViewSelectAll()
        {
            string deductGrp = cmbDeductGroup.SelectedValue.ToString();
            if (chkAll.Checked)
                deductGrp = "%";
            gvList.DataSource = deduction.ListSupplierDeductionForApproval(Convert.ToInt32(BLUser.StrYear), Convert.ToInt32(BLUser.strMonthID), deductGrp);

            gvList.ReadOnly = false;

            foreach (DataGridViewColumn dc in gvList.Columns)
            {
                if (!dc.Index.Equals(5))
                    dc.ReadOnly = true;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (status)
            {
                foreach (DataGridViewRow dr in gvList.Rows)
                {
                    dr.Cells[5].Value = true;
                }
                status = false;
                btnAll.Text = "Un-Check All";
            }
            else
            {
                foreach (DataGridViewRow dr in gvList.Rows)
                {
                    dr.Cells[5].Value = false;
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
                            deduction.ApprovalSuppllierDeduction(Convert.ToString(dr.Cells[4].Value), Convert.ToString(dr.Cells[0].Value), Convert.ToInt32(dr.Cells[1].Value), Convert.ToInt32(dr.Cells[2].Value), Convert.ToDateTime(dr.Cells[3].Value), Convert.ToBoolean(dr.Cells[5].Value));
                        }
                        MessageBox.Show("Successfully Approved !");

                        //SMS Machanism START
                        DataTable dt = smsSettings.getSMSSendData();
                        
                        if (Convert.ToBoolean(dt.Rows[0][0]))
                        {
                            smsHelper.connectPort();
                            foreach (DataGridViewRow dr in gvList.Rows)
                            {
                                if (Convert.ToString(dr.Cells[0].Value).Equals("ADVANCE"))
                                {
                                    if (Convert.ToBoolean(dr.Cells[3].Value))
                                    {
                                        string mobNumber = supplierObj.getMobileNumber(Convert.ToString(dr.Cells[0].Value));
                                        string smsMessage = BoughtLeafBusinessLayer.BLUser.getCompanyName() + "\n" + "Mema dinayata " + dr.Cells[3].Value.ToString().Split(' ')[0]
                                                            + "\n" + "Apa ayathanaya wetha labunu Amu-dalu pramanaya sahathika karana ladi."
                                                            + "\n" + "Amu Dalu Pramanaya : " + Convert.ToInt32(dr.Cells[6].Value);
                                        smsHelper.SendMessage(mobNumber, smsMessage);
                                    }
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
                MessageBox.Show("This Month has no Any Other Deductions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridViewClear()
        {
            gvList.DataSource = null;
        }

        private void chkAllRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                cmbDeductGroup.Enabled = false;
            else
                cmbDeductGroup.Enabled = true;
        }

        private void btnFillData_Click(object sender, EventArgs e)
        {
            dataGridViewSelectAll();
        }
    }
}