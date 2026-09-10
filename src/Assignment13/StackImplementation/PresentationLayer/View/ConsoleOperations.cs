using System;
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

            Console.WriteLine("Before reversing: ");
            this.DisplayWord(word);
            var reversedWord = this.ReverseWord(word);
            Console.WriteLine("After reversing: ");
            this.DisplayWord(reversedWord);
        }

        private string GetWord()
        {
            Console.WriteLine("Enter Word: ");
            string word = Console.ReadLine();
            if (!StringValidator.ValidateString(word))
            {
                Console.WriteLine("Word should not be null or empty, and should contain only characters");
                return null;
            }

            return word;
        }

        private void DisplayWord(string word)
        {
            Console.WriteLine($"Word : {word}");
        }

        private string ReverseWord(string word)
        {
            return this._stringReversalService.ReverseString(word);
        }
    }
}
