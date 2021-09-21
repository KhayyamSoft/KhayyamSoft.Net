using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSA = Security.Crypto.RSA;

namespace SecurityTest
{
    [TestClass]
    public class RSATest
    {
        [TestMethod]
        public void EncryptDecryptTest()
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                const string testString = "Hello World!";
                var byteConverter = new UnicodeEncoding();
                var key = rsa.ExportParameters(true);
                var encryptedBytes = RSA.RSAEncrypt(testString, rsa.ExportParameters(false));
                var encryptedString = byteConverter.GetString(encryptedBytes);
                var decryptedBytes = RSA.RSADecrypt(encryptedString, rsa.ExportParameters(true));
                var decryptedString = byteConverter.GetString(decryptedBytes);
                Assert.IsTrue(decryptedString == testString);
            }
        }
    }
}
