﻿using System.Windows.Input;
using System.Windows;

namespace KhayyamApps.Windows.WindowExtensions
{
	public static class WindowInputExtensions
	{
		/// <summary>
		/// Make Windows Moving With Mouse Drag Until Left Button Is Released (Use On Mouse Down Event Handler)
		/// </summary>
		/// <param name="restrictMaximizeDrag">Set True If You Dont Want Maximized Window Being Dragged! Default Is True.</param>
		public static void DragWindowWithMouse(this Window window, MouseButtonEventArgs e, bool restrictMaximizeDrag = true)
		{
			if (restrictMaximizeDrag && window.WindowState != WindowState.Normal) return;
			while (e.LeftButton == MouseButtonState.Pressed) window.DragMove();
		}

		/// <summary>
		/// Make Windows Moving With Mouse Drag Until Left Button Is Released.
		/// Caution: This Method Binds Itself to Window Mouse Down Event
		/// </summary>
		/// <param name="restrictMaximizeDrag">Set True If You Dont Want Maximized Window Being Dragged! Default Is True.</param>
		public static void MakeWindowDraggableWithMouse(this Window window, bool restrictMaximizeDrag = true)
		{
			window.MouseDown += (s, e) => DragWindowWithMouse(window, e, restrictMaximizeDrag);
		}
	}
}
