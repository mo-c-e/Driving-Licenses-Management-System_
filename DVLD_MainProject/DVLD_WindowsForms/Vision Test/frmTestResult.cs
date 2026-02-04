using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Vision_Test
{
    public partial class frmTestResult : Form
    {
        int _LocalDrivingAppID;
        int _TestAppointment;
        int _TestTypeID;
        clsTestsBL Tests;

       
        public frmTestResult(int localDrivingAppID,int testappointment,int TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingAppID = localDrivingAppID;
            _TestAppointment = testappointment;
            _TestTypeID = TestTypeID;
            //
            ucTestsResults1.TestType = "Scheduled Test";
            //ucTestsResults1.LocalDrivingLicense = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(_LocalDrivingAppID);
            //ucTestsResults1.TestAppointment = clsTestAppointmentsBL.FindByTestAppointmentID(TestAppointment);
            //ucTestsResults1.UplaodTestResult();
            ucTestsResults1.SetExamUserControl(_LocalDrivingAppID,_TestAppointment,_TestTypeID);
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTestResult_Load(object sender, EventArgs e)
        {

        }

        private void buSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Save? After Saving you can't Change Pass/Fail Result","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                if (AddTests())
                { 
                  
                    MessageBox.Show("Grade Saved Successfully");
                    
                this.Close();
                return;
            
                }
                MessageBox.Show("Unable To TestTable");
            }
            else
            {
                MessageBox.Show("Saving Fail");
            }
        }
        private byte Pass_Fail()
        {
           if(rbPass.Checked==true)
            {

                return 1;
            }
            if (rbFail.Checked == true) {
                ucTestsResults1.SetRetakeApplication();
                return 0;
            }
            return 0;
        }
        private bool AddTests()
        {
            Tests = new clsTestsBL();
            Tests.TestAppointmentID = _TestAppointment;
            Tests.TestResult = Pass_Fail();
            Tests.Notes = tbNotes.Text;
            Tests.CreatedByUserID = ucTestsResults1.TestAppointment.CreatedByUserID;
            if (Tests.Save())
            {
                if (ucTestsResults1.LockTest())
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private void rbPass_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
