using ReadOnlyCollections.ApplicationLayer.Service;

namespace ReadOnlyCollections.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private CollectionService _collectionService;

        public ConsoleOperations(CollectionService collectionService)
        {
            this._collectionService = collectionService;
        }

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
            Console.WriteLine($"Sum of Array Elements: {this._collectionService.SumOfElements(intArray)}");
        }

        private void SumOfListElements()
        {
            var listOfElements = new List<int>();
            listOfElements.Add(1);
            listOfElements.Add(2);
            listOfElements.Add(3);
            listOfElements.Add(4);
            listOfElements.Add(5);
            Console.WriteLine($"Sum of List Elements: {this._collectionService.SumOfElements(listOfElements)}");
        }

        private void SumOfQueueElements()
        {
            var queueOfElements = new Queue<int>();
            queueOfElements.Enqueue(1);
            queueOfElements.Enqueue(2);
            queueOfElements.Enqueue(3);
            queueOfElements.Enqueue(4);
            queueOfElements.Enqueue(5);
            Console.WriteLine($"Sum of Queue Elements: {this._collectionService.SumOfElements(queueOfElements)}");
        }

        private void PrintDictionary(IReadOnlyDictionary<string, int> dictionaryOfElements)
        {
            Console.WriteLine("\nDictionary Elements");
            foreach (var element in dictionaryOfElements)
            {
                Console.WriteLine($"{element.Key} - {element.Value}");
            }
        }
    }
}
