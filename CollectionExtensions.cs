using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KhayyamApps.Windows
{
	public static class CollectionExtensions
	{
		public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
		{ foreach (var i in items) collection.Add(i); }
	}
}
