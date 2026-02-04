namespace DVLD_WindowsForms.UserControls
{
    partial class ucUser_Info
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.laUserID = new System.Windows.Forms.Label();
            this.laUserName = new System.Windows.Forms.Label();
            this.lable2 = new System.Windows.Forms.Label();
            this.laIsActive = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userControl_People_Info1 = new DVLD_WindowsForms.People.UserControl_People_Info();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.laIsActive);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.laUserName);
            this.panel1.Controls.Add(this.lable2);
            this.panel1.Controls.Add(this.laUserID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 78);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "User ID : ";
            // 
            // laUserID
            // 
            this.laUserID.AutoSize = true;
            this.laUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laUserID.Location = new System.Drawing.Point(222, 29);
            this.laUserID.Name = "laUserID";
            this.laUserID.Size = new System.Drawing.Size(35, 18);
            this.laUserID.TabIndex = 3;
            this.laUserID.Text = "N/A";
            // 
            // laUserName
            // 
            this.laUserName.AutoSize = true;
            this.laUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laUserName.Location = new System.Drawing.Point(432, 29);
            this.laUserName.Name = "laUserName";
            this.laUserName.Size = new System.Drawing.Size(35, 18);
            this.laUserName.TabIndex = 5;
            this.laUserName.Text = "N/A";
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable2.Location = new System.Drawing.Point(323, 29);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(103, 18);
            this.lable2.TabIndex = 4;
            this.lable2.Text = "UserName : ";
            // 
            // laIsActive
            // 
            this.laIsActive.AutoSize = true;
            this.laIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laIsActive.Location = new System.Drawing.Point(643, 29);
            this.laIsActive.Name = "laIsActive";
            this.laIsActive.Size = new System.Drawing.Size(35, 18);
            this.laIsActive.TabIndex = 7;
            this.laIsActive.Text = "N/A";
            this.laIsActive.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(551, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Is Active : ";
            // 
            // userControl_People_Info1
            // 
            this.userControl_People_Info1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControl_People_Info1.Location = new System.Drawing.Point(21, 22);
            this.userControl_People_Info1.Name = "userControl_People_Info1";
            this.userControl_People_Info1.Size = new System.Drawing.Size(792, 282);
            this.userControl_People_Info1.TabIndex = 0;
            // 
            // ucUser_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userControl_People_Info1);
            this.Name = "ucUser_Info";
            this.Size = new System.Drawing.Size(834, 438);
            this.Load += new System.EventHandler(this.ucUser_Info_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.UserControl_People_Info userControl_People_Info1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label laUserID;
        private System.Windows.Forms.Label laIsActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label laUserName;
        private System.Windows.Forms.Label lable2;
    }
}
