using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinegere
{
   public class Vinegere
    {
        public string Alphabeth { get; set; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 .,:";
        //private string alphabeth = "abcdefghijklmnopqrstuvwxyz";
        private char[,] VinegereMatrix;
        public Vinegere()
        {
            //Initialize Matrix (we add +1 row and +1 column extra because we need the alphabeth padding in each side of the vinegere tableu
            VinegereMatrix = new char[Alphabeth.Length + 1, Alphabeth.Length + 1];
            BuildVinegereTableu();
        }
        private void BuildVinegereTableu()
        {
            int transpositionCounter = 0;
            //a-z row+column padding
            for (int j = 1; j < VinegereMatrix.GetLength(0); j++)
            {
                if (j != 0)
                {
                    VinegereMatrix[0, j] = Alphabeth[j - 1];
                    VinegereMatrix[j, 0] = Alphabeth[j - 1];
                }
                else
                {
                    VinegereMatrix[0, j] = Alphabeth[j];
                    VinegereMatrix[j, 0] = Alphabeth[j];
                }
            }
            for (int i = 1; i <= Alphabeth.Length; i++)
            {
                for (int j = 1; j <= Alphabeth.Length; j++)
                {
                    VinegereMatrix[i, j] = Alphabeth[(j + transpositionCounter - 1) % Alphabeth.Length];
                }
                transpositionCounter++;
            }
            VinegereMatrix[0, 0] = ' ';
        }
        public char FindEncryptedChar(char clearChar, char keyChar)
        {
            int keyCharIndex = -1;
            int clearCharIndex = -1;
            //Run through keylist, find index of char in row 0 (-1)
            for (int i = 0; i < VinegereMatrix.GetLength(1); i++)
            {

                if (VinegereMatrix[0, i] == keyChar)
                    keyCharIndex = i;
            }
            for (int i = 0; i < VinegereMatrix.GetLength(0); i++)
            {

                if (VinegereMatrix[i, 0] == clearChar)
                    clearCharIndex = i;
            }
            return VinegereMatrix[keyCharIndex, clearCharIndex];
            //Run through clearlist find index of char in row 1  (-1)

            //combine indexes to find encryped char
        }
        public char FindDecryptedChar(char encryptChar, char keyChar)
        {
            int keyCharIndex = -1;
            int encryptCharCharIndex = -1;
            //Run through keylist, find index of char in row 0 (-1)
            for (int i = 0; i < VinegereMatrix.GetLength(1); i++)
            {

                if (VinegereMatrix[0, i] == keyChar)
                {
                    keyCharIndex = i;
                    break;
                }
            }
            for (int i = 0; i < VinegereMatrix.GetLength(0); i++)
            {
                if (VinegereMatrix[i, keyCharIndex] == encryptChar)
                {
                    encryptCharCharIndex = i;
                    break;
                }
            }
            return VinegereMatrix[0, encryptCharCharIndex];
        }
        private string ElongateKey(int stringLength, string key)
        {
            //if (key.Length > stringLength)
            //    return key.Substring(0, stringLength);

            int paddingCounter = 0;
            while (key.Length < stringLength)
            {
                if (paddingCounter == key.Length - 1)
                    paddingCounter = 0;
                key = key.PadRight(key.Length + 1, key[paddingCounter]);
                paddingCounter++;
            }
            return key;
        }
        public string Encrypt(string s, string key)
        {
            //Elongate key so it is as long as the text to encrypt
            var elongatedKey = ElongateKey(s.Length, key);
            string tempString = "";
            for (int i = 0; i < s.Length; i++)
            {
                tempString += FindEncryptedChar(s[i], elongatedKey[i]);
            }
            return tempString;
        }
        public string Decrypt(string s, string key)
        {
            //Elongate key so it is as long as the text to decrypt
            var elongatedKey = ElongateKey(s.Length, key);
            string tempString = "";
            for (int i = 0; i < s.Length; i++)
            {
                tempString += FindDecryptedChar(s[i], elongatedKey[i]);
            }
            return tempString;
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < VinegereMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < VinegereMatrix.GetLength(1); j++)
                {
                    Console.Write(VinegereMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
