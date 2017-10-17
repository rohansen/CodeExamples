using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    public class CaesarCypher
    {
        private static char[] alphabeth = "abcdefghijklmnopqrstuvxyzw".ToCharArray();
        public string Encrypt(string s)//This doesnt use a static alphabeth, relies on the charset
        {
            var input = s.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (char)(input[i] + 3);
            }
            return new string(input);
        }
        public string Decrypt(string s)//This doesnt use a static alphabeth, relies on the charset
        {
            var input = s.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (char)(input[i] - 3);
            }
            return new string(input);
        }
        public string EncryptStaticAlphabeth(string s)//This uses a static alphabeth, defined above
        {

            var input = s.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                var remainder = (Array.IndexOf(alphabeth, input[i]) + 3) % alphabeth.Length;
                Debug.WriteLine(remainder);
               
                input[i] = alphabeth[remainder];

            }
            return new string(input);
        }
        public string DecryptStaticAlphabeth(string s)//This uses a static alphabeth, defined above
        {
            //xyz
            var input = s.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                var index = (Array.IndexOf(alphabeth, input[i]) - 3) % alphabeth.Length;
                if (index < 0)
                {
                    index = alphabeth.Length+index; //If the index for our alfabeth ends as a negtive, we plus the negative number to the arrays length(we deduct it, and get to the end of the array (eg. 0(a)+(-3) = 24(y)))
                }
                input[i] = alphabeth[index];
                
            }
            return new string(input);
        }

        public char[] EncryptLinq(string s) //not done yet, just for fun
        {
            var xx =  s.ToCharArray()
                .Where(x=>x>=65 && x<=90)
                .Select(x => Convert.ToChar((x+3)))
                .ToArray();
            return xx;
        }
      

    }
}
