using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ITenantRepository
    {
        Task<Tenant> CreateTenantAsync(TenantVM model);


        Task<IEnumerable<TenantVM>> GetTenant();

		 Task<IEnumerable<TenantVM>> GetTenantById(int tenantId);

        Task<bool> UpdateTenant(int tenantId, TenantVM model);

        Task<bool> DeleteTenant(int tenantId);
    }
}



     
