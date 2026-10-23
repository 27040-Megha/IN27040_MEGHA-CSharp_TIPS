## Assignment-17: Task 6 - Mocking Framework
 
 
Use Reflection to dynamically generate a mock object from an interface.
 
---

### Mock Interface - IDownloadable.cs

public string DownloadPdf()

public string DownloadDocx()

### Program.cs

1. Create assembly named DownloaderAssembly.
2. Create module named DownloaderModule.
3. Create a type - public class named BudgetReport.
4. Add interface implementaion to the type using AddInterfaceImplementation(typeof(IDownloadable)).
5. Using MethodBuilder, add the two methods to the class.
6. Create object at run-time and explicitly typecast the method and invoke during run-time.

---