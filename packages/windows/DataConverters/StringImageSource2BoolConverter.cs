using System;
using System.Globalization;
using System.Windows.Data;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Converts String Of ImageSource To Bool.
	/// Returns True If String Is Not Null Or WhiteSpace 
	/// And Its Not A System.Windows.Media.DrawingImage
	/// Otherwise Returns False.
	/// Caution: ConvertBack Is Not Implemented
	/// </summary>
	public sealed class StringImageSource2BoolConverter : IValueConverter
	{
		private const string DrawingImageFullName = nameof(System.Windows.Media.DrawingImage);

		public static bool HasImage(string src)
			=> !string.IsNullOrWhiteSpace(src) && src != DrawingImageFullName;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> HasImage((string)value);

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}
}
