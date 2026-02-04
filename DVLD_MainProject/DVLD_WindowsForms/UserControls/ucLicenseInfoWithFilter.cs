using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ucLicenseInfoWithFilter : UserControl
    {
        enum enMode
        {
            RenewLicense,IssueInternationalLicense,ReplacementLicense,DetainLicense,ReleaseLicense
        }
        enMode _Mode;
        clsLicenseBL _License;
        public void ResetMode(clsUtil.enFilterMode fm)
        {
            switch (fm) 
            {
                case clsUtil.enFilterMode.RenewLicense:
                    _Mode = enMode.RenewLicense;
                    break;
                    case clsUtil.enFilterMode.IssueInternationalLicense:
                    _Mode = enMode.IssueInternationalLicense;
                    break;
                case clsUtil.enFilterMode.ReplacementLicense: 
                    _Mode=enMode.ReplacementLicense;
                    break;
                case clsUtil.enFilterMode.DetainLicense:
                    _Mode = enMode.DetainLicense;
                    break;
                case clsUtil.enFilterMode.ReleaseLicense:
                    _Mode = enMode.ReleaseLicense;
                    break;
            }

        }
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int LID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(LID);
            }
        }

        public event Action<bool> OnPersonSel;
        protected virtual void PersonSel(bool x)
        {
            Action<bool> handler = OnPersonSel;
            if (handler != null)
            {
                handler(x);
            }
        }

        public ucLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void buFindLicenseID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                errorProvider1.SetError(tbSearch, "Enter LicenseID");
                PersonSel(false);
                // -1 means empty
                ucLicenseInfo2.FillForm_UsingLicenseID(-1);
                return;
            }
            else
            {
                errorProvider1.SetError(tbSearch, null);
            }

            _License = clsLicenseBL.FindByLicenseID(Convert.ToInt32(tbSearch.Text));
           

            if (!clsLicenseBL.IsLicenseExists(Convert.ToInt32(tbSearch.Text)))
            {
                MessageBox.Show($"No License With ID {tbSearch.Text}", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PersonSel(false);
                ucLicenseInfo2.FillForm_UsingLicenseID(-1);
                return;
            }

            switch(_Mode) 
                {
                case enMode.IssueInternationalLicense:
                    if (!InternationalLicense(Convert.ToInt32(tbSearch.Text)))
                        return;
                      break;
                case enMode.RenewLicense:
                    if(!RenewLicnese(Convert.ToInt32(tbSearch.Text)))
                    return;
                    break;

                case enMode.ReplacementLicense:
                    if (!ReplacmentLicense(Convert.ToInt32(tbSearch.Text)))
                        return;
                    break;

                case enMode.DetainLicense: 
                    if (!DetainLicense(Convert.ToInt32(tbSearch.Text)))
                        return;
                    break;

                case enMode.ReleaseLicense:
                    if (!ReleaseLicense(Convert.ToInt32(tbSearch.Text)))
                        return;
                    break;
            }
           
            int x = Convert.ToInt32(tbSearch.Text);
            ucLicenseInfo2.FillForm_UsingLicenseID(x);
            PersonSelected(Convert.ToInt32(x));
            PersonSel(true);
            DisableFilter();
        }

        
        private void DisableFilter(bool enable=false)
        {
            tbSearch.Enabled = enable;
            buFindLicenseID.Enabled=enable;
        }

        private void ucLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
           
        }

        private bool RenewLicnese(int LicenseID)
        {

            if(!clsLicenseBL.Is_LicenseExpired(LicenseID))
            {
                MessageBox.Show($"Selected License Is Not Yet Expired, It Will Expire On : {_License.ExpirationDate}","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ucLicenseInfo2.FillForm_UsingLicenseID(LicenseID);
                PersonSel(true);
               PersonSelected(Convert.ToInt32(tbSearch.Text));
                return false;
            }
            if(!clsLicenseBL.IsActiveLicense(LicenseID))
            {
                MessageBox.Show("Selected License is not active.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
               // ucLicenseInfo2.FillForm_UsingLicenseID(LicenseID);
                PersonSel(false);
                PersonSelected(Convert.ToInt32(tbSearch.Text));
                return false;
            }

            return true;
                
        }

        private  bool ReplacmentLicense(int LicenseID)
        {
            if (!clsLicenseBL.IsActiveLicense(LicenseID))
            {
                MessageBox.Show("Selected License is not active.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfo2.FillForm_UsingLicenseID(LicenseID);
                PersonSel(false);
                PersonSelected(Convert.ToInt32(tbSearch.Text));
                return false;
            }
            return true;
        }

        private bool DetainLicense(int LicenseID)
        {
            if (!clsLicenseBL.IsActiveLicense(LicenseID))
            {
                MessageBox.Show("Selected License is not active.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfo2.FillForm_UsingLicenseID(LicenseID);
                PersonSel(false);
               // PersonSelected(Convert.ToInt32(tbSearch.Text));
                return false;
            }
            if (!clsDetainedLicensesBL.IsReleasedReturn(LicenseID))
            {
                MessageBox.Show("Selected License is already Detained, Choose another one.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfo2.FillForm_UsingLicenseID(LicenseID);
                PersonSel(false);
               // PersonSelected(Convert.ToInt32(tbSearch.Text));
                return false;
            }
            return true;
        }

        private bool ReleaseLicense(int LicenseID)
        {
            if (!clsLicenseBL.IsActiveLicense(LicenseID))
            {
                MessageBox.Show("Selected License is not active.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfo2.FillForm_UsingLicenseID(LicenseID);
                PersonSel(false);
                return false;
            }
            if (clsDetainedLicensesBL.IsReleasedReturn(LicenseID))
            {
                MessageBox.Show("Selected License is not Detained, Choose another one.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfo2.FillForm_UsingLicenseID(LicenseID);
                PersonSel(false);
                return false;
            }
            return true;
        }

        private bool InternationalLicense(int LicenseID)
        {
            if (clsInternationalLicensesBL.IsInternationalLicenseExistsByLocalLicense(LicenseID))
            {
                MessageBox.Show($"Person already have an active international license with ID= {tbSearch.Text}", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!clsLicenseBL.IsActiveLicense(LicenseID))
            {
                MessageBox.Show("Selected License is not active.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!clsLicenseBL.IsLicenseClassExistsForLicense(LicenseID,clsLicenseClassesBL.enLicenseClass.Class3))
            {
                MessageBox.Show("Allowing Only International License of Class 3 .", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public void AutoClick(int LicenseID)
        {
            tbSearch.Text = LicenseID.ToString();
            DisableFilter();
            buFindLicenseID_Click(null,null);
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
