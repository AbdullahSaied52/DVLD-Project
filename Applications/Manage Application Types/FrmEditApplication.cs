using Bussiness_Layer;
using DTO_Test_types_namespace;
using DTOApplication_types_namespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_Application_Types
{
    public partial class FrmEditApplication : Form
    {
        int _id;
        DTOApplication_types app;
        public FrmEditApplication(int id)
        {
            _id = id;
            app = ClsBussinessApplication_test_types.get_application_by_id(_id);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            app.title = textBox1.Text;
            app.fees = Convert.ToDecimal(textBox2.Text);
            ClsBussinessApplication_test_types.update_app(app);
            MessageBox.Show("Saved");
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditApplication_Load(object sender, EventArgs e)
        {
            textBox1.Text = app.title;
            textBox2.Text = app.fees.ToString();
        }
    }
}
