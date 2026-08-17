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

namespace DVLD.Manage_Test_Types
{
    public partial class FrmListTestTypes : Form
    {
        public FrmListTestTypes()
        {
            InitializeComponent();
        }

        private void _refresh()
        {
            dataGridView1.DataSource = ClsBussinessApplication_test_types.list_all_tests();
        }
        private void FrmListTestTypes_Load(object sender, EventArgs e)
        {
            _refresh();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditTestType frm = new FrmEditTestType((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refresh();
        }
    }
}
