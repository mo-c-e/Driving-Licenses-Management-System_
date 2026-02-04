namespace DVLD_WindowsForms.Licenses
{
    partial class frmDrivingLicenseAppInfo
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
            this.ucDrivingLicenseAppInfo1 = new DVLD_WindowsForms.Local_Driving_License_Application.ucDrivingLicenseAppInfo();
            this.SuspendLayout();
            // 
            // ucDrivingLicenseAppInfo1
            // 
            this.ucDrivingLicenseAppInfo1.Location = new System.Drawing.Point(12, 12);
            this.ucDrivingLicenseAppInfo1.Name = "ucDrivingLicenseAppInfo1";
            this.ucDrivingLicenseAppInfo1.Size = new System.Drawing.Size(828, 338);
            this.ucDrivingLicenseAppInfo1.TabIndex = 0;
            // 
            // frmDrivingLicenseAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(852, 399);
            this.Controls.Add(this.ucDrivingLicenseAppInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDrivingLicenseAppInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving Application Info";
            this.Load += new System.EventHandler(this.frmDrivingLicenseAppInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Local_Driving_License_Application.ucDrivingLicenseAppInfo ucDrivingLicenseAppInfo1;
    }
}