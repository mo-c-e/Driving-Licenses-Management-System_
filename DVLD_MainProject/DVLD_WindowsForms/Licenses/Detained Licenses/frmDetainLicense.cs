using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Licenses.Detained_Licenses
{
    public partial class frmDetainLicense : Form
    {
        int _LicenseID;
        clsDetainedLicensesBL DetainedLicense;
        public frmDetainLicense()
        {
            InitializeComponent();
            ucLicenseInfoWithFilter1.ResetMode(clsUtil.enFilterMode.DetainLicense);
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {

        }

        private void ucLicenseInfoWithFilter1_OnPersonSelected(int obj)
        {
            buDetain.Enabled = true;
            tbFineFees.Enabled = true;
            _LicenseID=obj;
            
        }

        private void ucLicenseInfoWithFilter1_OnPersonSel(bool obj)
        {
            linkLicensesHistory.Enabled = obj;
            if (obj == true)
                FillApplicationInfo();
        }
        private void FillApplicationInfo()
        {
            laDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            laUser.Text = Properties.Settings.Default.UserName;
            laLicenseID.Text= _LicenseID.ToString();
        }

        private void buDetain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Missing Information", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Do you want to Detain Selected License?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DetainLicense() != -1)
                {
                    MessageBox.Show("Detained License Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    linkLicenseInfo.Enabled = true;
                    buDetain.Enabled = false;
                    tbFineFees.Enabled = false;
                    laDetainID.Text = DetainedLicense.DetainID.ToString();
                }
                else
                {
                    MessageBox.Show("Failed to detain license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operation canceled by user.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private int DetainLicense()
        {
             DetainedLicense = new clsDetainedLicensesBL();
            clsUsersBL User = clsUsersBL.FindbyUserName(Properties.Settings.Default.UserName);
            DetainedLicense.LicenseID = _LicenseID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.IsReleased = false;
            DetainedLicense.FineFees = Convert.ToSingle(tbFineFees.Text);
            DetainedLicense.CreatedByUserID = User.UserID;
            if (DetainedLicense.Save())
                return DetainedLicense.DetainID;
            else
            return -1;
        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DetainedLicense == null)
                return;

                frmLicenseInfo LicenseInfo = new frmLicenseInfo(DetainedLicense.LicenseID);
                LicenseInfo.ShowDialog();
            
        }

        private void tbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // stop the key from being entered
            }
        }

        private void tbFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFineFees, "Please enter fine fees.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFineFees, "");
            }
        }
    }


        }
    

