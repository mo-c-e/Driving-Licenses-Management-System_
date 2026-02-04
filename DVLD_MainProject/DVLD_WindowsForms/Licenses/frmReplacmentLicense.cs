using DVLD_BusinessLayer;
using DVLD_WindowsForms.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Licenses
{
    public partial class frmReplacmentLicense : Form
    {
        int _LicenseID;
        clsLicenseBL _LicenseInfo;
        clsLicenseBL _ReplacedLicenseInfo;
        public frmReplacmentLicense()
        {
            InitializeComponent();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplacmentLicense_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Checked = true;
            ucLicenseInfoWithFilter1.ResetMode(clsUtil.enFilterMode.ReplacementLicense);
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMode(sender,e);
        }
        private void ChangeMode(object sender,EventArgs e)
        {
            int ApplicationTypeID = -1;
            RadioButton button = sender as RadioButton;

            if (button == null || !button.Checked)
                return;

            if (button == rbDamagedLicense)
            {
                label1.Text = "Replacement For Damaged License";
                ApplicationTypeID = 4;
            }
            else if (button == rbLostLicense)
            {
                label1.Text = "Replacement For Lost License";
                ApplicationTypeID = 3;
            }
            ucReplacmentApplicationInfo1.FillApplicatoinFees(ApplicationTypeID);
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMode(sender,e);
        }

        private void ucLicenseInfoWithFilter1_OnPersonSelected(int obj)
        {
            _LicenseID = obj;
            if(clsLicenseBL.IsActiveLicense(_LicenseID))
            {
                _LicenseInfo = clsLicenseBL.FindByLicenseID(_LicenseID);
                if (_LicenseInfo == null)
                    return;

                buIssueReplacment.Enabled=true;
                ucReplacmentApplicationInfo1.Fill_LowerPart(_LicenseInfo);
                linkLicensesHistory.Enabled = true;
            }
        }

        private void buIssueReplacment_Click(object sender, EventArgs e)
        {
            ReplacmentLicense();

        }

        private void ReplacmentLicense()
        {
            clsUsersBL User = clsUsersBL.FindbyUserName(Properties.Settings.Default.UserName);
            _ReplacedLicenseInfo = new clsLicenseBL();
            if (AddNewApplication() == -1)
            {
                MessageBox.Show("Uanbl to Add Application");
                return;
            }
            _ReplacedLicenseInfo.ApplicationID = AddNewApplication();
            _ReplacedLicenseInfo.DriverID = _LicenseInfo.DriverID;
            _ReplacedLicenseInfo.LicenseClass = _LicenseInfo.LicenseClass;
            _ReplacedLicenseInfo.IssueDate = DateTime.Now;
            _ReplacedLicenseInfo.ExpirationDate = DateTime.Now.AddYears(_LicenseInfo.LicenseClassInfo.DefaultValidityLength);
            _ReplacedLicenseInfo.Notes = _LicenseInfo.Notes;
            _ReplacedLicenseInfo.PaidFees = _LicenseInfo.PaidFees;
            _ReplacedLicenseInfo.IsActive = true;
            _ReplacedLicenseInfo.IssueReason = 3;
            _ReplacedLicenseInfo.CreatedByUserID = User.UserID;

            // Deactivate Old License
            _LicenseInfo.IsActive = false;
            if (_ReplacedLicenseInfo.Save() && _LicenseInfo.Save())
            {
                MessageBox.Show($"License Replaced Successfully With ID {_ReplacedLicenseInfo.LicenseID}", "License Replacement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                linkLicenseInfo.Enabled=true;
                ucReplacmentApplicationInfo1.Fill_IDs(_ReplacedLicenseInfo);
            }
            else
                MessageBox.Show("Unable Saving Info");
        }

        private int AddNewApplication()
        {
            clsUsersBL User = clsUsersBL.FindbyUserName(Properties.Settings.Default.UserName);
            clsApplicationBL Application = new clsApplicationBL();
            clsAppTypesBL AppTypes = clsAppTypesBL.Find(3);
            Application.ApplicantPersonID = _LicenseInfo.ApplicationInfo.PersonInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = 3;
            Application.ApplicationStatus = 3;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = AppTypes.ApplicationFees;
            Application.CreatedByUserID = User == null ? -1 : User.UserID;
            return Application.Save() ? Application.ApplicationID : -1;

        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo(_ReplacedLicenseInfo.LicenseID);
            LicenseInfo.ShowDialog();
        }

        private void linkLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(_LicenseInfo.ApplicationInfo.PersonInfo.NationalNo);
            LicenseHistory.ShowDialog();
        }
    }
}
