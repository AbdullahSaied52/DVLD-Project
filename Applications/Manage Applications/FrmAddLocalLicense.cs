using Bussiness_Layer;
using DTOApplication_namespace;
using DTOPerson_namespace;
using DVLD.Global_info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_Applications
{
    
    public partial class FrmAddLocalLicense : Form
    {
        DTOPerson person;
        DTOApplication app;
        public FrmAddLocalLicense()
        {
            InitializeComponent();
        }

        private void FrmAddLocalLicense_Load(object sender, EventArgs e)
        {
            btnnext.Enabled = false;
            lbldate.Text = DateTime.Now.ToString();
            lbluser.Text = ClsGlobal.current_user.name;
            var classes = ClsBussinessManageLocalLicenses.list_licesnse_names();
            foreach (var x in classes)
            {
                comboBox1.Items.Add(x);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            person = ClsBussinessperson.get_person_by_national_num(textBox1.Text);
            if (person != null)
            {
                btnnext.Enabled = true;
                cntrl_Show1.fill_data_by_id(person.PersonID);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (person != null)
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            else
                MessageBox.Show("not exist");

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            app = new DTOApplication();
            app.person_id = person.PersonID;
            app.user_id = ClsGlobal.current_user.id;
            app.app_status =(int) DTOApplication.enApplicationStatus.New;
            app.date = DateTime.Now;
            app.app_type_id = (int) DTOApplication.enApplicationType.NewLocalDrivingLicense;                // as he want to add new local license
            app.last_status_date = DateTime.Now;
            app.fees_for_app = 15; // as it new local license
            if (ClsBussinessApplications.if_app_exist(app))
            {
                MessageBox.Show("this application is exists");
            }
            else

            {
                ClsBussinessApplications.add_new_app(app);
                ClsBussinessApplications.add_new_local_license(app.app_id, comboBox1.SelectedIndex + 1);
                MessageBox.Show("Added");
            }
        }

        private void btncancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
