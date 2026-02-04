using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsAppTypesBL
    {
       public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTile { get; set; }
        public float ApplicationFees { get; set; }

       public clsAppTypesBL()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTile = "";
            this.ApplicationFees = -1;
        }

        private clsAppTypesBL(int AppTypeID,string AppTypeTitle,float AppFees)
        {
            this.ApplicationTypeID=AppTypeID;
            this.ApplicationTypeTile = AppTypeTitle;
            this.ApplicationFees = AppFees;
        }

        public static DataTable GetAppTypes()
        {
            return clsAppTypesDAL.GetAppTypes();
        }

        public static clsAppTypesBL Find(int AppTypeID)
        {
            string AppTitle = "";
            float sqlMoney = -1;
            if (clsAppTypesDAL.FindByAppTypeID(AppTypeID, ref AppTitle, ref sqlMoney))
                return new clsAppTypesBL(AppTypeID,AppTitle,sqlMoney);
            else
                return null;
        }

        public bool UpdateAppType()
        {
            return clsAppTypesDAL.UpdateAppTypes(ApplicationTypeID,ApplicationTypeTile,ApplicationFees);
        }
    }
}
