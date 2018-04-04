using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    public class FirstReverseChallenge
    {
        public static string FirstReverse(string str)
        {

            char[] newWord = new char[str.Length];
            int j = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                newWord[j] = str[i];
                j++;
            }
            return new string(newWord);
        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(FirstReverse(Console.ReadLine()));
        }


    }
}
