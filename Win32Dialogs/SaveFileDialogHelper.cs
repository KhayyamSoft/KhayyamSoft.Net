using Microsoft.Win32;

namespace KhayyamApps.Windows.Win32Dialogs
{
	/// <summary>
	/// Minimal Helper Class For Win32 SaveFileDialog
	/// </summary>
	public static class SaveFileDialogHelper
	{
		/// <summary>
		/// Creates New Win32 Save File Dialog
		/// </summary>
		/// <param name="fileAndPathCheck">CheckPathExists & CheckFileExists</param>
		/// <returns>SaveFileDialog Object</returns>
		public static SaveFileDialog NewSaveFileDialog(bool fileAndPathCheck = true, string defaultExt = null, string filter = null)
		{
			var dialog =  new SaveFileDialog()
			{
				CheckPathExists = fileAndPathCheck,
				CheckFileExists = fileAndPathCheck,
				DefaultExt = defaultExt ?? string.Empty,
				Filter = filter
			};
			return dialog;
		}

		/// <summary>
		/// Show A Simple SaveFileDialog With Common Settings 
		/// (File & Path Check & No Filter)
		/// </summary>
		/// <returns>Selected File Path Or Null If Dialog Canceled</returns>
		public static string ShowSimpleSaveFileDialog()
		{
			var dialog = NewSaveFileDialog();
			var path = dialog.ShowDialog();
			var result = path == true ? dialog.FileName : null;
			return result;
		}
	}
}
