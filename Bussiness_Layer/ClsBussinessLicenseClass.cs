using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class ClsBussinessLicenseClass
    {
        public int license_class_id { get; set; }
        public string license_name { get; set; }
        public string description { get; set; }
        public int minimum_adge { get; set; }
        public int validate_length { get; set; }
        public float license_fees { get; set; }

        public ClsBussinessLicenseClass()
        {
            this.license_fees = 0;
            this.license_name = "";
            this.minimum_adge = 0;
            this.validate_length = 0;
            this.description = "";
            this.license_class_id = -1;
        }

        public ClsBussinessLicenseClass(int id, string name,string desc,int adge,int length,float fees)
        {
            this.license_fees = fees;
            this.license_name =name;
            this.minimum_adge = adge;
            this.validate_length = length;
            this.description = desc;
            this.license_class_id = id;
        }

        public static ClsBussinessLicenseClass find_license_class_by_id(int id)
        {
            float license_fees = 0;
            string license_name = "";
            int minimum_adge = 0;
            int validate_length = 0;
            string description = "";
            if (ClsDataLicenseClass.find_license_class_by_id(id, ref license_name, ref description, ref minimum_adge, ref validate_length, ref license_fees))
                return new ClsBussinessLicenseClass(id, license_name, description, minimum_adge, validate_length, license_fees);
            else
                return null;

        }

    }
}
