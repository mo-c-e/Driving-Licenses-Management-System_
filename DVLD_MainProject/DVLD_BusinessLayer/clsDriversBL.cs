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
    public class clsDriversBL
    {
        enum eMode
        {
            AddNew, Update
        }
        eMode Current_Mode = new eMode();
        public int DriverID { get; set; }
       public int PersonID { get; set; }
      public  int CreatedByUserID { get; set; }
      public DateTime CreatedDate { get; set; }

        public clsPeopleBL PersonInfo;
        public clsUsersBL UsersInfo;

        public clsDriversBL()
        {
            this.PersonID = -1;
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Current_Mode = eMode.AddNew;
        }
        private clsDriversBL(int DriverID,int PersonID,int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID=DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPeopleBL.FindByPersonID(this.PersonID);
            this.UsersInfo = clsUsersBL.FindbyUserID(this.CreatedByUserID);
            Current_Mode = eMode.Update;
        }

        public static clsDriversBL FindByDriverID(int DriverID)
        {
           int personID=-1,createdByUserID=-1;
            DateTime createdDate=DateTime.Now;

            if (clsDriversDAL.GetDriversByID(DriverID,ref personID,ref createdByUserID,ref createdDate))
            {
                return new clsDriversBL(DriverID,personID,createdByUserID,createdDate);
            }
            else
            {
                return null;
            }

        }

        public static clsDriversBL FindByPersonID(int PersonID)
        {
            int driverid = -1, createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDriversDAL.GetDriversByPersonID(ref driverid,PersonID,ref createdByUserID,ref createdDate))
            {
                return new clsDriversBL(driverid, PersonID, createdByUserID, createdDate);
            }
            else
            {
                return null;
            }

        }


        public static DataTable GetDriversTable()
        {
            return clsDriversDAL.GetDriversTable();
        }

        public static bool DeleteDriver(int DriverID)
        {
            return clsDriversDAL.DeleteDriver(DriverID);
        }

        private bool _AddNewDriver()
        {
            this.DriverID =clsDriversDAL.AddNewDriver(this.PersonID,this.CreatedByUserID,this.CreatedDate);
            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriversDAL.UpdateDriver(this.DriverID,this.PersonID,this.CreatedByUserID,this.CreatedDate);
        }

        public bool Save()
        {
            switch (Current_Mode)
            {
                case eMode.AddNew:
                    return _AddNewDriver();
                case eMode.Update:
                    return _UpdateDriver();
                default:
                    break;
            }
            return false;
        }

        public static bool IsDriverExists(int DriverID)
        {
            return clsDriversDAL.IsDriverExists(DriverID);
        }

        public static bool IsDriverExistsByPersonID(int PersonID)
        {
            return clsDriversDAL.IsDiverExistsByPersonID (PersonID);
        }
    }
}
