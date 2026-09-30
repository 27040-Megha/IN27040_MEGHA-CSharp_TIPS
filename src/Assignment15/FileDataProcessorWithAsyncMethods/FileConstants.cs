namespace FileCreator
{
    /// <summary>
    /// Class contains constant values (like file size)
    /// </summary>
    public class FileConstants
    {
        /// <summary>
        /// Buffer Size
        /// </summary>
        public const int BufferSize = 1024 * 1024;

        /// <summary>
        /// Chunk Size
        /// </summary>
        public const int ChunkSize = 4096;

        /// <summary>
        /// File Path for writing data to file using File class
        /// </summary>
        public const string FilePath = "FileData.txt";

        /// <summary>
        /// File Path for writing processed data to file using File class
        /// </summary>
        public const string ProcessedFilePath = "ProcessedData.txt";
    }
}
