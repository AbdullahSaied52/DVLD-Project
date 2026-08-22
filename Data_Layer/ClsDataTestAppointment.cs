using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataTestAppointment
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static void get_test_info(int local_license_id)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {

            }
        }
    }
}
