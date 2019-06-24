namespace OLAXBoughtLeaf
{
    partial class IncentivesTRNFRM
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
            this.allRouteChk = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbRouteNo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvList = new System.Windows.Forms.DataGridView();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdApplyAll = new System.Windows.Forms.Button();
            this.btnApplyToAllTansport = new System.Windows.Forms.Button();
            this.btnApplyToAllRegular = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allRouteChk);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbRouteNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // allRouteChk
            // 
            this.allRouteChk.AutoSize = true;
            this.allRouteChk.Location = new System.Drawing.Point(189, 45);
            this.allRouteChk.Name = "allRouteChk";
            this.allRouteChk.Size = new System.Drawing.Size(64, 17);
            this.allRouteChk.TabIndex = 37;
            this.allRouteChk.Text = "All route";
            this.allRouteChk.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbRouteNo
            // 
            this.cmbRouteNo.FormattingEnabled = true;
            this.cmbRouteNo.Location = new System.Drawing.Point(78, 43);
            this.cmbRouteNo.Name = "cmbRouteNo";
            this.cmbRouteNo.Size = new System.Drawing.Size(105, 21);
            this.cmbRouteNo.TabIndex = 35;
            this.cmbRouteNo.SelectedIndexChanged += new System.EventHandler(this.cmbRouteNo_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Route No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(78, 17);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(105, 20);
            this.dtDate.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvList);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.Location = new System.Drawing.Point(6, 12);
            this.gvList.Name = "gvList";
            this.gvList.Size = new System.Drawing.Size(581, 311);
            this.gvList.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(99, 451);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(18, 451);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdApplyAll
            // 
            this.cmdApplyAll.Location = new System.Drawing.Point(12, 87);
            this.cmdApplyAll.Name = "cmdApplyAll";
            this.cmdApplyAll.Size = new System.Drawing.Size(170, 23);
            this.cmdApplyAll.TabIndex = 37;
            this.cmdApplyAll.Text = "Apply 1st Value to All Incentives";
            this.cmdApplyAll.UseVisualStyleBackColor = true;
            this.cmdApplyAll.Click += new System.EventHandler(this.cmdApplyAll_Click);
            // 
            // btnApplyToAllTansport
            // 
            this.btnApplyToAllTansport.Location = new System.Drawing.Point(188, 87);
            this.btnApplyToAllTansport.Name = "btnApplyToAllTansport";
            this.btnApplyToAllTansport.Size = new System.Drawing.Size(223, 23);
            this.btnApplyToAllTansport.TabIndex = 38;
            this.btnApplyToAllTansport.Text = "Apply 1st Value to All Transport Incentives";
            this.btnApplyToAllTansport.UseVisualStyleBackColor = true;
            this.btnApplyToAllTansport.Click += new System.EventHandler(this.btnApplyToAllTansport_Click);
            // 
            // btnApplyToAllRegular
            // 
            this.btnApplyToAllRegular.Location = new System.Drawing.Point(417, 87);
            this.btnApplyToAllRegular.Name = "btnApplyToAllRegular";
            this.btnApplyToAllRegular.Size = new System.Drawing.Size(188, 23);
            this.btnApplyToAllRegular.TabIndex = 39;
            this.btnApplyToAllRegular.Text = "Apply 1st  to All Regular Incentives";
            this.btnApplyToAllRegular.UseVisualStyleBackColor = true;
            this.btnApplyToAllRegular.Click += new System.EventHandler(this.btnApplyToAllRegular_Click);
            // 
            // IncentivesTRNFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 486);
            this.Controls.Add(this.btnApplyToAllRegular);
            this.Controls.Add(this.btnApplyToAllTansport);
            this.Controls.Add(this.cmdApplyAll);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncentivesTRNFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incentives";
            this.Load += new System.EventHandler(this.Incentives_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRouteNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdApplyAll;
        private System.Windows.Forms.CheckBox allRouteChk;
        private System.Windows.Forms.Button btnApplyToAllTansport;
        private System.Windows.Forms.Button btnApplyToAllRegular;
    }
}