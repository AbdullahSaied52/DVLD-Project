using Data_Layer;
using DTOApplication_namespace;
using DTOApplication_types_namespace;
using DTOPerson_namespace;
using DTOUsers_namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessApplications
    {
        public enum enApplicationType
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6
        }

        public enum enApplicationStatus
        {
            New = 1,
            Cancel = 2,
            Completed = 3
        }
        public int app_id { get; set; }
        public int person_id { get; set; }
        public DTOPerson person { get; set; }
        public DateTime date { get; set; }
        public int app_type_id { get; set; }
        public DTOApplication_types app_type { get; set; }
        public byte app_status { get; set; }
        public DateTime last_status_date { get; set; }
        public float fees_for_app { get; set; }
        public int user_id { get; set; }
        public DTOUser userinfo { get; set; }

        public ClsBussinessApplications(int app_id, int personid, DateTime date, DateTime last_date, int apptypeid, byte appstatus, float fees
            , int userid)
        {
            this.app_id = app_id;
            this.person_id = personid;
            this.date = date;
            this.app_type_id = apptypeid;
            this.app_status = appstatus;
            this.last_status_date = last_date;
            this.fees_for_app = fees;
            this.user_id = userid;
            this.person = ClsBussinessperson.get_person_by_id(personid);
            this.userinfo = ClsBussinessUser.get_user_ByID(userid);
            this.app_type = ClsBussinessApplication_test_types.get_application_by_id(apptypeid);

        }

        public ClsBussinessApplications()
        {
            this.app_id = -1;
            this.person_id = -1;
            this.date = DateTime.Now;
            this.app_type_id = -1;
            this.app_status = 1;
            this.last_status_date = DateTime.Now;
            this.fees_for_app = 0;
            this.user_id = -1;

        }

        public void add_new_app()
        {
            
            this.app_id=ClsDataApplications.add_new_application(this.person_id,this.date,this.app_type_id,
                this.app_status,this.fees_for_app,this.user_id);

        }
        public bool if_app_exist(int person_id,int app_type_id,int license_class_id)
        {
            return ClsDataApplications.if_application_exist(person_id, app_type_id, license_class_id) > 0 ? true : false;
        }

        public static void cancel_application_by_app_id(int app_id)
        {
            ClsDataApplications.cancel_application_by_app_id(app_id);
        }

        public  void delete_applications()
        {
            ClsDataApplications.delete_application_by_id(this.app_id);
        }

        public static ClsBussinessApplications find_app_by_id(int id)
        {
            int person_id = -1;
            DateTime date = DateTime.Now;
            int app_type_id = -1;
            byte app_status = 1;
            DateTime last_status_date = DateTime.Now;
            float fees_for_app = 0;
            int user_id = -1;

            bool found = ClsDataApplications.find_app_by_id(id,ref person_id,ref date,ref app_type_id,ref app_status,
                ref last_status_date,ref fees_for_app,ref user_id);
            if (found)
                return new ClsBussinessApplications(id, person_id, date, last_status_date, app_type_id, app_status, fees_for_app, user_id);
            else
                return null;
        }

        public void update_application()
        {
            ClsDataApplications.Update_application(
        this.app_id,
        this.person_id,
        this.date,
        this.app_type_id,
        this.app_status,
        this.last_status_date,
        this.fees_for_app,
        this.user_id);
        }
    }
}
