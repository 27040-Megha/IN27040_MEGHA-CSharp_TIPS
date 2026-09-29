# Assignment-18 : Async/Await, Task Parallel Library, and Multi-Threading in C#
 
## Task 3: Advanced Understanding and Usage of Multi-Threading

### Concept

Multithreading

- Thread: Execution unit within a process.
- Process needs a thread to run.
- Multithreading: Runs multiple threads concurrently or parallely.
- Each thread has its own call stack, and share managed heap.
- Thread.Join() : Waits for the respective thread to complete its execution, otherwise the main thread will complete its execution and exits.
- Difference between Task and Thread: Threads does not return anything, While Tasks can return data.
___

## Implementation

### Program.cs

Methods

- int CalculateSum(int[] array) - Returns the sum of array elements.
- void SortArray(int[] array) - Sort the given array elements.
- int FindAverage(int[] array) - Returns the average of array elements.
- DisplayResult(int sum, int average, int[] array) - Displays sum, average and calls DisplayArray.
- void DisplayArray(int[] array) - Displays array elements.

Main()

- Creates 3 threads.
- Each thread will run parallelly and executes CalculateSum, SortArray and FindAverage.
- Using Thread.Join(), wait for threads to complete its execution.
- Print Result using DisplayResult
