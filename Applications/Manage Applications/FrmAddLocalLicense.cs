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
        DTOPerson p;
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
            p = ClsBussinessperson.get_person_by_national_num(textBox1.Text);
            if (p != null)
            {
                btnnext.Enabled = true;
                cntrl_Show1.fill_data_by_id(p.PersonID);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (p != null)
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            else
                MessageBox.Show("not exist");

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            app = new DTOApplication();
            app.app_status = 1;
            app.date = DateTime.Now;
            app.app_type_id = 1;                // as he want to add new local license
            app.last_status_date = DateTime.Now;
            app.fees = ClsBussinessManageLocalLicenses.license_fees_by_id(comboBox1.SelectedIndex + 1);

            ClsBussinessApplications.add_new_app(app);
            MessageBox.Show("Added");
        }
    }
}
