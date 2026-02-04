using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.International_Licenses
{
    public partial class frmInternationalLicenseInfo : Form
    {
        int _InernationalLicenseID;
        public frmInternationalLicenseInfo(int ILD)
        {
            InitializeComponent();
            _InernationalLicenseID = ILD;
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ucInternationlLicenseInfo1.FillInfo(_InernationalLicenseID);
        }

        private void pbTestTypeImage_Click(object sender, EventArgs e)
        {

        }
    }
}
