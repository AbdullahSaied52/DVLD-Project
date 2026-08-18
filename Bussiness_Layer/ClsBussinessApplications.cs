using Data_Layer;
using DTOApplication_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessApplications
    {
        public static void add_new_app(DTOApplication app)
        {
            ClsDataApplications.add_new_application(app);

        }
    }
}
