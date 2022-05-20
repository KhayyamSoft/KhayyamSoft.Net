using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using System;

namespace Security.BC
{
	public static class BCBase
	{
		/// <summary>
		/// Encrypt/Decrypt Bytes Sequence With A Specified Key And BouncyCastle Crypto Engine
		/// </summary>
		/// <param name="forEncrypt">Set true For Encrypt And false For Decrypt</param>
		/// <param name="input">Bytes Sequence To Encrypt/Decrypt</param>
		/// <param name="keyByte">Encrypt/Decrypt Key</param>
		/// <param name="blockCipher">Use One Engine From Org.BouncyCastle.Crypto.Engines</param>
		/// <returns></returns>
		private static byte[] EncryptOrDecrypt(bool forEncrypt, byte[] input,
			 ReadOnlySpan<byte> keyByte, IBlockCipher blockCipher)
		{
			var cipher = new PaddedBufferedBlockCipher(blockCipher);
			cipher.Init(forEncrypt, new KeyParameter(keyByte.ToArray()));
			var result = cipher.DoFinal(input);
			//SAFETY
			cipher = null;
			return result;
		}

		/// <summary>
		/// Encrypt Bytes With Specified Key And BouncyCastle Crypto Engine
		/// </summary>
		/// <param name="plain">Unencrypted Bytes</param>
		/// <param name="keyByte">Key For Encryption</param>
		/// <param name="blockCipher">Use One Engine From Org.BouncyCastle.Crypto.Engines</param>
		/// <returns>Encrypted Bytes</returns>
		public static byte[] Encrypt(byte[] plain, ReadOnlySpan<byte> keyByte, IBlockCipher blockCipher)
			=> EncryptOrDecrypt(true, plain, keyByte, blockCipher);

		/// <summary>
		/// Decrypt Base64 Encoded String With Specified Key And BouncyCastle Crypto Engine
		/// </summary>
		/// <param name="cipher">Base64 Encoded String</param>
		/// <param name="keyByte">Key For Decryption</param>
		/// <param name="blockCipher">Use One Engine From Org.BouncyCastle.Crypto.Engines</param>
		/// <returns>Decrypted Bytes</returns>
		public static byte[] Decrypt(string cipher, ReadOnlySpan<byte> keyByte, IBlockCipher blockCipher)
			=> EncryptOrDecrypt(false, Convert.FromBase64String(cipher), keyByte, blockCipher);
	}
}
