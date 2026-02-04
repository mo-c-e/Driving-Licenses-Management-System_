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

namespace DVLD_WindowsForms.Licenses
{
    public partial class frmRenewLicense : Form
    {
        int _LicenseID;
        clsLicenseBL _LicenseInfo;
        clsLicenseBL NewLicense;
        public frmRenewLicense()
        {
            InitializeComponent();
            
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            ucLicenseInfoWithFilter1.ResetMode(clsUtil.enFilterMode.RenewLicense);
        }

        private void ucLicenseInfoWithFilter1_OnPersonSelected(int obj)
        {
            _LicenseID = obj;
            if (clsLicenseBL.Is_LicenseExpired(obj) && clsLicenseBL.IsActiveLicense(obj))
            { 
            Enable_BuRenew(true);
            _LicenseInfo = clsLicenseBL.FindByLicenseID(_LicenseID);
            ucRenewApplicationInfo1.FillInfo(_LicenseID, _LicenseInfo.ExpirationDate);
        }

        }

        private void Enable_BuRenew(bool enable)
        {
            buRenew.Enabled = enable;
        }

        private void buRenew_Click(object sender, EventArgs e)
        {
           
            RenewLicense();
            linkLicenseInfo.Enabled = true;
            
        }

        private void RenewLicense()
        {
            clsUsersBL User = clsUsersBL.FindbyUserName(Properties.Settings.Default.UserName);
             NewLicense = _LicenseInfo.RenewLicense(ucRenewApplicationInfo1.Notes,User.UserID);
            if(NewLicense!=null)
            {
                MessageBox.Show($"License Renewd Successfully With ID {NewLicense.LicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucRenewApplicationInfo1.FillNew_App_License_ID(NewLicense.LicenseID);
            }
            else
               MessageBox.Show("Unable Saving Info");

        }

     

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo Info = new frmLicenseInfo(NewLicense.LicenseID);
            Info.ShowDialog();
        }

        private void linkLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenseBL TempLicense = clsLicenseBL.FindByLicenseID(_LicenseID);
            if (TempLicense == null)
                return;
            frmLicenseHistory History = new frmLicenseHistory(TempLicense.ApplicationInfo.PersonInfo.NationalNo);
            History.ShowDialog();
        }

        private void ucLicenseInfoWithFilter1_OnPersonSel(bool obj)
        {
            linkLicensesHistory.Enabled= obj;
        }
    }
}
