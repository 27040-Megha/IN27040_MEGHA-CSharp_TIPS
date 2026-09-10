using System.Collections.Generic;

namespace ListImplementation.InfrastructureLayer
{
    public class BookRepo<T>
    {
        private List<T> _bookList = new List<T>();

        public void AddBook(T bookTitle)
        {
            this._bookList.Add(bookTitle);
        }

        public void RemoveBook(T bookTitle)
        {
            this._bookList.Remove(bookTitle);
        }

        public bool SearchBook(T bookTitle)
        {
            return this._bookList.Contains(bookTitle);
        }

        public List<T> ReturnBookList()
        {
            return this._bookList;
        }
    }
}
