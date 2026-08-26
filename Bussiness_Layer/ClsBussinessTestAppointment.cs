using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessTestAppointment
    {
        public int test_id { get; set; }
        public int test_type_id { get; set; }
        public int local_license_id { get; set; }
        public DateTime date { get; set; }

        public float fees { get; set; }
        public int createby_user_id { get; set; }
        public int locked { get; set; }
        public int retake_test_id { get; set; }
        public ClsBussinessApplications retake_info { get; set; }

        public ClsBussinessTestAppointment()
        {
            this.test_id = -1;
            this.test_type_id = -1;
            this.date = DateTime.Now;
            this.fees = 0;
            this.createby_user_id = -1;
            this.local_license_id = -1;
            this.locked = 0;
            this.retake_test_id = -1;

        }
        public ClsBussinessTestAppointment(int tesid,int testtypeid,int locallicense_id,DateTime date,
            float fees,int user_id,int locked,int retake_id)
        {
            this.test_id = tesid;
            this.test_type_id = testtypeid;
            this.date = date;
            this.fees = fees;
            this.createby_user_id = user_id;
            this.local_license_id = locallicense_id;
            this.locked = locked;
            this.retake_test_id = retake_id;
            this.retake_info = ClsBussinessApplications.find_app_by_id(retake_test_id);
        }

        public static DataTable list_all_appointment()
        {
            return ClsDataTestAppointment.get_all_test_appointments_info();
        }

        public static ClsBussinessTestAppointment get_appointmnet_by_id(int id)
        {
            int test_id = -1;
            int test_type_id = -1;
            DateTime date = DateTime.Now;
            float fees = 0;
            int createby_user_id = -1;
            int local_license_id = -1;
            int locked = 0;
            int retake_id = -1;
            bool found = ClsDataTestAppointment.get_test_appointment_by_id(id, ref test_type_id, ref local_license_id,
                ref date, ref fees, ref createby_user_id, ref locked, ref retake_id);
            if (found)
            {
                return new ClsBussinessTestAppointment(test_id, test_type_id, local_license_id, date, fees, createby_user_id, locked, retake_id);
            }
            else return null;
            
        }
        
        public static ClsBussinessTestAppointment get_last_appointment(int local_license_id,int test_type_id)
        {
            int test_id = -1;
            DateTime date = DateTime.Now;
            float fees = 0;
            int createby_user_id = -1;
            int locked = 0;
            int retake_id = -1;
            bool found = ClsDataTestAppointment.get_last_test_appointment_by_id(test_type_id, ref test_id, local_license_id,
                ref date, ref fees, ref createby_user_id, ref locked, ref retake_id);

            if (found)
            {
                return new ClsBussinessTestAppointment(test_id, test_type_id, local_license_id, date, fees, createby_user_id, locked, retake_id);
            }
            else return null;
        }

        public static DataTable get_test_by_id_per_type(int local_license_id,int type)
        {
            return ClsDataTestAppointment.get_test_appointment_by_id_per_test_type(local_license_id, type);
        }

        public void add_test_appointment()
        {

            this.test_id= ClsDataTestAppointment.add_test_appointment(this.test_id,
                                            this.test_type_id,
                                            this.local_license_id,
                                            this.date,
                                            this.fees,
                                            this.createby_user_id,
                                            this.locked,
                                            this.retake_test_id);
        }

        public void update_test_appointment()
        {
            ClsDataTestAppointment.update_test_appointment(this.test_id,
        this.test_type_id,
        this.local_license_id,
        this.date,
        this.fees,
        this.createby_user_id,
        this.locked,
        this.retake_test_id);
        }
    }
}
