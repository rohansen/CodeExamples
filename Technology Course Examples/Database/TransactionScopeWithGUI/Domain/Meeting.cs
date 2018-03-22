using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Meeting
    {
        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return $"{BeginTime} -> {EndTime}";
        }
    }
}
