using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestsBL
    {
        enum Mode
        {
            AddNew, Update
        }
        Mode CurrentMode = Mode.AddNew;
        public int TestID { get; set; }
       public int TestAppointmentID { get; set; }
       public byte TestResult { get; set; }
       public string Notes { get; set; }
       public int CreatedByUserID { get; set; }

       public clsTestAppointmentsBL TableTestAppointment;

       public clsTestsBL()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = 0;
            this.Notes = "";
            this.CreatedByUserID = -1;
            CurrentMode = Mode.AddNew;
        }

       private clsTestsBL(int TestID, int TestAppointmentID, byte TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID= TestID;
            this.TestAppointmentID= TestAppointmentID;
            this.TestResult= TestResult;
            this.Notes= Notes;
            this.CreatedByUserID= CreatedByUserID;
            this.TableTestAppointment = clsTestAppointmentsBL.FindByTestAppointmentID(this.TestAppointmentID);
            CurrentMode = Mode.Update;
        }

        public static clsTestsBL FindByTestsID(int TestID)
        {
            int TestAppointment = -1, CreatedByUser = -1;
            byte TestResult = 0;
            string Notes = "";

            if (clsTestsDAL.GetTestsByID(TestID,ref TestAppointment,ref TestResult,ref Notes,ref CreatedByUser))
            {
                return new clsTestsBL(TestID,TestAppointment,TestResult,Notes,CreatedByUser);
            }
            else
            {
                return null;
            }

        }



        public static DataTable GetTestsTable()
        {
            return clsTestsDAL.GetTestsTable();
        }

        public static bool DeleteTests(int TestID)
        {
            return clsTestsDAL.DeleteTests(TestID);
        }

        private bool _AddNewTests()
        {
            this.TestID = clsTestsDAL.AddNewTests(this.TestID,this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);
            return (this.TestID != -1);
        }

        private bool _UpdateTets()
        {
            return clsTestsDAL.UpdateTests(this.TestID,this.TestAppointmentID,TestResult,this.Notes,this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (CurrentMode)
            {
                case Mode.AddNew:
                    if (_AddNewTests())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Mode.Update:
                    return _UpdateTets();
                default:
                    break;
            }
            return false;
        }

        public static bool IsTestsExists(int TestID)
        {
            return clsTestsDAL.IsTestsExists(TestID);
        }

        public static bool IsTestTypeExists(int LocalDrivingLicenseApp,string TestType)
        {
            return clsTestsDAL.IsTestTypeExists(LocalDrivingLicenseApp,TestType);
        }

        public static bool IsPass(int TestTypeID,int LocalDrivingLicenseAppID)
        {
            return clsTestsDAL.IsPass(TestTypeID,LocalDrivingLicenseAppID);
        }

        public static bool IsTestExistsByLocalDLApp(int LocalDrivingLicenseAppID)
        {
            return clsTestsDAL.IsTestExists_ByLocalDrivingLicenseApp(LocalDrivingLicenseAppID);
        }

        public static int CountPassedTests(int LocalDrivingLicenseAppID)
        {
            return clsTestsDAL.CountPassedTests(LocalDrivingLicenseAppID);
        }

    }
}
