using System;
using ExpenseTracker.Models;
using ExpenseTracker.Service;
using ExpenseTracker.Validation;
using ExpenseTracker.Common;

namespace ExpenseTracker.View
{
    public class ExpenseTrackerView
    {
        private const int MaxAttempts = 3;

        private readonly IFinancialRecordService _service;

        public ExpenseTrackerView(IFinancialRecordService service)
        {
            _service = service;
        }

        public void Run()
        {
            byte choice;
            do
            {
                DisplayMenu();
                bool isValidChoice = byte.TryParse(Console.ReadLine(), out choice);
                if (!isValidChoice)
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        AddIncome();
                        break;
                    case 2:
                        AddExpense();
                        break;
                    case 3:
                        ViewAllRecords();
                        break;
                    case 4:
                        DeleteRecord();
                        break;
                    case 5:
                        EditRecord();
                        break;
                    case 6:
                        ViewSummary();
                        break;
                    case 7:
                        Console.WriteLine("App Exited");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice, Enter a valid choice");
                        break;
                }
            }
            while (choice != 7);
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Welcome to Expense Tracker Application");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View all Financial Records");
            Console.WriteLine("4. Delete Financial Record");
            Console.WriteLine("5. Edit Financial Record");
            Console.WriteLine("6. View Summary Report");
            Console.WriteLine("7. Exit");
            Console.Write("Enter Choice: ");
        }

        private void ViewSummary()
        {
            Console.WriteLine("\nSummary Details");
            Console.WriteLine("Total Income: " + BalanceTracker.TotalIncome);
            Console.WriteLine("Total Expense: " + BalanceTracker.TotalExpense);
            Console.WriteLine("Net Balance: " + BalanceTracker.BalanceAmount);
        }

        private void AddIncome()
        {
            Result amountResult = GetValidDecimal();
            if (!amountResult.IsSuccess)
            {
                return;
            }

            decimal amount = amountResult.DecimalData;
            Result dateResult = GetValidDate();
            if (!dateResult.IsSuccess)
            {
                return;
            }

            DateOnly date = dateResult.DateData;
            Result descResult = GetValidString("Description");
            if (!descResult.IsSuccess)
            {
                return;
            }

            string desc = descResult.StringData;

            Result sourceResult = GetValidString("Source");
            if (!sourceResult.IsSuccess)
            {
                return;
            }

            string source = sourceResult.StringData;
            _service.AddIncome(amount, date, desc, source);
            Console.WriteLine("Income Record added successfully!");
        }

        private void AddExpense()
        {
            Result amountResult = GetValidDecimal();
            if (!amountResult.IsSuccess)
            {
                return;
            }

            decimal amount = amountResult.DecimalData;
            Result dateResult = GetValidDate();
            if (!dateResult.IsSuccess)
            {
                return;
            }

            DateOnly date = dateResult.DateData;
            Result descResult = GetValidString("Description");
            if (!descResult.IsSuccess)
            {
                return;
            }

            string desc = descResult.StringData;
            Result categoryResult = GetValidString("Category");
            if (!categoryResult.IsSuccess)
            {
                return;
            }

            string category = categoryResult.StringData;
            _service.AddExpense(amount, date, desc, category);
            Console.WriteLine("Expense Record added successfully!");
        }

        private void ViewAllRecords()
        {
            Console.WriteLine("\nIncome Records");
            ViewIncomeRecords();
            Console.WriteLine("\nExpense Records");
            ViewExpenseRecords();
        }

        private void ViewIncomeRecords()
        {
            var income = _service.GetAllIncome();
            for (int i = 0; i < income.Count; i++)
            {
                Console.WriteLine($"Index: {i} | Amt: {income[i].Amount} | Date: {income[i].Date} | Description: {income[i].Description} | Source: {income[i].Source} ");
            }
        }

        private void ViewExpenseRecords()
        {
            var expense = _service.GetAllExpense();
            for (int i = 0; i < expense.Count; i++)
            {
                Console.WriteLine($"Index: {i} | Amt: {expense[i].Amount} | Date: {expense[i].Date} | Description: {expense[i].Description} | Source: {expense[i].Category} ");
            }
        }

        private void DeleteRecord()
        {
            Console.Write("Delete: 1.Income 2.Expense? ");
            if (int.TryParse(Console.ReadLine(), out int type) && (type == 1 || type == 2))
            {
                Result idResult = GetValidGuid();
                if (!idResult.IsSuccess)
                {
                    return;
                }

                Guid id = idResult.GuidData;
                if (type == 1)
                {
                    if (_service.DeleteIncomeRecord(id))
                    {
                        Console.WriteLine("Deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Record not found.");
                    }
                }
                else
                {
                    if (_service.DeleteExpenseRecord(id))
                    {
                        Console.WriteLine("Deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Record not found.");
                    }
                }

                return;
            }

            Console.WriteLine("Invalid Choice");
        }

        private void EditRecord()
        {
            Console.Write("Edit: 1.Income 2.Expense? ");
            if (int.TryParse(Console.ReadLine(), out int type) && (type == 1 || type == 2))
            {
                Result idResult = GetValidGuid();
                if (!idResult.IsSuccess) 
                {
                    return;
                }

                Guid id = idResult.GuidData;
                Result amountResult = GetValidDecimal();
                if (!amountResult.IsSuccess) 
                {
                    return;
                }

                decimal amount = amountResult.DecimalData;
                Result dateResult = GetValidDate();
                if (!dateResult.IsSuccess)
                {
                    return;
                }

                DateOnly date = dateResult.DateData;
                Result descResult = GetValidString("Description");
                if (!descResult.IsSuccess)
                {
                    return;
                }

                string desc = descResult.StringData;
                if (type == 1)
                {
                    Result sourceResult = GetValidString("Source");
                    if (!sourceResult.IsSuccess)
                    {
                        return;
                    }

                    string source = sourceResult.StringData;
                    if (_service.UpdateIncome(id, amount, date, desc, source))
                    {
                        Console.WriteLine("Updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Record not found.");
                    }
                }
                else
                {
                    Result categoryResult = GetValidString("Category");
                    if (!categoryResult.IsSuccess) 
                    {
                        return;
                    }

                    string category = categoryResult.StringData;
                    if (_service.UpdateExpense(id, amount, date, desc, category))
                    {
                        Console.WriteLine("Updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Record not found.");
                    }
                }

                return;
            }

            Console.WriteLine("Invalid Choice");
        }

        private Result GetValidDecimal()
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write("Enter Amount: ");
                Result result = InputValidator.ValidateAmount(Console.ReadLine());
                if (result.IsSuccess)
                {
                    return result;
                }
                Console.WriteLine($"{result.Message} (Attempt {i}/{MaxAttempts})");
            }
            return new Result(false, "Max attempts reached for Amount entry.");
        }

        private Result GetValidDate()
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write("Enter Date (YYYY/MM/DD/): ");
                Result result = InputValidator.ValidateDate(Console.ReadLine());
                if (result.IsSuccess)
                {
                    return result;
                }
                Console.WriteLine($"{result.Message} (Attempt {i}/{MaxAttempts})");
            }
            return new Result(false, "Max attempts reached for Date entry.");
        }

        private Result GetValidString(string fieldName)
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write($"Enter {fieldName}: ");
                Result result = InputValidator.ValidateString(Console.ReadLine(), fieldName);
                if (result.IsSuccess)
                {
                    return result;
                }

                Console.WriteLine($"{result.Message} (Attempt {i}/{MaxAttempts})");
            }

            return new Result(false, $"Max attempts reached for {fieldName} entry.");
        }

        private Result GetValidGuid()
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write("Enter GUID: ");
                Result result = InputValidator.ValidateGuid(Console.ReadLine());
                if (result.IsSuccess)
                {
                    return result;
                }

                Console.WriteLine($"{result.Message} (Attempt {i}/{MaxAttempts})");
            }

            return new Result(false, "Max attempts reached for GUID entry.");
        }
    }
}