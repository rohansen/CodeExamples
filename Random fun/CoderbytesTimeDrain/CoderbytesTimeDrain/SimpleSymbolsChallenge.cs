using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class SimpleSymbolsChallenge
    {

        public static string SimpleSymbols(string str)
        {
            char[] notLetters = new char[] { '+', '=', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < str.Length; i++)
            {

                if (!Contains(notLetters, str[i]))
                {
                    if (i == 0 || i == str.Length - 1)
                    {
                        return "false";
                    }
                    if (str[i - 1] == '+' && str[i + 1] == '+')
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }


            }
            return "true";


        }

        private static bool Contains(char[] list1, char charToCheck)
        {
            for (int i = 0; i < list1.Length; i++)
            {

                if (list1[i] == charToCheck)
                {
                    return true;
                }
            }
            return false;
        }


        static void Main()
        {
            // keep this function call here
            Console.WriteLine(SimpleSymbols(Console.ReadLine()));
        }


    }
}
