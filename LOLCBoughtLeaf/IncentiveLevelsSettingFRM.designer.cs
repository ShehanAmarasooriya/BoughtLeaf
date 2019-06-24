namespace OLAXBoughtLeaf
{
    partial class IncentiveLevelsSettingFRM
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
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSupplierWise = new System.Windows.Forms.RadioButton();
            this.rbRouteWise = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(114, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSupplierWise);
            this.groupBox1.Controls.Add(this.rbRouteWise);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbSupplierWise
            // 
            this.rbSupplierWise.AutoSize = true;
            this.rbSupplierWise.Location = new System.Drawing.Point(141, 30);
            this.rbSupplierWise.Name = "rbSupplierWise";
            this.rbSupplierWise.Size = new System.Drawing.Size(90, 17);
            this.rbSupplierWise.TabIndex = 5;
            this.rbSupplierWise.TabStop = true;
            this.rbSupplierWise.Text = "Supplier Wise";
            this.rbSupplierWise.UseVisualStyleBackColor = true;
            // 
            // rbRouteWise
            // 
            this.rbRouteWise.AutoSize = true;
            this.rbRouteWise.Checked = true;
            this.rbRouteWise.Location = new System.Drawing.Point(33, 30);
            this.rbRouteWise.Name = "rbRouteWise";
            this.rbRouteWise.Size = new System.Drawing.Size(81, 17);
            this.rbRouteWise.TabIndex = 4;
            this.rbRouteWise.TabStop = true;
            this.rbRouteWise.Text = "Route Wise";
            this.rbRouteWise.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(201, 91);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // IncentiveLevelsSettingFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 126);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncentiveLevelsSettingFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incentive Levels Setting";
            this.Load += new System.EventHandler(this.IncentiveLevelsSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSupplierWise;
        private System.Windows.Forms.RadioButton rbRouteWise;
        private System.Windows.Forms.Button btnClose;
    }
}