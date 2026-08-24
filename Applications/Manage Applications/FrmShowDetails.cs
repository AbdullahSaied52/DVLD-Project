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
    public partial class FrmShowDetails : Form
    {
        int _local_license_id;
        public FrmShowDetails(int id)
        {
            _local_license_id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShowDetails_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.load_data(_local_license_id);
        }

        private void ctrlApplicationInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
