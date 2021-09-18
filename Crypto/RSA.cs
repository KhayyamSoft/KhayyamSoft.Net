using System;
using System.Security.Cryptography;
using System.Text;

namespace Security.Crypto
{
    /// <summary>
    /// Providing methods to encrypt and decrypt data using Advanced Encryption Standard (RSA) / Rijndael 
    /// more details:
    ///  The following code uses the RSACryptoServiceProvider class
    ///  to encrypt a string into an array of bytes and then decrypt the bytes back into a string.
    /// </summary>
    public static class RSA
    {
        /// <summary>
        ///  Pass the data to ENCRYPT, the public key information 
        /// (using RSACryptoServiceProvider.ExportParameters(false),
        /// and a boolean flag specifying no OAEP padding.
        /// example for use this method:
        /// encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
        /// </summary>
        /// <param name="input">Data to encrypt</param>
        /// <param name="RSAKeyInfo">Key to encrypt. RSAKeyInfo is an byte Array</param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns>Encrypted byte array</returns>
        public static byte[] RSAEncrypt(string input, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            //Create a UnicodeEncoder to convert between byte array and string.
            var ByteConverter = new UnicodeEncoding();

            //Create byte arrays to hold original, encrypted data.
            var dataToEncrypt = ByteConverter.GetBytes(input);

            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (var RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(dataToEncrypt, DoOAEPPadding);
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

        /// <summary>
        /// Pass the data to DECRYPT, the private key information 
        /// (using RSACryptoServiceProvider.ExportParameters(true),
        /// and a boolean flag specifying no OAEP padding.
        /// example for use this method:
        /// decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
        /// </summary>
        /// <param name="input">Data to encrypt</param>
        /// <param name="RSAKeyInfo">Key to decrypt. RSAKeyInfo is an byte Array</param>
        /// <param name="DoOAEPPadding">Decrypt byte array</param>
        public static byte[] RSADecrypt(string input, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            //Create a UnicodeEncoder to convert between byte array and string.
            var ByteConverter = new UnicodeEncoding();

            //Create byte arrays to hold original, decrypt data.
            var dataToDecrypt = ByteConverter.GetBytes(input);

            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (var RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(dataToDecrypt, DoOAEPPadding);
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
}
