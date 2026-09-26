using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileDataProcessorWithAsyncMethods
{
    /// <summary>
    /// Contains asynchronous methods to read, process and write to files
    /// </summary>
    public class AsyncFileProcessor
    {
        /// <summary>
        /// Reads from file, writes to memory and then writes back to destination file asynchronously
        /// </summary>
        /// <param name="sourceFilePath">Source file path to read data</param>
        /// <param name="destinationFilePath">Destination file path to write data</param>
        /// <returns>Asynchronous result object</returns>
        public static async Task ProcessAndSaveFileAsync(string sourceFilePath, string destinationFilePath)
        {
            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            int chunkSize = 1024 * 1024;
            var buffer = new byte[chunkSize];
            using (var fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, chunkSize, useAsync: true))
            {
                using (var destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, chunkSize, useAsync: true))
                {
                    int bytesRead;
                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await SaveFileToMemoryAsync(buffer, bytesRead, memoryStream);
                            ProcessMemoryStreamToUpperCase(memoryStream);
                            await WriteMemoryToFile(memoryStream, destinationStream);
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

        private static async Task SaveFileToMemoryAsync(byte[] buffer, int bytesRead, MemoryStream memoryStream)
        {
            await memoryStream.WriteAsync(buffer, 0, bytesRead);
        }

        private static async Task WriteMemoryToFile(MemoryStream memory, FileStream destinationStream)
        {
            await memory.CopyToAsync(destinationStream);
        }
    }
}
