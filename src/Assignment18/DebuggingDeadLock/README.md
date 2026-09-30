# Assignment-18 : Async/Await, Task Parallel Library, and Multi-Threading in C#
 
## Task 5: Debugging and Fixing Deadlock Conditions

### Concept

### Task.Result

- Task.Result gets the value produced by a completed asynchronous task.
- ISSUE: Accessing .Result on an unfinished task synchronously blocks the current thread until the task finishes.
- This causes deadlock.

### Synchronization Context

- Ensures that after an await finishes, control must return to the original thread that started it.
- For console applications, this will be null.

---

### Issue identified in code

var result = SomeAsyncOperation().Result; 

- When SomeAsyncOperation executes await Task.Delay(1000), it captures the current thread's synchronization context to resume execution on the same thread once the delay completes.
- Meanwhile, DeadlockMethod calls .Result on the task returned by SomeAsyncOperation. This synchronously blocks the main thread until the task finishes.
- When the delay finishes, SomeAsyncOperation attempts to return to the captured synchronization context to complete the method and return "Hello, World!".
- It cannot resume because that context is being held by .Result. The two operations wait for each other indefinitely.

### Solution

- Remove .Result and use await keyword.
- This frees up the thread during execution of SomeAsyncOperation method.

---

### No deadlock was observed

- Console Applications do not have SynchronizationContext by default.
- So, when await Task.Delay(1000) finishes, it doesn't care what thread it resumes on.
- It simply grabs any available thread from the ThreadPool to complete the method and returns "Hello, World!".
- Deadlock will be observed in WPF applications where everything must resume on the main UI thread.

---