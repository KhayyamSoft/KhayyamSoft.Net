using System.Windows;

namespace KhayyamApps.Windows.ApplicationExtensions
{
	public static class ApplicationStartup
	{
		/// <summary>
		/// Sets Provided Window As Application MainWindow and Shows It.
		/// Caution: Remember To Initialize Window Before Passing It To This Method!
		/// </summary>
		public static void ShowSplashScreen(this Application app, Window splash)
		{
			app.MainWindow = splash;
			splash.Show();
		}

		/// <summary>
		/// Sets Provided mainWindow As Application MainWindow, Show and also Activates It.
		/// In Addition Provided splashWindow Will Be Closed Before MainWindow Activation.
		/// Caution: Remember To Initialize Window Before Passing It To This Method!
		/// </summary>
		public static void ShowMainWindow(this Application app, Window mainWindow, Window splashWindow = null)
		{
			app.MainWindow = mainWindow;
			mainWindow.Show();
			if (splashWindow != null) try { splashWindow.Close(); } catch { };
			mainWindow.Activate();
		}
	}
}
