using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BoughtLeafBusinessLayer;
using System.Globalization;

namespace OLAXBoughtLeaf
{
    public partial class Pre_Month_DebtsCoinsEntry : Form
    {
        int row = 0;
        int cell = 0;
        public Pre_Month_DebtsCoinsEntry()
        {
            InitializeComponent();
            dtpYearMonth.Format = DateTimePickerFormat.Custom;
            dtpYearMonth.CustomFormat = "MMMM yyyy";
            dtpYearMonth.ShowUpDown = true;


            try
            {
                setGrid();
            }
            catch { }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Pre_Month_DebtsCoinsEntry_Load(object sender, EventArgs e)
        {
            cmbRoute.DataSource = Pre_Month_DebtsCoinEntryCLS.getAllRouteCode();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }

        private void dtpYearMonth_ValueChanged(object sender, EventArgs e)
        {
            setGrid();
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            setGrid();
        }

        void setGrid()
        {
            Pre_Month_DebtsCoinEntryCLS.year = dtpYearMonth.Value.Year;
            Pre_Month_DebtsCoinEntryCLS.month = dtpYearMonth.Value.Month;
            Pre_Month_DebtsCoinEntryCLS.routCode = cmbRoute.SelectedValue.ToString();
            gdvList.DataSource = Pre_Month_DebtsCoinEntryCLS.getSupllierByRouteCode();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Pre_Month_DebtsCoinEntryCLS.month = dtpYearMonth.Value.Year;
            Pre_Month_DebtsCoinEntryCLS.month = dtpYearMonth.Value.Month;
            Pre_Month_DebtsCoinEntryCLS.routCode = cmbRoute.SelectedValue.ToString();
            DataSet ds = new DataSet();
            DataTable dt = Pre_Month_DebtsCoinEntryCLS.getSupllierByRouteCode();
            ds.Tables.Add(dt);
            ds.WriteXml("myCOins.xml");

            pre_coinsAndDebts myRpt = new pre_coinsAndDebts();
            ReportViewer myReportViewer = new ReportViewer();


            myRpt.SetDataSource(ds);
            myRpt.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myRpt.SetParameterValue("Year", Pre_Month_DebtsCoinEntryCLS.year);
            myRpt.SetParameterValue("Month", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Pre_Month_DebtsCoinEntryCLS.month));
            myReportViewer.crystalReportViewer1.ReportSource = myRpt;
            myReportViewer.Show();
        }

        private void gdvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gdvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                 decimal value;
                 if (Decimal.TryParse(gdvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out value))
                 {
                     }
                else
                {

                    MessageBox.Show("Invalid Value");
                }
        }

        private void gdvList_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void gdvList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    //SendKeys.Send("{Tab}");

                    if (cell == 3)
                    {
                        gdvList.Rows[row].Cells[4].Selected = true;
                        gdvList.BeginEdit(true);
                    }
                    if (cell == 4)
                    {
                        gdvList.Rows[row + 1].Cells[3].Selected = true;
                        gdvList.BeginEdit(true);
                    }
                }
            }
            catch 
            {
                
 
            }
        }

        private void gdvList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            cell = e.ColumnIndex;
        }

        private void gdvList_SelectionChanged(object sender, EventArgs e)
        {
         
        }

        private void gdvList_Leave(object sender, EventArgs e)
        {
            
        }

        private void gdvList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = gdvList.Rows[e.RowIndex];

            if (gdvList.Columns[e.ColumnIndex].Name.Equals("Coins") || gdvList.Columns[e.ColumnIndex].Name.Equals("Debts"))
            {
                Pre_Month_DebtsCoinEntryCLS.SCode = dr.Cells["SupCode"].Value.ToString();
                Pre_Month_DebtsCoinEntryCLS.routCode = dr.Cells["RouteCode"].Value.ToString();
                Pre_Month_DebtsCoinEntryCLS.coin = Convert.ToDouble(dr.Cells["Coins"].Value.ToString().Trim());
                Pre_Month_DebtsCoinEntryCLS.debt = Convert.ToDouble(dr.Cells["Debts"].Value.ToString().Trim());
                Pre_Month_DebtsCoinEntryCLS.InsertUpdateCoins();
            }
        }

        private void gdvList_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void gdvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                    DataGridViewRow dr = gdvList.Rows[e.RowIndex];

                    if (gdvList.Columns[e.ColumnIndex].Name.Equals("Coins") || gdvList.Columns[e.ColumnIndex].Name.Equals("Debts"))
                    {
                        Pre_Month_DebtsCoinEntryCLS.SCode = dr.Cells["SupCode"].Value.ToString();
                        Pre_Month_DebtsCoinEntryCLS.routCode = dr.Cells["RouteCode"].Value.ToString();
                        Pre_Month_DebtsCoinEntryCLS.coin = Convert.ToDouble(dr.Cells["Coins"].Value.ToString().Trim());
                        Pre_Month_DebtsCoinEntryCLS.debt = Convert.ToDouble(dr.Cells["Debts"].Value.ToString().Trim());
                        Pre_Month_DebtsCoinEntryCLS.InsertUpdateCoins();
                    }

                
            }
            catch
            {


            }
        }

        private void gdvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4) // 1 should be your column index
            {
                double i;

                if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Invalid Value"); 
                }

            }
        }


    }
}