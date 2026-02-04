using DVLD_BusinessLayer;
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
    public partial class ucReplacmentApplicationInfo : UserControl
    {
       
        public ucReplacmentApplicationInfo()
        {
            InitializeComponent();
        }

        private void ucReplacmentApplicationInfo_Load(object sender, EventArgs e)
        {

        }
        public void Fill_LowerPart( clsLicenseBL License)
        {
            laApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyyy");
            laOldLicenseID.Text = License.LicenseID.ToString();
            laUser.Text = Properties.Settings.Default.UserName;
            
        }

        public void FillApplicatoinFees(int ApplicationTypeID)
        {
            clsAppTypesBL App = clsAppTypesBL.Find(ApplicationTypeID);
            if (App == null)
            {
                return;
            }
            laFees.Text= App.ApplicationFees.ToString();  

        }

        public void Fill_IDs(clsLicenseBL RenewedLicense)
        {
            laLRApplicationID.Text= RenewedLicense.ApplicationID.ToString();
            laReplacedLicenseID.Text = RenewedLicense.LicenseID.ToString();
        }
    }
}
