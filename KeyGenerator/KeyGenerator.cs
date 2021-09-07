using System;
using System.Text;
using Security.Utilities;

namespace Security.KeyGenerator
{
    /// <summary>
    /// Providing Methods to Generate Passwords and Keys
    /// </summary>
    public static class KeyGenerator
    {
        private const string UpperAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerAlpha = "abcdefghijklmnopqrstuvwxyz";
        private const string Numbers = "1234567890";
        private const string Symbols = "!@#$%^&*-_=+-";
        private const string AmbiguousSymbols = @"{}[]()/\'""`~,;:.<>";
        private static readonly string[] Parts = { UpperAlpha, LowerAlpha, Numbers, Symbols, AmbiguousSymbols };

        /// <summary>
        /// Generate Random Password
        /// </summary>
        /// <param name="length">Password Length (should be equal or greater than 8)</param>
        /// <param name="containAmbiguous">Wheter to include ambiguous characters ({}[]()/\'"`~,;:.&lt;&gt;) in password or not</param>
        /// <returns>Random Password</returns>
        public static string GeneratePassword(int length, bool containAmbiguous = true)
        {
            if (length <= 0) return string.Empty;

            var partsUpperBound = containAmbiguous ? Parts.Length - 1 : Parts.Length - 2;
            var partIndex = 0;
            var sb = new StringBuilder(length);
            var random = new Random((int)DateTime.Now.Ticks);
            //Add Random Character Until We Reach The Maximum Length Of Password
            for (var i = 0; i < length; i++)
            {
                //Select Part Based On Index
                var part = Parts[partIndex];
                //Calculate Part Upper Bound
                var partUpperBound = part.Length - 1;
                //Select Character Between the Start and the End of Part
                var randomChar = part[random.Next(0, partUpperBound)];

                sb.Append(randomChar);

                //Count Up Index To Use Chars From Next Parts
                partIndex++;
                //Reset Index
                if (partIndex >= partsUpperBound) partIndex = 0;
            }

            return Arrays.ShuffleString(sb.ToString());
        }
    }
}
