
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BinaryPlayground
{
    public class Program
    {
        private static int binaryZeroPadding = 16;
        private static int myNumber = 13;
        static void Main(string[] args)
        {
            ConsoleKeyInfo keypress;
            Console.OutputEncoding = Encoding.ASCII;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitshifting Application: Use left and right arrows to shift bits.");
                Console.WriteLine("Current number: {0}", myNumber);
                Console.WriteLine("Binary: {0}", Convert.ToString(myNumber, 2).PadLeft(binaryZeroPadding, '0'));
                Console.WriteLine("Hexidecimal: {0}", Convert.ToString(myNumber, 16));
                Console.WriteLine("ASCII Char (if it exists) {0}", Encoding.ASCII.GetString(new byte[]{(byte)myNumber}));
                keypress = Console.ReadKey();
                //"Removing" Integer overflow when hitting the boundries
                if (myNumber <=0)
                {
                    myNumber = 128;

                }else if (keypress.Key == ConsoleKey.LeftArrow)
                {
                    myNumber = myNumber << 1;
                  
                }
                else if (keypress.Key == ConsoleKey.RightArrow)
                {
                    myNumber = myNumber>>1;
                  
                }
                else if (keypress.Key == ConsoleKey.Escape)
                {
                    break;
                }
                
            }

        }


    }
}
