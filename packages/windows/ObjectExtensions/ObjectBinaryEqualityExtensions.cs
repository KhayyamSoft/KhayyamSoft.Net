using System.Linq;

namespace KhayyamApps.Windows.ObjectExtensions
{
	/// <summary>
	/// Methods To Check For Objects Equality Using Binary Operators
	/// </summary>
	public static class ObjectBinaryEqualityExtensions
	{
		/// <summary>
		/// Checks Whether <paramref name="v"/> Equals To Any Of <paramref name="objects"/> Or Not
		/// </summary>
		public static bool EqualsOr<T>(this T v, params T[] objects)
		{
			return objects.Any(o => o.Equals(v));
		}

		/// <summary>
		/// Checks Whether <paramref name="v"/> Equals To All Of <paramref name="objects"/> Or Not
		/// </summary>
		public static bool EqualsAnd<T>(this T v, params T[] objects)
		{
			return objects.All(o => o.Equals(v));
		}
	}
}
