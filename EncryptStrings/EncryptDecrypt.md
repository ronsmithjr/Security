
#EncryptDecrypt

### You can use the following example code ().NET4.7 Console Application) to generate matching encrypt/decrypt keys for your password
#### You are going add in your own exception handling


`
class Program
    {
        static string StringToEncrypt { get; set; }
        static string StringToEncryptKey { get; set; }
        static string StringToDecrypt { get; set; }
        static string StringToDecryptKey { get; set; }  
   
        static void Main()
        {
            GetEncryptedValue();
            GetDecryptedValue();
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit");
            Console.Read();
          
        }

        static void GetEncryptedValue()
        {
            Console.WriteLine("Enter the string that you want to encrypt: ");
            StringToEncrypt = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Enter the key for the string that you want to encrypt: ");
            StringToEncryptKey = Console.ReadLine();

            Console.WriteLine("");

            var encryptedString = StringToEncrypt.Encrypt(StringToEncryptKey);
            Console.WriteLine($"Encrypted String is {encryptedString}");

            Console.WriteLine("");
        }
        static void GetDecryptedValue()
        {
            Console.WriteLine("Enter the string that you want to decrypt: ");
            StringToDecrypt = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Enter the key for the string that you want to decrypt: ");
            StringToDecryptKey = Console.ReadLine();

            Console.WriteLine("");

            var decryptedString = StringToDecrypt.Decrypt(StringToDecryptKey);
            Console.WriteLine($"Decrypted String is {decryptedString}");
            Console.WriteLine("-------------------------------------------------------------");
        }
    
`