using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlocks
{
    class Program
    {
        static object object1 = new object();
        static object object2 = new object();
        public static void Main(string[] args)
        {
         
            Thread thread1 = new Thread((ThreadStart)ObliviousFunction);
            Thread thread2 = new Thread((ThreadStart)BlindFunction);

            thread1.Start();
            thread2.Start();

            while (true)
            {
                // Stare at the two threads in deadlock.
            }
        }
        public static void ObliviousFunction()
        {
            lock (object1)
            {
                Console.WriteLine("Object 1 Locked");
                Thread.Sleep(1000); // Wait for the blind to lead
                Console.WriteLine("Trying to lock object 2... waiting");
                lock (object2)
                {
                    Console.WriteLine("Object 2 Locked");
                }
            }
        }

        public static void BlindFunction()
        {
            lock (object2)
            {
                Console.WriteLine("Object 2 Locked");
                Thread.Sleep(1000); // Wait for oblivion
                Console.WriteLine("Trying to lock object 1... waiting");
                lock (object1)
                {
                    Console.WriteLine("Object 1 Locked");
                }
            }
        }
        
    }
}
