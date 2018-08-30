using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavisionCore.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string SystemVersion { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string BusinessProfileId { get; set; }
        public CompanyInformation CompanyInformation { get; set; }
    }
}
