using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using BusinessLogicLayer;
using Newtonsoft.Json;

/// <summary>
/// Deserializing data from a restful web service that uses JSON
/// </summary>
namespace BasicExample
{
    /// <summary>
    /// This program uses Newtonsoft.Json to deserialize the json from the webservice, to an object
    /// Furthermore this example uses WebRequest to call the web service, this is a less flexible way of doing a request, than the following example using RestSharp
    /// Flexibility can be hightened if you use the HttpRequest type, i believe this approach is a bit more cumbersome than using RestSharp though
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
                //Accept a user input, and parse it as a integer
                Console.WriteLine("Indtast Postnummer");
                int zipCode = -1;
                int.TryParse(Console.ReadLine(), out zipCode);
                Postnummer zipCodeData = GetZipCodeData(zipCode);
                Console.WriteLine("Fundet '{0}', {1} kommune", zipCodeData.Navn, zipCodeData.Kommuner.FirstOrDefault()?.Navn);
                Console.ReadLine();
            
        }

        public static Postnummer GetZipCodeData(int zipCode)
        {
            if (zipCode < 0)
            {
                throw new Exception("Invalid Zip Code");
            }
            WebRequest wr = WebRequest.Create("http://dawa.aws.dk/postnumre/" + zipCode);
            WebResponse response = wr.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string json = sr.ReadToEnd();
            return JsonConvert.DeserializeObject<Postnummer>(json);
        }

    }
}
