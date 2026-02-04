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

namespace DVLD_WindowsForms.Users
{
    public partial class frm_ChangePassword : Form
    {
        int _UserID;
        clsUsersBL _User;

        public frm_ChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ChangePassword_Load(object sender, EventArgs e)
        {
            ucUser_Info1.LoadUserInfo(_UserID);
            _User = clsUsersBL.FindbyUserID(_UserID);
        }

        private void tbCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_User.Password != clsUtil.ComputeHash(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Wrong Password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword,null);
                e.Cancel=false;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if ( tbNewPassword.Text != tbConfirmPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "UnMatched Password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
                e.Cancel = false;
            }
        }

        private void tbNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _User.Password = clsUtil.ComputeHash(tbNewPassword.Text);
                if (_User.Save(true))
                {
                    MessageBox.Show("Password Changed Successfully, ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbConfirmPassword.Text = null;
                    tbNewPassword.Text = null;
                    tbCurrentPassword.Text = null;
                    MessageBox.Show("The application will now restart.","Restarting",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Complete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
