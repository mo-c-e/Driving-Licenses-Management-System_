using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Application_Types
{
    public partial class frmUpdateAppType : Form
    {
        int _AppTypeID;
        clsAppTypesBL app;
        public frmUpdateAppType(int apptypeID)
        {
            InitializeComponent();
            _AppTypeID = apptypeID;
        }

        private void laID_Click(object sender, EventArgs e)
        {

        }

        private void tbfees_TextChanged(object sender, EventArgs e)
        {

        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateAppType_Load(object sender, EventArgs e)
        {
             app = clsAppTypesBL.Find(_AppTypeID);
            if(app!=null)
            {
                laID.Text = app.ApplicationTypeID.ToString();
                tbAppTitle.Text = app.ApplicationTypeTile;
                tbfees.Text= app.ApplicationFees.ToString();
            }
            else
            {
                MessageBox.Show("Unable To find Application Type","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void buSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Missing Info","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
              app.ApplicationTypeTile=tbAppTitle.Text;
            app.ApplicationFees = Convert.ToInt32(tbfees.Text);
            if(app.UpdateAppType())
            {
                MessageBox.Show("Update Info Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable To Update Info", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbAppTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbAppTitle.Text))
            {
                errorProvider1.SetError(tbAppTitle,"Enter Value");
            }
            else
            {
                errorProvider1.SetError(tbAppTitle,null);
            }
        }

        private void tbfees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbfees.Text))
            {
                errorProvider1.SetError(tbfees, "Enter Amount");
            }
            else
            {
                errorProvider1.SetError(tbfees, null);
            }
        }
    }
}
