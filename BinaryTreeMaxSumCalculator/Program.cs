namespace BinaryTreeMaxSumCalculator
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using TreePathSumCalculator;
    using TreePathSumCalculator.Models;

    internal class Program
    {
        static void Main(string[] args)
        {
            SetupDi(out ICalculator applicationInit);
            CalculationResult result = applicationInit.StartCalculation(@"Data\tree.txt");

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                Console.WriteLine(result.ErrorMessage);
            }
            else
            {
                Console.WriteLine($"Calculation completed. ");
                Console.WriteLine($"Max path sum: {result.MaxPathSum}\nPath: {result.Path}");
            }

            Console.ReadLine();
        }

        private static void SetupDi(out ICalculator app)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDataReader, DataReader>()
                .AddSingleton<IDataParser, DataParser>()
                .AddSingleton<ICalculator, Calculator>()
                .AddSingleton<ICalculationLogic, CalculationLogic>()
                .AddSingleton<ILogger, CustomLogger>()
                .AddSingleton<IBinaryTreeValidator, BinaryTreeValidator>()
              .BuildServiceProvider();

            app = serviceProvider.GetService<ICalculator>();
        }
    }
}
