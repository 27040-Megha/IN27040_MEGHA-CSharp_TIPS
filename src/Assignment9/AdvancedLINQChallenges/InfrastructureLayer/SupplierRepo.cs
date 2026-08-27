using AdvancedLINQChallenges.Domain;

namespace AdvancedLINQChallenges.InfrastructureLayer
{
    public class SupplierRepo
    {
        private readonly List<Supplier> _supplierList;

        public SupplierRepo()
        {
            this._supplierList = new List<Supplier>();
        }

        public void CreateSupplier(Supplier supplier)
        {
            this._supplierList.Add(supplier);
        }

        public IEnumerable<Supplier> ReturnAllSuppliers()
        {
            return this._supplierList;
        }
    }
}
