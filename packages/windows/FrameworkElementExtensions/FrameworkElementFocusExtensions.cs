using System.Windows;
using System.Windows.Input;

namespace KhayyamApps.Windows.FrameworkElementExtensions
{
	public static class FrameworkElementFocusExtensions
	{
		/// <summary>
		/// Navigation Directions
		/// </summary>
		public enum NavDir { First, Last, Next, Previous, Up, Down, Left, Right }

		/// <summary>
		/// Makes New TraversalRequest For The Direction Specified
		/// </summary>
		/// <returns>New TraversalRequest</returns>
		public static TraversalRequest NewTraversalRequest(NavDir navDir)
		{
			var dir = (FocusNavigationDirection)System.Enum.Parse(typeof(FocusNavigationDirection), navDir.ToString());
			return new TraversalRequest(dir);
		}

		/// <summary>
		/// Move FrameworkElement Focus Toward Specified Direction
		/// </summary>
		/// <returns>True If Focus Moves Successfully; Otherwise False</returns>
		public static bool MoveFocus(this FrameworkElement element, NavDir dir) =>
			element.MoveFocus(NewTraversalRequest(dir));

		public static bool MoveFocusToFirst(this FrameworkElement element) => MoveFocus(element, NavDir.First);
		public static bool MoveFocusToLast(this FrameworkElement element) => MoveFocus(element, NavDir.Last);
		public static bool MoveFocusToNext(this FrameworkElement element) => MoveFocus(element, NavDir.Next);
		public static bool MoveFocusToPrevious(this FrameworkElement element) => MoveFocus(element, NavDir.Previous);
	}
}
