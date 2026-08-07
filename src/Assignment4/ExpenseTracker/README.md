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
├── Program.cs
```

---

Folder Structure
 
Models

Outside Interface, Declare delegate 
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
 
Interface defining CRUD operations for financial records `(IRepository<T>)`
 
- `event FinancialRecordHandler RecordHandler;`  (Whenever transaction is updated, the event is invoked by the BalanceTracker class which has subscribed to this event, and the methods to update the global balance(expense and income), total income and total expense will be executed according to transaction (Income/Expense) and the balance will be updated)
- Add(T record)
- Update(Guid id, T updatedRecord)
- Delete(Guid id)
- GetById(Guid id)
- GetAll()
---

FinancialRepository.cs  `(FinancialRepository<T>)`
 
Generic repository implementation that stores records and raises events after successful operations.
 
---
 
Services

IFinancialRecordService.cs
 
Defines business operations for income and expense management.
 
- AddIncome()
- UpdateIncome()
- DeleteIncome()
- GetIncomeById()
- GetAllIncome()
- AddExpense()
- UpdateExpense()
- DeleteExpense()
- GetExpenseById()
- GetAllExpenses()
- GetSummary()

---

FinancialRecordService.cs
 
Implements financial operations by interacting with the repositories.
 
---
BalanceTracking.cs
 
Subscribes to both Income and Expense Repository to manage the global balance, total income and total expense accurately

- Property (Summary Details): decimal CurrentBalance, decimal TotalIncome, decimal TotalExpense 
- BalanceTracking(IRepository<Income> incomeRepo, IRepository<Expense> expenseRepo) - Subscribe to the events 
- void HandleIncomeChanged(TransactionAction action, IFinancialRecord current, IFinancialRecord? old) - Update Summary on Add, Edit or Delete Income
- void HandleExpenseChanged(TransactionAction action, IFinancialRecord current, IFinancialRecord? old) - Update Summary on Add, Edit or Delete Expense

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
 
InputHelper.cs
 
Provides helper methods for reading and validating user input.
 
Methods
 
- ReadPositiveDecimal()
- ReadDate()
- ReadRequiredString()
- ReadGuid()
- ReadMenuChoice()
 
---
 
Program
 
Program.cs
 
- Creates object for Repository, Service and View  and inject their dependencies.
 