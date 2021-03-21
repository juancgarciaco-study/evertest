namespace evertest
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class DataProcess
    {
        private readonly LineProcessed lineProc;

        public DataProcess()
        {
            lineProc = new LineProcessed("FileDone.txt");
        }

        public Task Process(BlockingCollection<string> inputLines)
        {
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };
            return Task.Factory.StartNew(() =>
            {
                int rowCount = 0;
                Parallel.ForEach(inputLines.GetConsumingEnumerable()
                //, parallelOptions
                , line =>
                {
                    ++rowCount;
                    string[] lineFields = line.Split(',');
                    double documentNumber = int.Parse(lineFields[1]);
                    double movement = int.Parse(lineFields[1]);
                    //Console.WriteLine($"documentNumber: {documentNumber}, row:{++rowCount}");
                    var newLine = $"Processed {rowCount}-{Thread.CurrentThread.ManagedThreadId},{line}";
                    Console.WriteLine(newLine);
                    finishLine(line: newLine);
                });
            });
        }

        public void finishLine(string line)
        {
            lineProc.processedLine(line);
        }

    }
}