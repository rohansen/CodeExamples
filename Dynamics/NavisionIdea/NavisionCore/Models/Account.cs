using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavisionCore.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string DisplayName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public bool Blocked { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
