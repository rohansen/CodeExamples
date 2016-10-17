using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO_Example
{
    public class Student
    {
        public string Activity { get; set; }
        public string ActivityShortDescription { get; set; }
        public string Username { get; set; }
        public string SSN { get; set; }
        public string Fullname { get; set; }
        public string MobilePhone { get; set; }
        public DateTime ActivityStartDate { get; set; }
        public DateTime ActivityEndDate { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string SecondaryAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string IDFromAdministrativeSystem { get; set; }
        public string PrivateMobilePhone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Fullname + "(" + IDFromAdministrativeSystem + ")";
        }

    }
    public sealed class MyClassMap : CsvClassMap<Student>
    {
        public MyClassMap()
        {
            Map(m => m.Activity).Name("Activity");
            Map(m => m.ActivityShortDescription).Name("Activity Short description");
            Map(m => m.Username).Name("Username");
            Map(m => m.SSN).Name("SSN");
            Map(m => m.Fullname).Name("Fullname");
            Map(m => m.MobilePhone).Name("MobilePhone");
            Map(m => m.ActivityStartDate).Name("Activity start Date");
            Map(m => m.ActivityEndDate).Name("Activity End Date");
            Map(m => m.GivenName).Name("Given name");
            Map(m => m.Surname).Name("Surname");
            Map(m => m.Address).Name("Address");
            Map(m => m.SecondaryAddress).Name("Secondary address");
            Map(m => m.PostalCode).Name("Postal code");
            Map(m => m.City).Name("City");
            Map(m => m.IDFromAdministrativeSystem).Name("IDFromAdministrativeSystem");
            Map(m => m.PrivateMobilePhone).Name("PrivateMobilePhone");
            Map(m => m.Email).Name("Email");
        }

    }
    }
