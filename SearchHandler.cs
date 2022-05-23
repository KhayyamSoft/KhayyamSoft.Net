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
		public SearchHandler(object collection)
		{
			Collection = collection;
		}

		/// <summary>UIElement Responsible For Showing User Search Found Anything Or Not</summary>
		/// <param name="notFoundElement"></param>
		public SearchHandler(object collection, UIElement notFoundElement) : this(collection)
		{
			NotFoundElement = notFoundElement;
		}

		private object Collection { get; set; }
		private UIElement NotFoundElement { get; set; }

		/// <summary>
		/// Function Which Gets TEntity Object And Says Should It Be In Search Result Or Not
		/// </summary>
		public Predicate<TEntity> FilterFuction { get; set; }

		/// <summary>
		/// Filter Collection Default View With Internal Filter Function.
		/// Also Show/Hides NotFoundElement If Exists Based On Search Result.
		/// </summary>
		public void Search()
		{
			var result = Collection.SetFilterOnCollectionView(FilterFuction);
			if(NotFoundElement != null)
				NotFoundElement.Visibility = result == true ? Visibility.Collapsed : Visibility.Visible;
		}
	}
}
