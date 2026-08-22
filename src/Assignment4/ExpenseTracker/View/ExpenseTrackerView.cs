using System;
using ExpenseTracker.Models;
using ExpenseTracker.Models.Enums;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Handles all console interactions with the user. Fetches text to display from resource file InputResource.resx
    /// </summary>
    public class ExpenseTrackerView
    {
        private readonly IFinancialRecordService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerView"/> class.
        /// </summary>
        /// <param name="service">Service object</param>
        public ExpenseTrackerView(IFinancialRecordService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Prints the text in Specific Color
        /// </summary>
        /// <param name="text">Input string</param>
        /// <param name="colorChoice">Specific color of text to be displayed</param>
        public static void WriteColorLine(string text, ConsoleColor colorChoice)
        {
            Console.ForegroundColor = colorChoice;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Entry point of View (Called from Main)
        /// </summary>
        public void Run()
        {
            WriteColorLine(InputResource.WelcomeUser, ConsoleColor.Blue);
            byte userChoice;
            MenuOption menuChoice;
            do
            {
                this.DisplayMenu();
                var isValidChoice = byte.TryParse(Console.ReadLine(), out userChoice);
                if (!isValidChoice)
                {
                    menuChoice = MenuOption.Invalid;
                }
                else
                {
                    menuChoice = (MenuOption)userChoice;
                }

                switch (menuChoice)
                {
                    case MenuOption.AddIncome:
                        this.AddIncomeRecord();
                        break;
                    case MenuOption.AddExpense:
                        this.AddExpenseRecord();
                        break;
                    case MenuOption.ViewAllRecord:
                        this.ViewAllRecords();
                        break;
                    case MenuOption.DeleteRecord:
                        this.DeleteRecord();
                        break;
                    case MenuOption.EditRecord:
                        this.EditRecord();
                        break;
                    case MenuOption.ViewSummary:
                        this.ViewSummary();
                        break;
                    case MenuOption.Exit:
                        break;
                    default:
                        WriteColorLine(InputResource.InvalidChoice, ConsoleColor.Red);
                        break;
                }
            }
            while (menuChoice != MenuOption.Exit);
        }

        private void DisplayMenu()
        {
            Console.WriteLine(InputResource.Menu);
        }

        private void ViewSummary()
        {
            WriteColorLine(string.Format(InputResource.SummaryDetailsBlock, BalanceTracker.TotalIncome, BalanceTracker.TotalExpense, BalanceTracker.BalanceAmount), ConsoleColor.Blue);
        }

        private void AddIncomeRecord()
        {
            var incomeRecord = ExpenseTrackerInput.GetIncomeInput();
            if (incomeRecord is null)
            {
                return;
            }

            this._service.SaveIncome(incomeRecord);
            WriteColorLine(InputResource.IncomeAddedSuccess, ConsoleColor.Green);
        }

        private void AddExpenseRecord()
        {
            var expenseRecord = ExpenseTrackerInput.GetExpenseInput();
            if (expenseRecord is null)
            {
                return;
            }

            this._service.SaveExpense(expenseRecord);
            WriteColorLine(InputResource.ExpenseAddedSuccess, ConsoleColor.Green);
        }

        private void ViewAllRecords()
        {
            WriteColorLine(InputResource.IncomeRecordsHeader, ConsoleColor.Blue);
            this.ViewIncomeRecords();
            WriteColorLine(string.Format(InputResource.TotalIncome, BalanceTracker.TotalIncome), ConsoleColor.Blue);
            WriteColorLine(InputResource.ExpenseRecordsHeader, ConsoleColor.Blue);
            this.ViewExpenseRecords();
            WriteColorLine(string.Format(InputResource.TotalExpense, BalanceTracker.TotalExpense), ConsoleColor.Blue);
        }

        private void ViewIncomeRecords()
        {
            if (!this.HasIncomeRecord())
            {
                WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                return;
            }

            var income = this._service.GetAllIncome();
            for (int i = 0; i < income.Count; i++)
            {
                Console.WriteLine(string.Format(InputResource.IncomeRecordFormat, i + 1, income[i].Amount, income[i].Date.Date.ToString("d"), income[i].Description, income[i].Source));
            }
        }

        private void ViewExpenseRecords()
        {
            if (!this.HasExpenseRecord())
            {
                WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                return;
            }

            var expense = this._service.GetAllExpense();
            for (int i = 0; i < expense.Count; i++)
            {
               Console.WriteLine(string.Format(InputResource.ExpenseRecordFormat, i + 1, expense[i].Amount, expense[i].Date.Date.ToString("d"), expense[i].Description, expense[i].Category));
            }
        }

        private void DeleteIncomeRecord(int index)
        {
            var deleteResult = this._service.RemoveIncome(index);
            if (!deleteResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, deleteResult.Message), ConsoleColor.Red);
            }
            else
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, deleteResult.Message), ConsoleColor.Green);
            }
        }

        private void DeleteExpenseRecord(int index)
        {
            var deleteResult = this._service.RemoveExpense(index);
            if (!deleteResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, deleteResult.Message), ConsoleColor.Red);
            }
            else
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, deleteResult.Message), ConsoleColor.Green);
            }
        }

        private void DeleteRecord()
        {
            FinanceType transactionType = ExpenseTrackerInput.GetFinanceType();

            if (transactionType == FinanceType.Unknown)
            {
                return;
            }

            if (transactionType == FinanceType.Income)
            {
                if (!this.HasIncomeRecord())
                {
                    WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                    return;
                }

                int index = ExpenseTrackerInput.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.DeleteIncomeRecord(index);
            }
            else if (transactionType == FinanceType.Expense)
            {
                if (!this.HasExpenseRecord())
                {
                    WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                    return;
                }

                int index = ExpenseTrackerInput.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.DeleteExpenseRecord(index);
            }
        }

        private bool HasIncomeRecord()
        {
            return this._service.HasActiveIncome();
        }

        private bool HasExpenseRecord()
        {
            return this._service.HasActiveExpense();
        }

        private void EditRecord()
        {
            FinanceType transactionType = ExpenseTrackerInput.GetFinanceType();

            if (transactionType == FinanceType.Unknown)
            {
                return;
            }

            Console.WriteLine(InputResource.EditPrompt);

            if (transactionType == FinanceType.Income)
            {
                if (!this.HasIncomeRecord())
                {
                    WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                    return;
                }

                int index = ExpenseTrackerInput.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.EditIncomeRecord(index);
            }
            else if (transactionType == FinanceType.Expense)
            {
                if (!this.HasExpenseRecord())
                {
                   WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                   return;
                }

                int index = ExpenseTrackerInput.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.EditExpenseRecord(index);
            }
        }

        private void EditIncomeRecord(int index)
        {
            var newIncome = ExpenseTrackerInput.GetIncomeInput();
            if (newIncome is null)
            {
                return;
            }

            var editedResult = this._service.ModifyIncome(index, newIncome);
            if (!editedResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, editedResult.Message), ConsoleColor.Red);
            }
            else
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, editedResult.Message), ConsoleColor.Green);
            }
        }

        private void EditExpenseRecord(int index)
        {
            var newExpense = ExpenseTrackerInput.GetExpenseInput();
            if (newExpense is null)
            {
                return;
            }

            var editedResult = this._service.ModifyExpense(index, newExpense);
            if (!editedResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, editedResult.Message), ConsoleColor.Red);
            }
            else
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, editedResult.Message), ConsoleColor.Green);
            }
        }
    }
}