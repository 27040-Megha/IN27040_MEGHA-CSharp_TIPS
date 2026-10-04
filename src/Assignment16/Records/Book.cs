namespace Records
{
    public record Book
    {
        /// <summary>
        /// Gets or Initializes Book Title
        /// </summary>
        /// <value>
        /// Book Title
        /// </value>
        public string Title { get; init; }

        /// <summary>
        /// Gets or Initializes Author of Book
        /// </summary>
        /// <value>
        /// Book Author
        /// </value>
        public string Author { get; init; }

        /// <summary>
        /// Gets or Initializes Book ISBN
        /// </summary>
        /// <value>
        /// ISBN of Book
        /// </value>
        public string ISBN { get; init; }

        /// <summary>
        /// Deconstructs a book record with its properties
        /// </summary>
        /// <param name="title">Book Title</param>
        /// <param name="author">Author</param>
        /// <param name="isbn">ISBN</param>
        public void Deconstruct(out string title, out string author, out string isbn)
        {
            title = this.Title;
            author = this.Author;
            isbn = this.ISBN;
        }
    }
}
