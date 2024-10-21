using System.Collections.Generic;
using System.Globalization;

namespace KhayyamApps.Windows.ApplicationExtensions
{
	/// <summary>
	/// Encapsulates Informations About Application Such As Culture,
	/// Version, Name In Different Languages & So On.
	/// </summary>
	public class ApplicationInfo
	{
		public string AppVersion { get; set; }

		/// <summary>
		/// By Default Set To Invariant
		/// </summary>
		public CultureInfo AppCulture { get; set; } = new CultureInfo("");

		private Dictionary<string, string> AppNames { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// Declare Application Name In Specified Language.
		/// Caution: Will Be Replaced By New Value If Exists In Storage
		/// </summary>
		/// <param name="language">Language Code Name like 'en'</param>
		/// <param name="name">Name Of Application In Specified Language</param>
		public void SetAppName(string language, string name)
		{
			if (AppNames.ContainsKey(language)) AppNames[language] = name;
			else AppNames.Add(language, name);
		}

		/// <summary>
		/// Try To Find Application Name In Specified Language.
		/// </summary>
		/// <param name="language">Language Code Name like 'en'</param>
		/// <returns>Application Name In Specified Language Or Empty String If Nothing Found</returns>
		public string GetAppName(string language)
		{
			AppNames.TryGetValue(language, out var name);
			return name ?? string.Empty;
		}

		public ApplicationInfo(string appVersion, Dictionary<string, string> appNames)
		{
			AppVersion = appVersion;
			foreach (var name in appNames) SetAppName(name.Key, name.Value);
		}
	}
}
