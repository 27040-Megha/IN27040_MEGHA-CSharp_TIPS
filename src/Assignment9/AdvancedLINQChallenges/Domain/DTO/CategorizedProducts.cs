namespace AdvancedLINQChallenges.Domain.DTO
{
    /// <summary>
    /// DTO for objects grouped by category 
    /// </summary>
    public struct CategorizedProducts
    {
        /// <summary>
        /// Gets or sets the value of category
        /// </summary>
        /// <value>
        /// Category of product
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the count of product in each category
        /// </summary>
        /// <value>
        /// Count of product in each category
        /// </value>
        public int ProductCount { get; set; }

        /// <summary>
        /// Gets or sets the most expensive product in each category
        /// </summary>
        /// <value>
        /// Most Expensive product in each category
        /// </value>
        public Product ExpensiveProduct { get; set; }
    }
}
