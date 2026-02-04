using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_BusinessLayer
{
    public class clsPeopleBL
    {
        enum peopleMode
        {
            AddNew, Update,Progress
        }
        peopleMode Mode = new peopleMode();
        public int PersonID { get; set; }
        public string NationalNo { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public int Gendor { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int NationalityCountryID { get; set; }

        public clsCountriesBL CountryInfo;

        public clsPeopleBL()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.Gendor = -1;
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            Mode = peopleMode.AddNew;
        }
        private clsPeopleBL(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName,string LastName,
                 DateTime DateOfBirth,int Gendor,string Address,string Phone,string Email,int NationalityCountryID,string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo=NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.Gendor = Gendor;
            this.DateOfBirth =DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath=ImagePath;
            this.CountryInfo = clsCountriesBL.Find(NationalityCountryID);
            Mode = peopleMode.Update;
        }

        public static clsPeopleBL FindByPersonID(int PersonID)
        {
           string FirstName = "",NationalNo="",SecondName="",ThirdName="", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            int NationalityCountryID = -1, Gendor = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleDAL.GetPeopleInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
          ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeopleBL(PersonID, NationalNo, FirstName, SecondName,ThirdName,LastName,
                 DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath);
            }
            else
            {
                return null;
            }

        }

        public static clsPeopleBL FindByNationalNo(string NationalNo)
        {
            string FirstName = "",SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            int NationalityCountryID = -1, Gendor = -1,PersonID=-1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleDAL.GetPeopleInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
          ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeopleBL(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                 DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetSpecificPeople()
        {
            return clsPeopleDAL.GetSpecificPeople();
        }

        public static DataTable GetPeopleTable()
        {
            return clsPeopleDAL.GetPeopleTable();
        }

        public static bool DeletePeople(int PersonID)
        {
            return clsPeopleDAL.DeletePeople(PersonID);
        }

        private bool _AddNewPeople()
        {
            this.PersonID = clsPeopleDAL.AddNewPeople(this.NationalNo,this.FirstName,this.SecondName,this.ThirdName,this.LastName,
                this.DateOfBirth,this.Gendor,this.Address,this.Phone,this.Email,this.NationalityCountryID,this.ImagePath);
            return (this.PersonID != -1);
        }

        private bool _UpdatePeople()
        {
            return clsPeopleDAL.UpdatePeople(this.PersonID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case peopleMode.AddNew:
                    if (_AddNewPeople())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case peopleMode.Update:
                    return _UpdatePeople();
                default:
                    break;
            }
            return false;
        }

        public static bool IsPeopleExists(int PersonID)
        {
            return clsPeopleDAL.IsPeopleExists(PersonID);
        }

        public static bool IsPeopleExists(string NationalNo)
        {
            return clsPeopleDAL.IsPeopleExists(NationalNo);
        }

    }
}
