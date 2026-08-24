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

namespace DVLD.Applications.Manage_Applications.Tests.Comtrol
{
    public partial class CtrlApplicationInfo : UserControl
    {
        public CtrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void CtrlApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void load_data(int id)
        {
            ClsBussinessLocalDrivingLicense app = ClsBussinessLocalDrivingLicense.find_local_license_by_id(id);

            lblapplicant.Text = app.person.FirstName + " " + app.person.SecondName;
            lblcreatedby.Text = app.userinfo.name;
            lbldate.Text = app.date.ToString();
            lblfees.Text = app.fees_for_app.ToString();
            switch (app.app_status)
            {
                case 1:
                    lblstatus.Text = "New";
                    break;
                case 2:
                    lblstatus.Text = "Canceled";
                    break;
                case 3:
                    lblstatus.Text = "Completed";
                    break;
            }
            lbltype.Text = app.app_type.title;
            lblstatusdate.Text = app.last_status_date.ToString();
        }
    }
}
