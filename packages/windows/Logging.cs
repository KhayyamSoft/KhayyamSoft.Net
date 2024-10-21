using NLog.Targets;
using NLog;
using System;

namespace KhayyamApps.Windows
{
	/// <summary>
	/// Make Using Of NLogger Not a Pain In Ass!
	/// </summary>
	public static class Logging
	{
		private static Action<Exception> EmptyErrorShowHandler { get; set; } = (e) => { };

		/// <summary>
		/// Routes Exception To UI (Use It With Something Like MessageBox)
		/// </summary>
		private static Action<Exception> ErrorShowHandler { get; set; } = EmptyErrorShowHandler;

		public static void SetupErrorShowHandler(Action<Exception> errorShowHandler = null)
		{
			ErrorShowHandler = errorShowHandler ?? EmptyErrorShowHandler;
		}

		/// <summary>
		/// Make New File Target With Basic Settings.
		/// FileName = {name}.log, Archive By Day And
		/// LayoutFormat = "${longdate}|${level:uppercase=true}|${logger}|${message:withexception=true}"
		/// </summary>
		public static FileTarget NewFileTarget(string name) => new FileTarget(name)
		{
			FileName = $"{name}.log",
			ArchiveFileName = name + ".{#}.log",
			ArchiveNumbering = ArchiveNumberingMode.Date,
			ArchiveEvery = FileArchivePeriod.Day,
			ArchiveDateFormat = "yyyyMMdd",
			Layout = "${longdate}|${level:uppercase=true}|${logger}|${message:withexception=true}"
		};

		/// <summary>
		/// Simple Handler For Logging And Showing Custom UI By ErrorShowHandler
		/// </summary>
		public static void LogUnhandledException(this Logger logger, Exception exception, string assemblyName = "-")
		{
			var message = $"Unhandled exception";
			try
			{
				message = $"{message} in {assemblyName}";
			}
			catch (Exception ex)
			{
				logger.Error(ex, $"Exception in {nameof(LogUnhandledException)}");
				ErrorShowHandler(ex);
			}
			finally
			{
				logger.Error(exception, message);
				ErrorShowHandler(exception);
			}
		}

		/// <summary>
		/// Simple Handler For Logging And Showing Custom UI By ErrorShowHandler (Using Serilog)
		/// </summary>
		public static void LogUnhandledException(this Serilog.ILogger logger, Exception exception, string assemblyName = "-")
		{
			var message = $"Unhandled exception";
			try
			{
				message = $"{message} in {assemblyName}";
			}
			catch (Exception ex)
			{
				logger.Error(ex, $"Exception in {nameof(LogUnhandledException)}");
				ErrorShowHandler(ex);
			}
			finally
			{
				logger.Error(exception, message);
				ErrorShowHandler(exception);
			}
		}
	}
}
