using System;

namespace AS.DateAndTime
{
	public static class UnixTime
	{
		/// <summary>
		/// Get Now Local Time In Unix Time Stamp
		/// </summary>
		/// <returns>Number Of Seconds Elapsed Since 1970/1/1 00:00 To Now</returns>
		public static long GetUnixTimeStamp() 
			=> DateTimeOffset.Now.ToUnixTimeSeconds();

		/// <summary>
		/// Convert Unix Time Stamp (Number Of Seconds Elapsed Since 1970/1/1 00:00) To Local DateTime
		/// </summary>
		/// <param name="timestamp">Unix Time Stamp</param>
		/// <returns>System.DateTime Represting Local Time</returns>
		public static DateTime UnixTimestampToLocalDateTime(double timestamp)
			=> DateTime.UnixEpoch.AddSeconds(timestamp).ToLocalTime();
	}
}
