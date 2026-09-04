using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataLicenses
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static int add_new_license( int app_id,int driver_id,
            int license_class_id,DateTime issue_date,DateTime expired_date,string notes
            ,float fees,short is_active,int issue_reaseon,int user_id)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"insert into Licenses(ApplicationID,DriverID,LicenseClass,IssueDate,
                                ExpirationDate,Notes,PaidFees,IsActive,IssueReason,
                            CreatedByUserID)
                            values (
                            @app_id,@driver_id,@license_class,@issuedate,@expired_date,@notes,@fees,@active,@reason,@userid)
                            select SCOPE_IDENTITY()";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@app_id", app_id);
                    cmd.Parameters.AddWithValue("@driver_id", driver_id);
                    cmd.Parameters.AddWithValue("@license_class", license_class_id);
                    cmd.Parameters.AddWithValue("@issuedate", issue_date);
                    cmd.Parameters.AddWithValue("@expired_date", expired_date);

                    if (string.IsNullOrEmpty(notes))
                        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@notes", notes);

                    cmd.Parameters.AddWithValue("@fees", fees);
                    cmd.Parameters.AddWithValue("@active", is_active);
                    cmd.Parameters.AddWithValue("@reason", issue_reaseon);
                    cmd.Parameters.AddWithValue("@userid", user_id);
                    cnct.Open();

                    return Convert.ToInt32( cmd.ExecuteScalar());


                }
            }
        }

        public static int is_license_exist(int app_id,int license_class_id)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"select result=1 from Licenses
                            where ApplicationID=@app_id and
                            LicenseClass=@licnese_id
                            and IsActive=1";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@app_id", app_id);
                    cmd.Parameters.AddWithValue("@license_id", license_class_id);
                    cnct.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static bool find_license_by_app_id(ref int license_id, int app_id, ref int driver_id,
           ref int license_class_id, ref DateTime issue_date, ref DateTime expired_date, ref string notes
            , ref float fees, ref short is_active, ref int issue_reaseon, ref int user_id)
        {
            bool found = false;
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"select * from Licenses where ApplicationID=@app_id";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@pp_id", app_id);
                    cnct.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            found = true;
                            //license_id = reader.GetInt32(reader.GetOrdinal("LicenseID"));
                            license_id = (int)reader["LicenseID"];
                            driver_id = (int)reader["DriverID"];
                            license_class_id = (int)reader["LicenseClass"];
                            issue_date = (DateTime)reader["IssueDate"];
                            expired_date = (DateTime)reader["ExpirationDate"];

                            // Handling NULL values for Notes safely
                            if (reader["Notes"] != DBNull.Value)
                            {
                                notes = (string)reader["Notes"];
                            }
                            else
                            {
                                notes = string.Empty;
                            }

                            fees = Convert.ToSingle(reader["PaidFees"]);
                            is_active = Convert.ToInt16(reader["IsActive"]);
                            issue_reaseon = (int)reader["IssueReason"];
                            user_id = (int)reader["CreatedByUserID"];
                        }
                    }
                }
            }

            return found;
        }
    }
}
