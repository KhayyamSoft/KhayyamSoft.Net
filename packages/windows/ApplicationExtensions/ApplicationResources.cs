using System;
using System.Linq;
using System.Windows;

namespace KhayyamApps.Windows.ApplicationExtensions
{
	public static class ApplicationResources
	{
		/// <summary>
		/// Load Resource Dictionary Object From Application Components
		/// </summary>
		/// <param name="dicUri">Resource URI</param>
		/// <returns></returns>
		public static ResourceDictionary LoadResourceDictionary(Uri dicUri)
			=> (ResourceDictionary)Application.LoadComponent(dicUri);

		/// <summary>
		/// Remove Items In Application.Resources.MergedDictionaries From Provided Index To Last 
		/// </summary>
		public static void RemoveMergedDictionariesItems(this Application app, int startIndex)
		{
			for(int i = app.Resources.MergedDictionaries.Count - 1; i >= startIndex; i--)
				app.Resources.MergedDictionaries.RemoveAt(i);
		}

		/// <summary>
		/// Add Provided Resource Dictionaries To Application MergedDictionaries
		/// </summary>
		public static void AddToMergedDictionaries(this Application app, params ResourceDictionary[] dics)
			=> app.Resources.MergedDictionaries.AddRange(dics);

		/// <summary>
		/// Remove Items In Application.Resources.MergedDictionaries From Provided Index To Last 
		/// And Add Uri Corresponding Resource Dictionaries Instead Of It 
		/// </summary>
		public static void ChangeTheme(this Application app, int startIndex, params Uri[] dicUris)
		{
			app.RemoveMergedDictionariesItems(startIndex);
			var dics = dicUris.Select(uri => LoadResourceDictionary(uri));
			app.AddToMergedDictionaries(dics.ToArray());
		}
	}
}
