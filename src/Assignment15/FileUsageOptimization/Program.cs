using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        /// <param name="filePath">File Path</param>
        public delegate void FileTask(string filePath);

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
            var filePath = GetFileName();
            if (filePath == null)
            {
                return;
            }

            fileTask(filePath);
            stopwatch.Stop();
            long bytesAllocatedAfterRun = GC.GetTotalAllocatedBytes();
            currentProcess.Refresh();
            long memoryAfterRun = currentProcess.WorkingSet64;
            DisplayPerformanceMetrics(bytesAllocatedAfterRun - bytesAllocatedBeforeRun, memoryAfterRun - memoryBeforeRun, stopwatch.ElapsedMilliseconds);
        }

        private static string GetFileName()
        {
            TextColor.WriteColoredLine(DisplayResource.PromptFileName, ConsoleColor.Cyan);
            var filePath = Console.ReadLine();
            if (!IsValidFilePath(filePath))
            {
                TextColor.WriteColoredLine(DisplayResource.InvalidFilePath, ConsoleColor.Red);
                return null;
            }

            return filePath;
        }

        private static bool IsValidFilePath(string input)
        {
            string fileName = Path.GetFileName(input);
            char[] invalidCharacters = Path.GetInvalidFileNameChars();
            if (fileName.Any(ch => invalidCharacters.Contains(ch)))
            {
                return false;
            }

            string extension = Path.GetExtension(fileName);
            if (!string.Equals(extension, ".txt", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}