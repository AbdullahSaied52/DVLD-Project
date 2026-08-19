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
        public static bool if_app_exist(DTOApplication app)
        {
            return ClsDataApplications.if_application_exist(app) > 0 ? true : false;
        }

        public static void add_new_local_license(int app_id,int license_id)
        {
             ClsDataApplications.add_new_localdrivinglicense(app_id, license_id);
        }

        public static void cancel_application_by_app_id(int app_id)
        {
            ClsDataApplications.cancel_application_by_app_id(app_id);
        }
    }
}
