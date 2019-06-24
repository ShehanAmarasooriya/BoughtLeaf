namespace OLAXBoughtLeaf
{
    partial class MonthlyDeductionSummaryRPTFRM
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
            this.chkAllGroup = new System.Windows.Forms.CheckBox();
            this.chkDeduction = new System.Windows.Forms.CheckBox();
            this.chkRoute = new System.Windows.Forms.CheckBox();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDeductionCode = new System.Windows.Forms.ComboBox();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.cmbDeductionGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeductRegWithLeaf = new System.Windows.Forms.Button();
            this.btnDeductionRegister = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnDepositFund = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllGroup);
            this.groupBox1.Controls.Add(this.chkDeduction);
            this.groupBox1.Controls.Add(this.chkRoute);
            this.groupBox1.Controls.Add(this.cmbRoute);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbDeductionCode);
            this.groupBox1.Controls.Add(this.chkSupplier);
            this.groupBox1.Controls.Add(this.cmbDeductionGroup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbMonth);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkAllGroup
            // 
            this.chkAllGroup.AutoSize = true;
            this.chkAllGroup.Checked = true;
            this.chkAllGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllGroup.Location = new System.Drawing.Point(401, 136);
            this.chkAllGroup.Name = "chkAllGroup";
            this.chkAllGroup.Size = new System.Drawing.Size(74, 17);
            this.chkAllGroup.TabIndex = 42;
            this.chkAllGroup.Text = "All Groups";
            this.chkAllGroup.UseVisualStyleBackColor = true;
            this.chkAllGroup.CheckedChanged += new System.EventHandler(this.chkAllGroup_CheckedChanged);
            // 
            // chkDeduction
            // 
            this.chkDeduction.AutoSize = true;
            this.chkDeduction.Checked = true;
            this.chkDeduction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeduction.Location = new System.Drawing.Point(401, 163);
            this.chkDeduction.Name = "chkDeduction";
            this.chkDeduction.Size = new System.Drawing.Size(94, 17);
            this.chkDeduction.TabIndex = 41;
            this.chkDeduction.Text = "All Deductions";
            this.chkDeduction.UseVisualStyleBackColor = true;
            this.chkDeduction.CheckedChanged += new System.EventHandler(this.chkDeduction_CheckedChanged);
            // 
            // chkRoute
            // 
            this.chkRoute.AutoSize = true;
            this.chkRoute.Checked = true;
            this.chkRoute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRoute.Location = new System.Drawing.Point(293, 84);
            this.chkRoute.Name = "chkRoute";
            this.chkRoute.Size = new System.Drawing.Size(74, 17);
            this.chkRoute.TabIndex = 40;
            this.chkRoute.Text = "All Routes";
            this.chkRoute.UseVisualStyleBackColor = true;
            this.chkRoute.CheckedChanged += new System.EventHandler(this.chkRoute_CheckedChanged);
            // 
            // cmbRoute
            // 
            this.cmbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoute.Enabled = false;
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(137, 80);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(151, 21);
            this.cmbRoute.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Select Route";
            // 
            // cmbDeductionCode
            // 
            this.cmbDeductionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeductionCode.FormattingEnabled = true;
            this.cmbDeductionCode.Location = new System.Drawing.Point(137, 161);
            this.cmbDeductionCode.Name = "cmbDeductionCode";
            this.cmbDeductionCode.Size = new System.Drawing.Size(247, 21);
            this.cmbDeductionCode.TabIndex = 35;
            // 
            // chkSupplier
            // 
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Checked = true;
            this.chkSupplier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupplier.Location = new System.Drawing.Point(401, 112);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(83, 17);
            this.chkSupplier.TabIndex = 17;
            this.chkSupplier.Text = "All Suppliers";
            this.chkSupplier.UseVisualStyleBackColor = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chkSupplier_CheckedChanged);
            // 
            // cmbDeductionGroup
            // 
            this.cmbDeductionGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeductionGroup.FormattingEnabled = true;
            this.cmbDeductionGroup.Location = new System.Drawing.Point(137, 134);
            this.cmbDeductionGroup.Name = "cmbDeductionGroup";
            this.cmbDeductionGroup.Size = new System.Drawing.Size(247, 21);
            this.cmbDeductionGroup.TabIndex = 34;
            this.cmbDeductionGroup.SelectedIndexChanged += new System.EventHandler(this.cmbDeductionGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select Year";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Deduction ";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(137, 107);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(246, 21);
            this.cmbSupplier.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Deduction Group";
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
            this.cmbYear.Location = new System.Drawing.Point(137, 26);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(105, 21);
            this.cmbYear.TabIndex = 12;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Select Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(137, 53);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(105, 21);
            this.cmbMonth.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(409, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(319, 19);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(84, 23);
            this.btnShow.TabIndex = 32;
            this.btnShow.Text = "Show All";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(148, 19);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(165, 23);
            this.btnSummary.TabIndex = 33;
            this.btnSummary.Text = "Show Deduction Codewise";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Show Routewise";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnSummary);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnShow);
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 77);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Month Actual Deductions";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(480, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Supplier Code Wise Deduction Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeductRegWithLeaf);
            this.groupBox3.Controls.Add(this.btnDeductionRegister);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(12, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 52);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Month Deductions Register";
            // 
            // btnDeductRegWithLeaf
            // 
            this.btnDeductRegWithLeaf.Location = new System.Drawing.Point(148, 19);
            this.btnDeductRegWithLeaf.Name = "btnDeductRegWithLeaf";
            this.btnDeductRegWithLeaf.Size = new System.Drawing.Size(165, 23);
            this.btnDeductRegWithLeaf.TabIndex = 34;
            this.btnDeductRegWithLeaf.Text = "Register With Todate Leaf";
            this.btnDeductRegWithLeaf.UseVisualStyleBackColor = true;
            this.btnDeductRegWithLeaf.Click += new System.EventHandler(this.btnDeductRegWithLeaf_Click);
            // 
            // btnDeductionRegister
            // 
            this.btnDeductionRegister.Location = new System.Drawing.Point(15, 19);
            this.btnDeductionRegister.Name = "btnDeductionRegister";
            this.btnDeductionRegister.Size = new System.Drawing.Size(127, 23);
            this.btnDeductionRegister.TabIndex = 33;
            this.btnDeductionRegister.Text = "Register";
            this.btnDeductionRegister.UseVisualStyleBackColor = true;
            this.btnDeductionRegister.Click += new System.EventHandler(this.btnDeductionRegister_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(409, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnDepositFund
            // 
            this.btnDepositFund.Location = new System.Drawing.Point(27, 364);
            this.btnDepositFund.Name = "btnDepositFund";
            this.btnDepositFund.Size = new System.Drawing.Size(480, 23);
            this.btnDepositFund.TabIndex = 36;
            this.btnDepositFund.Text = "Deposit Fund Contributions";
            this.btnDepositFund.UseVisualStyleBackColor = true;
            this.btnDepositFund.Click += new System.EventHandler(this.btnDepositFund_Click);
            // 
            // MonthlyDeductionSummaryRPTFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 399);
            this.Controls.Add(this.btnDepositFund);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonthlyDeductionSummaryRPTFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Deduction Summary";
            this.Load += new System.EventHandler(this.MonthlyDeductionSummaryRPTFRM_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.ComboBox cmbDeductionCode;
        private System.Windows.Forms.ComboBox cmbDeductionGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRoute;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDeduction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeductionRegister;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDeductRegWithLeaf;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkAllGroup;
        private System.Windows.Forms.Button btnDepositFund;
    }
}