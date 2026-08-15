using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOPeople
{
    public class ClsPeople
    {
         {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor_bit { get; set; }
        public string Gendor_string { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public ClsPeople()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor_bit = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.Country = "";
        }
        public ClsPeople(int personID, string nationalNo, string firstName, string secondName,
                      string thirdName, string lastName, DateTime dateOfBirth, byte gendor,
                      string address, string phone, string email, string nationalityCountryID)
        {
            this.PersonID = personID;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor_bit = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Country = nationalityCountryID;
            this.Gendor_string = Gendor_bit == 0 ? "Male" : "Female";
        }
    }

    public class DTOCountry
    {
        public int id { get; set; }
        public string country_name { get; set; }

        public DTOCountry(int id, string name)
        {
            this.id = id;
            this.country_name = name;
        }
    }
}
}
