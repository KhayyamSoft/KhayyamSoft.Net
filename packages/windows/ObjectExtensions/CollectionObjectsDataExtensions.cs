using System;
using System.Windows.Data;

namespace KhayyamApps.Windows.ObjectExtensions
{
	/// <summary>
	/// Useful Methods To Obtain Data From Collection Objects Like IEnumerables
	/// </summary>
	public static class CollectionObjectsDataExtensions
	{
		/// <summary>
		/// Get Default View Of Collection/IEnumerable (e.g. List Items Source) 
		/// </summary>
		/// <returns>Default View As A CollectionView</returns>
		public static CollectionView GetDefaultView(this object collection) =>
			(CollectionView)CollectionViewSource.GetDefaultView(collection);

		/// <summary>
		/// Sets Filter On A Collection View
		/// </summary>
		/// <typeparam name="T">Type Of Collection Items</typeparam>
		/// <param name="predicate">Filter Function</param>
		/// <returns>Whether View Is Empty Or Not After Filtering</returns>
		public static bool SetFilterOnCollectionView<T>(this CollectionView collection, Predicate<T> predicate) where T : class
		{
			collection.Filter = o => predicate(o as T);
			return !collection.IsEmpty;
		}

		/// <summary>
		/// Gets Default View Of A Collection Object And Sets Filter On It
		/// </summary>
		/// <typeparam name="T">Type Of Collection Items</typeparam>
		/// <param name="predicate">Filter Function</param>
		/// <returns>Whether View Is Empty Or Not After Filtering</returns>
		public static bool SetFilterOnCollectionView<T>(this object collection, Predicate<T> predicate) where T : class
			=> collection.GetDefaultView().SetFilterOnCollectionView(predicate);
	}
}
