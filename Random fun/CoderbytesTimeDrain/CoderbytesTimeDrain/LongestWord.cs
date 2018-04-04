using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class LongestWordChallenge
    {
        public static string LongestWord(string sen)
        {

            List<string> words = FindWords(sen);
            int longest = -1;
            int longestIndex = -1;
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > longest)
                {
                    longestIndex = i;
                    longest = words[i].Length;
                }
            }

            return words[longestIndex];

        }

        public static List<string> FindWords(string sen)
        {
            List<string> words = new List<string>();
            string strBuilder = "";
            for (int i = 0; i < sen.Length; i++)
            {
                if (sen[i] != ' ' && i != sen.Length)
                {
                    strBuilder += sen[i];
                }
                else
                {
                    words.Add(strBuilder);//add word already accumulated
                    strBuilder = "";
                }
            }
            return words;
        }
        static void Main()
        {
            // keep this function call here
            Console.WriteLine(LongestWord(Console.ReadLine()));
        }

    }
}
