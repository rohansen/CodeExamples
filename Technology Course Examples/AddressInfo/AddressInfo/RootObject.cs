using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressInfo
{
    public class RootObject
    {
        public string id { get; set; }
        public string kvhx { get; set; }
        public int status { get; set; }
        public string href { get; set; }
        public string etage { get; set; }
        public string adressebetegnelse { get; set; }
        public Adgangsadresse adgangsadresse { get; set; }
    }
    public class Postnummer
    {
        public string href { get; set; }
        public string nr { get; set; }
        public string navn { get; set; }
    }
    public class Adgangsadresse
    {
        public string href { get; set; }

        public string husnr { get; set; }
        public object supplerendebynavn { get; set; }
        public Postnummer postnummer { get; set; }
        public object stormodtagerpostnummer { get; set; }
        public Kommune kommune { get; set; }
        public Ejerlav ejerlav { get; set; }
     
    }
    public class Kommune
    {
        public string href { get; set; }
        public string kode { get; set; }
        public string navn { get; set; }
    }

    public class Ejerlav
    {
        public int kode { get; set; }
        public string navn { get; set; }
    }

}
