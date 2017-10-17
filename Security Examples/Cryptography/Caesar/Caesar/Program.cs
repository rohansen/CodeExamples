using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            Vinegere v = new Vinegere();
            v.PrintMatrix();
            while (true)
            {
                CaesarCypher cc = new CaesarCypher();
                var cypherText = cc.EncryptStaticAlphabeth(Console.ReadLine());
                Console.WriteLine(cypherText);
                var clearText = cc.DecryptStaticAlphabeth(cypherText);
                Console.WriteLine(clearText); 
            }
        }

      
    }
}
