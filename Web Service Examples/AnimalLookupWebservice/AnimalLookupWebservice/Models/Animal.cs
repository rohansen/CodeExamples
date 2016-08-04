using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalLookupWebservice.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime? Birthdate { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}