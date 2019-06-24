using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class IncentivesTRNFRM : Form
    {
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.Incentives myIncentives = new BoughtLeafBusinessLayer.Incentives();

        public IncentivesTRNFRM()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Incentives_Load(object sender, EventArgs e)
        {
            //cmbYear.DataSource = myYear.ListAllVisibleYears();
            //cmbYear.DisplayMember = "YearCode";
            //cmbYear.ValueMember = "YearCode";
            //cmbYear.Text = BoughtLeafBusinessLayer.BLUser.StrYear;

            //cmbMonth.DataSource = myYear.ListAllMonths();
            //cmbMonth.DisplayMember = "MonthName";
            //cmbMonth.ValueMember = "MonthCode";
            //cmbMonth.SelectedValue = BoughtLeafBusinessLayer.BLUser.strMonthID;

            cmbRouteNo.DataSource = myRoute.ListRouteDetails();
            cmbRouteNo.DisplayMember = "RouteName";
            cmbRouteNo.ValueMember = "RouteCode";

            cmbRouteNo_SelectedIndexChanged(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshGrid();            
        }

        private void RefreshGrid()
        {
            String strAllRoutes = "%";
            if (allRouteChk.Checked)
            {
                strAllRoutes = "%";
            }
            else
            {
                strAllRoutes = cmbRouteNo.SelectedValue.ToString();
            }

            DataTable dt = mySupplier.getRouteWiseSuppliersWithIncentives1(strAllRoutes);
            if (dt.Rows.Count > 0)
            {
                gvList.DataSource = dt;
                if (gvList.Rows.Count > 0)
                {
                    gvList.Columns[0].ReadOnly = true;
                    gvList.Columns[1].ReadOnly = true;
                }
            }
            else
            {
                //MessageBox.Show("No Supplier Incentives Available");
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                myIncentives.DeleteIncentives( cmbRouteNo.SelectedValue.ToString());
                for (Int32 i = 0; i <= gvList.Rows.Count - 1; i++)
                {
                    myIncentives.InsertIncentives( cmbRouteNo.SelectedValue.ToString(), gvList.Rows[i].Cells[0].Value.ToString(), dtDate.Value.Date, Convert.ToDecimal(gvList.Rows[i].Cells[2].Value.ToString()), BoughtLeafBusinessLayer.BLUser.StrUserName, Convert.ToDecimal(gvList.Rows[i].Cells[3].Value.ToString()), Convert.ToDecimal(gvList.Rows[i].Cells[4].Value.ToString()));
                }
                MessageBox.Show("Incentives Saved Successfull...!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdApplyAll_Click(object sender, EventArgs e)
        {
            try
            {
                String FirstValue = gvList.Rows[0].Cells[2].Value.ToString();
                //String SValue = gvList.Rows[0].Cells[3].Value.ToString();

                for (Int32 i = 0; i <= gvList.Rows.Count - 1; i++)
                {
                    gvList.Rows[i].Cells[2].Value = FirstValue;
                    //gvList.Rows[i].Cells[3].Value = SValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //sacchintha udara add new method for change supplier code with four zero prefix
        // 1 is like 0001
        private string supCodeChange(string pSupCode)
        {
            //return pSupCode.PadLeft(5, '0');
            return pSupCode;
        }

        

        private void txtSupCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnApplyToAllTansport_Click(object sender, EventArgs e)
        {
            try
            {
                //String FirstValue = gvList.Rows[0].Cells[2].Value.ToString();
                String SValue = gvList.Rows[0].Cells[3].Value.ToString();

                for (Int32 i = 0; i <= gvList.Rows.Count - 1; i++)
                {
                    //gvList.Rows[i].Cells[2].Value = FirstValue;
                    gvList.Rows[i].Cells[3].Value = SValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRouteNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbRouteNo.SelectedIndex>-1)
            {
                RefreshGrid();
            }
        }

        private void btnApplyToAllRegular_Click(object sender, EventArgs e)
        {
            try
            {
                //String FirstValue = gvList.Rows[0].Cells[2].Value.ToString();
                String SValue = gvList.Rows[0].Cells[4].Value.ToString();

                for (Int32 i = 0; i <= gvList.Rows.Count - 1; i++)
                {
                    //gvList.Rows[i].Cells[2].Value = FirstValue;
                    gvList.Rows[i].Cells[4].Value = SValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}