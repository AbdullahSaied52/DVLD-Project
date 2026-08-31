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
    public partial class FrmShowTest : Form
    {
        int _local_license_id;
        ClsBussinessTestAppointment appointment;
        int _test_type;
        public FrmShowTest(int local_id,int test_type)
        {
            InitializeComponent();
            _local_license_id = local_id;
            _test_type = test_type;
        }
        private void _refresh()
        {
            switch (_test_type)
            {
                case 1:lbltitle.Text = "Vision Test Appointment";
                    FrmSchedualeTest.enum_test_type = FrmSchedualeTest.e_test_type.vision;
                    break;
                case 2:lbltitle.Text = "Written Test Appointment";
                    FrmSchedualeTest.enum_test_type = FrmSchedualeTest.e_test_type.written;
                    break;
                case 3:lbltitle.Text = "Speed Test Appointment";
                    FrmSchedualeTest.enum_test_type = FrmSchedualeTest.e_test_type.speed;
                    break;
            }
            ctrlApplicationInfo1.load_data(_local_license_id);
            dataGridView1.DataSource = ClsBussinessTestAppointment.get_test_by_id_per_type(_local_license_id, _test_type);

        }
        private void FrmVisionTest_Load(object sender, EventArgs e)
        {
            _refresh();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appointment = ClsBussinessTestAppointment.get_last_appointment(_local_license_id, _test_type);
            if( appointment==null)
            {
                FrmSchedualeTest frm = new FrmSchedualeTest(_local_license_id);
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
                    if (ClsBussinessTests.is_passed(appointment.test_id))
                    {
                        MessageBox.Show("this person passed the test");
                    }
                    else
                    {
                        // configure the form for retake test
                        FrmSchedualeTest frm = new FrmSchedualeTest(_local_license_id,appointment.test_id,1); //1 to retake test
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
            appointment = ClsBussinessTestAppointment.get_appointmnet_by_id((int)dataGridView1.CurrentRow.Cells[0].Value);
            if (appointment.locked == 1)
                MessageBox.Show("Can't edit it as it LOCKED");
            else
            {
                FrmSchedualeTest frm = new FrmSchedualeTest(_local_license_id, (int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _refresh();
            }
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appointment = ClsBussinessTestAppointment.get_appointmnet_by_id((int)dataGridView1.CurrentRow.Cells[0].Value);
            if (appointment.locked == 1)
                MessageBox.Show("Can't edit it as it LOCKED");
            else
            {
                FrmTakeTest frm = new FrmTakeTest((int)dataGridView1.CurrentRow.Cells[0].Value, _test_type);
                frm.ShowDialog();
                _refresh();
            }
        }
    }
}
