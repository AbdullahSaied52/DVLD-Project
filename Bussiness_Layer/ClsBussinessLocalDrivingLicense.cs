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

        public ClsBussinessLocalDrivingLicense()
        {
            this.local_license_id = -1;
            this.license_class_id = -1;
        }

        public ClsBussinessLocalDrivingLicense(int local_license_id,int license_calss_id, 
            int app_id, int personid, DateTime date, DateTime last_date, int apptypeid, int appstatus, float fees
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
        }

        public void add_new_local_license()
        {
            base.add_new_app();
            ClsDataLocalLicenses.add_new_local_license(this.app_id, this.license_class_id);
        }

    }
}
