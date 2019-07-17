using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger : IDisposable
    {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private const string PathToFile = @"Files\log.txt";
        private bool _disposed;

        public void ReadFile()
        {
            _streamReader = new StreamReader(PathToFile);
            var counter = 0;
            string line;
            while ((line = _streamReader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }
            _streamReader?.Close();
            Console.WriteLine($"File has {counter} lines.");
        }

        public void Log(string message)
        {
            _streamWriter = new StreamWriter(PathToFile);
            _streamWriter.Write(message);
            _streamWriter?.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            Console.WriteLine("protected virtual void Dispose");
            if (_disposed) return;
            if (disposeManagedResources)
            {
                _streamWriter?.Dispose();
                _streamReader?.Dispose();
            }
            _disposed = true;
        }
    }
}
