namespace ReadOnlyCollections.ApplicationLayer.Service
{
    /// <summary>
    /// Contains business logic that performs operations using ReadOnly collection
    /// </summary>
    public class CollectionService
    {
        /// <summary>
        /// Calculates the sum of elements in the collection
        /// </summary>
        /// <param name="collection">IEnumerable collection</param>
        /// <returns>Sum of elements of collection</returns>
        public int SumOfElements(IEnumerable<int> collection)
        {
            return collection.Sum();
        }

        /// <summary>
        /// Creates a dictionary and returns the dictionary
        /// </summary>
        /// <returns>Dictionary as readonly</returns>
        public IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            var studentResult = new Dictionary<string, int>
            {
                { "23CSR129", 9 },
                { "23CSR130", 6 },
                { "23CSR131", 6 },
                { "23CSR132", 8 },
                { "23CSR133", 7 },
            };
            return studentResult;
        }

        /// <summary>
        /// Modifying IReadOnlyDictionary will throw a compiler error, because the IReadOnlyDictionary is read only, so can't be edited
        /// </summary>
        /// <param name="dictionaryOfElements">Readonly Dictionary of elements</param>
        // public void UpdateDictionaryElements(IReadOnlyDictionary<string, int> dictionaryOfElements)
        // {
        //    dictionaryOfElements["23CSR131"] = 5; // Throws CS0200: Property or indexer 'property' cannot be assigned to -- it is read only
        // }
    }
}
