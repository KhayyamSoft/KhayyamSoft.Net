using System;
using KhayyamApps.Windows.ObjectExtensions;
using System.Windows;

namespace KhayyamApps.Windows
{
	/// <summary>
	/// Wrapper For Basic Searching Features On Both UI And Backend  
	/// </summary>
	/// <typeparam name="TEntity">Collection Items Entity Type</typeparam>
	public class SearchHandler<TEntity> where TEntity : class
	{
		/// <summary></summary>
		/// <param name="notFoundElement">UIElement Responsible For Showing User Search Found Anything Or Not</param>
		public SearchHandler(object collection, UIElement notFoundElement = null)
		{
			Collection = collection;
			NotFoundElement = notFoundElement ?? NotFoundElement;
		}

		private object Collection { get; set; }

		/// <summary>
		/// UIElement Responsible For Showing User Search Found Anything Or Not
		/// </summary>
		public UIElement NotFoundElement { get; set; }

		/// <summary>
		/// Function Which Gets TEntity Object And Says Should It Be In Search Result Or Not
		/// </summary>
		public Predicate<TEntity> FilterFuction { get; set; }

		/// <summary>
		/// Filter Collection Default View With Internal Filter Function.
		/// Also Show/Hides NotFoundElement If Exists Based On Search Result.
		/// </summary>
		/// <returns>Whether Search Founds Anything Or Not</returns>
		public bool Search()
		{
			var succeed = Collection.SetFilterOnCollectionView(FilterFuction);
			if (NotFoundElement != null)
			{
				NotFoundElement.Visibility = succeed ? Visibility.Collapsed : Visibility.Visible;
			}
			return succeed;
		}
	}
}
