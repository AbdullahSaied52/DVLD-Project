using Data_Layer;
using DTOPerson_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessperson
    {
        public static List<DTOPerson> list_all()
        {

            return ClsDataPerson.list_all();
        }
        public static bool if_id_exist(int id)
        {
            return ClsDataPerson.is_exist(id) == 1 ? true : false;
        }

        public static bool if_nationalNO_exist(string NO)
        {
            return ClsDataPerson.is_nationalNo_exist(NO);
        }


        public static void add_new_person(DTOPerson p)
        {
            ClsDataPerson.add_new_person(p);
        }

        public static DTOPerson get_person_by_id(int id)
        {
            return ClsDataPerson.get_person_by_id(id);
        }

        public static DTOPerson get_person_by_national_num(string No)
        {
            return ClsDataPerson.get_person_by_No(No);
        }

        public static bool delete_person(int id)
        {
            return ClsDataPerson.delete_person(id);
        }

        public static void update_person(DTOPerson p)
        {
            ClsDataPerson.update_person(p);
        }

        public static List<DTOCountry> list_countries()
        {
            return ClsDataPerson.list_countries();
        }
    }
}
