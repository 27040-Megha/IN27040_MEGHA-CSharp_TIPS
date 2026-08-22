Expense Tracker Application
 
Overview
 
A C# Expense Tracker Application that includes the functionality of tracking both expenses and income. This application aims to provide a user-friendly environment for individuals to manage their finances by monitoring their earnings and expenditures.
 
---

##  Project Structure
```text
ExpenseTracker
│
├── Models
│   ├── Expense.cs
│   ├── FinancialEventArgs.cs
│   ├── IFinancialRecord.cs
│   ├── Income.cs
│   ├── MenuOption.cs
│   └── Result.cs
│
├── Repository
│   ├── FinancialRepository.cs
│   └── IFinancialRepository.cs
│
├── Service
│   ├── BalanceTracker.cs
│   ├── FinancialEventPublisher.cs
│   ├── FinancialRecordService.cs
│   └── IFinancialRecordService.cs
│
├── View
│   ├── ExpenseTrackerView.cs
│   ├── InputResource.resx
│   └── InputValidator.cs
│
|── Program.cs
```

---

Folder Structure
 
Models

Outside Interface (IFinancialRecord), Declare enum for Transaction Action
- public enum TransactionAction { Added, Updated, Deleted }
 
IFinancialRecord.cs
 
 Properties:
  - TransactionID 
  - Amount
  - Date
  - Description
 
Income.cs
 
- Implements "IFinancialRecord" and defines string source property additionally
- Income(decimal amount, DateTime date, string description, string source) - Assigns values using Constructor
- Generates a unique "Guid" Transaction ID

Expense.cs
 
- Implements "IFinancialRecord" and defines string category property additionally
- Expense(decimal amount, DateTime date, string description, string category) - Assigns values using Constructor
- Generates a unique "Guid" Transaction ID

FinancialEventArgs.cs

- Data Class that holds Transaction Action(Add, Update, Delete) and IFinancial Records
- FinancialEventArgs class objects are used to invoke events

MenuOption.cs

- Enum for Menu Options to give in switch case

Result.cs

- Result Object to return Success/Failure Outcome 
- Properties: isSuccess, Message, AmountData, DateData, StringData
---
 
Repository
 
IRepository.cs
 
Interface defining CRUD operations for financial records 
 
- AddIncome(Income record)
- AddExpense(Expense record)
- UpdateIncome(Income oldRecord, Income newRecord)
- UpdateExpense(Expense oldRecord, Expense newRecord)
- DeleteIncome(Income record)
- DeleteExpense(Expense record)
- Income FindIncome(Guid id)
- Expense FindExpense(Guid id)
- IReadOnlyList&lt;Expense&gt; ReturnAllExpense()
- IReadOnlyList&lt;Income&gt; ReturnAllIncome()
---

FinancialRepository.cs  
 
Repository implementation for all the methods in the interface
 
---
 
Services

IFinancialRecordService.cs
 
Defines business operations for income and expense management.
 
- SaveIncome(decimal amount, DateOnly date, string description, string source)
- SaveExpense(decimal amount, DateOnly date, string description, string category)
- ModifyIncome(int index, decimal amount, DateOnly date, string description, string source)
- ModifyExpense(int index, decimal amount, DateOnly date, string description, string category)
- RemoveIncome(int index)
- RemoveExpense(int index)
- GetIncomeCount()
- GetExpenseCount()
- GetExpenseById()
- IReadOnlyList&lt;Expense&gt; GetAllExpense()
- IReadOnlyList&lt;Income&gt; GetAllIncome()

---

FinancialRecordService.cs
 
Implements financial service operations by interacting with the repositories.
 
---
FinancialEventPublisher.cs
 
 Event Publisher Class - Notifies the Subscribers when Income or Expense is Added/Updated/Deleted (Like a BroadCaster)

- Notify(object sender, FinancialEventArgs args)

---
BalanceTracking.cs
 
Manage the global balance, total income and total expense accurately

- Properties : BalanceAmount, TotalIncome, TotalExpense
- HandleFinancialRecordChange(object sender, FinancialEventArgs e)  - Subscribes to the FinancialEventPublisher and calls the HandleIncomeTransaction() or HandleExpenseTransaction() based on the object (income or expense) to update Summary details
- HandleIncomeTransaction(TransactionAction action, IFinancialRecord currentRecord, decimal oldAmount)
- HandleExpenseTransaction(TransactionAction action, IFinancialRecord currentRecord, decimal oldAmount)

---
 
View
 
ExpenseTrackerView.cs
 
Handles all console interactions with the user. Fetches text to display from resource file Resource.resx
 
Methods
 
- Run()
- DisplayMenu()
- AddIncome()
- AddExpense()
- EditIncome()
- EditExpense()
- DeleteIncome()
- DeleteExpense()
- ViewTotalIncome()
- ViewTotalExpense()
- ViewAllRecords()
- DisplayBalance()
 
InputValidator.cs
 
Provides helper methods for reading and validating user input.
 
Methods
 
- ValidateAmount(string input)
- ValidateDate(string input)
- ValidateString(string input, string fieldName)
 
---
 
Program
 
Program.cs
 
- Creates object for Repository, Service and View  and inject their dependencies.
- Subscriber subscribes to publisher's Event 
- (FinancialEventPublisher.FinancialRecordChangeHandler += BalanceTracker.HandleFinancialRecordChange)
 