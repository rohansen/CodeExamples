using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class SimpleAddingChallenge
    {

        public static int SimpleAdding(int num)
        {
            if (num == 0)
                return num;

            return num + SimpleAdding(num - 1);

        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(SimpleAdding(int.Parse(Console.ReadLine())));


        }
    }
}
