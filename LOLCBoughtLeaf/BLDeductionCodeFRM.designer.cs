namespace OLAXBoughtLeaf
{
    partial class BLDeductionCodeFRM
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCommissionAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeductAmount = new System.Windows.Forms.TextBox();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.cmbDeductGroupCode = new System.Windows.Forms.ComboBox();
            this.cmbDeductionGroupCode = new System.Windows.Forms.Label();
            this.chkDeductionUntilStop = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Priority = new System.Windows.Forms.Label();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.txtDeductionName = new System.Windows.Forms.TextBox();
            this.txtDeductionCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvDeduction = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cachedGreenLeafSummaryROUTERPT1 = new OLAXBoughtLeaf.CachedGreenLeafSummaryROUTERPT();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.groupBoxButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCommissionAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDeductAmount);
            this.groupBox1.Controls.Add(this.nudPriority);
            this.groupBox1.Controls.Add(this.cmbDeductGroupCode);
            this.groupBox1.Controls.Add(this.cmbDeductionGroupCode);
            this.groupBox1.Controls.Add(this.chkDeductionUntilStop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Priority);
            this.groupBox1.Controls.Add(this.txtAccountCode);
            this.groupBox1.Controls.Add(this.txtDeductionName);
            this.groupBox1.Controls.Add(this.txtDeductionCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 248);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Commission Amount";
            // 
            // txtCommissionAmount
            // 
            this.txtCommissionAmount.Location = new System.Drawing.Point(146, 158);
            this.txtCommissionAmount.Name = "txtCommissionAmount";
            this.txtCommissionAmount.Size = new System.Drawing.Size(167, 20);
            this.txtCommissionAmount.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Deduction Amount";
            // 
            // txtDeductAmount
            // 
            this.txtDeductAmount.Location = new System.Drawing.Point(146, 132);
            this.txtDeductAmount.Name = "txtDeductAmount";
            this.txtDeductAmount.Size = new System.Drawing.Size(167, 20);
            this.txtDeductAmount.TabIndex = 4;
            // 
            // nudPriority
            // 
            this.nudPriority.Location = new System.Drawing.Point(146, 106);
            this.nudPriority.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPriority.Name = "nudPriority";
            this.nudPriority.ReadOnly = true;
            this.nudPriority.Size = new System.Drawing.Size(46, 20);
            this.nudPriority.TabIndex = 3;
            // 
            // cmbDeductGroupCode
            // 
            this.cmbDeductGroupCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeductGroupCode.FormattingEnabled = true;
            this.cmbDeductGroupCode.Location = new System.Drawing.Point(146, 27);
            this.cmbDeductGroupCode.Name = "cmbDeductGroupCode";
            this.cmbDeductGroupCode.Size = new System.Drawing.Size(167, 21);
            this.cmbDeductGroupCode.TabIndex = 0;
            this.cmbDeductGroupCode.SelectedIndexChanged += new System.EventHandler(this.cmbDeductGroupCode_SelectedIndexChanged);
            // 
            // cmbDeductionGroupCode
            // 
            this.cmbDeductionGroupCode.AutoSize = true;
            this.cmbDeductionGroupCode.Location = new System.Drawing.Point(19, 31);
            this.cmbDeductionGroupCode.Name = "cmbDeductionGroupCode";
            this.cmbDeductionGroupCode.Size = new System.Drawing.Size(116, 13);
            this.cmbDeductionGroupCode.TabIndex = 12;
            this.cmbDeductionGroupCode.Text = "Deduction Group Code";
            // 
            // chkDeductionUntilStop
            // 
            this.chkDeductionUntilStop.AutoSize = true;
            this.chkDeductionUntilStop.Location = new System.Drawing.Point(146, 210);
            this.chkDeductionUntilStop.Name = "chkDeductionUntilStop";
            this.chkDeductionUntilStop.Size = new System.Drawing.Size(124, 17);
            this.chkDeductionUntilStop.TabIndex = 6;
            this.chkDeductionUntilStop.Text = "Deduction Until Stop";
            this.chkDeductionUntilStop.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Account Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Deduction Name";
            // 
            // Priority
            // 
            this.Priority.AutoSize = true;
            this.Priority.Location = new System.Drawing.Point(19, 110);
            this.Priority.Name = "Priority";
            this.Priority.Size = new System.Drawing.Size(38, 13);
            this.Priority.TabIndex = 2;
            this.Priority.Text = "Priority";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Location = new System.Drawing.Point(146, 184);
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(167, 20);
            this.txtAccountCode.TabIndex = 5;
            // 
            // txtDeductionName
            // 
            this.txtDeductionName.Location = new System.Drawing.Point(146, 81);
            this.txtDeductionName.Name = "txtDeductionName";
            this.txtDeductionName.Size = new System.Drawing.Size(167, 20);
            this.txtDeductionName.TabIndex = 2;
            this.txtDeductionName.TextChanged += new System.EventHandler(this.txtDeductionName_TextChanged);
            // 
            // txtDeductionCode
            // 
            this.txtDeductionCode.Location = new System.Drawing.Point(146, 55);
            this.txtDeductionCode.Name = "txtDeductionCode";
            this.txtDeductionCode.Size = new System.Drawing.Size(167, 20);
            this.txtDeductionCode.TabIndex = 1;
            this.txtDeductionCode.TextChanged += new System.EventHandler(this.txtDeductionCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deduction Code";
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.btnClear);
            this.groupBoxButtons.Controls.Add(this.btnUpdate);
            this.groupBoxButtons.Controls.Add(this.btnDelete);
            this.groupBoxButtons.Controls.Add(this.btnAdd);
            this.groupBoxButtons.Location = new System.Drawing.Point(12, 260);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(344, 61);
            this.groupBoxButtons.TabIndex = 1;
            this.groupBoxButtons.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(247, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(85, 22);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(166, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvDeduction
            // 
            this.dgvDeduction.AllowUserToAddRows = false;
            this.dgvDeduction.AllowUserToDeleteRows = false;
            this.dgvDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeduction.Location = new System.Drawing.Point(362, 12);
            this.dgvDeduction.Name = "dgvDeduction";
            this.dgvDeduction.ReadOnly = true;
            this.dgvDeduction.Size = new System.Drawing.Size(428, 309);
            this.dgvDeduction.TabIndex = 2;
            this.dgvDeduction.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeduction_CellDoubleClick);
            this.dgvDeduction.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeduction_CellContentClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BLDeductionCodeFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 332);
            this.Controls.Add(this.dgvDeduction);
            this.Controls.Add(this.groupBoxButtons);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BLDeductionCodeFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deduction Code Master";
            this.Load += new System.EventHandler(this.Deduction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
            this.groupBoxButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Priority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountCode;
        private System.Windows.Forms.TextBox txtDeductionName;
        private System.Windows.Forms.TextBox txtDeductionCode;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvDeduction;
        private System.Windows.Forms.CheckBox chkDeductionUntilStop;
        private System.Windows.Forms.Label cmbDeductionGroupCode;
        private System.Windows.Forms.ComboBox cmbDeductGroupCode;
        private System.Windows.Forms.NumericUpDown nudPriority;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtDeductAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCommissionAmount;
        private CachedGreenLeafSummaryROUTERPT cachedGreenLeafSummaryROUTERPT1;
    }
}