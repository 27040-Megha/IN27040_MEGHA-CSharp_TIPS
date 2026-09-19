using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using FileUsageOptimization;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Custom delegate - To pass code snippet method and optimized version method as parameters
        /// </summary>
        public delegate void FileTask();

        private static void Main(string[] args)
        {
            TextColor.WriteColoredLine(DisplayResource.CodeSnippet, ConsoleColor.Cyan);
            AnalyzePerformance(CodeSnippet.Run);
            TextColor.WriteColoredLine(DisplayResource.OptimizedCode, ConsoleColor.Cyan);
            AnalyzePerformance(OptimizedFileUsage.Run);
        }

        private static void DisplayPerformanceMetrics(long heapMemory, long physicalRAM, long timeConsumed)
        {
            TextColor.WriteColoredLine(string.Format(DisplayResource.PerformanceMetrics, timeConsumed, heapMemory, physicalRAM), ConsoleColor.White);
        }

        private static void AnalyzePerformance(FileTask fileTask)
        {
            var stopwatch = new Stopwatch();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            var currentProcess = Process.GetCurrentProcess();
            long memoryBeforeRun = currentProcess.WorkingSet64;
            long bytesAllocatedBeforeRun = GC.GetTotalAllocatedBytes();
            stopwatch.Start();
            fileTask();
            stopwatch.Stop();
            long bytesAllocatedAfterRun = GC.GetTotalAllocatedBytes();
            currentProcess.Refresh();
            long memoryAfterRun = currentProcess.WorkingSet64;
            DisplayPerformanceMetrics(bytesAllocatedAfterRun - bytesAllocatedBeforeRun, memoryAfterRun - memoryBeforeRun, stopwatch.ElapsedMilliseconds);
        }
    }
}