namespace KhayyamApps.Windows.WindowExtensions
{
	public static class WindowAsDialogExtensions
	{
		/// <summary>
		/// Sets Dialog Result And Close It (Without Exception)
		/// </summary>
		/// <param name="window">Dialog To Close</param>
		/// <param name="dialogResult">Result To Set As Dialog Result</param>
		/// <returns></returns>
		public static bool SafeCloseDialog(this System.Windows.Window window, bool? dialogResult = null)
		{
			try { window.DialogResult = true; } catch { return false; }
			try { window.Close(); } catch { return false; }
			return true;
		}
	}
}
