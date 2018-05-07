using System;
using System.Collections.Generic;

namespace Microsoft_Text_Analytics_API
{
    public class Booking
    {
        public Booking()
        {
        }
        public string Agenda { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ConsultantBooking ConsultantBooking { get; set; }
    }
}