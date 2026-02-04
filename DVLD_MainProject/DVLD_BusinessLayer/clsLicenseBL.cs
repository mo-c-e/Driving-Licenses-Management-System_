using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseBL
    {
        enum eMode
        {
            AddNew,Update
        }
        eMode CurrentMode = new eMode();
       
       public int LicenseID { get; set; }
      public int ApplicationID { get; set; }
       public int DriverID { get; set; }
        public int LicenseClass { get; set; }
      public  DateTime IssueDate {get; set; }
      public  DateTime ExpirationDate { get; set; }
       public string Notes { get; set; }
       public float PaidFees { get; set; }
       public bool IsActive { get; set; }
       public short IssueReason { get; set; }
       public int CreatedByUserID { get; set; }

        public clsApplicationBL ApplicationInfo;
        public clsDriversBL DriverInfo;
        public clsLicenseClassesBL LicenseClassInfo;
        public clsUsersBL UsersInfo;

        public clsLicenseBL()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = 0;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive=false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
            CurrentMode = eMode.AddNew;
        }

        private clsLicenseBL(int LicenseID ,int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, short IssueReason, int CreatedByUserID)
        {
            this.LicenseID= LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID= DriverID;
            this.LicenseClass= LicenseClass;
            this.IssueDate= IssueDate;
            this.ExpirationDate= ExpirationDate;
            this.Notes= Notes;
            this.PaidFees= PaidFees;
            this.IsActive= IsActive;
            this.IssueReason= IssueReason;
            this.CreatedByUserID= CreatedByUserID;
            ApplicationInfo = clsApplicationBL.FindByApplicationID(this.ApplicationID);
            DriverInfo = clsDriversBL.FindByDriverID(this.DriverID);
            LicenseClassInfo=clsLicenseClassesBL.FindLicenseClasses(this.LicenseClass);
            UsersInfo = clsUsersBL.FindbyUserID(this.CreatedByUserID);
            CurrentMode = eMode.Update;
        }

        public static clsLicenseBL FindByLicenseID(int LicenseID)
        {
            int appID=-1,DriverID=-1,LicenseClass=-1,createdbyuserid=-1;
            DateTime issuedate=DateTime.Now,ExpirationDate= DateTime.Now;
            string notes = "";
            float paidfees = 0;
            bool isActive = false;
            short issuereason = 0;


            if (clsLicensesDAL.GetLicenseByID(LicenseID,ref appID,ref DriverID,ref LicenseClass,ref issuedate,ref ExpirationDate,ref notes,ref paidfees,ref isActive,ref issuereason,ref createdbyuserid))
            {
                return new clsLicenseBL(LicenseID,appID,DriverID,LicenseClass,issuedate,ExpirationDate,notes,paidfees,isActive,issuereason,createdbyuserid);
            }
            else
            {
                return null;
            }

        }

        public static clsLicenseBL FindByLocalDrivingLicenseAppID(int LocalDrivingLicenseApplicationID)
        {
            int appID = -1, DriverID = -1, LicenseClass = -1, createdbyuserid = -1,licenseid=-1;
            DateTime issuedate = DateTime.Now, ExpirationDate = DateTime.Now;
            string notes = "";
            float paidfees = 0;
            bool isActive = false;
            short issuereason = 0;


            if (clsLicensesDAL.GetLicenseByLocalDrivingLicenseAppID(LocalDrivingLicenseApplicationID,ref licenseid, ref appID, ref DriverID, ref LicenseClass, ref issuedate, ref ExpirationDate, ref notes, ref paidfees, ref isActive, ref issuereason, ref createdbyuserid))
            {
                return new clsLicenseBL(licenseid, appID, DriverID, LicenseClass, issuedate, ExpirationDate, notes, paidfees, isActive, issuereason, createdbyuserid);
            }
            else
            {
                return null;
            }

        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicensesDAL.DeactivateLicense(this.LicenseID));
        }

        public clsLicenseBL RenewLicense(string Notes,int CreatedByUserID)
        {
            clsAppTypesBL Apptype = clsAppTypesBL.Find(2);
            clsApplicationBL Application = new clsApplicationBL();
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = Apptype.ApplicationTypeID;
            Application.ApplicationStatus = 3;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = Apptype.ApplicationFees;
            Application.CreatedByUserID= CreatedByUserID;
            if(!Application.Save())
            {
                return null;
            }
            clsLicenseBL NewLicense= new clsLicenseBL();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate=DateTime.Now;
            int LicenseLength = this.LicenseClassInfo.DefaultValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(LicenseLength);
            NewLicense.Notes= Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive= true;
            NewLicense.IssueReason = 2;
            NewLicense.CreatedByUserID = CreatedByUserID;
            if(!NewLicense.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();

            return NewLicense;

        }
        public static DataTable GetLicenseTable()
        {
            return clsLicensesDAL.GetLicensesTable();
        }

        public static DataTable GetLicenseByNationalNo(string NationalNo)
        {
            return clsLicensesDAL.GetRecordByNationalNo(NationalNo);
        }

        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicensesDAL.DeleteLicense(LicenseID);
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicensesDAL.AddNewLicense(this.ApplicationID,this.DriverID,this.LicenseClass,this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserID);
            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicensesDAL.UpdateLicense(this.LicenseID,this.ApplicationID,this.DriverID,this.LicenseClass,this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (CurrentMode)
            {
                case eMode.AddNew:
                    return _AddNewLicense();
                case eMode.Update:
                    return _UpdateLicense();
                default:
                    break;
            }
            return false;
        }

        public static bool IsLicenseExists(int LicenseID)
        {
            return clsLicensesDAL.IsLicenseExists(LicenseID);
        }

        public static bool IsLicenseExistsByLocalDrivingLicenseID(int LDLAID)
        {
            return clsLicensesDAL.IsLicenseExistsByLocalDrivingAppID(LDLAID);
        }

        public static bool Is_LicenseExpired(int LicenseID)
        {
            return clsLicensesDAL.IsLicenseExpired(LicenseID);
        }

        public static bool IsActiveLicense(int LicenseID)
        {
            return clsLicensesDAL.IsLicenseActive(LicenseID);
        }

        public static bool IsLicenseClassExistsForLicense(int LicenseID,clsLicenseClassesBL.enLicenseClass x)
        {
            return clsLicensesDAL.IsSelectedClass_ExistsForLicense(LicenseID,(int)x);
        }

    }
}
