using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ISupplierRepository
    {
        Task<Supplier> CreateSupplierAsync(SupplierVM model);

        Task<SupplierVM> GetSupplier(int supplierId, int tenantId);

        Task<IEnumerable<SupplierVM>> GetSupplier(int tenantId);

		 Task<IEnumerable<SupplierVM>> GetSupplierById(int supplierId,int tenantId);

        Task<bool> UpdateSupplier(int supplierId, SupplierVM model);

        Task<bool> DeleteSupplier(int supplierId);
    }
}



     
