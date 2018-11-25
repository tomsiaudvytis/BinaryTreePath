namespace TreePathSumCalculator
{
    using NLog;
    using System;
    using System.Collections.Generic;
    using TreePathSumCalculator.Models;

    public interface ICalculator
    {
        CalculationResult StartCalculation(string filePath);
    }

    public class Calculator : ICalculator
    {
        private readonly ICalculationLogic _calculationLogic;
        private readonly IDataParser _dataParser;
        private readonly IDataReader _dataReader;
        private readonly ILogger _logger;
        private readonly IBinaryTreeValidator _binaryTreeValidator;

        public Calculator(
            ICalculationLogic calculationLogic,
            IDataParser dataParser,
            IDataReader dataReader,
            ILogger logger,
            IBinaryTreeValidator binaryTreeValidator)
        {
            _calculationLogic = calculationLogic;
            _dataParser = dataParser;
            _dataReader = dataReader;
            _logger = logger;
            _binaryTreeValidator = binaryTreeValidator;

            InitLogger();
        }

        public CalculationResult StartCalculation(string filePath)
        {
            try
            {
                _logger.LogFile("Initiating Calculation.");

                string[] fileContent = ReadFileContent(filePath);

                List<int[]> fileContentAsBinaryTreeData = ConvertToDigitsList(fileContent);

                if (!ValidateBinaryTree(fileContentAsBinaryTreeData))
                {
                    return new CalculationResult()
                    {
                        ErrorMessage = $"Supplied data was not correct.!"
                    };
                }

                _logger.LogFile("Calculation completed.");
                return CalculatePathMaxSum(fileContentAsBinaryTreeData);
            }
            catch (Exception ex)
            {
                _logger.LogFile($"{ex.Message} | {ex.StackTrace}");

                return new CalculationResult()
                {
                    ErrorMessage = $"Calculation failed => {ex.Message} \nFor more details check logs."
                };
            }
        }

        private bool ValidateBinaryTree(List<int[]> tree) => _binaryTreeValidator.IsTreeValid(tree);

        private CalculationResult CalculatePathMaxSum(List<int[]> data) => _calculationLogic.CalculateMaxSum(data);

        private List<int[]> ConvertToDigitsList(string[] fileContent) => _dataParser.ParseToList(" ", fileContent);

        private string[] ReadFileContent(string filePath) => _dataReader.ReadFileContent(filePath);

        private void InitLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }
    }
}
