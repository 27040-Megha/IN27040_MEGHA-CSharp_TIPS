using System.Collections.Generic;
using ListImplementation.InfrastructureLayer;

namespace ListImplementation.ApplicationLayer.Service
{
    /// <summary>
    /// Contains business logic to Add, Remove and Check if Book Title exists in the Repository.
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class BookService<T>
    {
        private BookRepo<T> _bookRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService{T}"/> class.
        /// </summary>
        /// <param name="bookRepo">InfrastructureLayer object</param>
        public BookService(BookRepo<T> bookRepo)
        {
            this._bookRepo = bookRepo;
        }

        /// <summary>
        /// Checks if a book title already exists and then adds to repo
        /// </summary>
        /// <param name="bookTitle">BookTitle to be added</param>
        /// <returns>true if successfully deleted; otherwise false</returns>
        public bool CreateBook(T bookTitle)
        {
            if (this.FindBook(bookTitle))
            {
                return false;
            }

            this._bookRepo.AddBook(bookTitle);
            return true;
        }

        /// <summary>
        /// Checks if a book title exists in the repo and then deletes
        /// </summary>
        /// <param name="bookTitle">Book title to be deleted</param>
        /// <returns>true if successfully deleted, otherwise false</returns>
        public bool DeleteBook(T bookTitle)
        {
            if (!this.FindBook(bookTitle))
            {
                return false;
            }

            this._bookRepo.RemoveBook(bookTitle);
            return true;
        }

        /// <summary>
        /// Checks if a book title exists in the repo
        /// </summary>
        /// <param name="bookTitle">Book title to be searched</param>
        /// <returns>true if book is found; otherwise false</returns>
        public bool FindBook(T bookTitle)
        {
            return this._bookRepo.SearchBook(bookTitle);
        }

        /// <summary>
        /// Returns the complete Book List from the repository
        /// </summary>
        /// <returns>List of Book title</returns>
        public List<T> GetBookList()
        {
            return this._bookRepo.ReturnBookList();
        }
    }
}
