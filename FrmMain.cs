using DVLD.Login;
using DVLD.People;
using DVLD.Users;
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
    public partial class FrmMain : Form
    {
        Frm_login _login;
        public FrmMain(Frm_login frm)
        {
            InitializeComponent();
            _login = frm;
        }

        private void peopleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmListPeople frm = new FrmListPeople();
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListUsers frm = new FrmListUsers();
            frm.Show();
        }
    }
}
