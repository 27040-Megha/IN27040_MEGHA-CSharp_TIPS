# Assignment-18 : Async/Await, Task Parallel Library, and Multi-Threading in C#
 
## Task 4: Implementing Multi-Layered Async/Await Operations in a Real-World Scenario 

### Concept

IO bound operations:

- Waiting for data to arrive from external system.
- The thread has no work to do while waiting.
- Eg: Fetching data from an URI using HttpClient.
- Use async/await.

CPU bound operations:

- The CPU waits for complex calculations to complete.
- The thread will be active throughout.
- Eg: Performing heavy calculations.
- Use Task.Run()

---
## Implementation

- Mix asynchronous programming (I/O-bound operations) with multi-threading (CPU-bound operations) without blocking system execution threads.

### Program.cs

- Method calling

```Main() -> MethodC() -> MethodB() -> MethodA()```

- Each method waits for the result from the awaited method callS

```Main() <- MethodC() <- MethodB() <- MethodA()```

Methods:

MethodA()

- Performs heavy calculations inside Task.Run().
- Thread will be freezed until it completes the calculation.
- Returns a resource title required for URI, which MethodB() needs.

---
 
MethodB()

- Waits for MethodA to complete its execution.
- Fetches data from URI using HttpClient and returns the downloaded data.
- Thread will be released to ThreadPool while waiting for the data to download.
- Returns the downloaded response.

---

MethodC()

- Waits for MethodB and gets the downloaded data.
- Using JsonSerializer.Deserialize(), the data will be deserialized as key-value pairs.
- Count the number of key-value pairs and return.

---

Main()

- Wait for MethodC, and print the number of key-value pairs in the resource.

---

Takeaway:

- If MethodA or MethodB throws an error (like a bad web URL or a network disconnect), the execution will be stopped and error will jump into Main's catch block.
- Since we awaiting calls, the application will completely be responsive even if any operation takes too long time.
- But the final result we be still delayed because we have to wait for each method to complete its execution and return result because of the method chaining.