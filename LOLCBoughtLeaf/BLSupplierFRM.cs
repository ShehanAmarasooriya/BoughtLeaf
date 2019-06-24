using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OLAXBoughtLeaf
{
    public partial class BLSupplierFRM : Form
    {
        BoughtLeafBusinessLayer.BLTown myTown = new BoughtLeafBusinessLayer.BLTown();
        BoughtLeafBusinessLayer.BLBank myBank = new BoughtLeafBusinessLayer.BLBank();
        BoughtLeafBusinessLayer.BLBankBranch myBranch = new BoughtLeafBusinessLayer.BLBankBranch();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();
        BoughtLeafBusinessLayer.BLTransportCost oTransportCost = new BoughtLeafBusinessLayer.BLTransportCost();
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLSettings mySettings = new BoughtLeafBusinessLayer.BLSettings();
        BoughtLeafBusinessLayer.BLCollector myCollector = new BoughtLeafBusinessLayer.BLCollector();
        string imageLoc = null;

        int RowI = 0;
        public BLSupplierFRM()
        {
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            pbImage.ImageLocation = Directory.GetCurrentDirectory() + "\\Red_Cross.png";

            cmbRoute.SelectedIndexChanged -= new EventHandler(cmbRoute_SelectedIndexChanged);
            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
            cmbRoute.SelectedIndexChanged += new EventHandler(cmbRoute_SelectedIndexChanged);
            cmbRoute_SelectedIndexChanged(null, null);

            cmbBank.SelectedIndexChanged -= new EventHandler(cmbBank_SelectedIndexChanged);
            cmbBank.DataSource = myBank.ListBankDetails();
            cmbBank.DisplayMember = "BankName";
            cmbBank.ValueMember = "BankCode";
            cmbBank.SelectedIndexChanged += new EventHandler(cmbBank_SelectedIndexChanged);
            cmbBank_SelectedIndexChanged(null, null);

            cmbTransport.DataSource = oTransportCost.getTransportCost();
            cmbTransport.DisplayMember = "Code";
            cmbTransport.ValueMember = "Code";


            cmbTransportType.DataSource = mySettings.ListBLMasterSettings("TransportType");
            cmbTransportType.DisplayMember = "Name";
            cmbTransportType.ValueMember = "Name";

            cmbSlabIncentiveMethod.DataSource = mySettings.ListBLSlabIncentiveMethod();
            cmbSlabIncentiveMethod.DisplayMember = "Name";
            cmbSlabIncentiveMethod.ValueMember = "Code";

            cmbType.SelectedIndex = 0;
            cmbRequired.SelectedIndex = 0;
            cmbSlabIncentiveMethod.SelectedIndex = 0;
         

            txtDepositRate.Enabled = false;
            

            gvList.DataSource = mySupplier.ListSupplierDetails();

            cmbBalencePaymentMode.Text = "Cash";
            cmbAdvancePaymentMode.Text = "Cash";

            cmbCollector.DataSource = myCollector.getCollectors();
            cmbCollector.DisplayMember = "CollectorName";
            cmbCollector.ValueMember = "CollectorCode";
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                RowI = e.RowIndex;
            }
            catch { }


            if (RowI < 0)
            { return; }


            try
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;

                txtCode.Enabled = false;

                txtCode.Text = gvList.Rows[RowI].Cells[0].Value.ToString();
                txtName.Text = gvList.Rows[RowI].Cells[1].Value.ToString();
                txtAddress.Text = gvList.Rows[RowI].Cells[2].Value.ToString();
                txtContact.Text = gvList.Rows[RowI].Cells[3].Value.ToString();
                cmbRoute.SelectedValue = gvList.Rows[RowI].Cells[4].Value.ToString();
                cmbTown.SelectedValue = gvList.Rows[RowI].Cells[21].Value.ToString();

                if (Convert.ToBoolean(gvList.Rows[RowI].Cells[30].Value.ToString()) == true)
                    ChkPaymentModeActive.Checked = true;
                else
                    ChkPaymentModeActive.Checked = false;

                bool i = false;

                i = Convert.ToBoolean(gvList.Rows[RowI].Cells[5].Value);
                if (i)
                {
                    chkSalarySendBack.Checked = i;
                    cmbBank.SelectedValue = gvList.Rows[RowI].Cells[6].Value.ToString();
                    cmbBankBranch.SelectedValue = gvList.Rows[RowI].Cells[7].Value.ToString();
                    txtAccountNo.Text = gvList.Rows[RowI].Cells[8].Value.ToString();
                }
                else
                {
                    chkSalarySendBack.Checked = i;
                    cmbBank.SelectedIndex = 0;
                }

                cmbRequired.SelectedIndex = 0;
                cmbRequired.Text = gvList.Rows[RowI].Cells["DepositRequired"].Value.ToString();
                txtDepositRate.Text = gvList.Rows[RowI].Cells["DepositRate"].Value.ToString();
                cmbSlabIncentiveMethod.SelectedValue = gvList.Rows[RowI].Cells["SlabIncentiveCode"].Value.ToString().Trim();
                cmbCollector.SelectedValue = gvList.Rows[RowI].Cells["Collector"].Value.ToString();
                txtExtent.Text = gvList.Rows[RowI].Cells[12].Value.ToString();
                cmbType.Text = gvList.Rows[RowI].Cells[13].Value.ToString();
                cmbTransport.SelectedValue = gvList.Rows[RowI].Cells[14].Value.ToString();
                txtElecID.Text = gvList.Rows[RowI].Cells[15].Value.ToString();
                txtGovRegNo.Text = gvList.Rows[RowI].Cells[16].Value.ToString();
                txtGLAccntNo.Text = gvList.Rows[RowI].Cells[17].Value.ToString();
                txtERemi.Text = gvList.Rows[RowI].Cells[18].Value.ToString();
                txtLatitude.Text = gvList.Rows[RowI].Cells[19].Value.ToString();
                txtLongitude.Text = gvList.Rows[RowI].Cells[20].Value.ToString();
                DataTable dt = mySupplier.getSupImage(gvList.Rows[RowI].Cells[0].Value.ToString(), gvList.Rows[RowI].Cells[4].Value.ToString());
                DataRow dr = dt.Rows[0];
                byte[] img = null;

                if (!dr["Image"].Equals(System.DBNull.Value))
                {
                    img = (byte[])(dr["Image"]);
                    MemoryStream ms = new MemoryStream(img);
                    pbImage.Image = Image.FromStream(ms);
                }
                else
                    pbImage.ImageLocation = Directory.GetCurrentDirectory() + "\\Red_Cross.png";

                if (gvList.Rows[RowI].Cells[9].Value.ToString() == "True")
                    chkInactive.Checked = true;
                else
                    chkInactive.Checked = false;

                if (gvList.Rows[RowI].Cells[10].Value.ToString() == "True")
                    chkUnion.Checked = true;

                else
                    chkUnion.Checked = false;
                if (gvList.Rows[RowI].Cells[11].Value.ToString() == "True")
                    chkStationary.Checked = true;
                else
                    chkStationary.Checked = false;







                txtNICno.Text = gvList.Rows[RowI].Cells["NIC"].Value.ToString();
                cmbTransportType.Text = gvList.Rows[RowI].Cells["TransportType"].Value.ToString();
                cmbBalencePaymentMode.Text = gvList.Rows[RowI].Cells["PaymentMode"].Value.ToString();
                cmbAdvancePaymentMode.Text = gvList.Rows[RowI].Cells["AdvancePayMode"].Value.ToString();
                cmbCollector.SelectedValue = gvList.Rows[RowI].Cells[29].Value.ToString();


                btnAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtName.Focus();
            }
        }

        private void cmbTown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbBank.Focus();
            }
        }

        private void cmbBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAccountNo.Focus();
            }
        }

        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnUpdate.PerformClick();
                txtCode.Focus();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtExtent.Focus();
            }
        }

        private void txtExtent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtContact.Focus();
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbRoute.Focus();
            }
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBalencePaymentMode.Text.Equals("Bank"))
            {
                cmbBank.Enabled = true;
                cmbBankBranch.Enabled = true;
                chkSalarySendBack.Checked = true;
            }
            else if (cmbBalencePaymentMode.Text.Equals("Cheque"))
            {
                cmbBank.Enabled = false;
                cmbBankBranch.Enabled = false;
                txtAccountNo.Enabled = false;
            }
            else
            {
                cmbBank.Enabled = false;
                cmbBankBranch.Enabled = false;
                chkSalarySendBack.Checked = false;
                txtAccountNo.Enabled = false; ;
            }

            try
            {
                cmbBankBranch.DataSource = myBranch.ListBranchDetails(cmbBank.SelectedValue.ToString());
                cmbBankBranch.DisplayMember = "BranchName";
                cmbBankBranch.ValueMember = "BranchCode";
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private byte[] getSupImage()
        {
            byte[] img = null;
            if (!string.IsNullOrEmpty(imageLoc))
            {
                try
                {
                    FileStream fs = new FileStream(imageLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                }
                catch (Exception ex) { img = null; }
            }
            else
            {
                pbImage.ImageLocation = Directory.GetCurrentDirectory() + "\\Red_Cross.png";
                img = imageToByteArray(pbImage.Image);
            }

            imageLoc = string.Empty;
            return img;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void valueAssign()
        {
            string supCode = txtCode.Text.PadLeft(5, '0');
            mySupplier.StrSupplierCode = supCode;
            mySupplier.StrSupplierCode = txtCode.Text;
            mySupplier.StrContactNo = txtContact.Text;
            mySupplier.StrSupplierAddress = txtAddress.Text;
            mySupplier.StrSupplierName = txtName.Text;
            mySupplier.StrRouteCode = cmbRoute.SelectedValue.ToString();
            mySupplier.StrTownCode = cmbTown.SelectedValue.ToString();
            mySupplier.BlnInactiveSupplier = chkInactive.Checked;
            mySupplier.BlnUnionLinked = chkUnion.Checked;
            mySupplier.BlnStationary = chkStationary.Checked;
            //mySupplier.DecExtent = Convert.ToDecimal(txtExtent.Text);
            mySupplier.DecExtent = string.IsNullOrEmpty(txtExtent.Text) ? 0 : Convert.ToDecimal(txtExtent.Text);
            mySupplier.ElectronicID = txtElecID.Text;
            mySupplier.ERemittanceID = txtERemi.Text;
            mySupplier.GovRegNo = txtGovRegNo.Text;
            mySupplier.GLAccountNo = txtGLAccntNo.Text;
            mySupplier.Image = getSupImage();
            mySupplier.StrCollector = cmbCollector.SelectedValue.ToString();

            mySupplier.TransPortType=cmbTransportType.SelectedValue.ToString();
            mySupplier.NicNo=txtNICno.Text;
            mySupplier.BalencePaymentMode = cmbBalencePaymentMode.Text;
            mySupplier.AdvancedPaymentMode = cmbAdvancePaymentMode.Text;


            mySupplier.TransportCode = cmbTransport.SelectedValue.ToString();
            mySupplier.Latitude = txtLatitude.Text;
            mySupplier.Longitude = txtLongitude.Text;

            if (ChkPaymentModeActive.Checked)
            {
                mySupplier.BoolPaymentModeActive = true;
            }
            else
                mySupplier.BoolPaymentModeActive = false;

            if (chkSalarySendBack.Checked)
                mySupplier.SalarySendBank = 1;
            else
                mySupplier.SalarySendBank = 0;
           
            if (cmbBankBranch.SelectedIndex > -1)
            {
                mySupplier.BankBranch = cmbBankBranch.SelectedValue.ToString();
            }
            else
                mySupplier.BankBranch = "NA";
            if(cmbBank.SelectedIndex>-1)                       
                mySupplier.StrBankCode = cmbBank.SelectedValue.ToString();
            else
                mySupplier.StrBankCode = "NA";
            if (!String.IsNullOrEmpty(txtAccountNo.Text))
            {
                mySupplier.StrAccountNo = txtAccountNo.Text;
            }
            else
                mySupplier.StrAccountNo = "NA";
                
            
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Enter Supplier Code");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Enter Supplier Name");
            }
            else if (cmbTransport.SelectedIndex < 0)
            {
                MessageBox.Show("Transport Deduction Code Not Selected");
            }
            else if (cmbCollector.SelectedIndex < 0)
            {
                MessageBox.Show("Collector Not Selected");
            }
            else
            {
                try
                {
                    valueAssign();

                    try
                    {
                        mySupplier.InsertSupplier(cmbType.SelectedItem.ToString(),cmbRequired.Text,String.IsNullOrEmpty(txtDepositRate.Text)?0:Convert.ToDecimal(txtDepositRate.Text), cmbSlabIncentiveMethod.SelectedValue.ToString());
                        MessageBox.Show("Insert Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                  
                    btnClear.PerformClick();
                    txtCode.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtCode.Text == "")
            {
                MessageBox.Show("Enter Supplier Code");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Enter Supplier Name");
            }
            else if (cmbTransport.SelectedIndex < 0)
            {
                MessageBox.Show("Transport Deduction Code Not Selected");
            }
            else if (cmbCollector.SelectedIndex < 0)
            {
                MessageBox.Show("Collector Not Selected");
            }
            else
            {
                try
                {
                    valueAssign();

                    try
                    {
                        mySupplier.UpdateSupplier(cmbType.SelectedItem.ToString(), cmbRequired.Text, String.IsNullOrEmpty(txtDepositRate.Text) ? 0 : Convert.ToDecimal(txtDepositRate.Text), cmbSlabIncentiveMethod.SelectedValue.ToString());
                        MessageBox.Show("Update Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    btnClear.PerformClick();
                    txtCode.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Delete...!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    mySupplier.StrSupplierCode = txtCode.Text;
                    mySupplier.DeleteSupplier(cmbRoute.SelectedValue.ToString());
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
            lbl_search_by.Text = "Click Colum Header";
            txtSearch.Clear();
            pbImage.ImageLocation = Directory.GetCurrentDirectory() + "\\Red_Cross.png";
            chkSalarySendBack.Checked = true;
            cmbRoute.SelectedIndex = 0;
            cmbBank.SelectedIndex = 0;
            cmbTransport.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbRequired.SelectedIndex = 0;
            txtDepositRate.Text = "0.00";
            txtName.Clear();
            txtContact.Clear();
            txtCode.Clear();
            txtAddress.Clear();
            txtAccountNo.Clear();
            txtExtent.Clear();
            pbImage.Image = null;
            chkInactive.Checked = false;
            chkUnion.Checked = false;
            txtERemi.Clear();
            txtElecID.Clear();
            txtGovRegNo.Clear();
            txtGLAccntNo.Clear();
            txtLongitude.Clear();
            txtLatitude.Clear();
            txtSearch.Clear();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtNICno.Clear();
            txtCode.Enabled = true;

            cmbSlabIncentiveMethod.SelectedIndex = 0;

            txtCode.Focus();
            

            gvList.DataSource = mySupplier.ListSupplierDetails();
            cmbType.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowesImg_Click(object sender, EventArgs e)
        {
            imageLoc = string.Empty;
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                fd.Title = "Select Supplier Image";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    imageLoc = fd.FileName.ToString();
                    pbImage.ImageLocation = imageLoc;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTown.DataSource = myTown.ListTownDetailsByRoute(cmbRoute.SelectedValue.ToString());
            cmbTown.DisplayMember = "TownName";
            cmbTown.ValueMember = "TownCode";
        }

        private void chkSalarySendBack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalarySendBack.Checked)
            {
                txtAccountNo.Enabled = true;
                cmbBank.Enabled = true;
                cmbBankBranch.Enabled = true;
            }
            else
            {
                txtAccountNo.Enabled = false;
                cmbBank.Enabled = false;
                cmbBankBranch.Enabled = false;
            }
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
                    { MessageBox.Show(ex.ToString()); btnClear.PerformClick(); }
                }
            }
            else
            {
              //  MessageBox.Show("Please Select the column");
            }
        }

        private void rbtnSupName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbAdvancePaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdvancePaymentMode.Text.Equals("Bank"))
            {
                cmbBank.Enabled = true;
                cmbBankBranch.Enabled = true;

            }
            else if (cmbAdvancePaymentMode.Text.Equals("Cheque"))
            {
                cmbBank.Enabled = false;
                cmbBankBranch.Enabled = false;
                txtAccountNo.Enabled = true;
            }
            else
            {
                cmbBank.Enabled = false;
                cmbBankBranch.Enabled = false;

                txtAccountNo.Enabled = false; ;
            }
        }

        private void BLSupplierFRM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BLSupplierFRM_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChkPaymentModeActive_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPaymentModeActive.Checked)
            {
                gbPaySettings.Enabled = true;
            }
            else
            {
                gbPaySettings.Enabled = false;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbRequired_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbRequired.SelectedIndex == 1)
                txtDepositRate.Enabled = true;
            else
            {
                txtDepositRate.Enabled = false;
                txtDepositRate.Text = "0.00";
            }
        }

        

        private void txtDepositRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAdd.Focus();
            }

            isNumbersOnly(sender, e);
        }

        private void cmbRequired_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepositRate.Focus();
        }

        private void isNumbersOnly(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            string sup = txtCode.Text;
            if (gvList.Rows.Count > 0)
            {

                string newSup = (sup.PadLeft(5, '0'));
                (gvList.DataSource as DataTable).DefaultView.RowFilter = string.Format("SupplierCode LIKE '{0}%' OR SupplierCode LIKE '% {0}%'", newSup);
                if (gvList.Rows.Count == 0)
                {
                    (gvList.DataSource as DataTable).DefaultView.RowFilter = string.Format("SupplierCode LIKE '{0}%' OR SupplierCode LIKE '% {0}%'", sup);

                    if (gvList.Rows.Count == 0)
                    {
                        gvList.DataSource = mySupplier.ListSupplierDetails();
                    }
                }
            }
        }

        private void gvList_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void gvList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSearch.Clear();
            string header_text = "";
            header_text = gvList.Columns[e.ColumnIndex].DataPropertyName;
            lbl_search_by.Text = header_text;
            txtSearch.Focus();
        }

        private void gvList_KeyDown(object sender, KeyEventArgs e)
        {

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
                    { MessageBox.Show(ex.ToString()); btnClear.PerformClick(); }
                
            }
            else
            {
               // MessageBox.Show("Please Select the column");
            }
        }

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

        private void gvList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowI = e.RowIndex;
        }
    }
}