using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsUsersBL
    {

        enum UserMode
        {
            AddUser,UpdateUser
        }
        UserMode Mode = new UserMode();
        public clsPeopleBL PeopleInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
        public int PersonID {get; set; }    

        public clsUsersBL()
        {
            this.UserID = -1;
            this.PersonID = PersonID;
            this.Password = "";
            this.UserName = "";
            this.IsActive = false;
            this.PeopleInfo = new clsPeopleBL();
            Mode = UserMode.AddUser;
        }

        private clsUsersBL(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {
            this.Password=Password;
            this.UserID=UserID;
            this.UserName=UserName;
            this.IsActive=IsActive;
            this.PersonID = PersonID;
            this.PeopleInfo = clsPeopleBL.FindByPersonID(PersonID);
            Mode = UserMode.UpdateUser;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersDAL.AddNewPeople(this.UserName,ComputeHash(this.Password), this.IsActive, this.PersonID);
            return (this.UserID != -1);
        }

        private bool _UpdateUsers()
        {
            return clsUsersDAL.UpdateUsers(this.UserID,this.PersonID,this.UserName,ComputeHash(this.Password),this.IsActive);
        }

        private bool _UpdatePassword()
        {
            return clsUsersDAL.UpdatPassword(this.UserID,this.Password);
        }
        public static DataTable GetUsersTable()
        {
            return clsUsersDAL.GetUsersTable();
        }

        public static DataTable GetUsersPeopel_Table()
        {
            return clsUsersDAL.GetUsers_People_Table();
        }

        public static clsUsersBL FindbyUserID(int UserID)
        {
            string UserName = "", Password = "";
            int PersonID = -1;
            bool IsActive = false;

            if(clsUsersDAL.GetUserInfoInfoByUserID(UserID,ref UserName,ref Password, ref PersonID,ref IsActive))
            {
                return new clsUsersBL(UserID,PersonID,UserName,Password,IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUsersBL FindbyPersonID(int PersonID)
        {
            string UserName = "", Password = "";
            int UserID = -1;
            bool IsActive = false;

            if (clsUsersDAL.GetUserInfoInfoByPersonID(PersonID,ref UserName,ref Password,ref UserID,ref IsActive))
            {
                return new clsUsersBL(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUsersBL FindbyUserName_Password(string UserName,string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if (clsUsersDAL.GetUserByUserNameAndPassWord(UserName,Password,ref PersonID,ref UserID,ref IsActive))
            {
                return new clsUsersBL(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUsersBL FindbyUserName(string UserName)
        {
            string  Password = "";
            int PersonID = -1,UserID=-1;
            bool IsActive = false;

            if (clsUsersDAL.GetUserInfoInfoByUserName(UserName, ref UserID, ref Password, ref PersonID, ref IsActive))
            {
                return new clsUsersBL(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
        public bool Save(bool with_Pass=false)
        {
            switch (Mode)
            {
                case UserMode.AddUser:
                    return _AddNewUser();

                case UserMode.UpdateUser:
                    if (!with_Pass) {
                        return _UpdateUsers();
                    }
                    else
                    {
                        return _UpdatePassword();
                    }
                        default:
                    break;
            }
            return false;
        }

        public static bool IsUserExists(int UserID)
        {
            return clsUsersDAL.IsUserExists(UserID);
        }

        public static bool IsUserExists(string UserName)
        {
            return clsUsersDAL.IsUserExists(UserName);
        }

        public static bool IsUserExists_ForPerson(int PersonID)
        {
            return clsUsersDAL.IsUserExistsForPerson(PersonID);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersDAL.DeleteUser(UserID);
        }

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
            }
        }
    }
}
