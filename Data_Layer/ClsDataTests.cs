using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataTests
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static int add_new_test(int test_appointment_id,int result,string notes,int user_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"INSERT INTO Tests
                                    (
                                        TestAppointmentID,
                                        TestResult,
                                        Notes,
                                        CreatedByUserID
                                    )
                                    VALUES
                                    (
                                        @TestAppointID,
                                        @TestResult,
                                        @notes,
                                        @CreatedByUserID
                                        
                                    ); SELECT SCOPE_IDENTITY();

                                    update TestAppointments
                                    set
                                        IsLocked=1
                                        where TestAppointmentID=@id;";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@TestAppointID", test_appointment_id);
                    cmd.Parameters.AddWithValue("@TestResult", result);
                    cmd.Parameters.AddWithValue("@notes", notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", user_id);
                    cmd.Parameters.AddWithValue("@id", test_appointment_id);
                    cnct.Open();

                    object res= cmd.ExecuteScalar();
                    return Convert.ToInt32(res);
                }
            }

        }

        public static int is_passed(int appointment_id)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"select TestResult from Tests 
                                       where TestAppointmentID=@appointment_id";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@appointment_id", appointment_id);
                    cnct.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return Convert.ToInt32(reader["TestResult"]);
                        else
                            return -1;
                    }
                }
            }
        }
    }
}
