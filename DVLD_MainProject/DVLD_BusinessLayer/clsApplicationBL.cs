using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationBL
    {
       public enum enMode
        {
            AddNew, Update
        }
       public enMode CurrentMode = enMode.AddNew;
        public int ApplicationID { get; set; }
         public int ApplicantPersonID { get; set; }
       public DateTime ApplicationDate { get; set; }
       public int ApplicationTypeID { get; set; }
       public byte ApplicationStatus { get; set; }
      public  DateTime LastStatusDate { get; set; }
      public  float PaidFees { get; set; }
      public  int CreatedByUserID { get; set; }
       public clsPeopleBL PersonInfo;
      public  clsUsersBL UserInfo;
       public clsAppTypesBL ApplicatoinTypeInfo;

        public clsApplicationBL()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate= DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            CurrentMode = enMode.AddNew;
        }

        private clsApplicationBL(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonInfo = clsPeopleBL.FindByPersonID(ApplicantPersonID);
            this.UserInfo = clsUsersBL.FindbyUserID(CreatedByUserID);
            this.ApplicatoinTypeInfo = clsAppTypesBL.Find(ApplicationTypeID);
            CurrentMode = enMode.Update;
        }

        public static DataTable GetApplicationTable()
        {
            return clsApplicationDAL.GetApplicationTable();
        }

        public static clsApplicationBL FindByApplicationID(int ApplicationID)
        {
            int AppPersonID = -1, AppTypeID = -1,CreatedByUserID=-1;
           DateTime AppDate = DateTime.Now,LastStatusDate= DateTime.Now;
            byte AppStatus = 0;
            float Paidfee = -1;

            if (clsApplicationDAL.GetApplicationByID(ApplicationID,ref AppPersonID,ref AppDate,ref AppTypeID,ref AppStatus,ref LastStatusDate,ref Paidfee,ref CreatedByUserID))
            {
                return new clsApplicationBL(ApplicationID,AppPersonID,AppDate,AppTypeID,AppStatus,LastStatusDate,Paidfee,CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationDAL.DeleteApplication(ApplicationID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationDAL.AddNewApplication(this.ApplicantPersonID,this.ApplicationDate,this.ApplicationTypeID,this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationDAL.UpdateApplication(this.ApplicationID,this.ApplicantPersonID,this.ApplicationDate,this.ApplicationTypeID,this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (CurrentMode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateApplication();
                default:
                    break;
            }
            return false;
        }

        public static bool IsApplicationExists(int ApplicationID)
        {
            return clsApplicationDAL.IsApplicationExists(ApplicationID);
        }

        
    }
}
