using System;
using log4net;
using log4net.Config;

namespace StackOverflow.Shared.Components.Logger
{
	public static class FileLogger
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(log4net.Repository.Hierarchy.Logger));
		public static void InitLogger()
		{
			XmlConfigurator.Configure();
		}
		public static void Error(string message, Exception exception)
		{
			log.Error(message, exception);
		}
		public static void Error(string message)
		{
			log.Error(message);
		}
		public static void Error(Exception exception)
		{
			Error(exception.ToString(), exception);
		}
	}
}
