using DVLD_BusinessLayer;
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

namespace DVLD_WindowsForms.Drivers
{
    public partial class frmManageDrivers : Form
    {
        DataTable _dtDrivers = clsDriversBL.GetDriversTable();
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            RefreshData();
            if(dataGridView1.Rows.Count>0)
            UploadDataHeaders();
        }
        private void UploadDataHeaders()
        {
            
            dataGridView1.Columns[0].HeaderText = "Driver ID";
            dataGridView1.Columns[0].Width = 150;

            dataGridView1.Columns[1].HeaderText = "Person ID";
            dataGridView1.Columns[1].Width = 200;

            dataGridView1.Columns[2].HeaderText = "National No.";
            dataGridView1.Columns[2].Width = 170;

            dataGridView1.Columns[3].HeaderText = "FullName";
            dataGridView1.Columns[3].Width = 305;

            dataGridView1.Columns[4].HeaderText = "Date";
            dataGridView1.Columns[4].Width = 200;

            dataGridView1.Columns[5].HeaderText = "Active Licenses";
            dataGridView1.Columns[5].Width = 150;

        }
        private void RefreshData()
        {
            dataGridView1.DataSource = _dtDrivers;
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
           
            string filter = "";
            switch(cbFilter.Text)
            {
                case "DriverID":
                    filter = "DriverID";
                        break;
                case "PersonID":
                    filter = "PersonID";
                    break;
                case "NationalNo":
                    filter = "NationalNo";
                    break;
                case "FullName":
                    filter = "FullName";
                    break;
                default:
                    filter = "None";
                    break;
            }

            if (tbFilter.Text.Trim() == "" || filter == "None")
            {
                _dtDrivers.DefaultView.RowFilter = "";

                laRecordCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            if (cbFilter.Text == "DriverID" || cbFilter.Text == "PersonID")
            {
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filter, tbFilter.Text.Trim());
            }
            else
            {
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filter, tbFilter.Text.Trim());
            }
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
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

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && (cbFilter.Text == "PersonID" || cbFilter.Text == "DriverID"))
            {
                e.Handled = true;
            }
        }
    }
}
