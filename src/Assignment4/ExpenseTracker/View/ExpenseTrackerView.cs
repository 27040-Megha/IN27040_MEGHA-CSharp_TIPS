using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int choice;
            do
            {
                DisplayMenu();
                bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);
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
                        UpdateFinancialRecord();
                        break;
                    case 4:
                        DeleteExpense();
                        break;
                    case 5:
                        DeleteIncome();
                        break;
                    case 6:
                        ViewAll();
                        break;
                    case 7:
                        ViewByID();
                        break;
                    case 8:
                        ViewBalance();
                        break;
                    case 9:
                        ViewIncome();
                        break;
                    case 10:
                        ViewExpense();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice, Enter a valid choice");
                        break;
                }
            }
            while (choice != 11);
        }

        private void ViewBalance()
        {
            Console.WriteLine("Balance Amount: " + _service.GetBalance());
        }

        private void AddIncome()
        {
            Console.WriteLine("Enter Income amount: ");
            bool isAmountValid = decimal.TryParse(Console.ReadLine(), out decimal amount);
            Console.WriteLine("Enter Date (e.g., MM/DD/YYYY): ");
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out DateTime date);
            Console.WriteLine("Enter Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Source: ");
            string source = Console.ReadLine();
            _service.AddIncome(amount, date, description, source);
        }

        private void AddExpense()
        {
            Console.WriteLine("Enter Expense amount: ");
            bool isAmountValid = decimal.TryParse(Console.ReadLine(), out decimal amount);
            Console.WriteLine("Enter Date (e.g., MM/DD/YYYY): ");
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out DateTime date);
            Console.WriteLine("Enter Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Category: ");
            string category = Console.ReadLine();
            _service.AddExpense(amount, date, description, category);
        }

        private void UpdateFinancialRecord()
        {
            throw new NotImplementedException();
        }

        private void DeleteExpense()
        {
            Console.WriteLine("Enter GUID of expense to be deleted: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                _service.DeleteExpenseRecord(id);
            }
            else
            {
                Console.WriteLine("Invalid GUID text formatting provided.");
            }
        }

        private void DeleteIncome()
        {
            Console.WriteLine("Enter GUID of income to be deleted: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                _service.DeleteIncomeRecord(id);
            }
            else
            {
                Console.WriteLine("Invalid GUID text formatting provided.");
            }
        }

        private void ViewAll()
        {
            ViewIncome();
            ViewExpense();
        }

        private void ViewIncome()
        {
            var incomeList = _service.GetAllIncome();
            foreach (var incomeTransaction in incomeList)
            {
                Console.WriteLine("Transaction ID:" + incomeTransaction.TransactionID);
                Console.WriteLine("Income Amount:" + incomeTransaction.Amount);
                Console.WriteLine("Date:" + incomeTransaction.Date);
                Console.WriteLine("Income Source:" + incomeTransaction.Source);
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }

        private void ViewExpense()
        {
            var expenseList = _service.GetAllExpense();
            foreach (var expenseTransaction in expenseList)
            {
                Console.WriteLine("Transaction ID:" + expenseTransaction.TransactionID);
                Console.WriteLine("Expense Amount:" + expenseTransaction.Amount);
                Console.WriteLine("Date:" + expenseTransaction.Date);
                Console.WriteLine("Expense Category:" + expenseTransaction.Category);
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }

        private void ViewByID()
        {
            Console.WriteLine("Enter 1.Income 2.Expense");
            int ch = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter GUID of record: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                if(ch==1)
                {
                    var incomeTransaction = _service.GetIncomeById(id);
                    if(incomeTransaction is null)
                    {
                        return;
                    }

                    Console.WriteLine("Transaction ID:" + incomeTransaction.TransactionID);
                    Console.WriteLine("Income Amount:" + incomeTransaction.Amount);
                    Console.WriteLine("Date:" + incomeTransaction.Date);
                    Console.WriteLine("Income Source:" + incomeTransaction.Source);
                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else if(ch==2)
                {
                    var expenseTransaction = _service.GetExpenseById(id);
                    if (expenseTransaction is null)
                    {
                        return;
                    }

                    Console.WriteLine("Transaction ID:" + expenseTransaction.TransactionID);
                    Console.WriteLine("Expense Amount:" + expenseTransaction.Amount);
                    Console.WriteLine("Date:" + expenseTransaction.Date);
                    Console.WriteLine("Expense Category:" + expenseTransaction.Category);
                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Enter Valid Choice");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid GUID text formatting provided.");
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine($"Welcome to Expense Tracker Application!\n1.Add Income \n2.Add Expense \n3.Update Financial Record\n4.Delete Expense record\n5.Delete Income Record\n6.View All Financial Records\n7.Find a financial record\n8.View Balance\n9.View Income\n10.View Expense\n11.Exit\nEnter Choice:");
        }
    }
}
