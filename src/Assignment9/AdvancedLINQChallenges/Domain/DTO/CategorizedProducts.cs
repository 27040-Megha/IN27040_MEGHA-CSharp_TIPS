namespace AdvancedLINQChallenges.Domain.DTO
{
    public struct CategorizedProducts
    {
        public string Category { get; set; }

        public int ProductCount { get; set; }

        public ProductSupplierDTO ExpensiveProduct { get; set; }
    }
}
