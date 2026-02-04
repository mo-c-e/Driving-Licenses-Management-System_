using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseAppBL : clsApplicationBL
    {
       public int LocalDrivingLicenseApplicationID { get; set; }
     
       public int LicenseClassID { get; set; }

      public  clsLicenseClassesBL LicenseClassesInfo;

       public clsApplicationBL ApplicationInfo;

        enum enMode
        {
            AddNew, Update
        }
        enMode CurrentMode = enMode.AddNew;
        public clsLocalDrivingLicenseAppBL()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            CurrentMode= enMode.AddNew;
        }

        private clsLocalDrivingLicenseAppBL(int LocalDrivingLicenseApplicationID, int ApplicationID,int LicenseClassID,int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID; 
            this.ApplicationID = ApplicationID;
            this.LicenseClassID= LicenseClassID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate= LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            LicenseClassesInfo = clsLicenseClassesBL.FindLicenseClasses(this.LicenseClassID);
            ApplicationInfo = clsApplicationBL.FindByApplicationID(this.ApplicationID);
            CurrentMode= enMode.Update;
        }

        public static DataTable GetLocalDrivingLicenseAppTable()
        {
            return clsLocalDrivingLicenseAppDAL.GetLocalLicenseAppTable();
        }

        public static DataTable GetLocalDrivingLicenseAppView()
        {
            return clsLocalDrivingLicenseAppDAL.GetLocalLiecenseAppView();
        }

        public static clsLocalDrivingLicenseAppBL FindByLocalDrivingLicenseAppID(int LocalDrivingLicenseApplicationID)
        {
            int AppID = -1, LicenseID = -1;


            if (clsLocalDrivingLicenseAppDAL.GetLocalLicenseAppBy_ID(LocalDrivingLicenseApplicationID,ref AppID,ref LicenseID))
            {

                clsApplicationBL Application = clsApplicationBL.FindByApplicationID(AppID);
                return new clsLocalDrivingLicenseAppBL(LocalDrivingLicenseApplicationID, Application.ApplicationID, LicenseID,Application.ApplicantPersonID,Application.ApplicationDate
                    ,Application.ApplicationTypeID,Application.ApplicationStatus,Application.LastStatusDate,Application.PaidFees,Application.CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static bool DeleteLocalDrivingLicenseApp(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppDAL.DeleteLocalLicenseApp(LocalDrivingLicenseApplicationID);
        }

        private bool _AddNewLocalDrivingLicenseApp()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseAppDAL.AddNewLocalLicenseApp(this.ApplicationID,this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateNewLocalDrivingLicenseApp()
        {
            return clsLocalDrivingLicenseAppDAL.UpdateLocalLicenseApp(this.LocalDrivingLicenseApplicationID,this.ApplicationID,this.LicenseClassID);
        }

        public bool LocalDrivingAppSave()
        {
            base.CurrentMode = (clsApplicationBL.enMode)CurrentMode;
            if (!base.Save())
                return false;

            switch (CurrentMode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApp())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateNewLocalDrivingLicenseApp();
                default:
                    break;
            }
            return false;
        }

        public static bool IsLocalDrivingLicenseAppExists(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppDAL.IsLocalLicenseAppExists(LocalDrivingLicenseApplicationID);
        }

        public static bool IsClassExists(int LicenseClassID, string NationalNo)
        {
            return clsLocalDrivingLicenseAppDAL.IsClassSelected(LicenseClassID,NationalNo);
        }

        public static int GetStatus(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppDAL.GetStatus(LocalDrivingLicenseApplicationID);
        }

        public static bool IsLocalLicenseAppCancelled(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppDAL.IsLocalLicenseAppCancelled(LocalDrivingLicenseApplicationID);
        }
    }
}
