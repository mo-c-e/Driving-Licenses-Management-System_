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
    public partial class ucRenewApplicationInfo : UserControl
    {
        int _LicenseID;
        public string Notes
        {
            get { return tbNotes.Text; }
            set {  tbNotes.Text = value; }
        }  
       // public float Total { set; get; }
        public ucRenewApplicationInfo()
        {
            InitializeComponent();
        }

        private void laFees_Click(object sender, EventArgs e)
        {

        }

        private void ucRenewApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void FillInfo(int LicenseID,DateTime ExpiryDate)
        {
            _LicenseID=LicenseID;
            clsLicenseBL LicenseInfo = clsLicenseBL.FindByLicenseID(_LicenseID);
            // 2 Stands For Renew
            clsAppTypesBL AppType = clsAppTypesBL.Find(2);
            if (LicenseInfo == null || AppType == null)
            {
                MessageBox.Show("Null Vales");
            }
            float Total = AppType.ApplicationFees + LicenseInfo.LicenseClassInfo.ClassFees;

            laApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            laIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            laAppFees.Text = AppType.ApplicationFees.ToString();
            laLicenseFees.Text = LicenseInfo.LicenseClassInfo.ClassFees.ToString();
            laTotalFees.Text = Total.ToString();
            laUser.Text = Properties.Settings.Default.UserName;
            laExpirationDate.Text = ExpiryDate.ToString("dd/MM/yyyyy");
            laOldLicenseID.Text= _LicenseID.ToString();
        }

        public void FillNew_App_License_ID(int NewLicenseID)
        {
            clsLicenseBL License = clsLicenseBL.FindByLicenseID(NewLicenseID);
            if (License == null)
                return;
            laILApplicationID.Text= License.ApplicationID.ToString();
            laRenewedLicenseID.Text= License.LicenseID.ToString();
        }

        private void tbNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // This blocks the key
            }
        }
    }
}
