# Assignment-15:  Working with Files and Streams in C# 

## Task 4: Analyze and Resolve Performance Issues with Logging System for Multiple Users.

```
    using System.IO;
    using System.Text;

    public class Logger
    {
        private static string _logFilePath = "log.txt";

        public static void LogError(string errorMessage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);

                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
        }
    }
```

# Issues identified in the given Logger code

## 1. Memory Issue - Physical memory overhead

- MemoryStream causes unnecessary overhead of memory usage.
- There is no need to encode the given error message to byte buffer and write to memory.
- And then write from memory to filestream.

## 2. System.IO.IOException

- Multiple users (Eg.100 threads) calls the LoggError method from main.
- 100 threads tries to access the same file at the same time.
- OS grants permission for the first thread and locks the file internally.
- When the other 99 threads try to access the same file, System.IO.IOException occur saying the file is already being used by another process.

## 3. Heap memory overhead

- FileStream access data only in bytes.
- This requires using a byte[] as a buffer to hold the errorMessage (Encoded in Byte format).
- Instead, StreamWriter can be used which can work with raw text data (Encoding is handled internally by itself).

---

## Solution 1: ThreadSafe Logger using Lock mechanism

```
    public class Logger
    {
        private static readonly object _fileLock = new ();
        private static string _logFilePath = "log.txt";
        public static void LogError(string errorMessage)
        {
            lock (_fileLock)
            {
                using (var writer = new StreamWriter(_logFilePath, append: true ))
                {
                    writer.WriteLine(errorMessage);
                }
            }
        }
    }

```

- This prevents application crashing because of System.IO.IOException.
- Lock acts like ordered queue - One thread enters the file, File is locked using lock mechanism.
- All remaining threads will wait to enter the file, until the currently executing thread completes its execution.

## Issue in this solution:

- Contention: When multiple threads (users) access same resource at the exact same time, the resource can handle only one request at a time.
- This decreases the performance of the application.

---

## Solution 2: Using Independent files to log each user's error message

```
    public class IndependentLogger
    {
        public static async Task LogErrorAsync(string userID, string errorMessage)
        {
            string logFile = $"User{userID}log.txt";
            using (var writer = new StreamWriter(logFile, append: true))
            {
                await writer.WriteLineAsync(errorMessage);
            }
        }
    }

```

- Instead of narrowing down access to single resource for 100 users, and making the thread wait for its turn to access the shared resource.
- We can have separate files for each individual user, to log their error message.
- This improves the performance of the application.

---

## Difference in Execution time between Lock mechanism(Same file) and Using multiple independent files for each user

Execution Time for Logging in Same file: 290 ms

Execution Time for Logging in Independent file: 101 ms

---