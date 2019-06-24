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
    public partial class Supplier_Reg : Form
    {
        BLSupplier supplier = new BLSupplier();

        public Supplier_Reg()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet dataSetReport = new DataSet();
            BoughtLeafBusinessLayer.BLSupplier myAccount = new BoughtLeafBusinessLayer.BLSupplier();
            dataSetReport = myAccount.viewSupplierList(cmbRoute.SelectedValue.ToString());
            dataSetReport.WriteXml("SupplierList.xml");
            SuppliersRPT myaclist = new SuppliersRPT();
            myaclist.SetDataSource(dataSetReport);
            ReportViewer myReportViewer = new ReportViewer();
            myaclist.SetParameterValue("Company", BoughtLeafBusinessLayer.BLUser.getCompanyName());
            myReportViewer.crystalReportViewer1.ReportSource = myaclist;
            myReportViewer.Show();
        }

        private void Supplier_Reg_Load(object sender, EventArgs e)
        {
            cmbRoute.DataSource = supplier.RouteLoad().Tables[0];
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
        }
    }
}