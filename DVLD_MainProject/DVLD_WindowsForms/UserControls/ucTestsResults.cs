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
using static System.Windows.Forms.AxHost;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ucTestsResults : UserControl
    {
        private int TestTypeID { get; set; }
        public string TestType { get; set; }
        public int PersonID { get; set; }

        public clsLocalDrivingLicenseAppBL LocalDrivingLicense { get; set; }

        public clsApplicationBL RetakeApplication;
        private clsAppTypesBL ApplicationTypes;
        private clsPeopleBL Person;
        private clsTestTypeBL TestTypes;
        public clsTestsBL Tests { get; set; }
        public clsTestAppointmentsBL TestAppointment;
        public ucTestsResults()
        {
            InitializeComponent();
        }

        private void ucTestsResults_Load(object sender, EventArgs e)
        {

        }

        public void SetExamUserControl(int localDrivingAppID, int testappointment, int TestTypeID)
        {
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicense = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(localDrivingAppID);
            this.TestAppointment = clsTestAppointmentsBL.FindByTestAppointmentID(testappointment);
            UplaodTestResult();
        }
        public void UplaodTestResult()
        {
            switch(TestTypeID)
            {
                case 1:
                    pbPhoto.Image = Properties.Resources.Vision_512;
                    break;
                case 2:
                    pbPhoto.Image = Properties.Resources.Written_Test_512;
                    break;
                case 3:
                    pbPhoto.Image = Properties.Resources.driving_test_512;
                    break;

                default:
                    break;
            }
            laTestType.Text = TestType;
            FillUpperPart();
        }
        private void FillUpperPart()
        {
           // ApplicationTypes = clsAppTypesBL.Find(TestAppointment.TabelLocalDrivingLicenseApp.ApplicationInfo.ApplicationTypeID);
            ApplicationTypes = clsAppTypesBL.Find(LocalDrivingLicense.ApplicationInfo.ApplicationTypeID);
            Person = clsPeopleBL.FindByPersonID(LocalDrivingLicense.ApplicationInfo.ApplicantPersonID);
            TestTypes = clsTestTypeBL.FindTestType(TestTypeID);
            laDLAppID.Text = TestAppointment.TabelLocalDrivingLicenseApp.LocalDrivingLicenseApplicationID.ToString();
            laDClass.Text = ApplicationTypes.ApplicationTypeTile.ToString();
            string ThirdName = Person.ThirdName == null ? "" : Person.ThirdName;
            laName.Text = Person.FirstName + " " + Person.SecondName + " " + ThirdName + " " + Person.LastName;
            laTrial.Text = (clsTestAppointmentsBL.CountTrial(TestTypeID, LocalDrivingLicense.LocalDrivingLicenseApplicationID)+1).ToString();
            laDate.Text = TestAppointment.AppointmentDate.ToString("dd/MM/yyyy");
            laFees.Text = TestTypes.TestTypeFees.ToString();  
            if(Tests!=null)
            {
                laTestID.Text = Tests.TestID.ToString();
            }
            else
            {
                laTestID.Text = "Not Taken Yet";
            }
        }

        public bool LockTest()
        {
            TestAppointment.IsLocked = 1;
            if(TestAppointment.Save())
            {
                return true;
            }
            return false;
        }

        public bool SetRetakeApplication()
        {
            RetakeApplication = new clsApplicationBL();
            RetakeApplication.ApplicantPersonID = Person.PersonID;
            RetakeApplication.ApplicationDate = DateTime.Now;
            RetakeApplication.ApplicationTypeID = 7;
            RetakeApplication.ApplicationStatus = 3;
            RetakeApplication.LastStatusDate = DateTime.Now;
            RetakeApplication.PaidFees = ApplicationTypes.ApplicationFees;
            RetakeApplication.CreatedByUserID = TestAppointment.CreatedByUserID;
            if(RetakeApplication.Save())
            {
                TestAppointment.RetakeTestApplicationID = RetakeApplication.ApplicationID;
                return true;
            }
            else
            {
                return false;
            }
        }

      

    }
}
