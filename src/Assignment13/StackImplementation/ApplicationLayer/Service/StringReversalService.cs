using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackImplementation.ApplicationLayer.Service
{
    /// <summary>
    /// Contains business logic that reverses a string using Stack
    /// </summary>
    public class StringReversalService
    {
        private Stack<char> _letterStack = new Stack<char>();

        /// <summary>
        /// Reverse String
        /// </summary>
        /// <param name="word">string to be reversed</param>
        /// <returns>Reversed String</returns>
        public string ReverseString(string word)
        {
            this.PushToStack(word);
            return this.PopFromStack();
        }

        private void PushToStack(string word)
        {
            foreach (char character in word)
            {
                this._letterStack.Push(character);
            }
        }

        private string PopFromStack()
        {
            StringBuilder sb = new StringBuilder();
            while (this._letterStack.Any())
            {
                sb.Append(this._letterStack.Pop());
            }

            return sb.ToString();
        }
    }
}
