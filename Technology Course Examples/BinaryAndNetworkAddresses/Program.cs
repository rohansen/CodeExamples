using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAndNetworkAddresses
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Console.WriteLine("Enter regular IP");
                //string binaryIp = ConvertToBinary(Console.ReadLine());
                //Console.WriteLine(binaryIp);
                //Console.WriteLine("Enter binary IP");
                //string stringIp = ConvertToIntegers(Console.ReadLine());
                //Console.WriteLine(stringIp);
                FindBroadcastAddress(new byte[] { 192, 168, 0, 200 }, new byte[] { 255, 255, 255, 0 });
                Console.ReadLine();
            }
        }


        public static string ConvertToBinary(string ip)
        {
            byte[] numbers = ip.Split('.').Select(x=>Convert.ToByte(x)).ToArray();
            string binaryIp = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != 0)
                    binaryIp += '.';
                binaryIp += Convert.ToString(numbers[i], 2).PadLeft(8, '0');
            }
            return binaryIp;
        }
        public static string ConvertToIntegers(string binaryIp)
        {
            byte[] numbers = binaryIp.Split('.').Select(x => Convert.ToByte(x,2)).ToArray();
            string stringIp = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != 0)
                    stringIp += '.';
                stringIp += Convert.ToString(numbers[i], 10);
            }
            return stringIp;
        }
        public static void FindNetworkAddress(byte[] ip, byte[] subnet)
        {
            if (ip.Length != subnet.Length)
                throw new ArgumentException("IP and SUBNET octets not defined equally");
            if (ip.Length < 0 || subnet.Length < 0)
                throw new ArgumentNullException("IP or Subnet byte arrays were empty");

            for (int i = 0; i < ip.Length; i++)
            {
                Console.WriteLine(ip[i] & subnet[i]);
            }

            Console.ReadLine();
        }
        public static void FindBroadcastAddress(byte[] ip, byte[] subnet)
        {
            if (ip.Length != subnet.Length)
                throw new ArgumentException("IP and SUBNET octets not defined equally");
            if (ip.Length < 0 || subnet.Length < 0)
                throw new ArgumentNullException("IP or Subnet byte arrays were empty");

            //Convert subnet bytearray to base2 bitstring
            string binaryString = "";
            for (int i = 0; i < subnet.Length; i++)
            {
                binaryString += Convert.ToString(subnet[i],2);
            }
            //look at the bitstring, and flip the bits into an array
            string invertedSubnet = "";
            byte[] invertedBytes = new byte[4];
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '0')
                {
                    invertedSubnet += '1';
                }
                else
                {
                    invertedSubnet += '0';
                }
            }
            string tempByte = "";
            int count = 0;
            for (int i = 0; i < invertedSubnet.Length; i++)
            {
                
                tempByte += invertedSubnet[i];
                if (tempByte.Length==8) {
                    invertedBytes[count] = Convert.ToByte(tempByte,2);
                    count++;
                    tempByte = "";
                }
            }
            

            //show bytes
            Console.WriteLine(binaryString);//subnet
            Console.WriteLine(invertedSubnet); //subnet

            //show inverted bytes

            for (int i = 0; i < ip.Length; i++)
            {
                var octet = ip[i] | invertedBytes[i];
                if (i != 0) 
                    Console.Write(".");

                Console.Write(octet);
            }

            Console.ReadLine();
        }
    }
}
