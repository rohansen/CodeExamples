using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiServiceProblem.Models
{
    public class User
    {
        public User()
        {
            Pets = new List<Pet>();
        }
        public List<Pet> Pets { get; set; }
    }
}
