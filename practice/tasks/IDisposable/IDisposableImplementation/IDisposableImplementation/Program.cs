using NetMentoring.Loggers;
using System;
using System.Diagnostics;

namespace NetMentoring
{
    internal class Program
    {
        private const string PathToFile = @"Files\log.txt";

        private static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();

            using (var logWriter = new LogWriter(PathToFile))
            {
                for (var i = 0; i < 10000; i++)
                    logWriter.Log(i == 9999 ? $"Iteration number #{i} {DateTime.Now:F}" : $"Iteration number #{i}");
            }

            using (var logReader = new LogReader(PathToFile))
            {
                logReader.ReadFile();
            }

            var executionTime = timer.ElapsedMilliseconds;
            timer.Stop();

            Console.WriteLine("Finished.");
            Console.WriteLine($"ExecutionTime: {executionTime} Milliseconds.");
            Console.Read();
        }
    }
}
