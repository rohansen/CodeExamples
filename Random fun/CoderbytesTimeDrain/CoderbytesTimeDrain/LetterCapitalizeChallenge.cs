using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class LetterCapitalizeChallenge
    {

        public static string LetterCapitalize(string str)
        {
            var stringAsChar = str.ToCharArray();
            for (int i = 0; i < stringAsChar.Length; i++)
            {
                if (i == 0)
                {
                    stringAsChar[i] = char.ToUpper(stringAsChar[i]);
                }
                else if (stringAsChar[i] == ' ' && (i + 1 < stringAsChar.Length))
                {
                    stringAsChar[i + 1] = char.ToUpper(stringAsChar[i + 1]);
                }
            }

            return new string(stringAsChar);

        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(LetterCapitalize(Console.ReadLine()));
        }


    }
}
