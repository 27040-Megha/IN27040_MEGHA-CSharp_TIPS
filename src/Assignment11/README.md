# Assignment-11 : Memory Management in C#
 
## Overview
 
Understand C# memory management - ValueType, ReferenceType, Stack, Heap, Garbage Collector, IDisposable and Using Statements. Complete tasks related to the tasks.

---

## Task 1

- Understanding and Using Value Types and Reference Types in C#.
- Define a value type and reference type.
- Create a method that takes both types as parameters and modifies them.
- Call the method and print the values of both types afterwards.

## Task 2

- Working with the Stack and the Heap.
- Create two methods: one that creates a large array of integers (a reference type), and another that performs a calculation with a large number of local variables (value types).
- Use a profiling tool, such as Visual Studio's Diagnostic Tools, to observe how memory is used when these methods are called. 
	
##  Project Structure
```text
ValueAndReferenceTypes
|
├── Domain
│   └── Model
│      └── Student.cs
│   └── Structs
│      └── StudentStruct.cs
|
├── ApplicationLayer
│   └── Service
│      └── UpdateService.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

# Folder Structure

# Domain

## Model

## Student.cs

- Class Definition for Student Model

Properties

- string RollNo
- string Name
- string Department
- byte YearOfStudy

## Structs

## StudentStruct.cs

- Structure Definition for Student

Properties

- string RollNo
- string Name
- string Department
- byte YearOfStudy

 
# ApplicationLayer

# Service
 
## UpdateService.cs

- Contains all Business logic to modify both value type and reference type using a single generic method.
 
Method

- void Modify `<T>`(T item) - Updates the Value of the item.

---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Shows Output to User

Methods

- void Run()
- void DisplayValueType()
- void DisplayReferenceType()
- void CreateArray() - Create a large array of integers.
- void CalculateSum() - Calculates Sum of multiple number of local variables.

---

## Program.cs
 
- Creates object for ApplicationLayer and PresentationLayer and inject their dependencies and start the application by using Run().
---

## Task 3

- Using Garbage Collection and Understanding Its Impact on Performance
- Create a method that creates and destroys a large number of objects in a for loop with large count.  
- Observe the memory usage of your application using a profiling tool. 
- Use GC.Collect to manually trigger garbage collection and observe the impact on memory usage. 	

##  Project Structure
```text
GarbageCollection
|
├── Domain
│   └── Model
│      └── Student.cs
│
└── Program.cs
```

---

# Folder Structure

## Student.cs

- Class Definition for Student Model

Properties

- string RollNo
- string Name
- string Department
- byte YearOfStudy


## Program.cs

- Create and destroy large number of objects in for loop upto int.MaxValue.
- Call GC.Collect()

---

## Task 4

- Implementing and understanding the IDisposable Interface and the 'using' Statement
- Create a class that opens a file for writing and implements the IDisposable interface. In the Dispose method, ensure that the file is properly closed and released. 
- Create an instance for the class in a using block.

##  Project Structure
```text
IDisposableDemo
|
├── InfrastructureLayer
│   └── FileRepository.cs
│
└── Program.cs
```

---

# Folder Structure

## FileRepository.cs

- Implement IDisposable

Methods

- void ReadFile()
- void WriteFile()
- void Dispose() - Close the file properly

## Program.cs

- Create an instance of FileRepository class in a 'using' block. Write some text to the file. 
- Open the same file for reading.
