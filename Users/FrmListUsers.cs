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

namespace DVLD.Users
{
    public partial class FrmListUsers : Form
    {
        public FrmListUsers()
        {
            InitializeComponent();
        }
        private void _refesh()
        {
            dataGridView1.DataSource = ClsBussinessUser.list_user();
            dataGridView1.Columns["password"].Visible = false;
        }

        private void FrmListUsers_Load(object sender, EventArgs e)
        {
            _refesh();
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            FrmAdd_Edit_User frm = new FrmAdd_Edit_User(-1);
            frm.ShowDialog();
            _refesh();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdd_Edit_User frm = new FrmAdd_Edit_User((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refesh();

        }
    }
}
