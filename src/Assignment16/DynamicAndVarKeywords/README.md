# Assignment-16: C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 

## Task 2: Understanding the Use of Dynamic and Var Keywords and Their Differences

Create a console application to demonstrate the differences between var and dynamic. 

- Use var to declare a variable and assign it a value. Attempt to change the variable's type after declaration and observe the result. 

- Use dynamic to declare a variable and assign it a value. Attempt to change the variable's type after declaration and observe the result. 
---

## Program.cs

## Main()

## var keyword

- The type of variables declared using var is determined during the compile time.

```

	var number = 5; // The type is checked at compile type and number will be of int type

	number = "five";
	// Changing type of var keyword throws Compile-Time Error  
	// ERROR CS0029 - Cannot implicitly convert type 'string' to 'int'    
	// This is because C# is a strongly typed language (Ensures type safety during Compile Time)

```

## dynamic keyword

- The type of variables declared using dynamic will be determined during the run-time.

```

	dynamic message = "Hi";
	message = 5;
	// So changing the type of value stored in dynamically defined variable is allowed in C#
	// But it is not a good practice

	Console.WriteLine(message.Length);
	// Finding the length of the message will be allowed during compile time
	// But this will cause Runtime exception and the code will crash as message doesn't hold a string value now, it holds an integer which can't use Length

```