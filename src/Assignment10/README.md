# Assignment-10 : Understanding the .NET
 
## Overview
 
Create a simple C# console application Calculator App that performs Add, Subtract, Multiply and Divide operations.

---
	
##  Project Structure
```text
CalculatorApp
|
├── ApplicationLayer
│   └── Service
│      └── CalculatorService.cs
│      └── MathUtility.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│   └── Helper
│       └── InputValidation.cs
│
└── Program.cs
```

---

# Folder Structure
 
# ApplicationLayer

# Service

## CalculatrService

- Contains all business logic to solve a complex expression using BODMAS rule.

Methods

- EvaluateExpression()
- EvaluateDivide()
- EvaluateMultiply()
- EvaluateAdd()
- EvaluateSubtract()
 
## MathUtility.cs

- Static class and contains all Business logic to perform Calculator Operations.
 
Methods

- int Add(int number1, int number2) - Returns the sum of two integers
- int Subtract(int number1, int number2) - Returns the difference between two integers
- int Multiply(int number1, int number2) - Returns the product of two integers
- int Divide(int number1, int number2) - Checks if number2 is 0 and Returns the quotient

---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Shows Output to User

Methods

- void Run()
- string GetExpression()
- void DisplayResult()

## Helper
## InputValidation.cs
 
- Contains helper methods that validates user input

Methods

- bool ValidateString(string input) - Checks if string is not null or empty

---

 
## Program.cs
 
- Creates object for ApplicationLayer and PresentationLayer and inject their dependencies and start the application by using Run().
---