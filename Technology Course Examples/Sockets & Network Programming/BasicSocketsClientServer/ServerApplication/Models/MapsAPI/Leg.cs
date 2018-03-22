using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Models.MapsAPI
{
    public class Leg
    {
        public List<Step> Steps { get; set; }
        public Distance Distance { get; set; }
    }
}
