using System.Windows.Controls;

namespace KhayyamApps.Windows.ObjectExtensions
{
	/// <summary>
	/// Useful Methods To Obtain Data From Windows Control Objects
	/// </summary>
	public static class ControlObjectDataExtensions
	{
		/// <summary>
		/// Obtain Data Context Of Control Object
		/// </summary>
		/// <returns>Data Context Object Or Null</returns>
		public static object ParseControlDataContext(this object sender)
			=> (sender as Control)?.DataContext ?? null;

		/// <summary>
		/// Obtain Data Context Of Control Object And Casts It To T
		/// </summary>
		/// <returns>Data Object Of Type T</returns>
		public static T ParseEntityFromControlDataContext<T>(this object sender)
			=> (T)sender.ParseControlDataContext();
	}
}
