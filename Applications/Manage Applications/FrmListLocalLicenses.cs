using Bussiness_Layer;
using DVLD.Applications.Manage_Applications;
using DVLD.Applications.Manage_Applications.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    ClsBussinessLocalDrivingLicense local_pp = ClsBussinessLocalDrivingLicense.find_local_license_by_id((int)dataGridView1.CurrentRow.Cells[0].Value);
                    local_pp.delete_local_license();
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
            FrmShowTest frm = new FrmShowTest((int)dataGridView1.CurrentRow.Cells[0].Value,1);
            frm.ShowDialog();
            _refresh();

        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowTest frm = new FrmShowTest((int)dataGridView1.CurrentRow.Cells[0].Value,2);
            frm.ShowDialog();
            _refresh();

        }

        private void speedTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowTest frm = new FrmShowTest((int)dataGridView1.CurrentRow.Cells[0].Value,3);
            frm.ShowDialog();
            _refresh();

        }

        private void context_on_opening(object sender, CancelEventArgs e)
        {
            ClsBussinessLocalDrivingLicense laocal_app = ClsBussinessLocalDrivingLicense.find_local_license_by_id((int)dataGridView1.CurrentRow.Cells[0].Value);
            bool passed_vision = laocal_app.GetPassedTestByLocalLicense(1);
            bool passed_written = laocal_app.GetPassedTestByLocalLicense(2);
            bool passed_speed = laocal_app.GetPassedTestByLocalLicense(3);
            if (laocal_app.app_status == 3)
            {
                cancelApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
            }
            else if (laocal_app.app_status == 2)
            {
                cancelApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
            }
            else
            {
                cancelApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                scheduleTestToolStripMenuItem.Enabled = true;

                visionTestToolStripMenuItem.Enabled = !passed_vision;
                writtenTestToolStripMenuItem.Enabled = passed_vision && !passed_written;
                speedTestToolStripMenuItem.Enabled = passed_vision && passed_written && !passed_speed;
            }




        }
    }
}
