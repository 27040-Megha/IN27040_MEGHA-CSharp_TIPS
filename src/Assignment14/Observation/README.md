# Assignment-14: Project, Solutions and Build Orders

- Create Project A(GreetingsApp), Project B(MathApp), Project C(DisplayApp) and Project D(UtilityApp).
- Solution Dependencies:
	
	- A depends on B
	- B depends on C
	- C depends on D
- Build Order will be
```
	Project D (UtilityApp)
	Project C (DisplayApp)
	Project B (MathApp)
	Project A (GreetingsApp)
```

- Project A (GreetingsApp): Create a program that displays a greeting message. 
- Project B (MathApp): Define a class that contains methods to perform mathematical calculations of your choice. 
- Project C (DisplayApp): Create a program that utilizes the functionalities from Project B and displays the results. 
- Project D (UtilityApp): Implement utility functions or helper classes that can be used by other projects. 
- Project E (ManagerApp): Define any necessary dependencies for Project E within the solution.Project E should be built after Project C.

### CIRCULAR DEPENDECY ISSUE

- Adding project reference B in C, requires B to be built first.
- But already, we have created a solution dependency for B as C, which requires C to be built first.
- This creates a circular dependency issue, which is not allowed in Visual Studio.
---

### SOLUTION TO OVERCOME CIRCULAR DEPENDENCY ISSUE BY STILL FOLLOWING THE SAME DEPENDENCY STRUCTURE IN THE QUESTION

- Create an interface IMathUtility in the ProjectD (UtilityApp).
- Add ProjectD as project reference to ProjectB (MathApp) and create a class that implements IMathUtility.
- Now in ProjectC (DisplayApp), add ProjectD (IMathApp) as project reference and use its functionalities.
---

##  Project Structure
```text
CSharp_Assignments.sln
│
├── GreetingsApp (.exe)
│   |── Program.cs
│		└── Main()
│		└── DisplayGreetingsMessage()
│
├── UtilityApp (.dll)
│   |__ IMathUtility.cs
│
├── MathApp (.dll)
│   └── MathApp.cs
│
├── DisplayApp (.dll)
│   └── ConsoleOperator.cs
|
├── ManagerApp (.exe)
|   └── Program.cs
|   		└── Main()
```

---

### GreetingsApp (Project A)

#### Program.cs

Main()

- Call DisplayGreetingsMessage().

DisplayGreetingsMessage()

- Display Greetings message to the Console.

---

### UtilityApp (Project D)

#### IMathUtility.cs

- int Add(int value1, int value2)
- int Subtract(int value1, int value2)
- int Multiply(int value1, int value2)
- int Divide(int value1, int value2)

---

### MathApp (Project B)

- Add Project Reference - UtilityApp

#### MathUtility.cs 

- Implement IMathUtility interface and provide definition for Add, Subtract, Mulitiply and Divide methods.

---

### DisplayApp (Project C)

- Add project Reference - UtilityApp

#### ConsoleOperator.cs

- Create Interface object - ```IMathUtility _mathUtility```
- Constructor
```
	ConsoleOperator(IMathUtility mathutility)
	{
		this._mathUtility = mathUtility;
	}
```

Methods:
- void PerformArithmeticCalculations() - Displays Arithmetic Operation results.
- int GetInputNumbers() - Get two input numbers to perform Arithmetic Operations.
- void DisplayAdditionResult() - Call this._mathUtility.Add(number1, number2) and print the result to the console.
- void DisplaySubtractionResult() - Call this._mathUtility.Subtract(number1, number2) and print the result to the console.
- void DisplayMultiplicationResult() - Call this._mathUtility.Multiply(number1, number2) and print the result to the console.
- void DisplayDivisionResult() - Call this._mathUtility.Divide(number1, number2) and print the result to the console.

---

### ManagerApp (Project E)

- Add Project Reference - MathApp (Project B), DisplayApp (Project C)
- Create object for MathUtility Class.
- Create object for ConsoleOperator by passing MathUtility class object.
- Call PerformArithmeticCalculations() in ConsoleOperator class.

---

Add Solution Dependencies:

- GreetingsApp - MathApp
- MathApp - DisplayApp

Build Order:

1. UtilityApp
2. DisplayApp
3. MathApp
4. ManagerApp 
5. GreetingsApp

---