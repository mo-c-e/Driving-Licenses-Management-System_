using DVLD_BusinessLayer;
using DVLD_WindowsForms.International_Licenses;
using DVLD_WindowsForms.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms
{
    public partial class frmAddInternationlLicense : Form
    {
        int _LicenseID;
        clsApplicationBL Application;
        clsLicenseBL License;
        clsInternationalLicensesBL ILicense;
        // For Enable and disable Issue Button
        public frmAddInternationlLicense()
        {
            InitializeComponent();
            ucLicenseInfoWithFilter1.ResetMode(clsUtil.enFilterMode.IssueInternationalLicense);
        }

        private void ucLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void frmAddInternationlLicense_Load(object sender, EventArgs e)
        {
           
        }

       

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewInternationalLicense()
        {
            if (!AddNewApplication())
            {
                MessageBox.Show("Enable To Issue International License");
                return;
            }
                 ILicense = new clsInternationalLicensesBL();
                ILicense.ApplicationID = Application.ApplicationID;
                ILicense.DriverID = License.DriverID;
                ILicense.IssuedUsingLocalLicenseID = License.LicenseID;
                ILicense.IssueDate = DateTime.Now;
                ILicense.ExpirationDate = (DateTime)ILicense.IssueDate.AddYears(1);
                ILicense.IsActive = License.IsActive;
                ILicense.CreatedByUserID = License.CreatedByUserID;
                if (ILicense.Save())
                {
                buIssue.Enabled = false;
                linkLicenseInfo.Enabled = true;
                linkLicensesHistory.Enabled = true;
                ucInternationalApplicationInfo1.LoadApplicationInfo(ILicense.InternationalLicenseID);
                MessageBox.Show("Added Successfully");
                }
                     
        }

        private bool AddNewApplication()
        {
            
             License = clsLicenseBL.FindByLicenseID(_LicenseID);
             Application = new clsApplicationBL();
            clsAppTypesBL AppTypes = clsAppTypesBL.Find(6);
            Application.ApplicantPersonID = License.ApplicationInfo.ApplicantPersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = 6;
            Application.ApplicationStatus = 3;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = AppTypes.ApplicationFees;
            Application.CreatedByUserID=License.CreatedByUserID;
            
            return Application.Save();
        }

        private void buIssue_Click(object sender, EventArgs e)
        {
           
            AddNewInternationalLicense();
        }

       

        private void ucLicenseInfoWithFilter1_OnPersonSelected(int obj)
        {
            _LicenseID = obj;
            buIssue.Enabled = true;
        }

        private void ucLicenseInfoWithFilter1_OnPersonSelected2(int obj)
        {
            
        }

        private void linkLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (License == null)
                return;
            frmLicenseHistory History = new frmLicenseHistory(License.ApplicationInfo.PersonInfo.NationalNo);
            History.ShowDialog();
        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo ILInfo = new frmInternationalLicenseInfo(ILicense.InternationalLicenseID);
            ILInfo.ShowDialog();
        }
    }
}
