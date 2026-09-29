using System.Collections.Generic;

namespace ListImplementation.InfrastructureLayer
{
    /// <summary>
    /// Contains a generic list to store the Book Titles and CRUD operation methods.
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class BookRepo<T>
    {
        private List<T> _bookList;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepo{T}"/> class.
        /// </summary>
        public BookRepo()
        {
            this._bookList = new List<T>();
        }

        /// <summary>
        /// Adds the book title to the BookList.
        /// </summary>
        /// <param name="bookTitle">Book Title to be added</param>
        public void AddBook(T bookTitle)
        {
            this._bookList.Add(bookTitle);
        }

        /// <summary>
        /// Remove the book title from the BookList.
        /// </summary>
        /// <param name="bookTitle">Book Title to be removed</param>
        public void RemoveBook(T bookTitle)
        {
            this._bookList.Remove(bookTitle);
        }

        /// <summary>
        /// Checks if a book title is found
        /// </summary>
        /// <param name="bookTitle">Book Title to be searched</param>
        /// <returns>true if book title is found, otherwise false</returns>
        public bool SearchBook(T bookTitle)
        {
            return this._bookList.Contains(bookTitle);
        }

        /// <summary>
        /// Returns all book title from the list.
        /// </summary>
        /// <returns>BookTitle list</returns>
        public List<T> ReturnBookList()
        {
            return this._bookList;
        }
    }
}
