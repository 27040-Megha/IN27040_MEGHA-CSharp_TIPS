# Assignment-13 : Understanding and Practicing Collections and Generics in C# 
 
## Overview
 
Understanding of collections, their operations, and how generics can be applied in C#.
Each task involves the usage of different type of Collections.

- Task 1: Working with Lists 
- Task 2: Using Stacks 
- Task 3: Working with Queues 
- Task 4: Understanding Dictionaries 
- Task 5: Applying Generic Collections 
- Task 6: Understanding IEnumerable, Concrete Types, and IReadOnlyDictionary 

---

##  Folder Structure
```text
Assignment13
|
├── InputValidator (Class Library .dll)
|
├── ListImplementation (Console Application)
|
├── StackImplementation (Console Application)
|
├── QueueImplementation (Console Application)
|
├── DictionaryImplementation (Console Application)
|
├── ReadOnlyCollections (Console Application)
```

## InputValidator

- Create this project as a Class Library that generates only .dll
- Contains a class `StringValidator` that contains method `ValidateString(string input)` - Can be used to check whether a string is valid or not.
- Contains a class `IntegerValidator` that contains method `ValidateInteger(string input, out int number)` - Can be used to check whether a string can be parsed to a valid Integer and also returns the valid number using out.
- Build this project and use this project reference in the remaining projects to validate inputs.

---

## Task 1 - Working with Lists

- Use a List to store a collection of book titles(string)
- Add 5 book titles, Remove a book, Check if a particular book is in the list, Display all the books in the list

##  Project Structure
```text
ListImplementation
|
├── InfrastructureLayer
│   └── BookRepo.cs
|
├── ApplicationLayer
│   └── Service
│      └── BookService.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

# Folder Structure

# InfrastructureLayer

## BookRepo.cs

- Contains a generic list to store the Book Titles and CRUD operation methods.

Field

- List &lt;T&gt; BookList

Methods

- void AddBook(T bookTitle) - Adds the book title to the BookList.
- void RemoveBook(T bookTitle) - Remove the book title from the BookList.
- bool SearchBook(T bookTitle) - Returns true if book title is found, otherwise returns false.
- List &lt;T&gt; ReturnBookList - Returns all book title from the list.
 
---

# ApplicationLayer

# Service
 
## BookService.cs

- Contains business logic to Add, Remove and Check if Book Title exists in the Repository.
 
Method

- void CreateBook(T bookTitle) - Adds the book title to the repository.
- void DeleteBook(T bookTitle) - Remove the book title from the repository.
- bool FindBook(T bookTitle) - Returns true if book title is found, otherwise returns false.
- List &lt;T&gt; GetBookList - Returns all book title from the list.

---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Gets Book Title from the user for Adding, Removing and Searching Books and Displays the Result to the user.

Methods

- void Run()
- string GetBookTitle() - Gets input from user and validates the input by using InputValidator Project reference.
- void AddBookTitle() 
- void RemoveBookTitle() 
- void SearchBookTitle() 
- void DisplayBookTitle() 
---

## Program.cs
 
- Creates object for InfrastructureLayer, ApplicationLayer, PresentationLayer and inject their dependencies and start the application by using Run().
---

## Task 2 - Working with Stack

- Use a stack of characters to reverse a string.

##  Project Structure
```text
StackImplementation
|
├── ApplicationLayer
│   └── Service
│      └── StringReversalService.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

# Folder Structure

# ApplicationLayer

# Service
 
## StringReversalService.cs

- Contains business logic to reverse a string using Stack.

Field

- Stack&lt;T&gt; wordStack 

Method

- void PushToStack(T character) - Pushes the character to the stack.
- T PopFromStack() - Returns the popped character from the stack.
- String ReverseString(string word) - Call PushToStack to push each character and then pop from the stack and append it to new string and return the result.
---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Get a word from user as input and display the original string and reversed string

Methods

- void Run()
- string GetWord() - Gets input string to be reveresed.
- void DisplayWord(string word)
- void ReverseWord(string word)
---

## Program.cs
 
- Creates object for ApplicationLayer, PresentationLayer and inject their dependencies and start the application by using Run().
---

## Task 3 - Working with Queues

- Use a queue to store a queue of people waiting with the person's name(string)
- Add 5 people to Queue, Remove a person from Queue, Display all people in the Waiting Queue

