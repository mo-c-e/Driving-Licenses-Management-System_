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
    public partial class frmReleaseDetainedLicense : Form
    {
        int _LicenseID;
        clsDetainedLicensesBL _DetainedLicense;
        clsAppTypesBL Apptype = clsAppTypesBL.Find(5);
        int applicationID;
        clsUsersBL user = clsUsersBL.FindbyUserName(Properties.Settings.Default.UserName);
        enum enMode
        {
            AutoLicenseNumber, BySearch
        }
        private enMode CurrentMode;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            CurrentMode = enMode.BySearch;
            ucLicenseInfoWithFilter1.ResetMode(clsUtil.enFilterMode.ReleaseLicense);
        }
        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            CurrentMode = enMode.AutoLicenseNumber;
            ucLicenseInfoWithFilter1.ResetMode(clsUtil.enFilterMode.ReleaseLicense);
        }

      

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucLicenseInfoWithFilter1_OnPersonSelected(int obj)
        {
            _LicenseID = obj;
            _DetainedLicense = clsDetainedLicensesBL.FindLastDetainLicenseByID(_LicenseID);
            buRelease.Enabled = true;
            FillApplicationInfo();
        }

        private void ucLicenseInfoWithFilter1_OnPersonSel(bool obj)
        {
            linkLicensesHistory.Enabled=obj;
            laUser.Text = Properties.Settings.Default.UserName;
            laDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void FillApplicationInfo()
        {
          
            if (_DetainedLicense == null)
            {
                MessageBox.Show("Not Found DetainedID","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
               
            laDetainID.Text = _DetainedLicense.DetainID.ToString();
            laLicenseID.Text=_DetainedLicense.LicenseID.ToString();
            laApplicationFees.Text = Apptype.ApplicationFees.ToString();
            laFineFees.Text = _DetainedLicense.FineFees.ToString();
            float total = Apptype.ApplicationFees + _DetainedLicense.FineFees;
            laTotalFees.Text = total.ToString();  
        }

        private bool ReleaseLicense()
        {
             applicationID=NewApplication();
            if (applicationID == -1)
            {
                MessageBox.Show("Failed to release license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _DetainedLicense.ReleaseDate = DateTime.Now;
            _DetainedLicense.ReleasedByUserID = user.UserID;
            _DetainedLicense.ReleaseApplicationID = applicationID;
            _DetainedLicense.IsReleased = true;

            return _DetainedLicense.Save() ? true  : false;
        }

        private int NewApplication()
        {
           
            clsApplicationBL App = new clsApplicationBL();
            App.ApplicantPersonID = _DetainedLicense.LicenseInfo.ApplicationInfo.PersonInfo.PersonID;
            App.ApplicationDate = DateTime.Now;
            App.ApplicationTypeID = 5;
            App.ApplicationStatus = 3;
            App.LastStatusDate= DateTime.Now;
            App.PaidFees = Apptype.ApplicationFees;
            App.CreatedByUserID = user.UserID;
            return App.Save() ? App.ApplicationID : -1;
        }

        private void buRelease_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Release Selected License?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ReleaseLicense())
                {
                    MessageBox.Show("Released License Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    linkLicenseInfo.Enabled = true;
                    buRelease.Enabled = false;
                  laApplicationID.Text=applicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Failed to Release license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operation canceled by user.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo(_LicenseID);
            LicenseInfo.ShowDialog();
        }

        private void linkLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(_DetainedLicense.LicenseInfo.ApplicationInfo.PersonInfo.NationalNo);
            LicenseHistory.ShowDialog();
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if (CurrentMode == enMode.AutoLicenseNumber)
                ucLicenseInfoWithFilter1.AutoClick(_LicenseID);
        }
    }
}
