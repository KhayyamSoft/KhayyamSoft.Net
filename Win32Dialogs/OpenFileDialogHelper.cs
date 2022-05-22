using Microsoft.Win32;

namespace KhayyamApps.Windows.Win32Dialogs
{
	/// <summary>
	/// Minimal Helper Class For Win32 OpenFileDialog
	/// </summary>
	public static class OpenFileDialogHelper
	{
		/// <summary>
		/// Creates New Win32 Open File Dialog
		/// </summary>
		/// <param name="fileAndPathCheck">CheckPathExists & CheckFileExists</param>
		/// <returns>OpenFileDialog Object</returns>
		public static OpenFileDialog NewOpenFileDialog(bool fileAndPathCheck = true, bool multiSelect = false,
			string defaultExt = null, string filter = null)
			=> new OpenFileDialog()
			{
				CheckPathExists = fileAndPathCheck,
				CheckFileExists = fileAndPathCheck,
				Multiselect = multiSelect,
				DefaultExt = defaultExt ?? string.Empty,
				Filter = filter
			};

		/// <summary>
		/// Show A Simple OpenFileDialog With Common Settings 
		/// (File & Path Check, Single Select Mode & No Filter)
		/// </summary>
		/// <returns>Selected File Path Or Null If Dialog Canceled</returns>
		public static string ShowSimpleFileDialog()
		{
			var dialog = NewOpenFileDialog();
			var result = dialog.ShowDialog();
			return result == true ? dialog.FileName : null;
		}
	}
}
