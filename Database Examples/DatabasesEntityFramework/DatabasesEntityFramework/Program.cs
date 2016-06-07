using DatabasesEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesEntityFramework
{
    class Program
    {
        
        static void Main(string[] args)
        {

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var persons = db.People.Where(x => x.FirstName.Contains("Ron") || x.LastName.Contains("Ron")).ToArray();
                foreach (var p in persons)
                {
                    Console.WriteLine("Found: {0} {1}", p.FirstName, p.LastName);
                }
                Console.ReadLine();
            }
            
        }

        
    }
}
