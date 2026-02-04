namespace DVLD_WindowsForms.Licenses
{
    partial class frmRenewLicense
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
            this.buRenew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ucLicenseInfoWithFilter1 = new DVLD_WindowsForms.UserControls.ucLicenseInfoWithFilter();
            this.ucRenewApplicationInfo1 = new DVLD_WindowsForms.UserControls.ucRenewApplicationInfo();
            this.SuspendLayout();
            // 
            // linkLicensesHistory
            // 
            this.linkLicensesHistory.AutoSize = true;
            this.linkLicensesHistory.Enabled = false;
            this.linkLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicensesHistory.Location = new System.Drawing.Point(57, 787);
            this.linkLicensesHistory.Name = "linkLicensesHistory";
            this.linkLicensesHistory.Size = new System.Drawing.Size(160, 18);
            this.linkLicensesHistory.TabIndex = 56;
            this.linkLicensesHistory.TabStop = true;
            this.linkLicensesHistory.Text = "Show Licenses History";
            this.linkLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicensesHistory_LinkClicked);
            // 
            // linkLicenseInfo
            // 
            this.linkLicenseInfo.AutoSize = true;
            this.linkLicenseInfo.Enabled = false;
            this.linkLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicenseInfo.Location = new System.Drawing.Point(234, 787);
            this.linkLicenseInfo.Name = "linkLicenseInfo";
            this.linkLicenseInfo.Size = new System.Drawing.Size(129, 18);
            this.linkLicenseInfo.TabIndex = 55;
            this.linkLicenseInfo.TabStop = true;
            this.linkLicenseInfo.Text = "Show License Info";
            this.linkLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseInfo_LinkClicked);
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(841, 769);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 54;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // buRenew
            // 
            this.buRenew.Enabled = false;
            this.buRenew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buRenew.Image = global::DVLD_WindowsForms.Properties.Resources.Renew_Driving_License_32_21;
            this.buRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buRenew.Location = new System.Drawing.Point(949, 769);
            this.buRenew.Name = "buRenew";
            this.buRenew.Size = new System.Drawing.Size(102, 36);
            this.buRenew.TabIndex = 53;
            this.buRenew.Text = "Renew";
            this.buRenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buRenew.UseVisualStyleBackColor = true;
            this.buRenew.Click += new System.EventHandler(this.buRenew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(345, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 31);
            this.label1.TabIndex = 52;
            this.label1.Text = "Renew License Application";
            // 
            // ucLicenseInfoWithFilter1
            // 
            this.ucLicenseInfoWithFilter1.Location = new System.Drawing.Point(4, 75);
            this.ucLicenseInfoWithFilter1.Name = "ucLicenseInfoWithFilter1";
            this.ucLicenseInfoWithFilter1.Size = new System.Drawing.Size(1047, 392);
            this.ucLicenseInfoWithFilter1.TabIndex = 50;
            this.ucLicenseInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ucLicenseInfoWithFilter1_OnPersonSelected);
            this.ucLicenseInfoWithFilter1.OnPersonSel += new System.Action<bool>(this.ucLicenseInfoWithFilter1_OnPersonSel);
            // 
            // ucRenewApplicationInfo1
            // 
            this.ucRenewApplicationInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucRenewApplicationInfo1.Location = new System.Drawing.Point(7, 464);
            this.ucRenewApplicationInfo1.Name = "ucRenewApplicationInfo1";
            this.ucRenewApplicationInfo1.Notes = "";
            this.ucRenewApplicationInfo1.Size = new System.Drawing.Size(1044, 299);
            this.ucRenewApplicationInfo1.TabIndex = 57;
            // 
            // frmRenewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1054, 814);
            this.Controls.Add(this.ucRenewApplicationInfo1);
            this.Controls.Add(this.linkLicensesHistory);
            this.Controls.Add(this.linkLicenseInfo);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.buRenew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenewLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew License";
            this.Load += new System.EventHandler(this.frmRenewLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLicensesHistory;
        private System.Windows.Forms.LinkLabel linkLicenseInfo;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.Button buRenew;
        private System.Windows.Forms.Label label1;
        private UserControls.ucLicenseInfoWithFilter ucLicenseInfoWithFilter1;
        private UserControls.ucRenewApplicationInfo ucRenewApplicationInfo1;
    }
}