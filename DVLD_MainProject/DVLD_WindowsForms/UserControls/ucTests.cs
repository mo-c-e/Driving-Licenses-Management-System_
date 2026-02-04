using DVLD_BusinessLayer;
using DVLD_WindowsForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ucTests : UserControl
    {
        enum Mode
        {
            AddNew,Edit
        }
        Mode currentMode;
        public int TestTypeID { get; set; }
        public string TestType { get; set; }
       
        public int PhotoNumber { set; get; }

        public int PersonID { get; set; }

        public float TestFees { get; set; }

       // public int mode {get; set; }

        private int TestAppointmentID { get; set; }

        private int LocalDrvingAppID;
       
        public clsLocalDrivingLicenseAppBL LocalDrivingLicense { get; set; }

        private clsApplicationBL RetakeApplication;
        private clsAppTypesBL ApplicationTypes;
        private clsPeopleBL Person;
        private clsTestTypeBL TestTypes;
     //   private clsTestsBL Tests;
        public clsTestAppointmentsBL TestAppointment;
      //  private int _TestAppointmentForAdd;

        public ucTests()
        {
            InitializeComponent();
            
        }

       
        public void SetUserControl(int localDLApp, int TestAppointmentID,int TestTypeID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrvingAppID = localDLApp;
            this.LocalDrivingLicense = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(this.LocalDrvingAppID);
            this.TestFees= clsTestTypeBL.FindTestType(this.TestTypeID).TestTypeFees;
            if (this.TestAppointmentID != -1)
            {
                TestAppointment = clsTestAppointmentsBL.FindByTestAppointmentID(this.TestAppointmentID);
            }

            // LoadUserControl();
            FillInfo();
            if (this.TestAppointmentID == -1)
            {
                if (clsTestAppointmentsBL.IsTestAppointmentExistsByLocalDrivingLicenseApp(this.LocalDrvingAppID))
                {
                    int x = clsTestAppointmentsBL.FindTestAppointment_RetakeExists(this.LocalDrvingAppID,this.TestTypeID);

                    if (x != -1)
                    {
                        LoadRetakeTestMenu(true, x);
                        return;
                    }
                }
               
                    return;
            }
            //if(ucTests1.TestAppointment!=null)
            LoadRetakeTestMenu();
            LockScreen();
        }
      

        private void FillUpperPart()
        {
           
             ApplicationTypes = clsAppTypesBL.Find(LocalDrivingLicense.ApplicationInfo.ApplicationTypeID);
             Person = clsPeopleBL.FindByPersonID(LocalDrivingLicense.ApplicationInfo.ApplicantPersonID);
             TestTypes = clsTestTypeBL.FindTestType(TestTypeID);
            string ThirdName = Person.ThirdName == null ? "" : Person.ThirdName;


            laDLAppID.Text = LocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
            laDClass.Text = ApplicationTypes.ApplicationTypeTile.ToString();
            laName.Text = Person.FirstName + " " + Person.SecondName + " " +ThirdName  + " " + Person.LastName;
            laTrial.Text = (clsTestAppointmentsBL.CountTrial(TestTypeID,LocalDrivingLicense.LocalDrivingLicenseApplicationID)+1).ToString();
            if(currentMode==Mode.Edit )
            dtDate.Value = TestAppointment.AppointmentDate;
           laFees.Text = TestTypes.TestTypeFees.ToString();
            laTotalFees.Text = TestFees.ToString();
        }

        public void LoadRetakeTestMenu(bool isEdit=false,int TestAppointmentID=-1)
        {
            //if(TestAppointment==null)
            //{
            //    return;
            //}
            if (!isEdit) {
                if(TestAppointment.RetakeTestApplicationID != null)
                {
                    FillRetakeTest((int)TestAppointment.RetakeTestApplicationID);
                    //return;
                }
                // return;
               
            }
           
            if (isEdit)
            {
                TestAppointment = clsTestAppointmentsBL.FindByTestAppointmentID(TestAppointmentID);
                FillRetakeTest((int)TestAppointment.RetakeTestApplicationID);
            }
            if (RetakeApplication != null)
            {
                TestFees += RetakeApplication.ApplicatoinTypeInfo.ApplicationFees;
                laTotalFees.Text = TestFees.ToString();
            }
        }
        public void FillRetakeTest(int testappointment)
        {
                RetakeApplication = clsApplicationBL.FindByApplicationID(testappointment);
           // TestFees += RetakeApplication.ApplicatoinTypeInfo.ApplicationFees;
            laRetakeFees.Text = RetakeApplication.ApplicatoinTypeInfo.ApplicationFees.ToString();
            laRTestID.Text = RetakeApplication.ApplicationID.ToString();
        }

        private void FillInfo()
        {
            SetMode();
            if (!clsTestsBL.IsTestExistsByLocalDLApp(LocalDrivingLicense.LocalDrivingLicenseApplicationID) || !clsTestsBL.IsPass(1, LocalDrivingLicense.LocalDrivingLicenseApplicationID))
            {
                pRetakeTest.Enabled = false;
            }
            else
            {
                pRetakeTest.Enabled = true;
            }
           switch(TestTypeID)
            {
                case 1:
                    pbPhoto.Image = Properties.Resources.Vision_512;
                    laTestType.Text = "Vision Test";
                    break;

                case 2:
                    pbPhoto.Image = Properties.Resources.Written_Test_512;
                    laTestType.Text = "Written Test";
                    break;
                case 3:
                    pbPhoto.Image = Properties.Resources.driving_test_512;
                    laTestType.Text = "Street Test";
                    break;

                default:
                    break;
               
            }
               
          //  laTestType.Text = TestType.ToString();
            FillUpperPart();
        }

        private void AddTestAppointment()
        {
           
            if (currentMode == Mode.AddNew)
            {
                TestAppointment.TestTypeID = TestTypeID;
                TestAppointment.LocalDrivingLicenseApplicationID = LocalDrivingLicense.LocalDrivingLicenseApplicationID;
               // TestAppointment.AppointmentDate = dtDate.Value;
                TestAppointment.PaidFees = TestTypes.TestTypeFees;
                TestAppointment.CreatedByUserID = LocalDrivingLicense.ApplicationInfo.CreatedByUserID;
                TestAppointment.IsLocked = 0;
                TestAppointment.RetakeTestApplicationID = null;
            }
           
            TestAppointment.AppointmentDate = dtDate.Value;

            if (TestAppointment.Save())
            {
                MessageBox.Show("Saved Successfully");
                if(currentMode==Mode.AddNew)
                {
                    buSave.Enabled = false;
                }
                currentMode = Mode.Edit;
            }
            else
            {
                MessageBox.Show("Enable To Save");
            }



        }

        private void SetMode()
        {

          //  laTotalFees.Text = TestFees.ToString();
            if (this.TestAppointmentID==-1)
            {
                currentMode = Mode.AddNew;
                dtDate.MinDate = DateTime.Now;
            }
           else
            {
                currentMode = Mode.Edit;
                dtDate.MinDate = clsTestAppointmentsBL.GetLeastDateAppointment(LocalDrivingLicense.LocalDrivingLicenseApplicationID,TestTypeID);
            }
        }

        private void buSave_Click(object sender, EventArgs e)
        {
            switch (currentMode)
            {
                case Mode.Edit:
                    TestAppointment = clsTestAppointmentsBL.FindByTestAppointmentID(this.TestAppointmentID);
                    break;
                case Mode.AddNew:
                    TestAppointment = new clsTestAppointmentsBL();
                    break;
            }
            AddTestAppointment();

        }

        public void LockScreen()
        {
            if(TestAppointment!=null)
            {
                if(TestAppointment.IsLocked==1 )
                {
                    laPersonAlready.Text = "Person already sat for the test, appointment loacked.";
                    DisableInfo(false);
                }
                else
                {
                    laPersonAlready.Text = "";
                    DisableInfo(true);
                }
            }
        }
        private void DisableInfo(bool Choice)
        {
            dtDate.Enabled = Choice;
             buSave.Enabled=Choice;
        }

        private void ucTests_Load(object sender, EventArgs e)
        {

        }
    }
}
