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
    public partial class AdvancedBooking : Form
    {
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.AdvanceBooking advBook = new BoughtLeafBusinessLayer.AdvanceBooking();

        public AdvancedBooking()
        {
            InitializeComponent();
        }

        private void valueAssign()
        {
            advBook.RouteNo = cmbRoute.SelectedValue.ToString();
            advBook.Year = Convert.ToInt16(cmbYear.SelectedValue.ToString());
            advBook.Month = Convert.ToInt16(cmbMonth.SelectedValue.ToString());
            advBook.CheckAllRoute = chkAllRoutes.CheckState == CheckState.Checked ? 1 : 0;
            DateTime monthFirstdate = new DateTime(DateTime.Now.Year, Convert.ToInt32(cmbMonth.SelectedValue.ToString()), 1);
            advBook.Monthfromdate = monthFirstdate;
            advBook.FromDate = FromDate.Value.Date;
            advBook.ToDate = ToDate.Value.Date;
            advBook.AdvBookDate =Convert.ToDateTime(cmbissueDate.SelectedValue.ToString());
            advBook.AdRate = Convert.ToDecimal(txtadvPayRate.Text);
        }

     
        private void gridUpdateAdvBook()
        {
           
            valueAssign();
           
            //Get Gl Rate
            string a = (advBook.getGLRate(Convert.ToInt32(cmbMonth.SelectedValue.ToString()), Convert.ToInt32(cmbYear.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString())).ToString("N2");
            advBook.GlRate = Convert.ToDecimal(a);

            gvList.DataSource = advBook.ListAdvBook();

           


            //check adv book or not
            foreach (DataGridViewRow row in gvList.Rows) 
           {
               if (row.Cells["From"].Value.ToString() == "S")
               {
                   row.DefaultCellStyle.BackColor = Color.Bisque; 
               }
           }

           //check adv confirm or not
           foreach (DataGridViewRow dgvr in gvList.Rows)
           {
               if (dgvr.Cells["Confirm"].Value.ToString() == ("True"))
               {
                   dgvr.DefaultCellStyle.ForeColor = Color.Red;
               }
           }


            #region coulumWidth
            gvList.Columns[1].Width = 65;
            gvList.Columns[2].Width = 70;
            gvList.Columns[3].Width = 120;
            gvList.Columns[4].Width = 75;
            gvList.Columns[5].Width = 75;
            gvList.Columns[6].Width = 75;
            gvList.Columns[7].Width = 75;
            gvList.Columns[8].Width = 75;
            #endregion

            #region Cell can ReadOnly
            //gvList.Columns[0].ReadOnly = true;
            gvList.Columns[1].ReadOnly = true;
            gvList.Columns[2].ReadOnly = true;
            gvList.Columns[3].ReadOnly = true;
            gvList.Columns[4].ReadOnly = true;
            gvList.Columns[5].ReadOnly = true;
            gvList.Columns[6].ReadOnly = true;
            gvList.Columns[7].ReadOnly = true;
            gvList.Columns[8].ReadOnly = true;
            gvList.Columns[9].ReadOnly = true;
            gvList.Columns[10].ReadOnly = true;
            gvList.Columns[11].ReadOnly = true;
            gvList.Columns[12].ReadOnly = true;
            #endregion

            #region alignment
            gvList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvList.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            #endregion


            //assign gl rate value to datagrid 
            gvList.Columns[7].DefaultCellStyle.NullValue = a;
            gvList.Columns[13].DefaultCellStyle.BackColor = Color.LightSkyBlue;

            gvList.Columns[14].Visible = false;
            gvList.Columns[15].Visible = false;
            
        }

        //get access on edit advance payment amount from BLMasteeSetting
          public String accessMessage;

        private void AdvancedBooking_Load(object sender, EventArgs e)
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
            cmbYear.Enabled = false;

            cmbMonth.DataSource = myYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";
            cmbMonth.SelectedValue = BLUser.strMonthID;
            cmbMonth.Enabled = false;

            advBook.RouteNo = cmbRoute.SelectedValue.ToString();
            advBook.Year = Convert.ToInt16(cmbYear.SelectedValue.ToString());
            advBook.Month = Convert.ToInt16(cmbMonth.SelectedValue.ToString());
            advBook.CheckAllRoute = chkAllRoutes.CheckState == CheckState.Checked ? 1 : 0;

            FromDate.Enabled = false;
            ToDate.Enabled = false;
            //get adv Book date
            #region advDataRange
            cmbissueDate.DataSource=advBook.GetIssueDate(Convert.ToInt16(cmbYear.SelectedValue.ToString()), Convert.ToInt16(cmbMonth.SelectedValue.ToString()));
            cmbissueDate.DisplayMember = "IssueDate";
            cmbissueDate.ValueMember = "IssueDate";
            try
            {
                DataSet issueDateRange = advBook.GetIssueDateRange(Convert.ToDateTime(cmbissueDate.SelectedValue.ToString()));
                FromDate.Value = Convert.ToDateTime(issueDateRange.Tables[0].Rows[0][0].ToString());
                ToDate.Value = Convert.ToDateTime(issueDateRange.Tables[0].Rows[0][1].ToString());
                
            }
            catch { }
            #endregion

            //get access on edit advance payment amount from BLMasteeSetting
            accessMessage = advBook.getAccessToEdit();
           

           //  loadData();
            // chkAllRoutes.Checked = false;

            #region Select data
            //  user can selet only current month days
            DateTime Now = Convert.ToDateTime(ToDate.Value.ToShortDateString());
            DateTime mindate = new DateTime(Now.Year, Convert.ToInt32(cmbMonth.SelectedValue.ToString()), 1);
            DateTime Maxdate = mindate.AddMonths(1).AddDays(-1);
            ToDate.MinDate = mindate;
            ToDate.MaxDate = Maxdate;
            FromDate.MinDate = mindate;
            FromDate.MaxDate = Maxdate;
            #endregion

            txtadvPayRate.Enabled = false;

            #region active GroupBox AdvPayment
            if (BLUser.StrUserName.ToUpper() == "ADMIN")
            {
                grpAdvBook.Enabled = true;
                txtadvPayRate.Enabled = true;
            }
            else
            {
                grpAdvBook.Enabled = false;
                txtadvPayRate.Enabled = false;
            }
            #endregion

            txtSupCode.Enabled = false;
            
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridUpdateAdvBook();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            
           // loadData();
        }

        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

           // loadData();
        }

        private void chkAllRoutes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllRoutes.Checked)
            {
                cmbRoute.Enabled = false;
                gridUpdateAdvBook();
            }
            else
            {
                cmbRoute.Enabled = true;
                gridUpdateAdvBook();
            }

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm Your Rest?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    valueAssign();
                    advBook.AdvBookDate = Convert.ToDateTime(cmbissueDate.SelectedValue.ToString());
                    for (int i = 0; i < gvList.RowCount; i++)
                    {
                        if ((gvList.Rows[i].Cells[15].Value.ToString() == "S") && (gvList.Rows[i].Cells[14].Value.ToString().ToUpper()!="TRUE"))
                        {
                            advBook.RouteNo = gvList.Rows[i].Cells[1].Value.ToString();
                            advBook.SuplieCode = gvList.Rows[i].Cells[2].Value.ToString();
                            advBook.SuplieName = gvList.Rows[i].Cells[3].Value.ToString();
                            advBook.PaymentMode = gvList.Rows[i].Cells[4].Value.ToString();
                            advBook.SelectedDateGlQty = Convert.ToDecimal(gvList.Rows[i].Cells[5].Value.ToString());
                            advBook.ToDateGlQty = Convert.ToDecimal(gvList.Rows[i].Cells[6].Value.ToString());
                            advBook.GlRate = Convert.ToDecimal((advBook.getGLRate(Convert.ToInt32(cmbMonth.SelectedValue.ToString()), Convert.ToInt32(cmbYear.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString())).ToString("N2"));
                            advBook.SelectedDateGLvalue = Convert.ToDecimal(gvList.Rows[i].Cells[8].Value.ToString());
                            advBook.ToDateGlValue = Convert.ToDecimal(gvList.Rows[i].Cells[9].Value.ToString());
                            advBook.ToDateDeduction = Convert.ToDecimal(gvList.Rows[i].Cells[10].Value.ToString());
                            advBook.SystemCalAmount = Convert.ToDecimal(gvList.Rows[i].Cells[11].Value.ToString());
                            advBook.AdvAmount = Convert.ToDecimal(gvList.Rows[i].Cells[12].Value.ToString());
                            advBook.AdvPayment = Convert.ToDecimal(gvList.Rows[i].Cells[13].Value.ToString());
                            advBook.CheckAllRoute = chkAllRoutes.CheckState == CheckState.Checked ? 1 : 0;

                        
                            advBook.insertAdvancedBook_Log();
                            advBook.deleteAdvanedBook();
                        }
                       
                    }
                     MessageBox.Show("Advane Payment of Current Month Reset Sucessfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                txtadvPayRate.Text = "100";
                cmbRoute.SelectedIndex = 0;
                gridUpdateAdvBook();
                chkAllRoutes.Checked = false;
            }
            else
            {
 
            }

        }



        private void txtadvPayRate_TextChanged(object sender, EventArgs e)
        {
            txtadvPayRate.Text = String.IsNullOrEmpty(txtadvPayRate.Text) ? "100" : txtadvPayRate.Text;
            if ((Convert.ToDecimal(txtadvPayRate.Text) < 0) || (Convert.ToDecimal(txtadvPayRate.Text) > 100))
            {
                MessageBox.Show("Enter the percentage value Between 1% And 100%");
                txtadvPayRate.Text = "100";
                txtadvPayRate.Focus();
            }

            gridUpdateAdvBook();
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Do You Want Give Advance Book?(Confirm Check Box Before Advance Book!)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                //used show messgebox 
                int messge = 0;
                try
                {
                    #region value assign
                    for (int i = 0; i < gvList.RowCount; i++)
                    {
                        if ((Convert.ToBoolean(gvList.Rows[i].Cells[0].Value) == true) && (gvList.Rows[i].Cells[14].Value.ToString().ToUpper() != "TRUE"))
                        {

                            advBook.Year = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                            advBook.Month = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                            advBook.FromDate = Convert.ToDateTime(FromDate.Value.Date);
                            advBook.ToDate = Convert.ToDateTime(ToDate.Value.Date);
                            advBook.AdvBookDate = Convert.ToDateTime(cmbissueDate.SelectedValue.ToString());

                            advBook.RouteNo = gvList.Rows[i].Cells[1].Value.ToString();
                            advBook.SuplieCode = gvList.Rows[i].Cells[2].Value.ToString();
                            advBook.SuplieName = gvList.Rows[i].Cells[3].Value.ToString();
                            advBook.PaymentMode = gvList.Rows[i].Cells[4].Value.ToString();
                            advBook.SelectedDateGlQty = Convert.ToDecimal(gvList.Rows[i].Cells[5].Value.ToString());
                            advBook.ToDateGlQty = Convert.ToDecimal(gvList.Rows[i].Cells[6].Value.ToString());
                            advBook.GlRate = Convert.ToDecimal((advBook.getGLRate(Convert.ToInt32(cmbMonth.SelectedValue.ToString()), Convert.ToInt32(cmbYear.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString())).ToString("N2"));
                            advBook.SelectedDateGLvalue = Convert.ToDecimal(gvList.Rows[i].Cells[8].Value.ToString());
                            advBook.ToDateGlValue = Convert.ToDecimal(gvList.Rows[i].Cells[9].Value.ToString());
                            advBook.ToDateDeduction = Convert.ToDecimal(gvList.Rows[i].Cells[10].Value.ToString());
                            advBook.SystemCalAmount = Convert.ToDecimal(gvList.Rows[i].Cells[11].Value.ToString());

                            if (Convert.ToDecimal(gvList.Rows[i].Cells[12].Value.ToString()) >= Convert.ToDecimal(gvList.Rows[i].Cells[13].Value.ToString()))
                            {
                                advBook.AdvAmount = Convert.ToDecimal(gvList.Rows[i].Cells[12].Value.ToString());
                                advBook.AdvPayment = Convert.ToDecimal(gvList.Rows[i].Cells[13].Value.ToString());
                            }
                            else if((Convert.ToDecimal(gvList.Rows[i].Cells[12].Value.ToString()) <= Convert.ToDecimal(gvList.Rows[i].Cells[13].Value.ToString())) && (accessMessage.ToUpper()=="YES"))
                            {
                                advBook.AdvAmount = Convert.ToDecimal(gvList.Rows[i].Cells[12].Value.ToString());
                                advBook.AdvPayment = Convert.ToDecimal(gvList.Rows[i].Cells[13].Value.ToString());

                            }
                            else
                            {
                                MessageBox.Show("Maximum Advance Payment for " + advBook.SuplieName + " (" + advBook.SuplieCode + ") is RS. " + advBook.AdvAmount.ToString() + " Please Chehck  Advaned Amount Which You Enter", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                messge = 1;
                                gridUpdateAdvBook();
                                continue;
                            }

                            
                            advBook.AddAdvancedBook();
                            messge = 2;
                        }



                    }
                    if (messge == 2)
                        MessageBox.Show("Advance Book Successfully!");
                         gridUpdateAdvBook();
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't Advance Book " + ex.ToString());
                }
            }
            else
            { }
        }
            

        private void txtSupCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtSupCode.ForeColor = Color.Black;
            txtSupCode.Clear();
        }

       
        string advRoute;
        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSupCode.Text = gvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            lblSupName.Text = gvList.Rows[e.RowIndex].Cells[3].Value.ToString();
            lblAdvAmount.Text = gvList.Rows[e.RowIndex].Cells[10].Value.ToString();
            advRoute = gvList.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void txtadvPayment_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtadvPayment.Text == "Enter Adv Payment")
            {
                txtadvPayment.Clear();
                txtadvPayment.ForeColor = Color.Black;
            }
        }

        private void btnGrpSave_Click(object sender, EventArgs e)
        {
            #region value Assign
            if (txtSupCode.Text != "")
            {
                
                try
                {
                    for (int i = 0; i < gvList.RowCount; i++)
                    {
                        if (gvList.Rows[i].Cells[2].Value.ToString() == txtSupCode.Text)
                        {

                            advBook.Year = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                            advBook.Month = Convert.ToInt32(cmbMonth.SelectedValue.ToString());

                            advBook.RouteNo = gvList.Rows[i].Cells[1].Value.ToString();
                            advBook.SuplieCode = gvList.Rows[i].Cells[2].Value.ToString();
                            advBook.SuplieName = gvList.Rows[i].Cells[3].Value.ToString();
                            advBook.PaymentMode = gvList.Rows[i].Cells[4].Value.ToString();
                            advBook.ToDateGlQty = Convert.ToDecimal(gvList.Rows[i].Cells[5].Value.ToString());
                            advBook.GlRate = Convert.ToDecimal((advBook.getGLRate(Convert.ToInt32(cmbMonth.SelectedValue.ToString()), Convert.ToInt32(cmbYear.SelectedValue.ToString()), cmbRoute.SelectedValue.ToString())).ToString("N2"));
                            advBook.ToDateGlValue = Convert.ToDecimal(gvList.Rows[i].Cells[7].Value.ToString());
                            advBook.ToDateDeduction = Convert.ToDecimal(gvList.Rows[i].Cells[8].Value.ToString());
                            advBook.SystemCalAmount = Convert.ToDecimal(gvList.Rows[i].Cells[9].Value.ToString());
                            advBook.AdvAmount = Convert.ToDecimal(gvList.Rows[i].Cells[10].Value.ToString());
                            advBook.AdvPayment = Convert.ToDecimal(txtadvPayment.Text);

                            advBook.AddAdvancedBook();
                        }



                    }
                    MessageBox.Show("Add Advance payment for " + lblSupName.Text + "  RS." + txtadvPayment.Text + " Successfully!","Advance payment",MessageBoxButtons.OK);
                    txtadvPayment.Clear();
                    txtSupCode.Clear();
                    lblSupName.Text = " ";
                    gridUpdateAdvBook();
                }

                catch 
                {
                    MessageBox.Show("Enter Adv Payment Correctly!", "Advance Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Select Suppler Code!", "Advance Payment",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            gridUpdateAdvBook();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmbissueDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet issueDateRange = advBook.GetIssueDateRange(Convert.ToDateTime(cmbissueDate.SelectedValue.ToString()));
                FromDate.Value = Convert.ToDateTime(issueDateRange.Tables[0].Rows[0][0].ToString());
                ToDate.Value = Convert.ToDateTime(issueDateRange.Tables[0].Rows[0][1].ToString());
                gridUpdateAdvBook();
            }
            catch { }
        }

        private void btnAllData_Click(object sender, EventArgs e)
        {
            gridUpdateAdvBook();

        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < gvList.RowCount; j++)
            {
                if (Convert.ToBoolean(gvList.Rows[j].Cells[0].Value) == true)
                {
                    if (gvList.Rows[j].Cells[15].Value.ToString() == "S")
                    {

                        int a = 0;
                        DialogResult dialogResult = MessageBox.Show("Confirm Your Advance Book?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                for (int i = 0; i < gvList.RowCount; i++)
                                {
                                    if (Convert.ToBoolean(gvList.Rows[i].Cells[0].Value) == true)
                                    {

                                        advBook.Year = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                                        advBook.Month = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                                        advBook.RouteNo = gvList.Rows[i].Cells[1].Value.ToString();
                                        advBook.SuplieCode = gvList.Rows[i].Cells[2].Value.ToString();
                                        advBook.AdvBookDate = Convert.ToDateTime(cmbissueDate.SelectedValue.ToString());

                                        advBook.confirmAdvBook();
                                        a = 1;
                                    }
                                }
                                if (a == 1)
                                    MessageBox.Show("Confirm Advance Book Successfully!");
                                gridUpdateAdvBook();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void gvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void gvList_CellStyleContentChanged(object sender, DataGridViewCellStyleContentChangedEventArgs e)
        {

        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    advBook.AdvBookDate = Convert.ToDateTime(cmbissueDate.SelectedValue.ToString());

            //    advBook.RouteNo = gvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    advBook.SuplieCode = gvList.Rows[e.RowIndex].Cells[2].Value.ToString();

            //    if (advBook.getConfirmAdvBook() == "YES")
            //    {
            //        MessageBox.Show("You Are Already Confirm Advnce Book.You Can't Change it.Only Admin Can Change it.", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            //        gridUpdateAdvBook();
            //    }



            //}
            //catch { }

        }

        private void btncancelConfirmAdvbook_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < gvList.RowCount; j++)
            {
                if (Convert.ToBoolean(gvList.Rows[j].Cells[0].Value) == true)
                {
                    if ((gvList.Rows[j].Cells[15].Value.ToString() == "S") && (gvList.Rows[j].Cells[14].Value.ToString().ToUpper() == "TRUE"))
                    {

                        int a = 0;
                        DialogResult dialogResult = MessageBox.Show("Confirm Your Advance Book To Cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                for (int i = 0; i < gvList.RowCount; i++)
                                {
                                    if (Convert.ToBoolean(gvList.Rows[i].Cells[0].Value) == true)
                                    {

                                        advBook.Year = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                                        advBook.Month = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                                        advBook.RouteNo = gvList.Rows[i].Cells[1].Value.ToString();
                                        advBook.SuplieCode = gvList.Rows[i].Cells[2].Value.ToString();
                                        advBook.AdvBookDate = Convert.ToDateTime(cmbissueDate.SelectedValue.ToString());

                                        advBook.cancelConfirmAdvBook();
                                        a = 1;
                                    }
                                }
                                if (a == 1)
                                    MessageBox.Show("Cancel Confirmation of Advance Book Successfully!");
                                gridUpdateAdvBook();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                }
            }
        }

    
      

        
  }
}
