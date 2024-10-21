using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KhayyamApps.Windows.WindowExtensions;
using KhayyamApps.Windows.UIElementExtensions;
using System.Collections.ObjectModel;

namespace KhayyamApps.Windows.WindowX
{
	/// <summary>
	/// Special Window That Can Be Set As Dialog, Moves To Next UI Element With 'Enter' Key,
	/// Can Be Dragged With Mouse and Can Be Closed With 'Enter' Key If Set As Dialog. 
	/// </summary>
	public class CustomWindow1 : Window
	{
		public bool IsDialog { get; set; } = false;

		/// <summary>
		/// Focus Will Not Move If These Elements Is KeyboardFocusedWithin
		/// </summary>
		public Collection<Control> EnterFocusMoveResterictedControls { get; set; } = new Collection<Control>();

		public CustomWindow1() : base()
		{
			this.MakeWindowDraggableWithMouse();
			PreviewKeyDown += Window_PreviewKeyDown;
		}

		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key != Key.Enter) return;
			if(EnterFocusMoveResterictedControls.Any(c => c.IsKeyboardFocusWithin)) { e.Handled = false; return; }
			(e.OriginalSource as UIElement)?.MoveUIElementFocusWithKeyboard(e, Key.Enter);
			e.Handled = true;
			if (IsDialog) this.SafeCloseDialog(true);
		}
	}
}
