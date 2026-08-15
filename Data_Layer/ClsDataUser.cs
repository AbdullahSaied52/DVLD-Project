using DTOUsers_namespace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataUser
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static List<DTOUser> list()
        {
            List<DTOUser> list1 = new List<DTOUser>();
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_list_users", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list1.Add(new DTOUser(
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetBoolean(reader.GetOrdinal("IsActive"))
                                     ));
                        }
                    }
                }
            }
            return list1;
        }

        public static int add_user(DTOUser u)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Add_User", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", u.name);
                    cmd.Parameters.AddWithValue("@pass", u.password);
                    cmd.Parameters.AddWithValue("@active", u.active);
                    cmd.Parameters.AddWithValue("@personid", u.personid);
                    SqlParameter outputID = new SqlParameter("@id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputID);
                    cnct.Open();
                    object result = cmd.ExecuteNonQuery();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        return insertedID;
                    }
                    else
                        return -1;
                }
            }
        }

        public static bool update_user(DTOUser u)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_User", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", u.name);
                    cmd.Parameters.AddWithValue("@pass", u.password);
                    cmd.Parameters.AddWithValue("@active", u.active);
                    cmd.Parameters.AddWithValue("@id", u.id);
                    cnct.Open();
                    return cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }

        public static DTOUser get_user_by_id(int id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Get_User_By_ID", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTOUser
                                     (
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetBoolean(reader.GetOrdinal("IsActive"))
                                     );
                        }
                        else
                            return null;
                    }
                }
            }
        }

        public static bool if_user_exists(int id)
        {
            int result;
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("select dbo.if_user_exist(@id)", cnct))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cnct.Open();
                    result = (int)cmd.ExecuteScalar();

                }
            }
            return result == 1;
        }

        public static void delete_user(int id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_User", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DTOUser get_user_by_username(string username)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Get_User_By_userName", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", username);
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTOUser
                                     (
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetBoolean(reader.GetOrdinal("IsActive"))
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
