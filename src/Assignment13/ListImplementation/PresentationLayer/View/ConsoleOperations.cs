using System;
using System.Linq;
using ConsoleUtilities;
using InputValidator;
using ListImplementation.ApplicationLayer.Service;

namespace ListImplementation.PresentationLayer.View
{
    /// <summary>
    /// Contains all methods that interacts with the user by getting input and displaying expected outcome
    /// </summary>
    public class ConsoleOperations
    {
        private BookService<string> _bookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="bookService">BookService object</param>
        public ConsoleOperations(BookService<string> bookService)
        {
            this._bookService = bookService;
        }

        /// <summary>
        /// Initial method that is called from Program.cs
        /// </summary>
        public void Run()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.AddBookTitle, ConsoleColor.Cyan);
            this.AddBookTitle();
            this.DisplayBookTitle();
            this.RemoveBookTitle();
            this.DisplayBookTitle();
            this.SearchBookTitle();
        }

        private string GetBookTitle()
        {
            Console.Write(DisplayResource.PromptBookTitle);
            string bookTitle = Console.ReadLine();
            if (!StringValidator.ValidateString(bookTitle))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.InputStringError, ConsoleColor.Red);
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
                    ConsoleLogger.WriteColorLine(DisplayResource.DuplicateBookError, ConsoleColor.Red);
                    return;
                }
            }
        }

        private void RemoveBookTitle()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.RemoveBookTitle, ConsoleColor.Cyan);
            string bookTitleToRemove = this.GetBookTitle();
            if (bookTitleToRemove == null)
            {
                return;
            }

            if (!this._bookService.DeleteBook(bookTitleToRemove))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.BookNotFoundError, ConsoleColor.Red);
                return;
            }

            ConsoleLogger.WriteColorLine(DisplayResource.SuccessfulDeletion, ConsoleColor.Green);
        }

        private void SearchBookTitle()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.SearchBookTitle, ConsoleColor.Cyan);
            string bookTitleToSearch = this.GetBookTitle();
            if (bookTitleToSearch == null)
            {
                return;
            }

            if (!this._bookService.FindBook(bookTitleToSearch))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.BookNotFound, ConsoleColor.Red);
                return;
            }

            ConsoleLogger.WriteColorLine(DisplayResource.BookTitleFound, ConsoleColor.Green);
        }

        private void DisplayBookTitle()
        {
            var bookList = this._bookService.GetBookList();
            if (!bookList.Any())
            {
                ConsoleLogger.WriteColorLine(DisplayResource.NoBookFound, ConsoleColor.Red);
                return;
            }

            ConsoleLogger.WriteColorLine(DisplayResource.BookListHeading, ConsoleColor.Cyan);
            foreach (var bookTitle in bookList)
            {
                Console.WriteLine($"{bookTitle}");
            }
        }
    }
}
