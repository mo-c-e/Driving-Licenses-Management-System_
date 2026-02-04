using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ucUser_Info : UserControl
    {
      //  int _UserID;
        clsUsersBL _User;
        public ucUser_Info()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int userID)
        {
            _User = clsUsersBL.FindbyUserID(userID);
            if(_User==null)
            {
                MessageBox.Show($"No UserID With {userID}");
                return;
            }
            userControl_People_Info1.LoadPersonInfo(_User.PersonID);
            laUserID.Text=_User.UserID.ToString();
            laUserName.Text = _User.UserName.ToString();
            laIsActive.Text = IsActive(_User.IsActive);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ucUser_Info_Load(object sender, EventArgs e)
        {

        }

       public static string IsActive(bool condition)
        {
            if (condition)
                return "Yes";
            else
                return "No";
        }
       
    }
}
