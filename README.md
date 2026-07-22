<<<<<<< HEAD
# Basic Contact Management System
 
A simple **C# Console Application** developed using a layered architecture to perform basic contact management operations. The application allows users to **Add, View, Search, Update, and Delete** contacts through an interactive console-based menu.

# Features
 
- Add a new contact
- View all contact details
- View Contact List(Names) sorted in alphabetical order
- Search contact by ID
- Update existing contact details by ID
- Delete a contact using ID
- Automatically generates a unique Contact ID using GUID
- Validating Email and Phone Number before adding to contacts and editing contact
=======
# Banking System
 
A simple C# Console Application that demonstrates object-oriented programming concepts by implementing a Banking System. The application supports creating Savings and Checking accounts, depositing money, and withdrawing money.
>>>>>>> 2a1dbe3 (fix: Changed Interface bank Account to abstract class Bank Account for task-3)
 
---
 
# Project Structure
<<<<<<< HEAD

(IN27040_MEGHA-CSharp_TIPS -> src -> Assignment1 -> BasicContactManagement)
 
```
BasicContactManagement
│
├── Models
│   └── ContactInfo.cs
│
├── Repository
│   └── Repo.cs
│
├── Services
│   └── ContactManager.cs
│
├── View
│   └── ConsoleOperations.cs
│
├── Helper
│   └── EmailValidation.cs, PhoneNumberValidation.cs
=======
 
```
BankingSystem
│
├── Helper
│   └── FieldValidation.cs
│
├── Models
│   ├── BankAccount.cs
│   ├── SavingsAccount.cs
│   └── CheckingAccount.cs
│
├── Repository
│   └── BankRepository.cs
│
├── Services
│   └── BankingService.cs
│
├── View
│   └── BankingConsoleOperation.cs
>>>>>>> 2a1dbe3 (fix: Changed Interface bank Account to abstract class Bank Account for task-3)
│
└── Program.cs
```
 
---
 
<<<<<<< HEAD
# Folder Responsibilities
 
## Models
 
The **Models** folder contains the `ContactInfo` class, which represents the structure of a contact in the application.
 
Each contact contains:
 
- Contact ID (Automatically generated using GUID)
- Name
- Phone Number
- Email
- Note
 
The constructor initializes the contact object whenever a new contact is created.
=======
# Folder Description
 
## Helper
 
Contains helper methods used across the application.
 
| Class | Description |
|--------|-------------|
| **FieldValidation** | Validates account number, customer name and transaction amounts. |
 
---
 
## Models
 
Contains the account definitions.
 
| Class | Description |
|--------|-------------|
| **BankAccount** | Abstract Base Class defines common properties and methods for all bank accounts. |
| **SavingsAccount** | Implements a savings account with minimum balance validation during withdrawal. |
| **CheckingAccount** | Implements a checking account with normal deposit and withdrawal operations. |
>>>>>>> 2a1dbe3 (fix: Changed Interface bank Account to abstract class Bank Account for task-3)
 
---
 
## Repository
 
<<<<<<< HEAD
The **Repository** layer acts as the application's data storage.
 
It contains:
 
- `List<ContactInfo>` to store all contacts in memory.
- Implementation of all CRUD operations:
  - Create (StoreInContactList())
  - Read (ReturnContactList())
  - Update (UpdateContactList())
  - Delete (DeleteContactFromRepo())
 
The repository is responsible only for storing and retrieving data.
=======
Handles storage and retrieval of account data.
 
| Class | Description |
|--------|-------------|
| **BankRepository** | Stores bank accounts in a list and performs add, search and update operations. |
>>>>>>> 2a1dbe3 (fix: Changed Interface bank Account to abstract class Bank Account for task-3)
 
---
 
## Services
 
<<<<<<< HEAD
The **Services** layer contains the application's business logic.
 
This layer:
- Receives requests from the View
- Communicates with the Repository to access or modify contact data
- Performs the required processing and returns data to View
 
It acts as the bridge between the user interface and the data storage layer.
=======
Contains the business logic of the application.
 
| Class | Description |
|--------|-------------|
| **BankingService** | Creates accounts and performs deposit and withdrawal by interacting with the repository. |
>>>>>>> 2a1dbe3 (fix: Changed Interface bank Account to abstract class Bank Account for task-3)
 
---
 
## View
 
<<<<<<< HEAD
The **View** layer is responsible for all user interaction.
 
Its responsibilities include:
 
- Reading user input
- Displaying menus
- Showing results
- Displaying validation messages
- Calling the appropriate service methods based on the user's actions
 
---

## Helper
 
The **Helper** folder contains the `EmailValidationClass` class and `PhoneNumberValidationClass`, which validates whether the info given by user is valid or not.
 
- ContactManager calls Helper functions from AddContact() and EditContactDetails() in ContactManagerClass
- ValidateEmail() returns true if email is valid and contact will be successfully added
- Otherwise returns false and the contact will not be added.
- ValidatePhnNumber() returns true if phnNumber is valid and contact will be successfully added
- Otherwise returns false and the contact will not be added.
 
---
 
## Program.cs
 
`Program.cs` is the entry point of the application.
 
- It creates an object for ConsoleOperations(View).
- Using the object reference, DisplayAndHandlesMenu() is called which displays menu and based on the selected option, it calls the appropriate method to perform the requested operation.
 
---
 
# Application Flow
 
The application follows a simple layered flow:
 
```
User
   │
Program.cs
   │
ConsoleOperations (View)
   │
ContactManager (Services) -> EmailValidation, PhoneNumberValidation (Helper)
   │
Repo (Repository)
   │
List<ContactInfo>
```
 
### Execution Flow
 
1. **Program.cs** creates object for **ConsoleOperations** and calls DisplayAndHandlesMenu().
2. `DisplayAndHandlesMenu()` displays menu and calls the corresponding method in **ConsoleOperations** in View.
3. The View collects the required input from the user.
4. The request is passed to the **ContactManager** service.
5. The service performs the required business logic.
6. If data validation is needed, the service calls the **Helper**.
7. If data access is needed, the service calls the **Repository**.
8. The Repository performs the operation on the in-memory `List<ContactInfo>`.
9. The result is returned back through:
   - Repository → Service → View
10. Finally, the View displays the output to the user.
 
---
 
# Design Overview
 
This project follows a simple layered architecture where each component has a specific responsibility.
 
- **Model** defines the structure of the contact.
- **Repository** manages data storage.
- **Service** contains the business logic.
- **View** handles user interaction.
- **Helper** contains functions that helps Services like EmailValidation and PhoneNumberValidation.
- **Program** is the entry point of the application.
 
---
=======
Handles user interaction through the console.
 
| Class | Description |
|--------|-------------|
| **BankingConsoleOperation** | Displays menus, accepts user input, validates data and invokes service methods. |
 
---
 
## Program
 
| File | Description |
|------|-------------|
| **Program.cs** | Entry point of the application. Starts the banking menu. |
 
---
 
# MVC Overview
 
### Model
- Represents bank account data.
- Contains account properties and transaction logic.
- Includes `IBankAccount`, `SavingsAccount` and `CheckingAccount`.
 
### View
- Interacts with the user.
- Displays menus and messages.
- Collects and validates input.
 
### Service 
- Acts as the bridge between View and Repository.
- Executes business logic for account creation, deposit and withdrawal.
 
### Repository
- Maintains the collection of bank accounts.
- Performs data storage, retrieval and update operations.
 
---
 
>>>>>>> 2a1dbe3 (fix: Changed Interface bank Account to abstract class Bank Account for task-3)
