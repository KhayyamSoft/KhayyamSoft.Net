using System;
using System.Security.Cryptography;
using System.Text;




namespace Security.Hash
{
    /// <summary>
    /// Providing Common Hash Functions
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Takes a string as input and returns it hashed by SHA256 algorithm as a string
        /// </summary>
        /// <param name="input">Must Be Not Null</param>
        /// <returns>SHA256Hash</returns>
        public static string GetSHA256Hash(string input) 
        {
            using (var sha256 = SHA256.Create())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);
                var byteHash = sha256.ComputeHash(byteValue);

                return Convert.ToBase64String(byteHash);
            }
        }

        /// <summary>
        /// Takes a string as input and returns it hashed by SHA512 algorithm as a string
        /// </summary>
        /// <param name="input">Must Be Not Null</param>
        /// <returns>SHA512Hash</returns>
        public static string GetSHA512Hash(string input) 
        {
            using (var sha512 = SHA512.Create())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);
                var byteHash = sha512.ComputeHash(byteValue);

                return Convert.ToBase64String(byteHash);
            }
        }

    }
}
