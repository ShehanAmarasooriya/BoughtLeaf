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
    public partial class AdvancedBookingRate : Form
    {
        public AdvancedBookingRate()
        {
            InitializeComponent();
        }
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.AdvanceBookRate advBookRate = new BoughtLeafBusinessLayer.AdvanceBookRate();

        private void gridUpdateAdvBookRate()
        {
            advBookRate.RouteCode=cmbRoute.SelectedValue.ToString();
            advBookRate.Year = Convert.ToInt32(cmbYear.SelectedValue.ToString());
            advBookRate.Month = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
            advBookRate.CheckAllRoute = chkAllRoute.CheckState == CheckState.Checked ? 1 : 0;

            gvlist.DataSource = advBookRate.ListAdvBookRate();
            
            txtMiRate.Clear();
            txtQty.Clear();
            txtAdvMinChe.Clear();

            #region alignment
            gvlist.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvlist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvlist.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            #endregion

           
            
            gvlist.Columns[0].Visible = false;
            gvlist.Columns[2].Visible = false;
            gvlist.Columns[3].Visible = false;

        }

        private void AdvancedBookingRate_Load(object sender, EventArgs e)
        {
            cmbRoute.SelectedIndexChanged -= new EventHandler(cmbRoute_SelectedIndexChanged);
            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
            cmbRoute.SelectedIndexChanged += new EventHandler(cmbRoute_SelectedIndexChanged);


            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = BLUser.StrYear;
         

            cmbMonth.DataSource = myYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";
            cmbMonth.SelectedValue = BLUser.strMonthID;
     

            chkAllRoute.Checked = false;

            gridUpdateAdvBookRate();
          
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridUpdateAdvBookRate();
        }

        private void chkAllRoutes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllRoute.Checked)
                {
                    cmbRoute.Enabled = false;
                    gridUpdateAdvBookRate();
                    // txtAdvMinChe.Enabled = false;
                    //txtMiRate.Enabled = false;
                    //txtQty.Enabled = false;
                    btnAdd.Enabled = false;
                }
                else
                {
                    cmbRoute.Enabled = true;
                    gridUpdateAdvBookRate();
                    //txtAdvMinChe.Enabled = true;
                    //txtMiRate.Enabled = true;
                    //txtQty.Enabled = true;
                    btnAdd.Enabled = true;
                }
                cmbRoute_SelectedIndexChanged(null, null);
            }
            catch
            {
            }
        }

        private void btncloase_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtQty.Text.Trim()==string.Empty)
                {
                    errorProvider.SetError(txtQty, "Minimum Qty");
                }
                else if (txtMiRate.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtMiRate, "Minimum Rate");
                }
                else if (txtAdvMinChe.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtAdvMinChe, "Advance Minimum Cheque Amount");
                }
                else
                {
                    advBookRate.RouteCode = cmbRoute.SelectedValue.ToString();
                    advBookRate.Year = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                    advBookRate.Month = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                    //advBookRate.CheckAllRoute = chkAllRoute.CheckState == CheckState.Checked ? 1 : 0;
                    advBookRate.MinimumQty=Convert.ToDecimal(txtQty.Text.ToString());
                    advBookRate.Minimumrate=Convert.ToDecimal(txtMiRate.Text.ToString());
                    advBookRate.AdvMinCheAmount=Convert.ToDecimal(txtAdvMinChe.Text.ToString());
                    advBookRate.insertAdvBookRate();
                    MessageBox.Show("Added Successfully!");
                    
                    gridUpdateAdvBookRate();
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gridUpdateAdvBookRate();
            }
            catch
            { }
           
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gridUpdateAdvBookRate();
            }
            catch
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvlist.SelectedRows.Count == 1)
            {
            if (MessageBox.Show("Press OK to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                
                    try
                    {
                        advBookRate.RouteCode = gvlist.CurrentRow.Cells[0].Value.ToString();
                        advBookRate.deleteAdvBookRate();
                        MessageBox.Show("Successfully Deleted");
                        gridUpdateAdvBookRate();

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }

                    gridUpdateAdvBookRate();

                }

            }
            else
                MessageBox.Show("Select Row");

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtQty, null);
        }

        private void txtMiRate_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtMiRate, null);
        }

        private void txtAdvMinChe_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtAdvMinChe, null);
        }

        private void gvlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtQty.Text = gvlist.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMiRate.Text = gvlist.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtAdvMinChe.Text = gvlist.Rows[e.RowIndex].Cells[6].Value.ToString();
               
            }
        }

        private void btnAllMinRate_Click(object sender, EventArgs e)
        {

        }

        private void btnAllAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtQty, "Minimum Qty");
                }
                else if (txtMiRate.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtMiRate, "Minimum Rate");
                }
                else if (txtAdvMinChe.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtAdvMinChe, "Advance Minimum Cheque Amount");
                }
                else
                {
                    advBookRate.MinimumQty = Convert.ToDecimal(txtQty.Text.ToString());
                    advBookRate.Minimumrate = Convert.ToDecimal(txtMiRate.Text.ToString());
                    advBookRate.AdvMinCheAmount = Convert.ToDecimal(txtAdvMinChe.Text.ToString());
                    DataTable dtroot = new DataTable();
                    dtroot = myRoute.ListRouteDetails();

                    for (int i = 0; i < dtroot.Rows.Count; i++)
                    {
                        
                       // advBookRate.RouteNo = cmbRoute.GetItemText(cmbRoute.Items[i]);
                        advBookRate.RouteCode = dtroot.Rows[i][0].ToString();
                        advBookRate.insertAdvBookRate();

                    }
                  
                    MessageBox.Show("Added Successfully!");
                    gridUpdateAdvBookRate();


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Enter All Route!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gvlist.SelectedRows.Count == 1)
            {
               if (txtQty.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtQty, "Minimum Qty");
                }
                else if (txtMiRate.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtMiRate, "Minimum Rate");
                }
                else if (txtAdvMinChe.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(txtAdvMinChe, "Advance Minimum Cheque Amount");
                }
                else{

                    try
                    {
                        advBookRate.RouteCode = gvlist.CurrentRow.Cells[0].Value.ToString();
                        advBookRate.Year = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                        advBookRate.Month = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                        advBookRate.MinimumQty = Convert.ToDecimal(txtQty.Text);
                        advBookRate.Minimumrate = Convert.ToDecimal(txtMiRate.Text);
                        advBookRate.AdvMinCheAmount = Convert.ToDecimal(txtAdvMinChe.Text);
                        advBookRate.updateAdvBookRate();
                        MessageBox.Show("Update Suceessfully");
                        gridUpdateAdvBookRate();

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }

                    gridUpdateAdvBookRate();

                }

            }
            else
                MessageBox.Show("Select Row");

        }
    }
}