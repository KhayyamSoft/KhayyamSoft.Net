using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security.Hash
{
    /// <summary>
    /// This class has a hash function
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Takes a string as input and returns it hashed by SHA256 algorithm as a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSHA256Hash(string input) 
        {
            using (var sha256 = SHA256.Create())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);
                var byteHash = sha256.ComputeHash(byteValue);

                return Convert.ToBase64String(byteHash);
            }
        }
    }
}
