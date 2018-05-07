using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Text_Analytics_API
{
    public class Consultant
    {
        public Consultant()
        {
            ConsultantBookings = new List<ConsultantBooking>();
        }
        public string Name { get; set; }
        public List<ConsultantBooking> ConsultantBookings { get; set; }

    }
}
