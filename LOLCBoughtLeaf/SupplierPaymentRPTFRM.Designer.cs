namespace OLAXBoughtLeaf
{
    partial class SupplierPaymentRPTFRM
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRoute = new System.Windows.Forms.CheckBox();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPaySmryDetail = new System.Windows.Forms.Button();
            this.btnPaySmry = new System.Windows.Forms.Button();
            this.btnPaySmryRoute = new System.Windows.Forms.Button();
            this.btnLMDebt = new System.Windows.Forms.Button();
            this.btnNMDebt = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSkippedDeductions = new System.Windows.Forms.Button();
            this.btnIncentiveSummary = new System.Windows.Forms.Button();
            this.gbCollector = new System.Windows.Forms.GroupBox();
            this.btnCollectorPayment = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbCollector.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRoute);
            this.groupBox1.Controls.Add(this.cmbRoute);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkSupplier);
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 146);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // chkRoute
            // 
            this.chkRoute.AutoSize = true;
            this.chkRoute.Checked = true;
            this.chkRoute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRoute.Location = new System.Drawing.Point(286, 118);
            this.chkRoute.Name = "chkRoute";
            this.chkRoute.Size = new System.Drawing.Size(74, 17);
            this.chkRoute.TabIndex = 15;
            this.chkRoute.Text = "All Routes";
            this.chkRoute.UseVisualStyleBackColor = true;
            this.chkRoute.CheckedChanged += new System.EventHandler(this.chkRoute_CheckedChanged);
            // 
            // cmbRoute
            // 
            this.cmbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoute.Enabled = false;
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(129, 116);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(151, 21);
            this.cmbRoute.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select Route";
            // 
            // chkSupplier
            // 
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Checked = true;
            this.chkSupplier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupplier.Location = new System.Drawing.Point(374, 92);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(78, 17);
            this.chkSupplier.TabIndex = 10;
            this.chkSupplier.Text = "Supplier All";
            this.chkSupplier.UseVisualStyleBackColor = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chkSupplier_CheckedChanged);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(129, 89);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(239, 21);
            this.cmbSupplier.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Supplier Name";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(129, 60);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(105, 21);
            this.cmbMonth.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Month";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmbYear.Location = new System.Drawing.Point(129, 29);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(105, 21);
            this.cmbYear.TabIndex = 5;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Year";
            // 
            // btnPaySmryDetail
            // 
            this.btnPaySmryDetail.Location = new System.Drawing.Point(125, 19);
            this.btnPaySmryDetail.Name = "btnPaySmryDetail";
            this.btnPaySmryDetail.Size = new System.Drawing.Size(122, 23);
            this.btnPaySmryDetail.TabIndex = 25;
            this.btnPaySmryDetail.Text = "Display Detail Report";
            this.btnPaySmryDetail.UseVisualStyleBackColor = true;
            this.btnPaySmryDetail.Click += new System.EventHandler(this.btnPaySmryDetail_Click);
            // 
            // btnPaySmry
            // 
            this.btnPaySmry.Location = new System.Drawing.Point(6, 19);
            this.btnPaySmry.Name = "btnPaySmry";
            this.btnPaySmry.Size = new System.Drawing.Size(113, 23);
            this.btnPaySmry.TabIndex = 26;
            this.btnPaySmry.Text = "Payment Summary";
            this.btnPaySmry.UseVisualStyleBackColor = true;
            this.btnPaySmry.Click += new System.EventHandler(this.btnPaySmry_Click);
            // 
            // btnPaySmryRoute
            // 
            this.btnPaySmryRoute.Location = new System.Drawing.Point(253, 19);
            this.btnPaySmryRoute.Name = "btnPaySmryRoute";
            this.btnPaySmryRoute.Size = new System.Drawing.Size(141, 23);
            this.btnPaySmryRoute.TabIndex = 27;
            this.btnPaySmryRoute.Text = "Route Wise Summary";
            this.btnPaySmryRoute.UseVisualStyleBackColor = true;
            this.btnPaySmryRoute.Click += new System.EventHandler(this.btnPaySmryRoute_Click);
            // 
            // btnLMDebt
            // 
            this.btnLMDebt.Location = new System.Drawing.Point(6, 48);
            this.btnLMDebt.Name = "btnLMDebt";
            this.btnLMDebt.Size = new System.Drawing.Size(113, 23);
            this.btnLMDebt.TabIndex = 28;
            this.btnLMDebt.Text = "This Month Debts";
            this.btnLMDebt.UseVisualStyleBackColor = true;
            this.btnLMDebt.Click += new System.EventHandler(this.btnLMDebt_Click);
            // 
            // btnNMDebt
            // 
            this.btnNMDebt.Location = new System.Drawing.Point(6, 77);
            this.btnNMDebt.Name = "btnNMDebt";
            this.btnNMDebt.Size = new System.Drawing.Size(113, 23);
            this.btnNMDebt.TabIndex = 29;
            this.btnNMDebt.Text = "Last Month Debts";
            this.btnNMDebt.UseVisualStyleBackColor = true;
            this.btnNMDebt.Click += new System.EventHandler(this.btnNMDebt_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(253, 77);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 23);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnSkippedDeductions);
            this.groupBox3.Controls.Add(this.btnIncentiveSummary);
            this.groupBox3.Controls.Add(this.btnPaySmry);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnPaySmryDetail);
            this.groupBox3.Controls.Add(this.btnNMDebt);
            this.groupBox3.Controls.Add(this.btnPaySmryRoute);
            this.groupBox3.Controls.Add(this.btnLMDebt);
            this.groupBox3.Location = new System.Drawing.Point(12, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 107);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Deductions Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSkippedDeductions
            // 
            this.btnSkippedDeductions.Location = new System.Drawing.Point(125, 77);
            this.btnSkippedDeductions.Name = "btnSkippedDeductions";
            this.btnSkippedDeductions.Size = new System.Drawing.Size(122, 23);
            this.btnSkippedDeductions.TabIndex = 32;
            this.btnSkippedDeductions.Text = "Skipped Deductions";
            this.btnSkippedDeductions.UseVisualStyleBackColor = true;
            this.btnSkippedDeductions.Click += new System.EventHandler(this.btnSkippedDeductions_Click);
            // 
            // btnIncentiveSummary
            // 
            this.btnIncentiveSummary.Location = new System.Drawing.Point(253, 48);
            this.btnIncentiveSummary.Name = "btnIncentiveSummary";
            this.btnIncentiveSummary.Size = new System.Drawing.Size(141, 23);
            this.btnIncentiveSummary.TabIndex = 31;
            this.btnIncentiveSummary.Text = "Incentive Details";
            this.btnIncentiveSummary.UseVisualStyleBackColor = true;
            this.btnIncentiveSummary.Click += new System.EventHandler(this.btnIncentiveSummary_Click);
            // 
            // gbCollector
            // 
            this.gbCollector.Controls.Add(this.btnCollectorPayment);
            this.gbCollector.Location = new System.Drawing.Point(12, 268);
            this.gbCollector.Name = "gbCollector";
            this.gbCollector.Size = new System.Drawing.Size(402, 59);
            this.gbCollector.TabIndex = 32;
            this.gbCollector.TabStop = false;
            this.gbCollector.Text = "Collector Payment";
            // 
            // btnCollectorPayment
            // 
            this.btnCollectorPayment.Location = new System.Drawing.Point(6, 19);
            this.btnCollectorPayment.Name = "btnCollectorPayment";
            this.btnCollectorPayment.Size = new System.Drawing.Size(388, 23);
            this.btnCollectorPayment.TabIndex = 34;
            this.btnCollectorPayment.Text = "Collector Payment";
            this.btnCollectorPayment.UseVisualStyleBackColor = true;
            this.btnCollectorPayment.Click += new System.EventHandler(this.btnCollectorPayment_Click);
            // 
            // SupplierPaymentRPTFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 354);
            this.Controls.Add(this.gbCollector);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierPaymentRPTFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Payment Summary";
            this.Load += new System.EventHandler(this.SupplierPaymentRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gbCollector.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPaySmryDetail;
        private System.Windows.Forms.Button btnPaySmry;
        private System.Windows.Forms.Button btnPaySmryRoute;
        private System.Windows.Forms.Button btnLMDebt;
        private System.Windows.Forms.Button btnNMDebt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIncentiveSummary;
        private System.Windows.Forms.CheckBox chkRoute;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSkippedDeductions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbCollector;
        private System.Windows.Forms.Button btnCollectorPayment;
    }
}