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

namespace DVLD.People
{
    public partial class FrmListPeople : Form
    {
        public FrmListPeople()
        {
            InitializeComponent();
        }

        private void _refresh()
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = ClsBussinessperson.list_all();
            dataGridView1.Columns["Gendor_bit"].Visible = false;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["PersonID"].HeaderText = "Person ID";
                dataGridView1.Columns["PersonID"].Width = 50;

                dataGridView1.Columns["NationalNo"].HeaderText = "National No.";
                dataGridView1.Columns["NationalNo"].Width = 50;

                dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                dataGridView1.Columns["FirstName"].Width = 60;

                dataGridView1.Columns["SecondName"].HeaderText = "Second Name";
                dataGridView1.Columns["SecondName"].Width = 60;

                dataGridView1.Columns["ThirdName"].HeaderText = "Third Name";
                dataGridView1.Columns["ThirdName"].Width = 60;

                dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                dataGridView1.Columns["LastName"].Width = 60;

                dataGridView1.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
                dataGridView1.Columns["DateOfBirth"].Width = 100;

                dataGridView1.Columns["Gendor_string"].HeaderText = "Gendor";
                dataGridView1.Columns["Gendor_string"].Width = 60;

                dataGridView1.Columns["Address"].HeaderText = "Address";
                dataGridView1.Columns["Address"].Width = 100;

                dataGridView1.Columns["Phone"].HeaderText = "Phone";
                dataGridView1.Columns["Phone"].Width = 50;

                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["Email"].Width = 60;

                dataGridView1.Columns["Country"].HeaderText = "Country Name";
                dataGridView1.Columns["Country"].Width = 100;


            }
        }

        private void FrmListPeople_Load(object sender, EventArgs e)
        {
            _refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1)
            {
                switch (comboBox1.Text)
                {
                    case "Person ID":
                        dataGridView1.DataSource = new List<DTOPerson> { ClsBussinessperson.get_person_by_id(Int32.Parse(textBox1.Text)) };
                        break;
                    case "National Number":
                        dataGridView1.DataSource = new List<DTOPerson> { ClsBussinessperson.get_person_by_national_num(textBox1.Text) };//list_all().Where(p => p.NationalNo.ToString() == textBox1.Text).ToList();
                        break;
                    case "Phone":
                        dataGridView1.DataSource = ClsBussinessperson.list_all().Where(p => p.Phone.ToString() == textBox1.Text).ToList();
                        break;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("do you want to delet " + dataGridView1.CurrentRow.Cells[2].Value + " " + dataGridView1.CurrentRow.Cells[3].Value, " confirm delete ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ClsBussinessperson.delete_person((int)dataGridView1.CurrentRow.Cells[0].Value);
                MessageBox.Show("contact deleted");
                _refresh();
            }
        }
    }
}
