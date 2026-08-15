using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOUsers
{
    public class ClsUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public int personid { get; set; }

        public ClsUser()
        {
            id = -1;
            name = "";
            password = "";
            active = false;
            personid = -1;
        }
        public ClsUser (int id, int personid, string name, string pass, bool active)
        {
            this.id = id;
            this.name = name;
            this.password = pass;
            this.active = active;
            this.personid = personid;
        }
    }
}
