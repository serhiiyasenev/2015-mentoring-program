using System;
using System.Diagnostics;

namespace NetMentoring
{
    internal class Program
    {
        private static void Main()
        {
            var timer = new Stopwatch();
            var logger = new Logger();
            timer.Start();
            for (var i = 0; i < 10000; i++)
                logger.Log(i == 9999 ? $"Iteration number #{i} {DateTime.Now:F}" : $"Iteration number #{i}");
            logger.ReadFile();
            var executionTime = timer.ElapsedMilliseconds;
            timer.Stop();

            Console.WriteLine("Finished");
            Console.WriteLine($"ExecutionTime: {executionTime} Milliseconds");
            Console.Read();
        }
    }
}
