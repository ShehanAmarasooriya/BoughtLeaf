namespace OLAXBoughtLeaf
{
    partial class DeductionApprovalFRM
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
            this.btnApproval = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.gvList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFillData = new System.Windows.Forms.Button();
            this.cmbDeductGroup = new System.Windows.Forms.ComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApproval
            // 
            this.btnApproval.BackColor = System.Drawing.Color.Transparent;
            this.btnApproval.Location = new System.Drawing.Point(122, 68);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(115, 23);
            this.btnApproval.TabIndex = 7;
            this.btnApproval.Text = "Update as Confirm";
            this.btnApproval.UseVisualStyleBackColor = false;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(12, 68);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(104, 23);
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "Check All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.Location = new System.Drawing.Point(12, 105);
            this.gvList.Name = "gvList";
            this.gvList.ReadOnly = true;
            this.gvList.Size = new System.Drawing.Size(690, 255);
            this.gvList.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFillData);
            this.groupBox1.Controls.Add(this.cmbDeductGroup);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 52);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Deduction Group";
            // 
            // btnFillData
            // 
            this.btnFillData.BackColor = System.Drawing.Color.Transparent;
            this.btnFillData.Location = new System.Drawing.Point(320, 15);
            this.btnFillData.Name = "btnFillData";
            this.btnFillData.Size = new System.Drawing.Size(90, 23);
            this.btnFillData.TabIndex = 17;
            this.btnFillData.Text = "Fill Data";
            this.btnFillData.UseVisualStyleBackColor = false;
            this.btnFillData.Click += new System.EventHandler(this.btnFillData_Click);
            // 
            // cmbDeductGroup
            // 
            this.cmbDeductGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeductGroup.FormattingEnabled = true;
            this.cmbDeductGroup.Location = new System.Drawing.Point(112, 16);
            this.cmbDeductGroup.Name = "cmbDeductGroup";
            this.cmbDeductGroup.Size = new System.Drawing.Size(148, 21);
            this.cmbDeductGroup.TabIndex = 14;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(266, 18);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 15;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAllRoute_CheckedChanged);
            // 
            // DeductionApprovalFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 372);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnApproval);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.gvList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeductionApprovalFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Deduction Approval";
            this.Load += new System.EventHandler(this.FrmOtherDeductionApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApproval;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFillData;
        private System.Windows.Forms.ComboBox cmbDeductGroup;
        private System.Windows.Forms.CheckBox chkAll;
    }
}