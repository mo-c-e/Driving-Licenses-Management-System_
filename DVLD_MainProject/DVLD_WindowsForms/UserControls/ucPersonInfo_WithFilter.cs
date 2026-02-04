using DVLD_BusinessLayer;
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

namespace DVLD_WindowsForms.UserControls
{
    public partial class ucPersonInfo_WithFilter : UserControl
    {
        private clsPeopleBL _Person;
        int PersonID;
        string _NationalNo;
        bool _IsEnable = true;

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if(handler!=null)
            {
                handler(PersonID);
            }
        }
        public ucPersonInfo_WithFilter()
        {
            InitializeComponent();
           // this._PersonID = PersonID;
        }

        public int GetPersonID()
        {
            return userControl_People_Info1.PersonID();
        }

        public clsPeopleBL SelectedPersonInfo()
        {
            return userControl_People_Info1.SelectedPersonInfo();
        }
        public  void SetPersonID(int personID)
        {
            PersonID = personID;
        }

        public void SetNationalNo(string NationalNo)
        {
            _NationalNo=NationalNo;
        }
        
        public void LoaducWithFilter_NationalNo(string NationalNo)
        {
            _NationalNo= NationalNo;
            cbFilter.SelectedIndex = 1;
            if (NationalNo != "")
            {
                _IsEnable = false;
                tbFilter.Text = _NationalNo.ToString();
            }
            EnableFilter(_IsEnable);
            userControl_People_Info1.LoadPersonInfo(NationalNo);
        }

        public void LoaducWithFilter_PersonID(int PersonID)
        {
            this.PersonID= PersonID;
            cbFilter.SelectedIndex = 1;
            if (this.PersonID != -1)
            {
                _IsEnable = false;
                tbFilter.Text = this.PersonID.ToString();
            }
            EnableFilter(_IsEnable);
            userControl_People_Info1.LoadPersonInfo(this.PersonID);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userControl_People_Info1_Load(object sender, EventArgs e)
        {

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.Text=="None")
            tbFilter.Visible = false;
            else 
                tbFilter.Visible=true; 
        }

        private void ucPersonInfo_WithFilter_Load(object sender, EventArgs e)
        {
           
            
        }


        private clsPeopleBL FilterType()
        {
            switch(cbFilter.Text)
            {
                case "NationalNo.":
                    return clsPeopleBL.FindByNationalNo(tbFilter.Text);
             
                case "PersonID":
                    return clsPeopleBL.FindByPersonID(Convert.ToInt32(tbFilter.Text.Trim()));
                    
                default:
                    return null;
            }
        }

        private void EnableFilter(bool enable=true)
        {
            if(!enable)
            {
                cbFilter.Enabled = false;
                tbFilter.Enabled = false;
                buAddPerson.Enabled = false;
                buFindPerson.Enabled = false;
            }
            else
            {
                cbFilter.Enabled = true;
                tbFilter.Enabled = true;
                buAddPerson.Enabled = true;
                buFindPerson.Enabled = true;
            }
        }

        private void buFindPerson_Click(object sender, EventArgs e)
        {
            _Person = FilterType();
             
            if(_Person!=null)
            {
               
                userControl_People_Info1.LoadPersonInfo(_Person.PersonID);
                if (OnPersonSelected != null && _IsEnable)
                    PersonSelected(userControl_People_Info1.PersonID());
            }
            else
            {
                MessageBox.Show("Not Found","Msesage",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                userControl_People_Info1.LoadPersonInfo(-1);
            }
        }

        private void buAddPerson_Click(object sender, EventArgs e)
        {
            Add_Edit_People person = new Add_Edit_People(-1);
            person.DataBack += Change_DataBack;
            person.ShowDialog();

        }

        public void Change_DataBack(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            tbFilter.Text=PersonID.ToString();
            userControl_People_Info1.LoadPersonInfo(PersonID);
            
        }

        private void tbFilter_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbFilter.Text))
            {
                errorProvider1.SetError(tbFilter,"Enter Value");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbFilter,null);
                e.Cancel = false;
            }
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && cbFilter.Text=="PersonID")
            {
                e.Handled = true; // Reject the input
            }

            if (e.KeyChar == (char)13)
            {
                buFindPerson.PerformClick();
                e.Handled = true;
            }
        }
       

    }
}

