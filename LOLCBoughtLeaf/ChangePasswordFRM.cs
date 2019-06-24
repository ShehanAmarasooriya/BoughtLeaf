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
    public partial class ChangePasswordFRM : Form
    {
        BoughtLeafBusinessLayer.BLUser myUser = new BLUser();
        public ChangePasswordFRM()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtUserName.Text = BoughtLeafBusinessLayer.BLUser.StrUserName;
            txtOldPassword.Text = BoughtLeafBusinessLayer.BLUser.StrUserPassword;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            //txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Password Change", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (txtNewPassword.Text == txtConfirmPassword.Text)
                    {
                        BoughtLeafBusinessLayer.BLUser.StrUserName = txtUserName.Text;
                        BoughtLeafBusinessLayer.BLUser.StrUserPassword = txtNewPassword.Text;
                        myUser.PasswordChange(myUser);

                        //myUser.CreateLog("Password Change", "Password changed of user : " + txtUserName.Text, DateTime.Now.Date);
                        MessageBox.Show("Password has changed successfully");
                        Application.Restart();
                    }
                    else
                    {
                        MessageBox.Show("Your Password is not matching...!");
                    }
                    //myAccount.StrAccountCode = txtCode.Text;
                    //myAccount.DeleteAccount(myAccount);
                    //ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}