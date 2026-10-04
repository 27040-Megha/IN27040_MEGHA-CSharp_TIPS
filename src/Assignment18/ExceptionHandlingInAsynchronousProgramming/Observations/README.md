# Assignment-18 : Async/Await, Task Parallel Library, and Multi-Threading in C#
 
## Task 7: Understanding the Difference between Async Void and Async Task with Exceptions

### Concept

Exception Handling in async Task Methods  :

- A try-catch block inside an async method can catch exceptions that occur within the awaited calls.
- If the task is never awaited (Fire and Forget), the exception is swallowed.

AggregateException

- When multiple tasks are executed together with Task.WhenAll, multiple exceptions can occur simultaneously. These are wrapped inside an AggregateException.

Exception Handling in async void Methods

- Exceptions that occur in async void methods will crash the application.
- Because their exceptions can't be awaited or caught by the caller.

Best Practice for Exception Handling in Asynchronous Programming:

- async methods should not be void.
- Follow async, await throught for all methods.
- Use a parent try-catch block, that catches the AggregateException (Multiple exceptions that are bubbled in the Task object) and handle it.

---
## Implementation

### Program.cs

Methods:

async void VoidMethod()

- Throws new exception.
- Crashes the Application.

---

async Task TaskMethod()

- Throws new exception.
- Exception will be bubbled in the Task object.
- The exception will be rethrown when the task is awaited using await.
- try-catch in the caller method can handle the exception there.

Main()

- Calls TaskMethod() and VoidMethod() within separate try-catch blocks.
- Catches the exception and logs it to user.