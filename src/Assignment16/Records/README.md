# Assignment-16: C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 

## Task 6: Implementing and Manipulating Records

Create a console application that demonstrates the use and benefits of records.

- Define a record Book with properties Title, Author, and ISBN. 
- In your Main method, declare a few Book records and display their details in the console. 
- Demonstrate the value equality of records by creating two Book records with the same property values. Compare them using the == operator and print the result. 
- Show the immutability of records by trying to change a property of a Book record after its declaration. Observe the result. 
- Use the with keyword to create a new Book record based on an existing one but with one or more properties changed. Print both records to show that the original has not been modified.  
- Implement a method DisplayBook that takes a Book record and uses deconstruction to print its properties. 

---
## Book.cs (Record)

- Properties: Title, Author, ISBN
- Method: void Deconstruct(out string title, out string author, out string isbn) - Deconstructs the properties of class

---

# Program.cs

## Methods:

## void DisplayBook(Book book)

- Deconstructs the book record and prints it to Console.

## void DisplayValueEquality(Book firstBook, Book secondBook, Book thirdBook)

- Calls and the CheckValueEquality method whether two records value are equal.

## bool CheckValueEquality(Book firstBook, Book secondBook)

- Checks whether the value of two instances are equal.

## void UpdateBookTitle(Book book)

- Try to update property of book record.


             Records are primarily intended to support immutable data models
             In Book Record, the properties are defined as init-only property
             Properties can be set only during object creation and can't be modified later - Throws Compile-Time error when trying to change a property of Book record
             CS8852: Init-only property or indexer 'property' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
             book.Title = "The Jungle Book";

## Book CreateNewBook(Book firstBook)

- Creates new book record using with keyword 
- Can change any of the property

## Main()

- Create 3 Book records
- Call all the above methods to observe the behaviour of records