using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionClient
{
    public static class BinaryConverter
    {
        public static string ToBinary(string text)
        {
            char[] textBytes = text.ToCharArray();
            byte[] bytes = Encoding.ASCII.GetBytes(textBytes);
            string binaryString = "";
            foreach (var charByte in bytes)
            {
                binaryString += Convert.ToString(charByte, 2).PadLeft(8,'0');
            }
            return binaryString;

        }

        public static string FromBinary(string binaryText)
        {
            List<char> binaryBuilder = new List<char>(binaryText.Length/8);
            for (int i = 0; i < binaryText.Length ; i++)
            {
                if (i % 8 == 0 || i==0 && i+8<binaryText.Length)
                {
                    binaryBuilder.Add((char)Convert.ToByte(binaryText.Substring(i, 8),2));
                }
            }
            string dataString = "";
            foreach (var b in binaryBuilder)
            {
                dataString += b;
            }

            return dataString;
        }
    }
}
