using System;
using System.Text;

namespace Security.BC
{
	internal static class DataHelper
	{
		internal static Span<byte> CharSpanToByteSpan(ReadOnlySpan<char> key, Encoding encoding)
		{
			var byteCount = encoding.GetByteCount(key);
			Span<byte> keyByte = new Span<byte>(new byte[byteCount]);
			encoding.GetBytes(key, keyByte);
			return keyByte;
		}
	}
}
