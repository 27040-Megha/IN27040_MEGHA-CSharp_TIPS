using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FileDataProcessorWithAsyncMethods;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private async static Task Main(string[] args)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                RunSynchronousFileProcessor();
                stopwatch.Stop();
                Console.WriteLine($"Time taken to process files Synchronously : {stopwatch.ElapsedMilliseconds}");
                stopwatch.Restart();
                await RunAsynchronousFileProcessorAsync();
                stopwatch.Stop();
                Console.WriteLine($"Time taken to process files Asynchronously : {stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static void RunSynchronousFileProcessor()
        {
            var threads = new List<Thread>();
            for (int i = 1; i <= 10; i++)
            {
                string sourceFilePath = FilePath.ResourceManager.GetString($"Source{i}");
                string destinationFilePath = FilePath.ResourceManager.GetString($"Destination{i}");
                var thread = new Thread(() => SyncFileProcessor.ProcessAndSaveFile(sourceFilePath, destinationFilePath));
                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        private static async Task RunAsynchronousFileProcessorAsync()
        {
            var tasks = new List<Task>();

            for (int i = 1; i <= 10; i++)
            {
                string sourceFilePath = FilePath.ResourceManager.GetString($"Source{i}");
                string destinationFilePath = FilePath.ResourceManager.GetString($"Destination{i}");
                Task task = AsyncFileProcessor.ProcessAndSaveFileAsync(sourceFilePath, destinationFilePath);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}