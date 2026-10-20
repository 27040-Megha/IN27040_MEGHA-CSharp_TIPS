using System;

namespace Library
{
    /// <summary>
    /// Class definition for Book, that contains fields, methods, properties and events
    /// </summary>
    public class Book
    {
        private static int totalBooks;

        private string _bookName;

        private event EventHandler OnBookNameChanged;

        /// <summary>
        /// Gets or sets value for the private backing field _bookName
        /// </summary>
        /// <value>
        /// Book Name
        /// </value>
        public string BookName
        {
            get => this._bookName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Book name cannot be null or empty");
                }

                this._bookName = value;
            }
        }

        private string Author { get; set; }

        private string GetBookDetails()
        {
            return $"Book Title: {this.BookName}, Author name: {this.Author}";
        }
    }
}