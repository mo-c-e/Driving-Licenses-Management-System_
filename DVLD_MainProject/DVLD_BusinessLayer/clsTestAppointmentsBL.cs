using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointmentsBL
    {
        enum Mode
        {
           AddNew,Update
        }
        Mode CurrentMode = Mode.AddNew;
      public  int TestAppointmentID { get; set; }
      public  int TestTypeID { get; set; }
      public  int LocalDrivingLicenseApplicationID { get; set; }
       public DateTime AppointmentDate { get; set; }
       public float PaidFees { get; set; }
      public  int CreatedByUserID { get; set; }
       public byte IsLocked { get; set; }
       public Nullable<int> RetakeTestApplicationID { get; set; }

        public clsTestTypeBL TableTestType;

        public clsLocalDrivingLicenseAppBL TabelLocalDrivingLicenseApp;

        public clsApplicationBL TableRetakeTestApplicationID;

        public clsTestAppointmentsBL()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = 0;
            this.RetakeTestApplicationID= null;
            CurrentMode = Mode.AddNew;
        }
        private clsTestAppointmentsBL(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID,
             byte IsLocked, Nullable<int> RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.TableTestType = clsTestTypeBL.FindTestType(this.TestTypeID);
            this.TabelLocalDrivingLicenseApp = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(this.LocalDrivingLicenseApplicationID);
            CurrentMode = Mode.Update;   
            //this.TableRetakeTestApplicationID = clsApplicationBL.FindByApplicationID(this.RetakeTestApplicationID==null ? 0 : this.RetakeTestApplicationID);
        }

        public static clsTestAppointmentsBL FindByTestAppointmentID(int TestAppointment)
        {
            int TestTypeID = -1, LocalDApp = -1, user = -1;
            Nullable<int> RetakeTestAppID = null;
            DateTime AppoitmentDate = DateTime.Now;
            float Fees = -1;
            byte IsLocked = 0;

            if (clsTestAppointmentsDAL.FindTestAppointmentByID(TestAppointment,ref TestTypeID,ref LocalDApp,ref AppoitmentDate,ref Fees,ref user,ref IsLocked,ref RetakeTestAppID))
            {
                return new clsTestAppointmentsBL(TestAppointment,TestTypeID,LocalDApp,AppoitmentDate,Fees,user,IsLocked,RetakeTestAppID);
            }
            else
            {
                return null;
            }

        }

        

        public static DataTable GetTestAppointmentTable()
        {
            return clsTestAppointmentsDAL.GetTestAppointmentTable();
        }

        public static DataTable GetTestAppointmentByLocalLicenseID(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsTestAppointmentsDAL.GetTestAppointmentTableByLocalDrivingLicense(LocalDrivingLicenseApplicationID,TestTypeID);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsDAL.DeleteTestAppointment(TestAppointmentID);
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsDAL.AddNewTestAppointment(this.TestAppointmentID,this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsDAL.UpdateTestAppointment(this.TestAppointmentID,this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
        }

        public bool Save()
        {
            switch (CurrentMode)
            {
                case Mode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Mode.Update:
                    return _UpdateTestAppointment();
                default:
                    break;
            }
            return false;
        }

        public static bool IsTestAppointmentExists(int TestAppointmentID)
        {
            return clsTestAppointmentsDAL.IsTestAppointmentExists(TestAppointmentID);
        }

        public static int CountTrial(int testtypeID,int LocalDrivingLicenseID)
        {
            return clsTestAppointmentsDAL.CountTiral(testtypeID,LocalDrivingLicenseID);
        }


        public static int FindTestAppointment_RetakeExists(int LocalDrivingLicenseID, int TestTypeID)
        {
            return clsTestAppointmentsDAL.GetTestAppointmentID_When_RetakExists(LocalDrivingLicenseID,TestTypeID);
        }

        public static bool IsTestAppointmentExistsByLocalDrivingLicenseApp(int LocalDrivingLicenseID)
        {
            return clsTestAppointmentsDAL.IsTestAppointmentExistsByLocalDrivingLicenseID(LocalDrivingLicenseID);
        }

        public static bool IsLockedAppointments(int LocalDrivingLicenseID,int TestTypeID)
        {
            return clsTestAppointmentsDAL.IsLocked(LocalDrivingLicenseID,TestTypeID);
        }

        public static bool IsLockedByAppointmentID(int TestAppointmentID, int TestTypeID)
        {
            return clsTestAppointmentsDAL.IsLocked_AppointmentID(TestAppointmentID,TestTypeID);
        }

        public static DateTime GetLeastDateAppointment(int LocalDrivingLicenseID, int TestTypeID)
        {
            return clsTestAppointmentsDAL.GetLeastDateAppointment(LocalDrivingLicenseID, TestTypeID);
        }
    }
}
