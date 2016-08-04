using BusinessLogicLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializingForTransfer
{
    /// <summary>
    /// This example uses NewtonSoft.Json to serialize an object to a JSON string; this will often be done before doing a web request or persisting data to a harddisk(not necessarily using JSON format)
    /// If you use RestSharp, it can do it for you automatically before it sends a request, but in this case, we are not doing a web request.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Postnummer postNr = new Postnummer { Href = "http://blabla.bla.dk", Navn = "Nyt PostNummer", Nr = "666" };
            string json = JsonConvert.SerializeObject(postNr);
            Console.WriteLine(json);
            Console.ReadLine();

        }
    }
}
