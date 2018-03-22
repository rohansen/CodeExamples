using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using BusinessLogicLayer;
/// <summary>
/// Deserializing data from a restful web service that uses JSON
/// </summary>
namespace RestSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Accept a user input, and parse it as a integer
            Console.WriteLine("Indtast Postnummer");
            int zipCode = -1;
            int.TryParse(Console.ReadLine(), out zipCode);


            RestClient client = new RestClient("http://dawa.aws.dk/postnumre/{zipcode}"); //Create a webclient that can do requests; input is the BaseUrl of the resource
            IRestRequest request = new RestRequest(Method.GET); //Prepare a web request, and set HTTP Request type to GET
            request.AddUrlSegment("zipcode", zipCode.ToString()); //Input the zipCode to the BaseUrl {zipcode}
            IRestResponse<Postnummer> response = client.Execute<Postnummer>(request); //Execute the request we have build using strongly typed generics (this will deserialize for us automatically!)
            Postnummer postNr = response.Data;

            Console.WriteLine("Fundet '{0}', {1} kommune", postNr.Navn, postNr.Kommuner.FirstOrDefault()?.Navn);
            Console.ReadLine();
        }
        
    }
}
