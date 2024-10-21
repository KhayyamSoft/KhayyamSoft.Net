using System;
using System.Windows.Input;

namespace KhayyamApps.Windows
{
	public static class ActionExtensions
	{
		/// <summary>
		/// Run Action If Specified Key Is Pressed
		/// </summary>
		/// <param name="key">Desired Key</param>
		public static void RunOnKeyPress(this Action action, KeyEventArgs e, Key key)
		{
			if (e.Key == key) { e.Handled = true; action(); }
		}

		/// <summary>
		/// Run Action If Conditions Is Met
		/// </summary>
		public static void RunOnCondition(this Action action, bool condition)
		{ 
			if (condition) action(); 
		}
	}
}
