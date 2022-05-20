using System;
using System.Globalization;

namespace KhayyamApps.DateAndTime
{
	public static class PersianDate
	{
		private static PersianCalendar PersianCalendar => new PersianCalendar();

		public static string[] PersianMonthNames =>
			new[]
			{
				"فروردین", "اردیبهشت", "خرداد",
				"تیر", "مرداد", "شهریور",
				"مهر", "آبان", "آذر",
				"دی", "بهمن", "اسفند"
			};

		/// <summary>
		/// Return Name Of Month In Persian (Convert Month Number To Month Name)
		/// </summary>
		/// <param name="month">Number Of Month (1-12)</param>
		/// <returns>A String Representing Name Of Month In Persian</returns>
		public static string GetMonthName(int month)
		{
			if (month >= 1 && month <= 12) return PersianMonthNames[month - 1];
			else throw new ArgumentOutOfRangeException(nameof(month), month, "Month Number Must Be In Range Of [1-12]");
		}

		/// <summary>
		/// Safe Version (Not Throwing Exception) Of GetMonthName(int month)
		/// </summary>
		/// <param name="month">Number Of Month (1-12)</param>
		/// <returns>A String Representing Name Of Month In Persian. Returns "" If Any Exception Occur</returns>
		public static string SafeGetMonthName(int month)
		{
			try
			{
				return GetMonthName(month);
			}
			catch
			{
				return string.Empty;
			}
		}

		public static int GetPersianYear(this DateTime date) => PersianCalendar.GetYear(date);
		public static int GetPersianMonth(this DateTime date) => PersianCalendar.GetMonth(date);
		public static int GetPersianDay(this DateTime date) => PersianCalendar.GetDayOfMonth(date);

		/// <summary>
		/// Convert DateTime To Equal Date In Persian Calendar And Returns It In Integer Format
		/// </summary>
		/// <param name="date"></param>
		/// <returns>An Integer Representing Corresponding DateTime In Persian Calendar. e.g: 14001231 (Last Day Of Year 1400)</returns>
		public static int GetPersianDateInInt(this DateTime date)
			=> date.GetPersianYear() * 10000 +
				date.GetPersianMonth() * 100 +
				date.GetPersianDay();

		/// <summary>
		/// Convert DateTime To Equal Date In Persian Calendar And Returns It In String Format
		/// </summary>
		/// <param name="date"></param>
		/// <returns>A String Representing Corresponding DateTime In Persian Calendar. e.g: 1400/12/31 (Last Day Of Year 1400)</returns>
		public static string GetPersianDateInString(this DateTime date)
			=> $"{date.GetPersianYear():D4}/{date.GetPersianMonth():D2}/{date.GetPersianDay():D2}";
	}
}