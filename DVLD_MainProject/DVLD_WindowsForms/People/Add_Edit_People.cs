using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DVLD_WindowsForms.People
{
    [Serializable]
    public partial class Add_Edit_People : Form
    {
       public int ID;
        private bool IsSaveClicked=false;
        int Full = 0;

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

       public class ProgressPerson 
        {
            public int PersonID { get; set; }
            public string NationalNo { get; set; }

            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string LastName { get; set; }
            public int Gendor { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int NationalityCountryID { get; set; }
            public ProgressPerson()
            {
                this.PersonID = -1;
                this.NationalNo = "";
                this.FirstName = "";
                this.SecondName = "";
                this.ThirdName = "";
                this.LastName = "";
                this.Email = "";
                this.Phone = "";
                this.Address = "";
                this.Gendor = -1;
                this.DateOfBirth = DateTime.Now;
                this.NationalityCountryID = -1;
               
            }
        }
        clsPeopleBL _Person;
        public Add_Edit_People(int flag)
        {
            InitializeComponent();
            //  ID = flag;
            this.ID = flag;
            _DefaultSettings(ID);
            SetMax_MinAge(60,18);
           
            ChangePhoto();
        }

        private void Add_Edit_People_Load(object sender, EventArgs e)
        {

            if (ID == -1)
            {
                laAdd_Edit.Text = "Add New People";
               
            }
            else
            {
                laAdd_Edit.Text = "Update People";
                laPersonID.Text=ID.ToString();
                _Person = clsPeopleBL.FindByPersonID(ID);
                laNationalNumber.Text = _Person.NationalNo.ToString();
                UploadPeopleInfo(_Person);
                
            }
           
        }

       
        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                
                errorProvider1.SetError(tbFirstName,"Enter FirstName");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbFirstName,null);
                e.Cancel=false;
            }
        }

        private void tbSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSecondName.Text))
            {

                errorProvider1.SetError(tbSecondName,"Enter SecondName");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbSecondName, null);
               e.Cancel = false;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {

                errorProvider1.SetError(tbLastName, "Enter LastName");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbLastName, null);
                e.Cancel = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void _DefaultSettings(int flage)
        {
            ID = flage;
            if(!IsUpdate())
            {
                rbMale.Checked=true;
            }
            _Upload_Countries();
            
        }

        private void _Upload_Countries()
        {
            DataTable dataTable = clsCountriesBL.GetAllCountries();
            foreach (DataRow row in dataTable.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }

        }

        private bool IsUpdate()
        {
            return (ID != -1);
        }

        private bool IsEmailExists(string Email)
        {
           
           int index = Email.IndexOf("@");
           
            if(index==Email.Length-1 || index>0 )
            {
              if  (IsDomainExsits(LowerEmailPart(index, Email)))
                   {
                    return true;
                }
                return false;

            }
            return false;
        }
        private string LowerEmailPart(int index,string Emaail)
        {
            return Emaail.Substring(index, Emaail.Length -index);
        }
        private bool IsDomainExsits(string Domain)
        {
            return (Domain=="@yahoo.com" || Domain=="@gmail.com");
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!IsEmailExists(tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail,"Wrong Input");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbEmail,null);
                e.Cancel=false;
            }
        }

        private void SetMax_MinAge(byte max,byte min)
        {
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-max);
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-min);
        }

        private void ChangePhoto()
        {
            if(rbMale.Checked==true && pbPhoto.ImageLocation==null) 
             {
                pbPhoto.Image = Properties.Resources.Male_512;
                pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if(rbFemale.Checked && pbPhoto.ImageLocation==null)
            {
                pbPhoto.Image = Properties.Resources.Female_512;
                pbPhoto.SizeMode=PictureBoxSizeMode.Zoom;
            }
        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(clsPeopleBL.IsPeopleExists(tbNationalNo.Text) || string.IsNullOrWhiteSpace(tbNationalNo.Text))
            {
                errorProvider1.SetError(tbNationalNo,"Number is already exists");
                e.Cancel=true;
            }
            else
            {
                errorProvider1.SetError(tbNationalNo,null);
                e.Cancel=false;
            }
        }

        private void linkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                // path=openFileDialog1.FileName;
                // pbPhoto.Image = Image.FromFile(path);
                string selectedfile = openFileDialog1.FileName;
                pbPhoto.Load(selectedfile);
                linkRemove.Visible = true;
            }
 
        }

      

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            ChangePhoto();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            ChangePhoto();
        }

        private void linkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         //   path = null;
            pbPhoto.ImageLocation = null;
           ChangePhoto();
            linkRemove.Visible = false;
        }

        // Phone Validation 

       public bool IsInt(string phoneNumber)
        {
            return int.TryParse(phoneNumber, out _);
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if(!IsInt(tbPhone.Text))
            {
                errorProvider1.SetError(tbPhone,"Enter Number");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbPhone,null);
                e.Cancel=false; 
            }
        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool IsMale(int value)
        {
            return (value==0);
        }


        private void UploadPeopleInfo(clsPeopleBL Info)
        {
         // clsPeopleBL Info= clsPeopleBL.FindByPersonID(ID);
          tbFirstName.Text = Info.FirstName;
            tbLastName.Text = Info.LastName;
            tbSecondName.Text = Info.SecondName;
            tbThirdName.Text = Info.ThirdName;
            tbNationalNo.Text = Info.NationalNo;
            dateTimePicker1.Value = Info.DateOfBirth;
          //  path = Info.ImagePath.Trim();
            
            if(Info.Gendor==0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked= true;
            }
            if (_Person.ImagePath != "")
            {
                pbPhoto.ImageLocation = _Person.ImagePath;

            }
            linkRemove.Visible = (_Person.ImagePath != "");

            tbPhone.Text= Info.Phone;
            tbEmail.Text = Info.Email;
            tbAddress.Text = Info.Address;
  
            cbCountry.Text = Info.CountryInfo.CountryName;
        }

        private void SavePersonInfo(ref int ID)
        {
            string word = "";
          //  clsPeopleBL _Person;
            
            if (ID!=-1)
            {
                _Person = clsPeopleBL.FindByPersonID(ID);
                _Person.PersonID = ID;
                word = "Updated";
            }
            else
            {
                 _Person = new clsPeopleBL();
                word = "Added";
            }

            if (!_HandlePersonImage())
                return;
            _Person.FirstName = tbFirstName.Text;
            _Person.SecondName = tbSecondName.Text;
            _Person.ThirdName = tbThirdName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.NationalNo = tbNationalNo.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
           // _Person.ImagePath = path ?? "";
            if (pbPhoto.ImageLocation != null)
                _Person.ImagePath = pbPhoto.ImageLocation;
            else
                _Person.ImagePath = "";

            if (rbMale.Checked == true)
            {
                _Person.Gendor = 0;
            }
            else
            {
                _Person.Gendor = 1;
            }
            _Person.Phone= tbPhone.Text;
            _Person.Email= tbEmail.Text;
            _Person.NationalityCountryID=cbCountry.SelectedIndex+1;
            _Person.Address= tbAddress.Text;
           // laPersonID.Text = objPeopleInfo.PersonID.ToString();
            laNationalNumber.Text = _Person.NationalNo.ToString();
            
           
            if(_Person.Save())
            {
                MessageBox.Show($"Info {word} Successfully ","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DataBack?.Invoke(this,_Person.PersonID);
            }
            else
            {
                MessageBox.Show("Error","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            laPersonID.Text = _Person.PersonID.ToString();
            ID = _Person.PersonID;
        }

        private void buSave_Click(object sender, EventArgs e)
        {
            IsSaveClicked=true;
          int Previous_ID = ID;
            //if (!_HandlePersonImage())
            //    return;
            //  string s = laPersonID.Text;

            //  laTest.Text = Previous_ID.ToString();
            SavePersonInfo(ref ID);
            if(Previous_ID==-1)
            {
                laAdd_Edit.Text = "Update People";
            }

        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {

        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void laAdd_Edit_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private bool _HandlePersonImage()
        {
           
            if(pbPhoto.ImageLocation!=_Person.ImagePath)
            {
                if(_Person.ImagePath!="")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch(IOException)
                    {

                    }
                }

                if (pbPhoto.ImageLocation != null)
                {
                    string SourceImageFile = pbPhoto.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPhoto.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
           
            return true;
        }

        private void Add_Edit_People_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!IsSaveClicked)
            {
                File.WriteAllText("People.xml", string.Empty);
                var Progress = new ProgressPerson();
                FillUnEmpty(  Progress);

                XmlSerializer serialzer= new XmlSerializer(typeof(ProgressPerson));
                using (TextWriter writer= new StreamWriter("People.xml"))
                {
                    serialzer.Serialize(writer,Progress);
                }
            }
          
        }
        private void FillUnEmpty(  ProgressPerson Person)
        {
            var textMappings = new (TextBox tb, Action<string> assign)[]
            {
                (tbFirstName, val => Person.FirstName = val),
               (tbSecondName, val => Person.SecondName = val),
               (tbThirdName, val => Person.ThirdName = val),
              (tbLastName, val => Person.LastName = val),
              (tbNationalNo, val => Person.NationalNo = val),
              (tbPhone, val => Person.Phone = val),
               (tbEmail, val => Person.Email = val),
               (tbAddress, val => Person.Address = val),
            };

            foreach (var (tb, assign) in textMappings)
            {
                if (!string.IsNullOrEmpty(tb.Text))
                {
                    assign(tb.Text);
                    Full++;
                }
            }
            if (!string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                Person.DateOfBirth = dateTimePicker1.Value;
                Full++;
            }

            if (cbCountry.SelectedIndex != 0)
            {
                Person.NationalityCountryID = cbCountry.SelectedIndex + 1;
                Full++;
            }

            Person.Gendor = rbFemale.Checked ? 0 : 1;
            Full++;
        }
        private ProgressPerson Deserlizerd()
        {
            XmlSerializer Deserialzer = new XmlSerializer(typeof(ProgressPerson));
            ProgressPerson SavedProgress;


            using (TextReader reader = new StreamReader("People.xml"))
            {
                 SavedProgress = (ProgressPerson)Deserialzer.Deserialize(reader);
            }
            return SavedProgress;
        }
        
    }
}
