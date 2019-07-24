using System;
using System.IO;

namespace NetMentoring.Loggers
{
    public class LogReader : IDisposable
    {
        private readonly StreamReader _streamReader;

        public LogReader(string pathToFile) 
            => _streamReader = new StreamReader(pathToFile);

        // added for educational purposes
        ~LogReader() 
            => Dispose(false);

        public void ReadFile()
        {
            try
            {
                var counter = 0;
                string line;
                while ((line = _streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    counter++;
                }
                Console.WriteLine($"File has {counter} lines.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _streamReader?.Close();
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _alreadyDisposed;

        protected virtual void Dispose(bool disposeManagedResources)
        {
            Console.WriteLine("Call of protected virtual void Dispose");
            if (_alreadyDisposed) return;
            if (disposeManagedResources)
                _streamReader?.Dispose();
            _alreadyDisposed = true;
        }
    }
}
