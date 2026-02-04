using DVLD_BusinessLayer;
using DVLD_WindowsForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ucLicenseInfo : UserControl
    {
        int _LocalDrivingLicenseApplicatoinID;
        int _LicenseID;
        public ucLicenseInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        }

        private void ucLicenseInfo_Load(object sender, EventArgs e)
        {
            
        }
        public void FillForm_UsingLocalDLAppID(int LocalDrivingLicenseAppID)
        {
           
            _LocalDrivingLicenseApplicatoinID = LocalDrivingLicenseAppID;
            clsLicenseBL License = clsLicenseBL.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseApplicatoinID);
            if(License!=null)
            {
                clsAppTypesBL ApplicationType = clsAppTypesBL.Find(License.ApplicationInfo.ApplicationTypeID);
                clsPeopleBL Person = clsPeopleBL.FindByPersonID(License.ApplicationInfo.ApplicantPersonID);
                string FullName= Person.FirstName +" "+ Person.SecondName+" "+ (Person.ThirdName==null ? "" : Person.ThirdName) + " " + Person.LastName;



                laClass.Text = ApplicationType.ApplicationTypeTile;
                laName.Text = FullName;
                laLicenseID.Text = License.LicenseID.ToString();
                laNationalNo.Text = Person.NationalNo;
                laGender.Text = Person.Gendor == 0 ? "Male" : "Female";
                laDate.Text = License.IssueDate.ToString("dd/M/yyyy");
                switch(License.IssueReason)
                {
                    case 1:
                        laIssueReason.Text = "First Time";
                        break;
                    case 2:
                        laIssueReason.Text = "Renew";
                        break;
                    case 3:
                        laIssueReason.Text = "Replacment";
                        break;
                }
                laNotes.Text = License.Notes=="" ? "No Notes" : License.Notes;
                laIsActive.Text = License.IsActive == true ? "Yes" : "No";
                laDateOfBirth.Text = Person.DateOfBirth.ToString("dd/MM/yyyy");
                laDriverID.Text= License.DriverID.ToString();
                laExpirDate.Text = License.ExpirationDate.ToString("dd/MM/yyyy");
                laIsDetained.Text = clsDetainedLicensesBL.IsReleasedReturn(License.LicenseID) ? "No" : "Yes";
                _LoadImage(Person);
                pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            } 
        }

        public void FillForm_UsingLicenseID(int LicenseID)
        {
            if (LicenseID == -1)
            {
                EmptyInfo();
                return;
            }
            _LicenseID=LicenseID;
            clsLicenseBL License = clsLicenseBL.FindByLicenseID(_LicenseID);
            if (License != null)
            {
                clsAppTypesBL ApplicationType = clsAppTypesBL.Find(License.ApplicationInfo.ApplicationTypeID);
                clsPeopleBL Person = clsPeopleBL.FindByPersonID(License.ApplicationInfo.ApplicantPersonID);
                string FullName = Person.FirstName + " " + Person.SecondName + " " + (Person.ThirdName == null ? "" : Person.ThirdName) + " " + Person.LastName;



                laClass.Text = ApplicationType.ApplicationTypeTile;
                laName.Text = FullName;
                laLicenseID.Text = License.LicenseID.ToString();
                laNationalNo.Text = Person.NationalNo;
                laGender.Text = Person.Gendor == 0 ? "Male" : "Female";
                laDate.Text = License.IssueDate.ToString("dd/M/yyyy");
                switch (License.IssueReason)
                {
                    case 1:
                        laIssueReason.Text = "First Time";
                        break;
                    case 2:
                        laIssueReason.Text = "Renew";
                        break;
                    case 3:
                        laIssueReason.Text = "Replacment";
                        break;
                }
                laNotes.Text = License.Notes == "" ? "No Notes" : License.Notes;
                laIsActive.Text = License.IsActive == true ? "Yes" : "No";
                laDateOfBirth.Text = Person.DateOfBirth.ToString("dd/MM/yyyy");
                laDriverID.Text = License.DriverID.ToString();
                laExpirDate.Text = License.ExpirationDate.ToString("dd/MM/yyyy");
                laIsDetained.Text = clsDetainedLicensesBL.IsReleasedReturn(License.LicenseID) ? "No" : "Yes";
                _LoadImage(Person);
                pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void laIsDetained_Click(object sender, EventArgs e)
        {

        }

        private void EmptyInfo(string empty = "[????]")
        {
            laClass.Text = empty;
            laName.Text = empty;
            laLicenseID.Text = empty;
            laNationalNo.Text = empty;
            laGender.Text = empty;
            laDate.Text = empty;
            laIssueReason.Text = empty;
            laNotes.Text = empty;
            laIsActive.Text = empty;
            laDateOfBirth.Text = empty;
            laDriverID.Text =empty;
            laExpirDate.Text = empty;
            laIsDetained.Text = empty;
            pbPhoto.Image = null;
        }
        private void _LoadImage(clsPeopleBL Person)
        {
            pbPhoto.Image = Person.ImagePath == "" ? (Person.Gendor == 0 ? Resources.Male_512 : Resources.Female_512) : Image.FromFile(Person.ImagePath);

            if (Person.Gendor == 0)
                pbPhoto.Image = Resources.Male_512;
            else
                pbPhoto.Image = Resources.Female_512;

            string ImagePath = Person.ImagePath;

            if (ImagePath != "")
                
                if (File.Exists(ImagePath))
                    pbPhoto.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
