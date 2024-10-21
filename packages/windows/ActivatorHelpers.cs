using System;

namespace KhayyamApps.Windows
{
	/// <summary>
	/// Makes Using Of Activator (Object Creator) Easier
	/// </summary>
	public static class ActivatorHelpers
	{
		/// <summary>
		/// Create An Instance Of T With Supplied Arguments And Return Casted Object Of It
		/// </summary>
		/// <typeparam name="T">Type To Create</typeparam>
		/// <param name="args">T Constructor Arguments</param>
		/// <returns>T Object</returns>
		public static T Build<T>(params object?[]? args)
		{
			var instance = Activator.CreateInstance(typeof(T), args);
			var casted = (T)instance;
			return casted;
		}
	}
}
