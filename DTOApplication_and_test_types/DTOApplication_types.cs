using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOApplication_types_namespace
{
    public class DTOApplication_types
    {
        public int id { get; set; }

        public string title { get; set; }
        public decimal fees { get; set; }
        public DTOApplication_types(int id, string name, decimal fees)
        {
            this.fees = fees;
            this.id = id;
            this.title = name;
        }
    }
}
