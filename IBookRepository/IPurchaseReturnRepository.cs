using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IPurchaseReturnRepository
    {
        Task<PurchaseReturn> CreatePurchaseReturnAsync(PurchaseReturnVM model);

        Task<PurchaseReturnVM> GetPurchaseReturn(int purchaseReturnId, int tenantId);

        Task<IEnumerable<PurchaseReturnVM>> GetPurchaseReturn(int tenantId);

		 Task<IEnumerable<PurchaseReturnVM>> GetPurchaseReturnById(int purchaseReturnId,int tenantId);

        Task<bool> UpdatePurchaseReturn(int purchaseReturnId, PurchaseReturnVM model);

        Task<bool> DeletePurchaseReturn(int purchaseReturnId);
    }
}



     
