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

        //public static void cancel_application_by_app_id(int app_id)
        //{
        //    using (SqlConnection cnct = new SqlConnection(connection_string))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_cancel_locallicense_application", cnct))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@local_app_id", app_id);
        //            cnct.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

    }
}
