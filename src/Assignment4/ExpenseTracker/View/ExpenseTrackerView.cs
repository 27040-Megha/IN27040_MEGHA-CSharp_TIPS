using System;
using ExpenseTracker.Models;
using ExpenseTracker.Service;
using ExpenseTracker.Validation;

namespace ExpenseTracker.View
{
    public class ExpenseTrackerView
    {
        private const int MaxAttempts = 3;

        private readonly IFinancialRecordService _service;

        public ExpenseTrackerView(IFinancialRecordService service)
        {
            this._service = service;
        }

        public static void WriteRedLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteGreenLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteYellowLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteBlueLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void Run()
        {
            WriteBlueLine(InputResource.WelcomeUser);
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
                    default:
                        WriteRedLine(InputResource.InvalidChoice);
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
            WriteBlueLine(string.Format(InputResource.SummaryDetailsBlock, BalanceTracker.TotalIncome, BalanceTracker.TotalExpense, BalanceTracker.BalanceAmount));
        }

        private (decimal amount, DateOnly date, string description)? GetUserInput()
        {
            var amountResult = this.GetValidAmount();
            if (!amountResult.IsSuccess)
            {
                WriteRedLine(string.Format(InputResource.ResultMessage, amountResult.Message));
                return null;
            }

            decimal amount = amountResult.AmountData;
            var dateResult = this.GetValidDate();
            if (!dateResult.IsSuccess)
            {
                WriteRedLine(string.Format(InputResource.ResultMessage, dateResult.Message));
                return null;
            }

            DateOnly date = dateResult.DateData;
            var descriptionResult = this.GetValidString("Description");
            if (!descriptionResult.IsSuccess)
            {
                WriteRedLine(string.Format(InputResource.ResultMessage, descriptionResult.Message));
                return null;
            }

            string description = descriptionResult.StringData;
            return (amount, date, description);
        }

        private (decimal amount, DateOnly date, string description, string source)? GetIncomeInput()
        {
            var inputDetails = this.GetUserInput();
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

        private (decimal amount, DateOnly date, string description, string category)? GetExpenseInput()
        {
            var inputDetails = this.GetUserInput();
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
            WriteGreenLine(InputResource.IncomeAddedSuccess);
        }

        private void AddExpenseRecord()
        {
            var expenseInputDetails = this.GetExpenseInput();
            if (expenseInputDetails is null)
            {
                return;
            }

            this._service.SaveExpense(expenseInputDetails.Value.amount, expenseInputDetails.Value.date, expenseInputDetails.Value.description, expenseInputDetails.Value.category);
            WriteGreenLine(InputResource.ExpenseAddedSuccess);
        }

        private void ViewAllRecords()
        {
            WriteBlueLine(InputResource.IncomeRecordsHeader);
            this.ViewIncomeRecords();
            WriteBlueLine(string.Format(InputResource.TotalIncome, BalanceTracker.TotalIncome));
            WriteBlueLine(InputResource.ExpenseRecordsHeader);
            this.ViewExpenseRecords();
            WriteBlueLine(string.Format(InputResource.TotalExpense, BalanceTracker.TotalExpense));
        }

        private void ViewIncomeRecords()
        {
            if (this._service.GetIncomeCount() == 0)
            {
                WriteYellowLine(InputResource.NoRecordFound);
                return;
            }

            var income = this._service.GetAllIncome();
            for (int i = 0; i < income.Count; i++)
            {
                Console.WriteLine(string.Format(InputResource.IncomeRecordFormat, i + 1, income[i].Amount, income[i].Date, income[i].Description, income[i].Source));
            }
        }

        private void ViewExpenseRecords()
        {
            if (this._service.GetExpenseCount() == 0)
            {
                WriteYellowLine(InputResource.NoRecordFound);
                return;
            }

            var expense = this._service.GetAllExpense();
            for (int i = 0; i < expense.Count; i++)
            {
               Console.WriteLine(string.Format(InputResource.ExpenseRecordFormat, i + 1, expense[i].Amount, expense[i].Date, expense[i].Description, expense[i].Category));
            }
        }

        private void DeleteIncomeRecord(int index)
        {
            var deleteResult = this._service.RemoveIncome(index);
            if (!deleteResult.IsSuccess)
            {
                WriteRedLine(string.Format(InputResource.ResultMessage, deleteResult.Message));
            }
            else
            {
                WriteGreenLine(string.Format(InputResource.ResultMessage, deleteResult.Message));
            }
        }

        private void DeleteExpenseRecord(int index)
        {
            var deleteResult = this._service.RemoveExpense(index);
            if (!deleteResult.IsSuccess)
            {
                WriteRedLine(string.Format(InputResource.ResultMessage, deleteResult.Message));
            }
            else
            {
                WriteGreenLine(string.Format(InputResource.ResultMessage, deleteResult.Message));
            }
        }

        private void DeleteRecord()
        {
            int transactionType = this.GetFinanceType();
            if (transactionType == 1)
            {
                if (this._service.GetIncomeCount() == 0)
                {
                    WriteYellowLine(InputResource.NoRecordFound);
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
                    WriteYellowLine(InputResource.NoRecordFound);
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
                WriteRedLine(InputResource.InvalidChoice);
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
                    WriteYellowLine(InputResource.NoRecordFound);
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
                    WriteYellowLine(InputResource.NoRecordFound);
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

            var isEditedResult = this._service.ModifyIncome(index, newIncome.Value.amount, newIncome.Value.date, newIncome.Value.description, newIncome.Value.source);
            if (!isEditedResult.IsSuccess)
            {
                WriteRedLine(string.Format(InputResource.ResultMessage, isEditedResult.Message));
            }
            else
            {
                WriteGreenLine(string.Format(InputResource.ResultMessage, isEditedResult.Message));
            }
        }

        private void EditExpenseRecord(int index)
        {
            var newExpense = this.GetExpenseInput();
            if (newExpense is null)
            {
                return;
            }

            var isEditedResult = this._service.ModifyExpense(index, newExpense.Value.amount, newExpense.Value.date, newExpense.Value.description, newExpense.Value.category);
            if (!isEditedResult.IsSuccess)
            {
                WriteRedLine(string.Format(InputResource.ResultMessage, isEditedResult.Message));
            }
            else
            {
                WriteGreenLine(string.Format(InputResource.ResultMessage, isEditedResult.Message));
            }
        }

        private int GetValidIndex()
        {
            Console.WriteLine(InputResource.PromptIndex);
            bool isValidIndex = int.TryParse(Console.ReadLine(), out int index);
            if (!isValidIndex || index < 1)
            {
                WriteRedLine(InputResource.InvalidIndex);
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

                WriteYellowLine(string.Format(InputResource.MaximumAttempts, amountResult.Message, i, MaxAttempts));
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

                WriteYellowLine(string.Format(InputResource.MaximumAttempts, dateResult.Message, i, MaxAttempts));
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

                WriteYellowLine(string.Format(InputResource.MaximumAttempts, stringResult.Message, i, MaxAttempts));
            }

            return new Result(false, $"Max attempts reached for {fieldName} entry");
        }
    }
}