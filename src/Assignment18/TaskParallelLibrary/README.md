# Assignment-18 : Async/Await, Task Parallel Library, and Multi-Threading in C#
 
##  Task 2: Implementing and Understanding Task Parallel Library

### Concept

### Task Parallel Library

- Collection of APIs for parallel and asynchronous programming.
- Namespace: System.Threading.Tasks
- Task class: Unit of work that can be executed asynchronously on a separate thread.
---

### Parallel.ForEach

- Used to execute loop parallely.
- Useful for processing large collections, where each iteration of loop will be executed independently.
- Optimizes the use of available CPU cores.

### Where to use Parallel.For vs Parallel.ForEach

Parallel.For:

- Input: Index Range.
- Best for Arrays, Structures or fixed numeric sequence loops.
- Index Access: Built-in.

Parallel.ForEach:

- Input: Any collection implementing IEnumerable&lt;T&gt;
- Best for Lists, Collections and enumerables where index is not strictly required.
- Index Access: Explictly should be given.

---
## Implementation

### Program.cs

CalculateSquareSequentially()

- Calculate squares of array elements sequentially using a for loop.

CalculateSquareParallelly()

- Calculate squares of array elements using Parrallelly using Parallel.For/Parallel.ForEach.

DisplayArray()

- Display the squares of array elements after calculating their squares.

Main()

Time Taken to process large Data from 1 to 1000000000:

Using Parallel.ForEach: 32844 ms 
Using Parallel.For: 3396 ms
Sequentially: 5438 ms

Best Option for this Task to calculate square of array elements parallely: Parallel.For

---