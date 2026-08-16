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
    public partial class FrmShowUserInfo : Form
    {
        int _id;
        public FrmShowUserInfo(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void FrmShowUserInfo_Load(object sender, EventArgs e)
        {
            cntrl_Show1.fill_data_by_id(_id);
        }
    }
}
