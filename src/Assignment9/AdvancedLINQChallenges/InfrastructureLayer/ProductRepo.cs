using AdvancedLINQChallenges.Domain;

namespace AdvancedLINQChallenges.InfrastructureLayer
{
    public class ProductRepo
    {
        private readonly List<Product> _productList;

        public ProductRepo()
        {
            this._productList = new List<Product>();
        }

        public void CreateProduct(Product product)
        {
            this._productList.Add(product);
        }

        public IEnumerable<Product> ReturnAllProducts()
        {
            return this._productList;
        }
    }
}
