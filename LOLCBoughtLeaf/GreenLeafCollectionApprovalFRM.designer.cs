namespace OLAXBoughtLeaf
{
    partial class GreenLeafCollectionApprovalFRM
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.chkAllRoute = new System.Windows.Forms.CheckBox();
            this.dtpMain = new System.Windows.Forms.DateTimePicker();
            this.btnFillData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblGreenLeaf = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBags = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSack = new System.Windows.Forms.Label();
            this.lblTrnCost = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApproval
            // 
            this.btnApproval.BackColor = System.Drawing.Color.Transparent;
            this.btnApproval.Location = new System.Drawing.Point(112, 19);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(115, 23);
            this.btnApproval.TabIndex = 10;
            this.btnApproval.Text = "Update As Confirm";
            this.btnApproval.UseVisualStyleBackColor = false;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(6, 19);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(100, 23);
            this.btnAll.TabIndex = 9;
            this.btnAll.Text = "Check All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.Location = new System.Drawing.Point(6, 48);
            this.gvList.Name = "gvList";
            this.gvList.ReadOnly = true;
            this.gvList.Size = new System.Drawing.Size(690, 264);
            this.gvList.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Total Green Leaf :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Route";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Date";
            // 
            // cmbRoute
            // 
            this.cmbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(60, 17);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(148, 21);
            this.cmbRoute.TabIndex = 14;
            // 
            // chkAllRoute
            // 
            this.chkAllRoute.AutoSize = true;
            this.chkAllRoute.Location = new System.Drawing.Point(214, 20);
            this.chkAllRoute.Name = "chkAllRoute";
            this.chkAllRoute.Size = new System.Drawing.Size(37, 17);
            this.chkAllRoute.TabIndex = 15;
            this.chkAllRoute.Text = "All";
            this.chkAllRoute.UseVisualStyleBackColor = true;
            this.chkAllRoute.CheckedChanged += new System.EventHandler(this.chkAllRoute_CheckedChanged);
            // 
            // dtpMain
            // 
            this.dtpMain.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMain.Location = new System.Drawing.Point(314, 18);
            this.dtpMain.Name = "dtpMain";
            this.dtpMain.Size = new System.Drawing.Size(121, 20);
            this.dtpMain.TabIndex = 16;
            // 
            // btnFillData
            // 
            this.btnFillData.BackColor = System.Drawing.Color.Transparent;
            this.btnFillData.Location = new System.Drawing.Point(456, 15);
            this.btnFillData.Name = "btnFillData";
            this.btnFillData.Size = new System.Drawing.Size(90, 23);
            this.btnFillData.TabIndex = 17;
            this.btnFillData.Text = "Fill Data";
            this.btnFillData.UseVisualStyleBackColor = false;
            this.btnFillData.Click += new System.EventHandler(this.btnFillData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFillData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpMain);
            this.groupBox1.Controls.Add(this.cmbRoute);
            this.groupBox1.Controls.Add(this.chkAllRoute);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 52);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnApproval);
            this.groupBox2.Controls.Add(this.btnAll);
            this.groupBox2.Controls.Add(this.gvList);
            this.groupBox2.Location = new System.Drawing.Point(10, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 329);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // lblGreenLeaf
            // 
            this.lblGreenLeaf.AutoSize = true;
            this.lblGreenLeaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreenLeaf.Location = new System.Drawing.Point(136, 403);
            this.lblGreenLeaf.Name = "lblGreenLeaf";
            this.lblGreenLeaf.Size = new System.Drawing.Size(24, 16);
            this.lblGreenLeaf.TabIndex = 20;
            this.lblGreenLeaf.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "No. Bags :";
            // 
            // lblBags
            // 
            this.lblBags.AutoSize = true;
            this.lblBags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBags.Location = new System.Drawing.Point(288, 404);
            this.lblBags.Name = "lblBags";
            this.lblBags.Size = new System.Drawing.Size(24, 16);
            this.lblBags.TabIndex = 22;
            this.lblBags.Text = "00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(361, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Sack Killos :";
            // 
            // lblSack
            // 
            this.lblSack.AutoSize = true;
            this.lblSack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSack.Location = new System.Drawing.Point(452, 403);
            this.lblSack.Name = "lblSack";
            this.lblSack.Size = new System.Drawing.Size(24, 16);
            this.lblSack.TabIndex = 24;
            this.lblSack.Text = "00";
            // 
            // lblTrnCost
            // 
            this.lblTrnCost.AutoSize = true;
            this.lblTrnCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrnCost.Location = new System.Drawing.Point(629, 403);
            this.lblTrnCost.Name = "lblTrnCost";
            this.lblTrnCost.Size = new System.Drawing.Size(24, 16);
            this.lblTrnCost.TabIndex = 26;
            this.lblTrnCost.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(514, 403);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Transport Cost :";
            // 
            // GreenLeafCollectionApprovalFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 432);
            this.Controls.Add(this.lblTrnCost);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblSack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBags);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblGreenLeaf);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GreenLeafCollectionApprovalFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GreenLeaf Collection Approval";
            this.Load += new System.EventHandler(this.FrmDailyGreenLeafApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApproval;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.CheckBox chkAllRoute;
        private System.Windows.Forms.DateTimePicker dtpMain;
        private System.Windows.Forms.Button btnFillData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblGreenLeaf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBags;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSack;
        private System.Windows.Forms.Label lblTrnCost;
        private System.Windows.Forms.Label label10;
    }
}