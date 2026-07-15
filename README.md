# Basic Contact Management System
 
A simple **C# Console Application** developed using a layered architecture to perform basic contact management operations. The application allows users to **Add, View, Search, Update, and Delete** contacts through an interactive console-based menu.
 
The project is structured to separate responsibilities across different layers. 
---
 
# Features
 
- Add a new contact
- View all contact details
- View Contact List(Names) sorted in alphabetical order
- Search contact by ID
- Update existing contact details by ID
- Delete a contact using ID
- Automatically generates a unique Contact ID using GUID
- Validating Email and Phone Number before adding to contacts and editing contact
 
---
 
# Project Structure

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
│
└── Program.cs
```
 
---
 
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
 
---
 
## Repository
 
The **Repository** layer acts as the application's data storage.
 
It contains:
 
- `List<ContactInfo>` to store all contacts in memory.
- Implementation of all CRUD operations:
  - Create (StoreInContactList())
  - Read (ReturnContactList())
  - Update (UpdateContactList())
  - Delete (DeleteContactFromRepo())
 
The repository is responsible only for storing and retrieving data.
 
---
 
## Services
 
The **Services** layer contains the application's business logic.
 
This layer:
-Receives requests from the View
-Communicates with the Repository to access or modify contact data
-Performs the required processing and returns data to View
 
It acts as the bridge between the user interface and the data storage layer.
 
---
 
## View
 
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
