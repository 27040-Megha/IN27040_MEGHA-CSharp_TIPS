namespace AdvancedLINQChallenges.Domain.DTO
{
    public struct FilteredProduct
    {
        public FilteredProduct(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
