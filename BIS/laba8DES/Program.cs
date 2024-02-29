using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;

internal class Program
{
    class DESSample
    {
        public static void EncryptTextToFile(string text, string path, byte[] key, byte[] iv)
        {
            try
            {
                using (FileStream fStream = File.Open(path, FileMode.Create))
                using (TripleDES tripledes = TripleDES.Create())
                using (ICryptoTransform encryptor = tripledes.CreateEncryptor(key, iv))
                using (var cStream = new CryptoStream(fStream, encryptor, CryptoStreamMode.Write))
                {
                    byte[] toEncrypt = Encoding.UTF8.GetBytes(text);
                    cStream.Write(toEncrypt, 0, toEncrypt.Length);
                }
                using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    string text1 = reader.ReadToEnd();
                    Console.WriteLine("Encrypted text: " + text1);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }

        public static string DecryptTextFromFile(string path, byte[] key, byte[] iv)
        {
            try
            {
                using (FileStream fStream = File.OpenRead(path))
                using (TripleDES tripledes = TripleDES.Create())
                using (ICryptoTransform decryptor = tripledes.CreateDecryptor(key, iv))
                using (var cStream = new CryptoStream(fStream, decryptor, CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cStream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }

        static void Main()
        {
            try
            {
                byte[] key;
                byte[] iv;

                using (TripleDES tripledes = TripleDES.Create())
                {
                    key = tripledes.Key;
                    iv = tripledes.IV;
                }

                string original = "Lobanov Vladimir";

                string filename = "CText.txt";
                Console.WriteLine("Original text: {0}", original);
                EncryptTextToFile(original, filename, key, iv);

                string decrypted = DecryptTextFromFile(filename, key, iv);
                Console.WriteLine($"Decrypted text: {decrypted}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            byte[] hashValue = new byte[128];

            using (SHA1 mysha256 = SHA1.Create())
            {
                hashValue = mysha256.ComputeHash(File.ReadAllBytes("sha.txt"));
                File.WriteAllBytes("hash.txt", hashValue);
            }
            StreamReader sr = new StreamReader("hash.txt");
            string line = sr.ReadLine();
            while(line != null)
            {
                Console.WriteLine("Hash file:" + line);
                line = sr.ReadLine();
            }
            sr.Close();
            Console.ReadLine();

        }
    };

}