using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class CheckNumsChallenge
    {

        public static string CheckNums(int num1, int num2)
        {

            // code goes here  
            /* Note: In C# the return type of a function and the 
               parameter types being passed are defined, so this return 
               call must match the return type of the function.
               You are free to modify the return type. */

            return num2 == num1 ? "-1" : (num2 > num1 ? "true" : "false");

        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(CheckNums(Console.ReadLine()));
        }


    }
}
