## Error Handling in C# 
 
Overview
 
Implement Error Handling using various strategies such as try/catch/finally blocks, exceptions, custom exception classes, and global unhandled exception handling.

---
 
Task - 1:

- Handle DivideByZeroException
- Using try/catch/finally blocks

Task - 2:

- Handle IndexOutOfRangeException
- Catch and throw a new exception when an IndexOutOfRangeException occurs

Task - 3:

- Custom Exception class -  InvalidUserInputException
- If the user enters an invalid input, throw an InvalidUserInputException
- Catch it in View and Print the message

Task - 4:

- Uses AppDomain.UnhandledException event
- Invoked automatically when an unhandled exception is thrown
- Remove catch(FormatException ex) in View which will actually catch InvalidUserInputException from Service
- Define a method UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e) that handles and logs messages to user without crashing the app
- Subscribe this method to AppDomain.UnhandledException event

Task - 5:

- Print exception's stack trace in the method UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
- Understand about Stack trace 
---
	
##  Project Structure
```text
ErrorHandlingTasks
│
├── Domain
│   └── InvalidUserInputException.cs
│
├── ApplicationLayer
│   └── ErrorHandlingService.cs
│
├── PresentationLayer
│   ├── Helper
│   │   └── InputValidator.cs
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

Folder Structure
 
Domain
 
InvalidUserInputException.cs

- Custom exception class that inherits from Exception class
- public InvalidInputException(string message, Exception innerException) 
        : base(message, innerException) { }
- Constructor contains innerException object for re-throwing

---
 
ApplicationLayer
 
ErrorHandlingService.cs
 
Methods

- Divide(int a, int b)
		
		try
	    {  //divide a/b }
		catch (DivideByZeroException ex)
		{ throw new DivideByZeroException(ex)}

- GetFifthElement(int[] arr)

		try
        { //Access arr[4] }
        catch (IndexOutOfRangeException ex)
		{ throw new InvalidOperationException(ex)}

---

PresentationLayer

View

ConsoleOperations.cs
 
- Contains try with multiple catch blocks and a finally block.
- Inside try, gets user input and calls Helper for Validation and calls Service for Divide and Accessing array elements 
1. catch(InvalidInputException ex) - Prints the exception message  //For task-4, this will be removed and an unhandled run-time exception will be thrown, AppDomain.UnhandledException event will be invoked and the message and Stack trace will be printed

2. catch(DivideByZeroException ex) - Catch exception thrown from ApplicationLayer and Print Exception Message

3. catch(InvalidOperationException ex) - Service will catch IndexOutOfRangeException and throws InvalidOperationException which will be caught here
- Finally block will print the default message at last

Method

- UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e) - Prints exception message and Stack trace

---

Helper

InputValidator.cs

- Gets input from View and use int.Parse() inside try{}
- catch(FormatException ex) will throw new InvalidInputException(ex), which will be catched by View
---
 
Program
 
Program.cs
 
- Creates object for ApplicationLayer and PresentationLayer and inject their dependencies
- Subscribe UnhandledExceptionHandler to AppDomain.UnhandledException event - This is invoked automatically when an unhandled exception is thrown
- Contains a global try-catch block to catch global unhandled exceptions
 