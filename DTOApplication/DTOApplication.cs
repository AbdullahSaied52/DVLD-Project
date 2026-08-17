using DTOApplication_types_namespace;
using DTOPerson_namespace;
using DTOUsers_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOApplication_namespace
{
    public class DTOApplication
    {
        public int app_id { get; set; }
        public int person_id { get; set; }
        public DTOPerson person { get; set; }
        public DateTime date { get; set; }
        public int app_type_id { get; set; }
        public DTOApplication_types app_type { get; set; }
        public int app_status { get; set; }
        public DateTime last_status_date { get; set; }
        public decimal fees { get; set; }
        public int user_id { get; set; }
        public DTOUser userinfo { get; set; }

        public DTOApplication(int app_id, int personid, DateTime date, DateTime last_date, int apptypeid, int appstatus, decimal fees
            , int userid)
        {
            this.app_id = app_id;
            this.person_id = personid;
            this.date = date;
            this.app_type_id = apptypeid;
            this.app_status = appstatus;
            this.last_status_date = last_date;
            this.fees = fees;
            this.user_id = userid;

        }

        public DTOApplication()
        {
            this.app_id = -1;
            this.person_id = -1;
            this.date = DateTime.Now;
            this.app_type_id = -1;
            this.app_status = 1;
            this.last_status_date = DateTime.Now;
            this.fees = 0;
            this.user_id = -1;

        }

    }
}
