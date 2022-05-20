using System;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;

namespace Security.BC
{
	public static class AES
	{
		private static Encoding DefaultEncoding => Encoding.UTF8;
		private static IBlockCipher DefaultBlockCipher => new AesEngine();

		/// <summary>
		/// Encrypt Text With Specified Key And AES Engine
		/// </summary>
		/// <param name="plain">Raw Text</param>
		/// <param name="key">Key For Encryption</param>
		/// <returns>Base64 Encrypted String</returns>
		public static string Encrypt(string plain, ReadOnlySpan<char> key)
		{
			Span<byte> keyByte = DataHelper.CharSpanToByteSpan(key, DefaultEncoding);
			//SAFETY
			key = Span<char>.Empty;
			var result = BCBase.Encrypt(DefaultEncoding.GetBytes(plain), keyByte, DefaultBlockCipher);
			//SAFETY
			keyByte = Span<byte>.Empty;
			//SAFETY
			DefaultBlockCipher.Reset();
			return Convert.ToBase64String(result);
		}

		/// <summary>
		/// Decrypt Text With Specified Key And AES Engine
		/// </summary>
		/// <param name="cipher">Encrypted Text</param>
		/// <param name="key">Key For Decryption</param>
		/// <returns>UTF-8 Decrypted String</returns>
		public static string Decrypt(string cipher, ReadOnlySpan<char> key)
		{
			Span<byte> keyByte = DataHelper.CharSpanToByteSpan(key, DefaultEncoding);
			//SAFETY
			key = Span<char>.Empty;
			var result = BCBase.Decrypt(cipher, keyByte, DefaultBlockCipher);
			//SAFETY
			keyByte = Span<byte>.Empty;
			var final = DefaultEncoding.GetString(result);
			//SAFETY
			result = Array.Empty<byte>();
			return final;
		}
	}
}
