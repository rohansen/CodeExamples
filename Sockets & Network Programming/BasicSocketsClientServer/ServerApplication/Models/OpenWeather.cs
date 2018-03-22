using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Models
{
    public class OpenWeather
    {
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Sys Sys { get; set; }
    }
}
