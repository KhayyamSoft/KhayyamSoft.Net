using System.Windows.Media;

namespace KhayyamApps.Windows.DataConverters
{
	/// <summary>
	/// Provides An Static Instance Of System.Windows.Media.ImageSourceConverter
	/// </summary>
	public static class StaticImageSourceConverter
	{
		public static ImageSourceConverter Default => new ImageSourceConverter();
	}
}
