using System.Windows;

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
		/// Creates New Instance Of Window Derived Class, Shows It As Dialog And Return Result
		/// </summary>
		/// <typeparam name="TWin">Type Of Window Class</typeparam>
		/// <param name="args">Args To Construct New Window From It</param>
		/// <returns>Result Of ShowDialog</returns>
		public static bool? ShowNewDialog<TWin>(params object?[]? args) where TWin : Window
		{
			ShowNewDialog<TWin>(out bool? result, args);
			return result;
		}

		/// <summary>
		/// Creates New Instance Of Window Derived Class, Shows It As Dialog And Return Result
		/// </summary>
		/// <typeparam name="TWin">Type Of Window Class</typeparam>
		/// <param name="owner">Owner Of New Dialog</param>
		/// <param name="args">Args To Construct New Window From It</param>
		/// <returns>Result Of ShowDialog</returns>
		public static bool? ShowNewDialog<TWin>(this Window owner, params object?[]? args) where TWin : Window
		{
			ShowNewDialog<TWin>(owner, out bool? result, args);
			return result;
		}

		/// <summary>
		/// Creates New Instance Of Window Derived Class & Shows It As Dialog
		/// </summary>
		/// <typeparam name="TWin">Type Of Window Class</typeparam>
		/// <param name="result">Result Of ShowDialog</param>
		/// <param name="args">Args To Construct New Window From It</param>
		/// <returns>New Instance Of Window Derived Class</returns>
		public static TWin ShowNewDialog<TWin>(out bool? result, params object?[]? args) where TWin : Window
		{
			var win = WindowHelpers.BuildNewDialog<TWin>(args);
			result = win.ShowDialog();
			return win;
		}

		/// <summary>
		/// Creates New Instance Of Window Derived Class & Shows It As Dialog
		/// </summary>
		/// <typeparam name="TWin">Type Of Window Class</typeparam>
		/// <param name="owner">Owner Of New Dialog. Null By Default.</param>
		/// <param name="result">Result Of ShowDialog</param>
		/// <param name="args">Args To Construct New Window From It</param>
		/// <returns>New Instance Of Window Derived Class</returns>
		public static TWin ShowNewDialog<TWin>(this Window owner, out bool? result, params object?[]? args) where TWin : Window
		{
			var win = WindowHelpers.BuildNewDialog<TWin>(owner, args);
			result = win.ShowDialog();
			return win;
		}
	}
}
