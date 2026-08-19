using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLocalLicense_view_namespace
{
    public class DTOLicense_view
    {
        public int app_id { get; set; }
        public string class_name { get; set; }

        public string national_num { get; set; }

        public string fullname { get; set; }
        public DateTime date { get; set; }

        public int passed_tests { get; set; }

        public string status { get; set; }

        public DTOLicense_view(int id, string classname, string fullname, 
            string national_num, DateTime date, int passed, string status)
        {
            this.app_id = id;
            this.class_name = classname;
            this.fullname = fullname;
            this.national_num = national_num;
            this.date = date;
            this.passed_tests = passed;
            this.status = status;
        }
    }
}
