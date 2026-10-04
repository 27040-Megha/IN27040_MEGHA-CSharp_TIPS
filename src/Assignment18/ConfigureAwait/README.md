# Assignment-18 : Async/Await, Task Parallel Library, and Multi-Threading in C#
 
## Task 6: Real-World Application of ConfigureAwait in a Console Application with Tread Tracking
### Concept

- ConfigureAwait(false) - The code after the await resumes on any available thread pool thread.
- ConfigureAwait(true) - The code after the await is forced back onto the original thread environment.

---
## Implementation

### Program.cs

Methods:

MethodA()

- Performs a CPU bound operation (complex calculataion).
- await Task.Delay(1500).ConfigureAwait(false) - Releases the thread.
- ConfigureAwait(false) will resume the code after await in any available thread in the threadpool.
- This can be observed by viewing their managed ID before and after the await call of this method.

---

MethodB()

- Prints the managed thread ID before the await call.
- Calls method MethodA().
- After resumed, prints the managed thread ID.
- From this we can find that the remaining continuation of the MethodB() will be executed by different thread.

Main()

- Awaits MethodB() and gets the result.
- The result is printed to the user.

---

OUTPUT:

Thread ID before awaiting MethodA: 1
Thread ID after awaiting MethodA: 9
Result is: 0

- We can observe that different thread has resumed the execution of the remaining code.