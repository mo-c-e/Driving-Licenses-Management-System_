using DVLD_BusinessLayer;
using DVLD_WindowsForms.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_WindowsForms.Licenses.Detained_Licenses
{
    public partial class frmDetainedLicensesList : Form
    {
        DataTable _dtDetained = clsDetainedLicensesBL.DetainedLicensesView();
        public frmDetainedLicensesList()
        {
            InitializeComponent();

            dataGridView1.DataSource = _dtDetained;
            PrepareDataGridView();

        }

        private void PrepareDataGridView()
        {
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Detain ID";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "License ID";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "Detain Date";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "IsReleased";
                dataGridView1.Columns[3].Width = 80;

                dataGridView1.Columns[4].HeaderText = "FineFees";
                dataGridView1.Columns[4].Width = 80;

                dataGridView1.Columns[5].HeaderText = "Release Date";
                dataGridView1.Columns[5].Width = 150;

                dataGridView1.Columns[6].HeaderText = "Natoinal No";
                dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Full Name";
                dataGridView1.Columns[7].Width = 250;

                dataGridView1.Columns[8].HeaderText = "R.Application ID";
                dataGridView1.Columns[8].Width = 130;
            }
        }
        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = clsDetainedLicensesBL.DetainedLicensesView();
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
        }





        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetainedLicensesList_Load(object sender, EventArgs e)
        {
           
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            string Filter_Type = "None";

            switch (cbFilter.Text)
            {
                case "Detain ID":
                    Filter_Type = "DetainID";
                    break;
                case "Is Released":
                    Filter_Type = "IsReleased";
                    break;
                case "National No":
                    Filter_Type = "NationalNo";
                    break;
                case "Full Name":
                    Filter_Type = "FullName";
                    break;
                case "Release Application ID":
                    Filter_Type = "ReleaseApplicationID";
                    break;
                default:
                    Filter_Type = "None";
                    break;
            }

            if (tbFilter.Text.Trim() == "" || Filter_Type == "None")
            {
                _dtDetained.DefaultView.RowFilter = "";
                laRecordCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (cbFilter.Text == "Detain ID" || cbFilter.Text == "Release Application ID")
            {
                // Numeric columns
                _dtDetained.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter_Type, tbFilter.Text.Trim());
            }
            else if (cbFilter.Text == "Is Released")
            {
                // Convert user input to lowercase
                string input = tbFilter.Text.Trim().ToLower();

                if (input == "true" || input == "yes" || input == "1")
                    _dtDetained.DefaultView.RowFilter = "[IsReleased] = true";
                else if (input == "false" || input == "no" || input == "0")
                    _dtDetained.DefaultView.RowFilter = "[IsReleased] = false";
                else
                    _dtDetained.DefaultView.RowFilter = ""; // Invalid input, clear filter
            }

            else
            {
                _dtDetained.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", Filter_Type, tbFilter.Text.Trim());
            }

            laRecordCount.Text = dataGridView1.Rows.Count.ToString();

        }

        private void buDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense Dlicense = new frmDetainLicense();
            Dlicense.ShowDialog();
            RefreshDataGridView();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text != "None")
            {
                tbFilter.Visible = true;
            }
            else
                tbFilter.Visible = false;

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense R = new frmReleaseDetainedLicense((int)dataGridView1.CurrentRow.Cells[1].Value);
            R.ShowDialog();
            RefreshDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableRelease();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            EnableRelease();
        }

        private void EnableRelease()
        {
            if (clsDetainedLicensesBL.IsReleasedReturn((int)dataGridView1.CurrentRow.Cells[1].Value))
                toolStripMenuItem2.Enabled = false;
            else
                toolStripMenuItem2.Enabled = true;
        }

        private void CMShowLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicenseHistory History = new frmLicenseHistory(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            History.ShowDialog();
        }

        private void CMShowAppDetails_Click(object sender, EventArgs e)
        {
            People_Info PeopleInfo = new People_Info(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            PeopleInfo.ShowDialog();

        }

        private void CMShowLicense_Click(object sender, EventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            LicenseInfo.ShowDialog();
        }

        private void buReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense ReleaseDetainedLicense = new frmReleaseDetainedLicense();
            ReleaseDetainedLicense.ShowDialog();
            RefreshDataGridView();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (cbFilter.Text == "Detain ID" || cbFilter.Text == "Release Application ID"))
            {
                e.Handled = true; 
            }
        }
    }

}
