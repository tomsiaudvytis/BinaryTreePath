namespace BinaryTreeMaxSumCalculator
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;

    interface IFileReader
    {
        StreamReader ReadFile(string nameSpace, string folder, string fileName);
    }

    internal class FileReader : IFileReader
    {
        public StreamReader ReadFile(string nameSpace,string folder, string fileName)
        {
            try
            {
                var assembly = Assembly.GetEntryAssembly();
                var resourceStream = assembly.GetManifestResourceStream($"{nameSpace}.{folder}.{fileName}");

                return new StreamReader(resourceStream, Encoding.UTF8);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
