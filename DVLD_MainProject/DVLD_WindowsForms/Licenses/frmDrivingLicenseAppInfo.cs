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
    public partial class frmDrivingLicenseAppInfo : Form
    {
        int _LocalDrivingApplicationID;
        public frmDrivingLicenseAppInfo(int LocalDrivingApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingApplicationID = LocalDrivingApplicationID;
        }

        private void frmDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {
            ucDrivingLicenseAppInfo1.SetLocalDrivingLicenseID(this._LocalDrivingApplicationID);
          //  ucDrivingLicenseAppInfo1.SetPassedTests(clsTestsBL.CountPassedTests(this._LocalDrivingApplicationID));
        }
    }
}
