using Data_Layer;
using DTOPerson_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    internal class ClsBUssinessDriver
    {
        public int driver_id { get; set; }

        public int person_id { get; set; }

        public int created_by_user_id { get; set; }
        public DateTime date { get; set; }

        ClsBUssinessDriver()
        {
            this.person_id = -1;
            this.date = DateTime.Now;
            this.created_by_user_id = -1;
            this.driver_id = -1;
        }

        ClsBUssinessDriver(int driverID,int personID,int UserID,DateTime date)
        {
            this.person_id = personID;
            this.date = date;
            this.created_by_user_id = UserID;
            this.driver_id = driverID;
        }

        public void add_new_driver()
        {
            this.driver_id=ClsDataDriver.add_new_driver(this.person_id, this.created_by_user_id, this.date);
        }

    }

    
}
