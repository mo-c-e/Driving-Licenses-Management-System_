using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.DrivingLicense
{
    public partial class frmIssueDrivingLicense : Form
    {
        private int _LocalDrivingLicenseAppID;
        private int _PassedTests;
        private clsLocalDrivingLicenseAppBL _LocalDrivingAppInfo;
        public delegate void delEnable(bool x);
        public event delEnable Databack;

        private clsDriversBL Driver;
        public frmIssueDrivingLicense(int LocalDrivingAppID,int passedTests)
        {
            InitializeComponent();
            this._LocalDrivingLicenseAppID = LocalDrivingAppID;
            this._PassedTests = passedTests;
            ucDrivingLicenseAppInfo2.SetLocalDrivingLicenseID(_LocalDrivingLicenseAppID);
          //  ucDrivingLicenseAppInfo2.SetPassedTests(_PassedTests);
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucDrivingLicenseAppInfo1_Load(object sender, EventArgs e)
        {

        }

        private void buIssue_Click(object sender, EventArgs e)
        {
            int LID = -1;
            _LocalDrivingAppInfo = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseAppID);
            clsApplicationBL application= clsApplicationBL.FindByApplicationID(_LocalDrivingAppInfo.ApplicationID);
            if (_LocalDrivingAppInfo == null)
                return;
            if (!clsDriversBL.IsDriverExistsByPersonID(_LocalDrivingAppInfo.ApplicationInfo.ApplicantPersonID))
            {
                if(AddNewDriver())
                {
                    if (AddNewLicense(ref LID))
                    {
                        application.ApplicationStatus = 3;
                        if (application.Save())
                        {
                            Databack?.Invoke(true);
                            MessageBox.Show($"Add License Successfully ID = {LID}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            buIssue.Enabled = false;
                        }
                        else
                            MessageBox.Show($"Error While Update Status", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show($"Unable to Issue License", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show($"Unable to AddDriver","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (AddNewLicense(ref LID))
            {
                application.ApplicationStatus = 3;
                if (application.Save())
                {
                    Databack?.Invoke(true);
                    MessageBox.Show($"Add License Successfully ID = {LID}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buIssue.Enabled=false;
                }
                else
                    MessageBox.Show($"Error While Update Status", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show($"Unable to Issue License", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool AddNewDriver()
        {
            Driver= new clsDriversBL();
            Driver.PersonID = _LocalDrivingAppInfo.ApplicationInfo.ApplicantPersonID;
            Driver.CreatedByUserID= _LocalDrivingAppInfo.ApplicationInfo.CreatedByUserID;
            Driver.CreatedDate=DateTime.Now;
            if (Driver.Save())
                return true;
            else return false;
        }

        private bool AddNewLicense(ref int LicenseID)
        {
            clsLicenseBL License= new clsLicenseBL();
            License.ApplicationID = _LocalDrivingAppInfo.ApplicationID;
            if (clsDriversBL.IsDriverExistsByPersonID(_LocalDrivingAppInfo.ApplicationInfo.ApplicantPersonID))
            {
                clsDriversBL Driver = clsDriversBL.FindByPersonID(_LocalDrivingAppInfo.ApplicationInfo.ApplicantPersonID);
                if (Driver != null)
                {
                    License.DriverID = Driver.DriverID;
                }
                else
                {
                    MessageBox.Show("Error IN Driver");
                    return false;
                }
            }
            else
            {
                License.DriverID = Driver.DriverID;
            }
            License.LicenseClass = _LocalDrivingAppInfo.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(_LocalDrivingAppInfo.LicenseClassesInfo.DefaultValidityLength);
            License.Notes=tbNotes.Text;
            License.PaidFees = _LocalDrivingAppInfo.LicenseClassesInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = 1;
            License.CreatedByUserID = _LocalDrivingAppInfo.ApplicationInfo.CreatedByUserID;
            
            if(License.Save())
            {
                LicenseID = License.LicenseID;
                return true;
            }
            return false;

        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
