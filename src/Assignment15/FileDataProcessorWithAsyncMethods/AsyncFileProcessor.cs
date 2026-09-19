using System.Text;

namespace FileDataProcessorWithAsyncMethods
{
    public class AsyncFileProcessor
    {
        public static async Task ProcessAndSaveFileAsync(string sourceFilePath, string destinationFilePath)
        {
            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            int chunkSize = 4096;
            var buffer = new byte[chunkSize];
            using (var fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, chunkSize, useAsync: true))
            {
                using (var bufferedStream = new BufferedStream(fileStream, 1024 * 1024))
                {
                    using (var destinationStream = new FileStream(destinationFilePath, FileMode.Append, FileAccess.Write, FileShare.None, 4096, useAsync: true))
                    {
                        int bytesRead;
                        while ((bytesRead = await bufferedStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
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
