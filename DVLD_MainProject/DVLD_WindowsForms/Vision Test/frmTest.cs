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

namespace DVLD_WindowsForms.Vision_Test
{
    public partial class frmTest : Form
    {
        int _LocalDrivingLicenseApp;
        int TestAppID;
        int _TestTypeID;
      
        public frmTest(int localDLApp,int TestAppointmentID,int TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApp=localDLApp;
            TestAppID = TestAppointmentID;
            _TestTypeID = TestTypeID;
          
            //ucTests1.TestAppointmentID = TestAppID;
            //ucTests1.TestFees = clsTestTypeBL.FindTestType(_TestTypeID).TestTypeFees;
            //if (TestAppID!=-1)
            //{
            //    ucTests1.TestAppointment = clsTestAppointmentsBL.FindByTestAppointmentID(TestAppID);
            //}
            //ucTests1.LocalDrivingLicense = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseApp);


        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            ucTests1.SetUserControl(_LocalDrivingLicenseApp,TestAppID,_TestTypeID);
            //ucTests1.LoadUserControl();
            //if(TestAppID==-1)
            //{
            //    if (clsTestAppointmentsBL.IsTestAppointmentExistsByLocalDrivingLicenseApp(_LocalDrivingLicenseApp))
            //    {
            //        int x = clsTestAppointmentsBL.FindTestAppointment_RetakeExists(_LocalDrivingLicenseApp);
               
            //        if (x != -1)
            //        {
            //            ucTests1.LoadRetakeTestMenu(true, x);
            //            return;
            //        }
            //    }
            //    else
            //        return;
            //}
            ////if(ucTests1.TestAppointment!=null)
            //ucTests1.LoadRetakeTestMenu();
            //ucTests1.LockScreen();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
