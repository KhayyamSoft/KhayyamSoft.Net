using System.IO;
using System.Security.Cryptography;

namespace Security.Crypto
{
    /// <summary>
    /// Providing methods to encrypt and decrypt data using Advanced Encryption Standard (AES) / Rijndael 
    /// </summary>
    public static class AES
    {
        /// <summary>
        /// Encrypt an input string using provided key and iv with AES algorithm
        /// </summary>
        /// <param name="plainText">Data to encrypt</param>
        /// <param name="key">Key to encrypt</param>
        /// <param name="iv">Initialization Vector (IV)</param>
        /// <returns>Encrypted byte array</returns>
        public static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
        {
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                // Create an encryptor to perform the stream transform.
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption.
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            //Write all data to the stream.
                            streamWriter.Write(plainText);
                        }
                        encrypted = memoryStream.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Encrypt an input string using random key and iv with AES algorithm
        /// </summary>
        /// <param name="plainText">Data to encrypt</param>
        /// <param name="key">Encrypt key</param>
        /// <param name="iv">Encrypt initialization vector (IV)</param>
        /// <returns>Encrypted byte array</returns>
        public static byte[] Encrypt(string plainText, out byte[] key, out byte[] iv)
        {
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (var aes = Aes.Create())
            {
                // Create an encryptor to perform the stream transform.
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption.
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            //Write all data to the stream.
                            streamWriter.Write(plainText);
                        }
                        encrypted = memoryStream.ToArray();
                    }
                }

                key = aes.Key;
                iv = aes.IV;
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Decrypt an encrypted byte array using provided key and iv with AES algorithm
        /// </summary>
        /// <param name="encryptedText">Byte array of encrypted text</param>
        /// <param name="key">Encrypt key</param>
        /// <param name="iv">Encrypt initialization vector (IV)</param>
        /// <returns>Decrypted string</returns>
        public static string Decrypt(byte[] encryptedText, byte[] key, byte[] iv)
        {
            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an Aes object
            // with the specified key and IV.
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (var memoryStream = new MemoryStream(encryptedText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
