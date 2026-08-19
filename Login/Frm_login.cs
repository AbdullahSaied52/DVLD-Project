using Bussiness_Layer;
using DTOUsers_namespace;
using DVLD.Global_info;
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

namespace DVLD.Login
{
    public partial class Frm_login : Form
    {
        public Frm_login()
        {
            InitializeComponent();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            DTOUser user = ClsSaveLastLogin.read_from_file();
            if (user != null)
            {
                checkBox1.Checked = true;
                txtusername.Text = user.name;
                txtpass.Text = user.password;
            }
            else
                checkBox1.Checked = false;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            DTOUser user = ClsBussinessUser.get_user_by_username(txtusername.Text);
            if (user != null)
            {
                if (user.password == txtpass.Text)
                {
                    if (user.active == false)
                    {
                        MessageBox.Show("not active ");
                    }
                    else
                    {
                        if (checkBox1.Checked == true)
                        {
                            ClsSaveLastLogin.save_to_file(user.name, user.password);
                            ClsGlobal.current_user = user;
                        }
                        else
                            ClsSaveLastLogin.save_to_file("", "");

                        this.Hide();
                        FrmMain frm = new FrmMain(this);
                        frm.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("not correct username or password");
            }
            else
                MessageBox.Show("not correct username or password");
        }

        private void validate_username(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }



        private void validate_pass(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
