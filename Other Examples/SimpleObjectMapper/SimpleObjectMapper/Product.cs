using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleObjectMapper
{
    public class Product
    {
        public Product()
        {
            KeyWords = new List<string>();
        }
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public string Review { get; set; }
        public List<string> KeyWords { get; set; }
    }
}
