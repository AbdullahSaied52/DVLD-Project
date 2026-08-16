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

        private void FrmListUsers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ClsBussinessUser.list_user();
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {

        }
    }
}
