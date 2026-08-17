using Data_Layer;
using DTOLocalLicense_view_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessManageLocalLicenses
    {
        public static List<DTOLicense_view> list_license_view()
        {
            return ClsDataManageLocalLicenses.list_all_licenses();
        }

        public static DTOLicense_view get_by_nationalnum(string num)
        {
            return ClsDataManageLocalLicenses.get_license_view_by_nationalnum(num);
        }

        public static List<string> list_licesnse_names()
        {
            return ClsDataManageLocalLicenses.list_names_of_classes();
        }

        public static decimal license_fees_by_id(int id)
        {
            return ClsDataManageLocalLicenses.get_license_fees_by_id(id);
        }
    }
}
