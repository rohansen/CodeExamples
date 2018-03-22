using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Consultant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName}");
        }
    }
}
