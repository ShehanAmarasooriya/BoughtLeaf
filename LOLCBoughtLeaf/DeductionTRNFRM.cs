using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BoughtLeafBusinessLayer;

namespace OLAXBoughtLeaf
{
    public partial class DeductionsTRNFRM : Form
    {
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLDeductionGroup DeductGroupMaster = new BoughtLeafBusinessLayer.BLDeductionGroup();
        BoughtLeafBusinessLayer.BLDeductionCode DeductMaster = new BoughtLeafBusinessLayer.BLDeductionCode();
        BoughtLeafBusinessLayer.SupplierDeduction mySupplierDeduction = new BoughtLeafBusinessLayer.SupplierDeduction();
        BoughtLeafBusinessLayer.BLFinancialYear myYear = new BoughtLeafBusinessLayer.BLFinancialYear();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();

        public DeductionsTRNFRM()
        {
            InitializeComponent();
        }

        private void Deduction_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = myYear.ListAllVisibleYears();
            cmbYear.DisplayMember = "YearCode";
            cmbYear.ValueMember = "YearCode";
            cmbYear.Text = BLUser.StrYear;

            cmbMonth.DataSource = myYear.ListAllMonths(Convert.ToInt32(cmbYear.SelectedValue.ToString()));
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthCode";
            cmbMonth.SelectedValue = BLUser.strMonthID;

            cmbDeductionGroup.SelectedIndexChanged -= new EventHandler(cmbDeductionGroup_SelectedIndexChanged);
            cmbDeductionGroup.DataSource = DeductGroupMaster.LoadComboboxGroupCode();
            cmbDeductionGroup.DisplayMember = "GroupName";
            cmbDeductionGroup.ValueMember = "GroupCode";
            cmbDeductionGroup.SelectedIndexChanged += new EventHandler(cmbDeductionGroup_SelectedIndexChanged);

            cmbDeductionGroup_SelectedIndexChanged(null, null);
        }

