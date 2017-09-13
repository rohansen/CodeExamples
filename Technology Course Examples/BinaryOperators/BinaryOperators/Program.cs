using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Raid example
            //int a = 65;
            //int b = 66;
            //int ba = b ^ a;
            //Console.WriteLine("Raid parity disk example with XOR operator ^");
            //Console.WriteLine(string.Format("{0}({1}) Saved on HDD1", (char)a, a));
            //Console.WriteLine(string.Format("{0}({1}) Saved on HDD2", (char)b, b));
            //Console.WriteLine(string.Format("Parity data: {0}", ba));
            //Console.WriteLine(string.Format("HDD 1 CRASHED DATA LEFT is {0} and {1}", b, ba));
            //int recoveredData = b ^ ba;
            //Console.WriteLine(string.Format("Recovered data is: {0} - {1}", recoveredData, (char)recoveredData));
            //Console.ReadLine();

            //ones complement-- invert bits and multiply by -1
            Console.WriteLine("Ones complement");
            Console.WriteLine(Convert.ToString(127, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(~127, 2).PadLeft(32, '0'));
            Console.WriteLine(128 * -1);




        }
    }
}
