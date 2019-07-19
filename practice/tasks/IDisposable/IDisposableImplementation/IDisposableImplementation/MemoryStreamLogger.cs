using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger
    {
        private const string PathToFile = @"Files\log.txt";

        public void Log(string message)
        {
            using (var streamWriter = new StreamWriter(PathToFile))
            {
                streamWriter.WriteLine(message);
            }
        }

        public void ReadFile()
        {
            if (!File.Exists(PathToFile))
            {
                Console.WriteLine($"File '{PathToFile}' does not exist!");
                return;
            }
            using (var streamReader = new StreamReader(PathToFile))
            {
                var counter = 0;
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    counter++;
                }
                Console.WriteLine($"File has {counter} lines.");
            }
        }
    }
}
