using DTOLocalLicense_view_namespace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataManageLocalLicenses
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static List<DTOLicense_view> list_all_licenses()
        {
            List<DTOLicense_view> list = new List<DTOLicense_view>();
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_list_local_driving_licence_app_view", cnct))
                {
                    cnct.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DTOLicense_view(
                                reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                                reader.GetString(reader.GetOrdinal("ClassName")),
                                reader.GetString(reader.GetOrdinal("FullName")),
                                reader.GetString(reader.GetOrdinal("NationalNo")),
                                reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                                reader.GetInt32(reader.GetOrdinal("PassedTestCount")),
                                reader.GetString(reader.GetOrdinal("Status"))
                            ));
                        }
                    }
                }
            }
            return list;
        }

        public static DTOLicense_view get_license_view_by_nationalnum(string num)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_getlocaldriving_view_by_nationalnum", cnct))
                {
                    cmd.Parameters.AddWithValue("@nationalnum", num);
                    cnct.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (new DTOLicense_view(
                                reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                                reader.GetString(reader.GetOrdinal("ClassName")),
                                reader.GetString(reader.GetOrdinal("FullName")),
                                reader.GetString(reader.GetOrdinal("NationalNo")),
                                reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                                reader.GetInt32(reader.GetOrdinal("PassedTestCount")),
                                reader.GetString(reader.GetOrdinal("Status"))
                            ));
                        }
                        else return null;
                    }
                }
            }
        }

        public static List<string> list_names_of_classes()
        {
            List<string> list = new List<string>();
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("select ClassName from LicenseClasses", cnct))
                {
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add((
                                reader.GetString(reader.GetOrdinal("ClassName"))
                            ));
                        }
                    }
                }
            }
            return list;
        }

        public static decimal get_license_fees_by_id(int id)
        {
            decimal res = 0;
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_fees_by_license_id", cnct))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cnct.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    object output = cmd.ExecuteScalar();
                    if (output != null)
                        res = Convert.ToDecimal(output);
                }
            }
            return res;
        }
    }
}
