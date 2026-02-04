using DVLD_BusinessLayer;
using DVLD_WindowsForms.Global_Classes;
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
    public partial class ucInternationalApplicationInfo : UserControl
    {
        int _InternationalLicenseID;
        public ucInternationalApplicationInfo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
             
        }

        public void LoadApplicationInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            clsInternationalLicensesBL International_License = clsInternationalLicensesBL.FindByInternationalLicenseID(_InternationalLicenseID);
            clsAppTypesBL ApplicationType = clsAppTypesBL.Find(International_License.ApplicationInfo.ApplicationTypeID);

            laILApplicationID.Text = International_License.ApplicationID.ToString();
            laApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            laIssueDate.Text= International_License.IssueDate.ToString("dd/MM/yyyy");
            laFees.Text = ApplicationType.ApplicationFees.ToString();
            laInternationalLicense.Text=International_License.InternationalLicenseID.ToString();
            lalocallicenseid.Text = International_License.IssuedUsingLocalLicenseID.ToString();
            laExpirationDate.Text = International_License.ExpirationDate.ToString();
            laUser.Text = SavedLogin_Users.UserName;

        }

        private void ucInternationalApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
