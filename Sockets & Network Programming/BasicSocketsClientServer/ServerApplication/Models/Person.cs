using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Models
{
    public class Person
    {
        public Person()
        {
            FavouriteAnimals = new List<string>();
            FavouriteAnimals.Add("Lions");
            FavouriteAnimals.Add("Dinosaurs");
        }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> FavouriteAnimals { get; set; }
    }
}
