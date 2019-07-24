using System;
using System.IO;

namespace NetMentoring.Loggers
{
    public class LogWriter : IDisposable
    {
        private readonly StreamWriter _streamWriter;

        public LogWriter(string pathToFile) 
            => _streamWriter = new StreamWriter(pathToFile);

        // added for educational purposes
        ~LogWriter() 
            => Dispose(false);

        public void Log(string message)
        {
            try
            {
                _streamWriter.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _streamWriter?.Close();
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
                _streamWriter?.Dispose();
            _alreadyDisposed = true;
        }
    }
}
