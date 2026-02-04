using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDetainedLicensesBL
    {
        enum enMode
        {
            AddNew,Update
        }
        enMode Mode = new enMode();
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public Nullable<DateTime> ReleaseDate { get; set; }
        public Nullable<int> ReleasedByUserID { get; set; }
        public Nullable<int> ReleaseApplicationID { get; set; }

        public clsUsersBL UserInfo;
        public clsLicenseBL LicenseInfo;

        public clsDetainedLicensesBL()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = -1;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = null;
            this.ReleasedByUserID = null;
            this.ReleaseApplicationID = null;
            Mode = enMode.AddNew;
        }

        private clsDetainedLicensesBL(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
            DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            this.DetainID= DetainID;
            this.LicenseID= LicenseID; 
            this.DetainDate= DetainDate;
            this.FineFees= FineFees;
            this.CreatedByUserID= CreatedByUserID;
            this.IsReleased= IsReleased;
            this.ReleaseDate= ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID= ReleaseApplicationID;
            this.UserInfo = clsUsersBL.FindbyUserID(CreatedByUserID);
            this.LicenseInfo = clsLicenseBL.FindByLicenseID(LicenseID);
            Mode = enMode.Update;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesDAL.IsLicenseDetained(LicenseID);
        }

        public static bool IsLicenseReleased(int LicenseID)
        {
            return clsDetainedLicensesDAL.IsLicenseReleased(LicenseID);
        }

        public static bool IsLicenseReleasedByDetainID(int DetainID)
        {
            return clsDetainedLicensesDAL.IsLicenseReleased_DetainID(DetainID);
        }

        public static DataTable DetainedLicensesView()
        {
            return clsDetainedLicensesDAL.GetDetainedLicensesView();
        }

        public static clsDetainedLicensesBL FindbyDetainID(int DetainID)
        {
            int LicenseID = -1;
            DateTime detaindate = DateTime.MinValue;
            float ff = -1;
            int createdbyuserid = -1;
            bool isreleased = false;
            DateTime? releasedate = null;
            int? releasebyuserid = null;
            int? releaseappid = null;

            if (clsDetainedLicensesDAL.GetDetainedLicenseInfoByID(DetainID,ref LicenseID,ref detaindate,ref ff,ref createdbyuserid,ref isreleased,ref releasedate,ref releasebyuserid,ref releaseappid))
            {
                return new clsDetainedLicensesBL(DetainID, LicenseID,  detaindate,ff,  createdbyuserid,  isreleased,  releasedate,  releasebyuserid,  releaseappid);
            }
            else
            {
                return null;
            }

        }

        public static clsDetainedLicensesBL FindbyDetainLicenseID(int LicenseID)
        {
            int detainID = -1;
            DateTime detaindate = DateTime.MinValue;
            float ff = -1;
            int createdbyuserid = -1;
            bool isreleased = false;
            DateTime? releasedate = null;
            int? releasebyuserid = null;
            int? releaseappid = null;

            if (clsDetainedLicensesDAL.GetDetainedLicenseInfoByLicenseID(LicenseID, ref detainID, ref detaindate, ref ff, ref createdbyuserid, ref isreleased, ref releasedate, ref releasebyuserid, ref releaseappid))
            {
                return new clsDetainedLicensesBL(detainID, LicenseID, detaindate, ff, createdbyuserid, isreleased, releasedate, releasebyuserid, releaseappid);
            }
            else
            {
                return null;
            }

        }

        public static clsDetainedLicensesBL FindLastDetainLicenseByID(int LicenseID)
        {
            int detainID = -1;
            DateTime detaindate = DateTime.MinValue;
            float ff = -1;
            int createdbyuserid = -1;
            bool isreleased = false;
            DateTime? releasedate = null;
            int? releasebyuserid = null;
            int? releaseappid = null;

            if (clsDetainedLicensesDAL.GetLastDetainedRecordByLicenseID(LicenseID, ref detainID, ref detaindate, ref ff, ref createdbyuserid, ref isreleased, ref releasedate, ref releasebyuserid, ref releaseappid))
            {
                return new clsDetainedLicensesBL(detainID, LicenseID, detaindate, ff, createdbyuserid, isreleased, releasedate, releasebyuserid, releaseappid);
            }
            else
            {
                return null;
            }

        }

        public static bool DeleteDetainedLicense(int DetainID)
        {
            return clsDetainedLicensesDAL.DeleteDetainedLicense(DetainID);
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicensesDAL.AddNewDetainedLicense(this.LicenseID,this.DetainDate,this.FineFees,this.CreatedByUserID,this.IsReleased,this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID);
            return (this.DetainID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesDAL.UpdateDetainedLicense(this.DetainID,this.LicenseID,this.DetainDate,this.FineFees,this.CreatedByUserID,this.IsReleased,this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                   return _AddNewDetainedLicense();
                case enMode.Update:
                    return _UpdateDetainedLicense();
                default:
                    break;
            }
            return false;
        }

        public static bool IsDetainedLicenseExists(int DetainID)
        {
            return clsDetainedLicensesDAL.IsDetainedLicenseExists(DetainID);
        }
        public static bool IsReleasedReturn(int LicenseID)
        {
            return clsDetainedLicensesDAL.IsRelease(LicenseID);
        }


    }
}
