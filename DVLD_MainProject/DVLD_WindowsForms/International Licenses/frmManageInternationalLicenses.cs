using DVLD_BusinessLayer;
using DVLD_WindowsForms.Licenses;
using DVLD_WindowsForms.People;
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
    public partial class frmManageInternationalLicenses : Form
    {
        DataTable _dt;
        clsApplicationBL _Application;
        public frmManageInternationalLicenses()
        {
          
            InitializeComponent();
            if (clsInternationalLicensesBL.GetInternationalLicensesTable()?.Rows.Count == 0)
                return;
            _dt = clsInternationalLicensesBL.GetInternationalLicensesTable().DefaultView.ToTable(false, "InternationalLicenseID", "ApplicationID", "DriverID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
            RefreshDataGridview();
            PrepareDataGridView();

        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {

        }

        private void PrepareDataGridView()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                laRecordCount.Text = dataGridView1.Rows.Count.ToString();
                dataGridView1.Columns[0].HeaderText = "Int.License ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Application ID";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "Driver ID";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "L.Licnese ID";
                dataGridView1.Columns[3].Width = 150;

                dataGridView1.Columns[4].HeaderText = "Issue Date";
                dataGridView1.Columns[4].Width = 255;

                dataGridView1.Columns[5].HeaderText = "Expiration Date";
                dataGridView1.Columns[5].Width = 255;

                dataGridView1.Columns[6].HeaderText = "Is Active";
                dataGridView1.Columns[6].Width = 150;
            }
        }
        private void RefreshDataGridview()
        {
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
            dataGridView1.DataSource = clsInternationalLicensesBL.GetInternationalLicensesTable().DefaultView.ToTable(false, "InternationalLicenseID", "ApplicationID", "DriverID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
        }

        private void buAddInterLicense_Click(object sender, EventArgs e)
        {
            frmAddInternationlLicense NewInterLicense= new frmAddInternationlLicense();
            NewInterLicense.ShowDialog();
            RefreshDataGridview();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _Application = clsApplicationBL.FindByApplicationID((int)dataGridView1.CurrentRow.Cells[1].Value);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _Application = clsApplicationBL.FindByApplicationID((int)dataGridView1.CurrentRow.Cells[1].Value);
        }

        private void CMShowAppDetails_Click(object sender, EventArgs e)
        {
            People_Info Person = new People_Info(_Application.PersonInfo.PersonID);
            Person.ShowDialog();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMShowLicense_Click(object sender, EventArgs e)
        {
            frmLicenseInfo Linfo = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[3].Value);
            Linfo.ShowDialog();
        }

        private void CMShowLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(_Application.PersonInfo.NationalNo);
            LicenseHistory.ShowDialog();
        }
    }
}
