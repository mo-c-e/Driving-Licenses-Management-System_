using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Users
{
    public partial class Show_User_Info : Form
    {
        int _UserID;
        public Show_User_Info(int userID)
        {
            InitializeComponent();
            _UserID = userID;
            
        }

        private void Show_User_Info_Load(object sender, EventArgs e)
        {
            ucUser_Info1.LoadUserInfo(_UserID);

        }

        private void ucUser_Info1_Load(object sender, EventArgs e)
        {

        }
    }
}
