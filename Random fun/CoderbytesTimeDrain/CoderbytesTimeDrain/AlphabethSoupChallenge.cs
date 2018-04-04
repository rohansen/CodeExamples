using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class AlphabethSoupChallenge
    {

        public static string AlphabetSoup(string str)
        {
            char[] characters = str.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                for (int j = 0; j < characters.Length; j++)
                {
                    if (characters[j] > characters[i])
                    {
                        char temp = characters[i];
                        characters[i] = characters[j];
                        characters[j] = temp;
                    }
                }
            }

            return new string(characters);

        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(AlphabetSoup(Console.ReadLine()));
        }


    }
}
