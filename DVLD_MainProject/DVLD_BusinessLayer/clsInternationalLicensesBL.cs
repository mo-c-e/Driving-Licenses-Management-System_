using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicensesBL
    {
        enum enMode
        {
            AddNew,Update
        }
        enMode Mode = new enMode();
        public int InternationalLicenseID { get; set; }
        public int ApplicationID {  get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsApplicationBL ApplicationInfo;
        public clsDriversBL DriverInfo;
        public clsLicenseBL LocalLicenseInfo;
        public clsUsersBL UsersInfo;

        public clsInternationalLicensesBL()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID= -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private clsInternationalLicensesBL(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,  DateTime IssueDate,  DateTime ExpirationDate, bool IsActive,
            int CreatedByUserID)
        {
            this.InternationalLicenseID= InternationalLicenseID;
            this.ApplicationID= ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID= IssuedUsingLocalLicenseID;
            this.IssueDate= IssueDate;
            this.ExpirationDate= ExpirationDate;
            this.IsActive=IsActive;
            this.CreatedByUserID= CreatedByUserID;
            this.ApplicationInfo = clsApplicationBL.FindByApplicationID(this.ApplicationID);
            this.DriverInfo = clsDriversBL.FindByDriverID(this.DriverID);
            this.LocalLicenseInfo = clsLicenseBL.FindByLicenseID(this.IssuedUsingLocalLicenseID);
            this.UsersInfo = clsUsersBL.FindbyUserID(this.CreatedByUserID);
            Mode = enMode.Update;
        }

        public static DataTable GetInternationalLicensesTable()
        {
            return clsInternationalLicensesDAL.GetInternationalLicenseTable();
        }

        public static DataTable GetInternationalLicensesByNationalNo(string NationlNo)
        {
            return clsInternationalLicensesDAL.GetRecordByNationalNo(NationlNo);
        }

        public static clsInternationalLicensesBL FindByInternationalLicenseID(int InternationalLicenseID)
        {
            int AppTypeID = -1,DriverID=-1,LicenseID=-1, CreatedByUserID = -1;
             DateTime issueDate= DateTime.MinValue,expirationdate= DateTime.MinValue;
            bool isActive = false;

            if (clsInternationalLicensesDAL.FindInternationalLicenseByID(InternationalLicenseID,ref AppTypeID,ref DriverID,ref LicenseID,ref issueDate,ref expirationdate,ref isActive,ref CreatedByUserID))
            {
                return new clsInternationalLicensesBL(InternationalLicenseID,AppTypeID,DriverID,LicenseID,issueDate,expirationdate,isActive,CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            return clsInternationalLicensesDAL.DeleteInternationalLicense(InternationalLicenseID);
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesDAL.AddNewInternationalLicense(this.ApplicationID,this.DriverID,this.IssuedUsingLocalLicenseID,this.IssueDate,this.ExpirationDate,this.IsActive,this.CreatedByUserID);
            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationlLicense()
        {
            return clsInternationalLicensesDAL.UpdateInternationalLicense(this.InternationalLicenseID,this.ApplicationID,this.DriverID,this.IssuedUsingLocalLicenseID,this.IssueDate,this.ExpirationDate,this.IsActive,this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewInternationalLicense();
                case enMode.Update:
                    return _UpdateInternationlLicense();
                default:
                    break;
            }
            return false;
        }

        public static bool IsInternationalLicenseExists(int InternationalLicenseID)
        {
            return clsInternationalLicensesDAL.IsInternationalLicenseExists(InternationalLicenseID);
        }

        public static bool IsInternationalLicenseExistsByLocalLicense(int IssuedUsingLocalLicenseID)
        {
            return clsInternationalLicensesDAL.IsInternationalLicenseExistsByLocalLicense(IssuedUsingLocalLicenseID);
        }



    }
}
