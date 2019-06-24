namespace OLAXBoughtLeaf
{
    partial class Pre_Month_DebtsCoinsEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gdvList = new System.Windows.Forms.DataGridView();
            this.SupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.dtpYearMonth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 436);
            this.panel1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(433, 373);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gdvList);
            this.groupBox2.Location = new System.Drawing.Point(6, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 305);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // gdvList
            // 
            this.gdvList.AllowUserToAddRows = false;
            this.gdvList.AllowUserToDeleteRows = false;
            this.gdvList.AllowUserToResizeRows = false;
            this.gdvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupCode,
            this.SupName,
            this.RouteCode,
            this.Coins,
            this.Debts});
            this.gdvList.Location = new System.Drawing.Point(6, 19);
            this.gdvList.Name = "gdvList";
            this.gdvList.RowHeadersVisible = false;
            this.gdvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gdvList.Size = new System.Drawing.Size(574, 280);
            this.gdvList.TabIndex = 1;
            this.gdvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvList_CellValueChanged);
            this.gdvList.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvList_CellLeave);
            this.gdvList.Leave += new System.EventHandler(this.gdvList_Leave);
            this.gdvList.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvList_RowLeave);
            this.gdvList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gdvList_CellValidating);
            this.gdvList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvList_CellEndEdit);
            this.gdvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvList_CellClick);
            this.gdvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvList_KeyDown);
            this.gdvList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvList_CellEnter);
            this.gdvList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gdvList_KeyPress);
            this.gdvList.SelectionChanged += new System.EventHandler(this.gdvList_SelectionChanged);
            this.gdvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SupCode
            // 
            this.SupCode.DataPropertyName = "SupplierCode";
            this.SupCode.HeaderText = "Sup Code";
            this.SupCode.Name = "SupCode";
            this.SupCode.ReadOnly = true;
            this.SupCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SupName
            // 
            this.SupName.DataPropertyName = "SupplierName";
            this.SupName.HeaderText = "Sup Name";
            this.SupName.Name = "SupName";
            this.SupName.ReadOnly = true;
            this.SupName.Width = 165;
            // 
            // RouteCode
            // 
            this.RouteCode.DataPropertyName = "RouteCode";
            this.RouteCode.HeaderText = "Route Code";
            this.RouteCode.Name = "RouteCode";
            this.RouteCode.ReadOnly = true;
            // 
            // Coins
            // 
            this.Coins.DataPropertyName = "coin";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.Coins.DefaultCellStyle = dataGridViewCellStyle11;
            this.Coins.HeaderText = "Roundoff Coins";
            this.Coins.Name = "Coins";
            // 
            // Debts
            // 
            this.Debts.DataPropertyName = "Debts";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.Debts.DefaultCellStyle = dataGridViewCellStyle12;
            this.Debts.HeaderText = "Debts";
            this.Debts.Name = "Debts";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRoute);
            this.groupBox1.Controls.Add(this.dtpYearMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbRoute
            // 
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(288, 17);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(286, 21);
            this.cmbRoute.TabIndex = 2;
            this.cmbRoute.SelectedIndexChanged += new System.EventHandler(this.cmbRoute_SelectedIndexChanged);
            // 
            // dtpYearMonth
            // 
            this.dtpYearMonth.Location = new System.Drawing.Point(76, 18);
            this.dtpYearMonth.Name = "dtpYearMonth";
            this.dtpYearMonth.Size = new System.Drawing.Size(131, 20);
            this.dtpYearMonth.TabIndex = 1;
            this.dtpYearMonth.ValueChanged += new System.EventHandler(this.dtpYearMonth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Route";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year/Month";
            // 
            // Pre_Month_DebtsCoinsEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 460);
            this.Controls.Add(this.panel1);
            this.Name = "Pre_Month_DebtsCoinsEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pre_Month Debts Coins Entry";
            this.Load += new System.EventHandler(this.Pre_Month_DebtsCoinsEntry_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.DateTimePicker dtpYearMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gdvList;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coins;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debts;
    }
}