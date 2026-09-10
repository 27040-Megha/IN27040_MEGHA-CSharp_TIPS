using System.Collections.Generic;
using ListImplementation.InfrastructureLayer;

namespace ListImplementation.ApplicationLayer.Service
{
    public class BookService<T>
    {
        private BookRepo<T> _bookRepo;

        public BookService(BookRepo<T> bookRepo)
        {
            this._bookRepo = bookRepo;
        }

        public bool CreateBook(T bookTitle)
        {
            if (this.FindBook(bookTitle))
            {
                return false;
            }

            this._bookRepo.AddBook(bookTitle);
            return true;
        }

        public bool DeleteBook(T bookTitle)
        {
            if (!this.FindBook(bookTitle))
            {
                return false;
            }

            this._bookRepo.RemoveBook(bookTitle);
            return true;
        }

        public bool FindBook(T bookTitle)
        {
            return this._bookRepo.SearchBook(bookTitle);
        }

        public List<T> GetBookList()
        {
            return this._bookRepo.ReturnBookList();
        }
    }
}