##  Project Structure
```text
QueueImplementation
|
├── InfrastructureLayer
│   └── QueueRepo.cs
|
├── ApplicationLayer
│   └── Service
│      └── QueueService.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

# Folder Structure

# InfrastructureLayer

## QueueRepo.cs

- Contains a generic queue to store the People names and CRUD operation methods.

Field

- Queue &lt;T&gt; WaitingQueue

Methods

- void AddPeople(T person) - Enqueues the person name to the WaitingQueue.
- void RemovePeople() - Dequeues the firstly entered person from the WaitingQueue.
- List &lt;T&gt; ReturnWaitingQueue - Returns all people currently in the WaitingQueue.
 
---

# ApplicationLayer

# Service
 
## BookService.cs

- Contains business logic to Enqueue People and Dequeue people from WaitingQueue in repository.
 
Method

- void EnqueuePeople(T person) - Sends the person name to enqueue in the Repo.
- void DequeuePeople() - Calls repo to dequeue firstly entered the person from the WaitingQueue.
- List &lt;T&gt; GetWaitingQueue - Returns all people currently in the WaitingQueue.
 
---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Gets Person Name from user and displays output to user.

Methods

- void Run()
- string GetPersonName() - Gets input from user and validates the input by using InputValidator Project reference.
- void AddPerson() 
- void RemovePerson() 
- void DisplayWaitingQueue() 
---

## Program.cs
 
- Creates object for InfrastructureLayer, ApplicationLayer, PresentationLayer and inject their dependencies and start the application by using Run().
---

## Task 4 - Working with Dictionaries

- Use a dictionary to map Student's name to their grade.
- Add 5 students and their grade to Dictionary, Remove a student from dictionary, Display all students and their grades.

##  Project Structure
```text
DictionaryImplementation
|
├── InfrastructureLayer
│   └── StudentRepo.cs
|
├── ApplicationLayer
│   └── Service
│      └── StudentService.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

# Folder Structure

# InfrastructureLayer

## StudentRepo.cs

- Contains a generic dictionary to map student name with their grades and CRUD operation methods.

Field

- Dictionary &lt;Tkey, TValue&gt; StudentResult

Methods

- void AddStudentResult(Tkey studentName, TResult grade ) - Adds the Student Name and grade as a key-value pair to the dictionary.
- void RemoveStudent(TKey studentName) - Removes the student result based on the key (studentName).
- List &lt;T&gt; ReturnStudentResult - Returns the StudentResult dictionary.
---

# ApplicationLayer

# Service
 
## StudentService.cs

- Contains business logic to perform operations, Interact with repository and returns result to the presentation layer.
 
Method


- void CreateStudentResult(Tkey studentName, TResult grade ) - Sends the Student name and grade details to adds them as a key-value pair to the dictionary.
- void DeleteStudent(TKey studentName) - Removes the student result based on the key (studentName).
- List &lt;T&gt; GetStudentResult - Fetches the StudentResult dictionary from repo.
---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Interacts with user to get input and display the expected output.
- Interacts with the ApplicationLayer to perform the necessary business operations.

Methods

- void Run()
- string GetStudentName() - Gets input from user and validates the input by using InputValidator.StringValidator class.
- int GetGrade() - Gets input from user and validates the input by using InputValidator.IntegerValidator class.
- void AddStudentGrade() 
- void RemoveStudentGrade() 
- void DisplayStudentGrade() 
---

## Program.cs
 
- Creates object for InfrastructureLayer, ApplicationLayer, PresentationLayer and inject their dependencies and start the application by using Run().
---

## Task - 5: Applying Generic Collections

- Convert the previous tasks to use generic collections, if they aren't already. 

---


## Task 6 - Working with IEnumerable, Concrete Types, IReadOnlyDictionary

##  Project Structure
```text
ReadOnlyCollections
|
├── ApplicationLayer
│   └── Service
│      └── CollectionsService.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

# Folder Structure

# ApplicationLayer

# Service
 
## CollectionsService.cs

Method

- int SumOfElements(IEnumerable&lt;int&gt; collection) - Calculate and return the sum of all elements in the IEnumerable collection
- IReadOnlyDictionary&lt;string, int&gt; GenerateDictionary() - Creates a dictionary object and returns it as ReadOnly collection.
---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Interacts with user to get input and display the expected output.
- Interacts with the ApplicationLayer to perform the necessary business operations.

Methods

- void Run()
- void SumOfArrayElements() - Calls the `SumOfElements` in service to calculate sum of array elements.
- void SumOfListElements() - Calls the `SumOfElements` in service to calculate sum of list elements.
- void SumOfQueueElements() - Calls the `SumOfElements` in service to calculate sum of queue elements.
- void PrintDictionary(IReadOnlyDictionary&lt;string&gt; collection) - Print the dictionary
- void ModifyDictioanry(IReadOnlyDictionary&lt;string&gt; collection) - Try modifying the ReadOnly collection and check if exception occurs (It should throw an error because IReadOnlyDictionary is immutable).
---

## Program.cs
 
- Creates object for InfrastructureLayer, ApplicationLayer, PresentationLayer and inject their dependencies and start the application by using Run().
---