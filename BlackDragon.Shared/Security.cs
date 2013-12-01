using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace BlackDragon.Shared
{
    public static class Security
    {
        private const string PasswordHash = "rMuRttcuyEr";
        private const string SaltKey = "SmyrTtuiVtr";
        private const string VIKey = "@sMgRdOhOtErynut";

        public static string Encrypt(string plaintext)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plaintext);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        public static string Hash(string text)
        {
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[text.Length * 2];
            enc.GetBytes(text.ToCharArray(), 0, text.Length, unicodeText, 0, true);
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] result = md5.ComputeHash(unicodeText);
                StringBuilder encryptPassword = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    encryptPassword.Append(result[i].ToString("X2"));
                }
                return encryptPassword.ToString();
            }
        }
    }
}
