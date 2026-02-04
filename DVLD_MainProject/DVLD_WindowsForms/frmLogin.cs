using DVLD_BusinessLayer;
using DVLD_WindowsForms.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLD_WindowsForms
{
    public partial class frmLogin : Form
    {
        clsUsersBL _User;
        // Change the keypath for deploying
        string keypath = @"HKEY_CURRENT_USER\Software\DVLD_";
        string value1_Name = "UserName";
        string value2_Name = "Password";
        List<string> LoginInfo = new List<string>();
        public frmLogin()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Enter UserName/Password","missing info",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            _User = clsUsersBL.FindbyUserName_Password(tbUserName.Text,clsUtil.ComputeHash(tbPassword.Text));

            if (IsCorrect())
            {
             if (_User.IsActive)
                {
                    SaveUserName_Passsowrd();
                Main main = new Main(_User.UserID);
                main.Show();
                }
             else
                {
                    MessageBox.Show("InActive UserName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Invalid Password/UserName","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if(IsUserName_PassowrdExists())
            {
                tbUserName.Text = LoginInfo[0];
                tbPassword.Text = LoginInfo[1];
                cbRemember.Checked=true;
            }
            else
            {
                SaveOrUpdateLoginInfo(tbUserName.Text,tbPassword.Text);
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                button1.PerformClick();
                e.Handled = true;
            }
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                errorProvider1.SetError(tbUserName,"Enter UserName");
             //   e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbUserName,null);
               // e.Cancel = false;
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Enter Password");
              //  e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
               // e.Cancel = false;
            }
        }

        private bool IsCorrect()
        {
            return (_User!=null);
        }
        private void SaveUserName_Passsowrd()
        {
            if(!cbRemember.Checked)
            {
                tbPassword.Text = "";
                tbUserName.Text = "";
            }
            SaveOrUpdateLoginInfo(tbUserName.Text.Trim(), tbPassword.Text.Trim());
        }

        // 6/12/2025
        private bool IsUserName_PassowrdExists()
        {
            try
            {
              string UserValue = Registry.GetValue(keypath, value1_Name,null) as string;
                string PasswordValue = Registry.GetValue(keypath, value2_Name,null) as string;
                if (!string.IsNullOrEmpty(UserValue) && !string.IsNullOrEmpty(PasswordValue))
                {
                    LoginInfo.Clear();
                    LoginInfo.Add(UserValue);
                    LoginInfo.Add(PasswordValue);
                    return true;
                }
                    return false;

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool SaveOrUpdateLoginInfo(string username, string password)
        {
            try
            {
                // This will create the key and values if they don't exist
                Registry.SetValue(keypath, value1_Name, username, RegistryValueKind.String);
                Registry.SetValue(keypath, value2_Name,password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registry write failed: {ex.Message}", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
       


    }
}
