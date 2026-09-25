namespace FileCreator
{
    /// <summary>
    /// Class contains constant values (like file size)
    /// </summary>
    public class FileConstants
    {
        /// <summary>
        /// Target File Size (1GB) in bytes
        /// </summary>
        public const long TargetFileSize = 1024L * 1024 * 1024;

        /// <summary>
        /// Chunk Size
        /// </summary>
        public const int ChunkSize = 4096;

        /// <summary>
        /// File Path for writing data to file using FileStreams
        /// </summary>
        public const string FileStreamPath = "FileStreamData.txt";

        /// <summary>
        /// File Path for writing data to file using File class
        /// </summary>
        public const string FilePath = "FileStreamData.txt";
    }
}
