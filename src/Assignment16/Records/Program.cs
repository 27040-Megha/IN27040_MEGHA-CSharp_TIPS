using System;
using Records;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var firstBook = new Book()
            {
                Title = "Jungle Book",
                Author = "Rudyard Kipling",
                ISBN = "1234-1234-1234",
            };

            var secondBook = new Book()
            {
                Title = "Harry Potter",
                Author = "J.K. Rowling",
                ISBN = "5678-5678-5678",
            };

            var thirdBook = new Book()
            {
                Title = "Jungle Book",
                Author = "Rudyard Kipling",
                ISBN = "1234-1234-1234",
            };
            DisplayBook(firstBook);
            DisplayBook(secondBook);
            DisplayBook(thirdBook);
            DisplayValueEquality(firstBook, secondBook, thirdBook);
            UpdateBookTitle(firstBook);
            var newBook = CreateNewBook(firstBook);
            Console.WriteLine(DisplayResource.NewBook);
            DisplayBook(newBook);
            DisplayBook(firstBook);
        }

        private static void DisplayValueEquality(Book firstBook, Book secondBook, Book thirdBook)
        {
            Console.WriteLine(string.Format(DisplayResource.CompareBook1With2, CheckValueEquality(firstBook, secondBook)));
            Console.WriteLine(string.Format(DisplayResource.CompareBook1With3, CheckValueEquality(firstBook, thirdBook)));
        }

        private static void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;
            Console.WriteLine(string.Format(DisplayResource.DisplayBook, title, author, isbn));
        }

        private static bool CheckValueEquality(Book firstBook, Book secondBook)
        {
            return firstBook == secondBook;
        }

        private static void UpdateBookTitle(Book book)
        {
            // Records are primarily intended to support immutable data models
            // In Book Record, the properties are defined as init-only property
            // Properties can be set only during object creation and can't be modified later - Throws Compile-Time error when trying to change a property of Book record
            // CS8852: Init-only property or indexer 'property' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
            // book.Title = "The Jungle Book";
        }

        private static Book CreateNewBook(Book firstBook)
        {
            return firstBook with { Title = "THE JUNGLE BOOK" };
        }
    }
}