using Bussiness_Layer;
using DTOPerson_namespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Control
{
    public partial class Cntrl_Add_Edit : UserControl
    {
        DTOPerson person;
        int _id;
        public Cntrl_Add_Edit()
        {
            InitializeComponent();
        }

        private void Cntrl_Add_Edit_Load(object sender, EventArgs e)
        {

        }

        private void add_new(DTOPerson p)
        {
            ClsBussinessperson.add_new_person(p);
        }
        private void update(DTOPerson p)
        {
            ClsBussinessperson.update_person(p);
        }

        private void _fill_compobox()
        {
            var countries = ClsBussinessperson.list_countries();
            foreach (var x in countries)
            {
                comboBox1.Items.Add(x.country_name);
            }
        }

        public void add_edit(int id)
        {
            _id = id;
            comboBox1.Items.Clear();
            _fill_compobox();
            if (_id == -1)
            {
                header.Text = "Add Person";
                label13.Text = "N/L";
                dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
                dateTimePicker1.Value = dateTimePicker1.MaxDate;
                return;
            }
            header.Text = "Person Information";
            person = ClsBussinessperson.get_person_by_id(_id);
            label13.Text = person.PersonID.ToString();
            txtfname.Text = person.FirstName;
            txtlname.Text = person.LastName;
            txtsname.Text = person.SecondName;
            txtthname.Text = person.ThirdName;
            txtaddress.Text = person.Address;
            comboBox1.SelectedIndex = comboBox1.FindString(person.Country);
            txtemail.Text = person.Email;
            txtphone.Text = person.Phone;
            txtnationalnumber.Text = person.NationalNo;
            dateTimePicker1.Value = person.DateOfBirth;
            if (person.Gendor_bit == 0)
                radioButton2.Checked = true;
            else
                radioButton1.Checked = true;

        }

        public void save_data()
        {
            person = new DTOPerson();

            person.Email = txtemail.Text;
            person.Address = txtaddress.Text;
            if (radioButton2.Checked == true)
                person.Gendor_bit = 0;
            else
                person.Gendor_bit = 1;
            person.NationalNo = txtnationalnumber.Text;
            person.Country = comboBox1.Text;
            person.DateOfBirth = dateTimePicker1.Value;
            person.Phone = txtphone.Text;
            person.FirstName = txtfname.Text;
            person.SecondName = txtsname.Text;
            person.ThirdName = txtthname.Text;
            person.LastName = txtlname.Text;
            if (_id == -1)
                add_new(person);
            else
            {
                person.PersonID = _id;
                update(person);
            }
            MessageBox.Show("saved");
        }
        private void national_number_validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtnationalnumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtnationalnumber, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtnationalnumber, null);
            }

            if (ClsBussinessperson.if_nationalNO_exist(txtnationalnumber.Text.Trim()))
            {
                errorProvider1.SetError(txtnationalnumber, "this number is used");
            }
            else
            {
                errorProvider1.SetError(txtnationalnumber, null);
            }
        }

        private void firstname_validate(object sender, CancelEventArgs e)
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

        private void seconname_validate(object sender, CancelEventArgs e)
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

    }
}
