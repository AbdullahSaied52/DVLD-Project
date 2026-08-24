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
        int _id;
        public FrmSchedualeVisionTest(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmSchedualeVisionTest_Load(object sender, EventArgs e)
        {
            ClsBussinessLocalDrivingLicense app = ClsBussinessLocalDrivingLicense.find_local_license_by_id(_id);
            lblfees.Text = app.fees_for_app.ToString();
            lbllicenseclass.Text = app.liecense_info.license_name;
            lblname.Text = app.person.FirstName + " " + app.person.SecondName;
            
        }
    }
}
