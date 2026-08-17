using Data_Layer;
using DTO_Test_types_namespace;
using DTOApplication_types_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessApplication_test_types
    {

        public static List<DTOApplication_types> list_all()
        {
            return ClsDataApplication_Test_types.list_all_applications();
        }

        public static void update_app(DTOApplication_types app)
        {
            ClsDataApplication_Test_types.edit_application_type(app);
        }
        public static DTOApplication_types get_by_id(int id)
        {
            return ClsDataApplication_Test_types.get_app_by_id(id);
        }
        public static DTOTest_types get_test_by_id(int id)
        {
            return ClsDataApplication_Test_types.get_test_by_id(id);
        }

        public static List<DTOTest_types> list_all_tests()
        {
            return ClsDataApplication_Test_types.list_all_TestTypes();
        }

        public static void update_test(DTOTest_types app)
        {
            ClsDataApplication_Test_types.edit_test_type(app);
        }



    }

}
