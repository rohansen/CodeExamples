using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    //Time - i wish i had more 
    public class Vinegere
    {
        private char[,] VinegereMatrix;
        private string alphabeth = "abcdefghijklmnopqrstuvwxyzæøå";
        public Vinegere()
        {
            int transposition = 0;
            VinegereMatrix = new char[alphabeth.Length, alphabeth.Length];
            for (int i = 0; i < alphabeth.Length; i++)
            {
              
                for (int j = 0; j < alphabeth.Length; j++)
                {
                    VinegereMatrix[i, j] = alphabeth[(j+transposition)%alphabeth.Length];
                }
                transposition++;
            }
           
            string test = "asd";
        }
        public char FindeEncryptedChar(char input, char keySubstitute)
        {
            throw new NotImplementedException();
        }
        public char FindDecryptedChar(char input, char keySubstitute)
        {
            throw new NotImplementedException();
        }
        public string Encrypt(string s)
        {
            throw new NotImplementedException();
        }
        public string Decrypt(string s)
        {
            throw new NotImplementedException();
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < VinegereMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < VinegereMatrix.GetLength(1); j++)
                {
                    Console.Write(VinegereMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
