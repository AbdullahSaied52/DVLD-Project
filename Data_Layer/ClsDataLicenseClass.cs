using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataLicenseClass
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static bool find_license_class_by_id(int id,ref string classname,ref string description
            ,ref int minimumadge,ref int validatelenght,ref float classfees)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"select * from LicenseClasses
                                    where LicenseClassID=@id";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            classname = (string)reader["ClassName"];
                            description = (string)reader["ClassDescription"];
                            minimumadge = Convert.ToByte(reader["MinimumAllowedAge"]);
                            validatelenght = Convert.ToByte(reader["DefaultValidityLength"]);
                            classfees = Convert.ToSingle(reader["ClassFees"]);
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
        }


    }
}
