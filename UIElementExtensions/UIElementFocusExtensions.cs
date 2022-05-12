using System.Windows.Input;
using System.Windows;

namespace AS.Windows.UIElementExtensions
{
	public static class UIElementFocusExtensions
	{
		/// <summary>
		/// Move Focus From UIElement To Next Or Any Other Navigation 
		/// </summary>
		/// <param name="direction">Direction To Move Focus. Default Is Next.</param>
		/// <returns>
		/// true if focus moved otherwise false
		/// </returns>
		public static bool MoveUIElementFocus(this UIElement element, FocusNavigationDirection direction = FocusNavigationDirection.Next)
			=> element.MoveFocus(new TraversalRequest(direction));

		/// <summary>
		/// Move Focus From UIElement To Next Or Any Other Navigation If Target Key Is Pressed
		/// </summary>
		/// <param name="e">KeyEventArgs</param>
		/// <param name="key">Target Key</param>
		/// <param name="direction">Direction To Move Focus. Default Is Next.</param>
		/// <returns>true if Target Key Is Pressed And Focus Moved Successfully</returns>
		public static bool MoveUIElementFocusWithKeyboard(this UIElement element, KeyEventArgs e, Key key,
			FocusNavigationDirection direction = FocusNavigationDirection.Next)
			=> e.Key == key && element.MoveUIElementFocus(direction);
	}
}
