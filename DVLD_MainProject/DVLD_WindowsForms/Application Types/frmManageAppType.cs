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

namespace DVLD_WindowsForms.Application_Types
{
    public partial class frmManageAppType : Form
    {
        public frmManageAppType()
        {
            InitializeComponent();
        }

        private void frmManageAppType_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsAppTypesBL.GetAppTypes();
            laRecordsNum.Text = dataGridView1.Rows.Count.ToString();
            dataGridView1.Columns[0].HeaderText = "Application Type ID";
            dataGridView1.Columns[0].Width = 250;

            dataGridView1.Columns[1].HeaderText = "Application Type Title";
            dataGridView1.Columns[1].Width = 250;

            dataGridView1.Columns[2].HeaderText = "Application Fees";
            dataGridView1.Columns[2].Width = 200;
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateAppType update = new frmUpdateAppType((int)dataGridView1.CurrentRow.Cells[0].Value);
            update.ShowDialog();
            frmManageAppType_Load(null,null);
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
