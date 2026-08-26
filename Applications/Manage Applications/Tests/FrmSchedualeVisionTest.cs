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
        int _local_license_id;
        int _test_type_id;
        ClsBussinessLocalDrivingLicense app;
        ClsBussinessTestAppointment test;
        public FrmSchedualeVisionTest(int id,int testtype_id)
        {
            _local_license_id = id;
            _test_type_id = testtype_id;
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
            if (_test_type_id == 1)
            {
                lbltitle.Text = "Vision Test Appointment";
                lblfees.Text = "10";
                return 10;

            }
            else if (_test_type_id == 2)
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
            dateTimePicker1.MinDate = DateTime.Now;
            app.date = dateTimePicker1.Value;
            test.date = app.date;
            test.local_license_id = app.local_license_id;
            test.fees = test_fees();
            test.locked = 0;
            test.createby_user_id = app.user_id;
            test.test_type_id = _test_type_id;
            test.add_test_appointment();
            MessageBox.Show("Added");
        }

        private void FrmSchedualeVisionTest_Load(object sender, EventArgs e)
        {
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
