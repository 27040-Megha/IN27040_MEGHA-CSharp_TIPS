using System.Diagnostics;
using System.Text;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var filePath = "FileData.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File Not found!");
                return;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            ReadFileUsingFileStreams(filePath);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to read files using FileStreams: {stopwatch.Elapsed}\n");
            stopwatch.Restart();
            ReadFileUsingBufferedStream(filePath);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to read files using BufferedStreams: {stopwatch.Elapsed}\n");
            stopwatch.Restart();
            WriteFileUsingMemoryStream(filePath, "ProcessedData.txt");
            stopwatch.Stop();
            Console.WriteLine($"Time taken to process data and writing using Memory Stream: {stopwatch.Elapsed}");
        }

        private static void ReadFileUsingFileStreams(string filePath)
        {
            int chunkSize = 4096;
            var buffer = new byte[chunkSize];
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int hardwareHit = 0;
                long filePosition = 0;
                while (fileStream.Read(buffer, 0, buffer.Length) > 0)
                {
                    if (fileStream.Position > filePosition)
                    {
                        hardwareHit++;
                        filePosition = fileStream.Position;
                    }
                }

                Console.WriteLine($"TOTAL NUMBER OF HARDWARE HITS USING FILE STREAM= {hardwareHit}");
            }
        }

        private static void ReadFileUsingBufferedStream(string filePath)
        {
            int chunkSize = 4096;
            var buffer = new byte[chunkSize];
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var bufferedStream = new BufferedStream(fileStream, 1024 * 1024))
                {
                    int hardwareHit = 0;
                    long filePosition = 0;
                    while (bufferedStream.Read(buffer, 0, buffer.Length) > 0)
                    {
                        if (fileStream.Position > filePosition)
                        {
                            hardwareHit++;
                            filePosition = fileStream.Position;
                        }
                    }

                    Console.WriteLine($"TOTAL NUMBER OF HARDWARE HITS USING BUFFERED STREAM= {hardwareHit}");
                }
            }
        }

        private static void WriteFileUsingMemoryStream(string sourceFilePath, string destinationFilePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                int chunkSize = 4096;
                var buffer = new byte[chunkSize];
                using (var fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var bufferedStream = new BufferedStream(fileStream, 1024 * 1024))
                    {
                        while (bufferedStream.Read(buffer, 0, buffer.Length) > 0)
                        {
                            byte[] processedBytes = ConvertTextToUpperCase(buffer);
                            memoryStream.Write(processedBytes, 0, processedBytes.Length);
                        }
                    }
                }

                memoryStream.Position = 0;
                using (var fileStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }

            Console.WriteLine("Data Processing and Writing to File using MemoryStream Completed successfully!");
        }

        private static byte[] ConvertTextToUpperCase(byte[] chunkData)
        {
            string originalText = Encoding.UTF8.GetString(chunkData, 0, chunkData.Length);
            return Encoding.UTF8.GetBytes(originalText.ToUpper());
        }
    }
}