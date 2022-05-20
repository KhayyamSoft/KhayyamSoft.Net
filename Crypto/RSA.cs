using System.Security.Cryptography;
using System.Text;

namespace KhayyamApps.Security.Crypto
{
	/// <summary>
	/// Providing methods to encrypt and decrypt data using Advanced Encryption Standard (RSA) / Rijndael. <br/>
	///  The following code uses the RSACryptoServiceProvider class
	///  to encrypt a string into an array of bytes and then decrypt the bytes back into a string.
	/// </summary>
	public static class RSA
	{
		/// <summary>
		///  Pass the data to ENCRYPT and the public key information 
		/// (using RSACryptoServiceProvider.ExportParameters(false) <br/>
		/// example for use this method:
		/// encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false));
		/// you must creat an instance of RSACryptoServiceProvider for use this method.
		/// </summary>
		/// <param name="input">Data to encrypt</param>
		/// <param name="rsaKeyInfo">RSAKeyInfo (Encrypt key)</param>
		/// <param name="doOAEPPadding"></param>
		/// <returns>Encrypted byte array</returns>
		public static byte[] RSAEncrypt(string input, RSAParameters rsaKeyInfo, bool doOAEPPadding = false)
		{
			//Create a UnicodeEncoder to convert between byte array and string.
			var byteConverter = new UnicodeEncoding();

			//Create byte arrays to hold original, encrypted data.
			var dataToEncrypt = byteConverter.GetBytes(input);

			byte[] encryptedData;
			//Create a new instance of RSACryptoServiceProvider.
			using (var rsa = new RSACryptoServiceProvider())
			{
				//Import the RSA Key information. This only needs
				//toinclude the public key information.
				rsa.ImportParameters(rsaKeyInfo);

				//Encrypt the passed byte array and specify OAEP padding.  
				//OAEP padding is only available on Microsoft Windows XP or
				//later.  
				encryptedData = rsa.Encrypt(dataToEncrypt, doOAEPPadding);
			}
			return encryptedData;
		}

		/// <summary>
		/// Pass the data to DECRYPT and the private key information 
		/// (using RSACryptoServiceProvider.ExportParameters(true)
		/// example for use this method:
		/// decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true));
		/// </summary>
		/// <param name="input">Data to encrypt</param>
		/// <param name="rsaKeyInfo">RSAKeyInfo (Decrypt key)</param>
		/// <param name="doOAEPPadding">Decrypt byte array</param>
		public static byte[] RSADecrypt(string input, RSAParameters rsaKeyInfo, bool doOAEPPadding = false)
		{
			//Create a UnicodeEncoder to convert between byte array and string.
			var byteConverter = new UnicodeEncoding();

			//Create byte arrays to hold original, decrypt data.
			var dataToDecrypt = byteConverter.GetBytes(input);

			byte[] decryptedData;
			//Create a new instance of RSACryptoServiceProvider.
			using (var rsa = new RSACryptoServiceProvider())
			{
				//Import the RSA Key information. This needs
				//to include the private key information.
				rsa.ImportParameters(rsaKeyInfo);

				//Decrypt the passed byte array and specify OAEP padding.  
				//OAEP padding is only available on Microsoft Windows XP or
				//later.  
				decryptedData = rsa.Decrypt(dataToDecrypt, doOAEPPadding);
			}
			return decryptedData;
		}

	}
}
