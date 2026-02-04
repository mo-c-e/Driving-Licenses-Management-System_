namespace DVLD_WindowsForms.Licenses
{
    partial class frmReplacmentLicense
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
            this.linkLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.linkLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.buClose = new System.Windows.Forms.Button();
            this.buIssueReplacment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.ucReplacmentApplicationInfo1 = new DVLD_WindowsForms.UserControls.ucReplacmentApplicationInfo();
            this.ucLicenseInfoWithFilter1 = new DVLD_WindowsForms.UserControls.ucLicenseInfoWithFilter();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLicensesHistory
            // 
            this.linkLicensesHistory.AutoSize = true;
            this.linkLicensesHistory.Enabled = false;
            this.linkLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicensesHistory.Location = new System.Drawing.Point(30, 643);
            this.linkLicensesHistory.Name = "linkLicensesHistory";
            this.linkLicensesHistory.Size = new System.Drawing.Size(160, 18);
            this.linkLicensesHistory.TabIndex = 63;
            this.linkLicensesHistory.TabStop = true;
            this.linkLicensesHistory.Text = "Show Licenses History";
            this.linkLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicensesHistory_LinkClicked);
            // 
            // linkLicenseInfo
            // 
            this.linkLicenseInfo.AutoSize = true;
            this.linkLicenseInfo.Enabled = false;
            this.linkLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicenseInfo.Location = new System.Drawing.Point(207, 643);
            this.linkLicenseInfo.Name = "linkLicenseInfo";
            this.linkLicenseInfo.Size = new System.Drawing.Size(129, 18);
            this.linkLicenseInfo.TabIndex = 62;
            this.linkLicenseInfo.TabStop = true;
            this.linkLicenseInfo.Text = "Show License Info";
            this.linkLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseInfo_LinkClicked);
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(771, 635);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 61;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // buIssueReplacment
            // 
            this.buIssueReplacment.Enabled = false;
            this.buIssueReplacment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buIssueReplacment.Image = global::DVLD_WindowsForms.Properties.Resources.Renew_Driving_License_32_21;
            this.buIssueReplacment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buIssueReplacment.Location = new System.Drawing.Point(879, 635);
            this.buIssueReplacment.Name = "buIssueReplacment";
            this.buIssueReplacment.Size = new System.Drawing.Size(172, 36);
            this.buIssueReplacment.TabIndex = 60;
            this.buIssueReplacment.Text = "Issue Replacment";
            this.buIssueReplacment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buIssueReplacment.UseVisualStyleBackColor = true;
            this.buIssueReplacment.Click += new System.EventHandler(this.buIssueReplacment_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(287, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 31);
            this.label1.TabIndex = 59;
            this.label1.Text = "Replacement For Damaged License\r\n";
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamagedLicense.Location = new System.Drawing.Point(6, 3);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(141, 19);
            this.rbDamagedLicense.TabIndex = 65;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbLostLicense);
            this.panel1.Controls.Add(this.rbDamagedLicense);
            this.panel1.Location = new System.Drawing.Point(830, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 70);
            this.panel1.TabIndex = 66;
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLostLicense.Location = new System.Drawing.Point(6, 40);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(106, 19);
            this.rbLostLicense.TabIndex = 66;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // ucReplacmentApplicationInfo1
            // 
            this.ucReplacmentApplicationInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucReplacmentApplicationInfo1.Location = new System.Drawing.Point(5, 468);
            this.ucReplacmentApplicationInfo1.Name = "ucReplacmentApplicationInfo1";
            this.ucReplacmentApplicationInfo1.Size = new System.Drawing.Size(1046, 151);
            this.ucReplacmentApplicationInfo1.TabIndex = 67;
            // 
            // ucLicenseInfoWithFilter1
            // 
            this.ucLicenseInfoWithFilter1.Location = new System.Drawing.Point(4, 70);
            this.ucLicenseInfoWithFilter1.Name = "ucLicenseInfoWithFilter1";
            this.ucLicenseInfoWithFilter1.Size = new System.Drawing.Size(1047, 392);
            this.ucLicenseInfoWithFilter1.TabIndex = 58;
            this.ucLicenseInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ucLicenseInfoWithFilter1_OnPersonSelected);
            // 
            // frmReplacmentLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1054, 675);
            this.Controls.Add(this.ucReplacmentApplicationInfo1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLicensesHistory);
            this.Controls.Add(this.linkLicenseInfo);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.buIssueReplacment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucLicenseInfoWithFilter1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplacmentLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace Damange or Lost License";
            this.Load += new System.EventHandler(this.frmReplacmentLicense_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLicensesHistory;
        private System.Windows.Forms.LinkLabel linkLicenseInfo;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.Button buIssueReplacment;
        private System.Windows.Forms.Label label1;
        private UserControls.ucLicenseInfoWithFilter ucLicenseInfoWithFilter1;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private UserControls.ucReplacmentApplicationInfo ucReplacmentApplicationInfo1;
    }
}