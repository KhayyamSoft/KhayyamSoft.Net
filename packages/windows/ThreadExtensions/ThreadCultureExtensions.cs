using System.Globalization;
using System.Threading;

namespace KhayyamApps.Windows.ThreadExtensions
{
	public static class ThreadCultureExtensions
	{
		/// <summary>
		/// Set Thread CurrentCulture & CurrentUICulture
		/// </summary>
		public static void SetThreadCulture(this Thread thread, CultureInfo cultureInfo)
		{
			thread.CurrentCulture = cultureInfo;
			thread.CurrentUICulture = cultureInfo;
		}

		/// <summary>
		/// Set Thread CurrentCulture & CurrentUICulture To Invariant Culture (new CultureInfo(string.Empty))
		/// </summary>
		public static void SetThreadCulture(this Thread thread) => SetThreadCulture(thread, new CultureInfo(string.Empty));
	}
}
