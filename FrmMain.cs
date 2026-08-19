using DVLD.Login;
using DVLD.Manage_Application_Types;
using DVLD.Manage_Applications;
using DVLD.Manage_Test_Types;
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

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListApplicationTypes frm = new FrmListApplicationTypes();
            frm.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListTestTypes frm = new FrmListTestTypes();
            frm.Show();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListLocalLicenses frm = new FrmListLocalLicenses();
            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddLocalLicense frm = new FrmAddLocalLicense();
            frm.ShowDialog();
        }
    }
}
