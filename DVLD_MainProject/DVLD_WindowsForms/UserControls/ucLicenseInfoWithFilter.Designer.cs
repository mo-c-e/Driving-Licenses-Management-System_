namespace DVLD_WindowsForms.UserControls
{
    partial class ucLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buFindLicenseID = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucLicenseInfo1 = new DVLD_WindowsForms.UserControls.ucLicenseInfo();
            this.ucLicenseInfo2 = new DVLD_WindowsForms.UserControls.ucLicenseInfo();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buFindLicenseID);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 71);
            this.panel1.TabIndex = 1;
            // 
            // buFindLicenseID
            // 
            this.buFindLicenseID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buFindLicenseID.Image = global::DVLD_WindowsForms.Properties.Resources.License_View_32___Copy;
            this.buFindLicenseID.Location = new System.Drawing.Point(718, 5);
            this.buFindLicenseID.Name = "buFindLicenseID";
            this.buFindLicenseID.Size = new System.Drawing.Size(67, 58);
            this.buFindLicenseID.TabIndex = 2;
            this.buFindLicenseID.UseVisualStyleBackColor = true;
            this.buFindLicenseID.Click += new System.EventHandler(this.buFindLicenseID_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(160, 19);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(375, 30);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LicenseID :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucLicenseInfo1
            // 
            this.ucLicenseInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLicenseInfo1.Location = new System.Drawing.Point(6, 87);
            this.ucLicenseInfo1.Name = "ucLicenseInfo1";
            this.ucLicenseInfo1.Size = new System.Drawing.Size(1044, 299);
            this.ucLicenseInfo1.TabIndex = 0;
            // 
            // ucLicenseInfo2
            // 
            this.ucLicenseInfo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLicenseInfo2.Location = new System.Drawing.Point(3, 87);
            this.ucLicenseInfo2.Name = "ucLicenseInfo2";
            this.ucLicenseInfo2.Size = new System.Drawing.Size(1044, 299);
            this.ucLicenseInfo2.TabIndex = 2;
            // 
            // ucLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ucLicenseInfo2);
            this.Controls.Add(this.panel1);
            this.Name = "ucLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(1056, 392);
            this.Load += new System.EventHandler(this.ucLicenseInfoWithFilter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucLicenseInfo ucLicenseInfo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buFindLicenseID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ucLicenseInfo ucLicenseInfo2;
    }
}
