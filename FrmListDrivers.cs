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

namespace DVLD
{
    public partial class FrmListDrivers : Form
    {
        public FrmListDrivers()
        {
            InitializeComponent();
        }

        private void FrmListDrivers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ClsBUssinessDriver.get_all_drivers();
        }
    }
}
