using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Manage_Applications.Tests
{
    public partial class FrmVisionTest : Form
    {
        int _local_license_id;
        public FrmVisionTest(int local_id)
        {
            InitializeComponent();
            _local_license_id = local_id;
        }
        private void _refresh()
        {
            ctrlApplicationInfo1.load_data(_local_license_id);
            dataGridView1.DataSource = ClsBussinessTestAppointment.get_test_by_id_per_type(_local_license_id, 1);// 1 for vision
        }
        private void FrmVisionTest_Load(object sender, EventArgs e)
        {
            _refresh();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsBussinessTestAppointment appointment = ClsBussinessTestAppointment.get_last_appointment(_local_license_id, 1);
            if( appointment==null)
            {
                FrmSchedualeVisionTest frm = new FrmSchedualeVisionTest(_local_license_id);// 1 for vision test
                frm.ShowDialog();
            }
            else
            {
                if (appointment.locked == 0)
                {

                    MessageBox.Show("this person has an active test");

                }
                else
                {
                    if (ClsBussinessTests.is_passed((int)dataGridView1.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("this person passed the test");
                    }
                    else
                    {
                        // configure the form for retake test
                        FrmSchedualeVisionTest frm = new FrmSchedualeVisionTest(_local_license_id);
                        frm.ShowDialog();
                    }
                }
            }
            _refresh();
        }

        private void ctrlApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSchedualeVisionTest frm = new FrmSchedualeVisionTest(_local_license_id, (int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refresh();
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTakeTest frm = new FrmTakeTest((int)dataGridView1.CurrentRow.Cells[0].Value, 1);
            frm.ShowDialog();
            _refresh();
        }
    }
}
