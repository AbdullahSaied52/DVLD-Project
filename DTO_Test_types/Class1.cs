using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Test_types_namespace
{
    public class DTOTest_types
    {
        public int id { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public decimal fees { get; set; }

        public DTOTest_types(int id, string title, string description, decimal fees)
        {
            this.fees = fees;
            this.id = id;
            this.title = title;
            this.description = description;
        }
    }
}
