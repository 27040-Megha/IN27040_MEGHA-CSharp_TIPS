using System.Diagnostics;
using FileDataProcessorWithAsyncMethods;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                RunSynchronousFileProcessor();
                stopwatch.Stop();
                Console.WriteLine($"Time taken to process files Synchronously : {stopwatch.ElapsedMilliseconds}");
                stopwatch.Restart();
                RunAsynchronousFileProcessor();
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
            var thread1 = new Thread(() => SyncFileProcessor.ProcessAndSaveFile(FilePath.FirstSource, FilePath.FirstDestination));
            var thread2 = new Thread(() => SyncFileProcessor.ProcessAndSaveFile(FilePath.SecondSource, FilePath.SecondDestination));
            var thread3 = new Thread(() => SyncFileProcessor.ProcessAndSaveFile(FilePath.ThirdSource, FilePath.ThirdDestination));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
        }

        private static void RunAsynchronousFileProcessor()
        {
            var task1 = AsyncFileProcessor.ProcessAndSaveFileAsync(FilePath.FirstSource, FilePath.FirstDestination);
            var task2 = AsyncFileProcessor.ProcessAndSaveFileAsync(FilePath.SecondSource, FilePath.SecondDestination);
            var task3 = AsyncFileProcessor.ProcessAndSaveFileAsync(FilePath.ThirdSource, FilePath.ThirdDestination);
            Task.WaitAll(task1, task2, task3);
        }
    }
}