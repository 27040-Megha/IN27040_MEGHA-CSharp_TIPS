namespace ReadOnlyCollections.ApplicationLayer.Service
{
    public class CollectionService
    {
        public int SumOfElements(IEnumerable<int> collection)
        {
            return collection.Sum();
        }

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
