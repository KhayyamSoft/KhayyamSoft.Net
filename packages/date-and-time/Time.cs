using System;

namespace KhayyamApps.DateAndTime
{
	public static class Time
	{
		/// <summary>
		/// Convert DateTime To Time In Integer Format
		/// </summary>
		/// <param name="date"></param>
		/// <returns>An Integer Representing Corresponding DateTime, Time. e.g: 1731 (17:31)</returns>
		public static int GetTimeInInt(this DateTime date)
			=> date.Hour * 100 + date.Minute;
	}
}
