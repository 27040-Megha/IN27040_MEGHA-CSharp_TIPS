# Assignment-16: C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 

## Task  7: Implementing Advanced Pattern Matching

- Define a base class Shape with properties common to all shapes. 
- Define subclasses Circle, Rectangle, and Triangle, each with properties specific to that shape. 
- Implement a method CalculateArea in each subclass to calculate and return the area of the shape. 
- In your Main method, declare a list of Shape objects. 
- Implement a method DisplayShapeDetails that takes a Shape object and uses type patterns in a switch statement to match the shape's type. For each case, it should print the shape's details and area. Don't forget to handle the case where the shape is null or doesn't match any known types. 
- Call DisplayShapeDetails on each shape in your list.

---

## Shape.cs

- Base class contains common properties - Color, Area
- Abstract method: CalculateArea()

---

## Rectangle.cs

- Inherits from Shape class.
- Properties defined: Length, Width
- Overrides and provides definition for abstract method CalculateArea()

---

## Circle.cs

- Inherits from Shape class.
- Properties defined: Radius
- Overrides and provides definition for abstract method CalculateArea()

---

## Triangle.cs

- Inherits from Shape class.
- Properties defined: Base, Height
- Overrides and provides definition for abstract method CalculateArea()

---

## Hexagon.cs

- Doesn't inherit from Shape class
- For learning purpose to see what happens when an object type that is not of Shape is passed to method that accepts shape object

# Program.cs

## Methods

## void DisplayShapeDetails(Shape shape)

- Using switch statement, find the type of Shape object as Triangle, Rectangle, Cicrle or null
- And call method to print specific shape details

## void DisplayTriangleDetails(Triangle triangle)

- Prints triangle details

## void DisplayRectangleDetails(Triangle triangle)

- Prints rectangle details

## void DisplayCircleDetails(Triangle triangle)

- Prints circle details

## Main()

- Create a list of Shape objects with Circle, Rectangle, Triangle and null objects
- Call DisplayShapeDetails by passing each object in the list.
- Try to pass an Hexagon object in DisplayShapeDetails and you will see Compile-Time error CS1503