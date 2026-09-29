# Assignment-16: C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 

## Task 5: Advanced Use of Delegates for Sorting 

Create a console application that demonstrates the use of delegates for complex sorting operations. 

- Create a Product class with properties Name, Category, and Price. 
- Declare a list of Product objects. 
- Create a delegate SortDelegate that takes in two Product objects and returns an integer. 
- Implement three methods SortByName, SortByCategory, and SortByPrice that take two Product objects and return an integer based on the comparison of the relevant properties. These methods will be compatible with the SortDelegate. 
- In the Main method, create instances of SortDelegate for each of the sorting methods. 
- Implement a method SortAndDisplay that takes a SortDelegate and a list of Product objects. This method should sort the list using the provided delegate and then print the sorted list to the console. 
- Call the SortAndDisplay method three times from the Main method, each time passing a different sorting delegate. 

---

## Product.cs

- Contains properties - ProductName, Category and Price.
- Constructor to assign the value of all properties.

---

## ProductSortService.cs

- Delegate: delegate int SortDelegate(Product firstProduct, Product secondProduct);

Methods:
1. int SortByName(Product firstProduct, Product secondProduct) - Compares ProductName using CompareTo method
2. int SortByCategory(Product firstProduct, Product secondProduct) - Compares Product Category using CompareTo method
3. int SortByPrice(Product firstProduct, Product secondProduct) - Compares Product Price using CompareTo method

---

## Program.cs

## SortAndDisplay(SortDelegate sortDelegate, List&lt;Product&gt; products)

- Sorts the list of products by using the sortDelegate.
- Displays the sorted product list.

---

## Main()

- Create a list of products.
- Create an instance for delegate and store each sorting method.
- Call SortAndDisplay by passing the delegate.
- Repeat this for all three sorting methods.

---