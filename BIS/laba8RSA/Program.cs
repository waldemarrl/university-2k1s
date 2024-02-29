using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;

class RSAample
{

    static void Main()
    {
        try
        {
            //Create a UnicodeEncoder to convert between byte array and string.
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            //Create byte arrays to hold original, encrypted, and decrypted data.
            byte[] dataToEncrypt = ByteConverter.GetBytes("Maksim Himyak");
            byte[] encryptedData;
            byte[] decryptedData;

            //Create a new instance of RSACryptoServiceProvider to generate
            //public and private key data.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {

                //Pass the data to ENCRYPT, the public key information 
                //(using RSACryptoServiceProvider.ExportParameters(false),
                //and a boolean flag specifying no OAEP padding.
                encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                //Pass the data to DECRYPT, the private key information 
                //(using RSACryptoServiceProvider.ExportParameters(true),
                //and a boolean flag specifying no OAEP padding.
                decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                using (var writter = new StreamWriter("file.txt"))
                {
                    writter.WriteLine("RSA");
                    writter.WriteLine("encrypted text: {0}", ByteConverter.GetString(encryptedData));
                    writter.WriteLine("Decrypted text: {0}", ByteConverter.GetString(decryptedData));
                    writter.WriteLine(RSA.ExportParameters(false));
                }

                Console.WriteLine("encrypted text: {0}", ByteConverter.GetString(encryptedData));
                Console.WriteLine("Decrypted text: {0}", ByteConverter.GetString(decryptedData));
            }
        }
        catch (ArgumentNullException)
        {
            //Catch this exception in case the encryption did
            //not succeed.
            Console.WriteLine("Encryption failed.");
        }

        byte[] hashValue = new byte[128];

        using (SHA256 mysha256 = SHA256.Create())
        {
            hashValue = mysha256.ComputeHash(File.ReadAllBytes("sha.txt"));
            File.WriteAllBytes("hash.txt", hashValue);
        }
        StreamReader sr = new StreamReader("hash.txt");
        string line = sr.ReadLine();
        while (line != null)
        {
            Console.WriteLine("Hash file:" + line);
            line = sr.ReadLine();
        }
        sr.Close();
    }

    public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
    {
        try
        {
            byte[] encryptedData;
            //Create a new instance of RSACryptoServiceProvider.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {

                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            return encryptedData;
        }
        //Catch and display a CryptographicException  
        //to the console.
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);

            return null;
        }

    }

    public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
    {
        try
        {
            byte[] decryptedData;
            //Create a new instance of RSACryptoServiceProvider.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                //Import the RSA Key information. This needs
                //to include the private key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Decrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            return decryptedData;
        }
        //Catch and display a CryptographicException  
        //to the console.
        catch (CryptographicException e)
        {
            Console.WriteLine(e.ToString());

            return null;
        }
    }
}