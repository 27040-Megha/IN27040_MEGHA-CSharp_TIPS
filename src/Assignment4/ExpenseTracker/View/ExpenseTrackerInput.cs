using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Helper;
using ExpenseTracker.Models;
using ExpenseTracker.Models.Enums;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Class that defines methods to get valid inputs
    /// </summary>
    public static class ExpenseTrackerInput
    {
        private const int MaxAttempts = 3;

        /// <summary>
        /// Helper method to get a valid index as input from user
        /// </summary>
        /// <returns>valid index, otherwise -1</returns>
        public static int GetValidIndex()
        {
            Console.WriteLine(InputResource.PromptIndex);
            bool isValidIndex = int.TryParse(Console.ReadLine(), out int index);
            if (!isValidIndex || index < 1)
            {
                ExpenseTrackerView.WriteColorLine(InputResource.InvalidIndex, ConsoleColor.Red);
                return -1;
            }

            return index - 1;
        }

        /// <summary>
        /// Helper method to get valid amount as input from the user, provides three attempts for user to enter a valid amount
        /// </summary>
        /// <returns>Result object that contains isSuccess, Message and Valid Amount</returns>
        public static Result GetValidAmount()
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write(InputResource.PromptAmount);
                var amountResult = InputValidator.ValidateAmount(Console.ReadLine());
                if (amountResult.IsSuccess)
                {
                    return amountResult;
                }

                ExpenseTrackerView.WriteColorLine(string.Format(InputResource.MaximumAttempts, amountResult.Message, i, MaxAttempts), ConsoleColor.Yellow);
            }

            return new Result(false, "Max attempts reached for Amount entry");
        }

        /// <summary>
        /// Helper method to get valid Date as input from the user, provides three attempts for user to enter a valid date and should not be ahead of current date
        /// </summary>
        /// <returns>Result object that contains isSuccess, Message and Valid Date</returns>
        public static Result GetValidDate()
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write(InputResource.PromptDate);
                var dateResult = InputValidator.ValidateDate(Console.ReadLine());
                if (dateResult.IsSuccess)
                {
                    return dateResult;
                }

                ExpenseTrackerView.WriteColorLine(string.Format(InputResource.MaximumAttempts, dateResult.Message, i, MaxAttempts), ConsoleColor.Yellow);
            }

            return new Result(false, "Max attempts reached for Date entry");
        }

        /// <summary>
        /// Helper method to get valid String as input from the user, provides three attempts for user to enter a valid string
        /// </summary>
        /// <param name="fieldName">Could be Description or Source of Income or Category of Expense</param>
        /// <returns>Result object that contains isSuccess, Message and Valid StringData</returns>
        public static Result GetValidString(string fieldName)
        {
            for (int i = 1; i <= MaxAttempts; i++)
            {
                Console.Write(string.Format(InputResource.PromptString, fieldName));
                var stringResult = InputValidator.ValidateString(Console.ReadLine(), fieldName);
                if (stringResult.IsSuccess)
                {
                    return stringResult;
                }

                ExpenseTrackerView.WriteColorLine(string.Format(InputResource.MaximumAttempts, stringResult.Message, i, MaxAttempts), ConsoleColor.Yellow);
            }

            return new Result(false, $"Max attempts reached for {fieldName} entry");
        }

        /// <summary>
        /// Input method to get input required to create an income object
        /// </summary>
        /// <returns>Income object</returns>
        public static Income GetIncomeInput()
        {
            var inputDetails = GetTransactionDetails();
            if (inputDetails is null)
            {
                return null;
            }

            var sourceResult = ExpenseTrackerInput.GetValidString("Source");
            if (!sourceResult.IsSuccess)
            {
                return null;
            }

            string source = sourceResult.StringData;
            return new Income(Guid.NewGuid(), inputDetails.AmountData, inputDetails.DateData, inputDetails.StringData, source);
        }

        /// <summary>
        /// Input method to get input required to create an expense object
        /// </summary>
        /// <returns>Expense object</returns>
        public static Expense GetExpenseInput()
        {
            var inputDetails = GetTransactionDetails();
            if (inputDetails is null)
            {
                return null;
            }

            var categoryResult = ExpenseTrackerInput.GetValidString("Category");
            if (!categoryResult.IsSuccess)
            {
                return null;
            }

            string category = categoryResult.StringData;
            return new Expense(Guid.NewGuid(), inputDetails.AmountData, inputDetails.DateData, inputDetails.StringData, category);
        }

        /// <summary>
        /// Gets FinanceType (Income or Expense) as input from user
        /// </summary>
        /// <returns>Income or Expense or Unknown</returns>
        public static FinanceType GetFinanceType()
        {
            Console.Write(InputResource.FinanceType);
            if (int.TryParse(Console.ReadLine(), out int type) && (type == 1 || type == 2))
            {
                return (FinanceType)type;
            }
            else
            {
                ExpenseTrackerView.WriteColorLine(InputResource.InvalidChoice, ConsoleColor.Red);
                return FinanceType.Unknown;
            }
        }

        private static Result GetTransactionDetails()
        {
            var amountResult = ExpenseTrackerInput.GetValidAmount();
            if (!amountResult.IsSuccess)
            {
                ExpenseTrackerView.WriteColorLine(string.Format(InputResource.ResultMessage, amountResult.Message), ConsoleColor.Red);
                return null;
            }

            decimal amount = amountResult.AmountData;
            var dateResult = ExpenseTrackerInput.GetValidDate();
            if (!dateResult.IsSuccess)
            {
                ExpenseTrackerView.WriteColorLine(string.Format(InputResource.ResultMessage, dateResult.Message), ConsoleColor.Red);
                return null;
            }

            DateTime date = dateResult.DateData;
            var descriptionResult = ExpenseTrackerInput.GetValidString("Description");
            if (!descriptionResult.IsSuccess)
            {
                ExpenseTrackerView.WriteColorLine(string.Format(InputResource.ResultMessage, descriptionResult.Message), ConsoleColor.Red);
                return null;
            }

            string description = descriptionResult.StringData;
            return new Result(amount, date, description);
        }
    }
}
