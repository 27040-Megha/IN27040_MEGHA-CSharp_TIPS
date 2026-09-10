using System;
using InputValidator;
using StackImplementation.ApplicationLayer.Service;

namespace StackImplementation.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private StringReversalService _stringReversalService;

        public ConsoleOperations(StringReversalService stringReversalService)
        {
            this._stringReversalService = stringReversalService;
        }

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
