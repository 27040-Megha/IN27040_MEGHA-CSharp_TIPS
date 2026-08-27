using AdvancedLINQChallenges.Domain;

namespace AdvancedLINQChallenges.InfrastructureLayer
{
    /// <summary>
    /// Storage for List of products
    /// </summary>
    public class ProductRepo
    {
        private readonly List<Product> _productList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepo"/> class.
        /// </summary>
        public ProductRepo()
        {
            this._productList = new List<Product>();
        }

        /// <summary>
        /// Adds product to product repo.
        /// </summary>
        /// <param name="product">Product object</param>
        public void CreateProduct(Product product)
        {
            this._productList.Add(product);
        }

        /// <summary>
        /// Returns all products from repo
        /// </summary>
        /// <returns>List of product objects</returns>
        public IEnumerable<Product> ReturnAllProducts()
        {
            return this._productList;
        }
    }
}
