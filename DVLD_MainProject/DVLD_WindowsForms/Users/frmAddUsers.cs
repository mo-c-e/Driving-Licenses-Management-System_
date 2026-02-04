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
    public partial class frmAddUsers : Form
    {
        int _PersonID;
        int _UserID;
        bool _Disable=false;
        enum enMode
        {
            AddNew,Update
        }
        clsUsersBL _User;

        enMode frmMode= enMode.AddNew;
        public frmAddUsers(int PersonID,int UserID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            this._UserID = UserID;
            ucPersonInfo_WithFilter1.LoaducWithFilter_PersonID(PersonID);
           
        }

     
        private void buNext_Click(object sender, EventArgs e)
        {
            if(clsUsersBL.IsUserExists_ForPerson(_PersonID) && frmMode==enMode.AddNew)
            {
                _Disable = false;  
                MessageBox.Show("Person Is Already Connected With User","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                SetLoginInfoDisabled(_Disable);
                return;
            }
            _Disable = true;
            SetLoginInfoDisabled(_Disable);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmAddUsers_Load(object sender, EventArgs e)
        {
           // _User = clsUsersBL.FindbyUserID(this._UserID);
            SetMode();
            if(frmMode==enMode.Update)
            {
                UploadUserInfoToForm();
            }

        }

        private void ucPersonInfo_WithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void SetMode()
        {
            if (_UserID != -1)
            {
                laAdd_Edit.Text = "Update User";
                _User= clsUsersBL.FindbyUserID(_UserID);
                frmMode = enMode.Update;
            }
            else
            {
                laAdd_Edit.Text = "Add New Users";
                _User = new clsUsersBL();
                frmMode = enMode.AddNew;
            }
        }

        private void SetIsActiveCheckBox(bool value)
        {
            if (value)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
        }

        private void UploadUserInfoToForm()
        {
            //label5.Text = ucPersonInfo_WithFilter1.GetPersonID().ToString();
            laUserID.Text = _User.UserID.ToString();
            tbUserName.Text = _User.UserName;
            tbPassword.Text = _User.Password;
            SetIsActiveCheckBox(_User.IsActive);
        }

        private void buSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Missing Information", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!_Disable)
            {
                MessageBox.Show("Person Is Already Connected With User", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.UserName = tbUserName.Text;
            _User.Password = tbPassword.Text;
            _User.IsActive= cbIsActive.Checked;
            if (_PersonID != -1)
                _User.PersonID = ucPersonInfo_WithFilter1.GetPersonID();
            else
                _User.PersonID = -1;

            if (_User.Save())
            {
                MessageBox.Show("Saved Info Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                laUserID.Text = _User.UserID.ToString();
                _UserID = _User.UserID;
                SetMode();
            }
            else
            {
                MessageBox.Show("Unable To Save Info", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ucPersonInfo_WithFilter1_OnPersonSelected(int obj)
        {
          
                _PersonID = obj;
                //label5.Text=obj.ToString();
            
        }

        private void SetLoginInfoDisabled(bool Disable)
        {
            tbUserName.Enabled = Disable;
            tbPassword.Enabled = Disable;
            tbConfirm_Password.Enabled = Disable;
            cbIsActive.Enabled = Disable;
           // _IsDisable = true;
        }

        private void tbConfirm_Password_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbConfirm_Password.Text))
            {
                errorProvider1.SetError(tbConfirm_Password,"Enter Passsword");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbConfirm_Password, null);
                e.Cancel = false;
            }
            if (tbConfirm_Password.Text != tbPassword.Text)
            {
                errorProvider1.SetError(tbConfirm_Password, "Un Matched Password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbConfirm_Password, null);
                e.Cancel = false;
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Enter Passsword");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbPassword,null);
                e.Cancel = false;
            }
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                errorProvider1.SetError(tbUserName, "Enter UserName");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbUserName, null);
                e.Cancel = false;
            }
            if (clsUsersBL.IsUserExists(tbUserName.Text) && tbUserName.Text != _User.UserName)
            {
                errorProvider1.SetError(tbUserName,"UserName Is Already In Use");
                e.Cancel=true;
            }
            else
            {
                errorProvider1.SetError(tbUserName, null);
                e.Cancel = false;
            }
        }
    }
}
