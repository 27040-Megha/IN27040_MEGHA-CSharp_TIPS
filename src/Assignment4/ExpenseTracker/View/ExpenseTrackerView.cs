using System;
using ExpenseTracker.Models;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    public class ExpenseTrackerView
    {
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
                        Console.WriteLine("Exiting App...");
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
            Console.WriteLine("Total Income:  " + BalanceTracker.TotalIncome);
            Console.WriteLine("Total Expense: " + BalanceTracker.TotalExpense);
            Console.WriteLine("Net Balance:   " + BalanceTracker.BalanceAmount);
        }

        private void AddIncome()
        {
            Console.Write("Enter Income amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            Console.Write("Enter Date (MM/DD/YYYY): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);
            Console.Write("Enter Description: ");
            string desc = Console.ReadLine();
            Console.Write("Enter Source: ");
            string source = Console.ReadLine();
            _service.AddIncome(amount, date, desc, source);
            Console.WriteLine("Income Record added successfully!");
        }

        private void AddExpense()
        {
            Console.Write("Enter Expense amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            Console.Write("Enter Date (MM/DD/YYYY): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);
            Console.Write("Enter Description: ");
            string desc = Console.ReadLine();
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            _service.AddExpense(amount, date, desc, category);
            Console.WriteLine("Expense Record added successfully!");
        }

        private void ViewAllRecords()
        {
            Console.WriteLine("\nIncome Records");
            foreach (var income in _service.GetAllIncome())
            {
                Console.WriteLine($"ID: {income.TransactionID} | Amt: {income.Amount} | Date: {income.Date.ToShortDateString()} | Description: {income.Description} | Source: {income.Source} ");
            }
            Console.WriteLine("\nExpense Records");
            foreach (var expense in _service.GetAllExpense())
            {
                Console.WriteLine($"ID: {expense.TransactionID} | Amt: {expense.Amount} | Date: {expense.Date.ToShortDateString()} | Description: {expense.Description} | Category: {expense.Category}");
            }
        }

        private void DeleteRecord()
        {
            Console.Write("Delete: 1.Income 2.Expense? ");
            if (int.TryParse(Console.ReadLine(), out int type))
            {
                Console.Write("Enter GUID: ");
                if (Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    if (type == 1)
                    {
                        _service.DeleteIncomeRecord(id);
                    }
                    else if (type == 2)
                    {
                        _service.DeleteExpenseRecord(id);
                    }

                    Console.WriteLine("Record processing complete.");
                    return;
                }
            }

            Console.WriteLine("Invalid target parameters handling cancellation.");
        }

        private void EditRecord()
        {
            Console.Write("Edit: 1.Income 2.Expense? ");
            if (int.TryParse(Console.ReadLine(), out int type))
            {
                Console.Write("Enter GUID: ");
                if (Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    Console.Write("New Amount: ");
                    decimal.TryParse(Console.ReadLine(), out decimal amount);
                    Console.Write("New Date: ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime date);
                    Console.Write("New Description: ");
                    string desc = Console.ReadLine();

                    if (type == 1)
                    {
                        Console.Write("New Source: "); string source = Console.ReadLine();
                        if (_service.UpdateIncome(id, amount, date, desc, source))
                        {
                            Console.WriteLine("Updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Record not found.");
                        }
                    }
                    else if (type == 2)
                    {
                        Console.Write("New Category: "); 
                        string category = Console.ReadLine() ?? "";
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
            }

            Console.WriteLine("Invalid Choice");
        }
    }
}
