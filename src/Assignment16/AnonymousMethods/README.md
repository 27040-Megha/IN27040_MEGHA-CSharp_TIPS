# Assignment-16: C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 

## Task 3:  Implementing Anonymous Methods

Create a console application that uses an anonymous method to sort an array of integers in ascending order.

- Declare an array of integers. 

- Use the Array.Sort the method and provide an anonymous method for comparison.

- Print the sorted array to the console. 

---

# Program.cs

## Methods: 

## SortInAscendingOrder(int[] array)

- In Arrays.Sort(), pass array and an anonymous method 
```
	delegate(int a, int b)
	{
		return a.Compare(b);
	}
```
- Sorts the array in ascending order.

## SortInDescendingOrder(int[] array)

- In Arrays.Sort(), pass array and an anonymous method 
```
	delegate(int a, int b)
	{
		return b.Compare(a);
	}
```
- Sorts the array in descending order.

## DisplayArray(int[] array)

- Prints array elements

## Main()

- Create an integer array, Sort and print the array to Console.