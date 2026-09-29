using ConsoleUtilities;
using ReadOnlyCollections.ApplicationLayer.Service;

namespace ReadOnlyCollections.PresentationLayer.View
{
    /// <summary>
    /// Contains all methods that interacts with the user by getting input and displaying expected outcome
    /// </summary>
    public class ConsoleOperations
    {
        private CollectionService _collectionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="collectionService">Service object</param>
        public ConsoleOperations(CollectionService collectionService)
        {
            this._collectionService = collectionService;
        }

        /// <summary>
        /// Initial method that is called from Program.cs
        /// </summary>
        public void Run()
        {
            this.SumOfArrayElements();
            this.SumOfListElements();
            this.SumOfQueueElements();
            var dictionaryOfElements = this._collectionService.GenerateDictionary();
            this.PrintDictionary(dictionaryOfElements);
        }

        private void SumOfArrayElements()
        {
            int[] intArray = { 1, 2, 3, 4, 5 };
            ConsoleLogger.WriteColorLine(string.Format(DisplayResource.ArraySum, this._collectionService.SumOfElements(intArray)), ConsoleColor.Cyan);
        }

        private void SumOfListElements()
        {
            var listOfElements = new List<int> { 1, 2, 3, 4, 5 };
            ConsoleLogger.WriteColorLine(string.Format(DisplayResource.ListSum, this._collectionService.SumOfElements(listOfElements)), ConsoleColor.Cyan);
        }

        private void SumOfQueueElements()
        {
            var queueOfElements = new Queue<int>();
            queueOfElements.Enqueue(1);
            queueOfElements.Enqueue(2);
            queueOfElements.Enqueue(3);
            queueOfElements.Enqueue(4);
            queueOfElements.Enqueue(5);
            ConsoleLogger.WriteColorLine(string.Format(DisplayResource.QueueSum, this._collectionService.SumOfElements(queueOfElements)), ConsoleColor.Cyan);
        }

        private void PrintDictionary(IReadOnlyDictionary<string, int> dictionaryOfElements)
        {
            ConsoleLogger.WriteColorLine(DisplayResource.DictionaryElementsHeading, ConsoleColor.Yellow);
            foreach (var element in dictionaryOfElements)
            {
                Console.WriteLine($"{element.Key} - {element.Value}");
            }
        }
    }
}
