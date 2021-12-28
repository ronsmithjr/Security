using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptStrings
{
    /// <summary>
    /// *****2 things of note*****
    /// 1. The encrypt and decrypt need the same key in order to function properly
    /// 2. You have to create a front end in order to get the same key/passord pair for the encryption and decryption methods.
    /// </summary>
    public static class EncryptDecrypt
    {
        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="encryptString">String to Encrypt</param>
        /// <param name="encryptionKey">Key to use to encrypt the string</param>
        /// <returns></returns>
        public static string Encrypt(this string encryptString, string encryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="cipherText">string to decrypt</param>
        /// <param name="encryptionKey">String to use to decrypt the string</param>
        /// <returns></returns>
        public static string Decrypt(this string cipherText, string encryptionKey)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
