using Data_Layer;
using DTOUsers_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessUser
    {
        public static List<DTOUser> list_user()
        {
            return ClsDataUser.list();
        }

        public static void add_user(DTOUser u)
        {
            ClsDataUser.add_user(u);
        }

        public static void update_user(DTOUser u)
        {
            ClsDataUser.update_user(u);
        }

        public static DTOUser get_user_ByID(int id)
        {
            return ClsDataUser.get_user_by_id(id);
        }

        public static bool if_user_exists(int id)
        {
            return ClsDataUser.if_user_exists(id);
        }

        public static void delete_user(int id)
        {
            ClsDataUser.delete_user(id);
        }

        public static DTOUser get_user_by_username(string name)
        {
            return ClsDataUser.get_user_by_username(name);
        }
    }

}
