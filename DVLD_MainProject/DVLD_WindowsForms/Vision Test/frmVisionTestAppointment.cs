using DVLD_BusinessLayer;
using DVLD_WindowsForms.Properties;
using DVLD_WindowsForms.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace DVLD_WindowsForms.Vision_Test
{
    public partial class frmVisionTestAppointment : Form
    {
        int _LocalDrivingLicenseApp;
       // int _PassedTests;
        int _TesttypeID;
        bool _UpdatePassedTests=false;
        public frmVisionTestAppointment(int LocalDrivingLicenseApp,int TesttypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApp=LocalDrivingLicenseApp;
         //   _PassedTests=passedTests;
            _TesttypeID = TesttypeID;
            ucDrivingLicenseAppInfo1.SetLocalDrivingLicenseID(_LocalDrivingLicenseApp);
           // ucDrivingLicenseAppInfo1.SetPassedTests(_PassedTests);
          
        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            TestType(_TesttypeID);
           
            Refresh_AppointmentTable();
            if(dataGridView1.Rows.Count > 0) 
                SetDataGridViewColumns();
        }

        
        private void Refresh_AppointmentTable()
        {
            dataGridView1.DataSource = clsTestAppointmentsBL.GetTestAppointmentByLocalLicenseID(_LocalDrivingLicenseApp,_TesttypeID);
            laRecord.Text = dataGridView1.Rows.Count.ToString();
         
        }

        private void SetDataGridViewColumns()
        {
           
                dataGridView1.Columns[0].HeaderText = "Test Appointment ID";
                dataGridView1.Columns[0].Width = 200;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 300;

                dataGridView1.Columns[2].HeaderText = "PaidFees";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "IsLocked";
                dataGridView1.Columns[3].Width = 100;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (clsTestsBL.IsTestExistsByLocalDLApp(_LocalDrivingLicenseApp))
            {
                if (clsTestAppointmentsBL.IsLockedAppointments(_LocalDrivingLicenseApp, _TesttypeID))
                {
                    MessageBox.Show("You Already have an active Appointment", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
                else
                {
                    if (!clsTestsBL.IsPass(_TesttypeID, _LocalDrivingLicenseApp))
                    {
                        frmTest test = new frmTest(_LocalDrivingLicenseApp, -1,_TesttypeID);
                        test.ShowDialog();
                        Refresh_AppointmentTable();
                    }
                    else
                    {
                        MessageBox.Show("You Already Passed Test", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
            else 
            {

                frmTest test = new frmTest(_LocalDrivingLicenseApp, -1, _TesttypeID);
                test.ShowDialog();
                Refresh_AppointmentTable();
                return;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmTest test = new frmTest(_LocalDrivingLicenseApp, (int)dataGridView1.CurrentRow.Cells[0].Value,_TesttypeID);
            test.ShowDialog();
            Refresh_AppointmentTable();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestResult result = new frmTestResult(_LocalDrivingLicenseApp, (int)dataGridView1.CurrentRow.Cells[0].Value,_TesttypeID);
            result.ShowDialog();
           // result.UpdateExamsDataback += DataBackFromTestResultForm;
            Refresh_AppointmentTable();
          //  if (_UpdatePassedTests == true)
                ucDrivingLicenseAppInfo1.UpdateExamStatus();
          //  MessageBox.Show(_UpdatePassedTests.ToString());
        }
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(dataGridView1.CurrentRow.Cells[0].Value==null)
            //{
            //    return; 
            //}
            //if (clsTestAppointmentsBL.IsLockedByAppointmentID((int)dataGridView1.CurrentRow.Cells[0].Value,_TesttypeID))
            //{
            //    retakeTestToolStripMenuItem.Enabled = false;
                 
            //}
            //else
            //    retakeTestToolStripMenuItem.Enabled = true;
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        public  void TestType(int TestTypeID)
        {
            switch (TestTypeID)
            {
                case 1:
                    pbPicture.Image = Resources.Vision_512;
                    la_TestAppointments.Text = "Vision Test Appointments";
                    break;
                case 2:
                    pbPicture.Image = Resources.Written_Test_512;
                    la_TestAppointments.Text = "Written Test Appointments";
                    break;
                case 3:
                    pbPicture.Image = Resources.driving_test_512;
                    la_TestAppointments.Text = "Street Test Appointments";
                    break;
                default:
                    break;

            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.CurrentRow.Cells[0].Value == null)
            //{
            //    return;
            //}
            //if (clsTestAppointmentsBL.IsLockedByAppointmentID((int)dataGridView1.CurrentRow.Cells[0].Value, _TesttypeID))
            //{
            //    retakeTestToolStripMenuItem.Enabled = false;

            //}
            //else
            //    retakeTestToolStripMenuItem.Enabled = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value == null)
            {
                return;
            }
            if (clsTestAppointmentsBL.IsLockedByAppointmentID((int)dataGridView1.CurrentRow.Cells[0].Value, _TesttypeID))
            {
                retakeTestToolStripMenuItem.Enabled = false;

            }
            else
                retakeTestToolStripMenuItem.Enabled = true;
        }
    }
}
