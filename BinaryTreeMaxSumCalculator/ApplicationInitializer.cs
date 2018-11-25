namespace BinaryTreeMaxSumCalculator
{
    using BinaryTreeMaxSumCalculator.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;

    interface IApplicationInitializer
    {
        BinaryTreeCalculationResult CalculateMaxPathSum();
    }

    internal class ApplicationInitializer : IApplicationInitializer
    {
        protected readonly IFileReader _fileReader;
        protected readonly IStreamConverter _streamConverter;
        protected readonly IBinaryTreeCalculator _binaryTreeCalculator;

        public ApplicationInitializer(
            IFileReader fileReader, 
            IStreamConverter streamConverter, 
            IBinaryTreeCalculator binaryTreeCalculator)
        {
            _fileReader = fileReader;
            _streamConverter = streamConverter;
            _binaryTreeCalculator = binaryTreeCalculator;
        }

        public BinaryTreeCalculationResult CalculateMaxPathSum()
        {
            try
            {
                StreamReader binaryTreeReader = GetBinaryTreeData();

                List<int[]> binaryTreeData = ConverStreamList(binaryTreeReader);

                return CalculateBinaryTreeMaxSumValue(binaryTreeData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Calculation failed due to {ex.Message}");
                Console.ReadLine();
                return new BinaryTreeCalculationResult();
            }
        }

        private BinaryTreeCalculationResult CalculateBinaryTreeMaxSumValue(List<int[]> binaryTreeData) 
            => _binaryTreeCalculator.CalculateMaxSum(binaryTreeData);

        private List<int[]> ConverStreamList(StreamReader reader) 
            => _streamConverter.ConvertStreamReaderToList(reader);

        private StreamReader GetBinaryTreeData()
            => _fileReader.ReadFile("BinaryTreeMaxSumCalculator", "Data", "tree.txt");
    }
}
