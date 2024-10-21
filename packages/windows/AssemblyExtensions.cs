using System;
using System.Reflection;

namespace KhayyamApps.Windows
{
	public static class AssemblyExtensions
	{
		public static Version GetVersion(this Assembly assembly) => assembly.GetName().Version;
		public static string GetVersion(this Assembly assembly, int fieldCount = 2) => assembly.GetVersion().ToString(fieldCount);
	}
}
