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
    public partial class frmLicenseInfo : Form
    {
        int _LicenseID;
        int _mode;
        public frmLicenseInfo(int LicenseID,int mode=-1)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            _mode = mode;

        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {

            if (_mode != -1)
                ucLicenseInfo1.FillForm_UsingLocalDLAppID(_LicenseID);
            else
                ucLicenseInfo1.FillForm_UsingLicenseID(_LicenseID);
        }
    }
}
