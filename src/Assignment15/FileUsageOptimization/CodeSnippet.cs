using System.Text;

namespace FileUsageOptimization
{
    /// <summary>
    /// Contains Run method to execute the given code snippet
    /// </summary>
    public static class CodeSnippet
    {
        /// <summary>
        /// Runs the given code snippet with memory inefficiences
        /// </summary>
        public static void Run()
        {
            string path = "file.txt";
            string data = "This is some test data";
            using (var memoryStream = new MemoryStream())
            {
                var buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    var writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.Write((char)buffer[i]);
                    }
                }
            }
        }
    }
}
