namespace DVLD_WindowsForms.Local_Driving_License_Application
{
    partial class frmAddLocalDrivingLicenseApplication
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
            this.laAdd_Edit = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buNext = new System.Windows.Forms.Button();
            this.ucPersonInfo_WithFilter1 = new DVLD_WindowsForms.UserControls.ucPersonInfo_WithFilter();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.laAppFees = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.laAppDate = new System.Windows.Forms.Label();
            this.laUser = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.laDLAppID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buSave = new System.Windows.Forms.Button();
            this.buClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // laAdd_Edit
            // 
            this.laAdd_Edit.AutoSize = true;
            this.laAdd_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laAdd_Edit.ForeColor = System.Drawing.Color.IndianRed;
            this.laAdd_Edit.Location = new System.Drawing.Point(175, 40);
            this.laAdd_Edit.Name = "laAdd_Edit";
            this.laAdd_Edit.Size = new System.Drawing.Size(548, 33);
            this.laAdd_Edit.TabIndex = 42;
            this.laAdd_Edit.Text = "New Local Driving License Application";
            this.laAdd_Edit.Click += new System.EventHandler(this.laAdd_Edit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(19, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(853, 500);
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buNext);
            this.tabPage1.Controls.Add(this.ucPersonInfo_WithFilter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(845, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buNext
            // 
            this.buNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buNext.Image = global::DVLD_WindowsForms.Properties.Resources.Next_32;
            this.buNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buNext.Location = new System.Drawing.Point(743, 435);
            this.buNext.Name = "buNext";
            this.buNext.Size = new System.Drawing.Size(96, 33);
            this.buNext.TabIndex = 1;
            this.buNext.Text = "Next";
            this.buNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buNext.UseVisualStyleBackColor = true;
            this.buNext.Click += new System.EventHandler(this.buNext_Click);
            // 
            // ucPersonInfo_WithFilter1
            // 
            this.ucPersonInfo_WithFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucPersonInfo_WithFilter1.Location = new System.Drawing.Point(5, 29);
            this.ucPersonInfo_WithFilter1.Margin = new System.Windows.Forms.Padding(2);
            this.ucPersonInfo_WithFilter1.Name = "ucPersonInfo_WithFilter1";
            this.ucPersonInfo_WithFilter1.Size = new System.Drawing.Size(835, 401);
            this.ucPersonInfo_WithFilter1.TabIndex = 0;
            this.ucPersonInfo_WithFilter1.OnPersonSelected += new System.Action<int>(this.ucPersonInfo_WithFilter1_OnPersonSelected);
            this.ucPersonInfo_WithFilter1.Load += new System.EventHandler(this.ucPersonInfo_WithFilter1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.laAppFees);
            this.tabPage2.Controls.Add(this.cbLicenseClasses);
            this.tabPage2.Controls.Add(this.laAppDate);
            this.tabPage2.Controls.Add(this.laUser);
            this.tabPage2.Controls.Add(this.pictureBox5);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.laDLAppID);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(845, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // laAppFees
            // 
            this.laAppFees.AutoSize = true;
            this.laAppFees.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laAppFees.Location = new System.Drawing.Point(317, 157);
            this.laAppFees.Name = "laAppFees";
            this.laAppFees.Size = new System.Drawing.Size(48, 17);
            this.laAppFees.TabIndex = 52;
            this.laAppFees.Text = "$$$$$";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(320, 123);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(217, 23);
            this.cbLicenseClasses.TabIndex = 51;
            // 
            // laAppDate
            // 
            this.laAppDate.AutoSize = true;
            this.laAppDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laAppDate.Location = new System.Drawing.Point(318, 89);
            this.laAppDate.Name = "laAppDate";
            this.laAppDate.Size = new System.Drawing.Size(80, 17);
            this.laAppDate.TabIndex = 50;
            this.laAppDate.Text = "00/00/0000";
            // 
            // laUser
            // 
            this.laUser.AutoSize = true;
            this.laUser.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laUser.Location = new System.Drawing.Point(318, 195);
            this.laUser.Name = "laUser";
            this.laUser.Size = new System.Drawing.Size(47, 17);
            this.laUser.TabIndex = 49;
            this.laUser.Text = "admin";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::DVLD_WindowsForms.Properties.Resources.User_32__2;
            this.pictureBox5.Location = new System.Drawing.Point(254, 193);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 48;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 47;
            this.label5.Text = "Created By : ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::DVLD_WindowsForms.Properties.Resources.money_32;
            this.pictureBox4.Location = new System.Drawing.Point(254, 155);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 44;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 18);
            this.label4.TabIndex = 43;
            this.label4.Text = "Application Fees : ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::DVLD_WindowsForms.Properties.Resources.Number_32_2;
            this.pictureBox3.Location = new System.Drawing.Point(254, 51);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 42;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::DVLD_WindowsForms.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox2.Location = new System.Drawing.Point(254, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Calendar_32;
            this.pictureBox1.Location = new System.Drawing.Point(254, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // laDLAppID
            // 
            this.laDLAppID.AutoSize = true;
            this.laDLAppID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDLAppID.Location = new System.Drawing.Point(318, 54);
            this.laDLAppID.Name = "laDLAppID";
            this.laDLAppID.Size = new System.Drawing.Size(36, 15);
            this.laDLAppID.TabIndex = 37;
            this.laDLAppID.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "License Class : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Applicatin Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "D.LApplication ID : ";
            // 
            // buSave
            // 
            this.buSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buSave.Image = global::DVLD_WindowsForms.Properties.Resources.Save_32;
            this.buSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buSave.Location = new System.Drawing.Point(770, 619);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(102, 36);
            this.buSave.TabIndex = 45;
            this.buSave.Text = "    Save";
            this.buSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.buSave_Click);
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(662, 619);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 44;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // frmAddLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 667);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.laAdd_Edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.frmAddLocalDrivingLicenseApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laAdd_Edit;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buNext;
        private UserControls.ucPersonInfo_WithFilter ucPersonInfo_WithFilter1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label laDLAppID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label laUser;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label laAppFees;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label laAppDate;
    }
}