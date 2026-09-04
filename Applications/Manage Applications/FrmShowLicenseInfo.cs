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
    public partial class FrmShowLicenseInfo : Form
    {
        int _local_license_id;
        public FrmShowLicenseInfo(int local_id)
        {
            _local_license_id = local_id;
            InitializeComponent();
        }

        private void FrmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ClsBussinessLocalDrivingLicense local_license = ClsBussinessLocalDrivingLicense.find_local_license_by_id(_local_license_id);
            ClsBussinessLicenses license = ClsBussinessLicenses.find_license_by_app_id(local_license.app_id);
            lblclass.Text = local_license.liecense_info.license_name;
            lblexpireddate.Text = license.expired_date.ToString();
            lblissuedate.Text = license.issue_date.ToString();
            lblname.Text = local_license.person.FirstName + " " + local_license.person.SecondName;
            lblgendor.Text = local_license.person.Gendor_string;
            if (license.active == 1)
                lblisactive.Text = "Active";
            else
                lblisactive.Text = "Not Active";
            lblissuereason.Text = "First Time";
            lblnationalnum.Text = local_license.person.NationalNo;
            lblnotes.Text = license.notes;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
