using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1Exercises
{
  
    abstract sealed class Program
    {
        


        static int Main(string[] args)
        {
            Console.WriteLine("asd");
            return 1;
        }

        static class Tasker
        {
            public async static void Start()
            {
                int x = 1;
                int y = 2;
                int z = x + y; 
                Console.WriteLine(z);
                Console.WriteLine("asd");
                Task<int> xx = Tasker.MakeTask();
                var taskResult = await xx;
            }
            public static Task<int> MakeTask()
            {
                return Task.Run(() => 1);
            }
        }
       
    }
}
