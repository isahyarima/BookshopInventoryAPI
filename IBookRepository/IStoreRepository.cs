using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IStoreRepository
    {
        Task<Store> CreateStoreAsync(StoreVM model);

        Task<StoreVM> GetStore(int storeId, int tenantId);

        Task<IEnumerable<StoreVM>> GetStore(int tenantId);

		 Task<IEnumerable<StoreVM>> GetStoreById(int storeId,int tenantId);

        Task<bool> UpdateStore(int storeId, StoreVM model);

        Task<bool> DeleteStore(int storeId);
    }
}



     
