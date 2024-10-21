using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace KhayyamApps.Windows
{
	/// <summary>
	/// Setup Global Exception Handlers For Application Dispatcher, AppDomain and TaskScheduler
	/// </summary>
	public static class ExceptionHandling
	{
		private static Action<Exception, string> EmptyErrorLogger { get; } = (s, e) => { };

		/// <summary>
		/// Routes Exception and Its Source To Logger
		/// </summary>
		private static Action<Exception, string> ErrorLogger { get; set; } = EmptyErrorLogger;

		private static string ApplicationName { get; set; }

		/// <summary>
		/// Setup Global Exception Handlers For Application Dispatcher, AppDomain and TaskScheduler
		/// </summary>
		/// <param name="errorLogger">Exception To Logger Router</param>
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
			ErrorLogger((Exception)e.ExceptionObject, nameof(AppDomain.CurrentDomain.UnhandledException));
		}

		private static void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			ErrorLogger(e.Exception, $"{ApplicationName}.DispatcherUnhandledException");
			e.Handled = true;
		}

		private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			ErrorLogger(e.Exception, nameof(TaskScheduler.UnobservedTaskException));
			e.SetObserved();
		}
	}
}
