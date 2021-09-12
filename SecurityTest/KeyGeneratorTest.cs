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

        [TestMethod]
        public void TestZeroKeyGenerator()
        {
            var key1 = KeyGenerator.GenerateKey(0).Length == 0;
            var key2 = KeyGenerator.GenerateKey(-1).Length == 0;
            Assert.IsTrue(key1 & key2);
        }

        [TestMethod]
        public void TestKeyGenerator()
        {
            var key = KeyGenerator.GenerateKey(256);
            Assert.IsTrue(key.Length == 256);
        }


    }
}
