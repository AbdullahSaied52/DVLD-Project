using Bussiness_Layer;
using DTO_Test_types_namespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_Test_Types
{
    public partial class FrmEditTestType : Form
    {
        int _id;
        DTOTest_types test;
        public FrmEditTestType(int id)
        {
            _id = id;
            test = ClsBussinessApplication_test_types.get_test_by_id(_id);
            InitializeComponent();
        }

        private void FrmEditTestType_Load(object sender, EventArgs e)
        {
            textBox1.Text = test.title;
            textBox3.Text = test.description;
            textBox2.Text = test.fees.ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           test.title= textBox1.Text  ;
            test.description=textBox3.Text  ;
            test.fees =Convert.ToDecimal( textBox2.Text) ;
            ClsBussinessApplication_test_types.update_test(test);
            MessageBox.Show("Saved");
        }
    }
}
