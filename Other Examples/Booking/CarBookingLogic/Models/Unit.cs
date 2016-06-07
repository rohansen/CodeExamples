using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingLogic.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
