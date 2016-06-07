using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherServiceConsumption.Models
{
    public class WeatherInfo
    {
        public string Name { get; set; }
        public Coordinate Coord { get; set; }
        public Main Main { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
    }

    public class Coordinate
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}