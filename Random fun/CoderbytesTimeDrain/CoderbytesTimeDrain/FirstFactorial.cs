using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    public class FirstFactorialChallenge
    {
        public static int FirstFactorial(int num)
        {
            if (num == 0)
                return 1;
            return num * FirstFactorial(num - 1);

        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(FirstFactorial(int.Parse(Console.ReadLine())));
        }

    }
}
