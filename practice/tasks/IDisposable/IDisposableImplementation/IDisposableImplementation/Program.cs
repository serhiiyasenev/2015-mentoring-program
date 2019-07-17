using System;
using System.Diagnostics;

namespace NetMentoring
{
    internal class Program
    {
        public static Stopwatch Timer { get; } = new Stopwatch();

        private static void Main(string[] args)
        {
            Timer.Start();

            using (var logger = new MemoryStreamLogger())
            {
                for (var i = 0; i < 10000; i++)
                {
                    if (i == 9999)
                        logger.Log("Iteration number #" + i + " " + DateTime.Now.ToString("F"));
                    else
                        logger.Log("Iteration number #" + i);
                }
                logger.ReadFile();
            }

            var executionTime = Timer.ElapsedMilliseconds;
            Timer.Stop();

            Console.WriteLine("Finished");
            Console.WriteLine($"ExecutionTime: {executionTime} Milliseconds");
        }
    }
}
