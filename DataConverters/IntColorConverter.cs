using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Convert Int To SolidColorBrush And Vice Versa
	/// </summary>
	[ValueConversion(typeof(int), typeof(SolidColorBrush))]
	public class IntColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var bytes = BitConverter.GetBytes((int)value);
			return new SolidColorBrush(Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var mCol = ((SolidColorBrush)value).Color;
			var c = System.Drawing.Color.FromArgb(mCol.A, mCol.R, mCol.G, mCol.B);
			return c.ToArgb();
		}
	}
}
