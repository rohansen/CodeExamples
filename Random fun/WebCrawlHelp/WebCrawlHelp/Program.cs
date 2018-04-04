using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebCrawlHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            var page = GetPageHTML("http://www.dr.dk/");
            var linksOnPage = GetLinks(page);
            foreach (var newPage in linksOnPage)
            {
                GetPageHTML(newPage);
                //pause 1 second between each request (so we can see whats going on)
                Thread.Sleep(1000);
            }

            //Pause mens resultatet bliver vist
            //Console.WriteLine(page);

            Console.ReadLine();


        }

        private static List<string> GetLinks(string html)
        {
            Regex regex = new Regex("(?:href|src)=[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            List<string> links = new List<string>();
            foreach (Match match in regex.Matches(html))
            {
                var newLink = match.Value.Replace("href=", "").Replace("src=", "").Replace("\"", "").TrimEnd('>');
                //Denne tilgang til links gør, at relative links "/Home/Site" IKKE bliver taget med i  resultatet. Så det er en forsimpling
                if (newLink.StartsWith("http://") || newLink.StartsWith("https://") && newLink!="https://")
                {
                    links.Add(newLink);

                    Console.WriteLine(newLink);
                }
                
            }
            return links;
        }

        private static string GetPageHTML(string url)
        {
            try
            {
            
                //opret et web request med den angivne url... Type Caster til HttpWebRequest
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //Sender vores request afsted med .GetResponse(), og gemmer resultatet i vores "response" variabel, af typen HttpWebResponse. Derfor caster vi også metodekaldet.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Udskriv resultat til konsollen. response.StatusCode viser teksten for respons (f.eks. OK, eller NotFound). Hvis du Caster den til en int (int)response.StatusCode, viser den tallet på fejlen. 200 el. 500
                Console.WriteLine("Response was: " + response.StatusCode + " " + (int)response.StatusCode + " on link " + url);
                
                //Hent data (HTML) fra vores web request, og returner det 
                Stream s = response.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                return sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                //Hvis der opstår en fejl, tjekker vi først om det er fordi URLen ikke findes
                if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    //Domænenavnet eksisterer ikke
                    Console.WriteLine("Domænet eksisterer ikke");
                }
                //Da det er et HTTP request, caster vi vores exception til en "HttpWebResponse"
                //vi bruger "as" keyworded fordi resultatet af vores Cast kan fejle. Hvis vores Type Cast fejler, vil værdien af errorResponse være null.
                HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse != null)
                {
                    //Hvis errorResponse IKKE er null, må der vøre sket en HTTP fejl, vi udskriver fejlen. Dette kan f.eks. være NotFound - 404
                    Console.WriteLine("Error - " + errorResponse.StatusCode + " " + (int)errorResponse.StatusCode);
                }
                return "No data recieved, and we dont want to crawl a 404 page";
            }
         
        }
    }
    
}
