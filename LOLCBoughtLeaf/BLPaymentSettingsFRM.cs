using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLPaymentSettingsFRM : Form
    {
        BoughtLeafBusinessLayer.BLFixedPaymentSettings mySettings = new BoughtLeafBusinessLayer.BLFixedPaymentSettings();

        public BLPaymentSettingsFRM()
        {
            InitializeComponent();
        }

        private void AdvancePaymentRate_Load(object sender, EventArgs e)
        {
            setTextFieldCurrentValues();
        }

        private void setTextFieldCurrentValues() 
        {
            DataTable dt = mySettings.ListSettings();
            if (dt.Rows.Count > 0)
            {
                txtAdvanceRate.Text = dt.Rows[0]["AdvancePaymentRate"].ToString();
                txtPaySlipRate.Text = dt.Rows[0]["PaySlipCharge"].ToString();
                txtNBT.Text = dt.Rows[0]["NBTRate"].ToString();
                txtStampDutyLevel.Text = dt.Rows[0]["StampDutyLevel"].ToString();
                txtStampDutyAmount.Text = dt.Rows[0]["StampDutyAmount"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                mySettings.DecAdvancePaymentRate = Convert.ToDecimal(txtAdvanceRate.Text);
                mySettings.DecPaySlipCharge = Convert.ToDecimal(txtPaySlipRate.Text);
                mySettings.StampDutyLevel = Convert.ToDecimal(txtStampDutyLevel.Text);
                mySettings.StampDutyAmount = Convert.ToDecimal(txtStampDutyAmount.Text);
                mySettings.Nbt = Convert.ToDecimal(txtNBT.Text);

                mySettings.UpdateSettings();

                MessageBox.Show("Settings Updated Successfully");

                clearControllers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearControllers()
        {
            txtAdvanceRate.Clear();
            txtPaySlipRate.Clear();
            txtStampDutyLevel.Clear();
            txtStampDutyAmount.Clear();
            txtNBT.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}