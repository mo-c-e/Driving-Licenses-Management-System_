namespace DVLD_WindowsForms.Licenses.Detained_Licenses
{
    partial class frmDetainedLicensesList
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
            this.buClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.laRecordCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cMMangepeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMShowAppDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.CMShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.CMShowLicensesHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.buDetainLicense = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buReleaseLicense = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cMMangepeople.SuspendLayout();
            this.SuspendLayout();
            // 
            // buClose
            // 
            this.buClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(1148, 564);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 59;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Detain_512_2;
            this.pictureBox1.Location = new System.Drawing.Point(524, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // laRecordCount
            // 
            this.laRecordCount.AutoSize = true;
            this.laRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laRecordCount.Location = new System.Drawing.Point(109, 574);
            this.laRecordCount.Name = "laRecordCount";
            this.laRecordCount.Size = new System.Drawing.Size(41, 16);
            this.laRecordCount.TabIndex = 57;
            this.laRecordCount.Text = "N / A";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.cMMangepeople;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(11, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1239, 233);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // cMMangepeople
            // 
            this.cMMangepeople.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cMMangepeople.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMMangepeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMShowAppDetails,
            this.CMShowLicense,
            this.CMShowLicensesHistory,
            this.toolStripMenuItem2});
            this.cMMangepeople.Name = "contextMenuStrip1";
            this.cMMangepeople.Size = new System.Drawing.Size(259, 108);
            // 
            // CMShowAppDetails
            // 
            this.CMShowAppDetails.Image = global::DVLD_WindowsForms.Properties.Resources.PersonDetails_32;
            this.CMShowAppDetails.Name = "CMShowAppDetails";
            this.CMShowAppDetails.Size = new System.Drawing.Size(258, 26);
            this.CMShowAppDetails.Text = "Show Person Details";
            this.CMShowAppDetails.Click += new System.EventHandler(this.CMShowAppDetails_Click);
            // 
            // CMShowLicense
            // 
            this.CMShowLicense.Image = global::DVLD_WindowsForms.Properties.Resources.License_View_32___Copy;
            this.CMShowLicense.Name = "CMShowLicense";
            this.CMShowLicense.Size = new System.Drawing.Size(258, 26);
            this.CMShowLicense.Text = "Show License Details";
            this.CMShowLicense.Click += new System.EventHandler(this.CMShowLicense_Click);
            // 
            // CMShowLicensesHistory
            // 
            this.CMShowLicensesHistory.Image = global::DVLD_WindowsForms.Properties.Resources.PersonLicenseHistory_32;
            this.CMShowLicensesHistory.Name = "CMShowLicensesHistory";
            this.CMShowLicensesHistory.Size = new System.Drawing.Size(258, 26);
            this.CMShowLicensesHistory.Text = "Show Person License History";
            this.CMShowLicensesHistory.Click += new System.EventHandler(this.CMShowLicensesHistory_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::DVLD_WindowsForms.Properties.Resources.Release_Detained_License_32_2;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(258, 26);
            this.toolStripMenuItem2.Text = "Release Detained License";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(491, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 29);
            this.label1.TabIndex = 50;
            this.label1.Text = "List Detained Licenses";
            // 
            // buDetainLicense
            // 
            this.buDetainLicense.BackColor = System.Drawing.Color.Transparent;
            this.buDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buDetainLicense.Image = global::DVLD_WindowsForms.Properties.Resources.Detain_64_2;
            this.buDetainLicense.Location = new System.Drawing.Point(1175, 241);
            this.buDetainLicense.Name = "buDetainLicense";
            this.buDetainLicense.Size = new System.Drawing.Size(75, 69);
            this.buDetainLicense.TabIndex = 52;
            this.buDetainLicense.UseVisualStyleBackColor = false;
            this.buDetainLicense.Click += new System.EventHandler(this.buDetainLicense_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(222, 266);
            this.tbFilter.Multiline = true;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(121, 30);
            this.tbFilter.TabIndex = 55;
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
            "Detain ID",
            "Is Released ",
            "National No",
            "Full Name",
            "Release Application ID"});
            this.cbFilter.Location = new System.Drawing.Point(94, 268);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 26);
            this.cbFilter.TabIndex = 54;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Filter by :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "# Records ";
            // 
            // buReleaseLicense
            // 
            this.buReleaseLicense.BackColor = System.Drawing.Color.Transparent;
            this.buReleaseLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buReleaseLicense.Image = global::DVLD_WindowsForms.Properties.Resources.Release_Detained_License_64_2;
            this.buReleaseLicense.Location = new System.Drawing.Point(1094, 241);
            this.buReleaseLicense.Name = "buReleaseLicense";
            this.buReleaseLicense.Size = new System.Drawing.Size(75, 69);
            this.buReleaseLicense.TabIndex = 60;
            this.buReleaseLicense.UseVisualStyleBackColor = false;
            this.buReleaseLicense.Click += new System.EventHandler(this.buReleaseLicense_Click);
            // 
            // frmDetainedLicensesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1258, 607);
            this.Controls.Add(this.buReleaseLicense);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.laRecordCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buDetainLicense);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetainedLicensesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detained Licenses";
            this.Load += new System.EventHandler(this.frmDetainedLicensesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cMMangepeople.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label laRecordCount;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cMMangepeople;
        private System.Windows.Forms.ToolStripMenuItem CMShowAppDetails;
        private System.Windows.Forms.ToolStripMenuItem CMShowLicense;
        private System.Windows.Forms.ToolStripMenuItem CMShowLicensesHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buDetainLicense;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buReleaseLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}