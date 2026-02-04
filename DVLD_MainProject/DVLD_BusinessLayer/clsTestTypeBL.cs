using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestTypeBL
    {
       public int TestTypeID { get; set; }
         public string TestTypeTitle { get; set; }

       public  string TestTypeDescription { get; set; }
       public float TestTypeFees { get; set; }

        public clsTestTypeBL()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = -1;
        }

        private clsTestTypeBL(int TestTypeID,string TestTypeTitle,string TestTypeDescription,float TestTypeFees)
        {
            this.TestTypeID= TestTypeID;
            this.TestTypeTitle= TestTypeTitle;
            this.TestTypeDescription= TestTypeDescription;
            this.TestTypeFees= TestTypeFees;
        }

        public static DataTable GetTestType()
        {
            return clsTestTypeDAL.GetTestTypes();
        }

        public static clsTestTypeBL FindTestType(int TestTypeID)
        {
            string Title = "", Description = "";
            float Fees = -1;
            if (clsTestTypeDAL.FindTestTypeByID(TestTypeID, ref Title, ref Description, ref Fees))
                return new clsTestTypeBL(TestTypeID, Title, Description, Fees);
            else
                return null;
        }

        public bool UpdateTestType()
        {
            return clsTestTypeDAL.UpdateTestTypes(this.TestTypeID,this.TestTypeTitle,this.TestTypeDescription,this.TestTypeFees);
        }
    }
}
