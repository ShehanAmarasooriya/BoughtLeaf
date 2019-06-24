using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BoughtLeafBusinessLayer;
using System.Text.RegularExpressions;

namespace OLAXBoughtLeaf
{
    public partial class FrmSlabIncentive : Form
    {
        int count = 0;
        DataTable table = new DataTable();
        DataRow dr = null;
        string status;
        SlabIncentive slab = new SlabIncentive();

        public FrmSlabIncentive()
        {
            InitializeComponent();


            table.Columns.Add("From", typeof(string));
            table.Columns.Add("To", typeof(string));
            table.Columns.Add("Insentive", typeof(string));

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmSlabInsentive_Load(object sender, EventArgs e)
        {
            this.FilldgvHead();
            btnDelete.Enabled = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtInsentive_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Code, Name;
            int from, to;
            decimal incentive;
            DataTable dt = new DataTable();
            for (int i = 0; i < dgvSubIncentive.Rows.Count; i++)
            {
                Code = txtCode.Text;
                Name = txtName.Text;
                if (dgvSubIncentive.Rows[i].Cells["From"].Value != null)
                {
                    from = Convert.ToInt32(dgvSubIncentive.Rows[i].Cells["From"].Value.ToString());
                    to = Convert.ToInt32(dgvSubIncentive.Rows[i].Cells["To"].Value.ToString());
                    incentive = Convert.ToDecimal(dgvSubIncentive.Rows[i].Cells["Incentives"].Value.ToString());
                    dt = slab.SlabAdd(Code, Name, from, to, incentive);
                }
            }
            if (dt.Rows[0][1].ToString() == "Fail")
            {
                MessageBox.Show("Insertion Fail Please Try Again");
            }
            else
            {
                MessageBox.Show("Insertion successfull");
            }

            this.FilldgvHead();
            btnDelete.Enabled = false;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll(this);

        }

        private void FilldgvHead()
        {
            DataTable dt = new DataTable();
            dt = slab.fillHeadSlabdgv().Tables[0];
            dgvSlabHead.DataSource = dt;
        }

        private void btnAddtoList_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != "" && txtName.Text != "" && txtFrom.Text != "" && txtTo.Text != "" && txtInsentive.Text != "")
            {
                dr = table.NewRow();
                dr["From"] = txtFrom.Text;
                dr["To"] = txtTo.Text;
                dr["Insentive"] = txtInsentive.Text;
                table.Rows.Add(dr);

                dgvSubIncentive.DataSource = table;


                txtCode.Enabled = false;
                txtName.Enabled = false;
                this.ClearSubText();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //if (dgvSubIncentive.Rows[i].Cells["To"].Value != null)
                    //    txtFrom.Text = dgvSubIncentive.Rows[i].Cells["To"].Value.ToString();
                    txtFrom.Text = table.Rows[i]["To"].ToString();
                }

            }

        }

        private void ClearSubText()
        {
            txtFrom.Clear();
            txtTo.Clear();
            txtInsentive.Clear();
        }

        private void ClearAll(Control control)
        {
            foreach (Control con in control.Controls)
            {
                if (con is TextBox)
                {
                    ((TextBox)con).Clear();
                }
            }
            txtCode.Enabled = true;
            txtName.Enabled = true;
            table.Rows.Clear();
            dgvSubIncentive.DataSource = table;

        }

        private void txtFrom_Leave(object sender, EventArgs e)
        {
            if (table.Rows.Count != 0 && txtFrom.Text != "")
            {
                if (Convert.ToInt32(table.Rows[0]["To"].ToString()) > Convert.ToInt32(txtFrom.Text))
                {
                    MessageBox.Show("Value that enter is on a Range that entered");
                    txtFrom.Clear();
                    txtFrom.Focus();
                }
            }
        }

        private void txtTo_Leave(object sender, EventArgs e)
        {
            if (txtTo.Text != "")
            {
                if (Convert.ToInt32(txtFrom.Text) > Convert.ToInt32(txtTo.Text))
                {
                    MessageBox.Show("Value that enter is on a Range that entered");
                    txtTo.Clear();
                    txtTo.Focus();
                }
            }
        }

        private void dgvSlabHead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = slab.FillDetaillabdgv(dgvSlabHead.Rows[e.RowIndex].Cells["Code"].Value.ToString()).Tables[0];
            dgvSubIncentive.DataSource = dt;
            txtCode.Text = dgvSlabHead.Rows[e.RowIndex].Cells["Code"].Value.ToString();
            txtName.Text = dgvSlabHead.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtName.Enabled = false;
            txtCode.Enabled = false;
            txtFrom.Text = dt.Rows[dt.Rows.Count - 1]["To"].ToString();
            table.Rows.Clear();
            table.ImportRow(dt.Rows[dt.Rows.Count - 1]);
            btnDelete.Enabled = true;

        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtInsentive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtInsentive.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you want to Delete the code \"" + txtCode.Text + "\" ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
            {
                if (slab.SlabDelete(txtCode.Text).Rows[0][0].ToString() == "SUCESS")
                {
                    MessageBox.Show("All the data to code \"" + txtCode.Text + "\" have been deleted successfully");
                }
                else
                {
                    MessageBox.Show("Delete Process Fail ");
                }
               // DataTable dt = 
               // dt.Rows.Clear();
                dgvSlabHead.DataSource = slab.fillHeadSlabdgv().Tables[0];
                this.ClearAll(this);
                btnDelete.Enabled = false;
            }
        }

        private void dgvSlabHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}