using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforcer
{
    class Program
    {

        static string passwordToFind = "abc";//iddqd1234
        static char[] alphabeth = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        static char[] debugAlphabeth = "abc".ToCharArray();
        static bool found = false;
        static void Main(string[] args)
        {


            //StringBuilder sb = new StringBuilder(passwordToFind.Length);
            //char currentChar = alphabeth[0];

            //for (int i = 1; i <= passwordToFind.Length; i++)
            //{
            //    sb.Append(currentChar);
            //}
            ////Beginning string to transform will be aaaa...n(passwordLength)
            //var answer = ChangeCharacters(0, sb, passwordToFind.Length);
            //Console.WriteLine(answer.ToString());

            NonRecursiveSearch();

        }

        private static void NonRecursiveSearch()
        {
          
            StringBuilder sb = new StringBuilder(passwordToFind.Length);
            char currentChar = debugAlphabeth[0];
            int position = 0;
            for (int i = 1; i <= passwordToFind.Length; i++)
            {
                sb.Append(currentChar);
            }
            for (int i = 0; i < debugAlphabeth.Length; i++)
            {
                for (int j = 0; j < debugAlphabeth.Length; j++)
                {
                    if (position == passwordToFind.Length)
                    {
                        return;
                    }
                    sb.Replace(sb[position], debugAlphabeth[j], position, 1);
                    Console.WriteLine("Trying: " + sb.ToString());


                    if (CheckPassword(sb.ToString(), passwordToFind))
                    {
                        Console.WriteLine("Found " + sb.ToString());
                        return;
                    }
                    
                    
                }
                sb.Replace(sb[position], debugAlphabeth[0], position, 1);
                position++;
            }
        }

        private static bool CheckPassword(string v, string passwordToFind)
        {
            
            return v == passwordToFind;
        }

        private static StringBuilder ChangeCharacters(int pos, StringBuilder sb, int length)
        {

            for (int i = 0; i <= alphabeth.Length - 1; i++)
            {
                //sb.setCharAt(pos, fCharList[i]);

                sb.Replace(sb[pos], alphabeth[i], pos, 1);

                if (pos == length - 1)
                {
                    // Write the Brute Force generated word.
                    Console.WriteLine(sb.ToString());
                }
                else
                {

                    ChangeCharacters(pos + 1, sb, length);
                    Console.WriteLine("Current try: " + sb.ToString());
                }
            }

            return sb;
        }

    }
}
