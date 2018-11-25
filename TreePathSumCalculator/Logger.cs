namespace TreePathSumCalculator
{
    using NLog;

    public interface ILogger
    {
        void LogConsole(string message);

        void LogFile(string message);
    }

    public class CustomLogger : ILogger
    {
        private Logger log = NLog.LogManager.GetCurrentClassLogger();

        public void LogConsole(string message) => log.Info(message);
       
        public void LogFile(string message) => log.Debug(message);
    }
}
