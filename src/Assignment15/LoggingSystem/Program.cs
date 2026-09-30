using System.Diagnostics;
using Helper;
using LoggingSystem;

namespace Assignments
{
    /// <summary>
    /// Entry point of application - Calls ExecuteLogger() that measures the execution time taken for writing log to same file and independent files
    /// </summary>
    public class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                await ExecuteLogger();
            }
            catch (Exception ex)
            {
                TextColor.WriteColoredLine(string.Format(DisplayResource.ExceptionMessage, ex.Message), ConsoleColor.Red);
            }
        }

        private static async Task ExecuteLogger()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await PerformanceTester.RunLoadForSameFileLogger();
            stopwatch.Stop();
            TextColor.WriteColoredLine(string.Format(DisplayResource.ExecutionTimeForSameFile, stopwatch.ElapsedMilliseconds), ConsoleColor.Cyan);
            stopwatch.Restart();
            await PerformanceTester.RunLoadForIndependentLogger();
            stopwatch.Stop();
            TextColor.WriteColoredLine(string.Format(DisplayResource.ExecutionTimeForIndependentFiles, stopwatch.ElapsedMilliseconds), ConsoleColor.Cyan);
        }
    }
}
