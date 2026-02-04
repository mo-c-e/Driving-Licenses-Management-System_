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

namespace DVLD_WindowsForms.UserControls
{
    public partial class ucInternationlLicenseInfo : UserControl
    {
        int _LicenseID;
        public ucInternationlLicenseInfo()
        {
            InitializeComponent();
        }

        private void ucInternationlLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        public void FillInfo(int ILD)
        {
            _LicenseID= ILD;
            clsInternationalLicensesBL InterLID = clsInternationalLicensesBL.FindByInternationalLicenseID(ILD);
            if (InterLID == null)
                return;

            string FullName = InterLID.ApplicationInfo.PersonInfo.FirstName + " " + InterLID.ApplicationInfo.PersonInfo.SecondName + " " + InterLID.ApplicationInfo.PersonInfo.ThirdName == null ? " " : InterLID.ApplicationInfo.PersonInfo.ThirdName + " " +
                InterLID.ApplicationInfo.PersonInfo.LastName;
            laName.Text = FullName;
            laILD.Text= InterLID.InternationalLicenseID.ToString();
            laLicenseID.Text= InterLID.IssuedUsingLocalLicenseID.ToString();
            laNationalNo.Text = InterLID.ApplicationInfo.PersonInfo.NationalNo;
            laGender.Text = InterLID.ApplicationInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            laIssueDate.Text= InterLID.IssueDate.ToString("dd/MM/yyyy");
            laApplicationID.Text= InterLID.ApplicationID.ToString();
            laIsActive.Text= InterLID.IsActive.ToString();
            laDateofBirth.Text = InterLID.ApplicationInfo.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            laDriverID.Text= InterLID.DriverID.ToString();
            laExpirationDate.Text = InterLID.ExpirationDate.ToString("dd/MM/yyyy");
            pbPersonImage.Image = InterLID.ApplicationInfo.PersonInfo.ImagePath == "" ? (laGender.Text=="Male" ? Resources.Male_512 : Resources.Female_512) : (Image.FromFile(InterLID.ApplicationInfo.PersonInfo.ImagePath));
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
