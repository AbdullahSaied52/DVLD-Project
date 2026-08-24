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
    public partial class FrmVisionTest : Form
    {
        int _id;
        public FrmVisionTest(int local_id)
        {
            InitializeComponent();
            _id = local_id;
        }
        private void _refresh()
        {
            ctrlApplicationInfo1.load_data(_id);
            dataGridView1.DataSource = ClsBussinessTestAppointment.get_test_by_id_per_type(_id, 1);// 1 for vision
        }
        private void FrmVisionTest_Load(object sender, EventArgs e)
        {
            _refresh();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSchedualeVisionTest frm = new FrmSchedualeVisionTest(_id);
            frm.ShowDialog();
        }
    }
}
