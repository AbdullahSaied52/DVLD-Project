using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ClsDataTestAppointment
    {
        public static string connection_string = "Server=localhost;Database=DVLD;Integrated Security=True;TrustServerCertificate=True";

        public static DataTable get_all_test_appointments_info()
        {
            DataTable dt = new DataTable();
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"select * from TestAppointments_View";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cnct.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public static bool get_test_appointment_by_id(int appointment_id,ref int test_type_id,ref int local_license,
            ref DateTime date,ref float fees, ref int user_id,ref int locked,ref int retake_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"select * from TestAppointments
                                    where TestAppointmentID=@id";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", appointment_id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            test_type_id = (int)reader["TestTypeID"];
                            local_license = (int)reader["LocalDrivingLicenseApplicationID"];
                            date = (DateTime)reader["AppointmentDate"];
                            fees = Convert.ToSingle(reader["PaidFees"]);
                            user_id = (int)reader["CreatedByUserID"];
                            locked = Convert.ToInt32( reader["IsLocked"]);
                            if (reader["RetakeTestApplicationID"] != DBNull.Value)
                            {
                                retake_id = (int)reader["RetakeTestApplicationID"];
                            }
                            else
                            {
                                retake_id = -1;
                            }
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
        }

        public static bool get_last_test_appointment_by_id(int test_type_id , ref int appointment_id, int local_license,
    ref DateTime date, ref float fees, ref int user_id, ref int locked, ref int retake_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"select top 1 * from TestAppointments
                            where TestTypeID= @id
                            AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                            order by TestAppointmentID desc";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cnct.Open();
                    cmd.Parameters.AddWithValue("@id", test_type_id);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", local_license);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            appointment_id = (int)reader["TestAppointmentID"];
                            local_license = (int)reader["LocalDrivingLicenseApplicationID"];
                            date = (DateTime)reader["AppointmentDate"];
                            fees = Convert.ToSingle(reader["PaidFees"]);
                            user_id = (int)reader["CreatedByUserID"];
                            //locked = (int)reader["IsLocked"];
                            if (reader["IsLocked"] != DBNull.Value)
                            {
                                locked = Convert.ToInt32( reader["IsLocked"]);
                            }
                            else
                            {
                                locked = 0;
                            }

                            if (reader["RetakeTestApplicationID"] != DBNull.Value)
                            {
                                retake_id = (int)reader["RetakeTestApplicationID"];
                            }
                            else
                            {
                                retake_id = -1;
                            }
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
        }

        public static int add_test_appointment(int appointment_id, int test_type_id,  int local_license,
             DateTime date,  float fees,  int user_id,  int locked,  int retake_id)
        {
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"INSERT INTO TestAppointments
                                    (
                                        TestTypeID,
                                        LocalDrivingLicenseApplicationID,
                                        AppointmentDate,
                                        PaidFees,
                                        CreatedByUserID,
                                        IsLocked,
                                        RetakeTestApplicationID
                                    )
                                    VALUES
                                    (
                                        @TestTypeID,
                                        @LocalDrivingLicenseApplicationID,
                                        @AppointmentDate,
                                        @PaidFees,
                                        @CreatedByUserID,
                                        @IsLocked,
                                        @RetakeTestApplicationID
                                    );
                                    SELECT SCOPE_IDENTITY() ";
                using(SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", test_type_id);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", local_license);
                    cmd.Parameters.AddWithValue("@AppointmentDate", date);
                    cmd.Parameters.AddWithValue("@PaidFees", fees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", user_id);
                    cmd.Parameters.AddWithValue("@IsLocked", locked);

                    if (retake_id != -1)
                        cmd.Parameters.AddWithValue("@RetakeTestApplicationID", retake_id);
                    else
                        cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

                    cnct.Open();

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32( result);
                }
            }
        }

        public static void update_test_appointment(int appointment_id, int test_type_id, int local_license,
             DateTime date, float fees, int user_id, int locked, int retake_id)
        {
            using (SqlConnection cnct = new SqlConnection(connection_string))
            {
                string query = @"update TestAppointments
                                    set
                                        TestTypeID= @TestTypeID,
                                        LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,
                                        AppointmentDate=@AppointmentDate,
                                        PaidFees=@PaidFees,
                                        CreatedByUserID=@CreatedByUserID,
                                        IsLocked=@IsLocked,
                                        RetakeTestApplicationID=@RetakeTestApplicationID
                                        where TestAppointmentID=@id
                                     ";
                using (SqlCommand cmd = new SqlCommand(query, cnct))
                {
                    cmd.Parameters.AddWithValue("@id", appointment_id);
                    cmd.Parameters.AddWithValue("@TestTypeID", test_type_id);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", local_license);
                    cmd.Parameters.AddWithValue("@AppointmentDate", date);
                    cmd.Parameters.AddWithValue("@PaidFees", fees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", user_id);
                    cmd.Parameters.AddWithValue("@IsLocked", locked);

                    if (retake_id != -1)
                        cmd.Parameters.AddWithValue("@RetakeTestApplicationID", retake_id);
                    else
                        cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

                    cnct.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable get_test_appointment_by_id_per_test_type(int local_license_id,int type)
        {
            DataTable dt = new DataTable();
            using(SqlConnection cnct=new SqlConnection(connection_string))
            {
                string query = @"select TestAppointmentID,AppointmentDate
                                ,PaidFees,IsLocked from TestAppointments
                                where LocalDrivingLicenseApplicationID=@id
                                and TestTypeID=@type
";
                using (SqlCommand cmd=new SqlCommand(query,cnct))
                {
                    cmd.Parameters.AddWithValue("@id", local_license_id);
                    cmd.Parameters.AddWithValue("@type", type);
                    cnct.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }
            return dt;
        }
    }
}
