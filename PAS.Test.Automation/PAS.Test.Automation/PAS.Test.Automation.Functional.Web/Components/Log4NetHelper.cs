using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Test.Automation.Functional.Web.Components
{
    class Log4NetHelper
    {
        #region Fields

        private static ILog _logger;
        private static ILog _xmlLogger;
        private static ConsoleAppender _consoleAppender;
        private static FileAppender _fileAppender;
        private static RollingFileAppender _rollingFileAppender;
        private static string _layout = "%message%newline";

        #endregion

        #region GettersAndSetters

        public static string Layout
        {
            set { _layout = value; }
        }

        #endregion

        #region Appenders

        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.Error

            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }

        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", ConfigurationManager.AppSettings["LogFilePath"])) + "\\" + "Logs.log"
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingFileAppender = new RollingFileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", ConfigurationManager.AppSettings["LogFilePath"])) + "\\" + "RollingLogs.log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15
            };
            rollingFileAppender.ActivateOptions();
            return rollingFileAppender;
        }

        #endregion

        #region Public

        public static ILog GetLogger(String loggerName)
        {
            if (_consoleAppender == null)
            {
                _consoleAppender = GetConsoleAppender();
            }
            if (_fileAppender == null)
            {
                _fileAppender = GetFileAppender();
            }
            if (_rollingFileAppender == null)
            {
                _rollingFileAppender = GetRollingFileAppender();
            }

            if (_logger != null)
                return _logger;

            BasicConfigurator.Configure(_consoleAppender, _fileAppender, _rollingFileAppender);
            _logger = LogManager.GetLogger(loggerName);
            return _logger;

        }

        public static ILog GetXMLLogger(String loggerName)
        {
            if (_xmlLogger != null)
            {
                return _xmlLogger;
            }

            XmlConfigurator.Configure();
          
            _xmlLogger = LogManager.GetLogger(loggerName);
            return _xmlLogger;
        }

        #endregion
    }
}
