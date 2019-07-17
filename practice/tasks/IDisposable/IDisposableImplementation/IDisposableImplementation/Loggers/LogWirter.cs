using System;
using System.IO;

namespace NetMentoring.Loggers
{
    public class LogWirter : IDisposable
    {
        private StreamWriter _streamWriter;
        private bool _disposed;

        public LogWirter(string pathToFile)
        {
            if (_streamWriter == null)
                _streamWriter = new StreamWriter(pathToFile);
        }

        public void Log(string message) => _streamWriter.WriteLine(message);

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
                _streamWriter?.Dispose();
            _disposed = true;
        }
    }
}
