using DTO_Test_types_namespace;
using DTOApplication_types_namespace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataApplication_Test_types
    {
        
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";
        public static List<DTOApplication_types> list_all_applications()
        {
            List<DTOApplication_types> list = new List<DTOApplication_types>();
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_list_app_types", cnct))
                {
                    cnct.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DTOApplication_types(
                                reader.GetInt32(reader.GetOrdinal("ApplicationTypeID")),
                                reader.GetString(reader.GetOrdinal("ApplicationTypeTitle")),
                                reader.GetDecimal(reader.GetOrdinal("ApplicationFees"))
                                ));
                        }
                    }
                }
            }
            return list;
        }

        public static void edit_application_type(DTOApplication_types app)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_edit_app_types", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", app.id);
                    cmd.Parameters.AddWithValue("@title", app.title);
                    cmd.Parameters.AddWithValue("@fees", app.fees);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static DTOApplication_types get_app_by_id(int id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_app_type", cnct))
                {
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTOApplication_types(
                                reader.GetInt32(reader.GetOrdinal("ApplicationTypeID")),
                                reader.GetString(reader.GetOrdinal("ApplicationTypeTitle")),
                                reader.GetDecimal(reader.GetOrdinal("ApplicationFees"))
                                );
                        }
                        else
                            return null;
                    }
                }
            }
        }
      
            
        // Test types functions

        public static List<DTOTest_types> list_all_TestTypes()
        {
            List<DTOTest_types> list = new List<DTOTest_types>();
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_list_test_types", cnct))
                {
                    cnct.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DTOTest_types(
                                reader.GetInt32(reader.GetOrdinal("TestTypeID")),
                                reader.GetString(reader.GetOrdinal("TestTypeTitle")),
                                reader.GetString(reader.GetOrdinal("TestTypeDescription")),
                                reader.GetDecimal(reader.GetOrdinal("TestTypeFees"))
                                ));
                        }
                    }
                }
            }
            return list;
        }

        public static void edit_test_type(DTOTest_types app)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_edit_test_types", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", app.id);
                    cmd.Parameters.AddWithValue("@title", app.title);
                    cmd.Parameters.AddWithValue("@description", app.description);
                    cmd.Parameters.AddWithValue("@fees", app.fees);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static DTOTest_types get_test_by_id(int id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_test_type_by_id", cnct))
                {
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTOTest_types(
                                reader.GetInt32(reader.GetOrdinal("TestTypeID")),
                                reader.GetString(reader.GetOrdinal("TestTypeTitle")),
                                reader.GetString(reader.GetOrdinal("TestTypeDescription")),
                                reader.GetDecimal(reader.GetOrdinal("TestTypeFees"))
                                );
                        }
                        else
                            return null;
                    }
                }
            }
        }
    }
}
