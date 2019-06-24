namespace OLAXBoughtLeaf
{
    partial class AdvancedBooking
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
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAllRoutes = new System.Windows.Forms.CheckBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbissueDate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvList = new System.Windows.Forms.DataGridView();
            this.CheckConfirm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtadvPayRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpAdvBook = new System.Windows.Forms.GroupBox();
            this.lblAdvAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGrpSave = new System.Windows.Forms.Button();
            this.txtadvPayment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSupName = new System.Windows.Forms.Label();
            this.txtSupCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkConfirm = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btncancelConfirmAdvbook = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpAdvBook.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRoute
            // 
            this.cmbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(83, 14);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(170, 21);
            this.cmbRoute.TabIndex = 6;
            this.cmbRoute.SelectedIndexChanged += new System.EventHandler(this.cmbRoute_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Route Name";
            // 
            // chkAllRoutes
            // 
            this.chkAllRoutes.AutoSize = true;
            this.chkAllRoutes.Location = new System.Drawing.Point(267, 16);
            this.chkAllRoutes.Name = "chkAllRoutes";
            this.chkAllRoutes.Size = new System.Drawing.Size(74, 17);
            this.chkAllRoutes.TabIndex = 27;
            this.chkAllRoutes.Text = "All Routes";
            this.chkAllRoutes.UseVisualStyleBackColor = true;
            this.chkAllRoutes.CheckedChanged += new System.EventHandler(this.chkAllRoutes_CheckedChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(599, 14);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(123, 21);
            this.cmbMonth.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Month";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmbYear.Location = new System.Drawing.Point(405, 15);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(123, 21);
            this.cmbYear.TabIndex = 0;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Year";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbissueDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.FromDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ToDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 46);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbissueDate
            // 
            this.cmbissueDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbissueDate.FormattingEnabled = true;
            this.cmbissueDate.Location = new System.Drawing.Point(76, 14);
            this.cmbissueDate.Name = "cmbissueDate";
            this.cmbissueDate.Size = new System.Drawing.Size(123, 21);
            this.cmbissueDate.TabIndex = 46;
            this.cmbissueDate.SelectedIndexChanged += new System.EventHandler(this.cmbissueDate_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Issuse Date";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // FromDate
            // 
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDate.Location = new System.Drawing.Point(245, 15);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(105, 20);
            this.FromDate.TabIndex = 0;
            this.FromDate.ValueChanged += new System.EventHandler(this.FromDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "From";
            // 
            // ToDate
            // 
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDate.Location = new System.Drawing.Point(388, 14);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(105, 20);
            this.ToDate.TabIndex = 1;
            this.ToDate.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "To";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbRoute);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbMonth);
            this.groupBox2.Controls.Add(this.chkAllRoutes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbYear);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 44);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckConfirm});
            this.gvList.Location = new System.Drawing.Point(8, 107);
            this.gvList.Name = "gvList";
            this.gvList.Size = new System.Drawing.Size(1237, 320);
            this.gvList.TabIndex = 38;
            this.gvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellDoubleClick);
            this.gvList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellEndEdit);
            this.gvList.CellStyleContentChanged += new System.Windows.Forms.DataGridViewCellStyleContentChangedEventHandler(this.gvList_CellStyleContentChanged);
            this.gvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellContentClick);
            // 
            // CheckConfirm
            // 
            this.CheckConfirm.HeaderText = "Confirm";
            this.CheckConfirm.Name = "CheckConfirm";
            this.CheckConfirm.Width = 45;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(1146, 453);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(86, 30);
            this.btnclose.TabIndex = 2;
            this.btnclose.Text = "CLOSE";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(1052, 453);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(86, 30);
            this.btnreset.TabIndex = 1;
            this.btnreset.Text = "RESET ";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtadvPayRate);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(532, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(234, 41);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(212, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "%";
            // 
            // txtadvPayRate
            // 
            this.txtadvPayRate.Location = new System.Drawing.Point(169, 13);
            this.txtadvPayRate.Name = "txtadvPayRate";
            this.txtadvPayRate.Size = new System.Drawing.Size(41, 20);
            this.txtadvPayRate.TabIndex = 1;
            this.txtadvPayRate.Text = "100";
            this.txtadvPayRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtadvPayRate.TextChanged += new System.EventHandler(this.txtadvPayRate_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Advanced Payment Percentage";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(955, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 39);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "ADVANED \r\nBOOK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // grpAdvBook
            // 
            this.grpAdvBook.Controls.Add(this.lblAdvAmount);
            this.grpAdvBook.Controls.Add(this.label9);
            this.grpAdvBook.Controls.Add(this.btnGrpSave);
            this.grpAdvBook.Controls.Add(this.txtadvPayment);
            this.grpAdvBook.Controls.Add(this.label10);
            this.grpAdvBook.Controls.Add(this.lblSupName);
            this.grpAdvBook.Controls.Add(this.txtSupCode);
            this.grpAdvBook.Controls.Add(this.label8);
            this.grpAdvBook.Location = new System.Drawing.Point(30, 433);
            this.grpAdvBook.Name = "grpAdvBook";
            this.grpAdvBook.Size = new System.Drawing.Size(414, 68);
            this.grpAdvBook.TabIndex = 42;
            this.grpAdvBook.TabStop = false;
            this.grpAdvBook.Text = "Advanecd Booking";
            // 
            // lblAdvAmount
            // 
            this.lblAdvAmount.AutoSize = true;
            this.lblAdvAmount.Location = new System.Drawing.Point(255, 44);
            this.lblAdvAmount.Name = "lblAdvAmount";
            this.lblAdvAmount.Size = new System.Drawing.Size(0, 13);
            this.lblAdvAmount.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(234, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "RS.";
            // 
            // btnGrpSave
            // 
            this.btnGrpSave.Location = new System.Drawing.Point(332, 40);
            this.btnGrpSave.Name = "btnGrpSave";
            this.btnGrpSave.Size = new System.Drawing.Size(75, 23);
            this.btnGrpSave.TabIndex = 5;
            this.btnGrpSave.Text = "SAVE";
            this.btnGrpSave.UseVisualStyleBackColor = true;
            this.btnGrpSave.Click += new System.EventHandler(this.btnGrpSave_Click);
            // 
            // txtadvPayment
            // 
            this.txtadvPayment.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtadvPayment.Location = new System.Drawing.Point(126, 42);
            this.txtadvPayment.Name = "txtadvPayment";
            this.txtadvPayment.Size = new System.Drawing.Size(101, 20);
            this.txtadvPayment.TabIndex = 4;
            this.txtadvPayment.Text = "Enter Adv Payment";
            this.txtadvPayment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtadvPayment_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Adv Payment Amount";
            // 
            // lblSupName
            // 
            this.lblSupName.AutoSize = true;
            this.lblSupName.Location = new System.Drawing.Point(198, 20);
            this.lblSupName.Name = "lblSupName";
            this.lblSupName.Size = new System.Drawing.Size(0, 13);
            this.lblSupName.TabIndex = 2;
            // 
            // txtSupCode
            // 
            this.txtSupCode.AutoCompleteCustomSource.AddRange(new string[] {
            "fsdfdsf"});
            this.txtSupCode.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSupCode.Location = new System.Drawing.Point(126, 17);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(66, 20);
            this.txtSupCode.TabIndex = 1;
            this.txtSupCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSupCode_MouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Suplier Code";
            // 
            // chkConfirm
            // 
            this.chkConfirm.AutoSize = true;
            this.chkConfirm.Location = new System.Drawing.Point(11, 15);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.Size = new System.Drawing.Size(132, 17);
            this.chkConfirm.TabIndex = 43;
            this.chkConfirm.Text = "Check All Confirmation";
            this.chkConfirm.UseVisualStyleBackColor = true;
            this.chkConfirm.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkConfirm);
            this.groupBox3.Location = new System.Drawing.Point(773, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(146, 41);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(775, 65);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(139, 28);
            this.btnConfirm.TabIndex = 45;
            this.btnConfirm.Text = "Confirm Advance Book";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btncancelConfirmAdvbook
            // 
            this.btncancelConfirmAdvbook.Location = new System.Drawing.Point(937, 63);
            this.btncancelConfirmAdvbook.Name = "btncancelConfirmAdvbook";
            this.btncancelConfirmAdvbook.Size = new System.Drawing.Size(173, 28);
            this.btncancelConfirmAdvbook.TabIndex = 46;
            this.btncancelConfirmAdvbook.Text = "Cancel Confirm Advance Book";
            this.btncancelConfirmAdvbook.UseVisualStyleBackColor = true;
            this.btncancelConfirmAdvbook.Click += new System.EventHandler(this.btncancelConfirmAdvbook_Click);
            // 
            // AdvancedBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 508);
            this.Controls.Add(this.btncancelConfirmAdvbook);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpAdvBook);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.gvList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "AdvancedBooking";
            this.Text = "Advanced Booking";
            this.Load += new System.EventHandler(this.AdvancedBooking_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpAdvBook.ResumeLayout(false);
            this.grpAdvBook.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAllRoutes;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtadvPayRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpAdvBook;
        private System.Windows.Forms.Label lblSupName;
        private System.Windows.Forms.TextBox txtSupCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtadvPayment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGrpSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckConfirm;
        private System.Windows.Forms.CheckBox chkConfirm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblAdvAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbissueDate;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btncancelConfirmAdvbook;
    }
}