using System.Windows;
using System;

namespace KhayyamApps.Windows.WindowExtensions
{
	public static class WindowAsDialogExtensions
	{
		/// <summary>
		/// Sets Dialog Result And Close It (Without Exception)
		/// </summary>
		/// <param name="window">Dialog To Close</param>
		/// <param name="dialogResult">Result To Set As Dialog Result</param>
		/// <returns></returns>
		public static bool SafeCloseDialog(this Window window, bool? dialogResult = null)
		{
			try { window.DialogResult = dialogResult; } catch { return false; }
			try { window.Close(); } catch { return false; }
			return true;
		}

		/// <summary>
		/// Creates New Instance Of Window Derived Class & Shows It As Dialog
		/// </summary>
		/// <typeparam name="TWin">Type Of Window Class</typeparam>
		/// <param name="result">Result Of ShowDialog</param>
		/// <returns>New Instance Of Window Derived Class</returns>
		public static TWin ShowNewDialog<TWin>(out bool? result, params object?[]? args) where TWin : Window
		{
			var instance = (TWin)Activator.CreateInstance(typeof(TWin), args);
			result = instance.ShowDialog();
			return instance;
		}
	}
}
