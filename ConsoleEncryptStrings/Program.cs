using EncryptStrings;
using System;

namespace ConsoleEncryptStrings
{
    class Program
    {
        static string StringToEncrypt { get; set; }
        static string StringToDecrypt { get; set; }
        //static string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string EncryptionKey = "Security";
        static void Main()
        {
            GetEncryptedValue();
            GetDecryptedValue();
            Console.Read();
        }

        static void GetEncryptedValue()
        {
            Console.WriteLine("Enter the string that you want to encrypt: ");
            StringToEncrypt = Console.ReadLine();
            var encryptedString = StringToEncrypt.Encrypt(EncryptionKey);
            Console.WriteLine($"Encrypted String is {encryptedString}");
        }
        static void GetDecryptedValue()
        {
            Console.WriteLine("Enter the string that you want to decrypt: ");
            StringToDecrypt = Console.ReadLine();
            var decryptedString = StringToDecrypt.Decrypt(EncryptionKey);
            Console.WriteLine($"Decrypted String is {decryptedString}");
        }
    }
}
