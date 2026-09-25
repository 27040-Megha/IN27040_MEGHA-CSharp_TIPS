using System.Diagnostics;
using System.Text;
using FileCreator;

namespace Assignments
{
    /// <summary>
    /// Class contains method to write Files in 2 ways: (Both method writes 4096 bytes as chunks at a time)
    /// 1. FileStreams - Opens a stream connection and writes data to files as chunks in byte format
    /// 2. File - Writes data as chunks, but for each iteration opens the file, writes, then closes and again repeats the same
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            CreateFileUsingStreams(FileConstants.TargetFileSize, "FileStreamData.txt");
            stopwatch.Stop();
            Console.WriteLine($"Time taken while writing using FileStream: {stopwatch.Elapsed}");
            stopwatch.Restart();
            CreateFileUsingFiles(FileConstants.TargetFileSize, "FileData.txt");
            stopwatch.Stop();
            Console.WriteLine($"Time taken while writing using File class: {stopwatch.Elapsed}");
        }

        private static string BuildSampleData()
        {
            var stringBuilder = new StringBuilder();
            while (stringBuilder.Length < FileConstants.ChunkSize)
            {
                stringBuilder.Append("This is a Sample Data written using Files");
            }

            return stringBuilder.ToString();
        }

        private static void CreateFileUsingStreams(long targetFileSize, string filePath)
        {
            long currentFileSize = 0;
            var buffer = GetByteData(BuildSampleData());
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                while (currentFileSize < targetFileSize)
                {
                    fileStream.Write(buffer, 0, buffer.Length);
                    currentFileSize += buffer.Length;
                }
            }

            Console.WriteLine("Successfully Written 1 GB of file using FileStreams!");
        }

        private static byte[] GetByteData(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        private static void CreateFileUsingFiles(long targetFileSize, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            long currentFileSize = 0;
            var lineToWrite = BuildSampleData();
            var buffer = GetByteData(lineToWrite);
            while (currentFileSize < targetFileSize)
            {
                File.AppendAllText(filePath, lineToWrite);
                currentFileSize += buffer.Length;
            }

            Console.WriteLine("Successfully Written 1 GB of file using Files!");
        }
    }
}