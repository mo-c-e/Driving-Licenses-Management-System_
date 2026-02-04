namespace DVLD_WindowsForms
{
    partial class frmAddInternationlLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.buIssue = new System.Windows.Forms.Button();
            this.buClose = new System.Windows.Forms.Button();
            this.linkLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.ucInternationalApplicationInfo1 = new DVLD_WindowsForms.UserControls.ucInternationalApplicationInfo();
            this.ucLicenseInfoWithFilter1 = new DVLD_WindowsForms.UserControls.ucLicenseInfoWithFilter();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(462, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(651, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "International License Application";
            // 
            // buIssue
            // 
            this.buIssue.Enabled = false;
            this.buIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buIssue.Image = global::DVLD_WindowsForms.Properties.Resources.International_32_2;
            this.buIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buIssue.Location = new System.Drawing.Point(1400, 1057);
            this.buIssue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buIssue.Name = "buIssue";
            this.buIssue.Size = new System.Drawing.Size(153, 55);
            this.buIssue.TabIndex = 46;
            this.buIssue.Text = "Issue";
            this.buIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buIssue.UseVisualStyleBackColor = true;
            this.buIssue.Click += new System.EventHandler(this.buIssue_Click);
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(1238, 1057);
            this.buClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(153, 55);
            this.buClose.TabIndex = 47;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // linkLicenseInfo
            // 
            this.linkLicenseInfo.AutoSize = true;
            this.linkLicenseInfo.Enabled = false;
            this.linkLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicenseInfo.Location = new System.Drawing.Point(344, 1085);
            this.linkLicenseInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLicenseInfo.Name = "linkLicenseInfo";
            this.linkLicenseInfo.Size = new System.Drawing.Size(209, 29);
            this.linkLicenseInfo.TabIndex = 48;
            this.linkLicenseInfo.TabStop = true;
            this.linkLicenseInfo.Text = "Show License Info";
            this.linkLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseInfo_LinkClicked);
            // 
            // linkLicensesHistory
            // 
            this.linkLicensesHistory.AutoSize = true;
            this.linkLicensesHistory.Enabled = false;
            this.linkLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicensesHistory.Location = new System.Drawing.Point(78, 1085);
            this.linkLicensesHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLicensesHistory.Name = "linkLicensesHistory";
            this.linkLicensesHistory.Size = new System.Drawing.Size(256, 29);
            this.linkLicensesHistory.TabIndex = 49;
            this.linkLicensesHistory.TabStop = true;
            this.linkLicensesHistory.Text = "Show Licenses History";
            this.linkLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicensesHistory_LinkClicked);
            // 
            // ucInternationalApplicationInfo1
            // 
            this.ucInternationalApplicationInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucInternationalApplicationInfo1.Location = new System.Drawing.Point(6, 740);
            this.ucInternationalApplicationInfo1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ucInternationalApplicationInfo1.Name = "ucInternationalApplicationInfo1";
            this.ucInternationalApplicationInfo1.Size = new System.Drawing.Size(1568, 304);
            this.ucInternationalApplicationInfo1.TabIndex = 1;
            // 
            // ucLicenseInfoWithFilter1
            // 
            this.ucLicenseInfoWithFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucLicenseInfoWithFilter1.Location = new System.Drawing.Point(-2, 128);
            this.ucLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ucLicenseInfoWithFilter1.Name = "ucLicenseInfoWithFilter1";
            this.ucLicenseInfoWithFilter1.Size = new System.Drawing.Size(1584, 603);
            this.ucLicenseInfoWithFilter1.TabIndex = 0;
            this.ucLicenseInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ucLicenseInfoWithFilter1_OnPersonSelected);
            this.ucLicenseInfoWithFilter1.Load += new System.EventHandler(this.ucLicenseInfoWithFilter1_Load);
            // 
            // frmAddInternationlLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1581, 1050);
            this.Controls.Add(this.linkLicensesHistory);
            this.Controls.Add(this.linkLicenseInfo);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.buIssue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucInternationalApplicationInfo1);
            this.Controls.Add(this.ucLicenseInfoWithFilter1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddInternationlLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Internationl License";
            this.Load += new System.EventHandler(this.frmAddInternationlLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ucLicenseInfoWithFilter ucLicenseInfoWithFilter1;
        private UserControls.ucInternationalApplicationInfo ucInternationalApplicationInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buIssue;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.LinkLabel linkLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLicensesHistory;
    }
}