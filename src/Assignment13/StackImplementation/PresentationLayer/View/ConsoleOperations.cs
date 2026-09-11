using System;
using ConsoleUtilities;
using InputValidator;
using StackImplementation.ApplicationLayer.Service;

namespace StackImplementation.PresentationLayer.View
{
    /// <summary>
    /// Contains all methods that interacts with the user by getting input and displaying expected outcome
    /// </summary>
    public class ConsoleOperations
    {
        private StringReversalService _stringReversalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="stringReversalService">Service Object</param>
        public ConsoleOperations(StringReversalService stringReversalService)
        {
            this._stringReversalService = stringReversalService;
        }

        /// <summary>
        /// Initial method that is called from Program.cs
        /// </summary>
        public void Run()
        {
            string word = this.GetWord();
            if (word == null)
            {
                return;
            }

            ConsoleLogger.WriteColorLine(DisplayResource.BeforeReversingTitle, ConsoleColor.Cyan);
            this.DisplayWord(word);
            var reversedWord = this.ReverseWord(word);
            ConsoleLogger.WriteColorLine(DisplayResource.AfterReversingTitle, ConsoleColor.Cyan);
            this.DisplayWord(reversedWord);
        }

        private string GetWord()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.PromptWord, ConsoleColor.Cyan);
            string word = Console.ReadLine();
            if (!StringValidator.ValidateString(word))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.InvalidWordFormat, ConsoleColor.Red);
                return null;
            }

            return word;
        }

        private void DisplayWord(string word)
        {
            Console.WriteLine(word);
        }

        private string ReverseWord(string word)
        {
            return this._stringReversalService.ReverseString(word);
        }
    }
}
