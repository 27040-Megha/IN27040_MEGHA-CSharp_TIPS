using AdvancedLINQChallenges.Domain;

namespace AdvancedLINQChallenges.InfrastructureLayer
{
    /// <summary>
    /// Storage for List of suppliers
    /// </summary>
    public class SupplierRepo
    {
        private readonly List<Supplier> _supplierList;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierRepo"/> class.
        /// </summary>
        public SupplierRepo()
        {
            this._supplierList = new List<Supplier>();
        }

        /// <summary>
        /// Adds Supplier to supplier repo
        /// </summary>
        /// <param name="supplier">Supplier object</param>
        public void CreateSupplier(Supplier supplier)
        {
            this._supplierList.Add(supplier);
        }

        /// <summary>
        /// Returns all suppliers from list
        /// </summary>
        /// <returns>List of suppliers</returns>
        public IEnumerable<Supplier> ReturnAllSuppliers()
        {
            return this._supplierList;
        }
    }
}
