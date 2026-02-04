using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClassesBL
    {
        public enum enLicenseClass
        {
            Class1=1, Class2, Class3, Class4, Class5, Class6, Class7
        }
        public int LicenseClassID { get; set; }
            public string ClassName { get; set; }
          public string ClassDescription { get; set; }
         public byte MinimumAllowedAge { get; set; }
         public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClassesBL()
            {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = -1;
            }

            private clsLicenseClassesBL(int LicenseClassID, string ClassName,string ClassDescription,byte MinimumAllowedAge,byte DefaultValidityLength,float ClassFees)
            {
            this.LicenseClassID =LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

            public static DataTable GetLicenseClasses()
            {
                return clsLicenseClassesDAL.GetLicenseClasses();
            }

        public static clsLicenseClassesBL FindLicenseClasses(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinAge = 0, DefaultLenght = 0;
            float ClassFees = 0;

            if (clsLicenseClassesDAL.FindLicsenseClssByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinAge, ref DefaultLenght, ref ClassFees))
                return new clsLicenseClassesBL(LicenseClassID,ClassName,ClassDescription,MinAge,DefaultLenght,ClassFees);
            else
                return null;
        }

        public bool UpdateAppType()
        {
            return clsLicenseClassesDAL.UpdateLicensesClasses(this.LicenseClassID,this.ClassName,this.ClassDescription,this.MinimumAllowedAge,this.DefaultValidityLength,this.ClassFees);
        }
    }
}
