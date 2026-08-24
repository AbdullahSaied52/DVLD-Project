using Bussiness_Layer;
using DVLD.Applications.Manage_Applications;
using DVLD.Applications.Manage_Applications.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_Applications
{
    public partial class FrmListLocalLicenses : Form
    {
        public FrmListLocalLicenses()
        {
            InitializeComponent();
        }

        private void _refresh()
        {
            dataGridView1.DataSource = ClsBussinessManageLocalLicenses.list_license_view();
        }

        private void FrmListLocalLicenses_Load(object sender, EventArgs e)
        {
            _refresh();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsBussinessApplications.cancel_application_by_app_id((int)dataGridView1.CurrentRow.Cells[0].Value);
            _refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddLocalLicense frm = new FrmAddLocalLicense(-1);
            frm.ShowDialog();
            _refresh();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmShowDetails frm = new FrmShowDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("do you want to delet " + dataGridView1.CurrentRow.Cells[3].Value, " confirm delete ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ClsBussinessLocalDrivingLicense.delete_local_license((int)dataGridView1.CurrentRow.Cells[0].Value);
                MessageBox.Show("Application deleted");
                _refresh();
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddLocalLicense frm = new FrmAddLocalLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refresh();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisionTest frm = new FrmVisionTest((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
