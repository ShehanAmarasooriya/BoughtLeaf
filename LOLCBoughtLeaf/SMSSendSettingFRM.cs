using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class SMSSendSettingFRM : Form
    {
        BoughtLeafBusinessLayer.SMSSettings smsHelper = new BoughtLeafBusinessLayer.SMSSettings();

        public SMSSendSettingFRM()
        {
            InitializeComponent();
            
        }

        private void SMSSendSettingFRM_Load(object sender, EventArgs e)
        {
            setSettingsForControllers();
        }

        private void setSettingsForControllers()
        {
            DataTable dt = smsHelper.getSMSSendData();

            if (Convert.ToBoolean(dt.Rows[0][0]))
            {
                rbActive.Checked = true;
            }
            else
                rbInactive.Checked = true;

            dt = null;

            dt = smsHelper.getSMSSettings();

            txtPort.Text = dt.Rows[0][0].ToString();
            txtBound.Text = dt.Rows[0][1].ToString();
            txtData.Text = dt.Rows[0][2].ToString();
            txtReadTimeOut.Text = dt.Rows[0][3].ToString();
            txtWriteTimeOut.Text = dt.Rows[0][4].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbActive.Checked)
            {

                if (txtPort.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please enter port number");
                }
                else if (txtBound.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please enter port number");
                }
                else if (txtData.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please enter Data Rate");
                }
                else if (txtWriteTimeOut.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please enter Write Time Out");
                }
                else if (txtReadTimeOut.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Please enter Read Time Out");
                }
                else
                {
                    smsHelper.saveSMSSend(rbActive.Checked);
                    smsHelper.saveSMSSettings(txtPort.Text.Trim().ToUpper(), Convert.ToInt32(txtBound.Text.Trim()), Convert.ToInt32(txtData.Text.Trim()), Convert.ToInt32(txtReadTimeOut.Text.Trim()), Convert.ToInt32(txtWriteTimeOut.Text.Trim()));
                    clearControllers();

                    MessageBox.Show("Successfully Save Data !");
                }
            }
            else
            {
                smsHelper.saveSMSSend(rbActive.Checked);
                MessageBox.Show("Successfully Inactive SMS Sending !");
            }

            smsHelper.saveSMSSend(rbActive.Checked);
        }

        private void clearControllers()
        {
            txtPort.Clear();
            txtBound.Clear();
            txtData.Clear();
            txtWriteTimeOut.Clear();
            txtReadTimeOut.Clear();

            btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActive.Checked)
                gbSettings.Enabled = true;
            else
                gbSettings.Enabled = false;
        }
    }
}