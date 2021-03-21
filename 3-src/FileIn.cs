namespace evertest
{
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading.Tasks;

    public class FileIn
    {
        private string pathFile;
        public FileIn(string PathFileIn)
        {
            this.pathFile = PathFileIn;
        }
        public BlockingCollection<string> GetDataFromFile()
        {
            //var inputLines = new BlockingCollection<string>(boundedCapacity: 500);
            var inputLines = new BlockingCollection<string>();

            foreach (var line in File.ReadLines(pathFile))
                inputLines.Add(line);

            inputLines.CompleteAdding();

            return inputLines;
        }
    }
}