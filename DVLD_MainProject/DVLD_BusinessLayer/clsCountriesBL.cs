using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountriesBL
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        private clsCountriesBL(int CountryID,string CountryName)
        {
            this.CountryName = CountryName;
            this.CountryID = CountryID;
        }

        public static clsCountriesBL Find(int CountryID)
        {
            string CountryName="";
            if (clsCountriesDAL.GetCountryInfoByID(CountryID, ref CountryName))
                return new clsCountriesBL(CountryID, CountryName);
            else
                return null;
        }

        public static clsCountriesBL Find(string CountryName)
        {
            int CountryID = -1;
            if(clsCountriesDAL.GetCountryInfoByName(CountryName,ref CountryID)) 
                return new clsCountriesBL(CountryID,CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDAL.GetCountries();
        }
    }
}
