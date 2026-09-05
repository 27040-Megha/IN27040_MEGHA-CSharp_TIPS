using System;
using System.Collections.Generic;
using System.IO;

namespace IDisposableDemo.InfrastructureLayer
{
    /// <summary>
    /// File reader class that contains StreamReader Object to read from files.
    /// </summary>
    public class FileReader : IDisposable
    {
        private readonly StreamReader _streamReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filePath">File Path</param>
        public FileReader(string filePath)
        {
            this._streamReader = new StreamReader(filePath);
        }

        /// <summary>
        /// Reads from file using StreamReader until the end of the stream
        /// </summary>
        /// <returns>List of string - file data</returns>
        public List<string> ReadFile()
        {
            var result = new List<string>();
            while (!this._streamReader.EndOfStream)
            {
                result.Add(this._streamReader.ReadLine());
            }

            return result;
        }

        /// <summary>
        /// Dispose method - Closes the file, Automatically called when using statement reaches end
        /// </summary>
        public void Dispose()
        {
            this._streamReader.Close();
        }
    }
}
