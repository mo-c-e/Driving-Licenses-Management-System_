using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DVLD_WindowsForms
{
    public class clsUtil 
    {
        public  enum enFilterMode
        {
            RenewLicense, IssueInternationalLicense, ReplacementLicense,DetainLicense,ReleaseLicense
        }
        public static enFilterMode FilterMode;
        private static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
        private static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if(!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
            return true;
        }

        private static string ReplaceFileNameWitGUID(string FileName)
        {
            string fn = FileName;
            FileInfo fi = new FileInfo(fn);
            string FileExtension = fi.Extension;
            return GenerateGUID() + FileExtension;
        }
        public static  bool CopyImageToProjectImagesFolder(ref string source)
        {
            string destination_Folder = @"C:\DVLD_Project\Photo_For_Users\";
            if (!CreateFolderIfDoesNotExist(destination_Folder))
            {
                return false;
            }
            string Destination_File = destination_Folder + ReplaceFileNameWitGUID(source);

            try
            {
                File.Copy(source, Destination_File, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            source = Destination_File;
            return true;

        }

        public static float ApplicationFeesByService(int ID)
        {
            clsAppTypesBL applicationBL = clsAppTypesBL.Find(ID);
            if (applicationBL == null)
            {
                return -1;
            }

            return applicationBL.ApplicationFees;
        }

        public static string GetApplicationStatus(int statusID)
        {
            switch(statusID)
            {
                case 1:
                    return "New";
                    case 2:
                    return "Cancelled";
                    case 3:
                    return "Completed";
                default:
                    return null;
            }
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
