using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataLocalLicenses
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static void add_new_local_license(int app_id,int license_class_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"insert into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                            values (@app_id,@license_id) ";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@app_id", app_id);
                    cmd.Parameters.AddWithValue("@license_id", license_class_id);
                    cnct.Open();
                    cmd.ExecuteScalar();
                }
            }

        }

        public static void delete_local_license(int local_license_id)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"delete from LocalDrivingLicenseApplications
                                where LocalDrivingLicenseApplicationID=@id";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@id", local_license_id);
                    cnct.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool find_local_license_by_local_id(int local_license_id, ref int app_id,ref int license_class_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"select * from LocalDrivingLicenseApplications
                                where LocalDrivingLicenseApplicationID=@id";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@id", local_license_id);
                    cnct.Open();
                    using(SqlDataReader reader =cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            app_id = reader.GetInt32(reader.GetOrdinal("ApplicationID"));
                            license_class_id = reader.GetInt32(reader.GetOrdinal("LicenseClassID"));
                            return true;
                        }
                        else
                            return false;

                    }
                }
            }
        }

        public static bool find_local_license_by_app_id(int app_id, ref int local_license_id, ref int license_class_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"select * from LocalDrivingLicenseApplications
                                where ApplicationID=@id";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@id", local_license_id);
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            local_license_id = reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID"));
                            license_class_id = reader.GetInt32(reader.GetOrdinal("LicenseClassID"));
                            return true;
                        }
                        else return false;

                    }
                }
            }
        }

        public static void update_local_license(int license_id,int license_class_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"update LocalDrivingLicenseApplications
                            set LicenseClassID=@license_id
                                where LocalDrivingLicenseApplicationID =@app_id";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@app_id", license_id);
                    cmd.Parameters.AddWithValue("@license_id", license_class_id);
                    cnct.Open();
                    cmd.ExecuteScalar();
                }
            }
        }

        public static bool get_passed_test_type(int license_id,int test_type)
        {
            int res = 0;
            using (SqlConnection cnct=new SqlConnection(connection_string))
            {
                
                string query = @"select top 1 TestResult from Tests inner join
                        TestAppointments on TestAppointments.TestAppointmentID=Tests.TestAppointmentID
                        inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=
                        TestAppointments.LocalDrivingLicenseApplicationID
                        where 
                        TestAppointments.TestTypeID=@type_id
                        and LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@local_id
                        order by Tests.TestAppointmentID desc";
                using(SqlCommand cmd=new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@type_id", test_type);
                    cmd.Parameters.AddWithValue("@local_id", license_id);
                    cnct.Open();

                    object result = cmd.ExecuteScalar();
                    res = Convert.ToInt32(result);

                    }
                }
            return res == 1 ? true : false;
        }


            
        }
    }

