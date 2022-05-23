using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Converts String To Arrow Cursor If String Is Null Or WhiteSpace Otherwise Returns Hand Cursor
	/// </summary>
	[ValueConversion(typeof(string), typeof(Cursor))]
	public class String2CursorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> string.IsNullOrWhiteSpace((string)value) ? Cursors.Arrow : Cursors.Hand;

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> (Cursor)value == Cursors.Arrow ? true.ToString() : false.ToString();
	}
}
