namespace AdvancedUseOfDelegates
{
    public delegate int SortDelegate(Product firstProduct, Product secondProduct);

    public class ProductSortService
    {
        public static int SortByName(Product firstProduct, Product secondProduct)
        {
            return firstProduct.ProductName.CompareTo(secondProduct.ProductName);
        }

        public static int SortByCategory(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Category.CompareTo(secondProduct.Category);
        }

        public static int SortByPrice(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Price.CompareTo(secondProduct.Price);
        }
    }
}
