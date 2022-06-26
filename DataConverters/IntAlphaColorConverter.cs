using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Convert Int To SolidColorBrush And Vice Versa.
	/// Return #00000000 Brush Or 0 If Convert Fails
	/// </summary>
	[ValueConversion(typeof(int), typeof(SolidColorBrush))]
	public class IntAlphaColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//Return #00000000 If Convert Fails
			if (!int.TryParse(value.ToString(), out int result))
			{
				return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
			}
			var bytes = BitConverter.GetBytes(result);
			var brush = new SolidColorBrush(Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]));
			return brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//Return 0 If Convert Fails
			if (value.GetType() != typeof(SolidColorBrush))
			{
				return 0;
			}
			var brush = value as SolidColorBrush;
			var mediaColor = brush.Color;
			var color = System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
			var result = color.ToArgb();
			return result;
		}
	}
}
