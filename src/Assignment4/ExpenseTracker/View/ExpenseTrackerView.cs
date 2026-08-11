using System;
using ExpenseTracker.Helper;
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
        private const int MaxAttempts = 3;

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
                bool isValidChoice = byte.TryParse(Console.ReadLine(), out userChoice);
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

        private (decimal amount, DateTime date, string description)? GetTransactionDetails()
        {
            var amountResult = this.GetValidAmount();
            if (!amountResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, amountResult.Message), ConsoleColor.Red);
                return null;
            }

            decimal amount = amountResult.AmountData;
            var dateResult = this.GetValidDate();
            if (!dateResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, dateResult.Message), ConsoleColor.Red);
                return null;
            }

            DateTime date = dateResult.DateData;
            var descriptionResult = this.GetValidString("Description");
            if (!descriptionResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, descriptionResult.Message), ConsoleColor.Red);
                return null;
            }

            string description = descriptionResult.StringData;
            return (amount, date, description);
        }

        private (decimal amount, DateTime date, string description, string source)? GetIncomeInput()
        {
            var inputDetails = this.GetTransactionDetails();
            if (inputDetails is null)
            {
                return null;
            }

            var sourceResult = this.GetValidString("Source");
            if (!sourceResult.IsSuccess)
            {
                return null;
            }

            string source = sourceResult.StringData;
            return (inputDetails.Value.amount, inputDetails.Value.date, inputDetails.Value.description, source);
        }

        private (decimal amount, DateTime date, string description, string category)? GetExpenseInput()
        {
            var inputDetails = this.GetTransactionDetails();
            if (inputDetails is null)
            {
                return null;
            }

            var categoryResult = this.GetValidString("Category");
            if (!categoryResult.IsSuccess)
            {
                return null;
            }

            string category = categoryResult.StringData;
            return (inputDetails.Value.amount, inputDetails.Value.date, inputDetails.Value.description, category);
        }

        private void AddIncomeRecord()
        {
            var incomeInputDetails = this.GetIncomeInput();
            if (incomeInputDetails is null)
            {
                return;
            }

            this._service.SaveIncome(incomeInputDetails.Value.amount, incomeInputDetails.Value.date, incomeInputDetails.Value.description, incomeInputDetails.Value.source);
            WriteColorLine(InputResource.IncomeAddedSuccess, ConsoleColor.Green);
        }

        private void AddExpenseRecord()
        {
            var expenseInputDetails = this.GetExpenseInput();
            if (expenseInputDetails is null)
            {
                return;
            }

            this._service.SaveExpense(expenseInputDetails.Value.amount, expenseInputDetails.Value.date, expenseInputDetails.Value.description, expenseInputDetails.Value.category);
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
            if (this._service.GetIncomeCount() == 0)
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
            if (this._service.GetExpenseCount() == 0)
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
            int transactionType = this.GetFinanceType();
            if (transactionType == 1)
            {
                if (this._service.GetIncomeCount() == 0)
                {
                    WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                    return;
                }

                int index = this.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.DeleteIncomeRecord(index);
            }
            else if (transactionType == 2)
            {
                if (this._service.GetExpenseCount() == 0)
                {
                    WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                    return;
                }

                int index = this.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.DeleteExpenseRecord(index);
            }
        }

        private int GetFinanceType()
        {
            Console.Write(InputResource.FinanceType);
            if (int.TryParse(Console.ReadLine(), out int type) && (type == 1 || type == 2))
            {
                return type;
            }
            else
            {
                WriteColorLine(InputResource.InvalidChoice, ConsoleColor.Red);
                return -1;
            }
        }

        private void EditRecord()
        {
            int transactionType = this.GetFinanceType();
            Console.WriteLine(InputResource.EditPrompt);
            if (transactionType == 1)
            {
                if (this._service.GetIncomeCount() == 0)
                {
                    WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                    return;
                }

                int index = this.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.EditIncomeRecord(index);
            }
            else if (transactionType == 2)
            {
                if (this._service.GetExpenseCount() == 0)
                {
                    WriteColorLine(InputResource.NoRecordFound, ConsoleColor.Yellow);
                    return;
                }

                int index = this.GetValidIndex();
                if (index == -1)
                {
                    return;
                }

                this.EditExpenseRecord(index);
            }
        }

        private void EditIncomeRecord(int index)
        {
            var newIncome = this.GetIncomeInput();
            if (newIncome is null)
            {
                return;
            }

            var editedResult = this._service.ModifyIncome(index, newIncome.Value.amount, newIncome.Value.date, newIncome.Value.description, newIncome.Value.source);
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
            var newExpense = this.GetExpenseInput();
            if (newExpense is null)
            {
                return;
            }

            var editedResult = this._service.ModifyExpense(index, newExpense.Value.amount, newExpense.Value.date, newExpense.Value.description, newExpense.Value.category);
            if (!editedResult.IsSuccess)
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, editedResult.Message), ConsoleColor.Red);
            }
            else
            {
                WriteColorLine(string.Format(InputResource.ResultMessage, editedResult.Message), ConsoleColor.Green);
            }
        }

        private int GetValidIndex()
        {
            Console.WriteLine(InputResource.PromptIndex);
            bool isValidIndex = int.TryParse(Console.ReadLine(), out int index);
            if (!isValidIndex || index < 1)
            {
                WriteColorLine(InputResource.InvalidIndex, ConsoleColor.Red);
                return -1;
            }

            return index - 1;
        }

        private Result GetValidAmount()
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write(InputResource.PromptAmount);
                var amountResult = InputValidator.ValidateAmount(Console.ReadLine());
                if (amountResult.IsSuccess)
                {
                    return amountResult;
                }

                WriteColorLine(string.Format(InputResource.MaximumAttempts, amountResult.Message, i, MaxAttempts), ConsoleColor.Yellow);
            }

            return new Result(false, "Max attempts reached for Amount entry");
        }

        private Result GetValidDate()
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write(InputResource.PromptDate);
                var dateResult = InputValidator.ValidateDate(Console.ReadLine());
                if (dateResult.IsSuccess)
                {
                    return dateResult;
                }

                WriteColorLine(string.Format(InputResource.MaximumAttempts, dateResult.Message, i, MaxAttempts), ConsoleColor.Yellow);
            }

            return new Result(false, "Max attempts reached for Date entry");
        }

        private Result GetValidString(string fieldName)
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write(string.Format(InputResource.PromptString, fieldName));
                var stringResult = InputValidator.ValidateString(Console.ReadLine(), fieldName);
                if (stringResult.IsSuccess)
                {
                    return stringResult;
                }

                WriteColorLine(string.Format(InputResource.MaximumAttempts, stringResult.Message, i, MaxAttempts), ConsoleColor.Yellow);
            }

            return new Result(false, $"Max attempts reached for {fieldName} entry");
        }
    }
}