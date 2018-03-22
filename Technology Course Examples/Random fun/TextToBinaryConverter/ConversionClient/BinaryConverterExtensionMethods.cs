using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionClient
{
    public static class BinaryConverterExtensionMethods
    {
        public static string ToBinary(this string s)
        {
            char[] textBytes = s.ToCharArray();
            byte[] bytes = Encoding.ASCII.GetBytes(textBytes);
            string binaryString = "";
            foreach (var charByte in bytes)
            {
                binaryString += Convert.ToString(charByte, 2).PadLeft(8, '0');
            }
            return binaryString;

        }

        public static string FromBinary(this string s)
        {
            List<char> binaryBuilder = new List<char>(s.Length / 8);
            for (int i = 0; i < s.Length; i++)
            {
                if (i % 8 == 0 || i == 0 && i + 8 < s.Length)
                {
                    binaryBuilder.Add((char)Convert.ToByte(s.Substring(i, 8), 2));
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
