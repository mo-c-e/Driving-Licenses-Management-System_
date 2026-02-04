using DVLD_BusinessLayer;
using DVLD_WindowsForms.International_Licenses;
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
    public partial class frmLicenseHistory : Form
    {

        private string _NationalNo;
        private static DataTable _dtLicense;
        private DataTable _dtFilterLicense;
        private static DataTable _dtInterLicense;
        private static DataTable _dtFilterInterLicense;
        public frmLicenseHistory(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
           
        }
        private void SetDataGridView1()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                laRecordCount.Text = dataGridView1.Rows.Count.ToString();
                dataGridView1.Columns[0].HeaderText = "License ID";
                dataGridView1.Columns[0].Width = 130;

                dataGridView1.Columns[1].HeaderText = "Application ID";
                dataGridView1.Columns[1].Width = 130;

                dataGridView1.Columns[2].HeaderText = "Class Name";
                dataGridView1.Columns[2].Width = 280;

                dataGridView1.Columns[3].HeaderText = "Issue Date";
                dataGridView1.Columns[3].Width = 170;

                dataGridView1.Columns[4].HeaderText = "Expiration Date";
                dataGridView1.Columns[4].Width = 170;

                dataGridView1.Columns[5].HeaderText = "Is Active";
                dataGridView1.Columns[5].Width = 100;
            }
        }
        private void SetDataGridView2()
        {
            if (dataGridView2.Rows.Count > 0)
            {
                laInterRecord.Text = dataGridView2.Rows.Count.ToString();
                dataGridView2.Columns[0].HeaderText = " Int.License ID";
                dataGridView2.Columns[0].Width = 130;

                dataGridView2.Columns[1].HeaderText = "Application ID";
                dataGridView2.Columns[1].Width = 130;

                dataGridView2.Columns[2].HeaderText = "L.License ID";
                dataGridView2.Columns[2].Width = 280;

                dataGridView2.Columns[3].HeaderText = "Issue Date";
                dataGridView2.Columns[3].Width = 170;

                dataGridView2.Columns[4].HeaderText = "Expiration Date";
                dataGridView2.Columns[4].Width = 170;

                dataGridView2.Columns[5].HeaderText = "Is Active";
                dataGridView2.Columns[5].Width = 100;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            ucPersonInfo_WithFilter1.LoaducWithFilter_NationalNo(_NationalNo);

            _dtLicense = clsLicenseBL.GetLicenseByNationalNo(_NationalNo);
            _dtFilterLicense = _dtLicense.DefaultView.ToTable(false, "LicenseID", "ApplicationID", "ClassName", "IssueDate", "ExpirationDate", "IsActive");
            dataGridView1.DataSource = _dtFilterLicense;
            SetDataGridView1();

            _dtInterLicense = clsInternationalLicensesBL.GetInternationalLicensesByNationalNo(_NationalNo);
            if (_dtInterLicense == null || _dtInterLicense.Rows.Count == 0)
            {
                return;
            }
            _dtFilterInterLicense = _dtInterLicense.DefaultView.ToTable(false, "InternationalLicenseID", "ApplicationID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
            dataGridView2.DataSource = _dtFilterInterLicense;
            SetDataGridView2();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_dtInterLicense == null || _dtInterLicense.Rows.Count == 0)
                return;
            frmInternationalLicenseInfo InternationalLicenseinfo = new frmInternationalLicenseInfo((int)dataGridView2.CurrentRow.Cells[0].Value);
            InternationalLicenseinfo.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dtLicense == null || _dtLicense.Rows.Count == 0)
                {
                    return;
                }
            frmLicenseInfo LicenseInfo = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            LicenseInfo.ShowDialog();
        }
    }
}
