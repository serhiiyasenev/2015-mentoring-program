using NetMentoring.Loggers;
using System;
using System.Diagnostics;

namespace NetMentoring
{
    internal class Program
    {
        private const string PathToFile = @"Files\log.txt";

        private static void Main(string[] args)
        {
            var Timer = new Stopwatch();
            Timer.Start();

            using (var logWirter = new LogWirter(PathToFile))
            {
                for (var i = 0; i < 10000; i++)
                {
                    if (i == 9999)
                        logWirter.Log("Iteration number #" + i + " " + DateTime.Now.ToString("F"));
                    else
                        logWirter.Log("Iteration number #" + i);
                }
            }

            using (var logReader = new LogReader(PathToFile))
            {
                logReader.ReadFile();
            }

            var executionTime = Timer.ElapsedMilliseconds;
            Timer.Stop();

            Console.WriteLine("Finished.");
            Console.WriteLine($"ExecutionTime: {executionTime} Milliseconds.");
        }
    }
}
