using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinegere
{
    class Program
    {
        static void Main(string[] args)
        {
            Vinegere v = new Vinegere();
            v.PrintMatrix();
            var encryptedText = v.Encrypt("Hello World 2017.", "MonkeySeeMonkeyDo2017");
            Console.WriteLine(encryptedText);
            var decryptedText = v.Decrypt(encryptedText, "MonkeySeeMonkeyDo2017");
            Console.WriteLine(decryptedText);
        }
    }
}
