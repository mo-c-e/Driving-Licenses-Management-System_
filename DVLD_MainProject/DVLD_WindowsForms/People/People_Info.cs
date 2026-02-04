using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace DVLD_WindowsForms.People
{
    public partial class People_Info : Form
    {
        int ID;
        string _NationalNo;
        public People_Info(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            userControl_People_Info1.LoadPersonInfo(ID);
           
        }
        public People_Info(string NationalNo)
        {
            InitializeComponent();
            this._NationalNo=NationalNo;
            userControl_People_Info1.LoadPersonInfo(this._NationalNo);

        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void People_Info_Load(object sender, EventArgs e)
        {

        }
    }
}
