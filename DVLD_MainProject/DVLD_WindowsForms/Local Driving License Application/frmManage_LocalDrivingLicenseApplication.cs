using DVLD_BusinessLayer;
using DVLD_WindowsForms.DrivingLicense;
using DVLD_WindowsForms.Licenses;
using DVLD_WindowsForms.Vision_Test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Local_Driving_License_Application
{
   
    public partial class frmManage_LocalDrivingLicenseApplication : Form
    {
        DataTable _dtLDLApp; 
        int _UserID;
        bool EnableClick= false;
        public frmManage_LocalDrivingLicenseApplication(int userId)
        {
            InitializeComponent();
            _UserID = userId;
            //None
            //L.D.L App ID
            //NationalNo
            //FullName
            //Status
        }

        private void frmLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _dtLDLApp=clsLocalDrivingLicenseAppBL.GetLocalDrivingLicenseAppView();
            dataGridView1.DataSource = _dtLDLApp;
            PrepareDataGridView();
        }
        private void PrepareDataGridView()
        {
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
            dataGridView1.Columns[0].HeaderText = "L.D.L ID";
            dataGridView1.Columns[0].Width = 100;

            dataGridView1.Columns[1].HeaderText = "Driving Class";
            dataGridView1.Columns[1].Width = 200;

            dataGridView1.Columns[2].HeaderText = "National No.";
            dataGridView1.Columns[2].Width = 110;

            dataGridView1.Columns[3].HeaderText = "FullName";
            dataGridView1.Columns[3].Width = 305;

            dataGridView1.Columns[4].HeaderText = "Application Date";
            dataGridView1.Columns[4].Width = 200;

            dataGridView1.Columns[5].HeaderText = "Passted Tests";
            dataGridView1.Columns[5].Width = 110;

            dataGridView1.Columns[6].HeaderText = "Status";
            dataGridView1.Columns[6].Width = 150;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.Text!="None")
            {
                tbFilter.Visible = true;
            }
            else 
                tbFilter.Visible=false;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            
            string filtervalue = "";
            switch (cbFilter.Text)
            {
                case "L.D.L App ID":
                    filtervalue = "LocalDrivingLicenseApplicationID";
                    break;
                case "NationalNo":
                    filtervalue = "NationalNo";
                    break;
                case "FullName":
                    filtervalue = "FullName";
                    break;
                case "Status":
                    filtervalue = "Status";
                    break;
                default:
                    filtervalue = "None";
                    break;
            }

            if (tbFilter.Text.Trim() == "" || filtervalue == "None")
            {
                _dtLDLApp.DefaultView.RowFilter = "";
              
                laRecordCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
           if(cbFilter.Text== "L.D.L App ID")
            {
                _dtLDLApp.DefaultView.RowFilter = string.Format("[{0}] = {1}", filtervalue, tbFilter.Text.Trim());
            }
           else
            {
                _dtLDLApp.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filtervalue, tbFilter.Text.Trim());
            }
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && cbFilter.Text == "L.D.L App ID")
            {
                e.Handled = true;  
            }
        }

        private void buAddLocalLicenseApp_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicenseApplication addNewLLApp = new frmAddLocalDrivingLicenseApplication(_UserID);
            addNewLLApp.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Message", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseAppBL.DeleteLocalDrivingLicenseApp((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Item deleted.");
                    frmLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                    MessageBox.Show("Unable to delete.");
            }
            else if (result == DialogResult.Cancel)
            {
              
                MessageBox.Show("Deletion cancelled.");
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPeopleBL people = clsPeopleBL.FindByNationalNo(dataGridView1.CurrentRow.Cells[2].Value.ToString());
          
            frmAddLocalDrivingLicenseApplication addNewLLApp = new frmAddLocalDrivingLicenseApplication(_UserID, (int)dataGridView1.CurrentRow.Cells[0].Value,people.PersonID);
            addNewLLApp.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells[6].Value.ToString()=="Cancelled")
            {
                MessageBox.Show("Application Cancelled Already", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            clsLocalDrivingLicenseAppBL L = clsLocalDrivingLicenseAppBL.FindByLocalDrivingLicenseAppID((int)dataGridView1.CurrentRow.Cells[0].Value);
            clsApplicationBL app = clsApplicationBL.FindByApplicationID(L.ApplicationID);
            app.ApplicationStatus = 2;
            if(app.Save())
            {
                if(L.Save())
                {
                    MessageBox.Show("Application Canceled Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Application Saving Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Application Error", "App Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointment visiontest = new frmVisionTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value, 2);
            visiontest.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);
        }

        private void msscheduleVisionTest_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointment visiontest = new frmVisionTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value,1);
            visiontest.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null,null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        
            //DisableIssueFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value);
            //DisableTests();
        }

        private void DisableTests()
        {
            if(clsLocalDrivingLicenseAppBL.IsLocalLicenseAppCancelled((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                E_DTestMenu(false,false,false);
                EnableMenuContext(false,false);
                return;
            }
            if ((int)dataGridView1.CurrentRow.Cells[5].Value==0)
            {
                E_DTestMenu(true,false,false);
            }
            else if((int)dataGridView1.CurrentRow.Cells[5].Value == 1)
            {
                E_DTestMenu(false,true,false);
            }
            else if((int)dataGridView1.CurrentRow.Cells[5].Value == 2)
            {
                E_DTestMenu(false, false, true);
            }
            else if ((int)dataGridView1.CurrentRow.Cells[5].Value == 3)
            {
                E_DTestMenu(false, false, false);
            }
        }
        private void DisableIssueFirstTime(int x)
        {
            
            if (clsLicenseBL.IsLicenseExistsByLocalDrivingLicenseID(x))
            {
                EnableMenuContext(false,true);
                return;
            }
            EnableMenuContext(true,false);
            if(clsTestsBL.CountPassedTests(x)!=3)
            {
                CMIssueFirstTime.Enabled = false;
            }
            if(clsTestAppointmentsBL.IsTestAppointmentExistsByLocalDrivingLicenseApp(x))
                CMEditApp.Enabled = false;

        }

        private void E_DTestMenu(bool vision,bool written,bool street)
        {
            msscheduleVisionTest.Enabled = vision;
            msscheduleWrittenTest.Enabled = written;
            msScheduleStreetTest.Enabled = street;
        }

        private void msScheduleStreetTest_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointment visiontest = new frmVisionTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value, 3);
            visiontest.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // DisableIssueFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmIssueDrivingLicense issueDrivingLicense = new frmIssueDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value, (int)dataGridView1.CurrentRow.Cells[5].Value);
            issueDrivingLicense.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null,null);
 
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DisableIssueFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value);
            //DisableTests();
        }

        private void GetData(bool enabeld)
        {
            EnableClick = enabeld;
        }

        private void EnableMenuContext(bool first,bool second)
        {
          
                CMScheduleTest.Enabled = first;
                CMIssueFirstTime.Enabled = first;
                CMEditApp.Enabled = first;
                CMDeleteApp.Enabled = first;
                CMCancelApp.Enabled = first;
                CMShowLicensesHistory.Enabled = second;
                CMShowLicense.Enabled = second;
        }

        private void CMShowLicense_Click(object sender, EventArgs e)
        {
            frmLicenseInfo LInfo = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value,1);
            LInfo.ShowDialog();
        }

        private void CMShowLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicenseHistory License = new frmLicenseHistory((string)dataGridView1.CurrentRow.Cells[2].Value);
            License.ShowDialog();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMShowAppDetails_Click(object sender, EventArgs e)
        {
            frmDrivingLicenseAppInfo DLAppInfo = new frmDrivingLicenseAppInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            DLAppInfo.ShowDialog();
        }

        private void cMMangepeople_Opening(object sender, CancelEventArgs e)
        {
            DisableIssueFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value);
            DisableTests();
        }
    }
}
