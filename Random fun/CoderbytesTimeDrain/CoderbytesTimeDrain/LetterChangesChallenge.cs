using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class LetterChangesChallenge
    {

        private static string alphabeth = "abcdefghijklmnopqrstuvwxyz";
        private static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        public static string LetterChanges(string str)
        {
            char[] newWord = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (alphabeth.Contains(str[i]))
                {
                    newWord[i] = (char)((alphabeth[(alphabeth.IndexOf(str[i]) + 1) % alphabeth.Length]));
                }
                else
                {
                    newWord[i] = str[i];
                }

                if (vowels.Contains(newWord[i]))
                {
                    newWord[i] = char.ToUpper(newWord[i]);
                }


            }

            return new string(newWord);

        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(LetterChanges(Console.ReadLine()));
        }


    }
}
