using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Drinks = new List<Drink>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
