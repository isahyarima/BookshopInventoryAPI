using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ISupplyStatusRepository
    {
        Task<SupplyStatus> CreateSupplyStatusAsync(SupplyStatusVM model);

        Task<SupplyStatusVM> GetSupplyStatus(int supplyStatusId, int tenantId);

        Task<IEnumerable<SupplyStatusVM>> GetSupplyStatus(int tenantId);

		 Task<IEnumerable<SupplyStatusVM>> GetSupplyStatusById(int supplyStatusId,int tenantId);

        Task<bool> UpdateSupplyStatus(int supplyStatusId, SupplyStatusVM model);

        Task<bool> DeleteSupplyStatus(int supplyStatusId);
    }
}



     
