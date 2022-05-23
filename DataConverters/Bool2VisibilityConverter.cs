using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Converts True To Visibility.Visible And False To Visibility.Collapsed
	/// And Vice Versa
	/// </summary>
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class Bool2VisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> (bool)value == true ? Visibility.Visible : Visibility.Collapsed;

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> (int)value <= 0 ? Visibility.Visible : Visibility.Collapsed;
	}
}
