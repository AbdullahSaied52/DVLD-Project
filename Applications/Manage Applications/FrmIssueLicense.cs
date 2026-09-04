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

namespace DVLD.Applications.Manage_Applications
{
    public partial class FrmIssueLicense : Form
    {
        int _local_license_id;
        public FrmIssueLicense(int local_license_id)
        {
            _local_license_id = local_license_id;
            InitializeComponent();
        }

        private void FrmIssueLicense_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.load_data(_local_license_id);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            ClsBussinessLocalDrivingLicense local_license = ClsBussinessLocalDrivingLicense.find_local_license_by_id(_local_license_id);

            ClsBUssinessDriver driver = new ClsBUssinessDriver();
            driver.person_id = local_license.person_id;
            driver.created_by_user_id = local_license.user_id;
            driver.date = DateTime.Now;
            driver.add_new_driver();

            ClsBussinessLicenses license = new ClsBussinessLicenses();
            license.expired_date = DateTime.Now.AddYears(local_license.liecense_info.validate_length);
            license.issue_date = DateTime.Now;
            license.app_id = local_license.app_id;
            license.user_id = local_license.user_id;
            license.notes = textBox1.Text;
            license.driver_id = driver.driver_id;
            license.issue_reason = 1; //1 for new 
            license.active = 1;
            license.fees = local_license.liecense_info.license_fees;
            license.license_class_id = local_license.license_class_id;
            license.add_new_license();

            MessageBox.Show("Added ");
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
