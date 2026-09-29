# Assignment-18 : Async/Await, Task Parallel Library, and Multi-Threading in C#
 
## Task 1: Understanding and Implementing Async/Await

### Concept

Asynchronous Programming 

- Allows you to perform non-blocking execution.
- A method has to be marked as async, which expects another method call with await keyword in it.
- The await keyword provides a nonblocking way to start a task, then continue execution when the task completes.

---

HttpClient class

- Provides a class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
- HttpClient is completely thread-safe. Multiple threads can concurrently execute requests using a shared instance.
- HttpClient has to be instantiated once and can be reused throughout. (Create static readonly object)

---
## Implementation

### Program.cs

HttpClient Object: private static readonly HttpClient Client = new ();

Methods:

DownloadDataAsync()

- Downloads content from a URL using the HttpClient class.
- Returns the downloaded content as String.

---

Main()

- Calls the async method DownloadDataAsync() and waits for its result.
- After the DownloadDataAsync has returned result.
- The result is printed to the user.