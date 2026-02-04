namespace DVLD_WindowsForms.DrivingLicense
{
    partial class frmIssueDrivingLicense
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
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.buIssue = new System.Windows.Forms.Button();
            this.buClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucDrivingLicenseAppInfo1 = new DVLD_WindowsForms.Local_Driving_License_Application.ucDrivingLicenseAppInfo();
            this.ucDrivingLicenseAppInfo2 = new DVLD_WindowsForms.Local_Driving_License_Application.ucDrivingLicenseAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "Notes :";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(111, 367);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(714, 92);
            this.tbNotes.TabIndex = 48;
            // 
            // buIssue
            // 
            this.buIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buIssue.Image = global::DVLD_WindowsForms.Properties.Resources.License_Type_32;
            this.buIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buIssue.Location = new System.Drawing.Point(724, 465);
            this.buIssue.Name = "buIssue";
            this.buIssue.Size = new System.Drawing.Size(102, 36);
            this.buIssue.TabIndex = 52;
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
            this.buClose.Location = new System.Drawing.Point(616, 465);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 51;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Notes_32;
            this.pictureBox1.Location = new System.Drawing.Point(84, 369);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // ucDrivingLicenseAppInfo1
            // 
            this.ucDrivingLicenseAppInfo1.Location = new System.Drawing.Point(2, 12);
            this.ucDrivingLicenseAppInfo1.Name = "ucDrivingLicenseAppInfo1";
            this.ucDrivingLicenseAppInfo1.Size = new System.Drawing.Size(828, 338);
            this.ucDrivingLicenseAppInfo1.TabIndex = 0;
            this.ucDrivingLicenseAppInfo1.Load += new System.EventHandler(this.ucDrivingLicenseAppInfo1_Load);
            // 
            // ucDrivingLicenseAppInfo2
            // 
            this.ucDrivingLicenseAppInfo2.Location = new System.Drawing.Point(2, 12);
            this.ucDrivingLicenseAppInfo2.Name = "ucDrivingLicenseAppInfo2";
            this.ucDrivingLicenseAppInfo2.Size = new System.Drawing.Size(828, 338);
            this.ucDrivingLicenseAppInfo2.TabIndex = 53;
            // 
            // frmIssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 509);
            this.Controls.Add(this.ucDrivingLicenseAppInfo2);
            this.Controls.Add(this.buIssue);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIssueDrivingLicense";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Local_Driving_License_Application.ucDrivingLicenseAppInfo ucDrivingLicenseAppInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Button buIssue;
        private System.Windows.Forms.Button buClose;
        private Local_Driving_License_Application.ucDrivingLicenseAppInfo ucDrivingLicenseAppInfo2;
    }
}