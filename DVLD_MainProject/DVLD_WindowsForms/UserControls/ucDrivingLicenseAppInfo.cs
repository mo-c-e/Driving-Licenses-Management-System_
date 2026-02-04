using DVLD_BusinessLayer;
using DVLD_WindowsForms.Licenses;
using DVLD_WindowsForms.People;
using DVLD_WindowsForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Local_Driving_License_Application
{
    public partial class ucDrivingLicenseAppInfo : UserControl
    {
        int _LocalDrivingLicenseID;
      //  int _PassedTets;
        clsAppTypesBL ApplicationClass;
        clsPeopleBL Person;
        clsUsersBL User;
        
        
        public ucDrivingLicenseAppInfo()
        {
           
            InitializeComponent();
            
        }

        public void SetLocalDrivingLicenseID(int LocalID)
        {
            _LocalDrivingLicenseID = LocalID;
            FillInformation();
        }

      

        public clsPeopleBL GetApplicationInfo()
        {
            return Person;
        }

        public clsUsersBL GetUserInfo()
        {
            return User;   
        }

        
        private void FillInformation()
        {
            if(_LocalDrivingLicenseID==-1)
            {
                return;
            }
           clsLicenseBL License= clsLicenseBL.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseID);
            if(License != null)
                linkShowLicenseInfo.Enabled= true;
            else
                linkShowLicenseInfo.Enabled= false;


            clsLocalDrivingLicenseAppBL LocalDrivingLicense = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseID);
            if(LocalDrivingLicense!=null)
            {
                 ApplicationClass = clsAppTypesBL.Find(LocalDrivingLicense.ApplicationInfo.ApplicationTypeID);
                 Person = clsPeopleBL.FindByPersonID(LocalDrivingLicense.ApplicationInfo.ApplicantPersonID);
                User = clsUsersBL.FindbyUserID(LocalDrivingLicense.ApplicationInfo.CreatedByUserID);
                laLDLID.Text = LocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
                laLicenseClass.Text = LocalDrivingLicense.LicenseClassesInfo.ClassName;
                UpdateExamStatus();
                laAppID.Text = LocalDrivingLicense.ApplicationID.ToString();
                laStatus.Text = clsUtil.GetApplicationStatus(LocalDrivingLicense.ApplicationInfo.ApplicationStatus);
                laFees.Text = LocalDrivingLicense.ApplicationInfo.PaidFees.ToString();
                laType.Text = ApplicationClass.ApplicationTypeTile;
                string ThirdName= Person.ThirdName == "" || Person.ThirdName == null ? "" : Person.ThirdName;
                string FullName = Person.FirstName + " " + Person.SecondName + " " + ThirdName+" " + Person.LastName;
                laApplicant.Text= FullName;
                laDate.Text = LocalDrivingLicense.ApplicationInfo.ApplicationDate.ToString();
                laStatusDate.Text= LocalDrivingLicense.ApplicationInfo.LastStatusDate.ToString();
                laUserName.Text= User.UserName;

            }
        }

        private void linkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            People_Info person = new People_Info(Person.PersonID);
            person.ShowDialog();
        }

        private void ucDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {
          //  FillInformation();
        }

        public void UpdateExamStatus()
        {
            int x = clsTestsBL.CountPassedTests(_LocalDrivingLicenseID);
            if (x < 0)
                return;
            lapassedTest.Text = x.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseInfo LicenseInfo = new frmLicenseInfo(_LocalDrivingLicenseID,1);
            LicenseInfo.ShowDialog();
          //  frmLicenseInfo LicenseInfo = new frmLicenseInfo();
        }
    }
}
