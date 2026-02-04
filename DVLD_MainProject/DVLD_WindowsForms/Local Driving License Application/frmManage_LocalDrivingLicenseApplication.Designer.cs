namespace DVLD_WindowsForms.Local_Driving_License_Application
{
    partial class frmManage_LocalDrivingLicenseApplication
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cMMangepeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CMShowAppDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.CMEditApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.CMDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.CMCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.CMScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.msscheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.msscheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.msScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CMIssueFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CMShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.CMShowLicensesHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.laRecordCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buAddLocalLicenseApp = new System.Windows.Forms.Button();
            this.clsLDLA = new System.Windows.Forms.BindingSource(this.components);
            this.buClose = new System.Windows.Forms.Button();
            this.cMMangepeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsLDLA)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 576);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "# Records ";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(223, 268);
            this.tbFilter.Multiline = true;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(121, 30);
            this.tbFilter.TabIndex = 15;
            this.tbFilter.Visible = false;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L App ID",
            "NationalNo",
            "FullName",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(95, 270);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 26);
            this.cbFilter.TabIndex = 14;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter by :";
            // 
            // cMMangepeople
            // 
            this.cMMangepeople.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cMMangepeople.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMMangepeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.CMShowAppDetails,
            this.toolStripSeparator4,
            this.CMEditApp,
            this.toolStripSeparator6,
            this.CMDeleteApp,
            this.toolStripSeparator7,
            this.CMCancelApp,
            this.toolStripSeparator8,
            this.CMScheduleTest,
            this.toolStripSeparator2,
            this.CMIssueFirstTime,
            this.toolStripSeparator3,
            this.CMShowLicense,
            this.toolStripSeparator5,
            this.CMShowLicensesHistory});
            this.cMMangepeople.Name = "contextMenuStrip1";
            this.cMMangepeople.Size = new System.Drawing.Size(283, 282);
            this.cMMangepeople.Opening += new System.ComponentModel.CancelEventHandler(this.cMMangepeople_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // CMShowAppDetails
            // 
            this.CMShowAppDetails.Image = global::DVLD_WindowsForms.Properties.Resources.PersonDetails_32;
            this.CMShowAppDetails.Name = "CMShowAppDetails";
            this.CMShowAppDetails.Size = new System.Drawing.Size(282, 26);
            this.CMShowAppDetails.Text = "Show Application Details";
            this.CMShowAppDetails.Click += new System.EventHandler(this.CMShowAppDetails_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(279, 6);
            // 
            // CMEditApp
            // 
            this.CMEditApp.Image = global::DVLD_WindowsForms.Properties.Resources.edit_32;
            this.CMEditApp.Name = "CMEditApp";
            this.CMEditApp.Size = new System.Drawing.Size(282, 26);
            this.CMEditApp.Text = "Edit Application";
            this.CMEditApp.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(279, 6);
            // 
            // CMDeleteApp
            // 
            this.CMDeleteApp.Image = global::DVLD_WindowsForms.Properties.Resources.Delete_32_2;
            this.CMDeleteApp.Name = "CMDeleteApp";
            this.CMDeleteApp.Size = new System.Drawing.Size(282, 26);
            this.CMDeleteApp.Text = "Delete Application";
            this.CMDeleteApp.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(279, 6);
            // 
            // CMCancelApp
            // 
            this.CMCancelApp.Image = global::DVLD_WindowsForms.Properties.Resources.Delete_32;
            this.CMCancelApp.Name = "CMCancelApp";
            this.CMCancelApp.Size = new System.Drawing.Size(282, 26);
            this.CMCancelApp.Text = "Cancel Application";
            this.CMCancelApp.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(279, 6);
            // 
            // CMScheduleTest
            // 
            this.CMScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msscheduleVisionTest,
            this.msscheduleWrittenTest,
            this.msScheduleStreetTest});
            this.CMScheduleTest.Image = global::DVLD_WindowsForms.Properties.Resources.Schedule_Test_32;
            this.CMScheduleTest.Name = "CMScheduleTest";
            this.CMScheduleTest.Size = new System.Drawing.Size(282, 26);
            this.CMScheduleTest.Text = "Schedule Tests";
            this.CMScheduleTest.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // msscheduleVisionTest
            // 
            this.msscheduleVisionTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msscheduleVisionTest.Image = global::DVLD_WindowsForms.Properties.Resources.Vision_Test_32;
            this.msscheduleVisionTest.Name = "msscheduleVisionTest";
            this.msscheduleVisionTest.Size = new System.Drawing.Size(203, 26);
            this.msscheduleVisionTest.Text = "Schedule Vision Test";
            this.msscheduleVisionTest.Click += new System.EventHandler(this.msscheduleVisionTest_Click);
            // 
            // msscheduleWrittenTest
            // 
            this.msscheduleWrittenTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msscheduleWrittenTest.Image = global::DVLD_WindowsForms.Properties.Resources.Written_Test_32_Sechdule;
            this.msscheduleWrittenTest.Name = "msscheduleWrittenTest";
            this.msscheduleWrittenTest.Size = new System.Drawing.Size(203, 26);
            this.msscheduleWrittenTest.Text = "Schedule Written Test";
            this.msscheduleWrittenTest.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // msScheduleStreetTest
            // 
            this.msScheduleStreetTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msScheduleStreetTest.Image = global::DVLD_WindowsForms.Properties.Resources.Street_Test_32;
            this.msScheduleStreetTest.Name = "msScheduleStreetTest";
            this.msScheduleStreetTest.Size = new System.Drawing.Size(203, 26);
            this.msScheduleStreetTest.Text = "Schedule Street Test";
            this.msScheduleStreetTest.Click += new System.EventHandler(this.msScheduleStreetTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(279, 6);
            // 
            // CMIssueFirstTime
            // 
            this.CMIssueFirstTime.Image = global::DVLD_WindowsForms.Properties.Resources.IssueDrivingLicense_32;
            this.CMIssueFirstTime.Name = "CMIssueFirstTime";
            this.CMIssueFirstTime.Size = new System.Drawing.Size(282, 26);
            this.CMIssueFirstTime.Text = "Issue Driving License(First Time)";
            this.CMIssueFirstTime.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(279, 6);
            // 
            // CMShowLicense
            // 
            this.CMShowLicense.Image = global::DVLD_WindowsForms.Properties.Resources.License_View_32___Copy;
            this.CMShowLicense.Name = "CMShowLicense";
            this.CMShowLicense.Size = new System.Drawing.Size(282, 26);
            this.CMShowLicense.Text = "Show License";
            this.CMShowLicense.Click += new System.EventHandler(this.CMShowLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(279, 6);
            // 
            // CMShowLicensesHistory
            // 
            this.CMShowLicensesHistory.Image = global::DVLD_WindowsForms.Properties.Resources.PersonLicenseHistory_32;
            this.CMShowLicensesHistory.Name = "CMShowLicensesHistory";
            this.CMShowLicensesHistory.Size = new System.Drawing.Size(282, 26);
            this.CMShowLicensesHistory.Text = "Show Person License History";
            this.CMShowLicensesHistory.Click += new System.EventHandler(this.CMShowLicensesHistory_Click);
            // 
            // laRecordCount
            // 
            this.laRecordCount.AutoSize = true;
            this.laRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laRecordCount.Location = new System.Drawing.Point(110, 576);
            this.laRecordCount.Name = "laRecordCount";
            this.laRecordCount.Size = new System.Drawing.Size(41, 16);
            this.laRecordCount.TabIndex = 17;
            this.laRecordCount.Text = "N / A";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.cMMangepeople;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(12, 319);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1239, 233);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(445, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Local Driving License Application";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_WindowsForms.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(696, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(521, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // buAddLocalLicenseApp
            // 
            this.buAddLocalLicenseApp.BackColor = System.Drawing.Color.Transparent;
            this.buAddLocalLicenseApp.Image = global::DVLD_WindowsForms.Properties.Resources.New_Application_64;
            this.buAddLocalLicenseApp.Location = new System.Drawing.Point(1176, 243);
            this.buAddLocalLicenseApp.Name = "buAddLocalLicenseApp";
            this.buAddLocalLicenseApp.Size = new System.Drawing.Size(75, 69);
            this.buAddLocalLicenseApp.TabIndex = 12;
            this.buAddLocalLicenseApp.UseVisualStyleBackColor = false;
            this.buAddLocalLicenseApp.Click += new System.EventHandler(this.buAddLocalLicenseApp_Click);
            // 
            // clsLDLA
            // 
            this.clsLDLA.DataSource = typeof(DVLD_BusinessLayer.clsPeopleBL);
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(1149, 566);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 48;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // frmManage_LocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1258, 607);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.laRecordCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buAddLocalLicenseApp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManage_LocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Application";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplication_Load);
            this.cMMangepeople.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsLDLA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource clsLDLA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buAddLocalLicenseApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem CMScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem CMCancelApp;
        private System.Windows.Forms.ToolStripMenuItem CMDeleteApp;
        private System.Windows.Forms.ToolStripMenuItem CMEditApp;
        private System.Windows.Forms.ToolStripMenuItem CMShowAppDetails;
        private System.Windows.Forms.ContextMenuStrip cMMangepeople;
        private System.Windows.Forms.Label laRecordCount;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem msscheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem msscheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem msScheduleStreetTest;
        private System.Windows.Forms.ToolStripMenuItem CMIssueFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CMShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem CMShowLicensesHistory;
        private System.Windows.Forms.Button buClose;
    }
}