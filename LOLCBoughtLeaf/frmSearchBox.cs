using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OLAXBoughtLeaf
{
    public partial class frmSearchBox : Form
    {
        public frmSearchBox(DataSet Items)
        {
            InitializeComponent();
            dsItems = Items;
        }
        

        #region Var

        
        public DataRow _drResult;
        private DataSet dsItems;

        public int _searchIndex1 = 0;
        public int _searchIndex2 = 1;
        public int _searchIndex3 = -1;
        public int _searchIndex4 = -1;
        public string _columnHeader = "";
        public int[] _visibleColumns;
        public int[] _searchAnyCharIndex = new int[] { 1 };

        private string searchCol1 = "";
        private string searchCol2 = "";
        private string searchCol3 = "";
        private string searchCol4 = "";

        private int column_0 = 0;
        private int column_1 = 1;

        private Dictionary<int, string> _columnFonts;
        private Dictionary<int, int> _columnWidth;
        private Dictionary<int, string> _columnFontFormat;
        private Dictionary<int, DataGridViewContentAlignment> _columnTextAlignment;


        #endregion
        #region Get Set

        public DataRow drResult
        {
            set
            { _drResult = value; }

            get
            { return _drResult; }
        }

        public int searchIndex1
        {
            set
            { _searchIndex1 = value; }

            get
            { return _searchIndex1; }
        }

        public int searchIndex2
        {
            set
            { _searchIndex2 = value; }

            get
            { return _searchIndex2; }
        }

        public int searchIndex3
        {
            set
            { _searchIndex3 = value; }

            get
            { return _searchIndex3; }
        }

        public int searchIndex4
        {
            set
            { _searchIndex4 = value; }

            get
            { return _searchIndex4; }
        }

        public string columnHeader
        {
            set
            { _columnHeader = value; }

            get
            { return _columnHeader; }
        }

        public int[] visibleColumns
        {
            set
            { _visibleColumns = value; }

            get
            { return _visibleColumns; }
        }

        public int[] searchAnyCharIndex
        {
            set
            { _searchAnyCharIndex = value; }

            get
            { return _searchAnyCharIndex; }
        }
        public Dictionary<int, string> columnFonts
        {
            set
            { _columnFonts = value; }
            get
            { return _columnFonts; }
        }
        public Dictionary<int, int> columnWidth
        {
            set
            { _columnWidth = value; }


            get
            { return _columnWidth; }
        }
        public Dictionary<int, string> columnFontFormat
        {
            set
            { _columnFontFormat = value; }
            get
            { return _columnFontFormat; }
        }
        public Dictionary<int, DataGridViewContentAlignment> columnTextAlignment
        {
            set
            { _columnTextAlignment = value; }
            get
            { return _columnTextAlignment; }
        }

        #endregion

        private void frmSearchBox_Load(object sender, EventArgs e)
        {
            dgvItems.DataSource = dsItems;
            dgvItems.DataMember = dsItems.Tables[0].TableName;
            fn_FormatGrid();
            try
            {
                dgvItems.Rows[0].Selected = false;

            }
            catch (ArgumentOutOfRangeException)
            { }

            txtSearchKey.Focus();
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
           
                try
                {
                    DataView myDataView = dsItems.Tables[0].DefaultView;
                    myDataView.RowFilter = fn_BuildQuery();
                    dgvItems.DataSource = myDataView;
                    fn_FormatGrid();
                }
                catch (Exception)
                { }

            
        }

        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }



        #region FUNCTIONS

        private string fn_BuildQuery()
        {

            #region Search Col 1
            try
            {
                searchCol1 = "[" + dsItems.Tables[0].Columns[searchIndex1].ColumnName + "]";
            }
            catch (Exception)
            {
                searchIndex1 = -1;
            }
            #endregion

            #region Search Col 2
            try
            {
                searchCol2 = "[" + dsItems.Tables[0].Columns[searchIndex2].ColumnName + "]";
            }
            catch (Exception)
            {
                searchIndex2 = -1;
            }
            #endregion

            #region Search Col 3
            try
            {
                searchCol3 = "[" + dsItems.Tables[0].Columns[searchIndex3].ColumnName + "]";
            }
            catch (Exception)
            {
                searchIndex3 = -1;
            }
            #endregion

            #region Search Col 4
            try
            {
                searchCol4 = "[" + dsItems.Tables[0].Columns[searchIndex4].ColumnName + "]";
            }
            catch (Exception)
            {
                searchIndex4 = -1;
            }
            #endregion



            string query = "";
            if (searchIndex1 >= 0)
                //query += searchCol1 + " like '" + (searchAnyCharIndex.Contains(1) ? "%" : "") + txtSearchKey.Text + "%'";
            query += searchCol1 + " like '" +  "%"  + txtSearchKey.Text + "%'";

            if (searchIndex1 >= 0 && searchIndex2 >= 0)
                query += " OR ";

            if (searchIndex2 >= 0)
               // query += searchCol2 + " like '" + (searchAnyCharIndex.Contains(2) ? "%" : "") + txtSearchKey.Text + "%' ";
            query += searchCol2 + " like '" +  "%"  + txtSearchKey.Text + "%' ";

            if (searchIndex2 >= 0 && searchIndex3 >= 0)
                query += " OR ";

            if (searchIndex3 >= 0)
                //query += searchCol3 + " like '" + (searchAnyCharIndex.Contains(3) ? "%" : "") + txtSearchKey.Text + "%' ";
            query += searchCol3 + " like '" + "%"  + txtSearchKey.Text + "%' ";

            if (searchIndex3 >= 0 && searchIndex4 >= 0)
                query += " OR ";

            if (searchIndex4 >= 0)
               // query += searchCol4 + " like '" + (searchAnyCharIndex.Contains(4) ? "%" : "") + txtSearchKey.Text + "%' ";
            query += searchCol4 + " like '" + "%"+ txtSearchKey.Text + "%' ";

            return query;
        }

        private void fn_SetGridHeaders()
        {
            try
            {
                for (int i = 0; i < dgvItems.ColumnCount; i++)
                {
                    dgvItems.Columns[i].HeaderText = fn_BuildHeaderName(dgvItems.Columns[i].HeaderText);
                }
            }
            catch (Exception)
            { }
        }

        private void fn_SetGridHeaders(string strHead)
        {
            if (columnHeader.Equals(""))
                return;

            try
            {
                dgvItems.Columns[column_0].HeaderText = strHead + " Code";
                dgvItems.Columns[column_1].HeaderText = strHead + " Name";
                //dgvItems.Columns[0].Width = 175;
                //dgvItems.Columns[1].Width = 275;
                ////lblSearch.Text = strHead + " " + lblSearch.Text;
            }
            catch (Exception)
            { }
        }

        private string fn_BuildHeaderName(string Str)
        {
            try
            {
                System.Text.StringBuilder SB = new System.Text.StringBuilder();
                try
                {
                    Str = Str.Substring(0, 1).ToUpper() + Str.Substring(1);
                }
                catch (Exception)
                { }

                bool Is_ = false;
                int i = 0;
                foreach (Char C in Str)
                {
                    string tmp = SB.ToString();

                    if (C.ToString().Equals("_"))
                    {
                        SB.Append(' ');
                        Is_ = true;
                        continue;
                    }

                    if (Is_)
                    {
                        SB.Append(C.ToString().ToUpper());
                        Is_ = false;
                        continue;
                    }

                    if (Char.IsUpper(C) && i > 0)
                    {
                        if (!tmp.Substring(tmp.Length - 1).Equals(" ") && !Char.IsUpper(tmp[tmp.Length - 1]))
                            SB.Append(' ');
                    }

                    SB.Append(C);
                    i++;
                }
                return SB.ToString();
            }
            catch (Exception)
            {
                return Str;
            }
        }

        private void fn_SetResult()
        {
            DataTable table = new DataTable();
            for (int i = 0; i < dgvItems.ColumnCount; i++)
            {
                table.Columns.Add(dsItems.Tables[0].Columns[i].ColumnName.ToString(), typeof(string));
            }

            string[] strAry = new string[dgvItems.ColumnCount];

            for (int i = 0; i < dgvItems.ColumnCount; i++)
            {
                strAry[i] = dgvItems.Rows[dgvItems.CurrentCell.OwningRow.Index].Cells[i].Value.ToString();
            }

            table.Rows.Add(strAry);
            drResult = table.Rows[0];
        }

        private void fn_DisableColumns(int[] cols)
        {
            try
            {
                if (cols.Length <= 0)
                    return;
            }
            catch (NullReferenceException)
            {
                return;
            }


            for (int i = 0; i <= dgvItems.Columns.Count - 1; i++)
            {
                this.dgvItems.Columns[i].Visible = false;
            }

            foreach (int i in cols)
            {
                this.dgvItems.Columns[i].Visible = true;
            }

            try
            {
                column_0 = cols[0];
                column_1 = cols[1];
            }
            catch (IndexOutOfRangeException ex)
            {
                column_1 = -1;
            }

            if (this.searchIndex1 != 0 || this.searchIndex2 != 1)
                return;

            if (cols.Length == 1)
            {
                this.searchIndex1 = cols[0];
                this.searchIndex2 = -1;
            }
            else if (cols.Length > 1)
            {
                this.searchIndex1 = cols[0];
                this.searchIndex2 = cols[1];
            }


        }

        private void fn_SetRowNos()
        {
           // new dgvClass().AutoNumberRowsForGridView(dgvItems);
        }

        private void fn_FormatGrid()
        {
            fn_DisableColumns(visibleColumns);
            fn_SetGridHeaders();
            fn_SetGridHeaders(columnHeader);
            SetColumnFonts(columnFonts);
            SetColumnWidth(columnWidth);
            SetColumnFontFormat(columnFontFormat);
            SetColumnTextAlignment(columnTextAlignment);
            fn_SetRowNos();
        }

        private void SetColumnFonts(Dictionary<int, string> clmFonts)
        {
            try
            {
                if (clmFonts != null)
                {
                    if (clmFonts.Count > 0)
                    {
                        foreach (KeyValuePair<int, string> acct in clmFonts)
                        {
                            if (acct.Key < dgvItems.Columns.Count)
                            {
                                dgvItems.Columns[acct.Key].DefaultCellStyle.Font = new Font(acct.Value, 10, FontStyle.Regular);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void SetColumnWidth(Dictionary<int, int> clmWidth)
        {
            try
            {
                if (clmWidth != null)
                {
                    if (clmWidth.Count > 0)
                    {
                        foreach (KeyValuePair<int, int> acct in clmWidth)
                        {
                            if (acct.Key < dgvItems.Columns.Count)
                            {
                                dgvItems.Columns[acct.Key].Width = acct.Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void SetColumnFontFormat(Dictionary<int, string> clmFontFormat)
        {
            try
            {
                if (clmFontFormat != null)
                {
                    if (clmFontFormat.Count > 0)
                    {
                        foreach (KeyValuePair<int, string> rowFontFormat in clmFontFormat)
                        {
                            if (rowFontFormat.Key < dgvItems.Columns.Count)
                            {

                                dgvItems.Columns[rowFontFormat.Key].DefaultCellStyle.Format = rowFontFormat.Value;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void SetColumnTextAlignment(Dictionary<int, DataGridViewContentAlignment> clmTextAlignment)
        {
            try
            {
                if (clmTextAlignment != null)
                {
                    if (clmTextAlignment.Count > 0)
                    {
                        foreach (KeyValuePair<int, DataGridViewContentAlignment> rowTextAlignment in clmTextAlignment)
                        {
                            if (rowTextAlignment.Key < dgvItems.Columns.Count)
                            {
                                dgvItems.Columns[rowTextAlignment.Key].DefaultCellStyle.Alignment = rowTextAlignment.Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #endregion

        private void dgvItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                //if (e.RowIndex < 0)
                if(dgvItems.CurrentCell.RowIndex < 0)
                {
                    return;
                }
                #endregion

                //drResult = dsItems.Tables[0].Rows[e.RowIndex];
                fn_SetResult();
                this.Close();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }

                #region Validation
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                if (dgvItems.CurrentCell.RowIndex < 0)
                {
                    return;
                }

                #endregion

                
                fn_SetResult();
                this.Close();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void frmSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}