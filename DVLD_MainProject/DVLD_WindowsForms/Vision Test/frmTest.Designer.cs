namespace DVLD_WindowsForms.Vision_Test
{
    partial class frmTest
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
            this.ucTests1 = new DVLD_WindowsForms.UserControls.ucTests();
            this.buClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucTests1
            // 
            this.ucTests1.LocalDrivingLicense = null;
            this.ucTests1.Location = new System.Drawing.Point(29, 12);
            this.ucTests1.Name = "ucTests1";
            this.ucTests1.PersonID = 0;
            this.ucTests1.PhotoNumber = 1;
            this.ucTests1.Size = new System.Drawing.Size(510, 754);
            this.ucTests1.TabIndex = 0;
          //  this.ucTests1.TestAppointmentID = 0;
            this.ucTests1.TestFees = 0F;
            this.ucTests1.TestType = "Vision Test";
            this.ucTests1.TestTypeID = 1;
         //   this.ucTests1.Load += new System.EventHandler(this.ucTests1_Load_1);
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(233, 781);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(102, 36);
            this.buClose.TabIndex = 49;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 840);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.ucTests1);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucTests ucTests1;
        private System.Windows.Forms.Button buClose;
    }
}