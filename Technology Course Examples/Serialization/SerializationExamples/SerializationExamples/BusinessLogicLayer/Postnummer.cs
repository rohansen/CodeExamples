using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Postnummer
    {
        public string Href { get; set; }
        public string Nr { get; set; }
        public string Navn { get; set; }
        //public string Stormodtageraddresser { get; set; } //I dont need this, so i ommit it.
        public List<Kommune> Kommuner { get; set; }

    }
}
