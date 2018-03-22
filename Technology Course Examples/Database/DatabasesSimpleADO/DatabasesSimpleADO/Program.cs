using DatabasesSimpleADO.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSimpleADO
{
    class Program
    {
        static void Main(string[] args)
        {
            DbAccess db = new DbAccess();
            var foundItems = db.FindItem("Rand");
            for (int i = 0; i < foundItems.Count; i++)
            {
                Console.WriteLine("Found: {0} {1}", foundItems[i].FirstName, foundItems[i].LastName);
                Console.ReadLine();
            }
        }
    }
}
