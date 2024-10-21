using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Converts Ture To Hand Cursor And False To Arrow Cursor
	/// </summary>
	public sealed class Bool2CursorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
			(bool)value ? Cursors.Hand : Cursors.Arrow;

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
			throw new NotImplementedException();
	}
}
