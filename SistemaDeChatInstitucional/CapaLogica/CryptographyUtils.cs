using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace CapaLogica
{
    public static class CryptographyUtils
    {

        //donde saque el codigo:
        //https://www.youtube.com/watch?v=PrjgsaY2hac

        //funciona pero para guardar la clave encriptada en la bd tambien necesito la key que se uso
        //en el algoritmo de encripcion. Para llamarlo en la desencripcion

        private static byte[] KEY;
        private static byte[] IV;

        public static string encryptThis(string target)
        {
            newSafeKey();
            var buffer = Encoding.UTF8.GetBytes(target);
            var tripleDES = new TripleDESCryptoServiceProvider()
            {
                IV = IV,
                Key = KEY
            };
            ICryptoTransform transform = tripleDES.CreateEncryptor();
            var cipherText = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return Convert.ToBase64String(cipherText);
        }

        public static string decryptThis(string encryptedText)
        {
            var buffer = Convert.FromBase64String(encryptedText);
            var tripleDES = new TripleDESCryptoServiceProvider()
            {
                IV = IV,
                Key = KEY
            };
            ICryptoTransform transform = tripleDES.CreateDecryptor();
            var cipherText = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(cipherText);
        }

        //me genera una crypto key y vector de inicialization nuevo
        public static void newSafeKey()
        {
            KEY = null;
            IV = null;
            var tripleDES = new TripleDESCryptoServiceProvider();
            KEY = tripleDES.Key;
            IV = tripleDES.IV;
        }

        
    }
}
