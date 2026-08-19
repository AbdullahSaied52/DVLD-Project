using DTOApplication_namespace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataApplications
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static int add_new_application(DTOApplication app)
        {
            app.userinfo = ClsDataUser.get_user_by_id(app.user_id);
            app.person = ClsDataPerson.get_person_by_id(app.person_id);
            app.app_type = ClsDataApplication_Test_types.get_app_by_id(app.app_type_id);



            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("sp_add_new_application", cnct))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@person_id", app.person_id);
                    cmd.Parameters.AddWithValue("@first_date", app.date);
                    cmd.Parameters.AddWithValue("@last_date", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@app_type_id", app.app_type_id);
                    cmd.Parameters.AddWithValue("@app_status", app.app_status);
                    cmd.Parameters.AddWithValue("@fees", app.fees_for_app);
                    cmd.Parameters.AddWithValue("@userid", app.user_id);
                    SqlParameter outputID = new SqlParameter("@app_id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputID);
                    cnct.Open();
                    object result = cmd.ExecuteNonQuery();
                    app.app_id = (int)outputID.Value;  // to update value of app_id immediatly
                    return app.app_id;
                }
            }


        }

        public static int if_application_exist(DTOApplication app)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"if exists(select 1 as result from Applications 
                                        where ApplicantPersonID=@person_id
                                        and ApplicationTypeID=@app_type_id and ApplicationStatus=1)
                                        begin 
                                        select 1 as found
                                        end
                                        else
                                        begin
                                        select 0 as found
                                        end ";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@app_type_id", app.app_type_id);
                    cmd.Parameters.AddWithValue("@person_id", app.person_id);
                    cnct.Open();
                    var output =cmd.ExecuteScalar();
                    return (int) output;
                }

            }
        }
        public static void add_new_localdrivinglicense(int app_id,int license_id)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"insert into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                                values (@app_id,@license_id) ";
                using (SqlCommand cmd = new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@app_id", app_id);
                    cmd.Parameters.AddWithValue("@license_id", license_id);
                    cnct.Open();
                    cmd.ExecuteNonQuery();
                }

            }

        }


        
    }
}
