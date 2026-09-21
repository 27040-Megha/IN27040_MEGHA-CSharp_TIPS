using System.IO;
using System.Text;

namespace FileDataProcessorWithAsyncMethods
{
    /// <summary>
    /// Contains methods to read, process and write to files synchronously
    /// </summary>
    public class SyncFileProcessor
    {
        /// <summary>
        /// Reads from file, writes to memory and then writes back to destination file
        /// </summary>
        /// <param name="sourceFilePath">Source file path to read data</param>
        /// <param name="destinationFilePath">Destination file path to write data</param>
        public static void ProcessAndSaveFile(string sourceFilePath, string destinationFilePath)
        {
            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            int chunkSize = 1024 * 1024;
            var buffer = new byte[chunkSize];
            using (var fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    int bytesRead;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            SaveFileToMemory(buffer, bytesRead, memoryStream);
                            ProcessMemoryStreamToUpperCase(memoryStream);
                            WriteMemoryToFile(memoryStream, destinationStream);
                        }
                    }
                }
            }
        }

        private static void ProcessMemoryStreamToUpperCase(MemoryStream memoryStream)
        {
            string originalText = Encoding.UTF8.GetString(memoryStream.ToArray());
            byte[] processedBytes = Encoding.UTF8.GetBytes(originalText.ToUpper());
            memoryStream.SetLength(0);
            memoryStream.Write(processedBytes, 0, processedBytes.Length);
            memoryStream.Position = 0;
        }

        private static void SaveFileToMemory(byte[] buffer, int bytesRead, MemoryStream memoryStream)
        {
            memoryStream.Write(buffer, 0, bytesRead);
        }

        private static void WriteMemoryToFile(MemoryStream memory, FileStream destinationStream)
        {
            memory.CopyTo(destinationStream);
        }
    }
}