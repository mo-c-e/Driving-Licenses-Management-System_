using DVLD_BusinessLayer;
using DVLD_WindowsForms.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms
{
    public partial class ManagePeople : Form
    {
       
        private static DataTable _GetAllPeople = clsPeopleBL.GetPeopleTable();
        private DataTable _dtPeople = _GetAllPeople.DefaultView.ToTable(false,"PersonID","NationalNo","FirstName","SecondName",
            "ThirdName","LastName","Gender","Email","DateOfBirth","Phone");
        public ManagePeople()
        {
            InitializeComponent();
            RefreshDataView();
           
           
        }
        public void RefreshDataView()
        {


            _GetAllPeople = clsPeopleBL.GetPeopleTable();
            _dtPeople = _GetAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName",
            "ThirdName", "LastName", "Gender", "Email", "DateOfBirth", "Phone");

            dataGridView1.DataSource = _dtPeople;
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
        
        }
        private void ManagePeople_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dtPeople;

            if (dataGridView1.Rows.Count>0)
            {
                dataGridView1.Columns[0].HeaderText = "PersonID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "NationalNO";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "FirstName";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "SecondName";
                dataGridView1.Columns[3].Width = 120;

                dataGridView1.Columns[4].HeaderText = "ThirdName";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "LastName";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Gender";
                dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Email";
                dataGridView1.Columns[7].Width = 120;

                dataGridView1.Columns[8].HeaderText = "DateOfBirth";
                dataGridView1.Columns[8].Width = 120;

                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 122;
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

      
        private void buAddPeople_Click(object sender, EventArgs e)
        {
            Add_Edit_People add_Edit_People = new Add_Edit_People(-1);
            add_Edit_People.ShowDialog();
            RefreshDataView();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Edit_People add_Edit_People = new Add_Edit_People(-1);
            add_Edit_People.ShowDialog();
            RefreshDataView();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Edit_People add_Edit_People = new Add_Edit_People((int)(dataGridView1.CurrentRow.Cells[0].Value));
            add_Edit_People.ShowDialog();
            RefreshDataView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPeopleBL s = clsPeopleBL.FindByPersonID((int)dataGridView1.CurrentRow.Cells[0].Value);
            if (clsPeopleBL.DeletePeople((int)(dataGridView1.CurrentRow.Cells[0].Value)))
            {
               
                MessageBox.Show("Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (s.ImagePath != "")
                {
                    try
                    {
                        File.Delete(s.ImagePath);
                    }
                    catch (IOException)
                    {

                    }
                }
                    RefreshDataView();
            }
            else
            {
                MessageBox.Show("Unable To Delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            People_Info people_Info = new People_Info((int)dataGridView1.CurrentRow.Cells[0].Value);
            people_Info.ShowDialog();
           
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == -1)
                tbFilter.Visible = false;
            else
                tbFilter.Visible = true;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterType = "";
           switch(cbFilter.Text)
            {
                case "PersonID":
                    FilterType = "PersonID";
                    break;
                case "NationalNo":
                    FilterType = "NationalNo";
                    break;
                case "FirstName":
                    FilterType = "FirstName";
                    break;
                case "SecondName":
                    FilterType = "SecondName";
                    break;
                case "ThirdName":
                    FilterType = "ThirdName";
                    break;
                case "LastName":
                    FilterType = "LastName";
                    break;
                case "Phone":
                    FilterType = "Phone";
                    break;
                case "Email":
                    FilterType = "Email";
                    break;
                case "Address":
                    FilterType = "Address";
                    break;
                default:
                    FilterType = "None";
                    break;

            }
            if(tbFilter.Text.Trim()=="" ||FilterType=="None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                laRecordCount.Text = dataGridView1.Rows.Count.ToString();  
                return;
            }

            if (FilterType == "PersonID")
            {
                 //string x = tbFilter.Text.Trim().ToString();
                 _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}","PersonID", tbFilter.Text.Trim());
                //_dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterType, x);

            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterType, tbFilter.Text.Trim());
            }
            laRecordCount.Text = dataGridView1.Rows.Count.ToString();
        }

        public bool IsInt(string phoneNumber)
        {
            return int.TryParse(phoneNumber, out _);
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && cbFilter.Text == "PersonID")
            {
                e.Handled = true;  // Ignore non-numeric key press
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The required information has not been provieded yet", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The required information has not been provieded yet", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
