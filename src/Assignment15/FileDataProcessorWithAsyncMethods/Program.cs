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
            var task1 = new Task(() => SyncFileProcessor.ProcessAndSaveFile(FilePath.FirstSource, FilePath.FirstDestination));
            var task2 = new Task(() => SyncFileProcessor.ProcessAndSaveFile(FilePath.SecondSource, FilePath.SecondDestination));
            var task3 = new Task(() => SyncFileProcessor.ProcessAndSaveFile(FilePath.ThirdSource, FilePath.ThirdDestination));
            task1.Start();
            task2.Start();
            task3.Start();
            Task.WaitAll(task1, task2, task3);
        }

        private static async void RunAsynchronousFileProcessor()
        {
            var task1 = Task.Run(async () => await AsyncFileProcessor.ProcessAndSaveFileAsync(FilePath.FirstSource, FilePath.FirstDestination));
            var task2 = Task.Run(async () => await AsyncFileProcessor.ProcessAndSaveFileAsync(FilePath.SecondSource, FilePath.SecondDestination));
            var task3 = Task.Run(async () => await AsyncFileProcessor.ProcessAndSaveFileAsync(FilePath.ThirdSource, FilePath.ThirdDestination));
            Task.WaitAll(task1, task2, task3);
        }
    }
}