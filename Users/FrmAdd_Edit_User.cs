using Bussiness_Layer;
using DTOPerson_namespace;
using DTOUsers_namespace;
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
    public partial class FrmAdd_Edit_User : Form
    {
        DTOPerson _person;
        DTOUser _user;
        int _id;
        public FrmAdd_Edit_User(int id)
        {
            _id = id;
            _user = ClsBussinessUser.get_user_ByID(_id);
            InitializeComponent();
        }

        private void cntrl_Add_Edit1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _person = ClsBussinessperson.get_person_by_national_num(textBox1.Text);
            if (_person != null)
                cntrl_Show1.fill_data_by_id(_person.PersonID);
            else
                MessageBox.Show("not found");
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (ClsBussinessUser.if_user_exists(_person.PersonID))
            {
                errorProvider1.SetError(btnnext, "selected person is a user");
                
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                return;
            }
        }

        private void FrmAdd_Show_User_Load(object sender, EventArgs e)
        {
            if(_id==-1)
            {
                textBox1.Enabled = true;
                label1.Enabled = true;
                btnsearch.Enabled = true;
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                textBox3.Text = _user.name;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void btncancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != textBox2.Text)
                errorProvider1.SetError(textBox4, "not match");
            else
            {
                _user.name = textBox3.Text;
                _user.password = textBox4.Text;
                if (checkBox1.Checked == true)
                    _user.active = true;
                else
                    _user.active = false;
                ClsBussinessUser.update_user(_user);
                MessageBox.Show("Saved");
            }
        }
    }
}
