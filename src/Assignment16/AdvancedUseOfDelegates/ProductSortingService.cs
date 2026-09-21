namespace AdvancedUseOfDelegates
{
    /// <summary>
    /// Delegate takes in two Product objects and returns an integer
    /// </summary>
    /// <param name="firstProduct">Product 1</param>
    /// <param name="secondProduct">Product 2</param>
    /// <returns>Integer indicating whether the instance precedes, follow or appears in the same position in the sort order</returns>
    public delegate int SortDelegate(Product firstProduct, Product secondProduct);

    /// <summary>
    /// Contains SortByName, SortByCategory, SortByPrice methods
    /// </summary>
    public class ProductSortingService
    {
        /// <summary>
        /// Compares two product's names
        /// </summary>
        /// <param name="firstProduct">Product 1</param>
        /// <param name="secondProduct">Product 2</param>
        /// <returns>Integer indicating whether the instance precedes, follow or appears in the same position in the sort order</returns>
        public static int SortByName(Product firstProduct, Product secondProduct)
        {
            return firstProduct.ProductName.CompareTo(secondProduct.ProductName);
        }

        /// <summary>
        /// Compares two product's category
        /// </summary>
        /// <param name="firstProduct">Product 1</param>
        /// <param name="secondProduct">Product 2</param>
        /// <returns>Integer indicating whether the instance precedes, follow or appears in the same position in the sort order</returns>
        public static int SortByCategory(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Category.CompareTo(secondProduct.Category);
        }

        /// <summary>
        /// Compares two product's Price
        /// </summary>
        /// <param name="firstProduct">Product 1</param>
        /// <param name="secondProduct">Product 2</param>
        /// <returns>Integer indicating whether the instance precedes, follow or appears in the same position in the sort order</returns>
        public static int SortByPrice(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Price.CompareTo(secondProduct.Price);
        }
    }
}
