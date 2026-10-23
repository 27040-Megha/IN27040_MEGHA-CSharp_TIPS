namespace MockingFramework
{
    /// <summary>
    /// Provides a contract for implementing classes
    /// </summary>
    public interface IDownloadable
    {
        /// <summary>
        /// Download file in pdf format
        /// </summary>
        /// <returns>String representing pdf file format</returns>
        public string DownloadPdf();

        /// <summary>
        /// Download file in Word format
        /// </summary>
        /// <returns>String representing Word docx file format</returns>
        public string DownloadDocx();
    }
}
