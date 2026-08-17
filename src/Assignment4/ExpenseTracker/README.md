**Expense Tracker Application-II**
 
Overview
 
Enhanced Expense Tracker Application that includes the functionality of tracking both expenses and income alone with File storage. This application aims to provide a user-friendly environment for individuals to manage their finances by monitoring their earnings and expenditures.
 
---

##  Project Structure
```text
ExpenseTracker
│
├── Helper
│   └── InputValidator.cs
│
├── Models
│   ├── Enums
│   ├── BalanceTracker.cs
│   ├── Expense.cs
│   ├── FinancialEventArgs.cs
│   ├── FinancialRecord.cs
│   ├── Income.cs
│   ├── MonthlyFinancialReport.cs
│   └── Result.cs
│
├── Repository
│   ├── DataStorage
│   ├── FilePath.resx
│   ├── FileRepoService.cs
│   ├── FileRepository.cs
│   ├── FinancialRepository.cs
│   └── IFinancialRepository.cs
│
├── Service
│   ├── FinancialEventPublisher.cs
│   ├── FinancialRecordService.cs
│   └── IFinancialRecordService.cs
│
├── View
│   ├── ExpenseTrackerView.cs
│   ├── InputResource.resx
│   └── InputValidator.cs
│
└── Program.cs

```

---

Folder Structure
 
**Models**

Enums

- MenuOption.cs - Contains menu Options 
- TransactionAction - Contains Transaction Action such as Added, Updated and Deleted
---

BalanceTracker.cs

Manage the global balance, total income and total expenses.

Properties:
  - BalanceAmount
  - TotalIncome
  - TotalExpense
---

FinancialRecord.cs

 Abstract Base class for Financial Record that has a constructor to assign the common properties

 Properties:
 
 - TransactionID
 - Amount
 - Date
 - Description
---
 
Income.cs
 
- Inherits "FinancialRecord" and defines string source property additionally
- Income(decimal amount, DateTime date, string description, string source) : base(transactionID, amount, date, description) - Assigns values using Constructor
---
Expense.cs
 
- Inherits "FinancialRecord" and defines string category property additionally
- Expense(decimal amount, DateTime date, string description, string category) : base(transactionID, amount, date, description) - Assigns values using Constructor
---
FinancialEventArgs.cs

- Data Class that holds Transaction Action(Add, Update, Delete) and IFinancial Records
- FinancialEventArgs class objects are used to invoke events

Properties

- TransactionAction (Action such as Added, Deleted and Updated)
- CurrentRecord (Record that was added, deleted or Updated)
- OldAmount (Old record amount if the action was delete or Update)
---
MonthlyFinancialRecord.cs

-  Defines the monthly report for FinancialRecords - Used as DTO (Data Transfer Object) for the View Month-wise summary report

Properties

- Date
- Month
- Year
- TotalAmount
---
Result.cs

- Result Object to return Success/Failure Outcome 
- Properties: isSuccess, Message, AmountData, DateData, StringData
---
 
**Repository**
 
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
 
Repository implementation for all the methods in the interface using in-memory List
 
---
FileRepoService.cs  
 
- Helper method for file repository - Contains methods for Serialize and Deserialize and return List
- ReadFile&lt;T&gt;(string filePath)
- WriteFile&lt;T&gt;(List&lt;T&gt; financialRecords, string filePath)
- WriteSummaryFile(BalanceTracker balanceTracker, string filePath)

---
FileRepository.cs  
 
- Reads from File using FileRepoService and stores in the in-memory list objects and BalanceTracker object in the constructor.
- Repository implementation for all the methods in the interface using in-memory List.
- Writes Back to the file while Exit.
 
---
 
Services

IFinancialRecordService.cs
 
Defines business operations for income and expense management.
 
- SaveIncome(Income income)
- SaveExpense(Expense expense)
- ModifyIncome(int index, Income income)
- ModifyExpense(int index, Expense expense)
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
- ViewMonthWiseSummaryReport()
- DisplayBalance()
 
---
 
Program
 
Program.cs
 
- Creates object for Repository, Service and View  and inject their dependencies.
- Subscriber subscribes to publisher's Event 
- (FinancialEventPublisher.FinancialRecordChangeHandler += BalanceTracker.HandleFinancialRecordChange)
 