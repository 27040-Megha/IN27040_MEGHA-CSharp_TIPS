using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.ApplicationLayer.Service;

namespace CalculatorApp.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private readonly MathUtility _mathUtility;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="mathUtility">MathUtility Object to access all methods in MathUtility class</param>
        public ConsoleOperations(MathUtility mathUtility)
        {
            this._mathUtility = mathUtility;
        }

        public void Run()
        {
            Console.WriteLine("CALCULATOR APP");
        }
    }
}
