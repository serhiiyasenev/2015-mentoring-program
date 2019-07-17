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

            for (var i = 0; i < 10000; i++)
            {
                if (i == 9999)
                    WriteLog("Iteration number #" + i + " " + DateTime.Now.ToString("F"));
                else
                    WriteLog("Iteration number #" + i);
            }
            
            var executionTime = Timer.ElapsedMilliseconds;
            Timer.Stop();

            Console.WriteLine("Finished");
            Console.WriteLine($"ExecutionTime: {executionTime} Milliseconds");
            new MemoryStreamLogger().ReadFile();
            Console.ReadKey();
        }

        private static void WriteLog(string str)
        {
            var logger = new MemoryStreamLogger();
            logger.Log(str);
            logger.Dispose();
        }

    }
}
