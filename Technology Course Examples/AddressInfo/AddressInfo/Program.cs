using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert address");
            string inputData = Console.ReadLine();
            RestClient client = new RestClient("https://dawa.aws.dk/adresser");
            RestRequest request = new RestRequest(Method.GET);
            request.AddQueryParameter("q", inputData);
            IRestResponse<List<RootObject>> response = client.Execute<List<RootObject>>(request);
            var data = response.Data;
            foreach (var item in response.Data)
            {
                Console.WriteLine(item.adressebetegnelse);
            }


        }
    }
}
