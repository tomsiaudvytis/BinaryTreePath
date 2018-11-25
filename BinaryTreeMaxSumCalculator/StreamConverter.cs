namespace BinaryTreeMaxSumCalculator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    interface IStreamConverter
    {
        List<int[]> ConvertStreamReaderToList(StreamReader reader);
    }

    internal class StreamConverter : IStreamConverter
    {
        public List<int[]> ConvertStreamReaderToList(StreamReader reader)
        {
            List<int[]> treeData = new List<int[]>();

            try
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    int[] singleRowDigits = line.Split(' ').Select(Int32.Parse).ToArray<int>();

                    treeData.Add(singleRowDigits);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return treeData;
        }
    }
}
