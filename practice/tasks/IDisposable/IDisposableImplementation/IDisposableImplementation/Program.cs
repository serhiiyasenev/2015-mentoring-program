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
                    WriteLog("Iteration number #" + i + " " + DateTime.Today.ToString("F"));
                else
                    WriteLog("Iteration number #" + i);
            }
            
            var executionTime = Timer.ElapsedMilliseconds / 1000;
            Timer.Stop();
            Console.WriteLine("Finished");
            Console.WriteLine($"ExecutionTime: {executionTime} seconds");
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
