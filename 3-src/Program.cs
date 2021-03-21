using System;
using System.Threading.Tasks;

namespace evertest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var _fileIn = new FileIn("filein.csv");
            var _dataProcess = new DataProcess();
            
            // Read data from file
            var _dataIn = _fileIn.GetDataFromFile();
            //Console.WriteLine($"_data.Count = {_data.Count}");

            // Process data
            var _processData = _dataProcess.Process(_dataIn);
            
            Task.WaitAll(_processData);

        }
    }
}
