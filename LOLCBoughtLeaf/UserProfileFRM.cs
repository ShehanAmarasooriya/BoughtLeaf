using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class UserProfileFRM : Form
    {
        BoughtLeafBusinessLayer.BLUser myUser = new BoughtLeafBusinessLayer.BLUser();
        BoughtLeafBusinessLayer.MenuLoader objMenuItem = new BoughtLeafBusinessLayer.MenuLoader();

        public UserProfileFRM()
        {
            InitializeComponent();
        }

        public void UserProfile_Load(object sender, EventArgs e)
        {
            cmbRole.DataSource = myUser.ListAllRoles();
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleName";

            //lstPermissions.Items.Clear();
            //DataTable myTable = myUser.ListAllMenuItems();
            //if (myTable.Rows.Count > 0)
            //{
            //    for (int i = 0; i < myTable.Rows.Count; i++)
            //    {
            //        lstPermissions.Items.Add(myTable.Rows[i][1].ToString());
            //    }
            //}
            //else
            //    lstPermissions.Items.Clear();
            gvUsers.DataSource = myUser.ListAllUsers();

            cmdUpdate.Enabled = false;
            cmdDelete.Enabled = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUserID.Clear();
            //lstPermissions.Items.Clear();
            //DataTable myTable = myUser.ListAllMenuItems();
            //if (myTable.Rows.Count > 0)
            //{
            //    for (int i = 0; i < myTable.Rows.Count; i++)
            //    {
            //        lstPermissions.Items.Add(myTable.Rows[i][1].ToString());
            //    }
            //}
            //else
            //    lstPermissions.Items.Clear();
            gvUsers.DataSource = myUser.ListAllUsers();

            cmdAdd.Enabled = true;
            cmdUpdate.Enabled = false;
            cmdDelete.Enabled = false;

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Deletion?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BoughtLeafBusinessLayer.BLUser.StrUserName = txtUserID.Text;
                    myUser.DeleteUser(myUser);
                    //myUser.DeleteUserPermission(myUser);
                    cmdClear.PerformClick();
                    MessageBox.Show(BoughtLeafBusinessLayer.BLUser.StrUserName +" Is Deleted Successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUserID.Text = gvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbRole.SelectedValue = gvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
                //lstPermissions.Items.Clear();
                //DataTable myTable = myUser.ListAllMenuItems();
                //if (myTable.Rows.Count > 0)
                //{
                //    for (int i = 0; i < myTable.Rows.Count; i++)
                //    {
                //        lstPermissions.Items.Add(myTable.Rows[i][1].ToString());
                //    }
                //}
                //else
                //    lstPermissions.Items.Clear();

                BoughtLeafBusinessLayer.BLUser.StrUserName = txtUserID.Text;
                //DataTable myPermission = myUser.ListUserPermissionbyUserID(myUser);
                //if (myPermission.Rows.Count > 0)
                //{
                //    txtPassword.Text = myPermission.Rows[0][0].ToString();
                //    for (int x = 0; x < myPermission.Rows.Count; x++)
                //    {
                //        for (int y = 0; y < lstPermissions.Items.Count; y++)
                //        {
                //            if (myPermission.Rows[x][1].ToString() == lstPermissions.Items[y].ToString())
                //            {
                //                lstPermissions.SetItemChecked(y, true);
                //            }
                //        }
                //    }
                //}

                cmdAdd.Enabled = false;

                cmdUpdate.Enabled = true;
                cmdDelete.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BoughtLeafBusinessLayer.BLUser.StrUserName = txtUserID.Text;
                myUser.StrRole = cmbRole.SelectedValue.ToString();
                myUser.UpdateUser(myUser.StrRole, BoughtLeafBusinessLayer.BLUser.StrUserName);
                //myUser.DeleteUserPermission(myUser);

                //for (int i = 0; i < lstPermissions.Items.Count; i++)
                //{
                //    if (lstPermissions.GetItemChecked(i) == true)
                //    {
                //        myUser.StrMenuName = lstPermissions.Items[i].ToString();
                //        myUser.IntMenuId = myUser.FindMenuIdbyMenuName(myUser);
                //        myUser.InsertUserPermission(myUser);
                //    }
                //}
                MessageBox.Show("User Updated Successfully");
                cmdClear.PerformClick();
                //Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BoughtLeafBusinessLayer.BLUser.StrUserName = txtUserID.Text;
                BoughtLeafBusinessLayer.BLUser.StrUserPassword = txtPassword.Text;
                myUser.StrRole = cmbRole.SelectedValue.ToString();
                //myUser.Str = cmbEstates.Text;
                //myUser.StrDivision = cmbDivisions.Text;
                myUser.InsertUser(myUser);

                //for (int i = 0; i < lstPermissions.Items.Count; i++)
                //{
                //    if (lstPermissions.GetItemChecked(i) == true)
                //    {
                //        myUser.StrMenuName = lstPermissions.Items[i].ToString();
                //       myUser.IntMenuId = myUser.FindMenuIdbyMenuName(myUser);
                //        myUser.InsertUserPermission(myUser);
                //    }
                //}
                MessageBox.Show("User Added Successfully");
                cmdClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSelectAll.Checked)
            //{
            //     for (int i = 0; i < lstPermissions.Items.Count; i++)
            //    {
            //        lstPermissions.SetItemChecked(i, true);                  
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < lstPermissions.Items.Count; i++)
            //    {
            //        lstPermissions.SetItemChecked(i, false);
            //    }
            //}
        }

        private void lstPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRoleFRM objUserRole = new UserRoleFRM(this);
            objUserRole.Show();
            
            
        }
    }
}