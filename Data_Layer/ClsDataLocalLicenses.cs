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


    }
}
