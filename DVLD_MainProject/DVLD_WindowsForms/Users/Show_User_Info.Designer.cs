namespace DVLD_WindowsForms.Users
{
    partial class Show_User_Info
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
            this.ucUser_Info1 = new DVLD_WindowsForms.UserControls.ucUser_Info();
            this.SuspendLayout();
            // 
            // ucUser_Info1
            // 
            this.ucUser_Info1.Location = new System.Drawing.Point(29, 12);
            this.ucUser_Info1.Name = "ucUser_Info1";
            this.ucUser_Info1.Size = new System.Drawing.Size(834, 438);
            this.ucUser_Info1.TabIndex = 0;
            this.ucUser_Info1.Load += new System.EventHandler(this.ucUser_Info1_Load);
            // 
            // Show_User_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 475);
            this.Controls.Add(this.ucUser_Info1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Show_User_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.Load += new System.EventHandler(this.Show_User_Info_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucUser_Info ucUser_Info1;
    }
}