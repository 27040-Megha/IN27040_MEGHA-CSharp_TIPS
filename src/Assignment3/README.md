Inventory Management System
 
Overview
 
This is a C# Console Application developed using Object-Oriented Programming (OOP) concepts and the MVC architecture. The application manages an inventory of products by performing basic CRUD operations. 
 
---
 
Features
 
- Add Product
- Edit Product
- Delete Product
- Search Products by Name
- Search Products by ID
- View All Products
- Input Validation and Exception Handling
 
---

##  Project Structure
```text
InventoryManagement
│
├── Models
│   ├── IProduct.cs
│   └── Product.cs
│
├── Repository
│   └── IProductRepository.cs
|   └── ProductRepository.cs 
│
├── Services
│   └── IInventoryService.cs
|   └── InventoryService
│
├── View
│   ├── InventoryConsoleOperations.cs
│   └── FieldValidation.cs
|   └── InventoryResource.resx
│
└── Program.cs
```

---

Folder Structure
 
Models
 
IProduct.cs
 
- Defines the product properties:
  - ProductId
  - Name
  - Category
  - Price
  - StockQuantity
  - TotalPrice
 
Product.cs
 
- Implements "IProduct"
- Assigns product values using the constructor
 
---
 
Repository
 
IProductRepository.cs
 
Defines the operations that a product repository must provide.
 
The application can later replace the in-memory list with a database or file storage without changing the service logic.

---

ProductRepository.cs
 
Implements IProductRepository and performs data operations.
 
Methods
 
- AddProduct()
- EditProduct()
- DeleteProduct()
- FindProductById()
- FindProductsByName()
- GetAllProducts()
 
---
 
Services
 
InventoryService.cs
 
Contains the business logic and communicates with the repository through IProductRepository.
 
Methods
 
- AddProductDetails()
- EditProductDetails(()
- DeleteProductDetails(()
- FindProductById()
- GetProductsByName()
- GetAllProducts()
 
---
 
View
 
InventoryView.cs
 
Handles all console interactions with the user. Fetches text to display from respurce file InventoreResource.resx
 
Methods
 
- DisplayMenu()
- AddProduct()
- EditProduct()
- DeleteProduct()
- SearchProductsByName()
- UpdateStockQuantity
- ViewAllProducts()
- DisplayProduct()
- DisplayProducts()
 
InputHelper.cs
 
Provides helper methods for reading and validating user input.
 
Methods
 
- ValidateProductID()
- ValidateString()
 
---
 
Program
 
Program.cs
 
- Creates object for Repository, Service and View  and inject their dependencies through Constructor.
 