using System;
using System.Linq;
using InputValidator;
using ListImplementation.ApplicationLayer.Service;

namespace ListImplementation.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private BookService<string> _bookService;

        public ConsoleOperations(BookService<string> bookService)
        {
            this._bookService = bookService;
        }

        public void Run()
        {
            Console.WriteLine("\nAdd 5 Book Titles to Repo:");
            this.AddBookTitle();
            this.DisplayBookTitle();
            this.RemoveBookTitle();
            this.DisplayBookTitle();
            this.SearchBookTitle();
        }

        private string GetBookTitle()
        {
            Console.WriteLine("Enter Book Title: ");
            string bookTitle = Console.ReadLine();
            if (!StringValidator.ValidateString(bookTitle))
            {
                Console.WriteLine("Book Title should not be null or empty, and should contain only characters");
                return null;
            }

            return bookTitle;
        }

        private void AddBookTitle()
        {
            for (int i = 0; i < 5; i++)
            {
                string bookTitle = this.GetBookTitle();
                if (bookTitle == null)
                {
                    return;
                }

                if (!this._bookService.CreateBook(bookTitle))
                {
                    Console.WriteLine("Duplicate Book Title found, Cannot add book to Repo");
                    return;
                }
            }
        }

        private void RemoveBookTitle()
        {
            Console.WriteLine("\nRemove Book Title: ");
            string bookTitleToRemove = this.GetBookTitle();
            if (bookTitleToRemove == null)
            {
                return;
            }

            if (!this._bookService.DeleteBook(bookTitleToRemove))
            {
                Console.WriteLine("Cannot delete, No Book with this book title found");
                return;
            }

            Console.WriteLine("Successfully Deleted!");
        }

        private void SearchBookTitle()
        {
            Console.WriteLine("\nSearch for Book");
            string bookTitleToSearch = this.GetBookTitle();
            if (bookTitleToSearch == null)
            {
                return;
            }

            if (!this._bookService.FindBook(bookTitleToSearch))
            {
                Console.WriteLine("No Book found with the title");
                return;
            }

            Console.WriteLine("Book Title Found!");
        }

        private void DisplayBookTitle()
        {
            var bookList = this._bookService.GetBookList();
            if (!bookList.Any())
            {
                Console.WriteLine("No Books found!");
                return;
            }

            Console.WriteLine("\nBooks in the Book List");
            foreach (var bookTitle in bookList)
            {
                Console.WriteLine($"{bookTitle}");
            }
        }
    }
}
