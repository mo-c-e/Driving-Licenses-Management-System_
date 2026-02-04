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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsTestTypeBL.GetTestType();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 200;

            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[1].Width = 200;

            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[2].Width = 200;

            dataGridView1.Columns[3].HeaderText = "Fees";
            dataGridView1.Columns[3].Width = 100;

            laRecordsNum.Text = dataGridView1.Rows.Count.ToString();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEdit_TestTypes test = new frmEdit_TestTypes((int)dataGridView1.CurrentRow.Cells[0].Value);
            test.ShowDialog();
            frmManageTestTypes_Load(null,null);
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
