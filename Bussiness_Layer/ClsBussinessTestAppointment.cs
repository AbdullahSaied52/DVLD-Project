using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessTestAppointment
    {
        public int test_id { get; set; }
        public int test_type_id { get; set; }
        public int local_license_id { get; set; }
        public DateTime date { get; set; }

        public int fees { get; set; }
        public int createby_user_id { get; set; }
        public short locked { get; set; }

        public ClsBussinessTestAppointment()
        {
            this.test_id = -1;
            this.test_type_id = -1;
            this.date = DateTime.Now;
            this.fees = 0;
            this.createby_user_id = -1;
            this.local_license_id = -1;
            this.locked = 0;

        }
        public ClsBussinessTestAppointment(int tesid,int testtypeid,int locallicense_id,DateTime date,int fees,int user_id,short locked)
        {
            this.test_id = tesid;
            this.test_type_id = testtypeid;
            this.date = date;
            this.fees = fees;
            this.createby_user_id = user_id;
            this.local_license_id = locallicense_id;
            this.locked = locked;
        }


        
    }
}
