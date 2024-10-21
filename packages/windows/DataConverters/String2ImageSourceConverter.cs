using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Convert String To ImageSource
	/// </summary>
	[ValueConversion(typeof(string), typeof(ImageSource))]
	public class String2ImageSourceConverter : IValueConverter
	{
		/// <summary>
		/// Convert String To ImageSource
		/// </summary>
		/// <param name="url">Image Url</param>
		/// <returns>ImageSource Or Null If String Is Null Or WhiteSpace Or If Image File Not Exists</returns>
		public static object Convert(string url)
		{
			Uri.TryCreate(url, UriKind.Absolute, out Uri uri);
			var path = uri?.LocalPath;
			if (string.IsNullOrWhiteSpace(path) || !System.IO.File.Exists(path)) return null;
			else return StaticImageSourceConverter.Default.ConvertFromString(url);
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> Convert((string)value);

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
	}
}
