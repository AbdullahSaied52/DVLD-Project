using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Manage_Applications.Tests
{
    public partial class FrmTakeTest : Form
    {
        int _test_appointment_id;
        int _local_license_id;
        int _test_type;
        ClsBussinessTestAppointment appointment;
        ClsBussinessLocalDrivingLicense local_license;
        public FrmTakeTest(int appointment_id,int test_type)
        {
            _test_appointment_id = appointment_id;
            _test_type = test_type;
            InitializeComponent();
        }

        private void FrmTakeTest_Load(object sender, EventArgs e)
        {
            appointment       = ClsBussinessTestAppointment.get_appointmnet_by_id(_test_appointment_id);
            local_license = ClsBussinessLocalDrivingLicense.find_local_license_by_id(appointment.local_license_id);
            lblfees.Text = appointment.fees.ToString();
            lbllicenseclass.Text = local_license.liecense_info.license_name;
            lbldate.Text = appointment.date.ToString();
            lblname.Text = local_license.person.FirstName + " " + local_license.person.SecondName;

        }

        private void btncalncel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            ClsBussinessTests test = new ClsBussinessTests();
            test.notes = textBox1.Text;
            if (rdpass.Checked == true)
                test.result = 1;
            else
                test.result = 0;
            test.test_appointment_id = _test_appointment_id;
            test.user_id = appointment.createby_user_id;
            test.add_new_test();
            MessageBox.Show("Saved");
        }
    }
}
