# Assignment-15: Working with Files and Streams

## Task 3: Investigate issues in basic file usage

- Identify the issue in the code snippet.
- Modify the code to fix the memory issue.
- Explain how you identified and fixed the issue.

---

## Memory Issues identified in the given code Snippet

1. Using MemoryStream to write to memory, then getting data from MemoryStream to read using FileStream is a memory overhead.
2. FileStreams require byte data, so raw data has to be converted to bytes and stored in a byte[] which will occupy space in Managed heap.
3. Using a for loop to write each data is inefficient, heavy IO operation is performed here.

## Solution 

1. Removed Memorystream completely.
2. Used StreamReader and StreamWriter instead of FileStreams as they can read/write raw data directly.
3. Removed for loop and read data at once completely and printed using Console.WriteLine().
4. Use Console.WriteLine(), only if needed because printing to console is also an expensive IO operation.

With all these Optimizations, there is no need of byte array(managed at heap), RAM memory, Converting to byte array and inefficient loop to print the file data

## How memory Issue was identified

- Using Diagnostic tool, to find memory occupied in the managed heap.
- Using Task Manager, to find memory occupied in the RAM.
- Used GC.GetTotalAllocatedBytes() to know memory allocated in the heap.
- Used Process.GetCurrentProcess() - Returns all information about the actively running process.
- CurrentProcess.WorkingSet64 - Returns the amount of physical memory in bytes allocated for the process.

## Performance Difference when tested for large test data of size 10 MB
```
Given Code Snippet
Performance Metrics
Execution Time: 72
Heap Allocated : 26220488
Physical RAM Consumed: 26574848
 
Optimized Version of Code
Performance Metrics
Execution Time: 42
Heap Allocated : 10502120
Physical RAM Consumed: 10567680
```
