using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Converts True To Visibility.Visible And False To Visibility.Collapsed
	/// And Vice Versa.
	/// If Convert Fails Returns Visibility.Collapsed
	/// </summary>
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class Bool2VisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//If Convert Fails Return Visibility.Collapsed
			if (!bool.TryParse(value.ToString(), out bool result))
			{
				return Visibility.Collapsed;
			}
			return result == true ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!int.TryParse(value.ToString(), out int result))
			{
				return Visibility.Collapsed;
			}
			return result <= 0 ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
