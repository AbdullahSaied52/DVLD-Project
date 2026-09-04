using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessLocalDrivingLicense:ClsBussinessApplications
    {
        public int local_license_id { get; set; }
        public int license_class_id { get; set; }
        public ClsBussinessLicenseClass liecense_info { get; set; }


        public ClsBussinessLocalDrivingLicense()
        {
            this.local_license_id = -1;
            this.license_class_id = -1;
        }
        public ClsBussinessLocalDrivingLicense(int local_license_id,int license_class_id, 
            int app_id, int personid, DateTime date, DateTime last_date, int apptypeid, byte appstatus, float fees
            , int userid)
        {
            this.local_license_id = local_license_id;
            this.app_id = app_id;
            this.license_class_id = license_class_id;
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
            this.liecense_info = ClsBussinessLicenseClass.find_license_class_by_id(license_class_id);
        }


        public void add_new_local_license()
        {
            base.add_new_app();
            ClsDataLocalLicenses.add_new_local_license(this.app_id, this.license_class_id);
        }

        public void delete_local_license()
        {
            ClsDataLocalLicenses.delete_local_license(this.local_license_id);
            base.delete_applications();

        }

        public static ClsBussinessLocalDrivingLicense find_local_license_by_id(int id)
        {
            int app_id = -1; int license_class_id = -1;
            if (ClsDataLocalLicenses.find_local_license_by_local_id(id, ref app_id, ref license_class_id))
            {
                ClsBussinessApplications app = ClsBussinessApplications.find_app_by_id(app_id);

                return new ClsBussinessLocalDrivingLicense(id,
    license_class_id,
    app_id,
    app.person_id,
    app.date,
    app.last_status_date, 
    app.app_type_id,      
    app.app_status,
    app.fees_for_app,
    app.user_id);
            }
            else return null;
        }

        public static ClsBussinessLocalDrivingLicense find_local_license_by_app_id(int app_id)
        {
            int local_license_id = -1; int license_class_id = -1;
            if (ClsDataLocalLicenses.find_local_license_by_app_id(app_id, ref local_license_id, ref license_class_id))
            {
                ClsBussinessApplications app = ClsBussinessApplications.find_app_by_id(app_id);

                return new ClsBussinessLocalDrivingLicense(local_license_id, license_class_id, app_id, app.person_id, app.date, app.last_status_date, app.app_type_id,
                    app.app_status, app.fees_for_app, app.user_id);
            }
            else return null;
        }

        public void update_local_license()
        {
            base.update_application();
            ClsDataLocalLicenses.update_local_license(this.local_license_id, this.license_class_id);
        }

        public bool GetPassedTestByLocalLicense(int test_type)
        {
            return ClsDataLocalLicenses.get_passed_test_type(this.local_license_id, test_type);
        }

        public bool get_active_license(int person_id,int license_class)
        {
            return ClsDataLocalLicenses.get_active_license(person_id, license_class) > 0 ? true : false;
        }

    }
}
