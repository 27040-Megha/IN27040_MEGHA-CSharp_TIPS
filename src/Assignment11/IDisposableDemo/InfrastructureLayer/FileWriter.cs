using System;
using System.IO;

namespace IDisposableDemo.InfrastructureLayer
{
    /// <summary>
    /// File writer class that contains StreamWriter Object to write to files.
    /// </summary>
    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _streamWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="filePath">File Path</param>
        public FileWriter(string filePath)
        {
            this._streamWriter = new StreamWriter(filePath, true);
        }

        /// <summary>
        /// Writes to file using StreamWriter
        /// </summary>
        /// <param name="textToWrite">Text to write to the file</param>
        public void WriteFile(string textToWrite)
        {
            this._streamWriter.WriteLine(textToWrite);
            this._streamWriter.Flush();
        }

        /// <summary>
        /// Dispose method - Closes the file, Automatically called when using statement reaches end
        /// </summary>
        public void Dispose()
        {
            this._streamWriter.Close();
        }
    }
}
