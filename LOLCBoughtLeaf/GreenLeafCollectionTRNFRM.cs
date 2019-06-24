using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace OLAXBoughtLeaf
{
    public partial class GreenLeafCollectionTRNFRM : Form
    {
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.GreenLeaf myGreenLeaf = new BoughtLeafBusinessLayer.GreenLeaf();
        BoughtLeafBusinessLayer.BLTransportCost myTran = new BoughtLeafBusinessLayer.BLTransportCost();
        BoughtLeafBusinessLayer.BLCollector myCollector = new BoughtLeafBusinessLayer.BLCollector();
        BoughtLeafBusinessLayer.BLSettings mySettings = new BoughtLeafBusinessLayer.BLSettings();

        String strAllRoute = "%";
        int rowI = 0;
        public GreenLeafCollectionTRNFRM()
        {
            InitializeComponent();
        }

        private void GreenLeafCollection_Load(object sender, EventArgs e)
        {
            cmbCollector.DataSource = myCollector.getCollectors();
            cmbCollector.DisplayMember = "CollectorName";
            cmbCollector.ValueMember = "CollectorCode";

            cmbTrncode.DataSource = myTran.getTransportCost();
            cmbTrncode.DisplayMember = "Code";
            cmbTrncode.ValueMember = "Cost";

            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";

            cmbLeafType.Text = "Good";
            cmbLeafType.DataSource = mySettings.ListBLMasterRates("LeafQuality");
            cmbLeafType.DisplayMember = "Name";
            cmbLeafType.ValueMember = "Amount";

            cmbTransportType.DataSource = mySettings.ListBLMasterSettings("TransportType");
            cmbTransportType.DisplayMember = "Name";
            cmbTransportType.ValueMember = "Name";

            cmbContainerType.DataSource = mySettings.ListBLMasterRates("ContainerType");
            cmbContainerType.DisplayMember = "Name";
            cmbContainerType.ValueMember = "Name";

            cmbTrncode_SelectedIndexChanged(null, null);



            //gvAll.DataSource = myGreenLeaf.ListRoutes(Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.StrYear), Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.strMonthID));
            gvAll.DataSource = myGreenLeaf.ListRoutes(dtDate.Value.Date);
            gvAllSummary.DataSource = myGreenLeaf.ListRoutesTotal(dtDate.Value.Date);

            //dtDate.Value = new DateTime(DateTime.Now.Year, Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.strMonthID), DateTime.Now.Day);
            //lblMonthTotal.Text = Convert.ToString(myGreenLeaf.MonthGreenLeafTotal(Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.StrYear), Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.strMonthID)));
            gridUpdateByDateRoute();
            lblTransport.Text = "";
        }

        public String PaddSuppliyerCode(String strSuppCode)
        {
            return strSuppCode.PadLeft(mySettings.GetSettingValue("SupplierCodeLength"), '0');
            //return strSuppCode;
        }

        private void btnRefreash_Click(object sender, EventArgs e)
        {
            gvList.DataSource = null;
            //lblMonthTotal.Text = Convert.ToString(myGreenLeaf.MonthGreenLeafTotal(Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.StrYear), Convert.ToInt32(BoughtLeafBusinessLayer.BLUser.strMonthID)));
            gridUpdateByDateRoute();
            gvAll.DataSource = myGreenLeaf.ListRoutes(dtDate.Value.Date);
            gvAllSummary.DataSource = myGreenLeaf.ListRoutesTotal(dtDate.Value.Date);
        }

        //sachintha udara add new method for change supplier code with four zero prefix
        // 1 is like 0001
        private string supCodeChange(string pSupCode)
        {
            //return pSupCode.PadLeft(5, '0');
            return pSupCode;
        }

        private void txtSupplierCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (txtSupplierCode.Text == "?")
                {
                    if (chkAllRoutes.Checked)
                    {
                        SupplierSearch objSuppSearch = new SupplierSearch(this, "%", "GL");
                        objSuppSearch.Show();
                    }
                    else
                    {
                        SupplierSearch objSuppSearch = new SupplierSearch(this, cmbRoute.SelectedValue.ToString(), "GL");
                        objSuppSearch.Show();
                    }
                }
                else
                {
                    txtSupplierCode.Text = PaddSuppliyerCode(txtSupplierCode.Text);
                    supCodeValidate();
                }
            }
        }

        private bool numberValidation(string txt)
        {
            Regex rgx = new Regex("^[0-9]{1,6}([.][0-9]{1,3})?$");
            return rgx.IsMatch(txt.Trim());
        }

        private void gridUpdateByDateRoute()
        {
            gvList.DataSource = myGreenLeaf.getGreenLeafDetailByDateAndRoute(Convert.ToDateTime(dtDate.Text), cmbRoute.SelectedValue.ToString(),chkAllRoutes.CheckState == CheckState.Checked ? 1 : 0);
            lblTotal.Text = myGreenLeaf.getGreenLeafTotal(Convert.ToDateTime(dtDate.Text), cmbRoute.SelectedValue.ToString()).ToString();
            lblMonthTotal.Text = Convert.ToString(myGreenLeaf.MonthGreenLeafTotal(dtDate.Value.Date));
            gvAll.DataSource = myGreenLeaf.ListRoutes(dtDate.Value.Date);
            gvAllSummary.DataSource = myGreenLeaf.ListRoutesTotal(dtDate.Value.Date);
            lblGrandTotal.Text = Convert.ToString(myGreenLeaf.MonthGreenLeafTotal(dtDate.Value.Date.Year, dtDate.Value.Date.Month));
            gvList.Columns[0].Width = 80;
            gvList.Columns[1].Width = 100;
            gvList.Columns[2].Width = 100;
            gvList.Columns[3].Width = 0;
            gvList.Columns[4].Width = 100;
            gvList.Columns[5].Width = 110;
            gvList.Columns[6].Width = 50;

            gvAll.Columns[1].Width = 0;
            gvAll.Columns[2].Width = 100;
            gvAll.Columns[3].Width = 100;
            gvAll.Columns[4].Width = 100;
            gvAll.Columns[5].Width = 100;
            gvAll.Columns[6].Width = 100;
            //--------------------------------
            //gvAllSummary.Columns[0].Width = 80;
            //gvAllSummary.Columns[1].Width = 100;
            //gvAllSummary.Columns[2].Width = 100;
            //gvAllSummary.Columns[3].Width = 0;
            //gvAllSummary.Columns[4].Width = 100;
            //gvAllSummary.Columns[5].Width = 110;
            //gvAllSummary.Columns[6].Width = 50;

            gvAllSummary.Columns[1].Width = 0;
            //gvAllSummary.Columns[2].Width = 100;
            //gvAllSummary.Columns[3].Width = 100;
            //gvAllSummary.Columns[4].Width = 100;
            //gvAllSummary.Columns[5].Width = 100;
            //gvAllSummary.Columns[6].Width = 100;

            UpdateSupplierTotals(Convert.ToDateTime(dtDate.Value.Date.ToShortDateString()), cmbRoute.SelectedValue.ToString(), txtSupplierCode.Text);

        }

        private void UpdateSupplierTotals(DateTime dtDate, String strRoute, String strSupp)
        {
            DataTable dtSummary = new DataTable();
            dtSummary = myGreenLeaf.getSuppliyerGreenLeafTotal(dtDate, strRoute, strSupp);
            if (dtSummary.Rows.Count > 0)
            {
                lblSupplierDayTotal.Text = dtSummary.Rows[0][0].ToString();
                lblSuppliyerTodate.Text = dtSummary.Rows[0][1].ToString();
            }
            else
            {
                lblSupplierDayTotal.Text = "0.00";
                lblSuppliyerTodate.Text = "0.00";
            }
            dtSummary.Dispose();
        }

        private void gridUpdateByDate()
        {
            gvList.DataSource = myGreenLeaf.getGreenLeafDetailByDateAndRoute(Convert.ToDateTime(dtDate.Text), lblRoute.Text, chkAllRoutes.CheckState == CheckState.Checked ? 1 : 0);
            lblTotal.Text = myGreenLeaf.getGreenLeafTotal(Convert.ToDateTime(dtDate.Text), lblRoute.Text).ToString();
        }

        private void cmdAddList_Click(object sender, EventArgs e)
        {
            if (txtNetWeight.Text.Trim() == String.Empty || !numberValidation(txtNetWeight.Text))
            {
                MessageBox.Show("Enter GreenLeaf to Proceed...!");
                txtNetWeight.Focus();
                return;
            }
            if (txtContainerDeduction.Text.Trim() == String.Empty || !numberValidation(txtContainerDeduction.Text))
            {
                MessageBox.Show("Enter Sack Kilos to Proceed...!");
                txtContainerDeduction.Focus();
                return;
            }
            if (txtNoOfContainers.Text.Trim() == String.Empty || !numberValidation(txtNoOfContainers.Text))
            {
                MessageBox.Show("Enter No of Bags to Proceed...!");
                txtNoOfContainers.Focus();
                return;
            }
            else if (txtSupplierCode.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Choose Correct Supplier to Proceed...!");
                txtSupplierCode.Focus();
                return;
            }
            else if (Convert.ToDecimal(txtNetWeight.Text) < 0)
            {
                MessageBox.Show("Net Weight Cannot Be Zero");
                txtGrossWeight.Focus();
            }
            else if (mySupplier.getSupplierName(cmbRoute.SelectedValue.ToString(),txtSupplierCode.Text)=="NA")
            {
                MessageBox.Show("Supplier Not Available");
                txtSupplierCode.Focus();
            }
            else
            {

                try
                {
                    CalculateNetWeight();
                    //myGreenLeaf.StrRouteNo = mySupplier.getRoute(supCodeChange(txtSupplierCode.Text));
                    myGreenLeaf.StrRouteNo = cmbRoute.SelectedValue.ToString();
                    myGreenLeaf.DatCollectedDate = dtDate.Value.Date;
                    myGreenLeaf.StrSupplierCode = supCodeChange(txtSupplierCode.Text);
                    myGreenLeaf.StrCollectorCode = cmbCollector.SelectedValue.ToString();
                    myGreenLeaf.DecGreenLeafCollected = Convert.ToDecimal(txtNetWeight.Text) ;
                    myGreenLeaf.DecNoofBags = Convert.ToDecimal(txtNoOfContainers.Text);
                    myGreenLeaf.DecSackKilos = Convert.ToDecimal(txtContainerDeduction.Text);
                    myGreenLeaf.StrTranCode = cmbTrncode.Text.ToString();
                    myGreenLeaf.StrGreeLeafType = cmbLeafType.Text;

                    myGreenLeaf.StrContainerType = cmbContainerType.SelectedValue.ToString();
                    myGreenLeaf.StrTransportType = cmbTransportType.SelectedValue.ToString();

                    myGreenLeaf.DecNoOfContainers = Convert.ToDecimal(txtNoOfContainers.Text);
                    myGreenLeaf.DecContainerDeduction = Convert.ToDecimal(txtContainerDeduction.Text);
                    myGreenLeaf.DecWaterDeduction = Convert.ToDecimal(txtwaterDeduction.Text);
                    myGreenLeaf.DecCoarseLeafDeduction = Convert.ToDecimal(txtCoarseLeafDeduction.Text);
                    myGreenLeaf.DecOtherDeduction = Convert.ToDecimal(txtOtherDeduction.Text);
                    myGreenLeaf.DecGrossWeight = Convert.ToDecimal(txtGrossWeight.Text);
                    myGreenLeaf.DecNetWeight = Convert.ToDecimal(txtNetWeight.Text);



                    if (cmbTrncode.Text == "NA" || cmbTrncode.Text == "")
                    {
                        myGreenLeaf.InsertGreenLeaf(Convert.ToDecimal("0.00"));
                    }
                    else
                    {
                        myGreenLeaf.InsertGreenLeaf(Convert.ToDecimal(cmbTrncode.SelectedValue.ToString()));
                    }

                    //MessageBox.Show("Record Inserted Successfully");
                    gridUpdateByDateRoute();
                    clearController();

                    txtSupplierCode.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clearController();
                gridUpdateByDateRoute();
                cmdAddList.Enabled = true;
                btnDelete.Enabled = false;
                cmdUpdate.Enabled = false;
            }
        }

        // New method for delete controller existing values
        // sachintha udara 2016.10.21

        private void clearController()
        {
            txtNoOfContainers.Text = "0";
            txtContainerDeduction.Text = "0";
            txtwaterDeduction.Text = "0";
            txtCoarseLeafDeduction.Text = "0";
            txtOtherDeduction.Text = "0";
            txtSupplierCode.Text = String.Empty;
            txtNetWeight.Text = "0";
            txtGrossWeight.Text = "0";
            lblSupplierDayTotal.Text = "0";
            lblSuppliyerTodate.Text = "0";
            lblSupplierName.Text = "";
            txtSupplierCode.Focus();

            cmbCollector.Enabled = true;
            cmbContainerType.Enabled = true;
            cmbLeafType.Enabled = true;
            cmbRoute.Enabled = true;
            cmbTransportType.Enabled = true;
            cmbTrncode.Enabled = true;
            dtDate.Enabled = true;
            txtSupplierCode.Enabled = true;


        }

        private void txtGreenLeaf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbLeafType.Focus();
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //myGreenLeaf.StrRouteNo = cmbRoute.SelectedValue.ToString();
                //myGreenLeaf.DatCollectedDate = dtDate.Value.Date;
                //myGreenLeaf.StrSupplierCode = supCodeChange(txtSupplierCode.Text);
                //myGreenLeaf.StrCollectorCode = cmbCollector.SelectedValue.ToString();
                //myGreenLeaf.DecGreenLeafCollected = Convert.ToDecimal(txtNetWeight.Text) - Convert.ToDecimal(txtContainerDeduction.Text);
                //myGreenLeaf.DecNoofBags = Convert.ToDecimal(txtNoOfContainers.Text);
                //myGreenLeaf.DecSackKilos = Convert.ToDecimal(txtContainerDeduction.Text);
                //myGreenLeaf.StrTranCode = cmbTrncode.Text;
                //myGreenLeaf.StrGreeLeafType = cmbLeafType.Text;




                myGreenLeaf.StrRouteNo = cmbRoute.SelectedValue.ToString();
                myGreenLeaf.DatCollectedDate = dtDate.Value.Date;
                myGreenLeaf.StrSupplierCode = supCodeChange(txtSupplierCode.Text);
                myGreenLeaf.StrCollectorCode = cmbCollector.SelectedValue.ToString();
                myGreenLeaf.DecGreenLeafCollected = Convert.ToDecimal(txtGrossWeight.Text);
                myGreenLeaf.DecNoofBags = Convert.ToDecimal(txtNoOfContainers.Text);
                myGreenLeaf.DecSackKilos = Convert.ToDecimal(txtContainerDeduction.Text);
                myGreenLeaf.StrTranCode = cmbTrncode.Text.ToString();
                myGreenLeaf.StrGreeLeafType = cmbLeafType.Text;

                myGreenLeaf.StrContainerType = cmbContainerType.SelectedValue.ToString();
                myGreenLeaf.StrTransportType = cmbTransportType.SelectedValue.ToString();

                myGreenLeaf.DecNoOfContainers = Convert.ToDecimal(txtNoOfContainers.Text);
                myGreenLeaf.DecContainerDeduction = Convert.ToDecimal(txtContainerDeduction.Text);
                myGreenLeaf.DecWaterDeduction = Convert.ToDecimal(txtwaterDeduction.Text);
                myGreenLeaf.DecCoarseLeafDeduction = Convert.ToDecimal(txtCoarseLeafDeduction.Text);
                myGreenLeaf.DecOtherDeduction = Convert.ToDecimal(txtOtherDeduction.Text);
                myGreenLeaf.DecGrossWeight = Convert.ToDecimal(txtGrossWeight.Text);
                myGreenLeaf.DecNetWeight = Convert.ToDecimal(txtNetWeight.Text);
                CalculateNetWeight();
                if (cmbTrncode.Text == "NA" || cmbTrncode.Text == "")
                {
                    myGreenLeaf.UpdateGreenLeaf(Convert.ToDecimal("0.00"));
                }
                else
                {
                    myGreenLeaf.UpdateGreenLeaf(Convert.ToDecimal(cmbTrncode.SelectedValue.ToString()));
                }

                MessageBox.Show("Record Upadated Successfully..!");

                gridUpdateByDateRoute();
                clearController();
                txtSupplierCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //clearController();
            //gridUpdateByDateRoute();
            cmdAddList.Enabled = true;
            btnDelete.Enabled = false;
            cmdUpdate.Enabled = false;
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            lbl_search_by.Text ="Click Colum Header";
            cmdAddList.Enabled = true;
            btnDelete.Enabled = false;
            cmdUpdate.Enabled = false;

            cmbCollector.Enabled = true;
            cmbContainerType.Enabled = true;
            cmbLeafType.Enabled = true;
            cmbRoute.Enabled = true;
            cmbTransportType.Enabled = true;
            cmbTrncode.Enabled = true;
            dtDate.Enabled = true;
            txtSupplierCode.Enabled = true;

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("Green Leaf Collected"));
            dt.Columns.Add(new DataColumn("NoofBags"));
            dt.Columns.Add(new DataColumn("SackKilos"));
            dt.Columns.Add(new DataColumn("Route"));

            //gvList.DataSource = dt;
            gvAll.DataSource = myGreenLeaf.ListRoutes(dtDate.Value.Date);
            gvAllSummary.DataSource = myGreenLeaf.ListRoutesTotal(dtDate.Value.Date);
            //txtContainerDeduction.Clear();
            //txtwaterDeduction.Clear();
            //txtCoarseLeafDeduction.Clear();
            //txtOtherDeduction.Clear();
            //txtNetWeight.Clear();
            //txtGrossWeight.Clear();
            //txtNoOfContainers.Text = "0";


            clearController();

            txtSupplierCode.Focus();
        }

        private void gvAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdDelete.Enabled = true;
            clearController();
            try
            {
                lblRoute.Text = myRoute.getRouteCode(gvAll.Rows[e.RowIndex].Cells[0].Value.ToString());
                //dtDate.Value = Convert.ToDateTime(gvAll.Rows[e.RowIndex].Cells[1].Value.ToString());


                if (gvAll.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                {
                    cmdUpdate.Enabled = false;
                }
                else
                {
                    cmdUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtContainerDeduction.Focus();
            }
        }

        private void txtSack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdAddList.PerformClick();
            }
        }

        public void load(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            cmdAddList.Enabled = false;
            btnDelete.Enabled = true;
            cmdUpdate.Enabled = true;

            cmbCollector.Enabled = false;
            cmbContainerType.Enabled = false;
            cmbLeafType.Enabled = false;
            cmbRoute.Enabled = false;
            cmbTransportType.Enabled = false;
            cmbTrncode.Enabled = false;
            dtDate.Enabled = false;
            txtSupplierCode.Enabled = false;


            txtSupplierCode.Text = gvList.Rows[rowI].Cells[0].Value.ToString();
            lblSupplierName.Text = gvList.Rows[rowI].Cells[1].Value.ToString();
            cmbCollector.SelectedValue = gvList.Rows[rowI].Cells[2].Value.ToString();
            txtNoOfContainers.Text = gvList.Rows[rowI].Cells[4].Value.ToString();
            txtContainerDeduction.Text = gvList.Rows[rowI].Cells[5].Value.ToString();
            lblRoute.Text = gvList.Rows[rowI].Cells[6].Value.ToString();
            cmbTrncode.Text = gvList.Rows[rowI].Cells[7].Value.ToString();
            //string str = gvList.Rows[rowI].Cells[8].Value.ToString().Substring(0, gvList.Rows[rowI].Cells[8].Value.ToString().IndexOf(" "));
            cmbLeafType.Text = gvList.Rows[rowI].Cells[8].Value.ToString();//.Substring(0,gvList.Rows[rowI].Cells[8].Value.ToString().IndexOf(" "));
            cmbTransportType.SelectedValue = gvList.Rows[rowI].Cells[9].Value.ToString();
            cmbContainerType.SelectedValue = gvList.Rows[rowI].Cells[10].Value.ToString();
            txtwaterDeduction.Text = gvList.Rows[rowI].Cells[11].Value.ToString();
            txtCoarseLeafDeduction.Text = gvList.Rows[rowI].Cells[12].Value.ToString();
            txtOtherDeduction.Text = gvList.Rows[rowI].Cells[13].Value.ToString();
            txtGrossWeight.Text = gvList.Rows[rowI].Cells[14].Value.ToString();
            txtNetWeight.Text = gvList.Rows[rowI].Cells[15].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (supCodeChange(txtSupplierCode.Text).Trim() == String.Empty)
            {

                MessageBox.Show("Please select a Supplier..!");
                return;
            }

            DialogResult dr = MessageBox.Show(("Are you sure to Delete " + supCodeChange(txtSupplierCode.Text) + " this supplier's Record ?"), "Confirm", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    myGreenLeaf.StrRouteNo = cmbRoute.SelectedValue.ToString();
                    myGreenLeaf.DatCollectedDate = dtDate.Value.Date;
                    myGreenLeaf.StrSupplierCode = supCodeChange(txtSupplierCode.Text);
                    myGreenLeaf.StrRouteNo = cmbRoute.SelectedValue.ToString();
                    myGreenLeaf.DatCollectedDate = dtDate.Value.Date;
                    myGreenLeaf.StrSupplierCode = supCodeChange(txtSupplierCode.Text);
                    myGreenLeaf.StrCollectorCode = cmbCollector.SelectedValue.ToString();
                    myGreenLeaf.DecGreenLeafCollected = Convert.ToDecimal(txtNetWeight.Text) - Convert.ToDecimal(txtContainerDeduction.Text);
                    myGreenLeaf.DecNoofBags = Convert.ToDecimal(txtNoOfContainers.Text);
                    myGreenLeaf.DecSackKilos = Convert.ToDecimal(txtContainerDeduction.Text);
                    myGreenLeaf.StrTranCode = cmbTrncode.Text.ToString();
                    myGreenLeaf.StrGreeLeafType = cmbLeafType.Text;

                    myGreenLeaf.StrContainerType = cmbContainerType.SelectedValue.ToString();
                    myGreenLeaf.StrTransportType = cmbTransportType.SelectedValue.ToString();

                    myGreenLeaf.DeleteGreenLeaf();
                    gridUpdateByDateRoute();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            clearController();
            cmdAddList.Enabled = true;
            btnDelete.Enabled = false;
            cmdUpdate.Enabled = false;
        }

        private void cmbTrncode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblTransport.Text = cmbTrncode.SelectedIndex.ToString();
                if (cmbTrncode.Text == "OTHER")
                    cmbTransportType.Text = "Other";
                else
                    cmbTransportType.Text = "Factory";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            supCodeValidate();
        }

        // sachintha udara
        // edited new function

        private void supCodeValidate()
        {
            string locSupCode = PaddSuppliyerCode(txtSupplierCode.Text);
            String locSupName = mySupplier.getSupplierName(locSupCode);

            if (mySupplier.getSupplierName(locSupCode) == "NA")
            {
                MessageBox.Show("Supplier Not Found !");
                txtSupplierCode.Text = String.Empty;
                txtSupplierCode.Focus();
            }
            else
            {
                txtSupplierCode.Text = locSupCode;
                lblSupplierName.Text = locSupName;
                lblRoute.Text = mySupplier.getRoute(locSupCode);
                cmbTrncode.Text = mySupplier.getSupplierTranCode(locSupCode);
                if (mySupplier.getSupplierTransportType(locSupCode) == "NA")
                {
                    MessageBox.Show("Transport Type Not Available In Master File");
                    cmbTransportType.SelectedIndex = -1;
                }
                else
                {
                    cmbTransportType.SelectedValue = mySupplier.getSupplierTransportType(locSupCode);
                }
                cmbTrncode.Focus();
            }
        }

        private void cmdAddList_Enter(object sender, EventArgs e)
        {
            //cmdUpdate.Focus();
        }

        private void cmdUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSupplierCode.Focus();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            gridUpdateByDateRoute();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure delete all record of " + lblRoute.Text + " route ?", "Confirm !!!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    myGreenLeaf.DeleteGreenLeafAll(dtDate.Value.Date, lblRoute.Text);
                    gvAll.DataSource = myGreenLeaf.ListRoutes(dtDate.Value.Date);
                    gvAllSummary.DataSource = myGreenLeaf.ListRoutesTotal(dtDate.Value.Date);
                    cmdDelete.Enabled = false;
                    cmdClear.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void lblRoute_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbRoute.Focus();
            }
        }

        private void cmbCollector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSupplierCode.Focus();
            }
        }

        private void cmbTrncode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbTransportType.Focus();
            }
        }

        private void txtSupplierCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplierCode.Text != "")
                gridUpdateByDateRoute();
        }

        private void cmbRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbCollector.Focus();
            }
        }

        private void cmbLeafType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdAddList.Focus();
            }
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridUpdateByDateRoute();
        }

        private void cmbCollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblCollectorName.Text = myCollector.getCollectorName(cmbCollector.SelectedValue.ToString());
            }
            catch { }
        }

        private void cmbTransportType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNoOfContainers.Focus();
            }
        }

        private void txtNoOfContainers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                if (Convert.ToDecimal(txtNoOfContainers.Text) == 0)
                {
                    MessageBox.Show("Can not enter 0 values");
                    txtNoOfContainers.Focus();
                }
                else
                {
                    txtGrossWeight.Focus();
                }
            }

            


        }

        private void txtGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Convert.ToDecimal(txtGrossWeight.Text) == 0)
                {
                    MessageBox.Show("No Of Containers Cannot be 0");
                    txtGrossWeight.Focus();
                }
                else if (Convert.ToDecimal(txtContainerDeduction.Text) == 0)
                {
                    txtContainerDeduction.Focus();
                }
                else
                {
                    txtwaterDeduction.Focus();
                }
            }


            isNumbersOnly(sender, e);
        }

        private void txtNoOfContainers_TextChanged(object sender, EventArgs e)
        {
            CalculateNetWeight();
            Decimal decContainerDeduction = 0;
            if (String.IsNullOrEmpty(txtNoOfContainers.Text))
            {
                MessageBox.Show("No Of Containers Cannot be Empty");
            }
            else
            {
                decContainerDeduction = mySettings.GetSettingRateValue("ContainerType", cmbContainerType.Text) * Convert.ToDecimal(txtNoOfContainers.Text);
                txtContainerDeduction.Text = decContainerDeduction.ToString("N2");
            }
        }

        private void txtwaterDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCoarseLeafDeduction.Focus();
            }


            isNumbersOnly(sender, e);
        }

        private void txtCoarseLeafDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtOtherDeduction.Focus();
            }
            isNumbersOnly(sender, e);
        }

        private void txtOtherDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdAddList.Focus();
            }
            isNumbersOnly(sender, e);
        }

        private void CalculateNetWeight()
        {
            txtGrossWeight.Text = String.IsNullOrEmpty(txtGrossWeight.Text) ? "0.00" : txtGrossWeight.Text;
            txtNoOfContainers.Text = String.IsNullOrEmpty(txtNoOfContainers.Text) ? "0.00" : txtNoOfContainers.Text;
            txtContainerDeduction.Text = String.IsNullOrEmpty(txtContainerDeduction.Text) ? "0.00" : txtContainerDeduction.Text;
            txtwaterDeduction.Text = String.IsNullOrEmpty(txtwaterDeduction.Text) ? "0.00" : txtwaterDeduction.Text;
            txtCoarseLeafDeduction.Text = String.IsNullOrEmpty(txtCoarseLeafDeduction.Text) ? "0.00" : txtCoarseLeafDeduction.Text;
            txtOtherDeduction.Text = String.IsNullOrEmpty(txtOtherDeduction.Text) ? "0.00" : txtOtherDeduction.Text;
            txtNetWeight.Text = String.IsNullOrEmpty(txtNetWeight.Text) ? "0.00" : txtNetWeight.Text;
            txtNetWeight.Text = Convert.ToString(Convert.ToDecimal(txtGrossWeight.Text) - (Convert.ToDecimal(txtContainerDeduction.Text) + Convert.ToDecimal(txtwaterDeduction.Text) + Convert.ToDecimal(txtCoarseLeafDeduction.Text) + Convert.ToDecimal(txtOtherDeduction.Text)));
            if (Convert.ToDecimal(txtNetWeight.Text) < 0)
            {
                //MessageBox.Show("Net Weight Cannot Be Less Than Zero");
                txtNetWeight.Text = "0.00";
                txtGrossWeight.Focus();
            }

        }

        private void txtGrossWeight_TextChanged(object sender, EventArgs e)
        {

            CalculateNetWeight();

        }

        private void txtContainerDeduction_TextChanged(object sender, EventArgs e)
        {
            CalculateNetWeight();
        }

        private void txtwaterDeduction_TextChanged(object sender, EventArgs e)
        {
            CalculateNetWeight();
        }

        private void txtCoarseLeafDeduction_TextChanged(object sender, EventArgs e)
        {
            CalculateNetWeight();
        }

        private void txtOtherDeduction_TextChanged(object sender, EventArgs e)
        {
            CalculateNetWeight();
        }

        private void gvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>0)
                {
                    return;
                }
        }

        private void cmbTransportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void isNumbersOnly(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSupplierCode_Leave_1(object sender, EventArgs e)
        {
            if(gvList.RowCount<0)
                supCodeValidate();
        }

        private void txtContainerDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtwaterDeduction.Focus();
            }
        }

        private void dtDate_Leave(object sender, EventArgs e)
        {
            gridUpdateByDateRoute();
        }

        private void chkAllRoutes_CheckedChanged(object sender, EventArgs e)
        {

            if (chkAllRoutes.Checked)
            {
                cmbRoute.Enabled = false;
                gridUpdateByDateRoute();
            }
            else
            {
                cmbRoute.Enabled = true;
                gridUpdateByDateRoute();
            }
            
        }

        private void cmbContainerType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lbl_search_by.Text != "Click Colum Header")
            {
                if (e.KeyChar == 13)
                {

                    try
                    {
                        if (txtSearch.Text != "" || lbl_search_by.Text != "Click Colum Header")
                        {
                            (gvList.DataSource as DataTable).DefaultView.RowFilter = string.Format(lbl_search_by.Text + " like'%{0}%'", txtSearch.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please Select the header and Enter Value");
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); cmdClear.PerformClick(); }
                }
            }
            else
            {
            }
        }

        private void gvList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSearch.Clear();
            string header_text = "";
            header_text = gvList.Columns[e.ColumnIndex].DataPropertyName;
            lbl_search_by.Text = header_text;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (lbl_search_by.Text != "Click Colum Header")
            {
                try
                {
                    if (txtSearch.Text != "" || lbl_search_by.Text != "Click Colum Header")
                    {
                        (gvList.DataSource as DataTable).DefaultView.RowFilter = string.Format(lbl_search_by.Text + " like'%{0}%'", txtSearch.Text);
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
                txtSearch.Clear();
               // MessageBox.Show("Please Select Column Name");
            }        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                gvList.Focus();
            }
        }

        private void gvList_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    gvList_CellDoubleClick(null, null);
            //}
        }

        private void gvList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gvList_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void gvList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          rowI = e.RowIndex;
        }





    }
}