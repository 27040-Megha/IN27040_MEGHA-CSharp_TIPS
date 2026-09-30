# Assignment-15: Working with files and streams.

## Task 2: Implement a File Data Processor with Asynchronous Methods

- Implement asynchronous versions of the read, process, and write methods. 

- Modify the application to process multiple files concurrently. 

- Compare the performance of the synchronous and asynchronous versions of the code. 

---

## Concept

### Synchronous Operations 

- When a process is executed synchronously, the thread executing that process is blocked.
- The thread will be completely freezed until it completes the process execution.
- The problem here is, OS threads are expensive resources.
- So if we want to process 100 files concurrently, 100 threads will be working and be freezed until the process is completed, it will exhaust the .NET Thread Pool.
- This causes new request to wait in a queue, which can even stop the entire application.

### Asynchronous Operations 

- Asynchronous method provides non-blocking execution.
- For this a method has to be marked async indicating that the method can expect an await method call.
- When the code hits await, the thread will be released back to the thread pool, which can be used for some other processing.
- So, now the released thread can pick up some other application task.
- Therefore for a multi-threaded application, we need to asynchronous methods.

---

## SyncFileProcessor.cs

- Reads from file using FileStream as chunks of 1 MB.
- Write to memory, Convert the text data to upper-case, and then writes data to destination filestream.

Methods:

- void ProcessAndSaveFile(string sourceFilePath, string destinationFilePath)
- void ProcessMemoryStreamToUpperCase(MemoryStream memoryStream)
- void SaveFileToMemory(byte[] buffer, int bytesRead, MemoryStream memoryStream)
- void WriteMemoryToFile(MemoryStream memory, FileStream destinationStream)

---

## AsyncFileProcessor.cs

- Reads, processes data and writes to destination file asynchronously.

Methods:

- async Task ProcessAndSaveFileAsync(string sourceFilePath, string destinationFilePath)
- void ProcessMemoryStreamToUpperCase(MemoryStream memoryStream)
- async Task SaveFileToMemoryAsync(byte[] buffer, int bytesRead, MemoryStream memoryStream)
- async Task WriteMemoryToFile(MemoryStream memory, FileStream destinationStream)

---

## Program.cs

- Measures the execution time taken to for Synchronous and Asynchronous processes.

1. RunSynchronousFileProcessor() - Create 3 threads to process three files, start the threads and wait for it to complete concurrent processing synchronously.

2. RunAsynchronousFileProcessor() - Run 3 tasks to process 3 files and wait for it to complete concurrent processing asynchronously.

---

