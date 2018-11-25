namespace BinaryTreeMaxSumCalculator
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        static void Main(string[] args)
        {
            SetupDi(out IApplicationInitializer applicationInit);
            var result = applicationInit.CalculateMaxPathSum();
            Console.WriteLine($"Max sum: {result.MaxSum}\nPath: {result.Path}");

            Console.ReadLine();
        }

        private static void SetupDi(out IApplicationInitializer app)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IApplicationInitializer, ApplicationInitializer>()
                .AddSingleton<IFileReader, FileReader>()
                .AddSingleton<IStreamConverter, StreamConverter>()
                .AddSingleton<IBinaryTreeCalculator, BinaryTreeCalculator>()
                .BuildServiceProvider();

            app = serviceProvider.GetService<IApplicationInitializer>();
        }
    }
}
