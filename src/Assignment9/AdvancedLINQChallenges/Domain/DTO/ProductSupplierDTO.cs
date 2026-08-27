namespace AdvancedLINQChallenges.Domain.DTO
{
    public struct ProductSupplierDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
    }
}
