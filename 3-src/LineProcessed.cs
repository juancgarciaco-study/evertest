namespace evertest
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class LineProcessed
    {
        private Object thisLock = new Object();

        public Queue logs = new Queue();

        public string path;

        public LineProcessed(string path)
        {
            this.path = path;
            Init();        
        }

        private void Init()
        {
            // if (File.Exists(path))
            // {
                File.WriteAllText(path,string.Empty);
                //File.Delete(path);File.Create(path);
            // }else{
            //     File.Create(path);
            // }

        }

        public void processedLine(string line)
        {
            lock (thisLock)
            {
                this.logs.Enqueue(line);
                //Console.WriteLine($"t: {t}");
                //Console.WriteLine($"ct: {_ct}");
                string[] _lines = {line};
                File.AppendAllLines(path, _lines);
            }

        }

    }
}