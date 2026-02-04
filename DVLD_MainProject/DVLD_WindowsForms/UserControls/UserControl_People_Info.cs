using DVLD_BusinessLayer;
using DVLD_WindowsForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.People
{
    public partial class UserControl_People_Info : UserControl
    {
        clsPeopleBL _Person;
        int _PersonID = -1;
        public UserControl_People_Info()
        {
            InitializeComponent();
        }

        public clsPeopleBL SelectedPersonInfo()
        {
            return _Person;
        }
        
        public int PersonID()
        {
            return _PersonID;
        }
        private void UserControl_People_Info_Load(object sender, EventArgs e)
        {
            
            
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person= clsPeopleBL.FindByPersonID(PersonID);
            if(_Person==null)
            {
                linkEditPersonInfo.Enabled = false;
                InitialLabel("[????????]");
               // MessageBox.Show($"No Person With PersonID {PersonID}");
                return;
            }
             _PersonID = PersonID;
                _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPeopleBL.FindByNationalNo(NationalNo);
            if (_Person == null)
            {
                linkEditPersonInfo.Enabled = false;
                InitialLabel("[????????]");
                // MessageBox.Show($"No Person With PersonID {PersonID}");
                return;
            }
            _FillPersonInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void InitialLabel(string text)
        {
            laName.Text=text;
            laPersonID.Text=text;
            laNationalNo.Text=text;
            laGender.Text=text;
            laCountry.Text=text;
            laPhone.Text=text;
            laAddress.Text=text;
            laEmail.Text=text;
            laDateOfBirth.Text=text;
            pbPhoto.Image = null;
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPhoto.Image = Resources.Male_512;
            else
                pbPhoto.Image = Resources.Female_512;
            string imagepath = _Person.ImagePath;
            if(imagepath!="")
            {
                if(File.Exists(imagepath))
                {
                    pbPhoto.ImageLocation = imagepath;
                }
                else
                {
                    MessageBox.Show("Couldn't Find This Image");
                }
            }
        }
        private void _FillPersonInfo()
        {
            
            linkEditPersonInfo.Enabled = true;
            laName.Text = $"{_Person.FirstName}  {_Person.SecondName}  {_Person.ThirdName}  {_Person.LastName}";
            laPersonID.Text = _Person.PersonID.ToString();
            laNationalNo.Text= _Person.NationalNo.ToString();
            laGender.Text = _Person.Gendor == 0 ? "Male" : "Female";
            laEmail.Text= _Person.Email.ToString();
            laAddress.Text= _Person.Address.ToString();
            laDateOfBirth.Text = _Person.DateOfBirth.Date.ToString("dd/MM/yyyy");
            laPhone.Text= _Person.Phone.ToString();
            laCountry.Text = clsCountriesBL.Find(_Person.NationalityCountryID).CountryName;
            _LoadPersonImage();
        }

        private void linkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_Edit_People objAdd_Edit = new Add_Edit_People(_Person.PersonID);
            objAdd_Edit.ShowDialog();
            LoadPersonInfo(_Person.PersonID);
        }
    }
}
