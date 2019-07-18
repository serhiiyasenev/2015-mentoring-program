using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger
    {
        private const string PathToFile = @"Files\log.txt";

        public void ReadFile()
        {
            if (!File.Exists(PathToFile)) return;
            using (var streamReader = new StreamReader(PathToFile))
            {
                var counter = 0;
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    counter++;
                }
                streamReader.Close();
                Console.WriteLine($"File has {counter} lines.");
            }
        }

        public void Log(string message)
        {
            using (var streamWriter = new StreamWriter(PathToFile))
            {
                streamWriter.Write(message);
                streamWriter.Close();
            }
        }
    }
}
