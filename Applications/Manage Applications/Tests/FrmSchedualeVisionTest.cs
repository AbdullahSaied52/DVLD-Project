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
    public partial class FrmSchedualeVisionTest : Form
    {

        public enum e_test_type { vision=0,written =1, speed=2}
        public static FrmSchedualeVisionTest.e_test_type enum_test_type { get; set; }
        int test_type_id { get; set; }

        int _local_license_id;
        ClsBussinessLocalDrivingLicense app;
        ClsBussinessTestAppointment test;
        int test_appointment_id;
        public FrmSchedualeVisionTest(int local_license_id,int appointment_id=-1)
        {
            _local_license_id = local_license_id;
            test_appointment_id = appointment_id;
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
                return 10;

            }
            else if (enum_test_type == e_test_type.written)
            {
                lbltitle.Text = "Written Test Appointment";
                lblfees.Text = "20";
                return 20;
            }
            else
            {
                lbltitle.Text = "Speed Test Appointment";
                lblfees.Text = "35";
                return 35;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            test = new ClsBussinessTestAppointment();
            app.date = dateTimePicker1.Value;
            test.date = dateTimePicker1.Value;
            test.local_license_id = app.local_license_id;
            test.fees = test_fees();
            test.locked = 0;
            test.createby_user_id = app.user_id;
            test.test_type_id = test_type_id;
            if (test_appointment_id == -1)
            {
                test.add_test_appointment();
                MessageBox.Show("Added");
            }
            else
            {
                test.test_id = test_appointment_id;
                test.update_test_appointment();
                MessageBox.Show("updated");
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
            
            lblfees.Text = app.fees_for_app.ToString();
            lbllicenseclass.Text = app.liecense_info.license_name;
            lblname.Text = app.person.FirstName + " " + app.person.SecondName;
            lbllicenseclass.Text = app.liecense_info.license_name;
            lbltrial.Text = "not handled yet";
            lblretakefees.Text = "not handled yet";
            lbltotalfees.Text = "not handled yet";

        }
    }
}
