using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Tests_Types
{
    public partial class frmEdit_TestTypes : Form
    {
        int _TestID;
        clsTestTypeBL _TestType;
        public frmEdit_TestTypes(int TestID)
        {
            InitializeComponent();
            this._TestID = TestID;
        }

        private void frmEdit_TestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypeBL.FindTestType(_TestID);
            if (_TestType != null)
            {
                laID.Text = _TestType.TestTypeID.ToString();
                tbTitle.Text = _TestType.TestTypeTitle;
                tbDecription.Text = _TestType.TestTypeDescription;
                tbfees.Text=_TestType.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("Unable To find Test Type", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Missing Info", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestType.TestTypeTitle = tbTitle.Text;
            _TestType.TestTypeDescription = tbDecription.Text;
            _TestType.TestTypeFees = Convert.ToSingle(tbfees.Text);
            if (_TestType.UpdateTestType())
            {
                MessageBox.Show("Update Info Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable To Update Info", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                errorProvider1.SetError(tbTitle, "Enter Value");
            }
            else
            {
                errorProvider1.SetError(tbTitle, null);
            }
        }

        private void tbDecription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDecription.Text))
            {
                errorProvider1.SetError(tbDecription, "Enter Value");
            }
            else
            {
                errorProvider1.SetError(tbDecription, null);
            }
        }

        private void tbfees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbfees.Text))
            {
                errorProvider1.SetError(tbfees, "Enter Value");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbfees, null);
                e.Cancel=false;
            }
        }

        private void tbfees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;  
            }
        }
    }
}
