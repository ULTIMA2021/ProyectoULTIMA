using System;
using System.Text;
using System.Security.Cryptography;

namespace CapaLogica
{
    public static class CryptographyUtils
    {
        //public static string encryptThis(string target, bool isLogging) {

        //    byte[] buffer = Encoding.Default.GetBytes(target);
        //    string result;
        //    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        //    aes.KeySize = 256;
        //    aes.GenerateKey();
        //    aes.GenerateIV();
        //    Console.WriteLine($"KEY:{Encoding.Default.GetString(aes.Key)}");
        //    Console.WriteLine($"KEYSIZE:{Encoding.Default.GetString(aes.Key).Length}");
        //    Console.WriteLine($"IV:{Encoding.Default.GetString(aes.IV)}");
        //    Console.WriteLine($"IVSIZE:{Encoding.Default.GetString(aes.IV).Length}");

        //    ICryptoTransform transform = aes.CreateEncryptor();
        //    var t = transform.TransformFinalBlock(buffer, 0, buffer.Length);
        //    result =
        //        Encoding.Default.GetString(t) +
        //        Convert.ToChar(Encoding.Default.GetString(t).Length) +
        //        Encoding.Default.GetString(aes.Key) +
        //        Convert.ToChar(Encoding.Default.GetString(aes.Key).Length) +
        //        Encoding.Default.GetString(aes.IV) +
        //        Convert.ToChar(Encoding.Default.GetString(aes.IV).Length);

        //    // esta parte iria en un metodo aparte es para extraer la llave y IV de el string incriptado
        //    // luego se usa la llave y la IV para comparar la clave del usuario sin decriptarla esos campos para comparar la clave ya encrypted

        //    Console.WriteLine($"OUTPUT:{result}");
        //    Console.WriteLine($"reading............");

        //    byte[] resArray = Encoding.Default.GetBytes(result);
        //    byte identifierIV = resArray[resArray.Length - 1];
        //    byte identifierKey = resArray[resArray.Length - identifierIV - 2];
        //    byte identifierPw = resArray[resArray.Length - identifierIV - identifierKey - 3];

        //    byte[] iv = new byte[identifierIV];
        //    byte[] key = new byte[identifierKey];
        //    byte[] pw = new byte[identifierPw];

        //    Array.Copy(resArray, resArray.Length - identifierIV - 1, iv, 0, identifierIV);
        //    Array.Copy(resArray, resArray.Length - identifierIV - identifierKey - 2, key, 0, identifierKey);
        //    Array.Copy(resArray, resArray.Length - identifierPw - identifierIV - identifierKey - 3, pw, 0, identifierPw);

        //    Console.WriteLine($"IV:{Encoding.Default.GetString(iv)}");
        //    Console.WriteLine($"KEY:{Encoding.Default.GetString(key)}");
        //    Console.WriteLine($"PW:{Encoding.Default.GetString(pw)}");

        //    return (result);
        //}


        public static bool comparePasswords(string submittedText, string encryptedText)
        {
            Console.WriteLine($"INCOMING:{encryptedText}");
            Console.WriteLine($"INCOMING:{encryptedText}");

            byte[] encryptedArray = Encoding.Default.GetBytes(encryptedText);
            byte identifierIV = encryptedArray[encryptedArray.Length - 1];
            byte identifierKey = encryptedArray[encryptedArray.Length - identifierIV - 2];
            byte identifierPw = encryptedArray[encryptedArray.Length - identifierIV - identifierKey - 3];

            byte[] iv = getIV(encryptedArray, identifierIV);
            byte[] key = getKey(encryptedArray, identifierIV, identifierKey);
            byte[] pw = new byte[identifierPw];
            string encryptedSubmitted = doEncryption(submittedText, key, iv);

            Console.WriteLine($"INCOMING:{encryptedText}");

            Console.WriteLine($"IV:{Encoding.Default.GetString(iv)}");
            Console.WriteLine($"KEY:{Encoding.Default.GetString(key)}");
            Console.WriteLine($"PW:{Encoding.Default.GetString(pw)}");


            if (string.Equals(encryptedSubmitted, encryptedText))
                return true;
            return false;
        }

        private static byte[] getIV(byte[] encryptedArray, byte identifierIV)
        {
            byte[] iv = new byte[identifierIV];
            Array.Copy(encryptedArray, encryptedArray.Length - identifierIV - 1, iv, 0, identifierIV);
            return iv;
        }

        private static byte[] getKey(byte[] encryptedArray, byte identifierIV, byte identifierKey)
        {
            byte[] key = new byte[identifierKey];
            Array.Copy(encryptedArray, encryptedArray.Length - identifierIV - identifierKey - 2, key, 0, identifierKey);
            return key;
        }

        public static string doEncryption(string target, byte[] key, byte[] iv)
        {
            byte[] buffer = Encoding.Default.GetBytes(target);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            if (key is null)
            {
                aes.KeySize = 256;
                aes.GenerateKey();
                aes.GenerateIV();
            }
            else
            {
                aes.Key = key;
                aes.IV = iv;
            }
            ICryptoTransform transform = aes.CreateEncryptor();
            byte[] t = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return @combineFields(aes, t);
        }

        private static string combineFields(AesCryptoServiceProvider aes, byte[] t)
        {
            string @result =
               @Encoding.Default.GetString(t) +
               Convert.ToChar(@Encoding.Default.GetString(t).Length) +
               @Encoding.Default.GetString(aes.Key) +
               Convert.ToChar(@Encoding.Default.GetString(aes.Key).Length) +
               Encoding.Default.GetString(aes.IV) +
               Convert.ToChar(@Encoding.Default.GetString(aes.IV).Length);


            Console.WriteLine($"KEY:{Encoding.Default.GetString(aes.Key)}");
            Console.WriteLine($"KEYSIZE:{Encoding.Default.GetString(aes.Key).Length}");
            Console.WriteLine($"IV:{Encoding.Default.GetString(aes.IV)}");
            Console.WriteLine($"IVSIZE:{Encoding.Default.GetString(aes.IV).Length}");

            return @result;
        }
    }
}