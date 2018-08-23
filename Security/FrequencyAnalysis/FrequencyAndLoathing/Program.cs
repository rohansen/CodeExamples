using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://www.gutenberg.org/
namespace FrequencyAndLoathing
{
    class Program
    {//problem - dem der er tæt på hinanden forvirrer: ide.. swap dem der er tæt  på hinanden i frekvens for at finde mening i teksten
        static byte[] readBuffer = new byte[4096];
        static void Main(string[] args)
        {

            StringBuilder sb = new StringBuilder();
            using (FileStream fs = File.OpenRead("fear.txt"))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string newLine;
                        while ((newLine = sr.ReadLine()) != null)
                        {
                            sb.Append(newLine);
                        }
                    }
                }
            }
            string SSSS = sb.ToString();
            string encryptedText = Encrypt(sb.ToString().ToUpper(), 3);
            string dec = Decrypt(encryptedText, 3);
            var clearTextFrequencies = SSSS.ToUpper().Where(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Contains(c)).GroupBy(c => c).Select(x => new FrequencyElement { Character = x.Key, Frequency = x.Count() }).OrderBy(x => x.Frequency).ToList();
            //Console.WriteLine(encryptedText);
            //Console.WriteLine(dec);

            var englishFrequencies = GetEnglishFrequencies();
            var encFrequencies = encryptedText.Where(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Contains(c)).GroupBy(c => c).Select(x=>new FrequencyElement { Character = x.Key, Frequency = x.Count() }).OrderBy(x=>x.Frequency).ToList();//.OrderBy(x => x.Count());
            PrintSideBySide(clearTextFrequencies, englishFrequencies, encFrequencies);

            StringBuilder sb2 = new StringBuilder(encryptedText);
            for (int i = 0; i < encFrequencies.Count(); i++)
            {
                sb2.Replace(encFrequencies[i].Character, englishFrequencies[i].Character);
            }

            var asd = "";
        }

        private static void PrintSideBySide(List<FrequencyElement> clearTextFrequencies, List<FrequencyElement> englishFrequencies, List<FrequencyElement> encFrequencies)
        {
            for (int i = 0; i < clearTextFrequencies.Count; i++)
            {
                Console.WriteLine("{0}-{1}-{2}", englishFrequencies[i].Character, clearTextFrequencies[i].Character, encFrequencies[i].Character);
            }
            Console.ReadLine();
        }

        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        private static List<FrequencyElement> GetEnglishFrequencies()
        {
            var englishFrequencies = new List<FrequencyElement>();
            englishFrequencies.Add(new FrequencyElement { Character = 'A', Frequency = 8.167 });
            englishFrequencies.Add(new FrequencyElement { Character = 'B', Frequency = 1.492 });
            englishFrequencies.Add(new FrequencyElement { Character = 'C', Frequency = 2.782 });
            englishFrequencies.Add(new FrequencyElement { Character = 'D', Frequency = 4.253 });
            englishFrequencies.Add(new FrequencyElement { Character = 'E', Frequency = 12.702 });
            englishFrequencies.Add(new FrequencyElement { Character = 'F', Frequency = 2.228 });
            englishFrequencies.Add(new FrequencyElement { Character = 'G', Frequency = 2.015 });
            englishFrequencies.Add(new FrequencyElement { Character = 'H', Frequency = 6.094 });
            englishFrequencies.Add(new FrequencyElement { Character = 'I', Frequency = 6.966 });
            englishFrequencies.Add(new FrequencyElement { Character = 'J', Frequency = 0.153 });
            englishFrequencies.Add(new FrequencyElement { Character = 'K', Frequency = 0.772 });
            englishFrequencies.Add(new FrequencyElement { Character = 'L', Frequency = 4.025 });
            englishFrequencies.Add(new FrequencyElement { Character = 'M', Frequency = 2.406 });
            englishFrequencies.Add(new FrequencyElement { Character = 'N', Frequency = 6.749 });
            englishFrequencies.Add(new FrequencyElement { Character = 'O', Frequency = 7.507 });
            englishFrequencies.Add(new FrequencyElement { Character = 'P', Frequency = 1.929 });
            englishFrequencies.Add(new FrequencyElement { Character = 'Q', Frequency = 0.095 });
            englishFrequencies.Add(new FrequencyElement { Character = 'R', Frequency = 5.987 });
            englishFrequencies.Add(new FrequencyElement { Character = 'S', Frequency = 6.327 });
            englishFrequencies.Add(new FrequencyElement { Character = 'T', Frequency = 9.056 });
            englishFrequencies.Add(new FrequencyElement { Character = 'U', Frequency = 2.758 });
            englishFrequencies.Add(new FrequencyElement { Character = 'V', Frequency = 0.978 });
            englishFrequencies.Add(new FrequencyElement { Character = 'W', Frequency = 2.360 });
            englishFrequencies.Add(new FrequencyElement { Character = 'X', Frequency = 0.150 });
            englishFrequencies.Add(new FrequencyElement { Character = 'Y', Frequency = 1.974 });
            englishFrequencies.Add(new FrequencyElement { Character = 'Z', Frequency = 0.074 });
            return englishFrequencies.OrderBy(x => x.Frequency).ToList();
        }

        public static string Encrypt(string input, int key)
        {
      
            StringBuilder builder = new StringBuilder();
            foreach (char ch in input)
                builder.Append(cipher(ch, key));

            return builder.ToString();
        }

        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, 26 - key);
        }
    }
}
