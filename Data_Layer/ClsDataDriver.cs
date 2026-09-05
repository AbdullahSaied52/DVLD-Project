using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataDriver
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static int add_new_driver(int person_id,int created_user_id,DateTime date)
        {
            int res = 0;
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"insert into Drivers(PersonID,CreatedByUserID,CreatedDate)
                                values(@person_id,@user_id,@date)
                                SELECT SCOPE_IDENTITY();";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@person_id", person_id);
                    cmd.Parameters.AddWithValue("@user_id", created_user_id);
                    cmd.Parameters.AddWithValue("@date", date);
                    cnct.Open();
                    object result= cmd.ExecuteScalar();
                    res = Convert.ToInt32(result);
                }
            }
            return res;
        }

        public static DataTable get_all_drivers()
        {
            DataTable dt = new DataTable();
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"select * from Drivers_View";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cnct.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
    }
}
