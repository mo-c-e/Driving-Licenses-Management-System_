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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_WindowsForms.Local_Driving_License_Application
{
    public partial class frmAddLocalDrivingLicenseApplication : Form
    {
        int _PersonID;
        int _UserID;
        string _NationalNo;
        int _LocalDrivingLicenseAppID;
        clsUsersBL _CurrentUser;
       // clsApplicationBL _CurrentApplication;
        clsLocalDrivingLicenseAppBL _LocalDLApp;
        clsPeopleBL Person;
        enum enMode
        {
            enAddNew,enUpdate
        }
        enMode Mode= enMode.enAddNew;
        public frmAddLocalDrivingLicenseApplication(int userID, int localDrivingLicenseAppID=-1,int PerosnID=-1)
        {
            InitializeComponent();
            _UserID = userID;
            _PersonID = PerosnID;
            if(localDrivingLicenseAppID!=-1)
            {
                _LocalDrivingLicenseAppID = localDrivingLicenseAppID;
                Mode = enMode.enUpdate;
                laAdd_Edit.Text = "Edit Local Driving License Application";
            }
            ucPersonInfo_WithFilter1.LoaducWithFilter_PersonID(_PersonID);
            
           
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void laAdd_Edit_Click(object sender, EventArgs e)
        {

        }

        private void frmAddLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            UploadLicenseClasses();

            FillApplicationInfo();
        }

        private void UploadLicenseClasses()
        {
            DataTable dtLC = clsLicenseClassesBL.GetLicenseClasses().DefaultView.ToTable(false,"ClassName");
            foreach (DataRow row in dtLC.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }
            cbLicenseClasses.SelectedIndex = 0;
           
        }

        private void FillApplicationInfo()
        {
            switch (Mode)
            {
                case enMode.enAddNew:
                _LocalDLApp = new clsLocalDrivingLicenseAppBL();
                _CurrentUser = clsUsersBL.FindbyUserID(_UserID);
                laAppDate.Text = DateTime.Now.ToString(("dd/MM/yyyy"));
                    laUser.Text = _CurrentUser.UserName;
                laAppFees.Text = clsUtil.ApplicationFeesByService(1).ToString();
                    laAdd_Edit.Text = "New Local Driving License Application";
                    break;
            case enMode.enUpdate:
                _LocalDLApp = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseAppID);
                    _CurrentUser = clsUsersBL.FindbyUserID(_UserID);
                     Person = clsPeopleBL.FindByPersonID(_PersonID);
                    _NationalNo = Person.NationalNo;
                    laDLAppID.Text = _LocalDLApp.LocalDrivingLicenseApplicationID.ToString();
                    laAppDate.Text = _LocalDLApp.ApplicationInfo.ApplicationDate.ToString("dd/MM/yyyy");
                    laUser.Text = _LocalDLApp.ApplicationInfo.CreatedByUserID.ToString();
                    laAppFees.Text = _LocalDLApp.ApplicationInfo.PaidFees.ToString();
                    cbLicenseClasses.SelectedIndex = _LocalDLApp.LicenseClassID - 1;
                    laAdd_Edit.Text = "Update Local Driving License Application";
                    break;
            }
        
        }

        private void buNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private bool IsLincenseClassExists()
        {
            return (clsLocalDrivingLicenseAppBL.IsClassExists(cbLicenseClasses.SelectedIndex + 1, _NationalNo));
           
        }

        private void SaveData()
        {
            if (Mode == enMode.enAddNew)
            {
                _LocalDLApp.ApplicantPersonID = _PersonID;
                _LocalDLApp.ApplicationDate = DateTime.Now;
                _LocalDLApp.ApplicationTypeID = 1;
               
                _LocalDLApp.PaidFees = Convert.ToSingle(laAppFees.Text);
                _LocalDLApp.CreatedByUserID = _CurrentUser.UserID;
                _LocalDLApp.ApplicationStatus = 1;
            }
            _LocalDLApp.LastStatusDate = DateTime.Now;
            _LocalDLApp.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;
                if (_LocalDLApp.LocalDrivingAppSave())
                {
                    MessageBox.Show("Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    laDLAppID.Text = _LocalDLApp.LocalDrivingLicenseApplicationID.ToString();
                ChangeMode();
                }
                else
                {
                    MessageBox.Show("Unable to Save Data", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
        }

       

        private void ucPersonInfo_WithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void ucPersonInfo_WithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
             Person= clsPeopleBL.FindByPersonID(obj);
            _NationalNo=Person.NationalNo;
        }
        private void ChangeMode()
        {
            Mode=enMode.enUpdate;
            _LocalDLApp = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID(_LocalDLApp.LocalDrivingLicenseApplicationID);
            laAdd_Edit.Text = "Update Local Driving License Application";
        }

        private void buSave_Click(object sender, EventArgs e)
        {

            if (IsLincenseClassExists())
            {
                MessageBox.Show($"You Aleardy Have an application on ID :{_PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveData();
        }
    }
}
