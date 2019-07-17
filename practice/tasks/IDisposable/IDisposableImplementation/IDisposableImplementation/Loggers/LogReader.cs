using System;
using System.IO;

namespace NetMentoring.Loggers
{
    public class LogReader : IDisposable
    {
        private StreamReader _streamReader;

        public LogReader(string pathToFile)
        {
            if (_streamReader == null)
                _streamReader = new StreamReader(pathToFile);
        }

        public void ReadFile()
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LogReader() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            //GC.SuppressFinalize(this);
        }
        #endregion
    }
}
