using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class BLRouteFRM : Form
    {
        BoughtLeafBusinessLayer.BLTown myTown = new BoughtLeafBusinessLayer.BLTown();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();

        public BLRouteFRM()
        {
            InitializeComponent();
        }

        private void Route_Load(object sender, EventArgs e)
        {
            btnClear.PerformClick();
        }


        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    txtRouteNo.Enabled = false;
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    
                    txtRouteNo.Text = gvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtRouteName.Text = gvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void valueAssign()
        {
            myRoute.RouteCode = txtRouteNo.Text;
            myRoute.RouteName = txtRouteName.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                valueAssign();
                myRoute.InsertRoute();
                MessageBox.Show("Route Created Successfully");
                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                valueAssign();
                myRoute.UpdateRoute();
                MessageBox.Show("Route Updated Successfully");
                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Delete...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    valueAssign();
                    myRoute.DeleteRoute();
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gvList.DataSource = myRoute.ListRouteDetails();
            gvList.Columns[1].Width = 250;
            txtRouteNo.Clear();
            txtRouteName.Clear();

            txtRouteNo.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}