using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace KhayyamApps.Windows
{
	public static class ExceptionHandling
	{
		private static Action<Exception, string> EmptyErrorLogger { get; } = (s, e) => { };
		private static Action<Exception, string> ErrorLogger { get; set; } = EmptyErrorLogger;
		private static string ApplicationName { get; set; }

		public static void SetupExceptionHandling(this Application application, AppDomain domain, Action<Exception, string> errorLogger = null)
		{
			ErrorLogger = errorLogger ?? EmptyErrorLogger;
			domain.UnhandledException += Domain_UnhandledException;
			ApplicationName = nameof(application);
			application.DispatcherUnhandledException += Application_DispatcherUnhandledException;
			TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
		}

		private static void Domain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			ErrorLogger.Invoke((Exception)e.ExceptionObject, nameof(AppDomain.CurrentDomain.UnhandledException));
		}

		private static void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			ErrorLogger.Invoke(e.Exception, $"{ApplicationName}.DispatcherUnhandledException");
			e.Handled = true;
		}

		private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			ErrorLogger.Invoke(e.Exception, nameof(TaskScheduler.UnobservedTaskException));
			e.SetObserved();
		}
	}
}
