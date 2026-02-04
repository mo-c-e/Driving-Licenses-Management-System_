namespace DVLD_WindowsForms.Licenses.Detained_Licenses
{
    partial class frmReleaseDetainedLicense
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
            this.laUser = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.buClose = new System.Windows.Forms.Button();
            this.buRelease = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.laLicenseID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.laDetainDate = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.laDetainID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.laApplicationID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.laFineFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.laTotalFees = new System.Windows.Forms.Label();
            this.laApplicationFees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.ucLicenseInfoWithFilter1 = new DVLD_WindowsForms.UserControls.ucLicenseInfoWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // laUser
            // 
            this.laUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laUser.Location = new System.Drawing.Point(828, 64);
            this.laUser.Name = "laUser";
            this.laUser.Size = new System.Drawing.Size(156, 18);
            this.laUser.TabIndex = 188;
            this.laUser.Text = "N/A";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_WindowsForms.Properties.Resources.User_32__2;
            this.pictureBox6.Location = new System.Drawing.Point(774, 60);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 27);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 187;
            this.pictureBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(601, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 18);
            this.label9.TabIndex = 186;
            this.label9.Text = "CreatedBy :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(601, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 184;
            this.label2.Text = "License ID :";
            // 
            // linkLicenseInfo
            // 
            this.linkLicenseInfo.AutoSize = true;
            this.linkLicenseInfo.Enabled = false;
            this.linkLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicenseInfo.Location = new System.Drawing.Point(204, 667);
            this.linkLicenseInfo.Name = "linkLicenseInfo";
            this.linkLicenseInfo.Size = new System.Drawing.Size(129, 18);
            this.linkLicenseInfo.TabIndex = 79;
            this.linkLicenseInfo.TabStop = true;
            this.linkLicenseInfo.Text = "Show License Info";
            this.linkLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseInfo_LinkClicked);
            // 
            // buClose
            // 
            this.buClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(821, 659);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 78;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // buRelease
            // 
            this.buRelease.Enabled = false;
            this.buRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buRelease.Image = global::DVLD_WindowsForms.Properties.Resources.Release_Detained_License_32_2;
            this.buRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buRelease.Location = new System.Drawing.Point(936, 659);
            this.buRelease.Name = "buRelease";
            this.buRelease.Size = new System.Drawing.Size(113, 36);
            this.buRelease.TabIndex = 77;
            this.buRelease.Text = "Release";
            this.buRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buRelease.UseVisualStyleBackColor = true;
            this.buRelease.Click += new System.EventHandler(this.buRelease_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(346, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 31);
            this.label1.TabIndex = 76;
            this.label1.Text = "Release Detained License";
            // 
            // laLicenseID
            // 
            this.laLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laLicenseID.Location = new System.Drawing.Point(828, 25);
            this.laLicenseID.Name = "laLicenseID";
            this.laLicenseID.Size = new System.Drawing.Size(150, 18);
            this.laLicenseID.TabIndex = 185;
            this.laLicenseID.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.LocalDriving_License;
            this.pictureBox1.Location = new System.Drawing.Point(774, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 183;
            this.pictureBox1.TabStop = false;
            // 
            // laDetainDate
            // 
            this.laDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDetainDate.Location = new System.Drawing.Point(286, 64);
            this.laDetainDate.Name = "laDetainDate";
            this.laDetainDate.Size = new System.Drawing.Size(156, 18);
            this.laDetainDate.TabIndex = 182;
            this.laDetainDate.Text = "N/A";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_WindowsForms.Properties.Resources.Calendar_32;
            this.pictureBox4.Location = new System.Drawing.Point(238, 60);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 181;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 18);
            this.label8.TabIndex = 180;
            this.label8.Text = "Detain Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 175;
            this.label5.Text = "Detain ID : ";
            // 
            // laDetainID
            // 
            this.laDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDetainID.Location = new System.Drawing.Point(286, 25);
            this.laDetainID.Name = "laDetainID";
            this.laDetainID.Size = new System.Drawing.Size(103, 18);
            this.laDetainID.TabIndex = 176;
            this.laDetainID.Text = "[???]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(75, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 172;
            this.label7.Text = "Total Fees :";
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::DVLD_WindowsForms.Properties.Resources.money_32;
            this.pictureBox13.Location = new System.Drawing.Point(238, 148);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(31, 27);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 173;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_WindowsForms.Properties.Resources.Number_32_2;
            this.pictureBox8.Location = new System.Drawing.Point(238, 21);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 27);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 171;
            this.pictureBox8.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.laApplicationID);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.laFineFees);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.laTotalFees);
            this.panel1.Controls.Add(this.laApplicationFees);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.laUser);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.laLicenseID);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.laDetainDate);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.laDetainID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pictureBox13);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Location = new System.Drawing.Point(5, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 192);
            this.panel1.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(601, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 18);
            this.label4.TabIndex = 198;
            this.label4.Text = "Application ID : ";
            // 
            // laApplicationID
            // 
            this.laApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laApplicationID.Location = new System.Drawing.Point(828, 152);
            this.laApplicationID.Name = "laApplicationID";
            this.laApplicationID.Size = new System.Drawing.Size(103, 18);
            this.laApplicationID.TabIndex = 199;
            this.laApplicationID.Text = "[???]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_WindowsForms.Properties.Resources.Number_32_2;
            this.pictureBox5.Location = new System.Drawing.Point(774, 148);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 27);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 197;
            this.pictureBox5.TabStop = false;
            // 
            // laFineFees
            // 
            this.laFineFees.AutoSize = true;
            this.laFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laFineFees.Location = new System.Drawing.Point(828, 112);
            this.laFineFees.Name = "laFineFees";
            this.laFineFees.Size = new System.Drawing.Size(35, 18);
            this.laFineFees.TabIndex = 196;
            this.laFineFees.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(601, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 194;
            this.label6.Text = "Fine Fees :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_WindowsForms.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(774, 108);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 195;
            this.pictureBox3.TabStop = false;
            // 
            // laTotalFees
            // 
            this.laTotalFees.AutoSize = true;
            this.laTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTotalFees.Location = new System.Drawing.Point(286, 152);
            this.laTotalFees.Name = "laTotalFees";
            this.laTotalFees.Size = new System.Drawing.Size(35, 18);
            this.laTotalFees.TabIndex = 193;
            this.laTotalFees.Text = "N/A";
            // 
            // laApplicationFees
            // 
            this.laApplicationFees.AutoSize = true;
            this.laApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laApplicationFees.Location = new System.Drawing.Point(286, 112);
            this.laApplicationFees.Name = "laApplicationFees";
            this.laApplicationFees.Size = new System.Drawing.Size(35, 18);
            this.laApplicationFees.TabIndex = 192;
            this.laApplicationFees.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 190;
            this.label3.Text = "Application Fees :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_WindowsForms.Properties.Resources.money_32;
            this.pictureBox2.Location = new System.Drawing.Point(238, 108);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 191;
            this.pictureBox2.TabStop = false;
            // 
            // linkLicensesHistory
            // 
            this.linkLicensesHistory.AutoSize = true;
            this.linkLicensesHistory.Enabled = false;
            this.linkLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLicensesHistory.Location = new System.Drawing.Point(27, 667);
            this.linkLicensesHistory.Name = "linkLicensesHistory";
            this.linkLicensesHistory.Size = new System.Drawing.Size(160, 18);
            this.linkLicensesHistory.TabIndex = 80;
            this.linkLicensesHistory.TabStop = true;
            this.linkLicensesHistory.Text = "Show Licenses History";
            this.linkLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicensesHistory_LinkClicked);
            // 
            // ucLicenseInfoWithFilter1
            // 
            this.ucLicenseInfoWithFilter1.Location = new System.Drawing.Point(4, 59);
            this.ucLicenseInfoWithFilter1.Name = "ucLicenseInfoWithFilter1";
            this.ucLicenseInfoWithFilter1.Size = new System.Drawing.Size(1047, 392);
            this.ucLicenseInfoWithFilter1.TabIndex = 75;
            this.ucLicenseInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ucLicenseInfoWithFilter1_OnPersonSelected);
            this.ucLicenseInfoWithFilter1.OnPersonSel += new System.Action<bool>(this.ucLicenseInfoWithFilter1_OnPersonSel);
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1054, 710);
            this.Controls.Add(this.ucLicenseInfoWithFilter1);
            this.Controls.Add(this.linkLicenseInfo);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.buRelease);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLicensesHistory);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release Detained License";
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ucLicenseInfoWithFilter ucLicenseInfoWithFilter1;
        private System.Windows.Forms.Label laUser;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLicenseInfo;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.Button buRelease;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label laLicenseID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label laDetainDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label laDetainID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLicensesHistory;
        private System.Windows.Forms.Label laApplicationFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label laApplicationID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label laFineFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label laTotalFees;
    }
}