namespace DVLD_WindowsForms.UserControls
{
    partial class ucPersonInfo_WithFilter
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
            this.buAddPerson = new System.Windows.Forms.Button();
            this.buFindPerson = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.userControl_People_Info1 = new DVLD_WindowsForms.People.UserControl_People_Info();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buAddPerson);
            this.panel1.Controls.Add(this.buFindPerson);
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.cbFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 70);
            this.panel1.TabIndex = 1;
            // 
            // buAddPerson
            // 
            this.buAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buAddPerson.Image = global::DVLD_WindowsForms.Properties.Resources.AddPerson_32;
            this.buAddPerson.Location = new System.Drawing.Point(547, 22);
            this.buAddPerson.Margin = new System.Windows.Forms.Padding(2);
            this.buAddPerson.Name = "buAddPerson";
            this.buAddPerson.Size = new System.Drawing.Size(49, 31);
            this.buAddPerson.TabIndex = 4;
            this.buAddPerson.UseVisualStyleBackColor = true;
            this.buAddPerson.Click += new System.EventHandler(this.buAddPerson_Click);
            // 
            // buFindPerson
            // 
            this.buFindPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buFindPerson.Image = global::DVLD_WindowsForms.Properties.Resources.SearchPerson;
            this.buFindPerson.Location = new System.Drawing.Point(493, 22);
            this.buFindPerson.Margin = new System.Windows.Forms.Padding(2);
            this.buFindPerson.Name = "buFindPerson";
            this.buFindPerson.Size = new System.Drawing.Size(49, 31);
            this.buFindPerson.TabIndex = 3;
            this.buFindPerson.UseVisualStyleBackColor = true;
            this.buFindPerson.Click += new System.EventHandler(this.buFindPerson_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(302, 26);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbFilter.Multiline = true;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(179, 21);
            this.tbFilter.TabIndex = 2;
            this.tbFilter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            this.tbFilter.Validating += new System.ComponentModel.CancelEventHandler(this.tbFilter_Validating);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownWidth = 266;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo."});
            this.cbFilter.Location = new System.Drawing.Point(119, 26);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(179, 21);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter by :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // userControl_People_Info1
            // 
            this.userControl_People_Info1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControl_People_Info1.Location = new System.Drawing.Point(24, 110);
            this.userControl_People_Info1.Name = "userControl_People_Info1";
            this.userControl_People_Info1.Size = new System.Drawing.Size(792, 282);
            this.userControl_People_Info1.TabIndex = 0;
            this.userControl_People_Info1.Load += new System.EventHandler(this.userControl_People_Info1_Load);
            // 
            // ucPersonInfo_WithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControl_People_Info1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucPersonInfo_WithFilter";
            this.Size = new System.Drawing.Size(837, 403);
            this.Load += new System.EventHandler(this.ucPersonInfo_WithFilter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private People.UserControl_People_Info userControl_People_Info1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button buFindPerson;
        private System.Windows.Forms.Button buAddPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
