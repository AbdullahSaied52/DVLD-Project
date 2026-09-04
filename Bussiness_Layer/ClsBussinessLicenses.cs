using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessLicenses
    {
        public int license_id { get; set; }
        public int app_id { get; set; }

        public int driver_id { get; set; }

        public int license_class_id { get; set; }

        public DateTime issue_date { get; set; }
        public DateTime expired_date { get; set; }
        public string notes { get; set; }
        public float fees { get; set; }
        public short active { get; set; }
        public int issue_reason { get; set; }
        public int user_id { get; set; }

        public ClsBussinessLicenses()
        {
            this.license_id = -1;
            this.app_id = -1;
            this.driver_id = -1;
            this.license_class_id = -1;
            this.issue_date = DateTime.MinValue;
            this.expired_date = DateTime.MinValue;
            this.notes = string.Empty;
            this.fees = 0.0f;
            this.active = 0;
            this.issue_reason = -1;
            this.user_id = -1;
        }

        // 2. Parameterized Constructor
        public ClsBussinessLicenses(int license_id, int app_id, int driver_id,
            int license_class_id, DateTime issue_date, DateTime expired_date,
            string notes, float fees, short active, int issue_reason, int user_id)
        {
            this.license_id = license_id;
            this.app_id = app_id;
            this.driver_id = driver_id;
            this.license_class_id = license_class_id;
            this.issue_date = issue_date;
            this.expired_date = expired_date;
            this.notes = notes;
            this.fees = fees;
            this.active = active;
            this.issue_reason = issue_reason;
            this.user_id = user_id;
        }

        public bool is_exist()
        {
            return ClsDataLicenses.is_license_exist(this.app_id, this.license_class_id) > 0 ? true : false;
        }

        public void add_new_license()
        {
            this.license_id = ClsDataLicenses.add_new_license(this.app_id,
        this.driver_id,
        this.license_class_id,
        this.issue_date,
        this.expired_date,
        this.notes,
        this.fees,
        this.active,
        this.issue_reason,
        this.user_id);
        }

        //public ClsBussinessLicenses find_license_by_app_id()
        //{
        //    int license_id = -1;
        //    int app_id = -1;
        //    int driver_id = -1;
        //    int license_class_id = -1;
        //    DateTime issue_date = DateTime.MinValue;
        //    DateTime expired_date = DateTime.MinValue;
        //    string notes = string.Empty;
        //    float fees = 0;
        //    short active = 0;
        //    int issue_reason = -1;
        //    int user_id = -1;

        //    if (ClsDataLicenses.find_license_by_app_id())
        //}
    }
}
