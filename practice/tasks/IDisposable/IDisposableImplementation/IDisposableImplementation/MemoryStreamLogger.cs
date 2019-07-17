using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger : IDisposable
    {
        private static FileStream _memoryStream;
        private static StreamWriter _streamWriter;
        private const string PathToFile = @"Files\\log.txt";
        private bool _disposed;


        public void ReadFile()
        {
            using (var file = new StreamReader(PathToFile))
            {
                var counter = 0;
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    counter++;
                }
                file.Close();
                Console.WriteLine($"File has {counter} lines.");  
            }
        }

        public void Log(string message)
        {
            _memoryStream = new FileStream(PathToFile, FileMode.Open);
            _streamWriter = new StreamWriter(_memoryStream);
            _streamWriter.Write(message);
        }

        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (_disposed) return;

            if (disposeManagedResources) _streamWriter?.Dispose();
            _disposed = true;
        }
    }
}
