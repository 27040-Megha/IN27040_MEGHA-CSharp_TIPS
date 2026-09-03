using AdvancedLINQChallenges.Domain;
using AdvancedLINQChallenges.InfrastructureLayer;

namespace AdvancedLINQChallenges.ApplicationLayer.Service
{
    /// <summary>
    /// Communicates with SupplierRepo and return Supplier data.
    /// </summary>
    public class SupplierService
    {
        private readonly SupplierRepo _supplierRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierService"/> class.
        /// </summary>
        /// <param name="supplierRepo">Supplier Repo</param>
        public SupplierService(SupplierRepo supplierRepo)
        {
            this._supplierRepo = supplierRepo;
        }

        /// <summary>
        /// Add Supplier to Supplier Repo
        /// </summary>
        /// <param name="supplier">Supplier Object</param>
        public void AddSupplier(Supplier supplier)
        {
            this._supplierRepo.CreateSupplier(supplier);
        }

        /// <summary>
        /// Returns all supplier details from Supplier Repo
        /// </summary>
        /// <returns>List of Supplier details</returns>
        public IEnumerable<Supplier> FetchAllSuppliers()
        {
            return this._supplierRepo.ReturnAllSuppliers();
        }
    }
}
