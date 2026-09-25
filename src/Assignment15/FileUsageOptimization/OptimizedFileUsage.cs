using System;
using System.IO;
using System.Text;

namespace FileUsageOptimization
{
    /// <summary>
    /// Optimized version of code
    /// </summary>
    public class OptimizedFileUsage
    {
        /// <summary>
        /// 1. Removed using memory stream to write to files
        /// 2. Used StreamReader and StreamWriter directly instead of FileStreams because FileStreams require Encoding to byte array and write to file
        /// 3. Removed for loop to write the data read from files
        /// 4. Directly printed the contents read from the file
        /// With these optimizations, there is no need of byte array(managed at heap), RAM memory, Encoding and inefficient loop to print the file data
        /// </summary>
        /// <param name="path">File Path</param>
        public static void Run(string path)
        {
            string data = "This is some test data";
            using (var writer = new StreamWriter(path, false))
            {
                writer.Write(data);
            }

            using (var reader = new StreamReader(path))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
