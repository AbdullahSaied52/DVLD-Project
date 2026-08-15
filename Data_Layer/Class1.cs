using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOPerson_namespace;

namespace Data_Layer
{
    public class ClsDataPerson
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static List<DTOPerson> list_all()
        {
            List<DTOPerson> list = new List<DTOPerson>();
            //DataTable dt = new DataTable();
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_list_people", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //if (reader.HasRows)
                        //    dt.Load(reader);
                        while (reader.Read())
                        {
                            list.Add(new DTOPerson(
                                        reader.GetInt32(reader.GetOrdinal("PersonID")),
                                        reader.GetString(reader.GetOrdinal("NationalNo")),
                                        reader.GetString(reader.GetOrdinal("FirstName")),
                                        reader.GetString(reader.GetOrdinal("SecondName")),
                                        reader.GetString(reader.GetOrdinal("ThirdName")),
                                        reader.GetString(reader.GetOrdinal("LastName")),
                                        reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                        reader.GetByte(reader.GetOrdinal("Gendor")), // تأكد من الاسم في الداتابيز Gendor أو Gender
                                        reader.GetString(reader.GetOrdinal("Address")),
                                        reader.GetString(reader.GetOrdinal("Phone")),
                                        reader.GetString(reader.GetOrdinal("Email")),
                                        reader.GetString(reader.GetOrdinal("CountryName"))
                                    ));
                        }
                    }
                }
            }
            return list;
        }

        public static int is_exist(int id)
        {
            int result = 0;
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("select dbo.IfExist(@id)", cnct))
                {
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    result = (int)cmd.ExecuteScalar();
                }
            }
            return result;
        }

        public static bool is_nationalNo_exist(string nationalNO)
        {
            int result = 0;
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("select dbo.if_nationalNO_exist(@nationalNO)", cnct))
                {
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@nationalNO", nationalNO);
                    result = (int)cmd.ExecuteScalar();
                }
            }
            return result == 1 ? true : false;
        }

        public static int add_new_person(DTOPerson person)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddNewPerson", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NationalNo", person.NationalNo);
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", person.SecondName);
                    cmd.Parameters.AddWithValue("@ThirdName", person.ThirdName);
                    cmd.Parameters.AddWithValue("@LastName", person.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gendor", person.Gendor_bit);
                    cmd.Parameters.AddWithValue("@Address", person.Address);
                    cmd.Parameters.AddWithValue("@Phone", person.Phone);
                    cmd.Parameters.AddWithValue("@Email", person.Email);
                    cmd.Parameters.AddWithValue("@CountryName", person.Country);
                    SqlParameter outputID = new SqlParameter("@NewPersonID", SqlDbType.Int)
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

        public static DTOPerson get_person_by_id(int id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPersonByID", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cnct.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTOPerson(
                                        reader.GetInt32(reader.GetOrdinal("PersonID")),
                                        reader.GetString(reader.GetOrdinal("NationalNo")),
                                        reader.GetString(reader.GetOrdinal("FirstName")),
                                        reader.GetString(reader.GetOrdinal("SecondName")),
                                        reader.GetString(reader.GetOrdinal("ThirdName")),
                                        reader.GetString(reader.GetOrdinal("LastName")),
                                        reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                        reader.GetByte(reader.GetOrdinal("Gendor")), // تأكد من الاسم في الداتابيز Gendor أو Gender
                                        reader.GetString(reader.GetOrdinal("Address")),
                                        reader.GetString(reader.GetOrdinal("Phone")),
                                        reader.GetString(reader.GetOrdinal("Email")),
                                        reader.GetString(reader.GetOrdinal("CountryName")));
                        }
                        else return null;
                    }
                }
            }
        }

        public static DTOPerson get_person_by_No(string No)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPersonByNationalNumber", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@national", No);
                    cnct.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTOPerson(
                                        reader.GetInt32(reader.GetOrdinal("PersonID")),
                                        reader.GetString(reader.GetOrdinal("NationalNo")),
                                        reader.GetString(reader.GetOrdinal("FirstName")),
                                        reader.GetString(reader.GetOrdinal("SecondName")),
                                        reader.GetString(reader.GetOrdinal("ThirdName")),
                                        reader.GetString(reader.GetOrdinal("LastName")),
                                        reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                        reader.GetByte(reader.GetOrdinal("Gendor")), // تأكد من الاسم في الداتابيز Gendor أو Gender
                                        reader.GetString(reader.GetOrdinal("Address")),
                                        reader.GetString(reader.GetOrdinal("Phone")),
                                        reader.GetString(reader.GetOrdinal("Email")),
                                        reader.GetString(reader.GetOrdinal("CountryName")));
                        }
                        else return null;
                    }
                }
            }
        }

        public static bool delete_person(int id)
        {
            int result = 0;
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeletePerson", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cnct.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result == 1 ? true : false; // deleted or not found
        }

        public static bool update_person(DTOPerson p)
        {
            int result = 0;
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePerson", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", p.PersonID);
                    cmd.Parameters.AddWithValue("@NationalNo", p.NationalNo);
                    cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", p.SecondName);
                    cmd.Parameters.AddWithValue("@ThirdName", p.ThirdName);
                    cmd.Parameters.AddWithValue("@LastName", p.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", p.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gendor", p.Gendor_bit);
                    cmd.Parameters.AddWithValue("@Address", p.Address);
                    cmd.Parameters.AddWithValue("@Phone", p.Phone);
                    cmd.Parameters.AddWithValue("@Email", p.Email);
                    cmd.Parameters.AddWithValue("@CountryName", p.Country);
                    cnct.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result == 1 ? true : false;
        }

        public static List<DTOCountry> list_countries()
        {
            List<DTOCountry> list = new List<DTOCountry>();

            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListCountries", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DTOCountry(
                                        reader.GetInt32(reader.GetOrdinal("CountryID")),
                                        reader.GetString(reader.GetOrdinal("CountryName"))
                                    ));
                        }
                    }
                }
            }
            return list;
        }
    }
}
