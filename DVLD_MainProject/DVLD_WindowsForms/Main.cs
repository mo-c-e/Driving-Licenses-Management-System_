using DVLD_BusinessLayer;
using DVLD_WindowsForms.Application_Types;
using DVLD_WindowsForms.Drivers;
using DVLD_WindowsForms.Global_Classes;
using DVLD_WindowsForms.International_Licenses;
using DVLD_WindowsForms.Licenses;
using DVLD_WindowsForms.Licenses.Detained_Licenses;
using DVLD_WindowsForms.Local_Driving_License_Application;
using DVLD_WindowsForms.Tests_Types;
using DVLD_WindowsForms.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms
{
    public partial class Main : Form
    {
        clsUsersBL _CurrentUser;
        int _UserID;
        public Main(int UserID)
        {
            InitializeComponent();
           this._UserID = UserID;
            
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _CurrentUser = clsUsersBL.FindbyUserID(_UserID);
            SavedLogin_Users.UserName = _CurrentUser.UserName;
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
             
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManagePeople ManagePeopleForm = new ManagePeople();
            ManagePeopleForm.MdiParent = this;
            ManagePeopleForm.Show();
        }

        private void applicationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Not Implemented yet");
            Show_User_Info info = new Show_User_Info(_UserID);
            info.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers manageUsers = new frmManageUsers();
            manageUsers.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

           
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frm_ChangePassword changePassword = new frm_ChangePassword(_UserID);
            changePassword.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageAppType ApplicationType = new frmManageAppType();
            ApplicationType.ShowDialog();
        }

        private void manageTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes TestType= new frmManageTestTypes();
            TestType.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage_LocalDrivingLicenseApplication LDLA = new frmManage_LocalDrivingLicenseApplication(_CurrentUser.UserID);
            LDLA.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmManageDrivers Driver = new frmManageDrivers();
            Driver.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicenseApplication LDA = new frmAddLocalDrivingLicenseApplication(this._UserID);
            LDA.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationlLicense Interntional= new frmAddInternationlLicense();
            Interntional.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses MIL= new frmManageInternationalLicenses();
            MIL.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense RenewLicense = new frmRenewLicense();
            RenewLicense.ShowDialog();
        }

        private void replacemntLostOrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacmentLicense Replacment = new frmReplacmentLicense();
            Replacment.ShowDialog();
        }

        private void manangeDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicensesList DetainedLlist = new frmDetainedLicensesList();
            DetainedLlist.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense DLicense = new frmDetainLicense();
            DLicense.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense Release = new frmReleaseDetainedLicense();
            Release.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense RDL= new frmReleaseDetainedLicense();
            RDL.ShowDialog();
        }
    }
}
