using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    class Program
    {
         

        static void Main(string[] args)
        {
            TheHardWorker<IUser> worker = new TheHardWorker<IUser>();
            worker.Create(new User { Name = "Ronni" }, MyCallback);
        }

        private static void MyCallback(IUser entity)
        {
            Console.WriteLine(entity.Name);
        }
    }
}
