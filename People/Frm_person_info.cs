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
    public partial class Frm_person_info : Form
    {
        int _id;
        public Frm_person_info(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void Frm_person_info_Load(object sender, EventArgs e)
        {
            cntrl_Show1.load(_id);
        }


    }
}
