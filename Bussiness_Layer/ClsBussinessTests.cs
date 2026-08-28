using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessTests
    {
        public int test_id { get; set; }
        public int test_appointment_id { get; set; }
        public string notes { get; set; }
        public int result { get; set; }
        public int user_id { get; set; }

        public ClsBussinessTests()
        {
            this.test_id = -1;
            this.test_appointment_id = -1;
            this.notes = "";
            this.result = -1;
            this.user_id = -1;
        }

        public ClsBussinessTests(int test_id,int appointment_id,string notes,int result,int user_id)
        {
            this.test_id = test_id;
            this.test_appointment_id = appointment_id;
            this.notes = notes;
            this.result = result;
            this.user_id = user_id;
        }


        public void add_new_test()
        {
            this.test_id =
            ClsDataTests.add_new_test(this.test_appointment_id, this.result, this.notes, this.user_id);
        }

        public static bool is_passed(int appointment_id)
        {
            return ClsDataTests.is_passed(appointment_id) > 0 ? true : false;
        }
    }
}
