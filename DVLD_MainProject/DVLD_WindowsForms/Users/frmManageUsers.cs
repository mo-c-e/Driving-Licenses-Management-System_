using DVLD_BusinessLayer;
using DVLD_WindowsForms.UserControls;
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

namespace DVLD_WindowsForms.Users
{
    public partial class frmManageUsers : Form
    {
        DataTable _UsersList=clsUsersBL.GetUsersPeopel_Table();
        public frmManageUsers()
        {
            InitializeComponent();

        }
        public void SetDatagridViewSizes()
        {
            UploadData();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "UserID";
                dataGridView1.Columns[0].Width = 103;

                dataGridView1.Columns[1].HeaderText = "PersonID";
                dataGridView1.Columns[1].Width = 103;

                dataGridView1.Columns[2].HeaderText = "FullName";
                dataGridView1.Columns[2].Width = 260;

                dataGridView1.Columns[3].HeaderText = "UserName";
                dataGridView1.Columns[3].Width = 170;

                dataGridView1.Columns[4].HeaderText = "IsActive";
                dataGridView1.Columns[4].Width = 100;
            }
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None" )
            {
                tbFilter.Visible = false;
                cbIsActive.Visible = false;
                
            }
            else if(cbFilter.Text=="Is Active")
            {
                tbFilter.Visible = false;
                cbIsActive.Visible = true;
            }
            else
            {
                tbFilter.Visible = true;
                cbIsActive.Visible = false;
            }
        }

        private void UploadData()
        {

            _UsersList = clsUsersBL.GetUsersPeopel_Table();
           dataGridView1.DataSource = _UsersList;
            laRecordsNum.Text = dataGridView1.Rows.Count.ToString();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (tbFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _UsersList.DefaultView.RowFilter = "";
                laRecordsNum.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
               _UsersList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilter.Text.Trim());
            else
                _UsersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbFilter.Text.Trim());

            laRecordsNum.Text = dataGridView1.Rows.Count.ToString();

        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            
            SetDatagridViewSizes();
        }

        private void buAddUser_Click(object sender, EventArgs e)
        {
            frmAddUsers user = new frmAddUsers(-1,-1);
            user.ShowDialog();
            UploadData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_User_Info info = new Show_User_Info((int)dataGridView1.CurrentRow.Cells[0].Value);
            info.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUsers user = new frmAddUsers((int)dataGridView1.CurrentRow.Cells[1].Value, (int)dataGridView1.CurrentRow.Cells[0].Value);
            user.ShowDialog();
            UploadData();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ChangePassword changePassword = new frm_ChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUsers user = new frmAddUsers(-1,-1);
            user.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are Your Sure You Want To Delete ?","delete",MessageBoxButtons.OKCancel))
            { 
            if (clsUsersBL.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Deleted Successfully", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UploadData();
            }
            else
            {
                MessageBox.Show("Unable To Delete", "message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

             }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool FilterType = true;
            
            switch (cbIsActive.Text.Trim())
            {
                case "Active All":
                    _UsersList.DefaultView.RowFilter = ""; // No filter applied
                    return; // Exit early, no need to set the filter below
                case "Yes":
                    FilterType = true;
                    break;
                case "No":
                    FilterType = false;
                    break;
                default:
                    // Optional: Handle unexpected values
                    MessageBox.Show("Invalid filter option selected.");
                    return;
            }

            _UsersList.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", FilterType.ToString().ToLower());
            laRecordsNum.Text = dataGridView1.Rows.Count.ToString();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && (cbFilter.Text == "Person ID" || cbFilter.Text=="User ID"))
            {
                e.Handled = true;  // Ignore non-numeric key press
            }
        }
    }   
}
