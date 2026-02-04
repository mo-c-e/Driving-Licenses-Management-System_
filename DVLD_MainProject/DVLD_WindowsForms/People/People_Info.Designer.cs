namespace DVLD_WindowsForms.People
{
    partial class People_Info
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
            this.buClose = new System.Windows.Forms.Button();
            this.userControl_People_Info1 = new DVLD_WindowsForms.People.UserControl_People_Info();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(333, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Details";
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLD_WindowsForms.Properties.Resources.Close_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(730, 386);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(96, 36);
            this.buClose.TabIndex = 38;
            this.buClose.Text = "    Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // userControl_People_Info1
            // 
            this.userControl_People_Info1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControl_People_Info1.Location = new System.Drawing.Point(45, 100);
            this.userControl_People_Info1.Name = "userControl_People_Info1";
            this.userControl_People_Info1.Size = new System.Drawing.Size(781, 282);
            this.userControl_People_Info1.TabIndex = 0;
            // 
            // People_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 434);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControl_People_Info1);
            this.Name = "People_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People_Info";
            this.Load += new System.EventHandler(this.People_Info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControl_People_Info userControl_People_Info1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buClose;
    }
}