using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExercisesNET
{
    internal class AesEncryption
    {
        public void Test()
        {
            var text = "Password";
            var aes = Aes.Create();

            var encryptedData = Encrypt(text, aes.Key, aes.IV);

            var decryptedPass = Decrypt(encryptedData, aes.Key, aes.IV);
        }


        private byte[] Encrypt(string data, byte[] key, byte[] vector) 
        {
            var aes = Aes.Create();
            aes.Key = key;
            aes.IV = vector;
            byte[] encryptedData;
            var encryptor = aes.CreateEncryptor();

            using (var memory = new MemoryStream())
            {
                using (var crypto = new CryptoStream(memory, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(crypto))
                    {
                        writer.Write(data);
                    }
                    encryptedData = memory.ToArray();
                }
            }

            return encryptedData;
        }

        private string Decrypt(byte[] encryptedData, byte[] key, byte[] vector)
        {

            var aes = Aes.Create();
            aes.Key = key;
            aes.IV = vector;
            string encrypted;
            var decryptor = aes.CreateDecryptor();

            using (var memory = new MemoryStream(encryptedData))
            {
                using (var crypto = new CryptoStream(memory, decryptor, CryptoStreamMode.Read))
                {
                    using (var reader = new StreamReader(crypto))
                    {
                        encrypted = reader.ReadToEnd();
                    }
                }
            }

            return encrypted;
        }
    }
}
