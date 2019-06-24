namespace OLAXBoughtLeaf
{
    partial class GreenLeafSummaryReport
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBox4;
            this.lblEarningsStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdProcess = new System.Windows.Forms.Button();
            this.gbSupplierSelection = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.chkAllRoutes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSupName = new System.Windows.Forms.TextBox();
            this.txtSupCode = new System.Windows.Forms.TextBox();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.txt_rate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbSupplierSelection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.lblEarningsStatus);
            groupBox4.Controls.Add(this.progressBar);
            groupBox4.Controls.Add(this.lblStatus);
            groupBox4.Location = new System.Drawing.Point(372, 1);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(314, 77);
            groupBox4.TabIndex = 31;
            groupBox4.TabStop = false;
            // 
            // lblEarningsStatus
            // 
            this.lblEarningsStatus.AutoSize = true;
            this.lblEarningsStatus.Location = new System.Drawing.Point(11, 56);
            this.lblEarningsStatus.Name = "lblEarningsStatus";
            this.lblEarningsStatus.Size = new System.Drawing.Size(19, 13);
            this.lblEarningsStatus.TabIndex = 21;
            this.lblEarningsStatus.Text = "....";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(290, 18);
            this.progressBar.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(11, 40);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(19, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "....";
            // 
            // FromDate
            // 
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDate.Location = new System.Drawing.Point(101, 20);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(105, 20);
            this.FromDate.TabIndex = 0;
            this.FromDate.ValueChanged += new System.EventHandler(this.FromDate_ValueChanged);
            // 
            // ToDate
            // 
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDate.Location = new System.Drawing.Point(101, 46);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(105, 20);
            this.ToDate.TabIndex = 1;
            this.ToDate.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(692, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(692, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 20);
            this.button2.TabIndex = 6;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(2, 228);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(812, 355);
            this.crystalReportViewer1.TabIndex = 9;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ToDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 77);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // cmdProcess
            // 
            this.cmdProcess.Enabled = false;
            this.cmdProcess.Location = new System.Drawing.Point(319, 15);
            this.cmdProcess.Name = "cmdProcess";
            this.cmdProcess.Size = new System.Drawing.Size(346, 23);
            this.cmdProcess.TabIndex = 29;
            this.cmdProcess.Text = "Prepare Credit Availability";
            this.cmdProcess.UseVisualStyleBackColor = true;
            this.cmdProcess.Click += new System.EventHandler(this.cmdProcess_Click);
            // 
            // gbSupplierSelection
            // 
            this.gbSupplierSelection.Controls.Add(this.button5);
            this.gbSupplierSelection.Controls.Add(this.chkAllRoutes);
            this.gbSupplierSelection.Controls.Add(this.label4);
            this.gbSupplierSelection.Controls.Add(this.label3);
            this.gbSupplierSelection.Controls.Add(this.txtSupName);
            this.gbSupplierSelection.Controls.Add(this.txtSupCode);
            this.gbSupplierSelection.Controls.Add(this.cmbRoute);
            this.gbSupplierSelection.Location = new System.Drawing.Point(3, 146);
            this.gbSupplierSelection.Name = "gbSupplierSelection";
            this.gbSupplierSelection.Size = new System.Drawing.Size(683, 76);
            this.gbSupplierSelection.TabIndex = 30;
            this.gbSupplierSelection.TabStop = false;
            this.gbSupplierSelection.Text = "Get Supplier Credit Availability";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(363, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(169, 20);
            this.button5.TabIndex = 28;
            this.button5.Text = "Credit Availability";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chkAllRoutes
            // 
            this.chkAllRoutes.AutoSize = true;
            this.chkAllRoutes.Checked = true;
            this.chkAllRoutes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllRoutes.Location = new System.Drawing.Point(312, 21);
            this.chkAllRoutes.Name = "chkAllRoutes";
            this.chkAllRoutes.Size = new System.Drawing.Size(74, 17);
            this.chkAllRoutes.TabIndex = 27;
            this.chkAllRoutes.Text = "All Routes";
            this.chkAllRoutes.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Route";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Supplier Code";
            // 
            // txtSupName
            // 
            this.txtSupName.Location = new System.Drawing.Point(153, 46);
            this.txtSupName.Multiline = true;
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(204, 20);
            this.txtSupName.TabIndex = 14;
            // 
            // txtSupCode
            // 
            this.txtSupCode.Location = new System.Drawing.Point(100, 46);
            this.txtSupCode.MaxLength = 5;
            this.txtSupCode.Multiline = true;
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(47, 20);
            this.txtSupCode.TabIndex = 13;
            this.txtSupCode.TextChanged += new System.EventHandler(this.txtSupCode_TextChanged_1);
            // 
            // cmbRoute
            // 
            this.cmbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(100, 19);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(206, 21);
            this.cmbRoute.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(541, 192);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(139, 20);
            this.button6.TabIndex = 29;
            this.button6.Text = "History";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txt_rate
            // 
            this.txt_rate.Location = new System.Drawing.Point(152, 15);
            this.txt_rate.Name = "txt_rate";
            this.txt_rate.Size = new System.Drawing.Size(153, 20);
            this.txt_rate.TabIndex = 32;
            this.txt_rate.TextChanged += new System.EventHandler(this.txt_rate_TextChanged);
            this.txt_rate.Leave += new System.EventHandler(this.txt_rate_Leave);
            this.txt_rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_rate_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Boughtleaf Minimum Rate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_rate);
            this.groupBox2.Controls.Add(this.cmdProcess);
            this.groupBox2.Location = new System.Drawing.Point(3, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(683, 54);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // GreenLeafSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 607);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(groupBox4);
            this.Controls.Add(this.gbSupplierSelection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(832, 645);
            this.MinimumSize = new System.Drawing.Size(832, 645);
            this.Name = "GreenLeafSummaryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Month To Date Credit Availability ";
            this.Load += new System.EventHandler(this.GreenLeafSummaryReport_Load);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSupplierSelection.ResumeLayout(false);
            this.gbSupplierSelection.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdProcess;
        private System.Windows.Forms.GroupBox gbSupplierSelection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSupName;
        private System.Windows.Forms.TextBox txtSupCode;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.CheckBox chkAllRoutes;
        private System.Windows.Forms.Label lblEarningsStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_rate;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}