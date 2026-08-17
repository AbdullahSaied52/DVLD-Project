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

namespace DVLD.Manage_Applications
{
    public partial class FrmListLocalLicenses : Form
    {
        public FrmListLocalLicenses()
        {
            InitializeComponent();
        }

        private void _refresh()
        {
            dataGridView1.DataSource = ClsBussinessManageLocalLicenses.list_license_view();
        }

        private void FrmListLocalLicenses_Load(object sender, EventArgs e)
        {
            _refresh();
        }
    }
}
