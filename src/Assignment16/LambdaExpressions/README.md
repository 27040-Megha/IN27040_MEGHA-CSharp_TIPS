# Assignment-16: C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 

## Task 4: Understanding and Using Lambda Expressions and Statements

Create a console application that uses lambda expressions and statements to filter and modify a collection of data. 

- Declare a list of integers. 

- Use a lambda expression with the Where LINQ method to filter out even numbers. 

- Use a lambda statement with the Select LINQ method to square the filtered numbers. 

- Print the resulting collection to the console. 

---

# Program.cs

## Methods: 

## FilterEvenNumbers(List&lt;int&gt; listOfIntegers)

- Filters even numbers from the list using WHERE
- Lamda Expression: (int number) => number % 2 == 0

## FindSquare(List&lt;int&gt; listOfIntegers)

- Returns the Square of list of integers using SELECT 
-  Lamda Expression: (int number) => number * number
	
## Main()

- Define List Of integers.
- Call FilterEvenNumbers and FindSquare methods.
- Print the result to console.