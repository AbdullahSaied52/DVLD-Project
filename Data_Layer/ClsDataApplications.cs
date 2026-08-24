using DTOApplication_namespace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataApplications
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static int add_new_application(int person_id,DateTime date, int app_type_id,int app_status,float fees,int user_id)
        {
            int app_id = -1;
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_add_new_application", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@person_id", person_id);
                    cmd.Parameters.AddWithValue("@first_date", date);
                    cmd.Parameters.AddWithValue("@last_date", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@app_type_id", app_type_id);
                    cmd.Parameters.AddWithValue("@app_status", app_status);
                    cmd.Parameters.AddWithValue("@fees", fees);
                    cmd.Parameters.AddWithValue("@userid",user_id);
                    SqlParameter outputID = new SqlParameter("@app_id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputID);
                    cnct.Open();
                    object result = cmd.ExecuteNonQuery();
                    app_id = (int)outputID.Value;  
                    return app_id;
                }
            }


        }

        public static int if_application_exist(int app_person_id, int app_type_id,int license_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"select Applications.ApplicationID from Applications 
                            inner join LocalDrivingLicenseApplications on
                            Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
                            where Applications.ApplicationStatus=1
                            and LocalDrivingLicenseApplications.LicenseClassID=@license_id
                            and Applications.ApplicantPersonID=@person_id
                            and Applications.ApplicationTypeID=@app_type_id ";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@app_type_id", app_type_id);
                    cmd.Parameters.AddWithValue("@person_id", app_person_id);
                    cmd.Parameters.AddWithValue("@license_id", license_id);
                    cnct.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return reader.GetInt32(reader.GetOrdinal("ApplicationID"));
                        else
                            return 0;
                    }
                    
                }

            }
        }


        ////cancel app

        public static void cancel_application_by_app_id(int app_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_cancel_locallicense_application", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@local_app_id", app_id);
                    cnct.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void delete_application_by_id(int app_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"delete from Applications
                                where ApplicationID=@id";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@id", app_id);
                    cnct.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool find_app_by_id(int app_id,ref int person_id,ref DateTime app_date,
            ref int app_type_id, ref byte app_status,ref DateTime last_date,ref float fees,ref int user_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"select * from Applications
                                where ApplicationID=@id";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@id", app_id);
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            person_id = (int)reader["ApplicantPersonID"];
                            app_date = (DateTime)reader["ApplicationDate"];
                            app_type_id = (int)reader["ApplicationTypeID"];
                            app_status = Convert.ToByte(reader["ApplicationStatus"]);
                            last_date = (DateTime)reader["LastStatusDate"];
                            fees = Convert.ToSingle(reader["PaidFees"]);
                            user_id = (int)reader["CreatedByUserID"];
                            return true;
                        }
                        else return false;

                    }
                }
            }

        }

        public static void Update_application(int app_id, int person_id, DateTime app_date,
    int app_type_id, byte app_status, DateTime last_date, float fees, int user_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"UPDATE Applications
                        SET ApplicantPersonID = @person_id,
                            ApplicationDate = @app_date,
                            ApplicationTypeID = @app_type_id,
                            ApplicationStatus = @app_status,
                            LastStatusDate = @last_date,
                            PaidFees = @fees,
                            CreatedByUserID = @user_id
                        WHERE ApplicationID = @app_id";

                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@app_id", app_id);
                    cmd.Parameters.AddWithValue("@person_id", person_id);
                    cmd.Parameters.AddWithValue("@app_date", app_date);
                    cmd.Parameters.AddWithValue("@app_type_id", app_type_id);
                    cmd.Parameters.AddWithValue("@app_status", app_status);
                    cmd.Parameters.AddWithValue("@last_date", last_date);
                    cmd.Parameters.AddWithValue("@fees", fees);
                    cmd.Parameters.AddWithValue("@user_id", user_id);

                    cnct.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }


    }
}
