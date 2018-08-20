using SignedMessages.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SignedMessages.CryptoHelpers
{
    public class CryptoHelper
    {

        public static string CreateHMAC(string message, byte[] key)
        {
            //Create a HMAC object with a provided key
            HMAC mac = new HMACSHA256(key);
            //Generate the Message Authentication Code (and convert it to a nice looking base64 string)
            var hash = Convert.ToBase64String(mac.ComputeHash(Encoding.Unicode.GetBytes(message)));
            return hash;
            //We assume that the message has been recieved by the second party, along with the HMAC, 
            //so we take the shared key and try to generate a HMAC again, and compare them
            //ValidateHMAC(hash, message, key);
            
        }
        public static bool ValidateHMAC(string MACString, string message, byte[] key)
        {
            var hmac = new HMACSHA256(key);
            //Compute HMAC again from the message and key
            var hashToValidate = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(message)));
            Console.WriteLine("Checking hashes {0} == {1}", hashToValidate, MACString);
            Console.WriteLine((hashToValidate == MACString) ? "MATCH!" : "Auth failed");
            //Compare the newly computed HMAC with the one provided from the sender
            return hashToValidate == MACString;
        }
        private static bool CheckIfKeysAreEqual(byte[] aliceKey, byte[] bobKey)
        {
            for (int i = 0; i < bobKey.Length; i++)
            {
                Console.Write(aliceKey[i].ToString() + " ?= " + bobKey[i].ToString() + "\t" + (bobKey[i] == aliceKey[i]));
                if (bobKey[i] != aliceKey[i])
                {
                    Console.Write("Not identical");
                    return false;
                }
                Console.Write(Environment.NewLine);
            }
            return true;
        }
        //https://stackoverflow.com/questions/17128038/c-sharp-rsa-encryption-decryption-with-transmission/17137218
        //Note: RSA includes both encryption, message authentication (MAC) and key generation
        public static AssymetricKeyInformation RSA()
        {
            byte[] plainTextMessage = Encoding.ASCII.GetBytes("LOL");
            //Create RSA crytosystem object with 4096 bit key pair (create a public private key pair)
            RSACryptoServiceProvider rsaCrypto = new RSACryptoServiceProvider(4096);
            var privKey = rsaCrypto.ExportParameters(true);//get private key
            var pubKey = rsaCrypto.ExportParameters(false);//get public key
            //convert to XML strings for easier reading
            var stringPrivKey = GetKeyAsXMLString(privKey);
            var stringPubKey = GetKeyAsXMLString(pubKey);
            return new AssymetricKeyInformation { PublicKey = GetKeyAsXMLString(pubKey), PrivateKey = GetKeyAsXMLString(privKey) };
            //Print it
            //Console.WriteLine("Private Key: " + stringPrivKey);
            //Console.WriteLine("Public Key: " + stringPubKey);
            //Console.WriteLine("Encrypting {0} with public key", plainTextMessage);

            ////Case: I want to send an encrypted message to a reciever using his public key (only the private key can decrypt it)
            ////Create CSP to import a public key
            //var senderCSP = new RSACryptoServiceProvider();
            ////Import public key that the reciever has made public--> Simulates that the sender takes the recievers public key
            //senderCSP.ImportParameters(GetParametersFromXMLString(stringPubKey));
            ////encrypt message with public key
            //byte[] encryptedMessage = senderCSP.Encrypt(plainTextMessage, false);
            //Console.WriteLine(Encoding.ASCII.GetString(encryptedMessage));

            ////Message is sent over a network
            //var recieverCSP = new RSACryptoServiceProvider();
            ////Import private key --> simulates that the reciever uses his private key to decrypt
            //recieverCSP.ImportParameters(GetParametersFromXMLString(stringPrivKey));
            //var decryptedMessage = recieverCSP.Decrypt(encryptedMessage, false);
            //Console.WriteLine(Encoding.ASCII.GetString(decryptedMessage));

        }
        public static RSAParameters GetParametersFromXMLString(string xml)
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(xml);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }
        public static RSACryptoServiceProvider GetCSPProviderFromXMLString(string xml)
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(xml);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            RSAParameters param = (RSAParameters)xs.Deserialize(sr);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(param);
            return csp;
        }
        public static string GetKeyAsXMLString(RSAParameters parameters)
        {
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, parameters);
            //get the string from the stream
            return sw.ToString();
        }
      
    }
}