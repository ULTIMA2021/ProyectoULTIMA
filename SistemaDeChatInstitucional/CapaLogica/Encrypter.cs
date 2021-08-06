using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace CapaLogica
{
    public static partial class Cryptography
    {
        private static string encrypted;
        private static SymmetricAlgorithm desObj = Rijndael.Create();
        private static byte[] plainKey = Encoding.ASCII.GetBytes("0123456789abcdef");
        private static byte[] encryptedBytes;

        public static string encryptThis(string target) {
            byte[] plainBytes = Encoding.ASCII.GetBytes(target);
            desObj.Key = plainKey;
            desObj.Mode = CipherMode.CBC;
            desObj.Padding = PaddingMode.PKCS7;

            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(stream, desObj.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(plainBytes,0,plainBytes.Length);
            cryptoStream.Close();
            encryptedBytes = stream.ToArray();
            stream.Close();
            encrypted = Encoding.ASCII.GetString(encryptedBytes);
            Console.WriteLine("THIS IS THE ORIGINAL MAN\n" + target);
            Console.WriteLine("THIS IS THE ENCRYPTED MAN\n"+ encrypted);
            return encrypted;
        }
        //NOSE QUE MIERDA LE PASA entonces lo puse en un puto try catch de mierda
        public static void decryptThis(string target)
        {
            try
            {

                byte[] plainBytes;
                byte[] encryptedBytes;


                encryptedBytes = Encoding.ASCII.GetBytes(target);

                System.IO.MemoryStream s = new System.IO.MemoryStream(encryptedBytes);
                CryptoStream cs = new CryptoStream(s, desObj.CreateDecryptor(), CryptoStreamMode.Read);

                cs.Read(encryptedBytes, 0, encryptedBytes.Length);

                plainBytes = s.ToArray();

                cs.Close();
                s.Close();

                Console.WriteLine("DE THIS IS THE ORIGINAL MAN\n" + target);
                target = Encoding.ASCII.GetString(plainBytes);
                Console.WriteLine("DE THIS IS THE DECRYPTED MAN\n" + target);
            }
            catch (Exception  e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
