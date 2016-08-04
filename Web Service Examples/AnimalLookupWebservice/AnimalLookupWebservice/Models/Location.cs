using System.Collections.Generic;

namespace AnimalLookupWebservice.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}