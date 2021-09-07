using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security.KeyGenerator;

namespace SecurityTest
{
    [TestClass]
    public class KeyGeneratorTest
    {
        [TestMethod]
        public void TestZeroOrNegativeLength()
        {
            var test1 = KeyGenerator.GeneratePassword(-1) == string.Empty;
            var test2 = KeyGenerator.GeneratePassword(0) == string.Empty;
            Assert.IsTrue(test1 & test2 == test1);
        }

        [TestMethod]
        public void TestOneCharacterPassword()
        {
            var password = KeyGenerator.GeneratePassword(1);
            Assert.IsTrue(char.IsUpper(password[0]));
        }

        [TestMethod]
        public void TestRegularPassword()
        {
            var password = KeyGenerator.GeneratePassword(16);
            Console.WriteLine(password);
            Assert.IsTrue(password.Length == 16);
        }
    }
}
