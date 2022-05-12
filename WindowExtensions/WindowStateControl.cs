using System.Windows;

namespace AS.Windows.WindowExtensions
{
	public static class WindowStateControl
	{
		/// <summary>
		/// Change Window State Between Normal And Maximized
		/// </summary>
		public static void SwitchWindowState(this Window window)
			=> window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

		public static void Minimize(this Window window) => window.WindowState = WindowState.Minimized;

		public static void Maximize(this Window window) => window.WindowState = WindowState.Maximized;

		/// <summary>
		/// Make Windows State Normal
		/// </summary>
		public static void Normalize(this Window window) => window.WindowState = WindowState.Normal;
	}
}
