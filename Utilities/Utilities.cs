using System;

namespace Security.Utilities
{
    /// <summary>
    /// Providing Helper Methods To Manipulate Arrays
    /// </summary>
    public static class Arrays
    {
        /// <summary>
        /// Shuffle an Array Based on Fisher–Yates Modern Algorithm
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T[] ShuffleArray<T>(T[] input)
        {
            if (input.Length <= 0) return input;

            var random = new Random((int)DateTime.Now.Ticks);
            var length = input.Length;
            for (var i = 0; i <= length - 2; i++)
            {
                var randomIndex = random.Next(i, length - 1);
                //Swap input[i] and input[randomIndex]
                var temp = input[i];
                input[i] = input[randomIndex];
                input[randomIndex] = temp;
            }

            return input;
        }

        /// <summary>
        /// Shuffle a String Based on Fisher–Yates Modern Algorithm
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ShuffleString(string input)
        {
            if (input.Length <= 0) return input;

            var chars = input.ToCharArray();
            ShuffleArray(chars);
            return new string(chars);
        }
    }
}