        private void cmbDeductions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSupCode.Focus();
            }
        }

        private void assignSupDetail()
        {
            string locSupCode = supCodeChange(txtSupCode.Text);

            if (locSupCode.Trim().Equals("NA"))
            {
                MessageBox.Show("Please Select Correct Supplier Code for selected Route.");
                txtSupCode.Text = string.Empty;
                txtSupName.Text = string.Empty;
                txtSupCode.Focus();
            }
            else
            {
                txtSupCode.Text = locSupCode;
                txtSupName.Text = mySupplier.getSupplierName(locSupCode);
                if (txtSupName.Text == "NA")
                {
                    MessageBox.Show("This Supplier Code Does Not exists");
                    txtSupCode.Text = "";
                    txtSupName.Text = "";
                    txtSupCode.Focus();
                    return;
                }
                lblLeaf.Text = mySupplier.getSupCurrentLeaf(locSupCode,Convert.ToInt32(cmbYear.SelectedValue.ToString()),Convert.ToInt32(cmbMonth.SelectedValue.ToString())).ToString("N2") + " Kg";
                lblFertOut.Text = mySupplier.getSupCurrentFertOut(locSupCode).ToString("N2");
                lblLoanOut.Text = mySupplier.getSupCurrentLoanOut(locSupCode).ToString("N2"); ;
                lblOtherOut.Text = mySupplier.getSupCurrentOtherOut(locSupCode).ToString("N2"); ;
                lblAdvaneOut.Text = mySupplier.getSupCurrentAdvanceOut(locSupCode).ToString("N2"); ;
                lblTotOut.Text = Convert.ToString(Convert.ToDecimal(lblFertOut.Text) + Convert.ToDecimal(lblLoanOut.Text) + Convert.ToDecimal(lblOtherOut.Text) + Convert.ToDecimal(lblAdvaneOut.Text));
                if (rbFerti.Checked)
                    txtFertiNoBags.Focus();
                else if (rbTeaIssue.Checked)
                    txtTeaNoBags.Focus();
                else
                     txtDeductAmount.Focus();
            }
        }

        private void txtEmpNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                assignSupDetail();
            }
        }

        //sacchintha udara add new method for change supplier code with four zero prefix
        // 1 is like 0001
        private string supCodeChange(string pSupCode)
        {
            return pSupCode.PadLeft(5, '0');
            //return pSupCode;
        }

        private void txtDeductAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {

                    if (txtNoOfMonths.Enabled == false)
                    {
                        txtBalance.Text = Convert.ToString(Convert.ToDecimal(txtDeductAmount.Text) * Convert.ToDecimal(txtNoOfMonths.Text));

                        cmdAdd.Focus();
                    }
                    else
                        txtNoOfMonths.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            
        }

        private void txtNoOfMonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmdAdd.Enabled == true)
                    cmdAdd.Focus();
                else if (cmdUpdate.Enabled == true)
                    cmdUpdate.Focus();
            }
        }

        private void chkDirectPay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDirectPay.Checked)
            {
                gbDirectPay.Enabled = true;
                dtpDP.Focus();
            }
            else
            {
                gbDirectPay.Enabled = false;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            String strUpdateStatus = "";
            #region FixedDeductionUpdate
            if (txtDeductAmount.Text == "")
            {
                MessageBox.Show("txtDeduct Amount can not be empty");
                txtDeductAmount.Focus();
            }
            else if (txtNoOfMonths.Text == "")
            {
                MessageBox.Show("No Of Months can not be empty");
                txtNoOfMonths.Focus();
            }
            else
            {
                mySupplierDeduction.IntFixedDeductId = Convert.ToInt32(lblRefNo1.Text);
                mySupplierDeduction.StrDeductionGroupCode = cmbDeductionGroup.SelectedValue.ToString();
                mySupplierDeduction.StrDeductionCode = cmbDeductionCode.SelectedValue.ToString();
                mySupplierDeduction.StrDeductionCode = cmbDeductionCode.SelectedValue.ToString();
                mySupplierDeduction.StrRouteNo = mySupplier.getRoute(supCodeChange(txtSupCode.Text));
                mySupplierDeduction.StrSupNo = supCodeChange(txtSupCode.Text);
                mySupplierDeduction.IntNoOfMonths = Convert.ToInt32(txtNoOfMonths.Text);
                mySupplierDeduction.IntFromYear = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                mySupplierDeduction.IntFromMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                mySupplierDeduction.FromDate = new DateTime(mySupplierDeduction.IntFromYear,mySupplierDeduction.IntFromMonth,1);


                if (rbFerti.Checked)
                {
                    mySupplierDeduction.FromDate = dtpFertiIssueData.Value.Date;
                    mySupplierDeduction.NoBags = Convert.ToDecimal(txtFertiNoBags.Text);
                    mySupplierDeduction.CostPerBag = Convert.ToDecimal(txtFertiCostPerBag.Text);
                    mySupplierDeduction.CostPerBagCommission = Convert.ToDecimal(txtFertiCom.Text);
                    //mySupplierDeduction.DecDeductAmount = (mySupplierDeduction.NoBags * (mySupplierDeduction.CostPerBag + mySupplierDeduction.CostPerBagCommission)) / mySupplierDeduction.IntNoOfMonths;
                    mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                }
                else if (rbLoan.Checked)
                {
                    //select automatically 1st date of every month
                    mySupplierDeduction.FromDate = new DateTime(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue), 1);
                    mySupplierDeduction.NoBags = 0;
                    mySupplierDeduction.CostPerBag = 0;
                    mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                }
                else if (rbTeaIssue.Checked)
                {
                    mySupplierDeduction.FromDate = dtpTeaIssueData.Value.Date;
                    mySupplierDeduction.NoBags = Convert.ToDecimal(txtTeaNoBags.Text);
                    mySupplierDeduction.CostPerBag = Convert.ToDecimal(txtTeaCostPerBag.Text);
                    mySupplierDeduction.CostPerBagCommission = Convert.ToDecimal(txtTeaCom.Text);
                    mySupplierDeduction.DecDeductAmount = (mySupplierDeduction.NoBags * (mySupplierDeduction.CostPerBag + mySupplierDeduction.CostPerBagCommission)) / mySupplierDeduction.IntNoOfMonths;
                }
                else if (rbCashAdvance.Checked)
                {
                    mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                }

                mySupplierDeduction.DecPrincipalAmount = mySupplierDeduction.DecDeductAmount * mySupplierDeduction.IntNoOfMonths;
                mySupplierDeduction.DecBalanceAmount = mySupplierDeduction.DecPrincipalAmount;
                mySupplierDeduction.DecRecoveredAmount = 0;
                mySupplierDeduction.DecRecoveredInstallments = 0;
                mySupplierDeduction.StrUserId = BoughtLeafBusinessLayer.BLUser.StrUserName;
                if (chkFixed.Checked)
                {
                    mySupplierDeduction.BoolFixed = true;
                }
                else
                {
                    mySupplierDeduction.BoolFixed = false;
                }
                if (mySupplierDeduction.IsRecoveredDeduction(dtpFertiIssueData.Value.Date, mySupplierDeduction.IntFromYear, mySupplierDeduction.IntFromMonth, cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), txtSupCode.Text))
                //if(true)
                {
                    if (MessageBox.Show("Confirm To Update Only Monthly Deduct Amount -Balance Amount Of Deduction Will Not Change...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        strUpdateStatus = mySupplierDeduction.UpdateDeductions();
                        if (strUpdateStatus.Equals("UPDATED"))
                        {
                            MessageBox.Show("Fixed Deductions Updated Successfully");
                            AfterAdd();
                        }
                        else if (strUpdateStatus.Equals("DAUPDATED"))
                        {
                            MessageBox.Show("Fixed Deduction Deduct Amount Updated Successfully");
                            AfterAdd();
                        }
                        else
                        {
                            MessageBox.Show("Fixed Deduction Update Failed");
                        }
                    }
                }
                else
                {
                    strUpdateStatus = mySupplierDeduction.UpdateDeductions();
                    if (strUpdateStatus.Equals("UPDATED"))
                    {
                        MessageBox.Show("Fixed Deductions Updated Successfully");
                        AfterAdd();
                    }
                    else if (strUpdateStatus.Equals("DAUPDATED"))
                    {
                        MessageBox.Show("Fixed Deduction Deduct Amount Updated Successfully");
                        AfterAdd();
                    }
                    else
                    {
                        MessageBox.Show("Fixed Deduction Update Failed");
                    }
                }
            }
            #endregion
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            String strRtnStatus = "";
            if (String.IsNullOrEmpty(txtSupCode.Text))
            {
                MessageBox.Show("EmpNo can not be empty");
                txtSupCode.Focus();
            }
            else if (txtNoOfMonths.Text == "" || Convert.ToInt32(txtNoOfMonths.Text) < 1)
            {
                MessageBox.Show("No Of Months Can Not Be Empty Or Less Than 1");
                txtNoOfMonths.Focus();
            }
            else
            {
                try
                {
                    mySupplierDeduction.StrDeductionGroupCode = cmbDeductionGroup.SelectedValue.ToString();
                    mySupplierDeduction.StrDeductionCode = cmbDeductionCode.SelectedValue.ToString();
                    mySupplierDeduction.StrRouteNo = mySupplier.getRoute(supCodeChange(txtSupCode.Text));
                    mySupplierDeduction.StrSupNo = supCodeChange(txtSupCode.Text);
                    mySupplierDeduction.IntNoOfMonths = Convert.ToInt32(txtNoOfMonths.Text);
                    mySupplierDeduction.IntFromYear = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                    mySupplierDeduction.IntFromMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                    mySupplierDeduction.FromDate = dtIssueDate.Value.Date;
                    mySupplierDeduction.StrUserId = BLUser.StrUserName;
                    //----------------------------------------------------------------
                    if (rbFerti.Checked)
                    {
                        mySupplierDeduction.FromDate = dtpFertiIssueData.Value.Date;
                        mySupplierDeduction.NoBags = Convert.ToDecimal(txtFertiNoBags.Text);
                        mySupplierDeduction.CostPerBag = Convert.ToDecimal(txtFertiCostPerBag.Text);
                        mySupplierDeduction.CostPerBagCommission = Convert.ToDecimal(txtFertiCom.Text);
                        mySupplierDeduction.DecDeductAmount = (mySupplierDeduction.NoBags * (mySupplierDeduction.CostPerBag + mySupplierDeduction.CostPerBagCommission)) / mySupplierDeduction.IntNoOfMonths;
                    }
                    else if (rbLoan.Checked)
                    {
                        //select automatically 1st date of every month
                        mySupplierDeduction.FromDate = dtIssueDate.Value.Date;
                        mySupplierDeduction.NoBags = 0;
                        mySupplierDeduction.CostPerBag = 0;
                        mySupplierDeduction.CostPerBagCommission = 0;
                        mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                    }
                    else if (rbTeaIssue.Checked)
                    {
                        mySupplierDeduction.FromDate = dtpTeaIssueData.Value.Date;
                        mySupplierDeduction.NoBags = Convert.ToDecimal(txtTeaNoBags.Text);
                        mySupplierDeduction.CostPerBag = Convert.ToDecimal(txtTeaCostPerBag.Text);
                        mySupplierDeduction.CostPerBagCommission = Convert.ToDecimal(txtTeaCom.Text);
                        mySupplierDeduction.DecDeductAmount = (mySupplierDeduction.NoBags * (mySupplierDeduction.CostPerBag + mySupplierDeduction.CostPerBagCommission)) / mySupplierDeduction.IntNoOfMonths;
                        mySupplierDeduction.DecPrincipalAmount = mySupplierDeduction.DecDeductAmount;
                    }
                    else if (rbCashAdvance.Checked)
                    {
                        //mySupplierDeduction.FromDate = new DateTime(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue), 1);
                        mySupplierDeduction.FromDate = dtIssueDate.Value.Date;
                        mySupplierDeduction.NoBags = 0;//Convert.ToDecimal(txtTeaNoBags.Text);
                        mySupplierDeduction.CostPerBag = 0;// Convert.ToDecimal(txtTeaCostPerBag.Text);
                        mySupplierDeduction.CostPerBagCommission = 0;// Convert.ToDecimal(txtTeaCom.Text);
                        mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                        mySupplierDeduction.DecPrincipalAmount = mySupplierDeduction.DecDeductAmount * mySupplierDeduction.IntNoOfMonths;

                        //(mySupplierDeduction.NoBags * (mySupplierDeduction.CostPerBag + mySupplierDeduction.CostPerBagCommission)) / mySupplierDeduction.IntNoOfMonths;
                    }
                    else 
                    {
                        //mySupplierDeduction.FromDate = new DateTime(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.SelectedValue), 1);
                        mySupplierDeduction.FromDate = dtIssueDate.Value.Date;
                        mySupplierDeduction.NoBags = 0;//Convert.ToDecimal(txtTeaNoBags.Text);
                        mySupplierDeduction.CostPerBag = 0;// Convert.ToDecimal(txtTeaCostPerBag.Text);
                        mySupplierDeduction.CostPerBagCommission = 0;// Convert.ToDecimal(txtTeaCom.Text);
                        mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                        mySupplierDeduction.DecPrincipalAmount = mySupplierDeduction.DecDeductAmount * mySupplierDeduction.IntNoOfMonths;

                        //(mySupplierDeduction.NoBags * (mySupplierDeduction.CostPerBag + mySupplierDeduction.CostPerBagCommission)) / mySupplierDeduction.IntNoOfMonths;
                    }

                    //----------------------------------------------------------------
                    //********* Special note please change bellow code ***************
                    
                   // mySupplierDeduction.DecPrincipalAmount = mySupplierDeduction.DecDeductAmount * mySupplierDeduction.IntNoOfMonths;
                    mySupplierDeduction.DecBalanceAmount = mySupplierDeduction.DecPrincipalAmount;
                    mySupplierDeduction.DecRecoveredAmount = 0;
                    mySupplierDeduction.DecRecoveredInstallments = 0;
                    mySupplierDeduction.BoolCloseYesNo = false;
                    mySupplierDeduction.StrGur1Div = "NA";
                    mySupplierDeduction.Gurantor1 = "NA";
                    mySupplierDeduction.StrGur2Div = "NA";
                    mySupplierDeduction.Gurantor2 = "NA";

                    mySupplierDeduction.BoolFixed = false;

                    //What is this code 
                    //DataTable DtBalance = mySupplierDeduction.GetBalanceAmounts(mySupplierDeduction.StrRouteNo, mySupplierDeduction.StrSupNo, mySupplierDeduction.StrDeductionGroupCode, mySupplierDeduction.StrDeductionCode);

                    //if (DtBalance.Rows.Count > 0)
                    //{
                    //    MessageBox.Show("Cannot Add Fixed Deduction,\r\n\r\nEmployee " + txtSupCode.Text + " Has a " + cmbDeductionCode.Text + " Deduction Balance On " + DtBalance.Rows[0][1].ToString() + "/" + DtBalance.Rows[0][2].ToString(), "Error");
                    //    txtSupCode.Focus();
                    //if (MessageBox.Show("Go To Deduction", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //{
                    //    txtSearchEmpNo.Text = txtEmpNo.Text;
                    //    txtSearchEmpNo_TextChanged(null, null);
                    //}
                    // }
                    // else
                    // {
                    try
                    {
                        strRtnStatus = mySupplierDeduction.InsertDeductions();
                        if (strRtnStatus.Equals("ADDED"))
                        {
                            MessageBox.Show("Fixed Deductions Added Successfully");
                            AfterAdd();
                        }
                        else if (strRtnStatus.Equals("EXISTS"))
                        {
                            MessageBox.Show("Fixed Deductions Already Exists");
                        }
                        else
                        {
                            MessageBox.Show("Error , Fixed Deduction Failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error On Insert Fixed Deductions " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! , Duplicate Entry.");
                }
            }
        }

        private void AfterAdd()
        {
            try
            {
                txtSearchEmpNo.Clear();
                lbl_search_by.Text = "Click Colum Header";
                txtDeductAmount.Text = string.Empty;
                txtNoOfMonths.Text = string.Empty;

                txtFertiCostPerBag.Text = string.Empty;
                txtFertiNoBags.Text = string.Empty;
                txtFertiCom.Text = string.Empty;

                txtTeaCostPerBag.Text = string.Empty;
                txtTeaNoBags.Text = string.Empty;
                txtTeaCom.Text = string.Empty;
            }
            catch { }
            finally
            {
                /*Enable disbled fields*/
                txtSupCode.Enabled = true;
                cmbDeductionGroup.Enabled = true;
                cmbDeductionCode.Enabled = true;
                cmbYear.Enabled = true;
                cmbMonth.Enabled = true;

                txtSupCode.Clear();
                txtSupName.Text = string.Empty;
                txtBalance.Clear();
                cmdAdd.Enabled = true;
                cmdUpdate.Enabled = false;
                cmdDelete.Enabled = false;

                lblLeaf.Text = string.Empty;
                lblFertOut.Text = string.Empty;
                lblLoanOut.Text = string.Empty;
                lblOtherOut.Text = string.Empty;
                lblAdvaneOut.Text = string.Empty;
                lblTotOut.Text = string.Empty;
                cmbDeductions_SelectedIndexChanged(null, null);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            #region FixedDeductionDelete
            if (MessageBox.Show("Confirm Cancel...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                mySupplierDeduction.IntFixedDeductId = Convert.ToInt32(lblRefNo1.Text);
                mySupplierDeduction.StrDeductionCode = cmbDeductionCode.SelectedValue.ToString();
                mySupplierDeduction.StrSupNo = txtSupCode.Text.PadLeft(4, '0');
                mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                mySupplierDeduction.StrDeductionGroupCode = cmbDeductionGroup.SelectedValue.ToString();
                mySupplierDeduction.StrDeductionCode = cmbDeductionCode.SelectedValue.ToString();
                mySupplierDeduction.StrUserId = BoughtLeafBusinessLayer.BLUser.StrUserName;
                mySupplierDeduction.IntFromYear = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                mySupplierDeduction.IntFromMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                mySupplierDeduction.FromDate = dtpFertiIssueData.Value.Date;

                //tempory code until get id from empdeductions
                if (mySupplierDeduction.IsRecoveredDeduction(dtpFertiIssueData.Value.Date, mySupplierDeduction.IntFromYear, mySupplierDeduction.IntFromMonth, cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), txtSupCode.Text))
                //if(true)
                {
                    MessageBox.Show("Cannot Delete, Already Recovered From This Entry But You May Terminate");
                }
                else
                {
                    try
                    {
                        mySupplierDeduction.DeleteFixedDeductions();
                        MessageBox.Show("Fixed Deductions Deleted Successfully");
                        AfterAdd();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error, " + ex.Message);
                    }
                }
            }
            #endregion
        }

        private void cmbDeductionGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbDeductionCode.Focus();
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblRefNo1.Text))
            {
                if (String.IsNullOrEmpty(txtReason.Text))
                {
                    MessageBox.Show("You Must Enter A Valid Reason To Terminate");
                    txtReason.Focus();
                }
                else
                {
                    if (MessageBox.Show("Confirm Terminate...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mySupplierDeduction.IntFixedDeductId = Convert.ToInt32(lblRefNo1.Text);
                        mySupplierDeduction.StrDeductionCode = cmbDeductionCode.SelectedValue.ToString();
                        mySupplierDeduction.StrSupNo = txtSupCode.Text;
                        mySupplierDeduction.DecDeductAmount = Convert.ToDecimal(txtDeductAmount.Text);
                        mySupplierDeduction.StrDeductionGroupCode = cmbDeductionGroup.SelectedValue.ToString();
                        mySupplierDeduction.StrDeductionCode = cmbDeductionCode.SelectedValue.ToString();
                        mySupplierDeduction.StrUserId = BoughtLeafBusinessLayer.BLUser.StrUserName;
                        mySupplierDeduction.IntFromYear = Convert.ToInt32(cmbYear.SelectedValue.ToString());
                        mySupplierDeduction.IntFromMonth = Convert.ToInt32(cmbMonth.SelectedValue.ToString());
                        mySupplierDeduction.StrReason = txtReason.Text;
                        try
                        {
                            mySupplierDeduction.TerminateFixedDeductions();
                            MessageBox.Show("Fixed Deductions Terminated Successfully");
                            try
                            {
                                AfterAdd();
                            }
                            catch { }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error, " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Fixed Deduction Is Selected To Terminate");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            AfterAdd();
        }

        private void clearSpecialControllers()
        {
            //Fertilizer
            txtFertiCostPerBag.Text = string.Empty;
            txtFertiNoBags.Text = string.Empty;
            txtFertiCom.Text = string.Empty;
            dtpFertiIssueData.Text = DateTime.Now.Date.ToString();

            //Tea Issue
            txtTeaCostPerBag.Text = string.Empty;
            txtTeaNoBags.Text = string.Empty;
            txtTeaCom.Text = string.Empty;
            dtpTeaIssueData.Text = DateTime.Now.Date.ToString();
        }

        private void cmbDeductionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearSpecialControllers();
            cmbDeductionCode.SelectedIndexChanged -= new EventHandler(cmbDeductions_SelectedIndexChanged);

            cmbDeductionCode.DataSource = DeductMaster.ViewAllDeductionByGroup(cmbDeductionGroup.SelectedValue.ToString());
            cmbDeductionCode.DisplayMember = "DeductionName";
            cmbDeductionCode.ValueMember = "DeductionCode";

            TypeSelection();

            cmbDeductionCode.SelectedIndexChanged += new EventHandler(cmbDeductions_SelectedIndexChanged);
            cmbDeductions_SelectedIndexChanged(null, null);

            lblTotal.Text = mySupplierDeduction.GetOutstandingFixedDeductionTotal(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), "%").ToString("N2");
            txtSupCode.Focus();
        }

        private void TypeSelection()
        {
            string deductType = DeductGroupMaster.deductType(cmbDeductionGroup.SelectedValue.ToString());

            if (deductType.Equals("LOAN"))
            {
                gbLoan.Enabled = true;
                gbTeaIssues.Enabled = false;
                gbFerti.Enabled = false;
                rbLoan.Checked = true;
                txtNoOfMonths.Enabled = true;
            }
            else if (deductType.Equals("FERTILIZER"))
            {
                gbFerti.Enabled = true;
                gbTeaIssues.Enabled = false;
                gbLoan.Enabled = true;
                rbFerti.Checked = true;
                txtNoOfMonths.Enabled = true;
            }
            else if (deductType.Equals("TEA ISSUES"))
            {
                gbTeaIssues.Enabled = true;
                gbFerti.Enabled = false;
                gbLoan.Enabled = false;
                txtNoOfMonths.Enabled = true;
                rbTeaIssue.Checked = true;
            }
            else if (deductType.Equals("CASH ADVANCE"))
            {
                gbLoan.Enabled = true;
                gbTeaIssues.Enabled = false;
                gbFerti.Enabled = false;

                rbCashAdvance.Checked = true;
                txtNoOfMonths.Text = "1";
                txtNoOfMonths.Enabled = false;
            }
            else if (deductType.Equals("OTHER"))
            {
                gbLoan.Enabled = true;
                gbTeaIssues.Enabled = false;
                gbFerti.Enabled = false;
                txtNoOfMonths.Enabled = true;
                rbOther.Checked = true;
            }
            else
            {
                gbLoan.Enabled = true;
                gbTeaIssues.Enabled = false;
                gbFerti.Enabled = false;
                txtNoOfMonths.Enabled = true;
                rbOther.Checked = true;
            }
        }

        private void cmbDeductions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTotal.Text = mySupplierDeduction.GetOutstandingFixedDeductionTotal(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), "%").ToString("N2");
            gvListDeductions.DataSource = null;
            TypeSelection();
            if (gbFerti.Enabled)
            {
                gvListDeductions.DataSource = mySupplierDeduction.ListOutstandingFixedDeductions(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), "%", "Tea_Ferti");
                txtFertiCostPerBag.Text = DeductMaster.getDeductionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
                txtFertiCom.Text = DeductMaster.getDeductionCommisionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
            }
            else if (gbTeaIssues.Enabled)
            {
                gvListDeductions.DataSource = mySupplierDeduction.ListOutstandingFixedDeductions(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), "%", "Tea_Ferti");
                txtTeaCostPerBag.Text = DeductMaster.getDeductionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
                txtTeaCom.Text = DeductMaster.getDeductionCommisionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
            }
            else 
                gvListDeductions.DataSource = mySupplierDeduction.ListOutstandingFixedDeductions(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), "%", "%");

            dtIssueDate.Focus();
        }

        private void GridRefresh(String StringSupplierCode)
        {
            lblTotal.Text = mySupplierDeduction.GetOutstandingFixedDeductionTotal(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(),StringSupplierCode ).ToString("N2");
            gvListDeductions.DataSource = null;
            TypeSelection();
            if (gbFerti.Enabled)
            {
                gvListDeductions.DataSource = mySupplierDeduction.ListOutstandingFixedDeductions(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), StringSupplierCode, "Tea_Ferti");
                txtFertiCostPerBag.Text = DeductMaster.getDeductionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
                txtFertiCom.Text = DeductMaster.getDeductionCommisionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
            }
            else if (gbTeaIssues.Enabled)
            {
                gvListDeductions.DataSource = mySupplierDeduction.ListOutstandingFixedDeductions(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), StringSupplierCode, "Tea_Ferti");
                txtTeaCostPerBag.Text = DeductMaster.getDeductionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
                txtTeaCom.Text = DeductMaster.getDeductionCommisionAmount(cmbDeductionCode.SelectedValue.ToString()).ToString();
            }
            else
                gvListDeductions.DataSource = mySupplierDeduction.ListOutstandingFixedDeductions(cmbDeductionGroup.SelectedValue.ToString(), cmbDeductionCode.SelectedValue.ToString(), StringSupplierCode, "%");

            if(StringSupplierCode.Equals("%"))
            txtSupCode.Focus();
        }

        private void gvListDeductions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            { return; }

            gbTerminate.Enabled = true;

            if (cmbDeductionGroup.SelectedValue.ToString() == "MA" || cmbDeductionGroup.SelectedValue.ToString() == "FA")
            {
                gbTerminate.Enabled = false;
                txtReason.Text = "";
            }
            else
            {
                gbTerminate.Enabled = true;
            }

            lblRefNo1.Text = gvListDeductions.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtSupCode.Text = gvListDeductions.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSupName.Text = mySupplier.getSupplierName(txtSupCode.Text);
            cmbDeductionGroup.SelectedValue = gvListDeductions.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbDeductionCode.SelectedValue = gvListDeductions.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDeductAmount.Text = gvListDeductions.Rows[e.RowIndex].Cells[8].Value.ToString();

            Decimal intNoOfMonths = Convert.ToDecimal(gvListDeductions.Rows[e.RowIndex].Cells[9].Value.ToString());
            txtNoOfMonths.Text = Decimal.ToInt32(intNoOfMonths).ToString();
            cmbYear.SelectedValue = Convert.ToInt32(gvListDeductions.Rows[e.RowIndex].Cells[1].Value.ToString());
            cmbMonth.SelectedValue = Convert.ToInt32(gvListDeductions.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtBalance.Text = gvListDeductions.Rows[e.RowIndex].Cells[10].Value.ToString();

            if (rbFerti.Checked)
            {
                dtpFertiIssueData.Text = gvListDeductions.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtFertiNoBags.Text = gvListDeductions.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtFertiCostPerBag.Text = gvListDeductions.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            else if (rbTeaIssue.Checked) 
            {
                dtpTeaIssueData.Text = gvListDeductions.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTeaNoBags.Text = gvListDeductions.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtTeaCostPerBag.Text = gvListDeductions.Rows[e.RowIndex].Cells[7].Value.ToString();
            }

            TypeSelection();


            /*Disable fields*/
            txtSupCode.Enabled = false;
            cmbDeductionGroup.Enabled = false;
            cmbDeductionCode.Enabled = false;
            cmbYear.Enabled = false;
            cmbMonth.Enabled = false;

            cmdUpdate.Enabled = true;
            cmdDelete.Enabled = true;
            cmdAdd.Enabled = false;
        }

        private void txtNoOfMonths_TextChanged(object sender, EventArgs e)
        {
            if (!rbFerti.Checked && !rbTeaIssue.Checked)
            {
                try
                {
                    txtBalance.Text = Convert.ToString(Convert.ToDecimal(txtDeductAmount.Text) * Convert.ToDecimal(txtNoOfMonths.Text));
                }
                catch
                {
                    return;
                }
            }
        }

        private void txtFertiNoBags_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtBalance.Text = Convert.ToString(Convert.ToDecimal(txtFertiNoBags.Text) * (Convert.ToDecimal(txtFertiCostPerBag.Text) + Convert.ToDecimal(txtFertiCom.Text)));
            }
            catch
            {
                return;
            }
        }

        private void txtTeaNoBags_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtBalance.Text = Convert.ToString(Convert.ToDecimal(txtTeaNoBags.Text) * (Convert.ToDecimal(txtTeaCostPerBag.Text) + Convert.ToDecimal(txtTeaCom.Text)));
            }
            catch
            {
                return;
            }
        }

        private void btnSupSearch_Click(object sender, EventArgs e)
        {
            try
            {


                DataSet ds = new DataSet();
                DataTable dt;
                DataTable dtal;
                //TreeMaster treeMaster = new TreeMaster();
                //FTSPayRollBL.EmployeeMaster myEmployee = new FTSPayRollBL.EmployeeMaster();
                //Additions adOj = new Additions();
               // dt = myEmployee.ListAllEmployess();
                // ds.Tables.Add(dt);
                //dtal = adOj.ALLAdditions();
                //ds.Tables.Add(dt);
                //ds = treeMaster.GetAllTreeMaster();
                ds = mySupplier.GetBoughtLeafSuppliersByCode("%", "%");
                frmSearchBox fsb = new frmSearchBox(ds);

                // Dictionary<int, string> fontFormat = new Dictionary<int, string>();
                //fontFormat.Add(0, "DL-Paras.");
                //fontFormat.Add(1, "0KDSAMAN");
                //fontFormat.Add(2, "DL-Paras.");
                //fsb.columnFonts = fontFormat;

                Dictionary<int, int> columnWidth = new Dictionary<int, int>();
                columnWidth.Add(0, 60);
                columnWidth.Add(1, 150);
                columnWidth.Add(2, 50);
                columnWidth.Add(3, 100);
                columnWidth.Add(4, 60);
                columnWidth.Add(5, 100);
                fsb.columnWidth = columnWidth;

                //Dictionary<int, string> columnFontFormat = new Dictionary<int, string>();
                //columnFontFormat.Add(2, "yyyy/MM/dd");
                // fsb.columnFontFormat = columnFontFormat;

                // Dictionary<int, DataGridViewContentAlignment> columnTextAlignment = new Dictionary<int, DataGridViewContentAlignment>();
                //columnTextAlignment.Add(0, DataGridViewContentAlignment.MiddleLeft);
                // columnTextAlignment.Add(1, DataGridViewContentAlignment.MiddleLeft);
                //fsb.columnTextAlignment = columnTextAlignment;
                fsb.searchIndex1 = 0;
                fsb.searchIndex2 = 1;
                fsb.searchIndex3 = 2;
                fsb.ShowDialog();
                //txtTreeCatCode.Enabled = true;

                if (fsb.drResult != null)
                {
                    // txtAdditionCode.Text = fsb.drResult["Addition Code"].ToString();
                    // txtAdditionName.Text = fsb.drResult["Addition Name"].ToString();
                    txtSupCode.Text = fsb.drResult["SupplierCode"].ToString();
                    txtSupName.Text = fsb.drResult["SupplierName"].ToString();
                    txtSupCode.Focus();
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtFertiNoBags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtFertiCostPerBag.Focus();
        }

        private void txtTeaNoBags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNoOfMonths.Focus();
        }

        private void btnDeductRegister_Click(object sender, EventArgs e)
        {
            DataTable dsReport = new DataTable();
            dsReport = mySupplierDeduction.GetDeductionRegister().Tables[0];
            if (dsReport.Rows.Count > 0)
            {
                dsReport.WriteXml("SuppliyerDeductionRegister.xml");
                SupplierDeductionRegisterRPT myReport = new SupplierDeductionRegisterRPT();
                myReport.SetDataSource(dsReport);
                ReportViewer rptViewer = new ReportViewer();
                myReport.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
                rptViewer.crystalReportViewer1.ReportSource = myReport;
                rptViewer.Show();
            }
            else
            {
                MessageBox.Show("No Data To Preview.");
            }

        }

        private void txtFertiCostPerBag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtFertiCom.Focus();

        }

        private void txtFertiCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNoOfMonths.Focus();
        }

        private void txtSearchEmpNo_TextChanged(object sender, EventArgs e)
        {
            if (lbl_search_by.Text != "Click Colum Header")
            {
                try
                {
                    if (txtSearchEmpNo.Text != "" || lbl_search_by.Text != "Click Colum Header")
                    {
                        (gvListDeductions.DataSource as DataTable).DefaultView.RowFilter = string.Format(lbl_search_by.Text + " like'%{0}%'", txtSearchEmpNo.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please Select the header and Enter Value");
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); cmdClear.PerformClick(); }
            }
            else
            {
               // MessageBox.Show("Please Select The Column");
            }
        }

        private void dtIssueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSupCode.Focus();
            }
            
        }

        private void dtpTeaIssueData_Leave(object sender, EventArgs e)
        {
            dtpFertiIssueData.Value = dtIssueDate.Value.Date;
            dtpTeaIssueData.Value = dtIssueDate.Value.Date;
        }

        private void dtIssueDate_Leave(object sender, EventArgs e)
        {
            dtpFertiIssueData.Value = dtIssueDate.Value.Date;
            dtpTeaIssueData.Value = dtIssueDate.Value.Date;
        }

        private void txtSearchEmpNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(lbl_search_by.Text !="Click Colum Header")
            {
                if (e.KeyChar == 13)
                {

                    try
                    {
                        if (txtSearchEmpNo.Text != "" || lbl_search_by.Text != "Click Colum Header")
                        {
                            (gvListDeductions.DataSource as DataTable).DefaultView.RowFilter = string.Format(lbl_search_by.Text + " like'%{0}%'", txtSearchEmpNo.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please Select the header and Enter Value");
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); cmdClear.PerformClick(); }
                }
                else
                {
                   // MessageBox.Show("Please Select The Column");
                }

            }
        }

        private void gvListDeductions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSearchEmpNo.Clear();
            string header_text = "";
            header_text = gvListDeductions.Columns[e.ColumnIndex].DataPropertyName;
            lbl_search_by.Text = header_text;
            txtSearchEmpNo.Focus();
        }
    }
}