using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavisionCore.Models
{


    public class CompanyInformation
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string TaxRegistrationNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrentFiscalYearStartDate { get; set; }
        public string Industry { get; set; }
        public string Picture { get; set; }
        public string BusinessProfileId { get; set; }
        public string LastModifiedDateTime { get; set; }
        public Company Company { get; set; }
        
    }
}
