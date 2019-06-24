using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class SupplierSearch : Form
    {
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.BLSupplier mySupplier = new BoughtLeafBusinessLayer.BLSupplier();

        GreenLeafCollectionTRNFRM objGLCollection;

        public String StrRoute;
        public String strFormType = "";

        public SupplierSearch()
        {
            InitializeComponent();
        }

        public SupplierSearch(GreenLeafCollectionTRNFRM frmGLCollection,String route,String FormType)
        {
            objGLCollection = frmGLCollection;
            StrRoute = route;
            strFormType = FormType;
            InitializeComponent();

        }

        private void SupplierSearch_Load(object sender, EventArgs e)
        {
            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";

            if (StrRoute == "%")
            {
                chkAllRoutes.Checked = true;
            }
            else
            {
                chkAllRoutes.Checked = false;
                cmbRoute.SelectedValue = StrRoute;                
            }
            cmbRoute_SelectedIndexChanged(null, null);
            
            
        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllRoutes.Checked)
                {
                    gvList.DataSource = mySupplier.ListActiveSuppliersOfRoute("%", txtSearchText.Text);
                }
                else
                {
                    gvList.DataSource = mySupplier.ListActiveSuppliersOfRoute(cmbRoute.SelectedValue.ToString(), txtSearchText.Text);
                }
            }
            catch { }
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvList.DataSource = mySupplier.ListActiveSuppliersOfRoute(StrRoute, txtSearchText.Text);
            }
            catch { }
        }

        private void gvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            objGLCollection.txtSupplierCode.Text = gvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            objGLCollection.lblSupplierName.Text = gvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            objGLCollection.lblRoute.Text = mySupplier.getRoute(objGLCollection.txtSupplierCode.Text.PadLeft(5,'0'));
            objGLCollection.cmbTrncode.Text = mySupplier.getSupplierTranCode(objGLCollection.txtSupplierCode.Text.PadLeft(5, '0'));
            this.Close();
        }
    }
}