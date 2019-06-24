using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BoughtLeafDataAccess;
using System.Data.SqlClient;


namespace OLAXBoughtLeaf
{
    public partial class Supplier_Green_Leaf_Amount : Form
    
    {
        BoughtLeafBusinessLayer.BLRoute myRoute = new BoughtLeafBusinessLayer.BLRoute();
        BoughtLeafBusinessLayer.Reports myReports = new BoughtLeafBusinessLayer.Reports();
        public Supplier_Green_Leaf_Amount()
        {
            InitializeComponent();
        }

        private void Supplier_Green_Leaf_Amount_Load(object sender, EventArgs e)
        {
            cmbRoute.DataSource = myRoute.ListRouteDetails();
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteCode";
            
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSupCode.Text == "")
            {
                errorProvider1.SetError(txtSupCode, "Enter Supplier Code");
            }
            string sup = txtSupCode.Text;
            string newSup;
            DataTable dt = myReports.getSelectSupplierDetails(newSup = sup.PadLeft(5, '0'), FromDate.Text.ToString(), ToDate.Text.ToString()); 
            dt.TableName = "GreanLeaf";
            dt.WriteXml("SupGreanLeaf.xml");
            SupplierGreenLeafRPT myaclist = new SupplierGreenLeafRPT();
            myaclist.SetDataSource(dt);
            crystalReport.ReportSource = myaclist;
            crystalReport.Show();
            txtSupCode.Focus();         
        }

        private void getSupName()
        {
           
            txtSupName.Clear();
            string sup = txtSupCode.Text;
            string newSup = sup.PadLeft(5, '0');
            string q = "SELECT SupplierName FROM Supplier WHERE SupplierCode='" +newSup+ "'";
            SQLHelper.ExecuteReader(q, CommandType.Text);
            SqlDataReader rdr = SQLHelper.ExecuteReader(q, CommandType.Text);

            while (rdr.Read())
            {
                txtSupName.Text = rdr["SupplierName"].ToString();
            }
            Error();

        }

        private void Error()
        {
            if (txtSupName.Text == "" && txtSupCode.Text == "")
            {
                errorProvider1.Clear();
            }
            else if (txtSupCode.Text !="" && txtSupName.Text == "")
            {
                errorProvider1.SetError(txtSupCode, "Invalid Supplier Code");
                txtSupCode.Focus();
            }

            else if (txtSupCode.Text != "" && txtSupName.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void Clear() 
        {
            txtSupCode.Clear();
            txtSupName.Clear();
            crystalReport.ReportSource =null;
            errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }


        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSupCode_TextChanged(object sender, EventArgs e)
        {
            getSupName();
            //button2.PerformClick();
            if (string.IsNullOrEmpty(txtSupCode.Text))
            {
                errorProvider1.Clear();
                Clear();
            }
        }

        private void txtSupCode_Leave(object sender, EventArgs e)
        {
            getSupName();
        }

        private void txtSupCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

        }      
    }
}