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
    public partial class Cntrl_Show : UserControl
    {
        DTOPerson person;

        public Cntrl_Show()
        {
            InitializeComponent();
        }

        private void Cntrl_Show_Load(object sender, EventArgs e)
        {

        }
        private void _fill_compobox()
        {
            var countries = ClsBussinessperson.list_countries();
            foreach (var x in countries)
            {
                comboBox1.Items.Add(x.country_name);
            }
        }

        public void fill_data_by_id(int id)
        {
            comboBox1.Items.Clear();
            _fill_compobox();
            if (id == -1)
            {
                header.Text = "Add Person";
                label13.Text = "N/L";
                person = new DTOPerson();
                dateTimePicker1.Value = DateTime.Now.AddYears(-18);
                return;
            }
            header.Text = "Person Information";
            person = ClsBussinessperson.get_person_by_id(id);
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

    }
}
