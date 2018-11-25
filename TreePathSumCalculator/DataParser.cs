namespace TreePathSumCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IDataParser
    {
        List<int[]> ParseToList(string delimeter, string[] content);
    }

    public class DataParser : IDataParser
    {
        private readonly ILogger _logger;

        public DataParser(ILogger logger)
        {
            _logger = logger;
        }

        public List<int[]> ParseToList(string delimeter, string[] content)
        {
            List<int[]> parsedData = new List<int[]>();

            try
            {
                foreach (string singleRow in content)
                {
                    string[] rowSplitted = singleRow.Split(delimeter);

                    int[] convertedRow = rowSplitted?.Select(int.Parse)?.ToArray();

                    parsedData.Add(convertedRow);
                }

                _logger.LogFile("Content Parsed successfully");
                return parsedData;
            }
            catch (Exception ex)
            {
                _logger.LogFile($"{ex.Message} | {ex.StackTrace}");
                throw;
            }
        }
    }
}
