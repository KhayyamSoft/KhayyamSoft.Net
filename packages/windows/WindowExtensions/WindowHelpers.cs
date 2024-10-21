using System.Windows;

namespace KhayyamApps.Windows.WindowExtensions
{
	/// <summary>
	/// Ease Working With Window's
	/// </summary>
	public static class WindowHelpers
	{
		/// <summary>
		/// Creates New Instance Of Window Derived Class & Return It
		/// </summary>
		/// <typeparam name="TWin">Type Of Window Class</typeparam>
		/// <param name="args">Args To Construct New Window From It</param>
		/// <returns>New Instance Of TWin</returns>
		public static TWin BuildNewDialog<TWin>(params object?[]? args) where TWin : Window
		{
			var win = ActivatorHelpers.Build<TWin>(args);
			return win;
		}

		/// <summary>
		/// Creates New Instance Of Window Derived Class (With Owner) & Return It
		/// </summary>
		/// <typeparam name="TWin">Type Of Window Class</typeparam>
		/// <param name="owner">Owner Of New Window</param>
		/// <param name="args">Args To Construct New Window From It</param>
		/// <returns>New Instance Of TWin</returns>
		public static TWin BuildNewDialog<TWin>(this Window owner, params object?[]? args) where TWin : Window
		{
			var win = BuildNewDialog<TWin>(args);
			win.Owner = owner;
			return win;
		}
	}
}
