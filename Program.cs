namespace BinaryTreeMaxSumCalculator
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        static void Main(string[] args)
        {
            SetupDi(out IApplicationInitializer applicationInit);

            Console.WriteLine("Starting calculation. !");
            applicationInit.StartApp();
            Console.WriteLine("Calculation completed. !");

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
