# Advanced LINQ Challenges in C# 
 
## Overview
 
Understand and use LINQ Queries to retrieve and manipulate data from different Data Structures.

---
	
##  Project Structure
```text
AdvancedLINQChallenges
│
├── Domain
│   └── Product.cs
│   └── Supplier.cs
|
├── InfrastructureLayer
│   └── ProductRepo.cs
│   └── SupplierRepo.cs
|
├── ApplicationLayer
│   └── Service
│      └── ProductService.cs
│      └── SupplierService.cs
│      └── QueryBuilder.cs
│
├── PresentationLayer
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

 
Task - 1:

- Filter products under the category "Electronics" with a price greater than $500 and select only ProductName and Price
- Sort the filtered products in descending order of price.
- Find the average price of these filtered products.

Task - 2:

- Group products by category and count the products in each category. Each group should also have the most expensive product in that category 
- Perform an inner join with a List of Suppliers to match products with their suppliers.

Task - 4:

- Optimized query to selects all products under the category "Books" and sorts them by price. 

Task - 5:

- Create a query builder utility that allows users to construct complex LINQ queries using a fluent API pattern.
- Support filtering, sorting, and joining data.
---

# Folder Structure
 
# Domain
 
## Product.cs

- Blueprint for product objects.

Properties

- int ProductId 
- string ProductName 
- decimal Price
- string Category

---
## Supplier.cs

- Blueprint for supplier objects.

Properties

- int SupplierId 
- string SupplierName 
- int ProductId

---
# InfrastructureLayer

## ProductRepo.cs

- Storage for List of products

Methods:

- CreateProduct()
- ReturnAllProducts()

---

## SupplierRepo.cs

- Storage for List of suppliers

Methods:

- CreateSupplier()
- ReturnAllSuppliers()
 
# ApplicationLayer

# Service
 
## ProductService.cs

- Performs all Business Logic and communicates with Product Repo.
 
Methods

- AddProduct(Product product) - Adds new product to Product Repository

- FetchAllProducts() - Fetches All Products from product repository.

- FilterProducts()  - Filter products under the category "Electronics" with a price greater than $500 select only ProductName and Price, sort the product in descending order of price.

- FindAveragePrice() - Calculates average price of the list of products

- GroupProductsByCategory() - Group products by category and count the products in each category, along with most expensive product in the category.

- MatchProductsWithSuppliers() - Map products with their suppliers

- SortProductsByPrice() -  Selects all products under the category "Books" and sorts them by price.

---

## SupplierService.cs

- Communicates with SupplierRepo and return Supplier data.

Methods:

- ReturnAllSuppliers()

---

## QueryBuilder.cs

- Contains methods that performs filtering, sorting and joining data by accepting Lambda expressions as input.

Methods

- Filter(LambdaExpression)
- Sort(LambdaExpression)
- Join(LambdaExpression)
- Execute()

---

# PresentationLayer

## View

## ConsoleOperations.cs
 
- Shows Output to User

Methods

- AddProducts()
- AddSuppliers()
- ViewFilteredProducts()
- DisplayAveragePrice()
- DisplayCategoryGroup()
- DisplaySuppliersOfProducts()
- DisplaySortedProductList()

---

 
## Program.cs
 
- Creates object for Infrastructure Layer, ApplicationLayer and PresentationLayer and inject their dependencies
---
---

# Task - 3:

- Find second highest number in the array.
- Find All unique pairs of numbers in the array that add up to a specified target. 

---
	
##  Project Structure
```text
Task3
├── ApplicationLayer
│   └── Service
│      └── ArrayService.cs
│
├── PresentationLayer
│   └── Helper
│       └── InputValidation.cs
│   └── View
│       └── ConsoleOperations.cs
│
└── Program.cs
```

---

# Folder Structure

# ApplicationLayer

# Service

## ArrayService.cs

- Contains business logic to find the result of the Task-3

Methods

- FindSecondHighest(int[] arr) - Returns the second highest number in the array.
- FindTargetSum(int[] arr, int target) - Returns All unique pairs of numbers in the array that add up to a specified target. 

# PresentationLayer

## View

## ConsoleOperations.cs

- Gets Input from User and displays output to user

Methods

- GetArrayInput()
- GetTargetValueInput()
- DisplaySecondHighestValue()
- DisplayTargetSumSubsets()

## Helper

## InputValidation.cs

- Validates if the given integer is Valid

Methods

- ValidateInteger(int number)

---

## Program.cs
 
- Creates object for ApplicationLayer and PresentationLayer and inject their dependencies
---