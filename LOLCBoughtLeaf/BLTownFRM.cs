using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLTownFRM : Form
    {
        BoughtLeafBusinessLayer.BLTown myTown = new BoughtLeafBusinessLayer.BLTown();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();

        public BLTownFRM()
        {
            InitializeComponent();
        }

        private void Town_Load(object sender, EventArgs e)
        {
            cmbRoute.SelectedIndexChanged -= new EventHandler(cmbRoute_SelectedIndexChanged);
            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
            cmbRoute.SelectedIndexChanged += new EventHandler(cmbRoute_SelectedIndexChanged);

            btnClear.PerformClick();
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    txtCode.Enabled = false;
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    
                    txtCode.Text = gvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtName.Text = gvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmbRoute.SelectedValue = gvList.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtDistance.Text = gvList.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void valueAssign()
        {
            myTown.StrTownCode = cmbRoute.SelectedValue.ToString() + "-" + txtCode.Text.ToUpper();
            myTown.StrTownName = txtName.Text.ToUpper();
            myTown.StrRouteCode = cmbRoute.SelectedValue.ToString();
            myTown.DecDistance = Convert.ToDecimal(txtDistance.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                valueAssign();
                myTown.InsertTown();
                MessageBox.Show("Successfully Inserted Town...!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            btnClear.PerformClick();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //valueAssign();
                myTown.StrTownCode = txtCode.Text.ToUpper();
                myTown.StrTownName = txtName.Text.ToUpper();
                myTown.StrRouteCode = cmbRoute.SelectedValue.ToString();
                myTown.DecDistance = Convert.ToDecimal(txtDistance.Text);

                myTown.UpdateTown();
                MessageBox.Show("Successfully Updated Town...!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            btnClear.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Delete...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //valueAssign();
                    myTown.StrTownCode = txtCode.Text.ToUpper();
                    myTown.StrTownName = txtName.Text.ToUpper();
                    myTown.StrRouteCode = cmbRoute.SelectedValue.ToString();
                    myTown.DecDistance = Convert.ToDecimal(txtDistance.Text);

                    myTown.DeleteTown();
                    btnClear.PerformClick();
                    MessageBox.Show("Successfully Deleted Town...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            
            txtCode.Clear();
            txtDistance.Clear();
            txtName.Clear();
            //cmbRoute.SelectedIndex = 0;

            txtCode.Focus();

            gvList.DataSource = myTown.ListTownDetails(cmbRoute.SelectedValue.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvList.DataSource = myTown.ListTownDetails(cmbRoute.SelectedValue.ToString());
        }
    }
}