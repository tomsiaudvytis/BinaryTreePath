namespace TreePathSumCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TreePathSumCalculator.Models;

    public interface ICalculationLogic
    {
        CalculationResult CalculateMaxSum(List<int[]> digits);
    }

    public class CalculationLogic : ICalculationLogic
    {
        private readonly ILogger _logger;

        public CalculationLogic(ILogger logger)
        {
            _logger = logger;
        }

        public CalculationResult CalculateMaxSum(List<int[]> binaryTryRows)
        {
            try
            {
                int maxSum = binaryTryRows[0][0];
                List<string> path = new List<string>() { maxSum.ToString() };

                bool isDigitOdd = IsOdd(maxSum);
                int lastTreeRowIndex = binaryTryRows.Count;
                int currentDigitIndex = 0;

                for (int i = 1; i < binaryTryRows.Count; i++)
                {
                    int[] row = (binaryTryRows.Count - 1) == i
                        ? binaryTryRows[i].Skip(currentDigitIndex).ToArray()
                        : binaryTryRows[i].Skip(currentDigitIndex).Take(2).ToArray();

                    int currentRowMaxValue = row.Where(x => IsOdd(x) != isDigitOdd).Max();

                    currentDigitIndex = Array.IndexOf(binaryTryRows[i], currentRowMaxValue);
                    isDigitOdd = !isDigitOdd;
                    maxSum += currentRowMaxValue;
                    path.Add(currentRowMaxValue.ToString());
                }

                return new CalculationResult()
                {
                    MaxPathSum = maxSum,
                    Path = string.Join(", ", path)
                };
            }
            catch (Exception ex)
            {
                _logger.LogFile($"{ex.Message} | {ex.StackTrace}");
                throw;
            }
        }

        public bool IsOdd(int value) => value % 2 != 0;
    }
}
