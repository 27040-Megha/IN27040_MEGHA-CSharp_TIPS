using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackImplementation.ApplicationLayer.Service
{
    /// <summary>
    /// Contains business logic that reverses a string using Stack
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class StringReversalService<T>
    {
        private Stack<T> _letterStack;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReversalService{T}"/> class.
        /// </summary>
        public StringReversalService()
        {
            this._letterStack = new Stack<T>();
        }

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
            if (this._letterStack is Stack<char> charStack)
            {
                foreach (var character in word)
                {
                    charStack.Push(character);
                }
            }
        }

        private string PopFromStack()
        {
            var sb = new StringBuilder();
            while (this._letterStack.Any())
            {
                sb.Append(this._letterStack.Pop());
            }

            return sb.ToString();
        }
    }
}
