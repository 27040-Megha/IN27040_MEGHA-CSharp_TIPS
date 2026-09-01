using System;
using CalculatorApp.ApplicationLayer.Service;

namespace CalculatorApp.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private readonly CalculatorService _calculatorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="calculatorService">Calculator Service object</param>
        public ConsoleOperations(CalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        public void Run()
        {
            Console.WriteLine("CALCULATOR APP");
            var expression = Console.ReadLine();
            var expressionResult = this._calculatorService.Evaluate(expression);
            if (expressionResult.IsSuccess)
            {
                Console.WriteLine(expressionResult.ResultData);
            }
            else
            {
                Console.WriteLine(expressionResult.Message);
            }
        }
    }
}
