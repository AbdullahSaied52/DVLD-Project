using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class Frm_add_edit_person : Form
    {
        int _id;
        public Frm_add_edit_person(int id)
        {
            InitializeComponent();
            _id = id;
            cntrl_Add_Edit1.add_edit(_id);
        }

        private void Frm_add_edit_person_Load(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            cntrl_Add_Edit1.save_data();
        }
    }
}
