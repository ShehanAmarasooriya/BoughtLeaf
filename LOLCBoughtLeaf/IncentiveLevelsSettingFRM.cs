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
    public partial class IncentiveLevelsSettingFRM : Form
    {
        BoughtLeafBusinessLayer.BLUser mySetting = new BoughtLeafBusinessLayer.BLUser();

        public IncentiveLevelsSettingFRM()
        {
            InitializeComponent();
        }

        private void IncentiveLevelsSetting_Load(object sender, EventArgs e)
        {
            try
            {
                if (BLUser.IsIncentiveLevelsSettingRouteWise())
                    rbRouteWise.Checked = true;
                else
                    rbSupplierWise.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool Value = rbRouteWise.Checked ? true : false;
            mySetting.updateIncentiveLevelsSetting(Value);
            MessageBox.Show("Done !", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}