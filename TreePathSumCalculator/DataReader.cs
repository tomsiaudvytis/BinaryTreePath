namespace TreePathSumCalculator
{
    using System;
    using System.IO;
    using System.Reflection;

    public interface IDataReader
    {
       string[] ReadFileContent(string fileName);
    }

    public class DataReader : IDataReader
    {
        private readonly ILogger _logger;

        public DataReader(ILogger logger)
        {
            _logger = logger;
        }

        public string[] ReadFileContent(string fileName)
        {
            try
            {
                string path = Path.Combine(
                    Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location),
                        fileName);

                return File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                _logger.LogFile($"{ex.Message} | {ex.StackTrace}");
                throw;
            }
        }
    }
}
