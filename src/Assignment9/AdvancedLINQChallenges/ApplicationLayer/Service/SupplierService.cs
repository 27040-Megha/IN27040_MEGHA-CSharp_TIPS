using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedLINQChallenges.Domain;
using AdvancedLINQChallenges.InfrastructureLayer;

namespace AdvancedLINQChallenges.ApplicationLayer.Service
{
    public class SupplierService
    {
        private readonly SupplierRepo _supplierRepo;

        public SupplierService(SupplierRepo supplierRepo)
        {
            this._supplierRepo = supplierRepo;
        }

        public void AddSupplier(Supplier supplier)
        {
            this._supplierRepo.CreateSupplier(supplier);
        }

        public IEnumerable<Supplier> FetchAllSuppliers()
        {
            return this._supplierRepo.ReturnAllSuppliers();
        }
    }
}
