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
    public partial class FrmSchedualeTest : Form
    {

        public enum e_test_type { vision=0,written =1, speed=2}
        public static FrmSchedualeTest.e_test_type enum_test_type { get; set; }
        public int test_type_id { get; set; }

        int _local_license_id;
        ClsBussinessLocalDrivingLicense app;
        ClsBussinessTestAppointment appointment;
        int _test_appointment_id;
        int _is_retake_test;
        public FrmSchedualeTest(int local_license_id,int appointment_id=-1,int retake=-1)
        {
            _local_license_id = local_license_id;
            _test_appointment_id = appointment_id;
            _is_retake_test = retake;
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private float test_fees()
        {
            if (enum_test_type == e_test_type.vision)
            {
                lbltitle.Text = "Vision Test Appointment";
                lblfees.Text = "10";
                test_type_id = 1;
                return 10;

            }
            else if (enum_test_type == e_test_type.written)
            {
                lbltitle.Text = "Written Test Appointment";
                lblfees.Text = "20";
                test_type_id = 2;
                return 20;
            }
            else
            {
                lbltitle.Text = "Speed Test Appointment";
                lblfees.Text = "35";
                test_type_id = 3;
                return 35;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            appointment = new ClsBussinessTestAppointment();
            app.date = dateTimePicker1.Value;
            appointment.date = dateTimePicker1.Value;
            appointment.local_license_id = app.local_license_id;
            appointment.fees = test_fees();
            appointment.locked = 0;
            appointment.createby_user_id = app.user_id;
            appointment.test_type_id = test_type_id;



            if (_test_appointment_id == -1)
            {
                appointment.add_test_appointment();
                MessageBox.Show("Added");
            }
            else
            {
                if (_is_retake_test != -1)
                {
                    appointment.retake_test_id = _test_appointment_id;
                    appointment.add_test_appointment();
                    MessageBox.Show("Add a retake test");
                }
                else
                {
                    appointment.test_id = _test_appointment_id;
                    appointment.update_test_appointment();
                    MessageBox.Show("updated");
                }
            }
        }
        private void _refresh()
        {
            dateTimePicker1.MinDate = DateTime.Now;


            if (enum_test_type == e_test_type.vision)
            {
                lbltitle.Text = "Vision Test Appointment";
                lblfees.Text = "10";
                test_type_id = 1;
            }
            else if (enum_test_type == e_test_type.written)
            {
                lbltitle.Text = "Written Test Appointment";
                lblfees.Text = "20";
                test_type_id = 2;
            }
            else
            {
                lbltitle.Text = "Speed Test Appointment";
                lblfees.Text = "35";
                test_type_id = 3;
            }
        }
        private void FrmSchedualeVisionTest_Load(object sender, EventArgs e)
        {
            _refresh();
            app = ClsBussinessLocalDrivingLicense.find_local_license_by_id(_local_license_id);
            
            //lblfees.Text = app.fees_for_app.ToString();
            lbllicenseclass.Text = app.liecense_info.license_name;
            lblname.Text = app.person.FirstName + " " + app.person.SecondName;
            lbllicenseclass.Text = app.liecense_info.license_name;
            lbltrial.Text = "not handled yet";
            lblretakefees.Text = "not handled yet";
            lbltotalfees.Text = "not handled yet";

        }
    }
}
